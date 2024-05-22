using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelectionController : MonoBehaviour
{
    public bool selected;
    public Outline outline;
    public EnemySelection enemySelection;

    private void Start()
    {
        outline.enabled = false;
        enemySelection = FindAnyObjectByType<EnemySelection>();
    }
    void OnMouseDown()
    {
        if (!selected && enemySelection.SelectedAny())
        {
            selected = true;
            outline.enabled = true;
            EvntManager.TriggerEvent("SelectAnEnemy", GetComponent<Enemy>());
        }
    }
}
