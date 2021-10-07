using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloodWave : MonoBehaviour {

    [SerializeField] float moveSpeed = 5f;
    float originalMoveSpeed;
    [SerializeField] float timeBeforeSlowDown = 10f;
    public float slowDownTimer;
    [SerializeField] Image warningUI;
    float maxDist;
    Color tempCol = new Color();

    RatController player;

    void Awake() {
        player = FindObjectOfType<RatController>();
        originalMoveSpeed = moveSpeed;
    }

    void Start() {
        maxDist = Vector3.Distance(transform.position, player.transform.position);
    }

    void Update() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        float dist = Vector3.Distance(transform.position, player.transform.position);
        tempCol = warningUI.color;
        float a = 1 - dist / maxDist;
        tempCol.a = a;
        warningUI.color = tempCol;

        if (dist < maxDist) {
            slowDownTimer += Time.deltaTime;
        }
        else {
            slowDownTimer = 0f;
            moveSpeed = originalMoveSpeed;
        }
        if (slowDownTimer >= timeBeforeSlowDown) {
            moveSpeed *= 0.9f;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<RatController>()) {
            print("gameover");
        }
    }
}
