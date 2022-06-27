using CoreLocation;
using Foundation;
//using RestaurantApp.WebRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace RestaurantApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public ViewController()
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await LoadMainTableData();
            searchButton.TouchUpInside += (sender, e) =>
            {
                ButtonClickEvent();
            };
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public async Task LoadMainTableData()
        {
            GetData gg = new GetData();
            var x = await gg.GetBusinessLocationAsync();
            var hotels = x;
            //var hotels = gg.GetBusinessLocation();
            MainTableView.ReloadData();
            MainTableView.Source = new MainTableViewSource(this, hotels);
        }

        public void ButtonClickEvent()
        {
            MainTableView.ReloadData();
            GetData gg = new GetData();
            var searchedText = searchboxtext();
            var hotels=gg.getHotelperLocation(searchedText);
            MainTableView.Source = new MainTableViewSource(this, hotels);
        }

        public string searchboxtext()
        {
            var searchedText = searchfield.Text;
            return searchedText;
        }

        public string searchboxtexts()
        {
            return "Hello";
        }
    }
}
