/*
 * Created By: Adam Tang
 * Date Created: 11/27/2021
 * Date Modified: 11/27/2021
 * Description: Controls animation of entity.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent),
 typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public float CrawlVelocity = 0.1f;
    public string AnimationCrawlParamName = "Crawl";
    private NavMeshAgent ThisNavMeshAgent = null;
    private Animator ThisAnimator = null;

    public string AnimationSpeedParamName = "Speed";
    private float MaxSpeed;

    void Awake()
    {
        ThisNavMeshAgent = GetComponent<NavMeshAgent>();
        ThisAnimator = GetComponent<Animator>();
        MaxSpeed = ThisNavMeshAgent.speed;

    }
    void Update()
    {
        ThisAnimator.SetBool(AnimationCrawlParamName,
        ThisNavMeshAgent.velocity.magnitude > CrawlVelocity);
        ThisAnimator.SetFloat(AnimationSpeedParamName,
        ThisNavMeshAgent.velocity.magnitude / MaxSpeed);
    }
}
