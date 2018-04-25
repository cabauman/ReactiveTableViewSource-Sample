using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using ReactiveUI;
using ReactiveTVSource.ViewModels;
using ReactiveTVSource.Models;
using CoreGraphics;

namespace ReactiveTVSource.Views
{
    [Register("CollectionViewController")]
    public class CollectionViewController : UIViewController
    {
        public SampleViewModel ViewModel { get; set; }

        public CollectionViewController()
        {
            ViewModel = new SampleViewModel();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            var flowLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CGSize(160, 50),
                HeaderReferenceSize = new CGSize(100, 100),
                SectionInset = new UIEdgeInsets(10, 10, 10, 10),
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
                MinimumInteritemSpacing = 10, // minimum spacing between cells
                MinimumLineSpacing = 50 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
            };

            var collectionView = new UICollectionView(UIScreen.MainScreen.Bounds, flowLayout); //ReactiveCollectionViewController();
            ViewModel.WhenAnyValue(vm => vm.Items).BindTo<SampleObject, SampleCollectionViewCell>(collectionView, cell => cell.Initialize());
            View = collectionView;

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
        }
    }
}