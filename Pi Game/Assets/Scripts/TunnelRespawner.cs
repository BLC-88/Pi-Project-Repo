using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelRespawner : MonoBehaviour
{
    public Transform spawnPoint;

    TunnelSpawner tunnelSpawner;

    void Start()
    {
        tunnelSpawner = FindObjectOfType<TunnelSpawner>();
    }

    //When Exiting a tunnel, destroys it, Spawns another one in the front.
    private void OnTriggerExit(Collider other) 
    {
        RatController rat = other.GetComponent<RatController>();
        if (other != null) {
            tunnelSpawner.SpawnNextTunnel();
            Destroy(gameObject, 2f);
        }
    }
}
