using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    [SerializeField] private float cameraRotationSpeed;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float pitchMin;
    [SerializeField] private float pitchMax;

    private Vector2 XYRotation;

    private void Update() {
        Rotate();
    }

    private void Rotate() {
        Vector2 rotationVector = InputManager.Instance.GetLookVector().normalized;

        XYRotation.x -= cameraRotationSpeed * Time.deltaTime * rotationVector.y;
        XYRotation.y += playerRotationSpeed * Time.deltaTime * rotationVector.x;

        XYRotation.x = Mathf.Clamp(XYRotation.x, pitchMin, pitchMax);

        transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
        //cameraTransform.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);
    }
}
