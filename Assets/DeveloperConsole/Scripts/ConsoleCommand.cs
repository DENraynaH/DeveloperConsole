using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConsoleCommand : ScriptableObject, IExecutable
{
    [SerializeField] private string _commandInput = string.Empty;
    public string CommandInput => _commandInput;

    public void Execute(string[] args)
    {
        throw new System.NotImplementedException();
    }
}

public interface IExecutable
{
    string CommandInput { get; }
    void Execute(string[] args);
}
