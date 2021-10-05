using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawner : MonoBehaviour
{

    [SerializeField]  GameObject[] tunnelType;
    [SerializeField] float[] prob;
    int randomizer;

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
        GameObject temp = Instantiate(tunnelType[0], nextSpawnPoint, Quaternion.identity);
        //nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        nextSpawnPoint = temp.GetComponent<TunnelRespawner>().spawnPoint.position;
    }


    //Spawns Random Tunnel.
    public void SpawnNextTunnel()
    {
        //randomizer = Random.Range(0, tunnelTypes.Count);
        randomizer = Choose(prob);
        GameObject temp = Instantiate(tunnelType[randomizer], nextSpawnPoint, Quaternion.identity);
        //nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        nextSpawnPoint = temp.GetComponent<TunnelRespawner>().spawnPoint.position;

    }

    int Choose(float[] probs)
    {
        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
