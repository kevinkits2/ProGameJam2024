using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance;

    public bool IsGrounded {
        get {
            return isGrounded;
        }
        private set {
            isGrounded = value;
        }
    }

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private Transform cameraTransform;
    private bool playerJumpedThisFrame;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Player Controller instance already exists!");
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start() {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;

        InputManager.Instance.OnJumpPerformed += HandlePlayerJumped;
    }

    private void HandlePlayerJumped() {
        playerJumpedThisFrame = true;
    }

    void Update() {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

        Vector2 moveVector = InputManager.Instance.GetMoveVector();
        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (playerJumpedThisFrame && isGrounded) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        playerJumpedThisFrame = false;
    }
}
