using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelDespowner : MonoBehaviour
{

    TunnelSpawner tunnelSpawner;

    // Start is called before the first frame update
    void Start()
    {
        tunnelSpawner = GameObject.FindObjectOfType<TunnelSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //When Exiting a tunnel, destroys it, Spawns another one in the front.
    private void OnTriggerExit(Collider other) 
    {
        tunnelSpawner.SpawnNextTunnel();
        Destroy(gameObject, 2);
    }
}
