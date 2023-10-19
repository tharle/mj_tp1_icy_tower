using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    [SerializeField]
    private Transform m_OffLimitScreen;

    private void LateUpdate()
    {
        if(transform.position.y < m_OffLimitScreen.position.y) 
        {
            Destroy(gameObject);
        }
    }
}
