using MaterialDesignThemes.Wpf;
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

namespace Project_Management.View.UserControl
{
    /// <summary>
    /// Interaction logic for UserControlEmpDegree.xaml
    /// </summary>
    public partial class UserControlEmpDegree : System.Windows.Controls.UserControl
    {
        Model.ContactContext context;
        public DialogHost host;
        public UserControlEmpDegree()
        {
            InitializeComponent();
            context = new Model.ContactContext();

        }

        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Model.Employee.Degree degree = new Model.Employee.Degree()
            {
                language = Namelang.Text
            };
            context.Degrees.Add(degree);
            context.SaveChanges();
            Namelang.Text = "";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
