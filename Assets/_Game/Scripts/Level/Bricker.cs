using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;
using UnityEngine.iOS;

public class Bricker : ColorObject
{

    public GameObject bricker;
    public ColorType ColorType;
    public override void ChangeColor(ColorType colortype)
    {
        ColorType = colortype;
        base.ChangeColor(colortype);
    }
    public void Setactive(bool Check)
    {
        bricker.SetActive(Check);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Cache.Character(other).ColorType == ColorType && renderer.enabled == true )
        {
            Cache.Character(other).AddBrick(renderer);
        }
    }
}
