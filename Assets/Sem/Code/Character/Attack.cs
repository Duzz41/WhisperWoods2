using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Attack : MonoBehaviour
{
    public int coreDamage;
    [Header("light attack icin Kritik vurus sans araliklari")]
    public int criticalChanceRateForLightMin = 5;
    public int criticalChanceRateForLightMax = 10;

    [Header("light attack icin Kritik vurus araliklari")]

    public int criticalValueForLightMin = 30;
    public int criticalValueForLightMax = 40;

    [Header("heavy attack icin Kritik vurus sans araliklari")]

    public int criticalChanceRateForHeavyMin = 10;
    public int criticalChanceRateForHeavyMax = 20;

    [Header("Heavy attack icin Kritik vurus araliklari")]

    public int criticalValueForHeavyMin = 30;
    public int criticalValueForHeavyMax = 40;


    //karakter dusmanini secebilmeli 
    //sectigimiz dusmana hesaplanan degerlere gore damage verilmeli
    //alan hasari vuan bir damage eklenmeli mi tartisilacak. bilmedigimden
    public List<Enemy> enemies;

    public Enemy selectedEnemy;


    private void Start()
    {
        //su anlik tahminlerim listening ile degil attack buttonlarindan calisacagi yonunde simdilik bu sekilde bekleytiliyo
        EvntManager.StartListening<Enemy>("SelectAnEnemy", SelectAnEnemy);
    }

    /* 
        Light Attack olarak isimlendirdigimiz attack 
        sadece secili olan dusmana hasar veren bir yetenektir?

            Kontrol edilecekler>
        Sadece bir dusman secili olmalidir

            Kritik ve hasar degerleri> criticalRateForLightMin & Max
        %5 - %10 arasinda *test degerleri > ihtimali 
        %30 - %40 arasinda hasar verir

        
    */



    //test edilecek
    public int CalculateCritLight()
    {
        int critChanceRate = Random.Range(criticalValueForLightMin, criticalChanceRateForLightMax);
        int critValue = Random.Range(criticalValueForHeavyMin, criticalValueForHeavyMax);

        if (Random.value < (critChanceRate / 100))
        {   
            if (selectedEnemy.weakRate > 0)
            {
                critChanceRate = critChanceRate * (2*selectedEnemy.weakRate);
            }
            Debug.Log("TEST CRIT CHANCE" + critChanceRate + "TEST CRIT " + critValue);

            return coreDamage / (critValue / 100);
        }

        return coreDamage;
    }
    public int CalculateCritHeavy()
    {
        int critChanceRate = Random.Range(criticalChanceRateForHeavyMin, criticalChanceRateForHeavyMax);
        int critValue = Random.Range(criticalValueForHeavyMin, criticalValueForHeavyMax);

        if (Random.value < (critChanceRate / 100))
        {
            Debug.Log("TEST CRIT CHANCE FOR HEAVY " + critChanceRate + "TEST CRIT " + critValue);

            return coreDamage / (critValue / 100);
        }

        return coreDamage;
    }


    //karakterden bu fonksiyonu cagir
    public void AttackLight()
    {
        EvntManager.TriggerEvent("DisableAllButtons");
        if (selectedEnemy == null)
        {
            Debug.LogWarning("====PLAYER==== <ATTACK-FAILED> " + System.DateTime.Now);

        }
        else
        {
            Debug.Log("====PLAYER==== <ATTACK> " + "to > " + selectedEnemy.enemyName + " " + System.DateTime.Now);


            EvntManager.TriggerEvent<int>("TakeDamageEnemy" + selectedEnemy.enemyName, CalculateCritLight());
            EvntManager.TriggerEvent("NextQ");

        }
    }



    /*
        Heavy Attacck olarak isimlendirdigimiz attack
        tum dusmanlara hasar verme yetenegidir

            Kontrol edilecekler>
        dusmanlarin secili olmasi kontrol edilmez ve tum dusmanlara hasar verilir.

            Kritik ve hasar degerleri> criticalRateForHeavyMin & Max
        kritik seviyesi her dusmanlari farkli olarak etkiler
        %10 - %20 arasinda *test degerleri > core damage uzerinden hesaplanir 
    */
    public void AttackHeavy()
    {
        foreach (Enemy enemy in enemies)
        {
            EvntManager.TriggerEvent<int>("TakeDamageEnemy" + enemy.enemyName, CalculateCritHeavy());
        }
    }

    public void Weak()
    {
        EvntManager.TriggerEvent("DisableAllButtons");
        if (selectedEnemy == null)
        {
            Debug.LogWarning("====PLAYER==== <WEAK-FAILED> " + System.DateTime.Now);

        }
        else
        {
            Debug.Log("====PLAYER==== <WEAK> " + "to > " + selectedEnemy.enemyName + " " + System.DateTime.Now);


            
            EvntManager.TriggerEvent("NextQ");

        }
    }

    private void SelectAnEnemy(Enemy enemy)
    {
        selectedEnemy = enemy;
        Debug.Log("Enemy selected " + enemy.enemyName);
    }
}
