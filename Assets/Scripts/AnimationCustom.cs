using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCustom : MonoBehaviour
{
    [SerializeField] Vector3 m_Translation = Vector3.zero;


    private void Update()
    {
        AnimationTranslation();
    }

    /// <summary>
    /// Translate le player vers le top du écran.
    /// ça fait partie de la animation de mort.
    /// </summary>
    private void AnimationTranslation()
    {
        if (!m_Translation.Equals(Vector3.zero))
        {
            Debug.Log("TRANSLATION CHANGED");
            transform.Translate(m_Translation * Time.deltaTime);
            m_Translation = Vector3.zero;
        }
    }
}
