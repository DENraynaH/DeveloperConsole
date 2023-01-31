using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Event Command", menuName = "Commands/Event Command")]
public class EventCommand : ConsoleCommand
{

    [SerializeField] private UnityEvent _commandEvents;
    
    public override void Execute(string[] args)
    {
        _commandEvents.Invoke();
        Debug.Log("test command executed");
    }
}
