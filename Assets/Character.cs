using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour   
{
    [SerializeField]
    protected GameObject BulletPrefab;
    
    [SerializeField]
    protected Transform gun;

    [SerializeField]
    protected Transform launcher;

    [SerializeField]
    protected float bulletDamage = 10;

    [SerializeField]
    protected float shootPower = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShootBullet(Vector3 direction)
    {
        GameObject newBullet = Instantiate(BulletPrefab, gun.position, gun.rotation) as GameObject;
        newBullet.GetComponent<Rigidbody>().AddForce(direction * shootPower);
        Damager bulletBehaviour = newBullet.GetComponent<Damager>();
        bulletBehaviour.Damage = bulletDamage;
        bulletBehaviour.Owner = gameObject;

        Destroy(newBullet.gameObject, 5);
    }
}
