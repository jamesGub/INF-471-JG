using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 


public class playerMove : MonoBehaviour
{
    public GameObject textMP;
    public GameObject endGameText; 
    private Vector2 movement;
    private Rigidbody rb;
    public int movementSpeed = 1;
    public int score;
    private TextMeshProUGUI textComp;
    bool gameRun; 



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textComp = textMP.GetComponent<TextMeshProUGUI>();
        score = 0;
        gameRun = true; 
    }

    void Update()
    {
        print("Update");
        if (score >= 5)
        {
            EndGame(); 
        }
    }

    void OnMove(InputValue moveVal)
    {
        if (gameRun)
        {
            movement = moveVal.Get<Vector2>();
            float movex = movement.x;
            float movey = movement.y;
            Vector3 movement3 = new Vector3(movex, 0.0f, movey);
            rb.AddForce(movement3 * movementSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            score += 1;
            textComp.text = score.ToString(); 
            other.gameObject.SetActive(false); 
            
        } else if (other.gameObject.CompareTag("Hazard"))  
        {
            Destroy(gameObject);
        }
    }

    void EndGame()
    {
        endGameText.SetActive(true);
        gameRun = false; 

    }
}
