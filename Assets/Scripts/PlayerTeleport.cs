using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour {

    private enum TimelineState {
        Past,
        Future
    }

    [SerializeField] private Vector3 pastPosition;
    [SerializeField] private Vector3 futurePosition;

    private TimelineState currentTimelineState = TimelineState.Past;


    private void Start() {
        InputManager.Instance.OnTeleportPerformed += HandleTeleportPerformed;

        pastPosition = transform.position;
    }



    private void HandleTeleportPerformed() {
        if (TeleportFade.Instance.IsTeleporting) return;

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
        transform.position = futurePosition;

        TeleportFade.Instance.FadeOut();
    }

    private void TeleportToPast() {
        transform.position = pastPosition;

        TeleportFade.Instance.FadeOut();
    }
}
