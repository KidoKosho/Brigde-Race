using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : GameUnit
{
    public new Renderer renderer;
    public ColorDataSO colorDataSO;
    public virtual void ChangeColor(ColorType colorType)
    {
        renderer.material = colorDataSO.GetMat(colorType);
    }
}
