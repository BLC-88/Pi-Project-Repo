using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour {

    [SerializeField] Rigidbody rb;
    [SerializeField] float depthBeforeSubmerged = 1f;
    [SerializeField] float displacementAmount = 3f;
    [SerializeField] int floaterPointCount = 1;
    [SerializeField] float waterDrag = 0.99f;
    [SerializeField] float waterAngularDrag = 0.5f;
    float waveHeight;

    void Awake() {
        if (rb == null) {
            rb = GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate() {
        rb.AddForceAtPosition(Physics.gravity / floaterPointCount, transform.position, ForceMode.Acceleration);
        if (transform.position.y < waveHeight) {
            float displacementMultiplier = Mathf.Clamp01(waveHeight - transform.position.y / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }

    void OnTriggerEnter(Collider other) {
        Wave waveInstance = other.GetComponent<Wave>();
        if (waveInstance != null) {
            waveHeight = waveInstance.GetWaveHeight(transform.position.x);
        }
    }

    void OnTriggerExit(Collider other) {
        Wave waveInstance = other.GetComponent<Wave>();
        if (waveInstance != null) {
            waveHeight = -100f;
        }
    }
}
