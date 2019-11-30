using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	Camera cam;
	PlayerMotor playerMotor;
	public LayerMask moveMask;
    void Start()
    {
		cam = Camera.main;
		playerMotor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(1))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100, moveMask))
			{
				playerMotor.MoveToPoint(hit.point);
			}
		}

		if (Input.GetMouseButton(0))
		{
			// if we hit an incractable
			// set it our focus
		}
    }
}
