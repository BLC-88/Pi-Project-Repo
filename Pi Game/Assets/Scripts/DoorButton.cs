using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{

    bool Opened = false;
    public GameObject[] Lights;
    public GameObject Door;
    public GameObject Particles;
    

    void Start()
    {
        //Switches the particles off to start with.
        Particles.SetActive(false);

        //rotate so the button spawns randomly around the pipe
        Vector3 pivot = new Vector3(0, 0, transform.position.z);
        transform.RotateAround(pivot, transform.root.GetComponent<TunnelRespawner>().spawnPoint.forward, Random.Range(0f, 360f));
    }

    void Update()
    {
        if (Opened)
        {
            //Switches Lights to Green
            foreach (GameObject LightObj in Lights)
            {
                LightObj.GetComponent<Light>().color = Color.green;
            }

            //Opens The Door + Activates The Particles.
            Door.transform.Translate(Vector3.up * Time.deltaTime * 2f, Space.World);
            Particles.SetActive(true);
        }
    }

        //When The player touches the button, different things activate ^
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            Opened = true;
        }
    }
}
