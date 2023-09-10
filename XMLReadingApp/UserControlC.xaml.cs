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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XMLReadingApp
{
    /// <summary>
    /// Interaction logic for UserControlC.xaml
    /// </summary>
    public partial class UserControlC : UserControl
    {
        public UserControlC(CategoryClass category)
        {
            InitializeComponent();
            string name = category.Title;
            string quantity = category.Quantity;

            Dispatcher.Invoke(() =>
            {
                LblName.Content = name;
                LblQt.Content = quantity;
            });
        }
    }
}
