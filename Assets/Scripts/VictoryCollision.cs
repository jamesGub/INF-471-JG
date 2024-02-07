using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCollision : MonoBehaviour
{
    public GameObject victoryMessageUI;
    public GameObject badVictoryMessageUI;
    

    private void Start()
    {
        if (victoryMessageUI != null)
        {
            victoryMessageUI.SetActive(false);
        }

         if (badVictoryMessageUI != null)
        {
            badVictoryMessageUI.SetActive(false);
        }
    }

    void Update()
    {
        CheckVictoryCondition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("VictorySpot"))
        {
            ShowVictoryMessage();
        }
    }

    void ShowVictoryMessage()
    {   
        int playerScore = Collectible.score;
    
        if (victoryMessageUI != null && playerScore >= 4)
        {
            victoryMessageUI.SetActive(true);
        } else if (playerScore < 4) { 
            badVictoryMessageUI.SetActive(true);
        }
    }

    void HideVictoryMessage()
    {
        if (victoryMessageUI != null)
        {
            victoryMessageUI.SetActive(false);
        }
        if (badVictoryMessageUI != null)
        {
            badVictoryMessageUI.SetActive(false);
        }
    }

    void CheckVictoryCondition()
    {
       
    }
}
