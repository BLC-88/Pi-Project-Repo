using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObstacle : MonoBehaviour, IObstacle {

    [SerializeField] bool keepCollision = false;
    [SerializeField] float slowDownSpeedMultiplier = 0.01f;
    [SerializeField] float slowDownDuration = 1.8f;

    public void Collide(GameObject other) {
        RatController rat = other.GetComponent<RatController>();
        if (rat != null) {
            rat.StartCoroutine(rat.ChangeSpeed(slowDownDuration, slowDownSpeedMultiplier));
        }
        GetComponent<Collider>().enabled = keepCollision;
    }
}
