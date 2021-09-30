using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Cat : MonoBehaviour {

    [SerializeField] GameObject target;

    NavMeshAgent agent;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start() {
        if (target == null) {
            target = FindObjectOfType<RollBallController>().gameObject;
        }
    }

    void Update() {
        agent.SetDestination(target.transform.position);
    }
}
