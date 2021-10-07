using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBlades : MonoBehaviour
{
    
    float speedMin = 0.5f; //Min Velocity
    float speedMax = 0.8f; //Max Velocity
    float randDir;
    
    // Start is called before the first frame update
    void Start()
    {
        randDir = Random.Range(1, 3); //Randomizes whether the blade should spin left or right.
    }

    // Update is called once per frame
    void Update()
    {
        switch(randDir)
        {
        case 1: transform.Rotate(new Vector3(0,0,Random.Range(speedMin, speedMax)));
             //applying rotation to the right
        break;

        case 2: transform.Rotate(new Vector3(0,0,-Random.Range(speedMin, speedMax)));
             //applying rotation to the left
        break;
        }
    }
}
