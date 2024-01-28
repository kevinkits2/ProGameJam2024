using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyInteract : MonoBehaviour {

    [SerializeField] private Transform interactTransform;
    [SerializeField] private float interactDistance = 2f;

    private Key currentInteractable;


    private void Start() {
        InputManager.Instance.OnInteractPerformed += HandleInteractPerformed;
    }

    private void FixedUpdate() {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * interactDistance, Color.white);
    }

    private void HandleInteractPerformed() {
        if (currentInteractable != null) {
            currentInteractable.Interact(interactTransform);
            currentInteractable = null;
            return;
        }

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * interactDistance, out RaycastHit hit)) {
            if (hit.collider.gameObject.TryGetComponent<Key>(out Key key)) {
                key.Interact(interactTransform);
                currentInteractable = key;
            }
        }
    }

}
