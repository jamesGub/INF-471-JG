using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CINF496write : MonoBehaviour
{
    void Start() { 
        CheckValue(8); 
        CheckValue(3); 
    }
    void OnTriggerEnter (Collider oopsie)
    {
        if(oopsie.CompareTag("Player")) { 
            Oops();
        }
    }

    void Explode(GameObject explosiveObj) {
         Destroy(explosiveObj); 
    }

    void CheckValue(int big) { 
        if (big > 5) { 
            Debug.Log("BIG!");
        } else { 
            Debug.Log("Small :(");
        }
    }

    void Oops() { 
      Debug.Log("Oops!"); 
    }

   
}
