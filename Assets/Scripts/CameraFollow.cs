using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ObjectToFollow;

    /// <summary>
    /// 
    /// </summary>
    private Vector2 m_OffsetVertical = new Vector2(0, 0.20f);
    private Vector3 m_StartPosition;
    private PlataformSpawnner m_PltaformSpawnner;

    private void Start()
    {
        m_PltaformSpawnner = FindAnyObjectByType<PlataformSpawnner>();
        m_StartPosition = transform.position;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        if (position.y + m_OffsetVertical.y < m_ObjectToFollow.transform.position.y )
        {
            position.y = m_ObjectToFollow.transform.position.y + m_OffsetVertical.y;
            m_PltaformSpawnner.SpawnNewPlataform();
        }
        transform.position = position;
    }
}
