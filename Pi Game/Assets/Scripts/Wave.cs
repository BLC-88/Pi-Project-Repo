using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    [SerializeField] float amplitude = 1f;
    [SerializeField] float length = 2f;
    public float speed = 1f;
    public Vector2 direction = new Vector2(1, 0);
    float offset = 0f;

    void Update() {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float x) {
        return transform.position.y + amplitude * Mathf.Sin(x / length + offset);
    }
}
