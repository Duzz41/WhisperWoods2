using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    //Sayfanın Id'si
    [SerializeField] private int _pageID;
    //Bir sonra gidebileceği sayfaların Id'si
    [SerializeField] private int[] _pageChoises;


    public List<GameObject> _panels = new List<GameObject>();
    public Animator _pageAnim;
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
        if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
        {
            if (_pageChoises.Length == 1)
            {
                if (_panelIndex != _panels.Count)
                {
                    _openPanels.Open(_panels[_panelIndex]);
                    _panelIndex++;
                }
                else
                {
                    //buraya sayfa değiştirme animasyonu eklenecek
                    _changePages.ChangePage(_pageChoises[0]);
                }
            }
            else
            {
                if (_panelIndex != _panels.Count)
                {
                    _openPanels.Open(_panels[_panelIndex]);
                    _panelIndex++;
                }
            }

        }
    }

    public void ClosePage()
    {
        this.gameObject.SetActive(false);
    }
}
