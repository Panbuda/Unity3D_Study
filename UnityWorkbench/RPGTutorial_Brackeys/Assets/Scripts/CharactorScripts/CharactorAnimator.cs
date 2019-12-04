using UnityEngine;
using UnityEngine.AI;

public class CharactorAnimator : MonoBehaviour
{
	const float locomotionAnimationSmoothTime = .1f;
	NavMeshAgent nma;
	Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		nma = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		float speedPercent = nma.velocity.magnitude / nma.speed;
		animator.SetFloat("SpeedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
