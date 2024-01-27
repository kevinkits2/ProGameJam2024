using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour {

    public static DoorOpenTrigger Instance;

    public bool KeyInTrigger {
        get {
            return keyInTrigger;
        }
        private set {
            keyInTrigger = value;
        }
    }

    private bool keyInTrigger;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Door Open Trigger instance already exists!");
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent<Key>(out Key key)) {
            keyInTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.TryGetComponent<Key>(out Key key)) {
            keyInTrigger = false;
        }
    }
}
