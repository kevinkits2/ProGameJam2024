using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform cameraTransform;


    private void Update() {
        Rotate();
    }

    private void Rotate() {
        Vector2 rotationVector = InputManager.Instance.GetLookVector();
        //Vector3 newRotation = 

        transform.Rotate(new Vector3());
    }
}
