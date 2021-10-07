using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObstacle : MonoBehaviour, IObstacle {

    [SerializeField] float slowDownSpeedMultiplier;
    [SerializeField] float slowDownDuration;

    public void Collide(GameObject other) {
        RatController rat = other.GetComponent<RatController>();
        if (rat != null) {
            rat.StartCoroutine(rat.ChangeSpeed(slowDownDuration, slowDownSpeedMultiplier));
        }
    }
}
