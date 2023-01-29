using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JE.DeveloperConsole
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
    }
}

