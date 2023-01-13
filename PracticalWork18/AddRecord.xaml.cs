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
    /// Логика взаимодействия для AddRecord.xaml
    /// </summary>
    public partial class AddRecord : Window
    {
        public AddRecord()
        {
            InitializeComponent();
        }

        StudentEntities db = StudentEntities.GetContext();
        Finals fin = new Finals();
        private void Add_Click(object sender, RoutedEventArgs e)
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
                db.Finals.Add(fin);
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
