using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinManagment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent(); 

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Close();
        }

        private void btn1Submit_Click(object sender, RoutedEventArgs e)
        {
            FileMan.AuthorizationUserFromJson(txtPassword.Text, txtUsername.Text);
            txtPassword.Text = "";
            txtUsername.Text = "";
        }
    }
}