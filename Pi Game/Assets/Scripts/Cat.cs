using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour {

    [SerializeField] GameObject target;

    NavMeshAgent agent;

    void Start() {
        if (target == null) {
            target = FindObjectOfType<RollBallController>().gameObject;
        }
    }

    void Update() {
        agent.SetDestination(target.transform.position);
    }
}
