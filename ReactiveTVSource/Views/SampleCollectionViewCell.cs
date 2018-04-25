using System;

using UIKit;
using ReactiveTVSource.ViewModels;
using ReactiveUI;
using ReactiveTVSource.Models;
using System.Diagnostics;
using System.Reactive.Linq;

namespace ReactiveTVSource.Views
{
    public class SampleCollectionViewCell : ReactiveCollectionViewCell, IViewFor<SampleObject>
    {
        private UILabel _label;

        public SampleCollectionViewCell() : base()
        {
            _label = new UILabel();
        }
        public SampleCollectionViewCell(IntPtr handle) : base(handle)
        {
            _label = new UILabel();
            AddSubview(_label);
        }

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

        public void Initialize()
        {
            _label.TextColor = UIColor.Black;
            ContentView.BackgroundColor = UIColor.Blue;
            this.WhenAnyValue(v => v.ViewModel.Name).BindTo(
                this,
                v => v._label.Text);
            Console.WriteLine("Initialized");
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            _label.Frame = ContentView.Bounds;
        }
    }
}
