using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private PlayerController m_Player;
    [SerializeField] private GameObject m_Menu;

    private void Start()
    {
        m_Player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (m_Player.IsDead()) 
        {
            m_Menu.SetActive(true);
        } 
    }
}
