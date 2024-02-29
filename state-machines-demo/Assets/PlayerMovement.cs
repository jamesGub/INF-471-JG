using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public CharacterController controller;
    [SerializeField]
    private float maxGravity;
    [SerializeField]
    private float gravityRate = 0.1f;
    [HideInInspector]
    private float speed = 10; 
    [HideInInspector]
    public Vector2 moveInput;
    private float currentY;
    public int rotationSpeed; 
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue moveValue)
    {
       moveInput = moveValue.Get<Vector2>();
    }

    public void ApplyGravity()
    {
        currentY -= gravityRate;
        currentY = Mathf.Clamp(currentY, maxGravity, 1); 
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(moveInput.x, currentY, moveInput.y);
        if(moveInput != Vector2.zero)
        {
            Vector3 lookVector = new Vector3(movement.x, 0, movement.z);
            Quaternion toRotation = Quaternion.LookRotation(lookVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed); 
        }
        controller.Move(movement * Time.deltaTime * speed);

    }
}
