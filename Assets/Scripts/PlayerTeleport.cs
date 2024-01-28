using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour {

    public static PlayerTeleport Instance;

    public enum TimelineState {
        Past,
        Future
    }

    [SerializeField] private Vector3 pastPosition;
    [SerializeField] private Vector3 futurePosition;

    private TimelineState currentTimelineState = TimelineState.Past;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Player Teleport instance already exists!");
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start() {
        InputManager.Instance.OnTeleportPerformed += HandleTeleportPerformed;

        pastPosition = transform.position;
    }



    private void HandleTeleportPerformed() {
        if (TeleportFade.Instance.IsTeleporting) return;
        if (!PlayerController.Instance.IsGrounded) return;

        if (currentTimelineState == TimelineState.Past) {
            pastPosition = transform.position;
            TeleportFade.Instance.FadeIn(TeleportToFuture);
        }
        else if (currentTimelineState == TimelineState.Future) {
            futurePosition = transform.position;
            TeleportFade.Instance.FadeIn(TeleportToPast);
        }
    }

    private void TeleportToFuture() {
        currentTimelineState = TimelineState.Future;
        transform.position = futurePosition;

        TeleportFade.Instance.FadeOut();
    }

    private void TeleportToPast() {
        currentTimelineState = TimelineState.Past;
        transform.position = pastPosition;

        TeleportFade.Instance.FadeOut();
    }

    public TimelineState GetCurrentTimelineState() {
        return currentTimelineState;
    }
}
