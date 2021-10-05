using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    [SerializeField] float waveAmplitude = 1f;
    [SerializeField] float waveLength = 2f;
    [SerializeField] float waveSpeed = 1f;
    public Vector3 direction = new Vector3(1, 0, 0);
    public float currentSpeed = 0.5f;

    float offset = 0f;

    void Update() {
        offset += Time.deltaTime * waveSpeed;
    }
    /*
    public float GetWaveHeight(float x) {
        return transform.position.y + waveAmplitude * Mathf.Sin(x / waveLength + offset);
    }
    */
    public float GetWaveHeight(Vector3 pos) {
        float x = direction.x * pos.x;
        float z = direction.z * pos.z;
        float average = (x + z) / 2;
        float height = transform.position.y + waveAmplitude * Mathf.Sin(average / waveLength + offset);
        return height;
    }
}
