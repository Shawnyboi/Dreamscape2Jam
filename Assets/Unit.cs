using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int m_Health = 1;
    public int m_Attack = 1;
    public string m_UnitName = string.Empty;

    public string m_AbilityType;

    public void RandomizeStats()
    {
        m_UnitName = transform.parent.gameObject.name;
        m_Health = Random.Range(1, 5);
        m_Attack = Random.Range(1, 5);
    }


}
