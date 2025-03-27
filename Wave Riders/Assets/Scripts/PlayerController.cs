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

    Vector3 newPos;
    private float lerpSpeed = 1f;

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
        //newPos = new Vector3(rb.position.x, rb.position.y, rb.position.z);
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


        //rb.position = Vector3.Lerp(rb.position, playerPos, lerpSpeed);

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

            /*while (rb.position.x != playerPos.x)
            {
               newPos.x = Mathf.Lerp(newPos.x, playerPos.x, lerpSpeed);
            } */


            //rb.transform.Translate(Vector3.left *Time.deltaTime * 1/2) ;

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
