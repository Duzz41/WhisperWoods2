using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] public Person[] persons;
    private int combatQueLength;
    private int combatCurrentQue;
    private void Start()
    {





        EvntManager.StartListening("NextQue", nextQue);
        combatQueLength = persons.Length + 1;
        Debug.Log("Combat Que: " + combatQueLength);
        combatCurrentQue = 0;
        Debug.Log("Combat Current Que: " + combatCurrentQue);
        persons[combatCurrentQue].Playing();
    }

    #region Combat Que
    public void nextQue()
    {
        if (combatQueLength > combatCurrentQue)
        {
            combatCurrentQue++;
        }
        if (combatQueLength == combatCurrentQue)
        {
            combatCurrentQue = 0;
        }
        if (combatCurrentQue < 0)
        { Debug.LogWarning("combatQueLength < 0"); }

        persons[combatCurrentQue].Playing();
    }
    #endregion

}
