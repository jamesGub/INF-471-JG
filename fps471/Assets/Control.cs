using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Control : MonoBehaviour
{

    public GameObject camera;
    private float xRot = 0;
    private float yRot = 0;
    public float mouseSen = 100;
    public float moveSpeed;
    public GameObject bulletSpawner;
    public GameObject bullet; 
     

    private CharacterController controller;
    float mouseX;
    Vector2 movement;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>(); 
    }


    void Update()
    {
        camera.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);

        transform.Rotate(Vector3.up * mouseX);

        Vector3 moveDir = (transform.forward * movement.x) + (transform.right * movement.y); 
        controller.Move(moveDir * moveSpeed);
    }

    void OnLook(InputValue lookValue)
    {
        //Vector2 from lookValue
        Vector2 mouseLook = lookValue.Get<Vector2>();
        
        //Separate into x + y
        mouseX = mouseLook.x * Time.deltaTime * mouseSen;
        float mouseY = mouseLook.y * Time.deltaTime * mouseSen;

        //Use the Y for up and down rotation of camera
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);
        yRot -= mouseX;
        yRot = Mathf.Clamp(-90, yRot, 90);
    }

    void OnMove(InputValue moveValue)
    {
        movement = moveValue.Get<Vector2>(); 
    }

    void OnFire(InputValue moveValue)
    {
        Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }
}
