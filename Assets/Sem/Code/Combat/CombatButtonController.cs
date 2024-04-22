using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CombatButtonController : MonoBehaviour
{
    public List<Button> CombatButtons;

    private GameObject MainButtonGO;
    public void Start()
    {
        //triigers
        EvntManager.StartListening("DisableAllButtons", DisableAllButtons);
        EvntManager.StartListening("EnableAllButtons", EnableAllButtons);


        //for dongusu tum buttonlari childden cekmek icin
        MainButtonGO = this.gameObject;
        for (int i = 0; i < MainButtonGO.transform.childCount; i++)
        {
            CombatButtons.Add(MainButtonGO.transform.GetChild(i).GetComponent<Button>());
        }
    }

    public void DisableAllButtons()
    {
        foreach (Button button in CombatButtons)
        {
            button.enabled = false;
        }
        Debug.Log(this.name + " " + CombatButtons.Count + " button disabled");
    }
    public void EnableAllButtons()
    {
        foreach (Button button in CombatButtons)
        {
            button.enabled = true;
        }
        Debug.Log(this.name + " " + CombatButtons.Count + " button enabled");

    }

}
