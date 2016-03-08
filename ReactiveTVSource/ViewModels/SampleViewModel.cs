using System;
using ReactiveUI;
using ReactiveTVSource.Models;
using System.Reactive.Linq;
using System.Diagnostics;

namespace ReactiveTVSource.ViewModels
{
    public class SampleViewModel : ReactiveObject
    {
        public IReactiveList<SampleObject> Items { get; private set; } 

        public SampleViewModel ()
        {
            Items = new ReactiveList<SampleObject> ();

            var rand = new Random ();

            Observable.Interval (TimeSpan.FromMilliseconds (300))
                .ObserveOn (RxApp.MainThreadScheduler)
                .Subscribe (num =>
            {
                var idx = rand.Next (Items.Count);

                var act = rand.NextDouble ();
                if (act < 0.4 || idx >= Items.Count)
                {
                    Items.Insert (
                        idx,
                        new SampleObject () { Name = "Hallo Number " + num });
                    Debug.WriteLine ("Inserted " + idx);
                }
                else if (act < 0.8)
                    {
                        Items [idx].Name = "Now I'm Number " + num;
                        Debug.WriteLine ("Renamed " + idx);
                    }
                    else
                    {
                        Items.RemoveAt (idx);
                        Debug.WriteLine ("Removed " + idx);


                    }
            });
        }
    }
}

