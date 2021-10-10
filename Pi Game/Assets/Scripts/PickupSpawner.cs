using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    [SerializeField] int maxNumber = 10;
    [SerializeField] Vector3 tunnelSize = new Vector3(5f, 5f, 20f);
    [SerializeField] PrefabArray[] pickups;
    float[] prob;

    void Awake() {
        prob = new float[pickups.Length];
        for (int i = 0; i < pickups.Length; i++) {
            prob[i] = pickups[i].rarity;
        }
    }

    void Start() {
        int rand = Random.Range(0, maxNumber);
        for (int i = 0; i < rand; i++) {
            Vector3 spawnPos = new Vector3(Random.Range(-tunnelSize.x, tunnelSize.x), Random.Range(-tunnelSize.y, tunnelSize.y), Random.Range(-tunnelSize.z, tunnelSize.z));
            int randomizer = Choose(prob);
            GameObject pickup = Instantiate(pickups[randomizer].prefab, transform.position + spawnPos, Quaternion.identity);
            pickup.transform.parent = transform;
        }
    }

    int Choose(float[] probs) {
        float total = 0;

        foreach (float elem in probs) {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++) {
            if (randomPoint < probs[i]) {
                return i;
            }
            else {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
