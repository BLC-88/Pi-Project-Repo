using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawner : MonoBehaviour
{
    [SerializeField] int maxNumberOfTunnels = 10;
    [SerializeField] int numberOfStartTunnels = 5;
    [SerializeField] TunnelType[] tunnelTypes;
    //[SerializeField] GameObject[] tunnelType;
    float[] prob;
    int randomizer;

    Vector3 nextSpawnPoint;
    Vector3 direction;

    void Awake() {
        prob = new float[tunnelTypes.Length];
        for (int i = 0; i < tunnelTypes.Length; i++) 
        {
            prob[i] = tunnelTypes[i].rarity;
        }
    }

    void Start()
    {
        nextSpawnPoint = transform.position;
        direction = transform.forward;
        for (int i = 0; i < numberOfStartTunnels - 1; i++)
        {
            SpawnEmptyTunnel(); //Spawns 5 "Empty Tunnels" to start with
        }
        for (int i = 0; i < maxNumberOfTunnels - numberOfStartTunnels - 1; i++) {
            SpawnNextTunnel(); //Spawns the rest of the tunnels
        }
    }

    //Spawns empty tunnels to start with
    public void SpawnEmptyTunnel()
    {
        GameObject temp = Instantiate(tunnelTypes[0].prefab, nextSpawnPoint, Quaternion.LookRotation(direction));
        nextSpawnPoint = temp.GetComponent<TunnelRespawner>().spawnPoint.position;
        direction = temp.GetComponent<TunnelRespawner>().spawnPoint.forward;
    }


    //Spawns Random Tunnel.
    public void SpawnNextTunnel()
    {
        //randomizer = Random.Range(0, tunnelTypes.Count);
        randomizer = Choose(prob);
        GameObject temp = Instantiate(tunnelTypes[randomizer].prefab, nextSpawnPoint, Quaternion.LookRotation(direction));
        nextSpawnPoint = temp.GetComponent<TunnelRespawner>().spawnPoint.position;
        direction = temp.GetComponent<TunnelRespawner>().spawnPoint.forward;

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

[System.Serializable]
public class TunnelType 
{
    public GameObject prefab;
    public float rarity;
}
