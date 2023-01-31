using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "New Command", menuName = "Commands/Test Command")]
public class TestCommand : ConsoleCommand
{
    
    [SerializeField] private UnityEvent _defaultEventExecution;
    
    public override void Execute(string[] args)
    {
        
    }

}
