/*
 * Created By: Adam Tang
 * Date Created: 12/4/2021
 * Date Modified: 12/4/2021
 * Description: Script to control when the objective doors open.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public string OpenDoorParam = "Open";

    private Animator thisAnimator;

    void Awake()
    {
        thisAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (lock1 == null && lock2 == null && lock3 == null)
        {
            thisAnimator.SetTrigger(OpenDoorParam);
        }
    }
}
