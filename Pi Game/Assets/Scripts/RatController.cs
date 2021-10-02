using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour {

    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask whatIsGround;
    [HideInInspector] public bool isGrounded;

    Vector3 moveDir;
    Quaternion lookRot;
    Quaternion startRot;
    Quaternion endRot;

    CameraController cam;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<CameraController>();
    }

    void Update() {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        moveDir = ((ver * cam.forward) + (hor * cam.right)).normalized;

        if (CheckGrounded()) {
            isGrounded = true;
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
        else {
            isGrounded = false;
        }

        startRot = transform.rotation;
        if (moveDir != Vector3.zero) {
            lookRot = Quaternion.LookRotation(moveDir, Vector3.up);
        }
        endRot = Quaternion.Euler(0, lookRot.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Slerp(startRot, endRot, turnSpeed * Time.deltaTime);
    }

    void FixedUpdate() {
        rb.AddForce(moveDir * acceleration * Time.deltaTime);
        if (moveDir == Vector3.zero) {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        else {
            if (rb.velocity.magnitude >= maxSpeed) {
                rb.AddForce(-moveDir * acceleration * Time.deltaTime);
            }
        }
    }

    bool CheckGrounded() {
        SphereCollider col = GetComponent<SphereCollider>();
        RaycastHit hit;
        return Physics.SphereCast(transform.position + col.center, col.radius - 0.01f, Vector3.down, out hit, 0.02f, whatIsGround);
        /*
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        Vector3 point1 = transform.position - transform.forward * col.height * 0.5f;
        Vector3 point2 = transform.position + transform.forward * col.height * 0.5f;
        return Physics.CapsuleCast(point1, point2, col.radius - 0.01f, Vector3.down, 0.02f, whatIsGround);*/
    }
}
