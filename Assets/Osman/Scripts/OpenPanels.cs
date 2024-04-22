using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using System;
using UnityEngine.UI;

public class OpenPanels : MonoBehaviour
{
    private Animator _panelAnimator;
    public Panels[] _panelsIndex;
    public GameObject[] _buttons;

    public void Open()
    {
        _panelAnimator = this.GetComponent<Animator>();
        _panelAnimator.SetTrigger("Open");
    }

    public void ChoosePanel(int i)
    {
        _panelAnimator = _panelsIndex[i]._panels[0].GetComponentInParent<Animator>();
        _panelAnimator.SetTrigger("Open");
        
        foreach (GameObject b in _buttons)
            b.GetComponent<Button>().interactable = false;
        foreach (GameObject a in _panelsIndex[i]._panels)
            a.SetActive(true);
        DontOpen();
        EvntManager.TriggerEvent("IncreaseIndex");
    }


    public void DontOpen()
    {
        EvntManager.TriggerEvent("DisableCursor");
    }
}
