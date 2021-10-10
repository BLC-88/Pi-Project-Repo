using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatTrap : MonoBehaviour {

    [SerializeField] bool randomRotation = true;
    [SerializeField] Transform trapPosition;
    [SerializeField] float moveSpeed = 0f;
    bool trapped;
    [SerializeField] float trapDurationMax = 100f;
    [SerializeField] float trapBreakAmount = 20f;
    [SerializeField] float trapDecayRate = 15f;
    float trapDuration;

    GameObject UI;
    Image fillUI;

    RatController rat;

    void Start() {
        if (randomRotation) {
            Vector3 pivot = new Vector3(0, 0, transform.position.z);
            transform.RotateAround(pivot, transform.root.GetComponent<TunnelRespawner>().spawnPoint.forward, Random.Range(0f, 360f));
        }
        trapDuration = trapDurationMax;

        UI = FindObjectOfType<Canvas>().transform.Find("HUD").transform.Find("TrappedUI").gameObject;
        fillUI = UI.transform.Find("FillAmount").GetComponent<Image>();

        UI.SetActive(false);
    }

    void Update() {
        if (trapped) {
            trapDuration = Mathf.Clamp(trapDuration, 0, trapDurationMax);
            trapDuration += trapDecayRate * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space)) {
                trapDuration -= trapBreakAmount;
            }
            if (trapDuration <= 0) {
                trapped = false;
                rat.ResetSpeed();
                UI.SetActive(false);
            }

            float perc = trapDuration / trapDurationMax;
            fillUI.fillAmount = perc;
        }
    }

    public void OnTriggerEnter(Collider other) {
        rat = other.GetComponent<RatController>();
        if (rat != null) {
            rat.SetSpeed(moveSpeed);
            rat.transform.position = trapPosition.position;
            trapped = true;
            UI.SetActive(true);
        }
    }
}
