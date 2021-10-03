using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    [SerializeField] float waveAmplitude = 1f;
    [SerializeField] float waveLength = 2f;
    [SerializeField] float waveSpeed = 1f;
    public Vector2 direction = new Vector2(1, 0);
    public float currentSpeed = 0.5f;

    float offset = 0f;

    void Update() {
        offset += Time.deltaTime * waveSpeed;
    }

    public float GetWaveHeight(float x) {
        return transform.position.y + waveAmplitude * Mathf.Sin(x / waveLength + offset);
    }
}
