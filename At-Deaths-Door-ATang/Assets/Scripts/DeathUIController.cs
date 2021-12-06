/*
 * Created By: Adam Tang
 * Date Created: 12/5/2021
 * Date Modified: 12/5/2021
 * Description: Controls UI when player dies.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathUIController : MonoBehaviour
{
    public GameObject player;
    private EntityHealth health;

    public TextMeshProUGUI deathText;
    public TextMeshProUGUI resetText;

    void Awake()
    {
        health = player.GetComponent<EntityHealth>();
        deathText.enabled = false;
        resetText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.HealthPoints <= 0)
        {
            deathText.enabled = true;
            resetText.enabled = true;
        }


    }
}
