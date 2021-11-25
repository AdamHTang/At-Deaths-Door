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

public class Inventory : MonoBehaviour
{
    public int numHealthPots;
    public int numStaminaPots;
    public bool hasObjItemOne;
    public bool hasObjItemTwo;


    void Awake()
    {
        numHealthPots = 0;
        numStaminaPots = 0;
        hasObjItemOne = false;
        hasObjItemTwo = false;
    }

     void Update()
    {
        


    }
}
