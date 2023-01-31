using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace R.DeveloperConsole
{
    public static class ConsoleUtilities
    {

        public static string RemovePrefix(string consoleCommand, int prefixLength)
        {
            return consoleCommand.Remove(0, prefixLength);
        }

        public static string[] CommandToArray(string consoleCommand)
        {
            return consoleCommand.Split(" ");
        }

        public static string[] GetArguments(string consoleCommand)
        {
            string[] arrayCommand = CommandToArray(consoleCommand);
            string[] arguments = arrayCommand.Skip(1).ToArray();
            return arguments;
        }

        public static string GetPrefix(string consoleCommand)
        {
            string[] arrayCommand = CommandToArray(consoleCommand);
            return arrayCommand[0];
        }
    }
}

