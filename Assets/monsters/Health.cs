﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float hp = 100;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void TakeDamage(float dmg) {
		hp -= dmg;
		if (hp <= 0)
			Die ();
	}

	void Die() {
		anim.SetBool ("dead", true);
		Destroy (transform.parent.gameObject, 3);
	}

	/*
	void Update() {
		TakeDamage (0.1f);
		print (hp);
	}
	*/
}
