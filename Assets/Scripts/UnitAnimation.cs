using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    private void Awake()
    {
        if (m_Animator == null)
        {
            m_Animator = GetComponentInChildren<Animator>();
        }
    }

    public void Die()
    {
        m_Animator.SetTrigger("Die");
    }

    public void Throw()
    {
        m_Animator.SetTrigger("Throw");
    }

    public void Hurt()
    {
        m_Animator.SetTrigger("Hurt");
    }

    public void Cast()
    {
        m_Animator.SetTrigger("Cast");
    }

    public void Aggro()
    {
        m_Animator.SetBool("Fighting", true);
    }

    public void Idle()
    {
        m_Animator.SetBool("Fighting", false);
    }

    public void Walk()
    {
        m_Animator.SetBool("Walking", true);
    }

    public void StopWalk()
    {
        m_Animator.SetBool("Walking", false);
    }
}
