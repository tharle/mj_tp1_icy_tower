using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ObjectToFollow;
    private Vector2 m_OffsetVertical = new Vector2(0, 0.24f);
    private PlataformSpawnner m_PltaformSpawnner;

    private void Start()
    {
        m_PltaformSpawnner = FindAnyObjectByType<PlataformSpawnner>();
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
