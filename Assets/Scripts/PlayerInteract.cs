using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    [SerializeField] private Transform interactTransform;
    [SerializeField] private float interactDistance = 2f;

    private IInteractable currentInteractable;


    private void Start() {
        InputManager.Instance.OnInteractHeld += HandleInteractPerformed;
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
            if (hit.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)) {
                interactable.Interact(interactTransform);
                currentInteractable = interactable;
            }
        }
    }
}
