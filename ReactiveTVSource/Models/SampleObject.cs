using System;
using ReactiveUI;

namespace ReactiveTVSource.Models
{
    public class SampleObject : ReactiveObject
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }
    }
}

