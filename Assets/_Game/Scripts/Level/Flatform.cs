using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flatform : MonoBehaviour
{
    [SerializeField] private Transform[] transformsbrickers;
    [SerializeField] private Bricker BrickerPrefabs;
    [SerializeField] private Door[] doors;
    private List<int> intList = new List<int>();
    private List<Bricker> brickers = new List<Bricker>();
    private bool boolBricker = false;
    public bool BoolBricker => boolBricker;
    public Door[] Doors => doors;
    public  void OnInit()
    {
        int characterAmount = LevelManager.Ins.CharacterAmount;
        int quantity = transformsbrickers.Length / characterAmount, index = 1;
        int count_color =quantity;  
        for (int i = 0; i < transformsbrickers.Length; i++)
        {
            intList.Add(i);
            Bricker bricker =SimplePool.Spawn<Bricker>(PoolType.Bricker, transformsbrickers[i].position, Quaternion.identity); 
            bricker.renderer.enabled = true;
            brickers.Add(bricker);
            bricker.Setactive(false);
        }
        for (int i = transformsbrickers.Length; i > 0; --i)
        {
            int random = Random.Range(0, i);
            brickers[intList[random]].ChangeColor((ColorType)index);
            intList.RemoveAt(random);
            --count_color;
            if (index != characterAmount && count_color <= 0)
            {
                ++index;
                count_color = quantity;
                Debug.Log((ColorType)index);
            }
            
        }
        intList.Clear();
    }
    public void CollorBricks(ColorType colorType,bool Check)
    {
        for (int i = 0; i < brickers.Count; i++)
        {
            if (brickers[i].ColorType == colorType)
            {
               brickers[i].Setactive(Check);
            }
        }
    }
    public Vector3 FindBricker(ColorType colorType,Vector3 enemy,ref int count)
    {
        Vector3 bricktranforms = Vector3.zero;
        float dis = 0f;
        count = 0;
        for (int i = 0; i < brickers.Count; i++)
        {
            if (brickers[i].ColorType == colorType && brickers[i].renderer.enabled == true)
            {
                count++;
                if (dis > Vector3.Distance(enemy, brickers[i].TF.position) || dis < 0.1f)
                {
                    bricktranforms = brickers[i].TF.position;
                    dis = Vector3.Distance(enemy, brickers[i].TF.position);
                }
            }
        }
        return bricktranforms;
    }
    public void OnDespawn()
    {
        brickers.Clear();
    }
}
