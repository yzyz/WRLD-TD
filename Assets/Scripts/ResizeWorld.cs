using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ResizeWorld : MonoBehaviour {

	void Start () {
		Invoke ("Resize", 2f);
	}
	
	void Resize() {
        GetComponent<WrldMap>().enabled = false;
		transform.localScale = Vector3.one / 100f;

        GetComponent<NavMeshSurface>().BuildNavMesh();
	}
		
}
