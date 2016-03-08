using System;

using UIKit;
using ReactiveTVSource.ViewModels;
using ReactiveUI;
using ReactiveTVSource.Models;
using System.Diagnostics;
using System.Reactive.Linq;

namespace ReactiveTVSource.Views
{
    public class SampleCell : ReactiveTableViewCell, IViewFor<SampleObject>
    {
        public SampleCell () : base() { }
        public SampleCell (IntPtr handle) : base(handle) { }

        private SampleObject _viewModel;
        public SampleObject ViewModel
        {
            get { return _viewModel; }
            set { this.RaiseAndSetIfChanged (ref _viewModel, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value as SampleObject; }
        }

        public override void WillMoveToSuperview (UIView newsuper)
        {
            if (newsuper == null)
                return;

            this.WhenAnyValue (v => v.ViewModel.Name).BindTo (
                this,
                v => v.TextLabel.Text);
        }
    }
}
