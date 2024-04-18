using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public int _panelCount;
    private OpenPanels _openPanels;
    int _panelIndex = 0;
    public List<GameObject> _panels = new List<GameObject>();
    void Start()
    {
        _openPanels = GetComponentInChildren<OpenPanels>();
    }
    void Update()
    {
        OpenPanel();
    }

    void OpenPanel()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_panelIndex != _panelCount)
            {
                _openPanels.Open(_panels[_panelIndex]);
                _panelIndex++;
            }
            else
            {
                //buraya sayfa değiştirme animasyonu eklenecek
                this.gameObject.SetActive(false);
            }
        }
    }
}
