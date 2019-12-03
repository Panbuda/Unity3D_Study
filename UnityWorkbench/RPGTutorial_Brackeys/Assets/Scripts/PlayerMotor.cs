using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
	Transform target;
	NavMeshAgent nma;
    // Start is called before the first frame update
    void Start()
    {
		nma = GetComponent<NavMeshAgent>();
    }

	private void Update()
	{
		if(target != null)
		{
			//problem: always face to the target instead of road when navigate
			nma.SetDestination(target.position);
			FaceToTarget();
		}
	}

	public void MoveToPoint(Vector3 point)
	{
		nma.SetDestination(point);
	}

	public void FollowTarget(Interactable target)
	{
		nma.stoppingDistance = target.radius;
		//ban rotation to make sure face to target
		nma.updateRotation = false;

		this.target = target.interactionTransform;
	}

	public void StopFollowTarget()
	{
		nma.stoppingDistance = 0f;
		nma.updateRotation = true;

		target = null;
	}

	void FaceToTarget()
	{
		Vector3 direction = (target.transform.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
}
