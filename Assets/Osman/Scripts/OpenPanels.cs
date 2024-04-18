using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanels : MonoBehaviour
{
    private Animator _panelAnimator;
    public void Open(GameObject panel)
    {
        _panelAnimator = panel.GetComponent<Animator>();
        _panelAnimator.SetTrigger("Open");
    }
}
