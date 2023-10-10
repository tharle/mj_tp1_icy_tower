using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float m_JumpForce = 10.0f;
    [SerializeField]
    float m_Speed = 5.0f;

    Rigidbody2D m_Rigidbody;
    Collider2D m_GroundCheck;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_GroundCheck = GetComponentInChildren<Collider2D>();
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
        Debug.Log("Add force up");
        m_Rigidbody.AddForce(Vector2.up * m_JumpForce);
    }

}
