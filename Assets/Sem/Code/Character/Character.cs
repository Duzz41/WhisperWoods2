using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    #region var
    public int health = 100;
    public int damagePoint = 10;
    //critical damage is percent 
    public int criticalDamagePoint = 20;
    #endregion

    #region class
    private Attack attack;
    #endregion
    private void Awake()
    {
        attack = GetComponent<Attack>();
        attack.coreDamage = damagePoint;
    }
    private void Start()
    {
        EvntManager.StartListening<int>("TakeDamage", TakeDamage);
    }


    public void TakeDamage(int value)
    {
        health -= value;
        CheckLife();
    }

    public void CheckLife()
    {
        if (health <= 0)
        {
            Debug.Log("====PLAYER==== <DEAD>" + System.DateTime.Now);
        }
    }

    public void PlayingState()
    {
        Debug.Log("====PLAYER==== <PLAYING>" + System.DateTime.Now);

        EvntManager.TriggerEvent("EnableAllButtons");
    }




}
