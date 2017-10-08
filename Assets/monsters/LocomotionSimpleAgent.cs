using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class LocomotionSimpleAgent : MonoBehaviour {
	Animator anim;
	NavMeshAgent agent;
    NavMeshObstacle obstacle;
	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
        obstacle = GetComponent<NavMeshObstacle>();
        obstacle.enabled = false;
		// Don’t update position automatically
		agent.updatePosition = false;
		anim.SetBool ("grounded", true);
		anim.SetBool ("grabweapon", true);
	}

	void Awake() {
		Start ();
	}

	void Update ()
	{
		if (anim.GetBool ("dead"))
			return;
        if (ReachedDestination())
        {
            agent.enabled = false;
            obstacle.enabled = true;
            anim.SetFloat("ver", 0);
            anim.SetFloat("hor", 0);
            anim.SetFloat("speed", 0);
            anim.SetBool("attack", true);
            return;
        } else
        {
            obstacle.enabled = false;
            agent.enabled = true;
            anim.SetBool("attack", false);
        }
		Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

		// Map 'worldDeltaPosition' to local space
		float dx = Vector3.Dot (transform.right, worldDeltaPosition);
		float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
		Vector2 deltaPosition = new Vector2 (dx, dy);

		// Low-pass filter the deltaMove
		float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
		smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);

		// Update velocity if time advances
		if (Time.deltaTime > 1e-5f)
			velocity = smoothDeltaPosition / Time.deltaTime;

		//bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

		// Update animation parameters
		//anim.SetBool("move", shouldMove);
		//anim.SetFloat ("velx", velocity.x);
		//anim.SetFloat ("vely", velocity.y);
		anim.SetFloat("ver", velocity.y * 5);
		anim.SetFloat("hor", velocity.x * 5);
		anim.SetFloat ("speed", velocity.magnitude * 5);
		//GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;
	}

    bool ReachedDestination()
    {
        if (obstacle.enabled) return true;
        return !agent.pathPending &&
               agent.remainingDistance <= agent.stoppingDistance &&
               (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
    }

    void OnAnimatorMove ()
	{
		if (anim.GetBool ("dead"))
			return;
		// Update position to agent position
        if (agent.enabled)
		    transform.position = agent.nextPosition;
	}
}