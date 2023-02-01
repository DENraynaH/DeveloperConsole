using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Command", menuName = "Commands/Command")]
public class ConsoleCommand : ScriptableObject, IConsoleCommand
{
    private Action _commandEvents;
    
    [SerializeField] private string _commandPrefix;

    public void Execute(string[] args)
    {
        _commandEvents.Invoke();
    }

    public void AssignMethod(Action eventAction)
    {
        _commandEvents += eventAction;
    }

    public void RemoveMethod(Action eventAction)
    {
        _commandEvents -= eventAction;
    }

    #region Get
    public string CommandPrefix => _commandPrefix;
    #endregion
    
}

public interface IConsoleCommand
{
    string CommandPrefix { get; }
    void Execute(string[] args);
    
}
