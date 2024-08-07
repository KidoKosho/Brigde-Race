    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.Build;
    using UnityEngine;
    using UnityEngine.UIElements;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    [SerializeField] FloatingJoystick joystick;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform rayCastStair;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask groundLayerMask;
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            IsCheckPlay(!IsCheckPlayGame);
        }
        if (!IsCheckPlayGame) return;
        if(Joystick.Ins.Vertical < 0f && IsCheckPlatform())
        {
            rb.velocity = UnityEngine.Vector3.zero;
        }
        else if(Joystick.Ins.Vertical > 0f&& CountBricks <= 0&&IsCheckRayCast())
        {
            rb.velocity = UnityEngine.Vector3.zero;
        }
        else
        {
            rb.velocity = new UnityEngine.Vector3(Joystick.Ins.Horizontal * speed, rb.velocity.y,Joystick.Ins.Vertical * speed);
        }
        if(Joystick.Ins.Horizontal!=0 || Joystick.Ins.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(new UnityEngine.Vector3(Joystick.Ins.Horizontal * speed, 0, Joystick.Ins.Vertical * speed));
            ChangeAnim(Constant.TAG_RUN);
        }
        //TODO:CACHE STRING
        else ChangeAnim(Constant.TAG_IDLE);

    }
    public bool IsCheckRayCast()
    {
        RaycastHit hit;
        Debug.DrawRay(rayCastStair.position, UnityEngine.Vector3.down, Color.red);
        if (Physics.Raycast(rayCastStair.position, UnityEngine.Vector3.down, out hit, 5f, groundLayer))
        {
            //TODO: CACH GETCOMPONENT
            Stair hitRenderer = Cache.Stair(hit.collider);
            return hitRenderer.ColorType != ColorType;
        }
        return false;
    }
    public bool IsCheckPlatform()
    {
        Debug.Log(Physics.Raycast(rayCastStair.position, UnityEngine.Vector3.down, 5f, groundLayerMask));
        return Physics.Raycast(rayCastStair.position, UnityEngine.Vector3.down, 5f, groundLayerMask);
    }
    public override void AddBrick(Renderer bricker)
    {
        base.AddBrick(bricker);
        Debug.Log("da an duoc r ne");
    }
}
