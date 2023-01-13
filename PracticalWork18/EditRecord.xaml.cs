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
using System.Xml.Linq;

namespace PracticalWork18
{
    /// <summary>
    /// Логика взаимодействия для EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        public EditRecord()
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (GroupId.Text.Length == 0) errors.AppendLine("Выберите группу");
            if (FullName.Text.Length == 0) errors.AppendLine("Введите ФИО");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            fin.GroupId = GroupId.Text;
            fin.FullName = FullName.Text;
            fin.Gender = Gender.Text;
            fin.MaritalStatus = MaritalStatus.Text;
            if (exam1.Text.Length != 0)
                fin.Exam1 = Convert.ToInt32(exam1.Text);
            if (exam2.Text.Length != 0)
                fin.Exam2 = Convert.ToInt32(exam2.Text);
            if (exam3.Text.Length != 0)
                fin.Exam3 = Convert.ToInt32(exam3.Text);
            if (exam4.Text.Length != 0)
                fin.Exam4 = Convert.ToInt32(exam4.Text);
            if (exam5.Text.Length != 0)
                fin.Exam5 = Convert.ToInt32(exam5.Text);

            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
