using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour, IPickup {

    [SerializeField] float speedMultiplier = 0.1f;
    [SerializeField] float speedChangeDuration = 0.01f;

    RatController rat;

    void Start() {
        Vector3 pivot = new Vector3(0, 0, transform.position.z);
        transform.RotateAround(pivot, transform.root.GetComponent<TunnelRespawner>().spawnPoint.forward, Random.Range(0f, 360f));
    }

    void Update() {
        RotateAnimation();
    }

    public void RotateAnimation() {
        transform.Rotate(new Vector3(0, 0, 1f) * Time.deltaTime);
    }

    public void Pickup() {
        rat.StartCoroutine(rat.ChangeSpeed(speedChangeDuration, speedMultiplier));
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
    }
}
