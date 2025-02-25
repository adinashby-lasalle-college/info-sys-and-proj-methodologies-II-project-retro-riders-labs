using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager Singleton;
    /*
    private void Start()
    {
        AudioManager.Singleton.PlaySoundEffect("Background Music");
    }*/
    public void Awake()
    {
        controls = new PlayerControls();
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    public static PlayerControls controls;

    public static Vector2 movementInput;

    void OnEnable()
    {
        //Add individual A and D inputs
        controls.Player.Move.performed += Move;
        controls.Player.Move.canceled += Move;

        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Move.performed -= Move;
        controls.Player.Move.canceled -= Move;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
}

