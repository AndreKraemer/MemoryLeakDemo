// --------------------------------------------------------------------------------------
// <copyright file="Demo4View2ViewModel.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 - 2023 André Krämer https://www.andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------

using System;
using System.ComponentModel;


namespace Ak.MemoryLeakDemo.ViewModels
{
    public class Demo4View2ViewModel 
    {

        private byte[] _tempData = new byte[5242880]; // 5 MB
        public Demo4View2ViewModel()
        {
            Name = "Demo4ViewModel2";
            Console.WriteLine(_tempData.Length);
        }
        public string Name { get; set; }

        #region Solution
        // WPF has a Memory Leak when you bind to something that doesn't implement INotifyPropertyChanged
        // so as a Solution you should Implement INotifyProperty Changed like this
        //
        //  public class Demo4View2ViewModel : INotifyPropertyChanged
        // {
        //  public event PropertyChangedEventHandler PropertyChanged;
        // ...

        // Those two modifications would already prevent the leak from happening. 
        // However, in Order to properly implement change notification, you shoul actually raise
        // the event like this:

        //public string Name
        //{
        //    get { return _name; }
        //    set
        //    {
        //        OnPropertyChanged();
        //        _name = value;
        //    }
        //}

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //}

        #endregion
    }
}