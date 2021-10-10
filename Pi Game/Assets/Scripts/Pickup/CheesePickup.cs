using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickup : MonoBehaviour, IPickup {

    [SerializeField] float cheeseAmount = Mathf.PI;

    PlayerScore playerScore;

    void Awake() {
        playerScore = FindObjectOfType<PlayerScore>();
    }

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
        playerScore.AddCheese(cheeseAmount);
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
    }
}
