using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttackCollider : MonoBehaviour
{
    public float damage;
    public bool HitPlayer;
    public float timeGapCollide;// can collide for intended interval time
    bool canCollide;

    public PlayerMovement playerAttribute;
    private void Awake()
    {
        playerAttribute = GameObject.Find("PlayerMain").GetComponent<PlayerMovement>();
    }
    void Start()
    {
        canCollide = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HitPlayer && canCollide)
        {
            playerAttribute.changeHealth(-damage);
            canCollide = false;
            Invoke(nameof(ResetAttack), timeGapCollide);
        }
    }

    void ResetAttack()
    {
        canCollide = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

            HitPlayer = true;
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

            HitPlayer = false;
        }
    }


}
