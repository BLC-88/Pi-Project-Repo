using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour {

    [SerializeField] PrefabArray[] prefabs;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] int maxNum = 5;
    int count;
    float spawnTime;

    void Start() {
        spawnTime = spawnInterval;
    }

    void Update() {
        if (count < maxNum) {
            if (spawnTime <= 0) {
                spawnTime = spawnInterval;
                Quaternion randRot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
                GameObject pref = Instantiate(prefabs[0].prefab, transform.position, randRot);
                pref.transform.parent = transform;
                count++;
            }
            spawnTime -= Time.deltaTime;
            spawnTime = Mathf.Clamp(spawnTime, 0, spawnInterval);
        }
    }
}
