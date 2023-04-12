using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {
	public Vector3 m_target;
	public float damage;
	public float speed;

	bool Hit;

	RaycastHit m_Hit;

	public GameObject ExplosionVFX;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Hit == true)
        {
			if (m_target != null)
			{
				if (transform.position == m_target)
				{
					if(m_Hit.collider.tag == "Enemy")
                    {
						EnemyTarget EnemyHit = m_Hit.transform.GetComponent<EnemyTarget>();
						if (EnemyHit != null)
						{
							EnemyHit.TakeDamage(damage);
						}
					}
					explode();
					return;
				}
			}
			transform.position = Vector3.MoveTowards(transform.position, m_target, speed * Time.deltaTime);
        }
        else
        {
			transform.position += transform.forward * speed * Time.deltaTime;
        }
		
	}


	public void receiveHit(RaycastHit hit)
    {
		m_Hit = hit;
    }
    /*void OnTriggerEnter(Collider other)
    {
		if(other.tag == "Enemy")
        {
			EnemyTarget EnemyHit = other.transform.GetComponent<EnemyTarget>();
			if (EnemyHit != null)
			{

				EnemyHit.TakeDamage(damage);
			}
			Destroy(gameObject);
        }    
    }*/

	public void setTarget(Vector3 target)
    {
		m_target = target;
    }

	public void checkHit(bool isHit)
    {
		Hit = isHit;
    }

	void explode()
    {
		Destroy(gameObject);

		/*if (ExplosionVFX != null)
        {
			GameObject explode = Instantiate(ExplosionVFX, m_target, transform.rotation);
			
			Destroy(explode, 1f);
        }*/
    }
}
