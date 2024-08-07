using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LevelManager.Ins.OnDespawn();
        LevelManager.Ins.player.gameObject.SetActive(false);
        if(other.CompareTag("Player"))
            LevelManager.Ins.OnWin();
        else LevelManager.Ins.OnLose();
    }
}
