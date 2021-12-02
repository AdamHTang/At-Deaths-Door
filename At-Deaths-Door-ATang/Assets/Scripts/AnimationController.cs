/*
 * Created By: Adam Tang
 * Date Created: 11/27/2021
 * Date Modified: 11/27/2021
 * Description: Controls animation of entity.
 * 
 */

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public float RunVelocity = 0.1f;
    public string AnimationRunParamName = "Patrol";

    private NavMeshAgent ThisNavMeshAgent;
    private Animator ThisAnimator;

    void Awake()
    {
        ThisNavMeshAgent = GetComponent<NavMeshAgent>();
        ThisAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        ThisAnimator.SetBool(AnimationRunParamName, ThisNavMeshAgent.velocity.magnitude > RunVelocity);
    }
}
