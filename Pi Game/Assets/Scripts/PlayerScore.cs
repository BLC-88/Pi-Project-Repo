using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    [SerializeField] Text distanceTravelledUI;
    [SerializeField] Text totalTimeUI;
    [SerializeField] Text cheeseCountUI;

    float distanceTravelled;
    float totalTime;
    float cheeseCount;

    void Start() {
        
    }

    void Update() {
        distanceTravelledUI.text = distanceTravelled.ToString("f2");
        totalTimeUI.text = totalTime.ToString("f2");
        cheeseCountUI.text = cheeseCount.ToString("f4");
    }

    public void AddCheese(float amount) {
        cheeseCount += amount;
    }
}
