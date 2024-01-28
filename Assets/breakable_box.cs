using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable_box : MonoBehaviour
{

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        audioSource.Play();
        Destroy(transform.GetChild(0).gameObject);
    } 
}
