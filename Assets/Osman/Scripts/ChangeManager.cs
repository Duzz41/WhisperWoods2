using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour
{
public List<GameObject> _pages=new List<GameObject>();
public int _pageIndex;

public void ChangePage(int index)
{
    _pageIndex = index;
}
}
