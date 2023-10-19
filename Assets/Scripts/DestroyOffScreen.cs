using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject m_OffLimitScreen;

    private void LateUpdate()
    {
        if(m_OffLimitScreen != null && transform.position.y < m_OffLimitScreen.transform.position.y) 
        {
            Destroy(gameObject);
        }
    }
}
