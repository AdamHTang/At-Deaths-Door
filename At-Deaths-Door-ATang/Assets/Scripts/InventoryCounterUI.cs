/*
 * Created By: Adam Tang
 * Date Created: 11/25/2021
 * Date Modified: 11/25/2021
 * Description: Managers IN GAME UI elements (potions and objective items)
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCounterUI : MonoBehaviour
{
    public Inventory playerInv;
    private int healthPotNum;
    private int staminaPotNum;
    private int numKeys;
    public Text hpText;
    public Text spText;
    public Text keyText;


    void Awake()
    {
        healthPotNum = 0;
        staminaPotNum = 0;
        numKeys = 0;
        hpText.text = "Health Potions:  " + healthPotNum    + " (H)";
        spText.text = "Stamina Potions: " + staminaPotNum   + " (J)";
        keyText.text = "Keys: " + numKeys;
    }

    void Update()
    {
        healthPotNum = playerInv.getHealthPots();
        staminaPotNum = playerInv.getStaminaPots();
        numKeys = playerInv.getKeys();
        hpText.text = "Health Potions:  " + healthPotNum + "    (H)";
        spText.text = "Stamina Potions: " + staminaPotNum + "   (J)";
        keyText.text = "Keys: " + numKeys;
    }
}


