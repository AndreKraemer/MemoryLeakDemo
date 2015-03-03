// --------------------------------------------------------------------------------------
// <copyright file="DictionaryCache.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using System.Collections.Generic;
using Ak.MemoryLeakDemo.ViewModels;

namespace Ak.MemoryLeakDemo
{
    public static class DictionaryCache
    {
        private static readonly Dictionary<int, Logfile> _cache = 
            new Dictionary<int, Logfile>();

        public static Dictionary<int, Logfile> Cache
        {
            get { return _cache; }
        }
    }
}