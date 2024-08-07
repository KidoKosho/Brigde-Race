using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : ColorObject
{
    public ColorType ColorType;
    private void OnTriggerEnter(Collider other)
    {
        if (renderer == null) return;
        Character character = Cache.Character(other);
        if (character.ColorType != ColorType&& character.CountBricks > 0)
        {
                if(renderer.enabled == false) renderer.enabled = true;
                ColorType = character.ColorType;
                ChangeColor(ColorType); 
                character.RemoveBrick();
        }
    }
}
