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
    /// Логика взаимодействия для FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        public FilterWindow()
        {
            InitializeComponent();
        }

        private void Filter_Click(object sender, object e)
        {
            Data.SetFilter = setSearch.Text;
            Data.FilterText = searchText.Text;
            Data.FilterParams = filterParams.Text;

            this.Close();
        }

        private void setSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboItem;
            string selected = (setSearch.SelectedItem as ComboBoxItem).Content.ToString();
            filterParams.Items.Clear();

            if (selected == "ФИО" || selected == "Группа")
            {
                comboItem = new ComboBoxItem()
                {
                    Content = "Содержат текст",
                    IsSelected = true
                };
                filterParams.Items.Add(comboItem);
                comboItem = new ComboBoxItem();
                comboItem.Content = "Начинаются с текста";
                filterParams.Items.Add(comboItem);
            
                searchPlace.Children.Clear();
                TextBox searchText = new TextBox()
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 160
                };
                searchPlace.Children.Add(searchText);
            }
            else
            {
                comboItem = new ComboBoxItem()
                {
                    Content = "Равны",
                    IsSelected = true
                };
                filterParams.Items.Add(comboItem);
                comboItem = new ComboBoxItem();
                comboItem.Content = "Больше, чем";
                filterParams.Items.Add(comboItem);
                comboItem = new ComboBoxItem();
                comboItem.Content = "Меньше, чем";
                filterParams.Items.Add(comboItem);

                searchPlace.Children.Clear();
                string[] marks = new string[4] { "2", "3", "4", "5" };
                ComboBox searchText = new ComboBox()
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 160
                };
                ComboBoxItem mark;
                mark = new ComboBoxItem()
                {
                    Content = marks[0],
                    IsSelected = true
                };
                searchText.Items.Add(mark);

                for (int i = 1; i < marks.Length; i++)
                {
                    mark = new ComboBoxItem();
                    mark.Content = marks[i];
                    searchText.Items.Add(mark);
                }
                searchPlace.Children.Add(searchText);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboItem;
            string[] arr = new string[7] 
            {"ФИО", "Группа",
            "Оценка за экзамен 1",
            "Оценка за экзамен 2",
            "Оценка за экзамен 3",
            "Оценка за экзамен 4",
            "Оценка за экзамен 5"};

            comboItem = new ComboBoxItem()
            {
                Content = arr[0],
                IsSelected = true
            };
            setSearch.Items.Add(comboItem);
            for (int i = 1; i < arr.Length; i++)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = arr[i];
                setSearch.Items.Add(comboItem);
            }
        }
    }
}
