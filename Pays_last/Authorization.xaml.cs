using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pays_last
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public MainWindow mainWindow;
        public Authorization(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void btn_input_Click(object sender, RoutedEventArgs e)
        {

            if (txt_name.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными         
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[Users] WHERE [login] = '" + txt_name.Text + "' AND [password] = '" + password.Password + "'");
                    DataTable id = mainWindow.Select("Select * From [dbo].[Users]");
                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        MessageBox.Show("Пользователь авторизовался");
                        mainWindow.MainFrame.Navigate(new MainTable());


                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден"); // выводим ошибку  
                        txt4.Visibility = Visibility.Visible;
                        Captcha();

                    }

                }
                else
                {
                    MessageBox.Show("Введите пароль"); // выводим ошибку    
                    txt4.Visibility = Visibility.Visible;
                    Captcha();

                }

            }
            else {
                MessageBox.Show("Введите логин"); // выводим ошибку 
                txt4.Visibility = Visibility.Visible;
                Captcha();

            }

        }

        private void Captcha()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = "";
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            txt3.Text = pwd;
        }


        //private void SHA()
        //{


        //    User user;

        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] passBytes = Encoding.UTF8.GetBytes(password.Text);
        //        byte[] hashBytes = sha256.ComputeHash(passBytes);
        //        string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

        //        user = Instance.db.Users.Where(u => u.password == hash).ToList()[100];
        //    }


        //}

        private void btn_output_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
