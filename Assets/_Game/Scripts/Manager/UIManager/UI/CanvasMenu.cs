using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenu : UICanvas 
{
    public void PlayGameButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<CanvasGamePlay>();
        LevelManager.Ins.Characterplay(true);
    }
    public void SettingButton()
    {
        UIManager.Ins.OpenUI<CanvasSetting>().SetState(this);
    }
}
