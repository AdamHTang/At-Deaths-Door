/*
 * Created By: Adam Tang
 * Date Created: 11/27/2021
 * Date Modified: 12/2/2021
 * Description: Determines if the entity sees another entity.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
public class SightLine : MonoBehaviour
{
    public Transform EyePoint;
    public string TargetTag = "Player";
    public float FieldOfView = 45f;

    public bool IsTargetInSightLine { get; set; } = false;
    public Vector3 LastKnowSighting { get; set; } = Vector3.zero;

    public SphereCollider ThisCollider;

    void Awake()
    {
        LastKnowSighting = transform.position;
    }

    void OnTriggerStay(Collider Other)
    {
        if (Other.CompareTag(TargetTag))
        {
            Debug.Log("Triggered on collider");
            UpdateSight(Other.transform);
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag(TargetTag)) 
            { IsTargetInSightLine = false; }
    }

    private bool HasClearLineofSightToTarget(Transform Target)
    {
        RaycastHit Info;

        Vector3 DirToTarget = (Target.transform.position - EyePoint.transform.position).normalized;
        if (Physics.Raycast(EyePoint.position, DirToTarget, out Info, ThisCollider.radius))
        {
            if (Info.transform.CompareTag(TargetTag))
            {
                Debug.Log("Triggered on LOS");
                return true;
            }
        }

        return false;
    }

    private bool TargetInFOV(Transform Target)
    {
        Vector3 DirToTarget = (Target.transform.position - EyePoint.transform.position);
        float Angle = Vector3.Angle(EyePoint.transform.up, DirToTarget);

        if (Angle <= FieldOfView)
        {
            Debug.Log("Triggered on FOV");
            return true;
        }

        return false;
    }

    private bool TargetIsTooClose(Transform Target)
    {
        RaycastHit Info;
        Vector3 DirToTarget = (Target.transform.position - EyePoint.transform.position).normalized;
        if (Physics.Raycast(EyePoint.position, DirToTarget, out Info, ThisCollider.radius/5.0f))
        {
            if (Info.transform.CompareTag(TargetTag))
            {
                Debug.Log("Triggered on kill collider");
                return true;
            }
        }

        return false;
    }

    void UpdateSight(Transform Target)
    {
        IsTargetInSightLine = TargetIsTooClose(Target) || (HasClearLineofSightToTarget(Target) && TargetInFOV(Target));

        Vector3 DirToTarget = (Target.transform.position - EyePoint.transform.position);

        if (IsTargetInSightLine)
        {
            Debug.DrawRay(EyePoint.position, DirToTarget, Color.red, .01f, true);
            Debug.Log("I see you.");
            LastKnowSighting = Target.position;
        }
    }


}
