using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] GameObject target;
    [SerializeField] float rotateSpeed;

    /*
    [Header("Camera Rotation Settings")]
    [Range(0.001f, 5f)] [SerializeField] float xSensitivity = 1f;
    [Range(0.001f, 5f)] [SerializeField] float ySensitivity = 1f;
    private float rotationX;
    private float rotationY;
    */
    [HideInInspector] public Vector3 forward;
    [HideInInspector] public Vector3 right;

    float lerpTime = 1f;
    float currentLerpTime;
    Vector3 startPos;
    Vector3 endPos;

    [HideInInspector] public bool canRotate = true;

    void Start() {
        canRotate = true;
    }

    void LateUpdate() {
        if (target == null) {
            return;
        }
        if (canRotate) {
            startPos = transform.position;
            endPos = target.transform.position;
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime) {
                currentLerpTime = lerpTime;
            }
            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
            /*
            rotationX = Mathf.Clamp(rotationX, -105, 65);
            rotationY += Input.GetAxis("Mouse X") * xSensitivity * Time.timeScale;
            rotationX -= Input.GetAxis("Mouse Y") * ySensitivity * Time.timeScale;
            transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
            */
            transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, rotateSpeed * Time.deltaTime);

            forward = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;
            right = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.right;
        }
    }
}
