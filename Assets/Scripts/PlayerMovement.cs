using UnityEngine;
using UnityEngine.AI;
using Fusion;

public class PlayerMovement : NetworkBehaviour
{
    private CharacterController _controller;
    private NavMeshAgent agent;
    private Vector3 inputDirection;

    public float walkSpeed = 6;
    public float runSpeed = 12;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
    }

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {

    // }
    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            FollowCamera.Instance.target = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // float horInput = Input.GetAxis("Horizontal");
        // float verInput = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(horInput, 0f, verInput);

        // Vector3 moveDestination = transform.position + movement;

        // GetComponent<NavMeshAgent>().destination = moveDestination;

        // UpdateAnimator();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            agent.speed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            agent.speed = walkSpeed;
        }
    }


    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority)
        {
            float horInput = Input.GetAxis("Horizontal");
            float verInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horInput, 0f, verInput);
            Vector3 moveDestination = transform.position + movement;

            GetComponent<NavMeshAgent>().destination = moveDestination;

            UpdateAnimator();
        }
        transform.position = agent.nextPosition;
    }


    void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
