using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace StackQA2XF
{
    public partial class CalculationQ : ContentPage
    {
        public CalculationQ()
        {
            InitializeComponent();
            this.BindingContext = this;
            GetSaleEntry();
        }

        private SaleEntryModel bindSaleEntryModel = new SaleEntryModel();
        public SaleEntryModel BindSaleEntryModel
        {
            get { return bindSaleEntryModel; }
            set
            {
                bindSaleEntryModel = value;
                OnPropertyChanged(nameof(BindSaleEntryModel));
            }
        }

        private void GetSaleEntry()
        {
            BindSaleEntryModel.SaleID = 1;
            BindSaleEntryModel.CustomerName = "Prajith";
            BindSaleEntryModel.ProductID = 1;
            BindSaleEntryModel.ProductName = "Auto";
            BindSaleEntryModel.Quantity = 5;
            BindSaleEntryModel.Rate = 20;
            BindSaleEntryModel.Discount = 5;
            BindSaleEntryModel.PaidAmount = 25;
        }

    }

    public class SaleEntryModel : INotifyPropertyChanged
    {

        public int SaleID { get; set; }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                OnPropertyChange(nameof(CustomerName));
            }
        }

        public int ProductID { get; set; }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChange(nameof(ProductName));
            }
        }

        private decimal _quantity;
        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChange(nameof(Quantity));
                OnPropertyChange(nameof(Total));
                OnPropertyChange(nameof(Balance));
            }
        }

        private decimal _rate;


        public decimal Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChange(nameof(Rate));
                OnPropertyChange(nameof(Total));
                OnPropertyChange(nameof(Balance));
            }
        }

        public decimal Total => Rate * Quantity;

        public decimal Balance => (Total - (Discount + PaidAmount));

        private int _discount;
        public int Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                OnPropertyChange(nameof(Discount));
                OnPropertyChange(nameof(Balance));
            }
        }

        private int _paidAmount;
        public int PaidAmount
        {
            get => _paidAmount;
            set
            {
                _paidAmount = value;
                OnPropertyChange(nameof(PaidAmount));
                OnPropertyChange(nameof(Balance));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
