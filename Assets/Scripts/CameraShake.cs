using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public static CameraShake Instance;

    [SerializeField] private CinemachineVirtualCamera virtualCam;
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeTime;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Camera Shake instance already exists!");
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void ApplyShake() {
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine() {
        CinemachineBasicMultiChannelPerlin shake = virtualCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        shake.m_AmplitudeGain = shakeIntensity;

        yield return new WaitForSeconds(shakeTime);

        shake.m_AmplitudeGain = 0f;
    }
}
