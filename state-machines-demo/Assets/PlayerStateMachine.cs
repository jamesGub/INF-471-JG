using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private enum State
    {
        Idle,
        Run,
        Jump,
        Fall,
    }

    [SerializeField]
    private Animator playerAnim; 

    private State currentState;
    private PlayerMovement playerMovement;
    private float deadZone;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        SwitchState(State.Idle); 
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.ApplyGravity();
        print(currentState);
        print(playerMovement.moveInput); 
        switch (currentState)
        {
            case State.Idle:
                DoIdle();
                break;
            case State.Run:
                DoRun();
                break;
            case State.Jump:
                break;
            case State.Fall:
                break;
        }
    }

    private void SwitchState(State newState) 
    {
        if (newState == State.Idle)
        {
            playerAnim.ResetTrigger("Run"); 
            playerAnim.SetTrigger("Idle");
        } else if (newState == State.Run)
        {
            playerAnim.ResetTrigger("Idle");

            playerAnim.SetTrigger("Run");
        }
        currentState = newState;
    }

    private void DoIdle()
    {
        if(playerMovement.moveInput.magnitude >= deadZone)
        {
            SwitchState(State.Run);
        }
    }
    
    private void DoRun()
    {
        playerMovement.MovePlayer();
        if (playerMovement.moveInput.magnitude < deadZone)
        {
            SwitchState(State.Idle);
        }
    }
}
