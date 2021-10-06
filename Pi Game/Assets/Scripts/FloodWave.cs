using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloodWave : MonoBehaviour {

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Image warningUI;
    float maxDist;
    Color tempCol = new Color();

    RatController player;

    void Awake() {
        player = FindObjectOfType<RatController>();
    }

    void Start() {
        maxDist = Vector3.Distance(transform.position, player.transform.position);
    }

    void Update() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        tempCol = warningUI.color;
        float a = 1 - Vector3.Distance(transform.position, player.transform.position) / maxDist;
        tempCol.a = a;
        warningUI.color = tempCol;
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<RatController>()) {
            print("gameover");
        }
    }
}
