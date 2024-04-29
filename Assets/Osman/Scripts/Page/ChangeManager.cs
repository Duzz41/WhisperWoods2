using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour
{
    public List<GameObject> _pages = new List<GameObject>();

    //2 Farlı sayfayı açabilen sayfalarda hangi sayfanın açılacağını belirler. Seçenekli sayfalarda bulunan butonlar bu fonksiyonu çalıştırması gerekir. 
    public void ChangePageWithChoise(int index)
    {
        _pages[index].SetActive(true);
    }


    public void ChangePage(int index)
    {
        if (_pages[index] == null)
            Debug.Log("Pages Over");
        else
        {
            _pages[index].SetActive(true);
        }
    }
}
