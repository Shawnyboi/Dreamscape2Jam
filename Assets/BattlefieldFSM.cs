using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldFSM : MonoBehaviour
{
    private string m_CurrentState = "SetUp";
    private bool m_IsDone = false;

    public delegate void UnitFightDelegate(Unit source, Unit target);
    public UnitFightDelegate onUnitFight;

    public delegate void VoidDelegate();
    public VoidDelegate onSetUp;

    [SerializeField]
    private Units m_GoodGuys;

    [SerializeField]
    private Units m_BadGuys;

    void Start()
    {
        StartCoroutine(GameLoop()); 
    }

    private IEnumerator GameLoop()
    {
        while (!m_IsDone)
        {
            yield return HandleCurrentState();
        }
        yield return null;
    }

    private IEnumerator HandleCurrentState()
    {
        switch (m_CurrentState)
        {
            case "SetUp":

                m_GoodGuys.RandomizeUnits();
                m_BadGuys.RandomizeUnits();

                onSetUp?.Invoke();

                m_CurrentState = "Ability";
                break;

            case "Ability":

                m_CurrentState = "Attack";

                break;

            case "Attack":

                Unit badGuy, goodGuy;

                if(m_GoodGuys.GetFirstUnit(out goodGuy) && m_BadGuys.GetFirstUnit(out badGuy))
                {
                    onUnitFight?.Invoke(badGuy, goodGuy);
                    onUnitFight?.Invoke(goodGuy, badGuy);
                    badGuy.m_Health -= goodGuy.m_Attack;
                    goodGuy.m_Health -= badGuy.m_Attack;
                }

                m_CurrentState = "CleanUp";
                break;

            case "CleanUp":

                int remainingBadGuys = m_BadGuys.checkForDeadUnits();
                int remainingGoodGuys = m_GoodGuys.checkForDeadUnits();

                if(remainingBadGuys == 0 || remainingGoodGuys == 0)
                {
                    m_CurrentState = "End";
                } 
                else
                {
                    m_CurrentState = "Ability";
                }
                break;

            case "End":
                m_IsDone = true;
                break;

            
        }
        yield return new WaitForSeconds(1.0f);
    }
}
