using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class ConsoleCommand : ScriptableObject, IConsoleCommand
{
    [SerializeField] private string _commandPrefix;
    public string CommandPrefix => _commandPrefix;

    public virtual void Execute(string[] args)
    {
        throw new System.NotImplementedException();
    }
}

public interface IConsoleCommand
{
    string CommandPrefix { get; }
    void Execute(string[] args);
    
}
