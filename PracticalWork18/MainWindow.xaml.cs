using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticalWork18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Получаем доступ к контексту данных
        StudentEntities db = StudentEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Finals.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста
            DataGrid1.ItemsSource = db.Finals.Local.ToBindingList();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddRecord add = new AddRecord();
            add.Owner = this;
            add.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int indexRow = DataGrid1.SelectedIndex;
                if (indexRow != -1)
                {
                    Finals row = (Finals)DataGrid1.Items[indexRow];
                    Data.Id = row.Id;
                    EditRecord edit = new EditRecord();
                    edit.Owner = this;
                    edit.ShowDialog();
                    DataGrid1.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Finals row = (Finals)DataGrid1.SelectedItems[0];
                    db.Finals.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                Finals row = (Finals)DataGrid1.Items[indexRow];
                Data.Id = row.Id;
                ViewWindow view = new ViewWindow();
                view.Owner = this;
                view.ShowDialog();
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            FilterWindow filt = new FilterWindow();
            filt.Owner = this;
            filt.ShowDialog();

            try
            {
                var filterResult = from p in db.Finals
                                   select p;
                if (Data.SetFilter == "Группа")
                {
                    if (Data.FilterParams == "Содержат текст")
                        filterResult = from p in db.Finals
                                       where p.GroupId.Contains(Data.FilterText)
                                       select p;
                    else filterResult = from p in db.Finals
                                        where p.GroupId.StartsWith(Data.FilterText)
                                        select p;
                }
                else if (Data.FilterParams == "Содержат текст")
                    filterResult = from p in db.Finals
                                   where p.FullName.Contains(Data.FilterText)
                                   select p;
                else filterResult = from p in db.Finals
                                    where p.FullName.StartsWith(Data.FilterText)
                                    select p;

                DataGrid1.ItemsSource = filterResult.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update up = new Update();
            up.Owner = this;
            up.ShowDialog();
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGrid1.Items.Refresh();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            DataGrid1.ItemsSource = db.Finals.Local.ToBindingList();
        }

        private void FindAndDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete del = new Delete();
            del.Owner = this;
            del.ShowDialog();
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGrid1.Items.Refresh();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа № 18 - Создание запросов к БД\n\nВариант 14\n\n" +
                "Результаты сессии на первом курсе кафедры ВТ. База данных должна содержать " +
                "следующую информацию: индекс группы, фамилию, имя, отчество студента, пол " +
                "студента, семейное положение и оценки по пяти экзаменам.\n\nвыполнила Дунаева М.И. группа ИСП-31");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
