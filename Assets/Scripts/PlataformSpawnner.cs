using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformSpawnner : MonoBehaviour
{
    
    [SerializeField] GameObject[] m_Plataforms;
    private int m_stage;

    void Start()
    {
        // il y a 3 plataform en game. 
        m_stage = 3;
    }

    public void SpawnNewPlataform()
    {
        string newName = m_Plataforms[0].gameObject.name + "_lvl_" + m_stage;
        GameObject newPlataformGameObject = Instantiate(m_Plataforms[0], transform.position, Quaternion.identity);
        newPlataformGameObject.name = newName;
        Debug.Log("SPAW NEW PLATAFORM");
    }
}
