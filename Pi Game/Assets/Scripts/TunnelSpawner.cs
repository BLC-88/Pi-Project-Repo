using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawner : MonoBehaviour
{
    
    public  GameObject[] TunnelType;
    public int Randomizer;

    Vector3 nextSpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnEmptyTunnel(); //Spawns 5 "Tunnels" to start with
        }
    }

    //Spawns 2 empty tunnels to start with.
    public void SpawnEmptyTunnel()
    {
        GameObject temp = Instantiate(TunnelType[0], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }


    //Spawns Random Tunnel.
    public void SpawnNextTunnel()
    {
        Randomizer = Random.Range(0, TunnelType.Length);
        GameObject temp = Instantiate(TunnelType[Randomizer], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}
