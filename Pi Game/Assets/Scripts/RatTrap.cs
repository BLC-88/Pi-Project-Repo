using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatTrap : MonoBehaviour {

    [SerializeField] bool randomRotation = true;
    [SerializeField] Animator anim;
    [SerializeField] Transform trapPosition;
    [SerializeField] float moveSpeed = 0f;
    bool trapped;

    [Header("Trap Settings")]
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
        anim.enabled = false;
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
                rat.canMove = true;
                rat.animationScript.anim.SetBool("Fallen", false);
                rat.animationScript.Successful();
                UI.SetActive(false);
                GetComponent<Collider>().enabled = false;
            }

            float perc = 1 - trapDuration / trapDurationMax;
            fillUI.fillAmount = perc;
        }
    }

    public void OnTriggerEnter(Collider other) {
        rat = other.GetComponent<RatController>();
        if (rat != null) {
            rat.SetSpeed(moveSpeed);
            rat.canMove = false;
            rat.transform.position = trapPosition.position;
            rat.transform.rotation = trapPosition.rotation;
            rat.animationScript.anim.SetBool("Fallen", true);
            trapped = true;
            UI.SetActive(true);
            anim.enabled = true;
        }
    }
}
