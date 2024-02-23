using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int m_Health = 1;
    public int m_Attack = 1;
    public string m_UnitName = string.Empty;
    public string m_AbilityType;


    [SerializeField]
    private UnitAnimation m_Animation;


    private void Awake()
    {
        if(m_Animation == null)
        {
            m_Animation = GetComponentInChildren<UnitAnimation>();
        }
    }

    public void TakeDamage(int amt)
    {
        m_Health -= amt;
        m_Animation.Hurt();
    }

    public void Attack(){
        m_Animation.Cast();
    }

    public IEnumerator Die()
    {
        m_Animation.Die();
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    public void Aggro()
    {
        m_Animation.Aggro();
    }

    public void Idle()
    {
        m_Animation.Idle();
    }

    public void RandomizeStats()
    {
        m_UnitName = transform.parent.gameObject.name;
        m_Health = Random.Range(1, 5);
        m_Attack = Random.Range(1, 5);
    }


}
