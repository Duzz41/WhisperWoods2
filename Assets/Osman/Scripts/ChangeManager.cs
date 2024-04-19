using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour
{
    public List<GameObject> _pages = new List<GameObject>();
    private PageManager pageManager;
    void Start()
    {
        pageManager = GetComponentInChildren<PageManager>();
    }
    
    public void ChangePageWithChoise(int index)
    {
        _pages[index].SetActive(true);
        pageManager._pageAnim.SetTrigger("Change");
    }

    public void ChangePage(int index)
    {
        if (_pages[index] == null)
            Debug.Log("Pages Over");
        else
        {
            _pages[index].SetActive(true);
            pageManager._pageAnim.SetTrigger("Change");
        }
    }
}
