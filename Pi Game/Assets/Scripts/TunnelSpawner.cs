using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawner : MonoBehaviour
{

    public GameObject[] TunnelType;
    Vector3 nextSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            SpawnNextTunnel(); //Spawns 2 "Tunnels" to start with
        }
    }

    public void SpawnNextTunnel()
    {
        GameObject temp = Instantiate(TunnelType[0], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}
