using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int coreDamage;
    
    //karakter dusmanini secebilmeli 
    //sectigimiz dusmana hesaplanan degerlere gore damage verilmeli
    //alan hasari vuan bir damage eklenmeli mi tartisilacak. bilmedigimden
    public List<Enemy> enemies;

    private void Start() {
        EvntManager.StartListening("LAttack", AttackLight);
        EvntManager.StartListening("HAttack", AttackHeavy);
    }
    private void AttackLight()
    {
        
    }
    private void AttackHeavy()
    {

    }
}
