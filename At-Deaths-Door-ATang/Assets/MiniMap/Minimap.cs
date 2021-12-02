/*
 * Made by: Adam Tang
 * Date Created: 11/23/2021
 * Date Modified 11/23/2021
 * Description: Minimap script to follow player around.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public float yAmount = 2.875f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = player.position.y + yAmount;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
