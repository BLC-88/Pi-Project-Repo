using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour {

    [SerializeField] float rotateSpeed = 1f;

    Vector3 moveDir;
    Quaternion lookRot;

    Quaternion startRot;
    Quaternion endRot;

    CameraController cam;

    void Awake() {
        cam = FindObjectOfType<CameraController>();
    }

    void Update() {
        startRot = transform.rotation;

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //moveDir = new Vector3(hor, 0, ver).normalized;
        moveDir = ((ver * cam.forward) + (hor * cam.right)).normalized;
        if (moveDir != Vector3.zero) {
            lookRot = Quaternion.LookRotation(moveDir, Vector3.up);
        }
        endRot = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        transform.rotation = Quaternion.Slerp(startRot, endRot, rotateSpeed * Time.deltaTime);
    }
}
