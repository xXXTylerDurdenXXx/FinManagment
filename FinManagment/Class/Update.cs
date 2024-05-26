using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myBiliotek;

namespace FinManagment.Class
{
    internal class Update
    {
        MaceWindow maceWindow = new MaceWindow();
        static public string str = $"Бюджет: {Account.Money}";
        static public MaceWindow mace;
        static public void Upd(MaceWindow maceWindow)
        {
            maceWindow.strMoney.Text = str;
        }
    }
}
