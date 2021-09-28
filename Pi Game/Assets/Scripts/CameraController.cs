using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [HideInInspector] public Vector3 forward;
    [HideInInspector] public Vector3 right;

    void Start() {
        
    }

    void Update() {
        forward = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;
        right = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.right;
    }
}
