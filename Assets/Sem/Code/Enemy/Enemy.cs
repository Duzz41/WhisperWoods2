using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int health = 100;
    public int damagePoints = 10;
    //critical damage is percent 
    public int criticalDamagePoints = 20;

    private void Start()
    {
        //bu triggeri tetiikledigin durumda dusmandan kesinlikle ismini alip ona gore tetiklemen lazim
        EvntManager.StartListening<int>("TakeDamageEnemy" + enemyName, TakeDamageEnemy);
    }


    public void TakeDamageEnemy(int damagePoints)
    {
        health -= damagePoints;
        Debug.Log("====ENEMY (" + enemyName + ")==== <DAMAGED>   - "+damagePoints +" - " + Time.time);
        //TODO: damage animation trigger
    }

    public void CheckLifeEnemy()
    {
        if (health <= 0)
        {
            Debug.Log("====ENEMY (" + enemyName + ")==== <DEAD>" + Time.time);

        }
    }
    public void starter()
    {
        EvntManager.TriggerEvent("DisableAllButtons");
        StartCoroutine(Playing());
    }

    public IEnumerator Playing()
    {
        //TODO: decision animation trigger
        yield return new WaitForSeconds(2f);
        MakeDecision();
        Attack();
        yield return new WaitForSeconds(2f);
        //TODO: attack animation trigger
        Done();
    }
    public void MakeDecision()
    {
        Debug.Log("====ENEMY (" + enemyName + ")==== <MAKING DECISION>" + System.DateTime.Now);

    }
    public void Attack()
    {
        Debug.Log("====ENEMY (" + enemyName + ")==== <ATTACK>" + System.DateTime.Now);

    }
    public void Done()
    {
        Debug.Log("====ENEMY (" + enemyName + ")==== <DONE>" + System.DateTime.Now);

        EvntManager.TriggerEvent("NextQ");
    }
}
