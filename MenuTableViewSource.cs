using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace RestaurantApp
{
    public class MenuTableViewSource : UITableViewSource
    {
        public MenuViewController Vc;
        List<String> names;
        List<String> menuimages;
        public MenuTableViewSource(MenuViewController vc, List<string> names)
        {
            this.Vc = vc;
            this.names = names;
        }

        public MenuTableViewSource()
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            cell.TextLabel.Text = names[indexPath.Row];
            var img = MenuViewController.imagedata;
            cell.ImageView.Image = FromUrl(img[indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return names.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selectedName = names[indexPath.Row];
            var row = indexPath.Row.ToString();
        }

        public bool ShouldSelectRow(UITableView tableView, nint row)
        {
            return true;
        }

        public UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }

        //public void getImageData()
        //{
        //    GetData gg = new GetData();
        //    menuimages = gg.getImages();
        //}

        public async Task<List<String>> LoadImageData()
        {
            GetData gg = new GetData();
            var menuimages = await gg.getImagesAsync();
            return menuimages;
        }

        public async Task getAsync()
        {
            await LoadImageData();
        }
    }
}
