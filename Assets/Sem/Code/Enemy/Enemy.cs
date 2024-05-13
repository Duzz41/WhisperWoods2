using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int maxHealth = 100;
    public int health = 100;
    public int healRate = 10;
    public int damagePoints = 10;
    public int weakRate = 0;
    //critical damage is percent 
    public int criticalDamageChance = 20;

    public int criticalHealtThreshold = 20;

    private void Start()
    {
        //bu triggeri tetiikledigin durumda dusmandan kesinlikle ismini alip ona gore tetiklemen lazim
        EvntManager.StartListening<int>("TakeDamageEnemy" + enemyName, TakeDamageEnemy);
        EvntManager.StartListening("Weak" + enemyName, Weak);
        health = maxHealth;
    }


    public void TakeDamageEnemy(int damagePoints)
    {
        health -= damagePoints;
        Debug.Log("====ENEMY (" + enemyName + ")==== <DAMAGED>   - " + damagePoints + " - " + Time.time);
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
        yield return new WaitForSeconds(2f);
        //TODO: attack animation trigger
        Done();
    }
    public void MakeDecision()
    {
        Debug.Log("====ENEMY (" + enemyName + ")==== <MAKING DECISION>" + System.DateTime.Now);
        if (health <= criticalHealtThreshold)
        {
            health += healRate;
        }
        else
        {
            Attack();
        }
    }
    public void Attack()
    {
        Debug.Log("====ENEMY (" + enemyName + ")==== <ATTACK>" + System.DateTime.Now);

        EvntManager.TriggerEvent<int>("TakeDamage", CalculateCritic());
    }
    public void Weak()
    {
        weakRate++;
    }
    public void Done()
    {
        Debug.Log("====ENEMY (" + enemyName + ")==== <DONE>" + System.DateTime.Now);

        EvntManager.TriggerEvent("NextQ");
    }

    public int CalculateCritic()
    {
        int critChanceRate = Random.Range(0,criticalDamageChance);
        if (Random.value < (10 / 100))
        {
            return damagePoints + critChanceRate;
        }

        return damagePoints;
    }
}
