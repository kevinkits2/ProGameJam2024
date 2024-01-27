using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorObject : MonoBehaviour {

    [SerializeField] private Transform originalObject;
    [SerializeField] private Vector3 offset;


    private void Update() {
        transform.position = originalObject.position + offset;
        transform.rotation = originalObject.rotation;
    }
}
