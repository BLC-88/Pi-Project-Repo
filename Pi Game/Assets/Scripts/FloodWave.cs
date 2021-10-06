using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodWave : MonoBehaviour {

    [SerializeField] float moveSpeed = 5f;

    void Start() {
        
    }

    void Update() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<RatController>()) {
            print("gameover");
        }
    }
}
