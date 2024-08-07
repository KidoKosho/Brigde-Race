using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Character : ColorObject
{
    [SerializeField] private CharacterBicker CharacterBricker;
    [SerializeField] Transform tranformsBricker;
    [SerializeField] private Animator anim;
    public Flatform Flatform;
    public ColorType ColorType;
    private Queue<Renderer> Stairs = new Queue<Renderer>();
    private string currentAnimName;
    private Stack<CharacterBicker> playerBrickers = new Stack<CharacterBicker>();
    private bool isCheckPlayGame = true;
    public bool IsCheckPlayGame => isCheckPlayGame;
    public int CountBricks => playerBrickers.Count;
    public override void ChangeColor(ColorType colorType)
    {
        base.ChangeColor(colorType);
        ColorType = colorType;
    }
    public virtual void AddBrick(Renderer bricker)
    {
        CharacterBicker playerbricker = Instantiate(CharacterBricker, tranformsBricker);
        playerbricker.transform.localPosition = Vector3.up*0.25f*CountBricks ;
        playerbricker.ChangeColor(ColorType);
        bricker.enabled = false;
        Stairs.Enqueue(bricker);
        playerBrickers.Push(playerbricker);
    }
    public void RemoveBrick()
    {
        if (Stairs.Count > 0) 
        {
            Stairs.Dequeue().enabled = true;
            Destroy(playerBrickers.Pop().gameObject);
        }
    }
    public void Clear()
    {
        for(int i=CountBricks-1;i >=0; --i)
        {
            Stairs.Dequeue();
            Destroy(playerBrickers.Pop().gameObject);
        }
        Stairs.Clear();
        playerBrickers.Clear();
    }
    public virtual void IsCheckPlay(bool check)
    {
        Debug.Log(isCheckPlayGame);
        isCheckPlayGame = check;
    }
    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            if(currentAnimName != null) anim.ResetTrigger(currentAnimName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
            Debug.Log(currentAnimName);
        }
    }
}
