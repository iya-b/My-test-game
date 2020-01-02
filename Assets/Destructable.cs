using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public float hitPoints = 100;
    public float hitPointsCurrent;

    // Start is called before the first frame update
    void Start()
    {
        hitPointsCurrent = hitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(float damage)
    {
        hitPointsCurrent -= damage;
        if (hitPointsCurrent <= 0)
        {
            Die();
        }
    }
    void MethodName()
    {

    }
    private void Die()
    {
        BroadcastMessage("Destroyed");
        Destroy(gameObject);
    }
}   
