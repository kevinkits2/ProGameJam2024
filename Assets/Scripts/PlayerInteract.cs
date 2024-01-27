using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    [SerializeField] private Transform interactTransform;
    [SerializeField] private float interactDistance = 1f;


    private void Start() {
        InputManager.Instance.OnInteractHeld += HandleInteractPerformed;
    }

    private void HandleInteractPerformed() {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * interactDistance, out RaycastHit hit)) {
            if (hit.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)) {
                interactable.Interact(interactTransform);
            }
        }
    }
}
