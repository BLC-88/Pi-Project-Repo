using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;

    void Start() {
        
    }

    void Update() {
        float hor = Input.GetAxisRaw("Horizontal");

        transform.Rotate(transform.forward * turnSpeed * hor * Time.deltaTime);
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }
}
