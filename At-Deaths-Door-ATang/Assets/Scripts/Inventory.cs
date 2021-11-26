/*
 * Created By: Adam Tang
 * Date Created: 11/25/2021
 * Date Modified: 11/25/2021
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
    public GameObject player;
    private bool ObjItemOne;
    private bool ObjItemTwo;
    private EntityHealth playerHealth;
    private FirstPersonController playerController;


    void Awake()
    {
        numHealthPots = 0;
        numStaminaPots = 0;

        playerHealth = player.GetComponent<EntityHealth>();
        playerController = player.GetComponent<FirstPersonController>();
        ObjItemOne = false;
        ObjItemTwo = false;
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

    public bool hasObjItemOne()
    {
        return ObjItemOne;
    }

    public bool hasObjItemTwo()
    {
        return ObjItemTwo;
    }

    public void addObjOne()
    {
        ObjItemOne = true;
    }

    public void addObjTwo()
    {
        ObjItemTwo = true;
    }

    public void addHP()
    {
        numHealthPots++;
    }

    public void addSP()
    {
        numStaminaPots++;
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
            playerHealth.HealthPoints += healthAdded;
        }
        
    }

    public void useSP()
    {
        if (numStaminaPots > 0 && playerController!= null)
        {
            numStaminaPots--;
            playerController.sprintTime = playerController.maxSprintTime;
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
}
