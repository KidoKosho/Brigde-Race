using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FindBrick : IState
{
    [HideInInspector] public int count = 0;
    private int countbricker_random = 0;    
    private UnityEngine.Vector3 target,dis;
   public void OnEnter(Enemy enemy)
   {
        Find(enemy);
        Debug.Log(count);
        countbricker_random = Random.Range(1, count+1);
        countbricker_random = (countbricker_random >= 10) ? 10 : countbricker_random;
        countbricker_random += enemy.CountBricks;
   }
    public void OnExecute(Enemy enemy)
    {
        if(countbricker_random <= enemy.CountBricks) 
        {
            enemy.ChangeState(new ClimbBrigde());
        }
        else if(enemy.IsDestionation)
        {
            Find(enemy);
            Debug.Log(countbricker_random);
        }
    }
    public void OnExit(Enemy enemy)
    {

    }
    public void Find(Enemy enemy)
    {
        count = 0;
        dis = enemy.Flatform.FindBricker(enemy.ColorType, enemy.transform.position, ref count);
        enemy.SetDestination(dis);
        enemy.ChangeAnim(Constant.TAG_RUN);
    }
}
