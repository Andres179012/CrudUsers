using APPFinal.Models;
using APPFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployeePage : ContentPage
    {
        Users services;
        public ShowEmployeePage()
        {
            
            InitializeComponent();
            services = new Users();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            showEmployee();
        }
        private void showEmployee()
        {
            var res = services.GetAllEmployees().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddEmployee());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                UserModel obj = (UserModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddEmployee(obj));
                        break;
                    case "Delete":
                        services.DeleteEmployee(obj);
                        showEmployee();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}