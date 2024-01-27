using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorldTextFade : MonoBehaviour {

    private PlayerControls playerControls;


    private void Start() {
        playerControls = InputManager.Instance.GetPlayerControls();

        playerControls.Player.Move.performed += HandleMovePerformed;
    }

    private void HandleMovePerformed(InputAction.CallbackContext obj) {

    }
}
