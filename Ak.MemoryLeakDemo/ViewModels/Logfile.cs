using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ak.MemoryLeakDemo.ViewModels
{
    public class Logfile : INotifyPropertyChanged
    {
        private int _size;
        private int _id;
        private string _path;
        private byte[] _content;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    OnPropertyChanged();
                }
                _id = value;
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                if (_path != value)
                {
                    OnPropertyChanged();
                }
                _path = value;
            }
        }

        public int Size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    Content = new Byte[value*1024];
                    OnPropertyChanged();
                }
                _size = value;
            }
        }

        public Byte[] Content
        {
            get { return _content; }
            internal set
            {
                if (_content != value)
                {
                    OnPropertyChanged();
                }
                _content = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}