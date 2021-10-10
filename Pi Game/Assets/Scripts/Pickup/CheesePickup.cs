using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickup : PickupMain {

    [Header("Pickup Settings")]
    [SerializeField] float cheeseAmount = Mathf.PI;

    PlayerScore playerScore;

    public override void InitialiseVariables() {
        base.InitialiseVariables();
        playerScore = FindObjectOfType<PlayerScore>();
    }

    public override void Pickup() {
        playerScore.AddCheese(cheeseAmount);
        GetComponent<Collider>().enabled = false;
        base.Pickup();
    }
}
