using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask whatIsGround;
     public bool isGrounded;
    [SerializeField] float gravityStrength = 9.81f;

    //Vector3 moveDir;
    Vector3 gravity;
    Quaternion lookRot;
    Quaternion startRot;
    Quaternion endRot;

    //CameraController cam;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        //cam = FindObjectOfType<CameraController>();
    }

    void Update() {
        float hor = Input.GetAxisRaw("Horizontal");
        //float ver = Input.GetAxisRaw("Vertical");

        //moveDir = ((ver * transform.forward) + (hor * transform.right)).normalized;
        //moveDir = ver * transform.forward;

        Vector3 pivot = new Vector3(0, 0, transform.position.z);
        transform.RotateAround(pivot, Vector3.forward, turnSpeed * hor * Time.deltaTime);
        transform.up = pivot - transform.position;

        if (CheckGrounded()) {
            isGrounded = true;
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(transform.up * jumpForce);
            }
        }
        else {
            isGrounded = false;
        }

        startRot = transform.rotation;
        /*
        if (moveDir != Vector3.zero) {
            lookRot = Quaternion.LookRotation(moveDir, Vector3.up);
        }
        endRot = Quaternion.Euler(0, lookRot.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Slerp(startRot, endRot, turnSpeed * Time.deltaTime);*/
        gravity = -transform.up;
        //transform.localEulerAngles = Vector3.zero;
    }

    void FixedUpdate() {
        //rb.MovePosition(transform.position + moveDir * speed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
        rb.AddForce(gravity * gravityStrength, ForceMode.Acceleration);
    }

    bool CheckGrounded() {
        SphereCollider col = GetComponent<SphereCollider>();
        RaycastHit hit;
        return Physics.SphereCast(transform.position + col.center, col.radius - 0.01f, -transform.up, out hit, 0.02f, whatIsGround);
    }
}
