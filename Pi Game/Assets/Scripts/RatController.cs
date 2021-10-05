using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask whatIsGround;
    [HideInInspector] public bool isGrounded;
    [SerializeField] float gravityStrength = 9.81f;

    [Header("Model Animations")]
    [SerializeField] GameObject model;
    [SerializeField] float modelTurnAngle;
    [SerializeField] float modelTurnspeed;

    //Vector3 moveDir;
    Vector3 pivot;
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
        //moveDir = (transform.forward + (hor * transform.right)).normalized;

        pivot = new Vector3(0, 0, transform.position.z);
        transform.RotateAround(pivot, Vector3.forward, turnSpeed * hor * Time.deltaTime);

        if (CheckGrounded()) {
            isGrounded = true;
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(transform.up * jumpForce);
            }
        }
        else {
            isGrounded = false;
        }
        
        startRot = model.transform.localRotation;
        /*
        if (moveDir != Vector3.zero) {
            lookRot = Quaternion.LookRotation(moveDir, transform.up);
            if (transform.position.y > pivot.y) {
                endRot = Quaternion.Euler(0, -lookRot.eulerAngles.y, 0f);
            }
            else {
                endRot = Quaternion.Euler(0, lookRot.eulerAngles.y, 0f);
            }
        }*/
        //endRot = Quaternion.Euler(0, lookRot.eulerAngles.y, 0f);
        endRot = Quaternion.Euler(0, modelTurnAngle * hor, 0);
        model.transform.localRotation = Quaternion.Slerp(startRot, endRot, modelTurnspeed * Time.deltaTime);
    }

    void FixedUpdate() {
        //rb.MovePosition(transform.position + moveDir * speed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
        rb.AddForce(gravity * gravityStrength, ForceMode.Acceleration);
    }

    void LateUpdate() {
        transform.up = pivot - transform.position;
        gravity = -transform.up;
    }

    bool CheckGrounded() {
        SphereCollider col = GetComponent<SphereCollider>();
        //RaycastHit hit;
        //return Physics.SphereCast(transform.position + col.center, col.radius - 0.01f, -transform.up, out hit, 0.02f, whatIsGround);
        return Physics.Raycast(transform.position + col.center, -transform.up, col.radius, whatIsGround);
    }
}
