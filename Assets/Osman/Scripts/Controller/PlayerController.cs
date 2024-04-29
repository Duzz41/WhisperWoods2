using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    bool dontClick = false;

    void Start()
    {
        EvntManager.StartListening("DisableCursor", DisableClick);
    }
    void Update()
    {
        if (dontClick == false)
            click();
    }

    void click()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            EvntManager.TriggerEvent("NextQue");
        }
    }

    void DisableClick()
    {
        if (dontClick == false)
            dontClick = true;
        else
            dontClick = false;
    }
}
