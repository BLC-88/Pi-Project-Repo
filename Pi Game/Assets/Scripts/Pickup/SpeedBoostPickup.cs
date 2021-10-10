using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickup : PickupMain {

    [Header("Pickup Settings")]
    [SerializeField] float speedMultiplier = 0.1f;
    [SerializeField] float speedChangeDuration = 0.01f;

    RatController rat;

    void Awake() {
        rat = FindObjectOfType<RatController>();
    }

    public override void Pickup() {
        rat.StartCoroutine(rat.ChangeSpeed(speedChangeDuration, speedMultiplier));
        GetComponent<Collider>().enabled = false;
        base.Pickup();
    }
}
