using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager Instance;

    public Action OnJumpPerformed;
    public Action OnTeleportPerformed;
    public Action OnInteractPerformed;
    public Action OnInteractHeld;

    private PlayerControls playerControls;
    private Vector2 moveVector;
    private Vector2 lookVector;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Input Manager instance already exists!");
            Destroy(gameObject);
        }

        Instance = this;

        playerControls = new PlayerControls();
        playerControls.Enable();

        playerControls.Player.Jump.performed += HandleJumpActionPerformed;
        playerControls.Player.Teleport.performed += HandleTeleportActionPerformed;
        playerControls.Player.Interact.performed += HandleInteractActionPerformed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void HandleInteractActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractPerformed?.Invoke();
    }

    private void HandleTeleportActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnTeleportPerformed?.Invoke();
    }

    private void HandleJumpActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnJumpPerformed?.Invoke();
    }

    private void Update() {
        SetMoveVector();
        SetLookVector();
        if (playerControls.Player.Interact.IsPressed())
            OnInteractHeld?.Invoke();
    }

    private void SetMoveVector() {
        Vector2 inputVector = playerControls.Player.Move.ReadValue<Vector2>();
        moveVector = inputVector.normalized;
    }

    public Vector2 GetMoveVector() {
        return moveVector;
    }

    private void SetLookVector() {
        Vector2 inputVector = playerControls.Player.Look.ReadValue<Vector2>();
        lookVector = inputVector.normalized;
    }

    public Vector2 GetLookVector() {
        return lookVector;
    }

    public PlayerControls GetPlayerControls() {
        return playerControls;
    }
}
