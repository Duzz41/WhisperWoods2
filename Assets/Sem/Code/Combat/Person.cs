using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Person : MonoBehaviour
{
    [Header("Dusman veya ana karakterin \n saldiri ve diger fonksiyonlarini\n burada fonksiyon olarak eklemelisin. \n Eger dogru yapmazsan TENGRI cezalandirir!")]
    public UnityEvent action;
    public void Playing()
    {
        action.Invoke();
        //burada dusman veya oyuncunun karar mekanizmasini calisitirilmasini saglayacagiz

    }
}
