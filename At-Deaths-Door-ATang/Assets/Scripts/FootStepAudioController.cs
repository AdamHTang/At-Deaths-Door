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
        randomWalk = Random.Range(1, 4);
        randomRun = Random.Range(1, 4);
        randomJump = Random.Range(1, 2);
        randomLand = Random.Range(1, 2);

    }

    void Update()
    {
        if (health.HealthPoints > 0)
        {
            if (fpc.Grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                while (body.velocity.magnitude > 0 && body.velocity.magnitude <= fpc.MoveSpeed)
                {
                    if (randomWalk == 1)
                        walk1.Play();
                    if (randomWalk == 2)
                        walk2.Play();
                    if (randomWalk == 3)
                        walk3.Play();
                    if (randomWalk == 4)
                        walk4.Play();

                    randomWalk = Random.Range(1, 4);

                }
                while(body.velocity.magnitude > fpc.MoveSpeed)
                {
                    if (randomRun == 1)
                        run1.Play();
                    if (randomRun == 2)
                        run2.Play();
                    if (randomRun == 3)
                        run3.Play();
                    if (randomRun == 4)
                        run4.Play();

                    randomRun = Random.Range(1, 4);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (randomJump == 1)
                        jump1.Play();
                    if (randomJump == 2)
                        jump2.Play();

                    randomJump = Random.Range(1, 2);
                }

            }
        }
    }
}
