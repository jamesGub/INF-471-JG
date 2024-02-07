using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public TMP_Text scoreCount; 
    public static int score; 

    void Start() { 
        score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectible"))
        {
            score += 1;
            
            UpdateScoreText();
            
            Destroy(other.gameObject);
        }
    }

    void UpdateScoreText()
    {
        if (scoreCount != null)
        {
            scoreCount.text = score.ToString();
        }
    }
}
