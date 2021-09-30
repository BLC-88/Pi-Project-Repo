using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RollBallController : MonoBehaviour {

    [SerializeField] float torque = 250f;
    [SerializeField] float jumpForce = 250f;
    [SerializeField] LayerMask whatIsGround;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isJumping;

    Vector3 moveDir;
    CameraController cam;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<CameraController>();
    }

    void Start() {
        rb.maxAngularVelocity = 100;
    }

    void Update() {
        float hor = -Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        moveDir = ((hor * cam.forward) + (ver * cam.right)).normalized;
        
        if (CheckGrounded()) {
            isGrounded = true;
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(Vector3.up * jumpForce);
                isJumping = true;
            }
        }
        else {
            isGrounded = false;
            isJumping = false;
        }
    }

    void FixedUpdate() {
        rb.AddTorque(moveDir * torque * Time.deltaTime);
    }

    bool CheckGrounded() {
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.14f, Vector3.down, out hit,  0.02f, whatIsGround);
    }
}
