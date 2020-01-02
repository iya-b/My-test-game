using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destructable player = other.gameObject.GetComponent<Destructable>();
        if (player != null)
        {
            player.hitPointsCurrent = player.hitPoints;
    	    Destroy(gameObject);
	    }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destructable player = collision.gameObject.GetComponent<Destructable>();
        if (player != null)
        {
            player.hitPointsCurrent = player.hitPoints;
            Destroy(gameObject);
        }
    }
    public static void Create(Vector3 position)
    {
        Instantiate(Resources.Load("HealthBonus"), position, Quaternion.identity);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
