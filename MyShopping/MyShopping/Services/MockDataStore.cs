using MyShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyShopping.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.", ImageSource=    "http://codeskulptor-demos.commondatastorage.googleapis.com/GalaxyInvaders/back06.jpg"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.", ImageSource=   "https://media-cdn.tripadvisor.com/media/photo-s/09/97/8c/27/castle-rock-trading-post.jpg"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.", ImageSource=    "https://www.xamarin.com/content/images/pages/forms/example-app.png"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.", ImageSource=   "https://media-cdn.tripadvisor.com/media/photo-s/09/97/8c/27/castle-rock-trading-post.jpg"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description.", ImageSource=    "https://i.ytimg.com/vi/JTxPzXQ1Sso/maxresdefault.jpg"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.", ImageSource=    "https://media-cdn.tripadvisor.com/media/photo-s/09/97/8c/27/castle-rock-trading-post.jpg"}
            };
        }

        //public async Task<Xamarin.Forms.ImageSource> GetImageFromStream(string ImageUrl)
        //{
        //    var client = new System.Net.Http.HttpClient();
        //    System.IO.Stream imagestream = await client.GetStreamAsync(ImageUrl);
        //    return ImageSource.FromStream(() => imagestream);
        //}

        //public async Task<ImageSource> GetImageFromStream(string url) { var resp = await obj_Client.GetStreamAsync(url); return Xamarin.Forms.ImageSource.FromStream(() => { return resp; }); }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}