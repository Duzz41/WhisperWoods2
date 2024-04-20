using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    void Update()
    {
        click();
    }

    void click()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            EvntManager.TriggerEvent("NextQue");
        }
    }
}
