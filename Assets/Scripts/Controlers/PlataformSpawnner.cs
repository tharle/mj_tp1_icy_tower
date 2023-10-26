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

        int randomIndex = GenerateRandomIndexPlataform();
        
        string newName = m_Plataforms[randomIndex].gameObject.name + "_lvl_" + ++m_stage;

        GameObject newPlataformGameObject = Instantiate(m_Plataforms[randomIndex], transform.position, Quaternion.identity);
        newPlataformGameObject.name = newName;
    }

    private int GenerateRandomIndexPlataform()
    {
        return Random.Range(6, m_Plataforms.Length - 1);
    }
}
