using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour {
	RaycastHit hitInfo = new RaycastHit();
	NavMeshAgent agent;
    NavMeshObstacle obstacle;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
        obstacle = GetComponent<NavMeshObstacle>();
	}
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                obstacle.enabled = false;
                agent.enabled = true;
                agent.destination = hitInfo.point;
            }
		}
	}
}