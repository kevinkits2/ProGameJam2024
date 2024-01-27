using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IInteractable {

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
            DropRock();
        }
        else {
            this.interactTransform = interactTrasform;
            EquipRock();
        }
    }

    private void EquipRock() {
        isAttached = true;

        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;

        colliderComponent.isTrigger = true;
    }

    private void DropRock() {
        isAttached = false;

        rb.useGravity = true;
        colliderComponent.isTrigger = false;
        StartCoroutine(RockDropRoutine());
    }

    private IEnumerator RockDropRoutine() {
        yield return new WaitForSeconds(0.1f);

        while (rb.velocity.y != 0f) {

            yield return null;
        }

        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
