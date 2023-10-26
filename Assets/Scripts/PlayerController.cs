using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_JumpSpeed = 10.0f;
    
    [SerializeField]
    private float m_Speed = 5.0f;
    
    [SerializeField]
    private Collider2D m_GroundCheckCollider;

    [SerializeField]
    private Transform m_LimitLeft;
    [SerializeField]
    private Transform m_LimitRight;

    private Rigidbody2D m_Rigidbody;
    private BoxCollider2D m_BoxCollider;
    private Animator m_Animator; 

    private bool m_LookingLeft = false;
    private bool m_die = false;



    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_BoxCollider = GetComponent<BoxCollider2D>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!m_die)
        {
            bool isPlayerGround = IsGround();
            m_Animator.SetBool("isGround", isPlayerGround);
            MovePlayer(isPlayerGround);
            JumpPlayer(isPlayerGround);

            VerifyAndFixPlayerBounds();

            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
        {
            Die();
        }
    }


    private void MovePlayerByForce()
    {
        float axisHorizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = m_Rigidbody.velocity;
        velocity.x = m_Speed * axisHorizontal;

        m_Rigidbody.velocity = velocity;

        if (axisHorizontal != 0) m_LookingLeft = axisHorizontal > 0;

    }

    private void MovePlayer(bool isPlayerGround)
    {
        float speed = m_Speed;
        if(!isPlayerGround) speed /= 2;


        float axisHorizontal = Input.GetAxis("Horizontal");
        float velocity_x = axisHorizontal * speed * Time.deltaTime;

        transform.Translate(new Vector3(velocity_x, 0, 0));

        if(axisHorizontal != 0) m_LookingLeft = axisHorizontal < 0;

        m_Animator.SetFloat("velocity_x", Math.Abs( velocity_x));
    }

    private void JumpPlayer(bool isPlayerGround)
    {   
        if (Input.GetKeyDown(KeyCode.Space)) { 
            if (isPlayerGround)
            {
                Debug.Log("Add force up");
                Vector2 velocity = m_Rigidbody.velocity;
                velocity.y = m_JumpSpeed;
                m_Rigidbody.velocity = velocity;
            }
        }
    }

    private void VerifyAndFixPlayerBounds()
    {
        Vector3 position = transform.position;

        float boundLeft     = m_LimitLeft.position.x + m_BoxCollider.size.x/2;
        float boundRight    = m_LimitRight.position.x - m_BoxCollider.size.x/2;

        if (position.x < boundLeft) position.x = boundLeft;
        else if (position.x > boundRight) position.x = boundRight;

        transform.position = position;
    }

    private void Flip()
    {
        Vector3 scale = transform.transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        
        if (m_LookingLeft) scale.x *= -1;

        transform.transform.localScale = scale;
    }

    private bool IsGround()
    {
        return m_GroundCheckCollider.IsTouchingLayers(LayerMask.GetMask("Plataform"));
    }

    private void Die()
    {
        m_Animator.SetTrigger("die");
        m_die = true;
    }


    
}
