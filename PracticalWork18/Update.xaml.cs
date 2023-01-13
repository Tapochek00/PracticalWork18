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
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public Update()
        {
            InitializeComponent();
        }

        StudentEntities db = StudentEntities.GetContext();
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                char exam = updateParam.Text.ElementAt(updateParam.Text.Length - 1);
                if (setSearch.Text == "Группа")
                {
                    if (updateParam.Text == "Группа")
                        db.Database.ExecuteSqlCommand("UPDATE Finals " +
                                                      $"SET GroupId='{changeText.Text}' " +
                                                      $"WHERE GroupId='{searchText.Text}'");

                    else
                    {
                        db.Database.ExecuteSqlCommand("UPDATE Finals " +
                                                      $"SET Exam{exam}='{changeText.Text}' " +
                                                      $"WHERE GroupId='{searchText.Text}'");
                    }
                }
                else
                {
                    if (updateParam.Text == "Группа")
                        db.Database.ExecuteSqlCommand("UPDATE Finals " +
                                                      $"SET GroupId='{changeText.Text}' " +
                                                      $"WHERE FullName='{searchText.Text}'");

                    else
                    {
                        db.Database.ExecuteSqlCommand("UPDATE Finals " +
                                                      $"SET Exam{exam}='{changeText.Text}' " +
                                                      $"WHERE FullName='{searchText.Text}'");
                    }
                }
                db.SaveChanges();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
