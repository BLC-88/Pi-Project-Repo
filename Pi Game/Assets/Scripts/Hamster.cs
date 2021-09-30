using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour {

    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] float fallSpeed = 2f;

    Vector3 moveDir;
    Quaternion lookRot;

    Vector3 pendingPos;
    Vector3 lastPos;
    Vector3 endPos;
    Quaternion startRot;
    Quaternion endRot;

    CameraController cam;
    RollBallController ball;

    void Awake() {
        cam = FindObjectOfType<CameraController>();
        ball = FindObjectOfType<RollBallController>();
    }

    void Update() {
        //Position
        transform.position = lastPos;

        transform.position = Vector3.Lerp(transform.position, endPos, fallSpeed * Time.deltaTime);
        lastPos = transform.position;

        if (ball.transform.localPosition != endPos && ball.transform.localPosition != pendingPos) {
            endPos = ball.transform.localPosition;
        }
        
        Vector3 ballPos = ball.transform.position;

        float yPos = Mathf.Clamp(transform.position.y, ballPos.y, ballPos.y + 0.3f);
        transform.position = new Vector3(ballPos.x, yPos, ballPos.z);

        //Rotation
        startRot = transform.rotation;

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        moveDir = ((ver * cam.forward) + (hor * cam.right)).normalized;
        if (moveDir != Vector3.zero) {
            lookRot = Quaternion.LookRotation(moveDir, Vector3.up);
        }
        if (ball.isGrounded) {
            endRot = Quaternion.Euler(0, lookRot.eulerAngles.y, 0f);
        }
        else {
            endRot = Quaternion.Euler(-24f, lookRot.eulerAngles.y, 0f);
        }
        transform.rotation = Quaternion.Slerp(startRot, endRot, rotateSpeed * Time.deltaTime);
    }
}
