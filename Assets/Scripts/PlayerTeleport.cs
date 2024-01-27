using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour {

    private void Start() {
        InputManager.Instance.OnTeleportPerformed += HandleTeleportPerformed;
    }

    private void HandleTeleportPerformed() {
        if (TeleportFade.Instance.IsTeleporting) return;

        TeleportFade.Instance.FadeIn();
    }
}
