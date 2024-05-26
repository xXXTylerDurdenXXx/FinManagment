using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using System.Xml;
using AngleSharp.Dom;
using System.Windows;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Media.Animation;
using FinManagment.Class;
using Microsoft.Win32;
using System.Data.SqlTypes;
using myBiliotek;
namespace FinManagment
{

    static class FileMan 
    {
        
        
        static string jsonFilePath = @"C:\Users\Tyler Durden\source\\repos\FinManagment\FinManagment\File\Money.json";
        
        static public void SaveUserToJson(string u, string p, string l)
        {
            User user = new User(u, p, l);
           
            if (!File.Exists(jsonFilePath))
            {
                File.Create(jsonFilePath).Close();
            }
            var logPasName = Deser();

            if (logPasName.Count != 0)
            {
                bool check = false;
                foreach (var item in logPasName)
                {
                    if (item.Login == user.Login && item.Password == user.Password)
                    {
                        MessageBox.Show("Такой пользователь уже есть!!!");
                        check = true;
                        break;
                    }

                }
                if (!check)
                {
                    logPasName.Add(user);
                    string serialization = JsonConvert.SerializeObject(logPasName, Formatting.Indented);
                    File.WriteAllText(jsonFilePath, serialization);
                    MessageBox.Show($"Поздравляю {user.Name} вы зарегистрированы!!!");
                    MainWindow main = new MainWindow();
                    main.Show();
                }
            }
            else
            {
                logPasName.Add(user);
                string serialization = JsonConvert.SerializeObject(logPasName, Formatting.Indented);
                File.WriteAllText(jsonFilePath, serialization);
                MessageBox.Show($"Поздравляю {user.Name} вы зарегистрированы!!!");
            }
        }

        static public void AuthorizationUserFromJson(string pas, string log)
        {
            User user = new User(pas, log);
            var logPasName = Deser();
            bool check = false;
            if (logPasName.Count != 0)
            {
                foreach (var item in logPasName)
                {

                    if (item.Login == user.Login && item.Password == user.Password)
                    {
                        Account.UseAcc(item);
                        MessageBox.Show($"С возвращением {item.Name}!!!");
                        check = true;
                        MainWindow main = new MainWindow();
                        main.Close();
                        MaceWindow mace = new MaceWindow();
                        mace.Show();
                        
                        break;
                    }

                }
                if (!check)
                {
                    MessageBox.Show($"Такого пользователя нет!!!");
                }
            }
            else MessageBox.Show($"Пользователи еще не добавлены, зарегистрируйтесь ");

        }

        static private List<User> Deser()
        {
            List<User> logPasName = new List<User>();
            logPasName = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(jsonFilePath));
            return logPasName;
            
        }

       static public void SaveFields()
        {
            
            User user = new User();
            int count = 0;
            var logPasName = Deser();
            foreach (var item in logPasName.ToList())
            {
                
                if (item.Login == Account.saveUser.Login && item.Password == Account.saveUser.Password)
                {
                    logPasName.RemoveAt(count);
                    logPasName.Add(user);
                  
                    string serialization = JsonConvert.SerializeObject(logPasName, Formatting.Indented);
                    File.WriteAllText(jsonFilePath, serialization);
                    
                }
                count++;
            }
        }
    }
}
