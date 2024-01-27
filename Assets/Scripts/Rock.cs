using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IInteractable {

    private Rigidbody rb;
    private Transform interactTransform;
    private bool isAttached;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (!isAttached) return;

        rb.MovePosition(interactTransform.position);
    }

    public void Interact(Transform interactTrasform) {
        if (isAttached) {
            this.interactTransform = null;
            DropRock();
        }
        else {
            this.interactTransform = interactTrasform;
            EquipRock();
        }
    }

    private void EquipRock() {
        isAttached = true;
    }

    private void DropRock() {
        isAttached = false;
    }
}
