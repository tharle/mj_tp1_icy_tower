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
    private bool m_dead = false;
    private Vector3 m_StartPosition;



    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_BoxCollider = GetComponent<BoxCollider2D>();
        m_Animator = GetComponentInChildren<Animator>();
        m_StartPosition = transform.position;
    }

    private void Update()
    {
        if (!m_dead)
        {
            bool isPlayerGround = IsGround();
            m_Animator.SetBool(GameParameters.AnimationPlayer.IS_GROUND, isPlayerGround);
            MovePlayer(isPlayerGround);
            JumpPlayer(isPlayerGround);

            VerifyAndFixPlayerBounds();

            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(GameParameters.LayerNames.DESTROYER))
        {
            StartCoroutine(DoDie());
        }
    }

    private void MovePlayer(bool isPlayerGround)
    {
        float speed = m_Speed;
        if(!isPlayerGround) speed /= 2;


        float axisHorizontal = Input.GetAxis(GameParameters.InputNames.AXIS_HORIZONTAL);
        float velocity_x = axisHorizontal * speed * Time.deltaTime;

        transform.Translate(new Vector3(velocity_x, 0, 0));

        if(axisHorizontal != 0) m_LookingLeft = axisHorizontal < 0;

        m_Animator.SetFloat(GameParameters.AnimationPlayer.VELOCITY_X, Math.Abs( velocity_x));
    }

    private void JumpPlayer(bool isPlayerGround)
    {   
        if (Input.GetKeyDown(KeyCode.Space)) { 
            if (isPlayerGround)
            {
                // Vector2 velocity = m_Rigidbody.velocity;
                // velocity.y = m_JumpSpeed;
                m_Rigidbody.AddForce(Vector2.up * m_JumpSpeed, ForceMode2D.Impulse);
                //m_Rigidbody.velocity = velocity;
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
        return m_GroundCheckCollider.IsTouchingLayers(LayerMask.GetMask(GameParameters.LayerNames.PLATAFORM));
    }

    private IEnumerator DoDie()
    {

        m_Animator.SetTrigger(GameParameters.AnimationPlayer.IS_DEAD);
        yield return new WaitForSeconds(2.8f);
        m_dead = true;
    }

    public bool IsDead()
    {
        return m_dead;
    }


    
}
