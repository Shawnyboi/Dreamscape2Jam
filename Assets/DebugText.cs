using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    int logNumber = 0;
    BattlefieldFSM fsm;
    TMP_Text text;
    List<string> log;
    public int maxLogLength;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        fsm = FindObjectOfType<BattlefieldFSM>();
        fsm.onUnitFight += fightUpdate;
        log = new List<string>();
    }

    private void fightUpdate(Unit source, Unit target)
    {
        logNumber++;
        string newLine = (logNumber + ":" + source.m_UnitName + " hit " + target.m_UnitName + " for " + source.m_Attack + " damage, health was : " + target.m_Health +
            ", is now: " + (target.m_Health - source.m_Attack));
        if(log.Count <= maxLogLength)
        {
            log.Insert(0, newLine);
        } else
        {
            log.Insert(0, newLine);
            log.RemoveRange(maxLogLength, log.Count - maxLogLength);
        }
        updateText();
    }

    private void updateText()
    {
        string res = "";
        foreach(string s in log) { 
            res += s;
            res+= "\n";
        }
        text.text = res;
    }
}
