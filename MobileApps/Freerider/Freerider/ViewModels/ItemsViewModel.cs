using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Freerider.Models;
using Freerider.Views;

namespace Freerider.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ItemModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ItemModel>();
            ExecuteLoadItemsCommand();

            MessagingCenter.Subscribe<AddItemPage, ItemModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = (ItemModel)item;
                Items.Add(newItem);
            });
        }

        private void ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();

                var allPostsCurrentlyOnHertzSite = Freerider.Services.WebscraperService.GetNewUpdate();

                foreach (var post in allPostsCurrentlyOnHertzSite)
                {
                    Items.Add(post);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}