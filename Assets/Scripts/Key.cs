using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable {

    [SerializeField] private float forceAmount = 50f;

    private Rigidbody rb;
    private Collider colliderComponent;
    private Transform interactTransform;
    private bool isAttached;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        colliderComponent = GetComponent<Collider>();
    }

    private void Update() {
        if (!isAttached) return;
        if (FollowCamera.Instance.IsColliding) return;

        rb.MovePosition(interactTransform.position);
    }

    public void Interact(Transform interactTrasform) {
        if (isAttached) {
            this.interactTransform = null;
            Drop();
        }
        else {
            this.interactTransform = interactTrasform;
            Equip();
        }
    }

    private void Equip() {
        isAttached = true;
        rb.useGravity = false;
        colliderComponent.isTrigger = true;
    }

    private void Drop() {
        isAttached = false;
        rb.useGravity = true;
        colliderComponent.isTrigger = false;

        rb.AddForce(Camera.main.transform.forward * forceAmount, ForceMode.Impulse);
    }
}
