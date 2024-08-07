using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClimbBrigde : IState
{
    public int index = 0;
    public void OnEnter(Enemy enemy)
    {
        index = 0;
        enemy.SetDestination(enemy.doorsposition[index]);
    }
    public void OnExecute(Enemy enemy)
    {
        if (enemy.IsDestionation)
        {
            if (index != enemy.doorsposition.Count - 1) enemy.SetDestination(enemy.doorsposition[++index]);
            else 
            {
                enemy.Randomdoor();
                enemy.ChangeState(new FindBrick());
            }
        }
        else if (enemy.CountBricks <= 0&& index <=1)
        {
            enemy.ChangeState(new FindBrick());
        }
    }
    public void OnExit(Enemy enemy)
    {

    }
}
