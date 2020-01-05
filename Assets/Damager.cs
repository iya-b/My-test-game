
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
   [SerializeField]
    private float damage;

    private GameObject owner;
    public float Damage 
    {
       get { return damage; }
       set { damage = value;}
    }

    public GameObject Owner
    {
        get { return owner; }
        set { owner = value; }
    }

     [SerializeField]
    private GameObject explosionPrefab;

    private float radius;
    private void OnCollisionEnter(Collision collision)
    {
        if (!GameObject.Equals(collision.gameObject, Owner))
        {
            Destructable target = collision.gameObject.GetComponent<Destructable>();
            if (target != null)
            {
                target.Hit(Damage);
            }

             Destroy(gameObject);
            if (explosionPrefab != null)
            {
                Explosion.Create(transform.position, explosionPrefab);
            }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
