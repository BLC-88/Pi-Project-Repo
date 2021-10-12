using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloodWave : MonoBehaviour {

    [SerializeField] float moveSpeed = 5f;
    float originalMoveSpeed;
    [SerializeField] float timeBeforeSlowDown = 10f;
    float slowDownTimer;
    [SerializeField] float timeBeforeSpeedUp = 2f;
    float speedUpTimer;
    [SerializeField] Image warningUI;
    [SerializeField] Image warningBar;
    float maxDist;
    Color tempCol = new Color();
    [SerializeField] GameObject gameOverUI;

    RatController player;

    void Awake() {
        player = FindObjectOfType<RatController>();
    }

    void Start() {
        maxDist = Mathf.Abs(player.transform.position.z - transform.position.z);
        originalMoveSpeed = moveSpeed;
    }

    void Update() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        float dist = Mathf.Abs(player.transform.position.z - transform.position.z);
        tempCol = warningUI.color;
        float a = 1 - dist / maxDist;
        tempCol.a = a;
        warningUI.color = tempCol;
        warningBar.fillAmount = a;

        if (dist < maxDist - 0.25f) {
            slowDownTimer += Time.deltaTime;
        }
        else if (dist > maxDist + 0.25f) {
            speedUpTimer += Time.deltaTime;
        }
        else {
            slowDownTimer = 0f;
            speedUpTimer = 0f;
            moveSpeed = originalMoveSpeed;
        }
        if (slowDownTimer >= timeBeforeSlowDown) {
            moveSpeed -= Time.deltaTime;
        }
        if (speedUpTimer >= timeBeforeSpeedUp) {
            moveSpeed += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<RatController>()) {
            Time.timeScale = 0f;
            FindObjectOfType<PlayerScore>().SetHighScore();
            gameOverUI.SetActive(true);
        }
    }
}
