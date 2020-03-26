using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private Number _selectedNumber;
        public Number SelectedNumber
        {
            get
            {
                return _selectedNumber;
            }
            set
            {
                _selectedNumber = value;
                OnPropertyRaised("SelectedNumber");
            }
        }

        public ObservableCollection<Number> Numbers { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Numbers = new ObservableCollection<Number>();
            Numbers.Add(new Number { Value = "1" });
            Numbers.Add(new Number { Value = "2" });
            Numbers.Add(new Number { Value = "3" });
            Numbers.Add(new Number { Value = "4" });

            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }


    public class Number
    {
        public string Value { get; set; }
    }
}
