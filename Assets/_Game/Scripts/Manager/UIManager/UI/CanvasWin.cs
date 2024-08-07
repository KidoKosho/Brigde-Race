using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWin : UICanvas
{
    public void PlayAgainButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<CanvasMenu>();
        LevelManager.Ins.OnReset();
    }
    public void SettingButton()
    {
        UIManager.Ins.OpenUI<CanvasSetting>().SetState(this);
    }
    public void MainMenuButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<CanvasMenu>();
        LevelManager.Ins.OnReset();
    }
    public void NextLevelButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<CanvasGamePlay>();
        LevelManager.Ins.NextLevel();
    }
}
