using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	public Interactable focus;

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
				RemoveFocus();
			}
		}

		if (Input.GetMouseButton(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);

			Interactable interactable = hit.transform.GetComponent<Interactable>();
			if(interactable != null)
			{
				SetFocus(interactable);
			}
		}
    }

	//elegant code!
	void SetFocus(Interactable newFocus)
	{
		//to make sure OnDeFocused function is carried out when focus changed
		if(newFocus != focus)
		{
			if (focus != null)
				focus.OnDeFocused();
			focus = newFocus;
			//FollowTarget test
			playerMotor.FollowTarget(focus);
		}

		focus.OnFocused(transform);
	}

	void RemoveFocus()
	{
		if(focus != null)
			focus.OnDeFocused();
		focus = null;
		//FollowTarget test
		playerMotor.StopFollowTarget();
	}
}
