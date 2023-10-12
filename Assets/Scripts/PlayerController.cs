using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float m_JumpSpeed = 10.0f;
    
    [SerializeField]
    float m_Speed = 5.0f;
    
    [SerializeField]
    Collider2D m_GroundCheckCollider;

    Rigidbody2D m_Rigidbody;
    

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space)) JumpPlayer();
    }


    private void MovePlayer()
    {
        float axisHorizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = m_Rigidbody.velocity;
        velocity.x = m_Speed * axisHorizontal;

        m_Rigidbody.velocity = velocity;
    }

    private void JumpPlayer()
    {
        if (isGround())
        {
            Debug.Log("Add force up");
            Vector2 velocity = m_Rigidbody.velocity;
            velocity.y = m_JumpSpeed;
            m_Rigidbody.velocity = velocity;
        }
    }

    private bool isGround()
    {
        return m_GroundCheckCollider.IsTouchingLayers(LayerMask.GetMask("Plataform"));
    }
}
