using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager Instance;

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
    }

    private void Update() {
        SetMoveVector();
        SetLookVector();
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
}
