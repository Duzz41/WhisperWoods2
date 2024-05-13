using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelection : MonoBehaviour
{
    public List<EnemySelectionController> enemies;

    public bool SelectedAny()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].selected)
            {
                return true;
            }
        }
        return false;
    }
    
}
