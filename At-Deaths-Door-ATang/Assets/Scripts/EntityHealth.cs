/*
 * Created By: Adam Tang
 * Date Created: 11/25/2021
 * Date Modified: 11/25/2021
 * Description: Health system for entities existing in game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EntityHealth : MonoBehaviour
{
    // Variables //
    [SerializeField] private float _HealthPoints = 100f;
    private float maxHealth = 100f;
    public bool DestroyOnDeath = true;

    public HealthBar healthBar;


    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public float HealthPoints
    {
        get { return _HealthPoints; } // End get()
        set
        {
            _HealthPoints = value;
            if (HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);

                if (DestroyOnDeath)
                {
                    Destroy(gameObject);
                }
            }

        } // End set()
    } // End HealthPoints()

    public float getHealthPoints()
    {
        return _HealthPoints;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    void Update()
    {
        healthBar.SetHealth(getHealthPoints());
    }


}
