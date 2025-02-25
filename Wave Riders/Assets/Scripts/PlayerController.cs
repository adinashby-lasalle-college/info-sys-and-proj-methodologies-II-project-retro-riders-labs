using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform orientationCam;

    [SerializeField] private int moveSpeed = 2;
    float time;

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
        //Get player position and lock it horizontally to the map
        CalculateTimePassed();
        Debug.Log(GetTimeMultiplier());

        Vector3 movement;
        movement = orientationCam.transform.forward * moveSpeed * GetTimeMultiplier();// + orientationCam.transform.right * InputManager.movementInput.x * moveSpeed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    private float GetTimeMultiplier()
    {
        float result;
        result = time / 10;
         
        if(result < 1) { return 1; }
        return result;
    }
    private float CalculateTimePassed()
    {
        time = Time.time;
        return time;
    }
}
