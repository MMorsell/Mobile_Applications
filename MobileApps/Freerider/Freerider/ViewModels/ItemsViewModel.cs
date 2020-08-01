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

                Items.Add(
                new ItemModel("Falun", "Borlänge")
                {
                    Id = 1,
                });
                Items.Add(
                    new ItemModel("Falun", "Stockholm")
                    {
                        Id = 2,
                    });
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