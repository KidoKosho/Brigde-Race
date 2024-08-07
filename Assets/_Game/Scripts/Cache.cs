using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache
{
    private static Dictionary<Collider, Character> diccharacter = new Dictionary<Collider, Character>();
    private static Dictionary<Collider, Stair> dicstair = new Dictionary<Collider, Stair>();
    public static Character Character(Collider collider)
    {
        if (!diccharacter.ContainsKey(collider))
        {
            Character character = collider.GetComponent<Character>();
            diccharacter.Add(collider, character);
        }
        return diccharacter[collider];
    }
    public static Stair Stair(Collider collider)
    {
        if(!dicstair.ContainsKey(collider))
        {
            Stair stair = collider.GetComponent<Stair>();
            dicstair.Add(collider, stair);
        }
        return dicstair[collider];
    }
}
