using UnityEngine;
using UnityEngine.AI;

public class CharactorAnimator : MonoBehaviour
{
	const float locomotionAnimationSmoothTime = .1f;
	NavMeshAgent nma;
	Animator animator;
	PlayerController playerController;
	float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
		nma = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		playerController = GetComponent<PlayerController>();
		maxSpeed = nma.speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
		float speedPercent = nma.velocity.magnitude / maxSpeed;
		animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
