using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeWorld : MonoBehaviour {

	void Start () {
		Invoke ("Resize", 5f);
	}
	
	void Resize() {
		transform.localScale = Vector3.one / 150f;
	}
		
}
