using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastPressurePlate : MonoBehaviour {

    [SerializeField] private Material originalMaterial;
    [SerializeField] private Material glowMaterial;
    [SerializeField] private GameObject pastSide;
    [SerializeField] private GameObject futureSide;

    public bool playerOnPlate;


    private void OnTriggerEnter(Collider other) {
        if (PlayerTeleport.Instance.GetCurrentTimelineState() != PlayerTeleport.TimelineState.Past) return;
        if (!other.gameObject.TryGetComponent<PlayerController>(out PlayerController player)) return;

        playerOnPlate = true;
        pastSide.GetComponent<MeshRenderer>().material = glowMaterial;
    }

    private void OnTriggerExit(Collider other) {
        if (PlayerTeleport.Instance.GetCurrentTimelineState() == PlayerTeleport.TimelineState.Future) return;
        if (!other.gameObject.TryGetComponent<PlayerController>(out PlayerController player)) return;

        playerOnPlate = false;
        pastSide.GetComponent<MeshRenderer>().material = originalMaterial;
    }

    public void SetFutureMaterial(Material material) {
        futureSide.GetComponent<MeshRenderer>().material = material;
    }
}
