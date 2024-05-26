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

namespace FinManagment
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {

        public Reg()
        {

            MainWindow main = new MainWindow();
            main.Close();
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            FileMan.SaveUserToJson(Fullname.Text ,txtPassword.Text,txtUsername.Text);
            Fullname.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        
    }
}
