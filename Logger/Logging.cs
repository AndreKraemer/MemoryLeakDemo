// --------------------------------------------------------------------------------------
// <copyright file="Logging.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using System.Threading;

namespace Logger
{
    public class Logging
    {
        public static void LogMessage(string message)
        {
            Thread.Sleep(600000);
        }
    }
}