using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCharacterSO : MonoBehaviour
{
    public  ColorDataSO colorDataSO;
    public new Renderer renderer;
    public ColorType color;

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        renderer.material = colorDataSO.GetMat(colorType);
    }
}
