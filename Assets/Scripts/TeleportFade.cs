using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportFade : MonoBehaviour {

    private enum FadeType {
        FadeIn,
        FadeOut
    }

    public static TeleportFade Instance;

    public bool IsTeleporting {
        get {
            return isTeleporting;
        }
        private set {
            isTeleporting = value;
        }
    }

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeInDuration = 1f;
    [SerializeField] private float fadeOutDuration = 1f;

    private bool isTeleporting;
    private Action callback;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Teleport Fade instance already exists!");
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void FadeIn(Action callback) {
        this.callback = callback;
        StartCoroutine(FadeRoutine(1f, fadeInDuration, FadeType.FadeIn));
    }

    public void FadeOut() {
        StartCoroutine(FadeRoutine(0f, fadeOutDuration, FadeType.FadeOut));
    }

    private IEnumerator FadeRoutine(float targetAlpha, float fadeDuration, FadeType fadeType) {
        isTeleporting = true;

        float currentFadeTime = 0f;

        while (currentFadeTime < fadeDuration) {
            Color color = fadeImage.color;

            float newAlpha = Mathf.Lerp(color.a, targetAlpha, currentFadeTime / fadeDuration);
            color.a = newAlpha;
            fadeImage.color = color;

            currentFadeTime += Time.deltaTime;

            yield return null;
        }

        if (fadeType == FadeType.FadeIn) {
            StartCoroutine(FadeRoutine(0f, fadeOutDuration, FadeType.FadeOut));
            callback?.Invoke();
        }
        else if (fadeType == FadeType.FadeOut) {
            isTeleporting = false;
        }
    }
}
