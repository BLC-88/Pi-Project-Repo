using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    [SerializeField] Text[] distanceTravelledUI;
    [SerializeField] Text[] totalTimeUI;
    [SerializeField] Text[] cheeseCountUI;

    float distanceTravelled;
    float totalTime;
    float cheeseCount;

    [Header("HIGH SCORES")]
    [SerializeField] Text highestDistanceTravelledUI;
    [SerializeField] Text highestTotalTimeUI;
    [SerializeField] Text highestCheeseCountUI;

    float highestDistanceTravelled;
    float highestTotalTime;
    float highestCheeseCount;

    RatController rat;

    void Awake() {
        rat = FindObjectOfType<RatController>();
    }

    void Update() {
        distanceTravelled = rat.transform.position.z;
        totalTime += Time.deltaTime;

        for (int i = 0; i < 2; i++) {
            distanceTravelledUI[0].text = distanceTravelled.ToString("f2");
            totalTimeUI[0].text = totalTime.ToString("f2");
            cheeseCountUI[0].text = cheeseCount.ToString("f4");
        }
    }

    public void SetHighScore() {
        if (distanceTravelled > highestDistanceTravelled) highestDistanceTravelled = distanceTravelled;
        if (totalTime > highestTotalTime) highestTotalTime = totalTime;
        if (cheeseCount > highestCheeseCount) highestCheeseCount = cheeseCount;
    }

    public void AddCheese(float amount) {
        cheeseCount += amount;
    }
}
