using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private Flatform Flatform;

    private void OnTriggerEnter(Collider other)
    {
        Character character = Cache.Character(other);
        character.Flatform = Flatform;
        Flatform.CollorBricks(character.ColorType, true);
    }
}
