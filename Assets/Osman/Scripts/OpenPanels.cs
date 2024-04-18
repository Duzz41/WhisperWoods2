using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanels : MonoBehaviour
{
    private Animator _panelAnimator;
    void Start()
    {
        _panelAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Open();
    }
    //Buradaki tıklama kodu kullanıcağımız Input sisteme ve Oyun içerisindeki koşullara göre değişecektir.
    public void Open()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _panelAnimator.SetTrigger("Open");
        }
    }
}
