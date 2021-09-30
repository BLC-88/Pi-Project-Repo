using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour {

    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] float fallSpeed = 2f;

    Vector3 moveDir;
    Quaternion lookRot;

    Vector3 startPos;
    public Vector3 endPos;
    Quaternion startRot;
    Quaternion endRot;

    CameraController cam;
    RollBallController ball;

    void Awake() {
        cam = FindObjectOfType<CameraController>();
        ball = FindObjectOfType<RollBallController>();
        endPos = transform.localPosition;
    }

    void Update() {
        startRot = transform.rotation;
        startPos = ball.transform.position;

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //moveDir = new Vector3(hor, 0, ver).normalized;
        moveDir = ((ver * cam.forward) + (hor * cam.right)).normalized;
        if (moveDir != Vector3.zero) {
            lookRot = Quaternion.LookRotation(moveDir, Vector3.up);
        }
        endRot = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);
        /*
        if (ball.isJumping) {
            endPos.y = 0.3f;
        }
        endPos.y += Physics.gravity.y * Time.deltaTime;
        endPos.y = Mathf.Clamp(endPos.y, 0f, 1f);*/
        if (!ball.isGrounded) {
            endPos.y = ball.transform.position.y;
            transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, fallSpeed * Time.deltaTime);
        }

        transform.rotation = Quaternion.Slerp(startRot, endRot, rotateSpeed * Time.deltaTime);
    }
}
