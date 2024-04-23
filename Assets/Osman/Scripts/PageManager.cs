using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    //Sayfanın Id'si
    [SerializeField]
    private int _pageID;
    //Bir sonra gidebileceği sayfaların Id'si
    [SerializeField]
    private int[] _nextPage;


    [SerializeField]
    private List<GameObject> _panels = new List<GameObject>();


    private List<OpenPanels> _openPanels;

    private Animator _pageAnim;
    private ChangeManager _changePages;
    private bool _pageChange = false;
    private int _panelIndex = 0;


    void Start()
    {

        EvntManager.StartListening("NextQue", PanelManagment);
        EvntManager.StartListening("IncreaseIndex", IncreasePanelIndex);

        foreach (GameObject p in _panels)
            _openPanels.Add(p.GetComponent<OpenPanels>());

        _changePages = GetComponentInParent<ChangeManager>();
        _pageAnim = GetComponent<Animator>();

    }

    void Update()
    {
        CloseAnimPage();
    }


    //Panellerin Açılma sırasını kontrol eder.
    public void PanelManagment()
    {

        if (_nextPage.Length == 1)
        {
            //Seçeneksiz ara panellerin açılmasını sağlar.
            if (_panelIndex != _panels.Count)
            {

                Debug.Log(_panelIndex);
                _openPanels[_panelIndex].Open();
                IncreasePanelIndex();

            }
            else //Seçeneksiz son panelden sonra sayfa değiştirilmesini sağlar.
            {
                _changePages.ChangePage(_nextPage[0]);
                _pageAnim.SetTrigger("Change");
            }

        }
        else
        {
            //Seçenekli sayfada(Yaptığımız seçeneklerin Yolu değiştirdiği sayfalarda) ara panellerin açılmasını sağlar.
            if (_panelIndex != _panels.Count)
            {
                _openPanels[_panelIndex].Open();
                IncreasePanelIndex();
            }

        }

    }

    //Açılacak olan Panellerin indexini arttırır. 
    void IncreasePanelIndex()
    {
        _panelIndex++;
    }

    //Animasyonlarda tıklamayı ve panel açılmasını engelleyen fonksiyona yönlendirilir.
    public void StopClick()
    {
        EvntManager.TriggerEvent("DisableCursor");
    }

    //Seçtiğimiz Butona göre belirtilen indexteki sayfa açılır. (Index sırası Change Managerda Pageleri koyduğumuz sıraya göre belirlenir)
    public void ChooseNextPage(int index)
    {
        _changePages.ChangePageWithChoise(index);
        _pageChange = true;
    }

    //Sayfa değişimindeki Animasyonu çalıştırır.
    public void CloseAnimPage()
    {
        if (_pageChange == true)
        {
            _pageAnim.SetTrigger("Change");
            _pageChange = false;
        }
    }

    //Kapanma animasyonun sonunda açık olan sayfayı kapatır.
    public void ClosePage()
    {
        this.gameObject.SetActive(false);
    }

}
