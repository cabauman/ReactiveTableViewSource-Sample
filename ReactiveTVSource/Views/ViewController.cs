using System;

using UIKit;
using ReactiveTVSource.ViewModels;
using ReactiveUI;
using ReactiveTVSource.Models;
using System.Diagnostics;
using System.Reactive.Linq;

namespace ReactiveTVSource.Views
{
    public partial class ViewController : UIViewController
    {
        public SampleViewModel ViewModel { get; set; }

        public ViewController (IntPtr handle) : base (handle)
        {
            ViewModel = new SampleViewModel ();
        }

        public override void ViewDidLoad ()
        {
            var tableView = new UITableView ();

            // Bind the List agains the table view
            // SampleObject is our model and SampleCell the cell
            ViewModel.WhenAnyValue (vm => vm.Items).BindTo<SampleObject, SampleCell> (tableView, 46);

            View = tableView;
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

