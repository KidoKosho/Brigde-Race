using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : Singleton<BotManager>
{

    public List<Enemy> Bots = new List<Enemy>();
    public void AddEnemy(Enemy enemy)
    {
        enemy.IsCheckPlay(false);
        Bots.Add(enemy);
    }
    public void Clear()
    {
        for (int i = Bots.Count - 1; i >= 0; i--)
        {
            Bots[i].Clear();
        }
        Bots.Clear();
    }
    public void BottoPlay(bool check)
    {
        for(int i = 0;i < Bots.Count; i++)
        {
            Bots[i].IsCheckPlay(check);
        }
    }
}
