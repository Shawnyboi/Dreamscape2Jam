using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    private List<Unit> m_Units;
    private List<GameObject> m_UnitObjects;

    [SerializeField]
    private List<GameObject> m_UnitPrefabs;

    public List<Transform> m_Slots;


    private void Awake()
    {
        m_Units = new List<Unit>();
        m_UnitObjects = new List<GameObject>();
    }

    public void RandomizeUnits()
    {
        
        for (int i = 0; i < m_Slots.Count; i++)
        {
            GameObject unitPrefab = m_UnitPrefabs[Random.Range(0, m_UnitPrefabs.Count)];
            var unit = Instantiate(unitPrefab, m_Slots[i].position, Quaternion.identity, m_Slots[i].transform);
            m_Units.Add(unit.GetComponent<Unit>());
            m_UnitObjects.Add(unit);
            unit.GetComponent<Unit>().RandomizeStats();
        }
    }

    public bool GetFirstUnit(out Unit unit)
    {
        if(m_Units.Count == 0)
        {
            unit = null;
            return false;
        } 
        else
        {
            unit = m_Units[0];
            return true;
        }
    }    

    public int checkForDeadUnits()
    {
        List<int> deadUnits = new List<int>();
        for(int i = 0; i < m_Units.Count; i++)
        {
            if (m_Units[i].m_Health <= 0)
            {
                deadUnits.Add(i);
            }
        }

        foreach(int i in deadUnits)
        {
            m_Units.RemoveAt(i);
            Destroy(m_UnitObjects[i]);
            m_UnitObjects.RemoveAt(i);

        }

        return m_Units.Count;
    }
}
