using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour {

    [SerializeField] List<Transform> floaterPoints;
    [SerializeField] float depthBeforeSubmerged = 1f;
    [SerializeField] float displacementAmount = 3f;
    [SerializeField] float waterDrag = 0.99f;
    [SerializeField] float waterAngularDrag = 0.5f;
    Wave waveObject;
    float waveHeight;

    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        if (floaterPoints.Count == 0) {
            floaterPoints.Add(transform);
        }
    }

    void FixedUpdate() {
        for (int i = 0; i < floaterPoints.Count; i++) {
            if (waveObject == null) {
                waveHeight = -100;
            }
            else {
                waveHeight = waveObject.GetWaveHeight(floaterPoints[i].position.x);
            }
            rb.AddForceAtPosition(Physics.gravity / floaterPoints.Count, floaterPoints[i].position, ForceMode.Acceleration);
            if (floaterPoints[i].position.y < waveHeight) {
                float displacementMultiplier = Mathf.Clamp01(waveHeight - floaterPoints[i].position.y / depthBeforeSubmerged) * displacementAmount;
                rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), floaterPoints[i].position, ForceMode.Acceleration);
                rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
                rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }
    }

    void OnTriggerStay(Collider other) {
        Wave waveInstance = other.GetComponent<Wave>();
        if (waveInstance != null) {
            waveObject = waveInstance;
            //waveHeight = waveInstance.GetWaveHeight(transform.position.x);
        }
    }

    void OnTriggerExit(Collider other) {
        Wave waveInstance = other.GetComponent<Wave>();
        if (waveInstance != null) {
            waveObject = null;
        }
    }
}
