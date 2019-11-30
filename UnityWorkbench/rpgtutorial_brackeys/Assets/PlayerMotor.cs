using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
	NavMeshAgent nma;
    // Start is called before the first frame update
    void Start()
    {
		nma = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
	{
		nma.SetDestination(point);
	}
}
