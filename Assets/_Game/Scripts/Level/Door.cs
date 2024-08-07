using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Door : MonoBehaviour
{
    [SerializeField] private Flatform platform;
    public Transform[] transfromsdoors;
    private void OnTriggerEnter(Collider other)
    {
       platform.CollorBricks(Cache.Character(other).ColorType, false);
    }
}
