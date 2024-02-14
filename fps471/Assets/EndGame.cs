using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
 
    public string endGameObjectTag = "Tresor-d'alien";

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag(endGameObjectTag))
        {
           
            EndGame();
        }
    }
    private void EndGame()
    {
        
        Debug.Log("Game Over!");
        
        SceneManager.LoadScene("GameOverScene");
    }
}


