using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [SerializeField]
    private int _pageIndex;
    public int _panelCount;
    public List<GameObject> _panels = new List<GameObject>();
    private Animator _pageAnim;
    int _panelIndex = 0;
    private OpenPanels _openPanels;
    private ChangeManager _changePages;

    void Start()
    {
        _openPanels = GetComponentInChildren<OpenPanels>();
        _changePages = GetComponentInParent<ChangeManager>();
        _pageAnim = GetComponent<Animator>();
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
                if (_changePages._pages[_pageIndex + 1] == null)
                    Debug.Log("Pages Over");
                else
                {
                    _changePages._pages[_pageIndex + 1].SetActive(true);
                    _pageAnim.SetTrigger("Change");

                }
            }
        }
    }

    public void ClosePage()
    {
        this.gameObject.SetActive(false);
    }
}
