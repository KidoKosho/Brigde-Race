using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform startPoint;
    public Transform finishPoint;
    public Flatform[] flatforms;
    public int botCount;

    public void OnInit()
    {
       for(int i = 0; i < flatforms.Length; i++)
        {
            flatforms[i].OnInit();
        }
    }
    public void OnDespawn()
    {
        for (int i = 0; i < flatforms.Length; i++)
        {
            flatforms[i].OnDespawn();
        }
    }
}
