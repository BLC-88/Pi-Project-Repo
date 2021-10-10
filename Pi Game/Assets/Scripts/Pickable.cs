using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] float speedMultiplier = 0.1f;
    [SerializeField] float speedChangeDuration = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pivot = new Vector3(0, 0, transform.position.z);
        transform.RotateAround(pivot, transform.root.GetComponent<TunnelRespawner>().spawnPoint.forward, Random.Range(0f, 360f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.2f));
    }

    public void OnTriggerEnter(Collider other) {
        RatController rat = other.GetComponent<RatController>();
        if (rat != null)
        {
            if(gameObject.tag == "Cheese")
            {
                //add points
            }

            if(gameObject.tag == "Boost1")
            {
                rat.StartCoroutine(rat.ChangeSpeed(speedChangeDuration, speedMultiplier));
            }
            Destroy(gameObject);
        }
    }
}
