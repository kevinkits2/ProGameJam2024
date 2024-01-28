using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PressurePlateManager : MonoBehaviour {

    public enum Level {
        Level1,
        Level2
    }

    [SerializeField] private Transform level2SpawnPast;
    [SerializeField] private Transform level2SpawnFuture;

    [SerializeField] private Material glowMaterial;
    [SerializeField] private Material originalMaterial;

    [SerializeField] private PastPressurePlate pastPressurePlate;
    [SerializeField] private FuturePressurePlate futurePressurePlate;

    [SerializeField] private PastPressurePlate pastPressurePlate2;
    [SerializeField] private FuturePressurePlate futurePressurePlate2;

    private Level currentLevel = Level.Level1;


    private void Update() {
        if (pastPressurePlate.playerOnPlate && futurePressurePlate.playerOnPlate) {

            if (currentLevel == Level.Level1) {
                SetupLevel2();
            }
        }

        if (pastPressurePlate.playerOnPlate) {
            futurePressurePlate.SetPastMaterial(glowMaterial);
        }
        else if (!pastPressurePlate.playerOnPlate) {
            futurePressurePlate.SetPastMaterial(originalMaterial);
        }

        if (futurePressurePlate.playerOnPlate) {
            pastPressurePlate.SetFutureMaterial(glowMaterial);
        }
        else if (!futurePressurePlate.playerOnPlate) {
            pastPressurePlate.SetFutureMaterial(originalMaterial);
        }
    }

    private void SetupLevel2() {
        pastPressurePlate = pastPressurePlate2;
        futurePressurePlate = futurePressurePlate2;
        currentLevel = Level.Level2;

        PlayerTeleport.Instance.TeleportToLevel2(level2SpawnPast.position, level2SpawnFuture.position);
    }
}
