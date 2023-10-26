using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    private PlayerController m_Player;
    private float m_DistanceMax = 2.5f;
    private float m_ElpseTime = 0;
    private float m_FrequenceCheck = 2.0f;

    private void Start()
    {
        m_Player = FindAnyObjectByType<PlayerController>();
    }

    public void Update()
    {
        // verifier la distance à chaque 2s

    }

    public void f() 
    {
        m_ElpseTime += Time.deltaTime;

        if (m_ElpseTime > m_FrequenceCheck)
        {
            m_ElpseTime = 0;
            Vector3 playerPosition = m_Player.gameObject.transform.position;
            float distance = Vector3.Distance(playerPosition, gameObject.transform.position);

            if (distance > m_DistanceMax)
            {
                Destroy(gameObject);
            }
        }
    }
}
