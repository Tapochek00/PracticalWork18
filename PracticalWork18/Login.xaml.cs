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
using System.Windows.Threading;

namespace PracticalWork18
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        DispatcherTimer _timer;
        int _countLogin = 1;
        StudentEntities _db = StudentEntities.GetContext();

        void GetCaptcha()
        {
            string masChar = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            string captcha = "";
            Random rnd = new Random();
            for (int i = 1; i <= 6; i++)
                captcha += masChar[rnd.Next(0, masChar.Length)];
            grid.Visibility = Visibility.Visible;
            txtCaptcha.Text = captcha;
            tbCaptcha.Text = null;
            txtCaptcha.LayoutTransform = new RotateTransform(rnd.Next(-15, 15));
            line.X1 = 10;
            line.Y1 = rnd.Next(10, 40);
            line.X2 = 280;
            line.Y2 = rnd.Next(10, 40);
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = from p in _db.User
                       where p.UserLogin == tbLogin.Text &&
                       p.UserPassword == pbPassword.Password
                       select p;
            if (user.Count() == 1 && txtCaptcha.Text == tbCaptcha.Text)
            {
                Data.Login = true;
                Data.Surname = user.First().UserSurname;
                Data.Name = user.First().UserName;
                Data.Patronymic = user.First().UserPatronymic;
                Data.Right = user.First().Role.RoleName;
                Close();
            }
            else
            {
                if (user.Count() == 1)
                    MessageBox.Show("Капча неверна");
                else MessageBox.Show("Логин и/или пароль неверны");
                GetCaptcha();
                if (_countLogin >= 2)
                {
                    stackPanel.IsEnabled = false;
                    _timer.Start();
                }
                _countLogin++;
                tbLogin.Focus();
            }
        }

        private void btnEsc_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Data.Login = true;
            Data.Surname = "Гость";
            Data.Name = "";
            Data.Patronymic = "";
            Data.Right = "Клиент";
            Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            tbLogin.Focus();
            Data.Login = false;
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 10);
            _timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            stackPanel.IsEnabled = true;
        }
    }
}
