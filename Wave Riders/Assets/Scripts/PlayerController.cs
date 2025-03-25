using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IChannel
{
    Rigidbody rb;
    Vector3 playerPos;
    Vector3 startingPos;
    [SerializeField] public Transform orientationCam;

    [SerializeField] public int moveSpeed = 2;
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
        HealthSystem.Singleton.AddObserver(this);
    }

    private void Update()
    {
        playerPos = rb.transform.position;
        //Get player position and lock it horizontally to the map
        CalculateTimePassed();

        Vector3 movement;
        movement = orientationCam.transform.forward * moveSpeed * GetTimeMultiplier();
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    public void Updates(int health)
    {
        if (health <= 50)
        {
            //moveSpeed /= 2;
            //Invoke("changeMoveSpeed",2);
        }
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

    private void changeMoveSpeed()
    {
        moveSpeed *= 2;
    }
}
