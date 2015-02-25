using System;

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
    }
}