using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FinManagment.Class;
using myBiliotek;

namespace FinManagment
{
    /// <summary>
    /// Логика взаимодействия для AddMoney.xaml
    /// </summary>
    public partial class AddMoney : Window
    {
        public AddMoney()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Account.Money += int.Parse(textMoney.Text);
            Account.checkUpdate = true;
            Update.Upd(Update.mace);
            FileMan.SaveFields();
            this.Close();
        }
    }
}
