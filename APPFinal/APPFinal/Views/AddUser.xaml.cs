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
    public partial class AddEmployee : ContentPage
    {
        Users _services;
        bool _isUpdate;
        int employeeID;
        public AddEmployee()
        {
            InitializeComponent();
            _services = new Users();
            _isUpdate = false;
        }
        public AddEmployee(UserModel obj)
        {
            InitializeComponent();
            _services = new Users();
            if (obj != null)
            {
                employeeID = obj.Id;
                txtName.Text = obj.Name;
                txtEmail.Text = obj.Email;
                txtAddress.Text = obj.Address;
                txtPassword.Text = obj.Password;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            UserModel obj = new UserModel();
            obj.Name = txtName.Text;
            obj.Email = txtEmail.Text;
            obj.Address = txtAddress.Text;
            obj.Password = txtPassword.Text;
            if (_isUpdate)
            {
                obj.Id = employeeID;
                await _services.UpdateEmployee(obj);
            }
            else
            {
                _services.InsertEmployee(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}