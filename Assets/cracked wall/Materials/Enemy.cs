using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character 
{
    public NavMeshAgent _navMeshAgent;

    [SerializeField]
    protected GameObject healthBonusPrefab;

    [SerializeField]
    public Transform target;
    public Transform Target { get; internal set; }

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float shootDelay = 5;

    private bool seeTarget;

    [SerializeField]
    private int Score = 25;

    [SerializeField]
    private GameObject explosionPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        InvokeRepeating("Shoot", 0.0f, shootDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            _navMeshAgent.SetDestination(target.position);
            CheckTargetVisibility();
        }
        
    }
    
    private void Shoot()
    {
        if (seeTarget == true)
        {
            Vector3 targetDirection = target.position - gun.transform.position;

            targetDirection.Normalize();

            ShootBullet(targetDirection);
        }
    }
    void Destroyed()
    {
        if (Random.Range(0, 100) < 50)
        {
            //HealthBonus.Create(transform.position);
            Instantiate(healthBonusPrefab, transform.position, Quaternion.identity);
            ScoreLabel.Score += 25;
            Explosion.Create(transform.position, explosionPrefab);
        }
    }

    void CheckTargetVisibility()
    {
        Vector3 targetDirection = target.position - gun.transform.position;
        

        Ray ray = new Ray(gun.transform.position, targetDirection);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == target)
            {
                seeTarget = true;
                return;
            }
        }

        seeTarget = false;

    }
  

}
