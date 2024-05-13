using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public List<Person> persons;
    private int combatQueLength;
    private int combatCurrentQue;
    private void Start()
    {
        Debug.Log("aaaa");
        EvntManager.StartListening("NextQ", nextQue);



        combatQueLength = persons.Count - 1;
        combatCurrentQue = 0;


        Debug.Log("Combat Que: " + combatQueLength + " \n Combat Current Que: " + combatCurrentQue);
        nextQue();
    }
    public void nextQue()
    {
        if (combatQueLength >= combatCurrentQue)
        {
            persons[combatCurrentQue].Assdasdas();
            Debug.Log("Combat Que: " + combatQueLength + " \n Combat Current Que: " + combatCurrentQue);
            combatCurrentQue++;


        }

        else
        {
            Debug.Log("allahionisikm");
            combatCurrentQue = 0;
            persons[combatCurrentQue].Assdasdas();
            Debug.Log("else Combat Que: " + combatQueLength + " \n Combat Current Que: " + combatCurrentQue);
            combatCurrentQue++;

        }


    }


}
