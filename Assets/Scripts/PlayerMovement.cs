using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float moveSpeed;

    private Rigidbody rb;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        Vector2 moveVector = InputManager.Instance.GetMoveVector();

        rb.velocity = Time.fixedDeltaTime * moveSpeed * new Vector3(moveVector.x, 0f, moveVector.y);
    }
}
