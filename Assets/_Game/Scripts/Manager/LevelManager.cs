using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : Singleton<LevelManager>
{
    public Level[] levelPrefabs;
    private Level currentLevel;
    public Enemy botPrefabs;
    public Player player;
    public int CharacterAmount => currentLevel.botCount + 1;
    private int level = 0;
    public void OnInit()
    {
        Vector3 index = currentLevel.startPoint.position;
        float space = 2f;
        Vector3 leftPont = ((CharacterAmount / 2) - (CharacterAmount % 2) * 0.5f) * space * Vector3.left + index;
        for (int i = 0; i < CharacterAmount; ++i)
        {
            Vector3 startCharacter = leftPont + space * i * Vector3.right;
            if (i == CharacterAmount / 2)
            {
                player.transform.position = startCharacter;
                player.transform.rotation = Quaternion.identity;
                player.gameObject.SetActive(true);
                player.ChangeColor((ColorType)i+1);
            }
            else
            {
                Enemy bot = SimplePool.Spawn<Enemy>(PoolType.Bot, startCharacter, Quaternion.identity);
                bot.Flatform = currentLevel.flatforms[0];
                bot.OnInit();
                bot.ChangeColor((ColorType)i+1);
                bot.ChangeAnim("idle");
                BotManager.Ins.AddEnemy(bot);
            }
            Characterplay(false);
        }
    }
    public void NextLevel()
    {
        level++;
        OnLoadLevel();
    }
    public void OnLoadLevel()
    {
        if(currentLevel != null) 
        { 
            Destroy(currentLevel.gameObject);
        }
        if(level < levelPrefabs.Length)
        {
            currentLevel = Instantiate(levelPrefabs[level],transform);
            currentLevel.OnInit();
            OnInit();
        }
        else
        {

        }
    }
    public void OnStartGame()
    {

    }
    public void OnFinishGame()
    {
       OnDespawn();
    }
    public void OnWin()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<CanvasWin>();
    }
    public void OnLose()
    {

    }

    public void OnReset()
    {
        OnDespawn();
        OnLoadLevel();
    }
    public void OnNextLevel(){
        level++;
        OnLoadLevel();
    }
    public void Characterplay( bool check)
    {
        BotManager.Ins.BottoPlay(check);
        player.IsCheckPlay(check);
    }
    public void OnDespawn() {
        Characterplay(false);
        player.Clear();
        BotManager.Ins.Clear();
        SimplePool.CollectAll();
        currentLevel.OnDespawn();
        if(currentLevel!=null) Destroy(currentLevel.gameObject);
    }
}
