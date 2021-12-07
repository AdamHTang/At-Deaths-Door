/*
 * Created By: Adam Tang
 * Date Created: 11/25/2021
 * Date Modified: 12/5/2021
 * Description: Inventory Controller
 * 
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Inventory : MonoBehaviour
{
    private int numHealthPots;
    private int numStaminaPots;
    public int numKeys = 0;
    public GameObject player;

    public AudioSource bottlePickup;
    public AudioSource unlockSound;
    public AudioSource bottleUse;
    public AudioSource keyPickup;

    private EntityHealth playerHealth;
    private FirstPersonController playerController;


    void Awake()
    {
        numHealthPots = 0;
        numStaminaPots = 0;
        numKeys = 0;
        playerHealth = player.GetComponent<EntityHealth>();
        playerController = player.GetComponent<FirstPersonController>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            useHP();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            useSP();
        }
    }


    public void addHP()
    {
        bottlePickup.Play();
        numHealthPots++;
    }

    public void addSP()
    {
        bottlePickup.Play();
        numStaminaPots++;
    }

    public void addKey()
    {
        keyPickup.Play();
        numKeys++;
    }

    public void useHP()
    {
        if (numHealthPots > 0 && playerHealth.getHealthPoints() != playerHealth.getMaxHealth()) 
        {
            numHealthPots--;
            float healthAdded = 50;
            if (playerHealth.getHealthPoints() > 50)
            {
                healthAdded = playerHealth.getMaxHealth() - playerHealth.getHealthPoints();
            }
            bottleUse.Play();
            playerHealth.HealthPoints += healthAdded;
        }
        
    }

    public void useSP()
    {
        if (numStaminaPots > 0 && playerController!= null)
        {
            numStaminaPots--;
            bottleUse.Play();
            playerController.sprintTime = playerController.maxSprintTime;
        }
    }

    public void useKey()
    {
        if (numKeys > 0)
        {
            numKeys--;
            unlockSound.Play();
        }
    }

    public int getHealthPots()
    {
        return numHealthPots;
    }

    public int getStaminaPots()
    {
        return numStaminaPots;
    }

    public int getKeys()
    {
        return numKeys;
    }
}
