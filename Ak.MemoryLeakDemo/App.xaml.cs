// --------------------------------------------------------------------------------------
// <copyright file="app.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public event EventHandler LoggedIn;
        public event EventHandler LoggedOut;

        public void Login()
        {
            SaveInvokeLoggedInEvent();
        }

        public void Logout()
        {
            SaveInvokeLoggedOutEvent();
        }

        private void SaveInvokeLoggedOutEvent()
        {
            var tempLoggedOut = LoggedOut;
            if (tempLoggedOut != null)
            {
                tempLoggedOut(this, EventArgs.Empty);
            }
        }

        private void SaveInvokeLoggedInEvent()
        {
            var tempLoggedIn = LoggedIn;
            if (tempLoggedIn != null)
            {
                tempLoggedIn(this, EventArgs.Empty);
            }
        }
    }
}
