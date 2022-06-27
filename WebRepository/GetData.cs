using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestaurantApp
{
    public class GetData
    {
        private List<String> hotelName = new List<String>();
        private List<String> menuName = new List<String>();
        private List<String> updatedList = new List<string>();
        private List<String> FinalupdatedList = new List<string>();
        public static List<String> hotelLists = new List<string>();

        private Dictionary<String, String> menunameAndid = new Dictionary<String, String>();
        private Dictionary<String, String> hotelandmenuid = new Dictionary<String, String>();
        private Dictionary<String, String> locationandhotel = new Dictionary<String, String>();
        private Dictionary<String, List<String>> menuandimage = new Dictionary<String, List<String>>();
        private Dictionary<String, String> images = new Dictionary<String, String>();
        private Dictionary<String, String> RestaurantImg = new Dictionary<String, String>();

        public GetData()
        {
        }

        public string RestaurantURL()
        {
            String url = "https://foodbukka.herokuapp.com/api/v1/restaurant";
            return url;
        }

        private string MenuURL()
        {
            String url = "https://foodbukka.herokuapp.com/api/v1/menu";
            return url;
        }

        private void RestaurantAPI()
        {
            WebRequest webRequest = WebRequest.Create(RestaurantURL());
            webRequest.Method = "GET";
            HttpWebResponse webResponse = null;
            webResponse = (HttpWebResponse)webRequest.GetResponse();
            //webResponse = (HttpWebResponse)await webRequest.GetResponseAsync();
            string srresulttest = null;
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                srresulttest = sr.ReadToEnd();
                var RestaurantInfo = JsonConvert.DeserializeObject<RestaurantRoot>(srresulttest);
                var result = RestaurantInfo.Result;
                foreach (var i in result)
                {
                    hotelName.Add(i.businessname);
                    hotelandmenuid.Add(i.businessname, i.menu);
                    locationandhotel.Add(i.businessname, i.location);
                    RestaurantImg.Add(i.businessname, i.image);
                }
                sr.Close();
            }
        }

        public async Task<List<string>> GetBusinessLocationAsync()
        {
            await RestaurantAPIhttp();
            hotelLists = new List<string>(locationandhotel.Keys);
            return hotelLists;
        }

        public async Task<List<string>> getImagesAsync()
        {
            await MenuAPIhttp();
            var s = menuandimage.Values;
            var img = new List<String>();
            foreach (var i in s)
            {
                img = i;
            }
            return img;
        }

        private async Task MenuAPIhttp()
        {
            WebRequest webRequest = WebRequest.Create(MenuURL());
            webRequest.Method = "GET";
            HttpWebResponse webResponse = null;
            webResponse = (HttpWebResponse)await webRequest.GetResponseAsync();
            string srresulttest = null;
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                srresulttest = sr.ReadToEnd();
                var MenuInfo = JsonConvert.DeserializeObject<MenuRoot>(srresulttest);
                var result = MenuInfo.Result;
                foreach (var i in result)
                {
                    menuName.Add(i.menuname);
                    menunameAndid.Add(i._id, i.menuname);
                }
                try
                {
                    foreach (var i in result)
                    {
                        menuandimage.Add(i.menuname, i.images);
                    }
                }
                catch (Exception ex)
                {

                }
                sr.Close();
            }
        }

        public async Task RestaurantAPIhttp()
        {
            WebRequest webRequest = WebRequest.Create("https://foodbukka.herokuapp.com/api/v1/restaurant");
            webRequest.Method = "GET";
            HttpWebResponse webResponse = null;
            webResponse = (HttpWebResponse)await webRequest.GetResponseAsync();
            string srresulttest = null;
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                srresulttest = await sr.ReadToEndAsync();
                var RestaurantInfo = JsonConvert.DeserializeObject<RestaurantRoot>(srresulttest);
                var result = RestaurantInfo.Result;
                foreach (var i in result)
                {
                    hotelName.Add(i.businessname);
                    hotelandmenuid.Add(i.businessname, i.menu);
                    locationandhotel.Add(i.businessname, i.location);
                    RestaurantImg.Add(i.businessname, i.image);
                }
                sr.Close();
            }
        }

        private void MenuAPI()
        {
            WebRequest webRequest = WebRequest.Create(MenuURL());
            webRequest.Method = "GET";
            HttpWebResponse webResponse = null;
            webResponse = (HttpWebResponse)webRequest.GetResponse();
            string srresulttest = null;
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                srresulttest = sr.ReadToEnd();
                var MenuInfo = JsonConvert.DeserializeObject<MenuRoot>(srresulttest);
                var result = MenuInfo.Result;
                foreach (var i in result)
                {
                    menuName.Add(i.menuname);
                    menunameAndid.Add(i._id, i.menuname);
                }
                try
                {
                    foreach (var i in result)
                    {
                            menuandimage.Add(i.menuname,i.images);
                    }
                }
                catch(Exception ex)
                {

                }
                sr.Close();
            }
        }

        public List<String> GetBusinessLocation()
        {
            RestaurantAPI();
            var hotelList = new List<string>(locationandhotel.Keys);
            return hotelList;
        }


        public List<String> GetMenu()
        {
            MenuAPI();
            return menuName;
        }

        private Dictionary<String, String> locationDict()
        {
            RestaurantAPI();
            return locationandhotel;
        }

        public List<String> getHotelperLocation(String location)
        {
            var data = locationDict();
            var hotellist = new List<String>();
            foreach(var i in data)
            {
                if (i.Value.Equals(location))
                {
                    hotellist.Add(i.Key);
                }
            }
            return hotellist;
        }
        public List<String> distinctMenu(String name)
        {
            RestaurantAPI();
            MenuAPI();
            foreach (var i in hotelandmenuid)
            {
                if (i.Key.Equals(name))
                {
                    updatedList.Add(i.Value);
                }
            }
            foreach(var m in updatedList)
            {
                foreach (var i in menunameAndid)
                {
                    if (i.Key.Equals(m))
                    {
                        FinalupdatedList.Add(i.Value);
                    }
                }
            }
            return FinalupdatedList;
        }

        private Dictionary<String, List<String>> getImagesandmenu()
        {
            MenuAPI();
            return menuandimage;
        }

        public List<String> getImages()
        {
            MenuAPI();
            var s = menuandimage.Values;
            var img = new List<String>();
            foreach (var i in s)
            {
                img = i;
            }
            return img;
        }

        public List<String> getRestaurantImages()
        {
            RestaurantAPI();
            var s = RestaurantImg.Values.ToList();
            var img = new List<String>(s);
            return img;
        }

        public void hello()
        {

        }
    }
}
