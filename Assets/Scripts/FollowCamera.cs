using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public static FollowCamera Instance;

    public bool IsColliding {
        get {
            return isColliding;
        }
        private set {
            isColliding = value;
        }
    }

    [SerializeField] private float distanceFromCamera = 1.5f;

    private bool isColliding;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Follow Camera instance already exists!");
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Update() {
        transform.localPosition = Camera.main.transform.forward.normalized * distanceFromCamera;
        transform.localPosition = new Vector3(transform.localPosition.x, 1f, transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)) return;

        isColliding = true;
    }

    private void OnTriggerExit(Collider other) {
        isColliding = false;
    }
}
