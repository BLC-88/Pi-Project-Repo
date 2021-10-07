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
        transform.Rotate(new Vector3(0, 180 * randDir, 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(speedMin, speedMax)));
        /*
        switch (randDir)
        {
        case 1:
            //applying rotation to the right
            transform.Rotate(new Vector3(0,0,Random.Range(speedMin, speedMax)));            
            break;

        case 2:
            //applying rotation to the left
            transform.Rotate(new Vector3(0,0,-Random.Range(speedMin, speedMax)));
            break;
        }*/
    }
}
