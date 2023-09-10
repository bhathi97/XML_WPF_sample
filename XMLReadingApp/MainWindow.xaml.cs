using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace XMLReadingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public XDocument Document { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            //lets load the XML file data
            try
            {
                string nameOfFile = "XMLFile.xml";
                string fullPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), nameOfFile); // path -> ./bin/debug/XMLFile.xml
                XDocument document = XDocument.Load(fullPath);
                Document = document;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BtnA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PnlLoadCategory.Children.Clear();
                List<CategoryClass> categoryA = LoadCategories("A");
                foreach(CategoryClass i in categoryA)
                {
                    UserControlC userControl = new UserControlC(i);
                    PnlLoadCategory.Children.Add(userControl);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PnlLoadCategory.Children.Clear();
                List<CategoryClass> categoryA = LoadCategories("B");
                foreach (CategoryClass i in categoryA)
                {
                    UserControlC userControl = new UserControlC(i);
                    PnlLoadCategory.Children.Add(userControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PnlLoadCategory.Children.Clear();
                List<CategoryClass> categoryA = LoadCategories("C");
                foreach (CategoryClass i in categoryA)
                {
                    UserControlC userControl = new UserControlC(i);
                    PnlLoadCategory.Children.Add(userControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<CategoryClass> LoadCategories(string categoryName)
        {
            //create a list of categories
            try
            {
                List<CategoryClass> category = Document.Root
                    .Elements("category")
                    .Where(cat => cat.Attribute("name")?.Value == categoryName)
                    .Elements("item")
                    .Select(items => new CategoryClass
                    {
                        Code = items.Attribute("code")?.Value,
                        Title = items.Element("title")?.Value,
                        Quantity = items.Element("quantity")?.Value

                    }).ToList();

                return category;
            }
            catch
            {
                return null;
            }
            
        }

        

    }
}
