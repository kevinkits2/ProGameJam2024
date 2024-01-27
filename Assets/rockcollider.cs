using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockcollider : MonoBehaviour
{

    [SerializeField] GameObject rock1, rock2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        rock2.transform.position = transform.GetChild(0).transform.position;

    }
}
