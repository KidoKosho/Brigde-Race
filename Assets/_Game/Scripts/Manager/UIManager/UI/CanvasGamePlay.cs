using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGamePlay : UICanvas
{ 
    public void SettingButton()
    {
        LevelManager.Ins.Characterplay(false);
        UIManager.Ins.OpenUI<CanvasSetting>().SetState(this);
    }
}
