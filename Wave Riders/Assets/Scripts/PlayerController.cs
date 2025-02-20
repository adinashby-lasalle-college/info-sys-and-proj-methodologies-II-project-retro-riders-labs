using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform orientationCam;

    [SerializeField] private int moveSpeed = 2;

    private void OnEnable()
    {
        //Enable any 1 time inputs
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 movement;
        movement = orientationCam.transform.forward * moveSpeed; //+ orientationCam.transform.forward * InputManager.movementInput.x * moveSpeed; //* GetTimeMultiplier(); // + move left or right
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    private float GetTimeMultiplier()
    {
        
        return 0;
    }
}
