using FinManagment.Class;
using FinManagment.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using myBiliotek;

namespace FinManagment
{

    /// <summary>
    /// Логика взаимодействия для MaceWindow.xaml
    /// </summary>
    public partial class MaceWindow : Window
    {
        
        public MaceWindow()
        {
            
            InitializeComponent();
            //Update.mace = this;
            // Update.Upd(this);
            UpdateMoney();
            DataContext = this;
            
        }

        
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        
        private void butplus_Click(object sender, RoutedEventArgs e)
        {
            if (Account.checkDay)
            {
                MyFrame.NavigationService.Navigate(new Snoska());
            }
            else MessageBox.Show("Сначала создайте день");

           
        }

        private void addMoney_Click(object sender, RoutedEventArgs e)
        {
            string mes = "Хотите пополнить бюджет";
            string mes1 = "Урааа деньги";
            
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(mes, mes1, button);
            if (result == MessageBoxResult.Yes)
            { 
                AddMoney add = new AddMoney();
                add.Show();

                
                
            }

           
        }
        
         public void UpdateMoney()
        {
            strMoney.Text = $"Бюджет: {Account.Money}";
        }

        private void butplusDay_Click(object sender, RoutedEventArgs e)
        {
            Account.products = new List<Product>();
            Account.checkDay = true;
            Account.products = new List<Product>();
        }

        private void butplusList_Click(object sender, RoutedEventArgs e)
        {
           
            CompletionList();
            MyFrame.NavigationService.RemoveBackEntry();
            MyFrame.NavigationService.Navigate(new Snoska());

        }

        private string[] SnosAdd()
        {
            var snoska = (Snoska)MyFrame.Content;
            
            string[] strings =
                {snoska.TextBoxName0.Text,
                snoska.TextBoxPrice0.Text,
                snoska.ComboBoxType0.Text,
                snoska.TextBoxName1.Text,
                snoska.TextBoxPrice1.Text,
                snoska.ComboBoxType1.Text,
                snoska.TextBoxName2.Text,
                snoska.TextBoxPrice2.Text,
                snoska.ComboBoxType2.Text,
                snoska.TextBoxPrice3.Text,
                snoska.TextBoxPrice3.Text,
                snoska.ComboBoxType3.Text,
                snoska.TextBoxName4.Text,
                snoska.TextBoxPrice4.Text,
                snoska.ComboBoxType4.Text,
                snoska.TextBoxName5.Text,
                snoska.TextBoxPrice5.Text,
                snoska.ComboBoxType5.Text};

            
            return strings;
        }

        private void CompletionList() 
        {
            var strings = (SnosAdd());
            bool[] check = new bool[3];
            check[0] = false;
            check[1] = false;
            check[2] = false;
            int count = 0;
            int countList = 0;
            
            foreach (var snos in strings)
            {

                if (snos != null && snos != "")
                {
                    check[count] = true;
                    count++;
                    countList++;
                }
                if (check[0] && check[1] && check[2])
                {
                    Product product = new Product(strings[countList - 3], strings[countList - 2 ], strings[countList - 1]);
                    Account.Money -= int.Parse(strings[countList - 2]);
                    UpdateMoney();
                    check[0] = false;
                    check[1] = false;
                    check[2] = false;
                    count = 0;
                    Account.products.Add(product);

                    
                }

            }
           

            FileMan.SaveFields();
        }
    }
}
