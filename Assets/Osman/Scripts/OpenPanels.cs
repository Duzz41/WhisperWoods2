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
    public bool dontOpen;

    public void Open(GameObject panel)
    {
            _panelAnimator = panel.GetComponent<Animator>();
            _panelAnimator.SetTrigger("Open");
    }

    public void ChoosePanel(int i)
    {
        _panelAnimator = _panelsIndex[i]._panels[0].GetComponentInParent<Animator>();
        _panelAnimator.SetTrigger("Open");
        for (int a = 0; a < _panelsIndex[i]._panels.Count; a++)
        {
            _panelsIndex[i]._panels[a].SetActive(true);
        }
    }

}
