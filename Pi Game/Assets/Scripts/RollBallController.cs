using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RollBallController : MonoBehaviour {

    [SerializeField] float speed = 1f;

    Vector3 moveDir;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        moveDir = new Vector3(hor, 0, ver).normalized;

        rb.AddTorque(moveDir * speed * Time.deltaTime);
    }
}
