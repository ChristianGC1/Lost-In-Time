using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounterHelper : MonoBehaviour
{
    public ItemCount itemCount;

    public void AddEliminatedEnemy()
    {
        Debug.Log("Animation Event Ran");
        itemCount.AddEnemy();
        //GetComponent<ItemCount>().AddEnemy();
        this.enabled = false;
    }
}
