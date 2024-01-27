using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IInteractable {

    [SerializeField] bool ignoreHeight;
    [SerializeField] float forceStrength;

    private Rigidbody rb;
    private Collider colliderComponent;
    private Transform interactTransform;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        colliderComponent = GetComponent<Collider>();
    }

    private void Update() {
    }

    public void Interact(Transform interactTransform) {
        Vector3 targetPoint = Vector3.Lerp(transform.position, interactTransform.position, 0.5f);
        Vector3 force = (targetPoint - transform.position) * forceStrength;
        if (ignoreHeight)
            force.y = 0;
        rb.AddForce(force, ForceMode.Impulse);
    }
}
