using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : MonoBehaviour
{
    public float shootRate;
    float shootTimeStamp;

    public GameObject LaserBulletprefab;

    
    public float range;
    void Start()
    {
        shootTimeStamp = shootRate;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(shootTimeStamp > shootRate)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                shootTimeStamp = 0;
            }
        }
        shootTimeStamp += Time.deltaTime;
        
    }
    
    void Shoot()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.collider.tag != "Enemy")
            {
                GameObject laser = Instantiate(LaserBulletprefab, transform.position, transform.rotation) as GameObject;
                laser.GetComponent<ShotBehavior>().checkHit(false);
                GameObject.Destroy(laser, 1.0f);
            }
            if(hit.collider.tag == "Enemy")
            {
                EnemyTarget EnemyHit = hit.transform.GetComponent<EnemyTarget>();
                GameObject laser = Instantiate(LaserBulletprefab, transform.position, transform.rotation) as GameObject;
                laser.GetComponent<ShotBehavior>().setTarget(hit.point);
                laser.GetComponent<ShotBehavior>().receiveHit(hit);
                laser.GetComponent<ShotBehavior>().checkHit(true);
            }
            
            
        }
        else
        {
            
        }

    }
}
