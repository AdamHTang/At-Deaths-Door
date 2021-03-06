/*
 * Created By: Adam Tang
 * Date Created: 11/25/2021
 * Date Modified: 12/4/2021
 * Description: Health system for entities existing in game.
 */

using StarterAssets;
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
    private FirstPersonController fpController;

    public HealthBar healthBar;
    public AudioSource hit1;
    public AudioSource hit2;
    public AudioSource death;
    private bool toggleHitSound  = false;

    void Awake()
    {
        fpController = gameObject.GetComponent<FirstPersonController>();
    }
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
                fpController.MoveSpeed = 0.0f;
                fpController.SpeedChangeRate = 0.0f;
                fpController.JumpHeight = 0.0f;
                fpController.RotationSpeed = 0.0f;
                gameObject.transform.rotation = Quaternion.Euler(-90.0f, transform.localRotation.y, transform.localRotation.z);
                
                if (HealthPoints == 0)
                {
                    death.Play();
                }

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

    public void playerHit()
    {
        if (toggleHitSound)
        {
            hit1.Play();
            toggleHitSound = !toggleHitSound;
        } else
        {
            hit2.Play();
            toggleHitSound = !toggleHitSound;
        }
    }

    void Update()
    {
        healthBar.SetHealth(getHealthPoints());

    }


}
