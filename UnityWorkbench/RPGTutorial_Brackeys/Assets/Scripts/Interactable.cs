using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radius = 3f;
	public Transform interactionTransform;


	bool isFocused = false;
	Transform player;
	bool hasInteracted = false;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		if(interactionTransform != null)
			Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

	public virtual void Interact()
	{
		Debug.Log("Interact with " + transform.name);
	}

	private void Update()
	{
		if (isFocused && !hasInteracted)
		{
			float distance = Vector3.Distance(interactionTransform.position, player.position);
			if(distance <= radius)
			{
				Interact();
				hasInteracted = true;
			}
		}
	}

	public void OnFocused(Transform player)
	{
		isFocused = true;
		this.player = player;
		//the next line will result in the Interact function be triggered some times, without it, we need to defocus to retrigger the Interact function
		//hasInteracted = false;
	}

	public void OnDeFocused()
	{
		isFocused = false;
		player = null;
		hasInteracted = false;
	}
}
