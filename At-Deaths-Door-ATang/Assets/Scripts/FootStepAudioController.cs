/*
 * Created By: Adam Tang
 * Date Created: 12/6/2021
 * Date Modified: 12/6/2021
 * Description: Controls footstep audio of game object;
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class FootStepAudioController : MonoBehaviour
{
    public GameObject player;
    public float walkStepDelay = 3.0f;
    public float runStepDelay = 1.5f;
    private float speed;
    private float walkTimer;
    private float runTimer;
    private FirstPersonController fpc;
    private EntityHealth health;
    private Rigidbody body;

    public AudioSource walk1;
    public AudioSource walk2;
    public AudioSource walk3;
    public AudioSource walk4;
    public AudioSource run1;
    public AudioSource run2;
    public AudioSource run3;
    public AudioSource run4;
    public AudioSource jump1;
    public AudioSource jump2;
    public AudioSource land1;
    public AudioSource land2;

    private int randomWalk;
    private int randomRun;
    private int randomJump;
    private int randomLand;

    private void Awake()
    {
        fpc = player.GetComponent<FirstPersonController>();
        health = player.GetComponent<EntityHealth>();
        body = player.GetComponent<Rigidbody>();
        speed = 0.0f;
        randomWalk = Random.Range(1, 4);
        randomRun = Random.Range(1, 4);
        randomJump = Random.Range(1, 2);
        walkTimer = runStepDelay;
        runTimer = runStepDelay;
        speed = 0.0f;

    }

    void Update()
    {
        speed = body.velocity.magnitude;


        if (health.HealthPoints > 0)
        {
            if (fpc.Grounded)
            {
                if ((!Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))) || Input.GetKey(KeyCode.LeftShift) && fpc.sprintTime < 5.0f)
                {
                    if (walkTimer <= 0.0f)
                    {
                        randomWalk = Random.Range(1, 4);
                        if (randomWalk == 1)
                            walk1.Play();
                        if (randomWalk == 2)
                            walk2.Play();
                        if (randomWalk == 3)
                            walk3.Play();
                        if (randomWalk == 4)
                            walk4.Play();
                        runTimer = runStepDelay;
                        walkTimer = walkStepDelay;
                        Debug.Log("Walk Speed: " + speed);
                    } 
                        walkTimer -= Time.deltaTime;
                }
                
                //else if ((speed > fpc.SprintSpeed))
                  else if (fpc.sprintTime > 5.0f && Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
                {
                    if (runTimer <= 0)
                    {
                        randomRun = Random.Range(1, 4);
                        if (randomRun == 1)
                            run1.Play();
                        if (randomRun == 2)
                            run2.Play();
                        if (randomRun == 3)
                            run3.Play();
                        if (randomRun == 4)
                            run4.Play();

                        walkTimer = walkStepDelay;
                        runTimer = runStepDelay;
                        Debug.Log("Run Speed: " + speed);
                    }
                     runTimer -= Time.deltaTime;
                    
                }
                

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    fpc.Grounded = false;
                    randomJump = Random.Range(1, 2);
                    if (randomJump == 1) 
                    {
                        jump1.Play();
                    }

                    if (randomJump == 2)
                    {
                        jump2.Play();
                    }

                    walkTimer = 0.0f;
                    runTimer = 0.0f;
                }

            }
        }
    }
}
