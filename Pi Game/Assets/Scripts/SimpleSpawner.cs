using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour {

    [SerializeField] float startDelay = 10f;
    float delay;

    [SerializeField] int maxNum = 3;
    int spawned;
    [SerializeField] float spawnInterval = 1f;
    float spawnTime;
    [SerializeField] PrefabArray[] prefabs;
    float[] prob;

    void Start() {
        delay = startDelay;
        prob = new float[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++) {
            prob[i] = prefabs[i].rarity;
        }
    }

    void Update() {
        if (delay <= 0) {
            if (spawned < maxNum) {
                if (spawnTime <= 0) {
                    //Quaternion rot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
                    int ran = Choose(prob);
                    GameObject pref = Instantiate(prefabs[ran].prefab, transform.position, Quaternion.identity);
                    pref.transform.parent = transform;
                    spawned++;
                    spawnTime = spawnInterval;
                }
                spawnTime -= Time.deltaTime;
            }
        }
        delay -= Time.deltaTime;
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
