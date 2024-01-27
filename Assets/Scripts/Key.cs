using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable {

    [SerializeField] private float forceAmount = 50f;
    [SerializeField] private Animator doorAnimator;

    private Animator keyAnimator;
    private Rigidbody rb;
    private Collider colliderComponent;
    private Transform interactTransform;
    private bool isAttached;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        colliderComponent = GetComponent<Collider>();
        keyAnimator = GetComponent<Animator>();
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
        rb.isKinematic = false;
        colliderComponent.isTrigger = true;
    }

    private void Drop() {
        if (DoorOpenTrigger.Instance.KeyInTrigger && keyAnimator != null) {
            keyAnimator.SetTrigger("Open");
        }
        else {
            isAttached = false;
            rb.useGravity = true;
            rb.isKinematic = false;
            colliderComponent.isTrigger = false;

            rb.AddForce(Camera.main.transform.forward * forceAmount, ForceMode.Impulse);
        }
    }

    public void OpenDoorAnimationEvent() {
        if (doorAnimator == null) return;

        doorAnimator.SetTrigger("Open");
        Destroy(gameObject);
    }
}
