using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public int health = 100;
    public int damagePoints = 10;
    //critical damage is percent 
    public int criticalDamagePoints = 20;

    private void Start()
    {
        EvntManager.StartListening<int>("TakeDamage", TakeDamage);
    }


    public void TakeDamage(int damagePoints)
    {
        health -= damagePoints;
    }

    public void CheckLife()
    {
        if (health <= 0)
        {
            Debug.Log("====PLAYER==== <DEAD>" + Time.time);

        }
    }

    public void PlayingState()
    {
        Debug.Log("Playing State");
        EvntManager.TriggerEvent("EnableAllButtons");
        //EvntManager.TriggerEvent("NextQ");

    }




}
