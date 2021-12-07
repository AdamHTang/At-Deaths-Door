using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(SightLine), typeof(Animator))]
public class PatrolState : MonoBehaviour, IFSMState
{
    public Transform Destination;
    public float MovementSpeed = 1.5f;
    public float Acceleration = 2.0f;
    public float AngularSpeed = 360.0f;
    public string AnimationRunParamName = "Chase";
    public string AnimationIdleParamName = "Idle";
    public AudioSource patrolSound1;
    public AudioSource patrolSound2;
    public AudioSource patrolSound3;
    public AudioSource patrolSound4;
    public float soundTimerMax = 15.0f;
    public float soundTimerMin = 7.5f;

    private float soundTimer;
    private int randomSound;


    public FSMStateType StateName { get { return FSMStateType.Patrol; } }

    private NavMeshAgent ThisAgent;
    private SightLine ThisSightLine;
    private Animator ThisAnimator;

    private void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
        ThisSightLine = GetComponent<SightLine>();
        ThisAnimator = GetComponent<Animator>();
        soundTimer = Random.Range(soundTimerMin, soundTimerMax);
        randomSound = 1;
    }

    public void OnEnter()
    {
        ThisAgent.isStopped = false;
        ThisAgent.speed = MovementSpeed;
        ThisAgent.acceleration = Acceleration;
        ThisAgent.angularSpeed = AngularSpeed;
        ThisAnimator.SetBool(AnimationRunParamName, false);
    }

    public void OnExit()
    {
        ThisAgent.isStopped = true;
        soundTimer = Random.Range(soundTimerMin, soundTimerMax);
    }

    public void DoAction()
    {
        ThisAgent.SetDestination(Destination.position);
    }

    public FSMStateType ShouldTransitionToState()
    {
        if (ThisSightLine.IsTargetInSightLine)
        {
            return FSMStateType.Chase;
        }

        return StateName;
    }

    private void Update()
    {
        if (soundTimer < 0)
        {
            randomSound = Random.Range(1, 4);

            if (randomSound == 1)
            {
                patrolSound1.Play();
            }

            if (randomSound == 2)
            {
                patrolSound2.Play();
            }

            if (randomSound == 3)
            {
                patrolSound3.Play();
            }

            if (randomSound == 4)
            {
                patrolSound4.Play();
            }

            soundTimer = Random.Range(soundTimerMin, soundTimerMax);
        } else
        {
            soundTimer -= Time.deltaTime;
        }
    }



}