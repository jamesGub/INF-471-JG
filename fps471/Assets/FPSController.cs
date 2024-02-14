using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera cam;
    public GameObject bulletSpawnerPrefab; 
    public GameObject bulletPrefab;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    public float trajectory; 

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    bool move = true;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool run = Input.GetKey(KeyCode.LeftShift);
        float xSpeed = move ? (run ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float ySpeed = move ? (run ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * xSpeed) + (right * ySpeed);

        if (Input.GetButton("Jump") && move && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (move)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Fire bullet when left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

  void FireBullet()
{
    if (bulletSpawnerPrefab == null)
    {
        Debug.LogError("Bullet spawner prefab is not assigned!");
        return;
    }

    if (bulletPrefab == null)
    {
        Debug.LogError("Bullet prefab is not assigned!");
        return;
    }

    // Instantiate the bullet spawner at a fixed position relative to the player's position and rotation
    Vector3 bulletSpawnerPosition = transform.position + transform.forward * 1.0f; // Adjust the offset as needed
    GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawnerPosition, transform.rotation);

    Vector3 bulletSpawnerForward = bulletSpawner.transform.forward;

    GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.transform.position, Quaternion.LookRotation(bulletSpawnerForward));

    Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
    if (bulletRigidbody != null)
    {
        bulletRigidbody.AddForce(bulletSpawnerForward * bulletRigidbody.mass * trajectory);
    }

 
}

}