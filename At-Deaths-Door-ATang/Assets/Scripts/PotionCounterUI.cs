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

public class PotionCounterUI : MonoBehaviour
{
    public Inventory playerInv;
    private int healthPotNum;
    private int staminaPotNum;
    public Text hpText;
    public Text spText;

    void Awake()
    {
        healthPotNum = 0;
        staminaPotNum = 0;
        hpText.text = "Health Potions:  " + healthPotNum    + " (H)";
        spText.text = "Stamina Potions: " + staminaPotNum   + " (J)";
    }

    void Update()
    {
        healthPotNum = playerInv.getHealthPots();
        staminaPotNum = playerInv.getStaminaPots();
        hpText.text = "Health Potions:  " + healthPotNum + "    (H)";
        spText.text = "Stamina Potions: " + staminaPotNum + "   (J)";
    }
}


