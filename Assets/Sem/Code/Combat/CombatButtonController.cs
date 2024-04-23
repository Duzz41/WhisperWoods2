using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
public class CombatButtonController : MonoBehaviour
{
    public List<Button> CombatButtons;

    private GameObject MainButtonGO;
    public void Awake()
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
        //ilk basta normal durumunda disable olmali gibi
    }

    public void DisableAllButtons()
    {
        foreach (Button button in CombatButtons)
        {
            button.enabled = false;
        }
        Debug.Log("> " + this.name + " " + CombatButtons.Count + " button disabled " +  System.DateTime.Now);
    }
    public void EnableAllButtons()
    {
        foreach (Button button in CombatButtons)
        {
            button.enabled = true;
        }
        Debug.Log("> " + this.name + " " + CombatButtons.Count + " button enabled " +  System.DateTime.Now);

    }

}
