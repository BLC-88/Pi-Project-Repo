using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour {

    [HideInInspector] public bool canMove = true;
    [SerializeField] float moveSpeed;
    float moveSpeedOriginal;
    [SerializeField] float turnSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask whatIsGround;
    [HideInInspector] public bool isGrounded;
    [SerializeField] float gravityStrength = 9.81f;

    [Header("Model Animations")]
    [SerializeField] GameObject model;
    [SerializeField] float modelTurnAngle;
    [SerializeField] float modelTurnspeed;
    [SerializeField] public RatAnimations animationScript;

    Vector3 moveDir;
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
        moveSpeedOriginal = moveSpeed;
        canMove = true;
    }

    void Update() {
        if (canMove) {
            float hor = Input.GetAxisRaw("Horizontal");
            //float ver = Input.GetAxisRaw("Vertical");

            //moveDir = ((ver * transform.forward) + (hor * transform.right)).normalized;
            //moveDir = ver * transform.forward;
            //moveDir = (transform.forward + (hor * transform.right)).normalized;

            if (moveDir == Vector3.forward) {
                pivot = new Vector3(0, 0, transform.position.z);
            }
            else if (moveDir == Vector3.left || moveDir == Vector3.right) {
                pivot = new Vector3(transform.position.x, 0, 0);
            }
            else if (moveDir == Vector3.down) {
                pivot = new Vector3(0, transform.position.y, 0);
            }
            transform.RotateAround(pivot, moveDir, turnSpeed * hor * Time.deltaTime);

            if (CheckGrounded()) {
                isGrounded = true;
                animationScript.anim.SetBool("Jump", false);
                if (Input.GetKeyDown(KeyCode.Space)) {
                    animationScript.anim.SetBool("Jump", true);
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
    }

    void FixedUpdate() {
        if (canMove) {
            //rb.MovePosition(transform.position + moveDir * speed * Time.fixedDeltaTime);
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
            rb.AddForce(gravity * gravityStrength, ForceMode.Acceleration);
        }
    }

    void LateUpdate() {
        if (canMove) {
            //transform.up = pivot - transform.position;
            Vector3 newRot = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Vector3.SignedAngle(Vector3.up, pivot - transform.position, moveDir));
            transform.rotation = Quaternion.Euler(newRot);
            gravity = -transform.up;
        }
    }

    bool CheckGrounded() {
        SphereCollider col = GetComponent<SphereCollider>();
        //RaycastHit hit;
        //return Physics.SphereCast(transform.position + col.center, col.radius - 0.01f, -transform.up, out hit, 0.02f, whatIsGround);
        return Physics.Raycast(transform.position + transform.up * col.center.y, -transform.up, col.radius + 0.01f, whatIsGround);
    }

    void OnTriggerEnter(Collider other) {
        TunnelRespawner tunnel = other.GetComponent<TunnelRespawner>();
        if (tunnel != null) {
            moveDir = tunnel.spawnPoint.forward;
            //transform.rotation = Quaternion.LookRotation(moveDir);
            StartCoroutine(Rotate(moveDir));
        }
        IPickup pickup = other.GetComponent<IPickup>();
        if (pickup != null) {
            pickup.Pickup();
        }
    }

    void OnCollisionEnter(Collision other) {
        IObstacle obstacle = other.transform.GetComponent<IObstacle>();
        if (obstacle != null) {
            animationScript.anim.SetTrigger("Stumble");
            obstacle.Collide(gameObject);
        }
    }

    public IEnumerator ChangeSpeed(float slowDownDuration, float moveSpeedMultiplier) {
        moveSpeed *= moveSpeedMultiplier;
        turnSpeed *= moveSpeedMultiplier;
        modelTurnspeed *= moveSpeedMultiplier;
        yield return new WaitForSeconds(slowDownDuration - 0.5f);
        animationScript.anim.SetTrigger("Getup");
        yield return new WaitForSeconds(0.5f);
        moveSpeed /= moveSpeedMultiplier;
        turnSpeed /= moveSpeedMultiplier;
        modelTurnspeed /= moveSpeedMultiplier;
    }

    public void SetSpeed(float newMoveSpeed) {
        moveSpeed = newMoveSpeed;
    }

    public void ResetSpeed() {
        moveSpeed = moveSpeedOriginal;
    }

    IEnumerator Rotate(Vector3 direction) {
        yield return new WaitForSeconds(1f);
        transform.forward = direction;
    }
}
