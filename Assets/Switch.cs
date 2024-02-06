using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public PlayerController player1, player2;
    [SerializeField] private CinemachineVirtualCamera virtualCam;
    
    public static PlayerController current;

    // Start is called before the first frame update
    void Start()
    {
        current = player1;
        current.enable();
        virtualCam.Follow = player1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (current == player1)
            {
                player1.disable();
                player2.enable();
                //virtualCam.Follow = player2.transform;
                current = player2;
            } else
            {
                player1.enable();
                player2.disable();
                //virtualCam.Follow = player1.transform;
                current = player1;
            }

        }
    }
}
