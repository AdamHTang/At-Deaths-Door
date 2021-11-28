/*
 * Created By: Adam Tang
 * Date Created: 11/26/2021
 * Date Modified: 11/26/2021
 * Description: Makes Nav Mesh Agent go to destination.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowDestination : MonoBehaviour
{
    public Transform Destination = null;
    private NavMeshAgent ThisAgent = null;
    void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        ThisAgent.SetDestination(Destination.position);

    }
}
