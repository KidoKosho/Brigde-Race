using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float speed = 5f;
    public UnityEngine.Vector3 offset;
    void Start()
    {
        transform.position = UnityEngine.Vector3.Lerp(transform.position, Player.position + offset, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = UnityEngine.Vector3.Lerp(transform.position, Player.position + offset, speed * Time.deltaTime);
    }
}
