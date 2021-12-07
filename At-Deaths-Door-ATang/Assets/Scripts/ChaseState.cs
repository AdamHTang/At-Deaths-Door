using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(SightLine), typeof(Animator))]
public class ChaseState : MonoBehaviour, IFSMState
{
    public FSMStateType StateName { get { return FSMStateType.Chase; } }

    public float MovementSpeed = 2.5f;
    public float Acceleration = 3.0f;
    public float AngularSpeed = 720.0f;
    public float FOV = 60.0f;
    public string AnimationChaseParamName = "Chase";
    public float chaseTimer = 10.0f;
    public float maxScreamTimer = 25.0f;
    public float minScreamTimer = 10.0f;
    public Transform player;
    public AudioSource scream;

    private float timeToChase;
    private float screamTimer;
    private bool isChasing = false;
    private readonly float MinChaseDistance = 2.0f;
    private NavMeshAgent ThisAgent;
    private SightLine SightLine;
    private float InitialFOV = 0.0f;
    private Animator ThisAnimator;

    private void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
        SightLine = GetComponent<SightLine>();
        ThisAnimator = GetComponent<Animator>();
        timeToChase = chaseTimer;
        screamTimer = 0.0f;
    }

    public void OnEnter()
    {
        InitialFOV = SightLine.FieldOfView;
        SightLine.FieldOfView = FOV;
        ThisAgent.isStopped = false;
        ThisAgent.speed = MovementSpeed;
        ThisAgent.acceleration = Acceleration;
        ThisAgent.angularSpeed = AngularSpeed;
        ThisAnimator.SetBool(AnimationChaseParamName, true);
        isChasing = true;
        
    }

    public void OnExit()
    {
        SightLine.FieldOfView = InitialFOV;
        ThisAgent.isStopped = true;
        isChasing = false;
    }

    public void DoAction()
    {
       
        ThisAgent.SetDestination(SightLine.LastKnowSighting);
    }

    public FSMStateType ShouldTransitionToState()
    {
        if (ThisAgent.remainingDistance <= MinChaseDistance)
        {
            return FSMStateType.Attack;
        }
        else if (!isChasing)
        {
            return FSMStateType.Patrol;
        }

        return FSMStateType.Chase;
    }

    void Update()
    {
        if (isChasing)
        {
            if (screamTimer < 0.0f)
            {
                scream.Play();
                screamTimer = Random.Range(minScreamTimer, maxScreamTimer);
            }
            else
            {
                screamTimer -= Time.deltaTime;
            }
        }

        if (timeToChase < 0.0f)
        {
            isChasing = false;
            screamTimer = 1.0f;
        } 


        Debug.Log("Time to chase - " + timeToChase);
        if (!SightLine.IsTargetInSightLine && isChasing)
        {
            timeToChase -= Time.deltaTime;
            ThisAgent.SetDestination(player.transform.position);

        } else if (SightLine.IsTargetInSightLine) {
            timeToChase = chaseTimer;

        }






        
    }
}