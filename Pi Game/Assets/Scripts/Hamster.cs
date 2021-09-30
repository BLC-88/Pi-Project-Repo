using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour {

    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] float fallSpeed = 2f;

    Vector3 moveDir;
    Quaternion lookRot;

    Vector3 pendingPos;
    public Vector3 lastPos;
    Vector3 endPos;
    Quaternion startRot;
    Quaternion endRot;

    CameraController cam;
    RollBallController ball;

    void Awake() {
        cam = FindObjectOfType<CameraController>();
        ball = FindObjectOfType<RollBallController>();
    }

    IEnumerator SetTargetPosition(Vector3 position) {
        pendingPos = position;
        yield return null;
        endPos = position;
    }

    void LateUpdate() {
        startRot = transform.rotation;

        transform.position = lastPos;

        transform.position = Vector3.Lerp(transform.position, endPos, fallSpeed * Time.deltaTime);

        float yPos = Mathf.Clamp(transform.localPosition.y, 0f, 0.5f);
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);

        lastPos = transform.position;

        if (ball.transform.localPosition != endPos && ball.transform.localPosition != pendingPos) {
            StartCoroutine(SetTargetPosition(ball.transform.localPosition));
        }


        if (transform.localPosition.y < 0) {
            Debug.Log("below zero");
        }

        Vector3 ballPos = ball.transform.position;
        transform.position = new Vector3(ballPos.x, transform.position.y, ballPos.z);

        
        /*
        lastPos = ball.transform.position;
        endPos = Vector3.zero;
        */
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
        /*
        if (!ball.isGrounded) {
            endPos.y = 0.3f;
        }*/

        //transform.position = Vector3.Lerp(transform.position, endPos, fallSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(startRot, endRot, rotateSpeed * Time.deltaTime);
    }
}
