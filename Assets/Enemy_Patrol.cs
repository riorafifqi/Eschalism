using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Patrol : StateMachineBehaviour
{
    NavMeshAgent enemy;
    FieldOfView fov;

    Transform moveSpot;
    private float waitTime;
    public float startWaitTime;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public void Awake()
    {
        moveSpot = GameObject.Find("MoveSpot").transform;
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<NavMeshAgent>();
        fov = animator.GetComponentInChildren<FieldOfView>();
        waitTime = startWaitTime;
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 1.33f, Random.Range(minZ, maxZ));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.SetDestination(moveSpot.position);
        // Debug.Log(moveSpot.position);
        // Debug.Log(Vector3.Distance(animator.transform.position, moveSpot.position));

        if (Vector3.Distance(animator.transform.position, moveSpot.position) <= 0.2f)
        {
            // New random spot
            moveSpot.position = new Vector3(Random.Range(minX, maxX), 1.33f, Random.Range(minZ, maxZ));
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        
        if (fov.visibleTargets.Any())
        {
            animator.SetBool("isChasing", true);
        }
        else
        {
            animator.SetBool("isChasing", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
