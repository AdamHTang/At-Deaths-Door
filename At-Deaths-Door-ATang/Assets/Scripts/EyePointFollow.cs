/*
 * Made by: Adam Tang
 * Date Created: 12/4/2021
 * Date Modified: 12/4/2021
 * Description: Makes the eyepoint follow a certain game object transform.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePointFollow : MonoBehaviour
{
    public Transform thisTransform;
    public float yAmount = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = thisTransform.position;
        newPosition.y = thisTransform.position.y + yAmount;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, thisTransform.eulerAngles.y, 0f);
    }
}
