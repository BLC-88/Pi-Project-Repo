using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask whatIsGround;
     public bool isGrounded;

    Vector3 moveDir;
    Vector3 turnDir;
    CameraController cam;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<CameraController>();
    }

    void Update() {
        float hor = -Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //moveDir = ((hor * cam.forward) + (ver * cam.right)).normalized;
        moveDir = (ver * cam.forward).normalized;
        turnDir = (hor * cam.right).normalized;

        if (CheckGrounded()) {
            isGrounded = true;
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
        else {
            isGrounded = false;
        }
    }

    void FixedUpdate() {
        rb.AddForce(moveDir * moveSpeed * Time.deltaTime);
        rb.AddTorque(turnDir * turnSpeed * Time.deltaTime);
    }

    bool CheckGrounded() {
        //RaycastHit hit;
        //return Physics.SphereCast(transform.position, 0.14f, Vector3.down, out hit, 0.02f, whatIsGround);
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        Vector3 point1 = transform.position - transform.forward * col.height * 0.5f;
        Vector3 point2 = transform.position + transform.forward * col.height * 0.5f;
        return Physics.CapsuleCast(point1, point2, col.radius - 0.01f, Vector3.down, 0.02f, whatIsGround);
    }
}
