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
    /// Логика взаимодействия для Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
        }

        StudentEntities db = StudentEntities.GetContext();
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (setSearch.Text == "Группа")
                    db.Database.ExecuteSqlCommand("DELETE FROM Finals " +
                                                 $"WHERE GroupId='{searchText.Text}'");
                else
                    db.Database.ExecuteSqlCommand("DELETE FROM Finals " +
                                                 $"WHERE FullName='{searchText.Text}'");
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
