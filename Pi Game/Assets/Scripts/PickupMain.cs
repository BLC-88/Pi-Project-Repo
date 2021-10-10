using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMain : MonoBehaviour, IPickup {

    [Header("Animation Settings")]
    [SerializeField] Vector3 rotateAngle = new Vector3(0f, 30f, 0f);
    [SerializeField] float bobAmplitude = 0.2f;
    [SerializeField] float bobSpeed = 0.5f;

    Vector3 bobPosition;
    Vector3 startPos;

    public RatController rat;

    void Awake() {
        InitialiseVariables();
    }

    public virtual void InitialiseVariables() {
        rat = FindObjectOfType<RatController>();
    }

    void Start() {
        Vector3 pivot = new Vector3(0, 0, transform.position.z);
        transform.RotateAround(pivot, transform.root.GetComponent<TunnelRespawner>().spawnPoint.forward, Random.Range(0f, 360f));
        startPos = transform.localPosition;
    }

    void Update() {
        Animate();
    }

    public void Animate() {
        transform.Rotate(rotateAngle * Time.deltaTime);
        bobPosition.y = bobAmplitude * Mathf.Sign(bobSpeed * Time.deltaTime);
        transform.localPosition = startPos + bobPosition;
    }

    public virtual void Pickup() {
        rat.animationScript.Pickup();
        Destroy(gameObject);
    }
}
