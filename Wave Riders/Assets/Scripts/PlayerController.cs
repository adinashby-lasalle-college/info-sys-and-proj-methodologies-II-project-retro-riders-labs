using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 playerPos;
    Vector3 startingPos;
    [SerializeField] Transform orientationCam;

    [SerializeField] private int moveSpeed = 2;
    float time;

    private void OnEnable()
    {
        InputManager.OnLeftInput += MoveLeft;
        InputManager.OnRightInput += MoveRight;
    }

    private void OnDisable()
    {
        InputManager.OnLeftInput -= MoveLeft;
        InputManager.OnRightInput -= MoveRight;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPos = rb.transform.position;
        startingPos = rb.transform.position;
    }

    private void Update()
    {
        playerPos = rb.transform.position;
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

    private void MoveLeft()
    {
        if (playerPos.x - 10 < startingPos.x - 12)
        {
            return;
        }
        else
        {
            playerPos.x -= 10;
            rb.MovePosition(playerPos);
        }
    }

    private void MoveRight()
    {
        if(playerPos.x + 10 > startingPos.x + 12)
        {
            return;
        }
        else
        {
            playerPos.x += 10;
            rb.MovePosition(playerPos);
        }
    }
}
