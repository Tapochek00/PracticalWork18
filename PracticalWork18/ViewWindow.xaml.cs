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

namespace PracticalWork18
{
    /// <summary>
    /// Логика взаимодействия для ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        public ViewWindow()
        {
            InitializeComponent();
        }

        StudentEntities db = StudentEntities.GetContext();
        Finals fin;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fin = db.Finals.Find(Data.Id);

            GroupId.Text = fin.GroupId;
            FullName.Text = fin.FullName;
            Gender.Text = fin.Gender;
            MaritalStatus.Text = fin.MaritalStatus;
            exam1.Text = fin.Exam1.ToString();
            exam2.Text = fin.Exam2.ToString();
            exam3.Text = fin.Exam3.ToString();
            exam4.Text = fin.Exam4.ToString();
            exam5.Text = fin.Exam5.ToString();
        }
    }
}
