using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace RestaurantApp
{
    public class MainTableViewSource : UITableViewSource
    {
        public ViewController Vc;
        List<String> names;
        public static string selectedName;
        public MainTableViewSource()
        {
        }

        public MainTableViewSource(ViewController vc, List<string> names)
        {
            this.Vc = vc;
            this.names= names;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            cell.TextLabel.Text = names[indexPath.Row];
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return names.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            PushController();
            //selectedName = names[indexPath.Row];
            selectedName = RowSelect(tableView,indexPath);
        }

        public bool ShouldSelectRow(UITableView tableView, nint row)
        {
            return true;
        }

        public void PushController()
        {
            MenuViewController rs = this.Vc.Storyboard.InstantiateViewController("MenuViewController") as MenuViewController;
            if (rs != null)
            {
                this.Vc.NavigationController.PushViewController(rs, true);
            }
        }
        public string RowSelect(UITableView tableView, NSIndexPath indexPath)
        {
            var m = names[indexPath.Row];
            return m;
        }
    }
}