using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 5f;
    public float height = 7f;
    private Rigidbody rigid;

    private void Start() {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void Update() {
        if(Input.GetAxis("Horizontal") > 0) {
            rigid.AddForce(Vector3.right * speed);
        } else if (Input.GetAxis("Horizontal") < 0) { 
            rigid.AddForce(-Vector3.right * speed);
        } 

        if(Input.GetAxis("Vertical") > 0) { 
            rigid.AddForce(Vector3.forward * speed);
        } else if (Input.GetAxis("Vertical") < 0) { 
            rigid.AddForce(-Vector3.forward * speed);
    }
        if(Input.GetKeyDown(KeyCode.Space)) {
            rigid.velocity = new Vector3(0, height, 0);
        }
}
}