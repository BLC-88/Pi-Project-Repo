using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RollBallController : MonoBehaviour {

    [SerializeField] float torque = 250f;

    Vector3 moveDir;
    CameraController cam;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<CameraController>();
    }

    void FixedUpdate() {
        float hor = -Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        moveDir = ((hor * cam.forward) + (ver * cam.right)).normalized;

        rb.AddTorque(moveDir * torque * Time.deltaTime);
    }
}
