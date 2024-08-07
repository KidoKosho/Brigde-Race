using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{ 
    private IState currentState;
    [SerializeField] private NavMeshAgent agent;
    private UnityEngine.Vector3 destination;
    private Vector3 savedestination;
    public List<Vector3> doorsposition;
    public bool IsDestionation => Vector3.Distance(TF.position, destination + (TF.position.y - destination.y) * Vector3.up) < 0.1f;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            IsCheckPlay(!IsCheckPlayGame);
        }
        if (!IsCheckPlayGame)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void SetDestination(UnityEngine.Vector3 destination)
    {
        this.destination = destination;
        agent.SetDestination(destination);
    }
    public void OnInit()
    {
        ChangeColor(ColorType);
        Randomdoor();
        ChangeState(new FindBrick());
        ChangeAnim(Constant.TAG_IDLE);
        IsCheckPlay(false);
    }
    public void Randomdoor()
    {
        Debug.Log("2");
        int random = Random.Range(0, Flatform.Doors.Length);    
        for(int i = doorsposition.Count - 1;i >= 0; --i)
        {
            doorsposition.RemoveAt(i);
        }
        Debug.Log(Flatform.Doors[random].transfromsdoors.Length +"length");
        for(int i = 0; i < Flatform.Doors[random].transfromsdoors.Length; i++)
        {
            doorsposition.Add(Flatform.Doors[random].transfromsdoors[i].position);
        }
    }
    public override void IsCheckPlay(bool check)
    {
        if (check == false)
        {
            savedestination = destination;
            SetDestination(transform.position);
        }
        else
        {
            SetDestination(savedestination);
        }
        base.IsCheckPlay(check);
    }
}
