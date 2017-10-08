using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour {
	Animator anim;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("attack", ReachedDestination ());
	}

	bool ReachedDestination() {
		return !agent.pathPending &&
			   agent.remainingDistance <= agent.stoppingDistance &&
			   (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
	}
}
