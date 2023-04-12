using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //retry UI
    public GameObject RetryUI;

    //player attribute
    [SerializeField] float health = 100;
    private float maxHealth;
    public PlayerHealthUI playerHealth;

    //for smooth rotation 
    [SerializeField] float TurnSmoothTime = 0.05f;
    private float turnSmoothVelocity;   
    //Variable
        //movement
    public float speed;
    Vector3 mousePos;
        //dash
    public float dashSpeed;
    public float dashTime;
    //get hit attribute
    bool getHit;

        //Animation
    private PlayerAnim m_AnimController;
    public PlayerAnim AnimController
    {
        get
        {
            if (m_AnimController == null)
            {
                m_AnimController = GetComponent<PlayerAnim>();
            }
            return m_AnimController;
        }
    }
    private InputController m_playerInput;
    public InputController playerInput
    {
        get
        {
            if(m_playerInput == null)
            {
                m_playerInput = GetComponent<InputController>();
            }
            return m_playerInput;
        }
    }
    

    void Awake()
    {
        maxHealth = health;
    }

    

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(playerInput.Horizontal, 0, playerInput.Vertical).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothTime);
        
        
        //Player Animation
        if (Input.GetButton("Fire1"))//direction change based on mouse click location
        {
            AnimController.Shoot();
            direction = new Vector3(0, 0, 0);
            RotateMouseLoc();
        }else if (direction.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            transform.position += direction * speed * Time.deltaTime;
            AnimController.Run();
        }
        else
        {
            AnimController.Idle();
        }

        
        


        //Dash
        if (Input.GetButtonDown("Dash"))
        {
            StartCoroutine(Dash(direction));
            
        }
    }

        
    IEnumerator Dash(Vector3 dir)
    {
        float startTime = Time.time;
        

        while(Time.time < startTime + dashTime)
        {
            transform.position += dir * dashSpeed * Time.deltaTime;

            yield return null;
        }
    }

    void RotateMouseLoc()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            mousePos = hit.point;
            mousePos.y = 0;
        }
        Vector3 forward = mousePos - new Vector3(transform.position.x, 0, transform.position.z);
        transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }

    



    public void changeHealth(float dmg)
    {
        health += dmg;
        playerHealth.changeHealth((dmg / maxHealth));
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //popup UI
        RetryUI.SetActive(true);
    }


}
