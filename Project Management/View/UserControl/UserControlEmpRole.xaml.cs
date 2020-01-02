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
    /// Interaction logic for UserControlEmpRole.xaml
    /// </summary>
    public partial class UserControlEmpRole : System.Windows.Controls.UserControl
    {
        Model.ContactContext context;

        public UserControlEmpRole()
        {
            InitializeComponent();
            context = new Model.ContactContext();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Model.Employee.Role role = new Model.Employee.Role()
            {
                RoleEmpl=namerole.Text
            };
            context.Roles.Add(role);
            context.SaveChanges();
            namerole.Text = "";
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
