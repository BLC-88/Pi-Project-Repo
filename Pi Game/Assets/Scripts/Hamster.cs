using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour {

    [SerializeField] Transform ball;

    void Start() {
        if (ball == null) {
            ball = transform.parent.transform;
        }
    }

    void Update() {
        
    }
}
