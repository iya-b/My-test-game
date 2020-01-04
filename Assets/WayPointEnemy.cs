using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointEnemy : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent navMeshAgent;

    [SerializeField]
    public Transform target;

    [SerializeField]
    public Transform[] wayPoint;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        MoveToWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if ((transform.position - playerTransform.position).magnitude < 20)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
        else
        {
            navMeshAgent.SetDestination(target.position);

            if ((transform.position - target.position).magnitude < 0.03f)
            {
                index++;
                if (index >= wayPoint.Length)
                {
                    index = 0;
                }

                MoveToWayPoint();
            }
        }

    }
    void MethodName()
    {
     
    }
    private void MoveToWayPoint()
    {
        target = wayPoint[index];
    }
}
