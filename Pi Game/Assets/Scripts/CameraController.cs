using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset = new Vector3(0, 3, -10);

    [HideInInspector] public Vector3 forward;
    [HideInInspector] public Vector3 right;

    float lerpTime = 1f;
    float currentLerpTime;
    Vector3 startPos;
    Vector3 endPos;

    void Start() {
        target = FindObjectOfType<RollBallController>().gameObject;
    }

    void Update() {
        startPos = transform.position;
        endPos = target.transform.position + offset;
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
        float perc = currentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(startPos, endPos, perc);

        forward = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;
        right = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.right;
    }
}
