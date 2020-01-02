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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Management.View.UserControl
{
    /// <summary>
    /// Interaction logic for UserControlEmploye.xaml
    /// </summary>
    public partial class UserControlEmploye : System.Windows.Controls.UserControl
    {
        private StackPanel StackPanel;
        private ContentControl content;
        EmplProjectUserControl EmplProject;
        UserControlEmpRole role;
        UserControlShowEmploye showEmploye;
        UserControlEmpDegree degree;
        UserControlEmpSpac spac;
        public UserControlEmploye()
        {
            InitializeComponent();
            StackPanel = Home.MultiSlide;
            content = Home.HoldMulti;
            EmplProject = new EmplProjectUserControl();
            role = new UserControlEmpRole();
            showEmploye = new UserControlShowEmploye();
            degree = new UserControlEmpDegree();
            spac = new UserControlEmpSpac();
        }
        public void HideStack()
        {
            Storyboard sb = new Storyboard();
            ThicknessAnimation thickness = new ThicknessAnimation()
            {
                BeginTime = new TimeSpan(0),
                From = new Thickness(0, 35, -440, 0),
                To = new Thickness(0, 0, 0, 0),
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            Storyboard.SetTarget(thickness, StackPanel);
            sb.Children.Add(thickness);
            Storyboard.SetTargetProperty(thickness, new PropertyPath(StackPanel.MarginProperty));
            sb.Begin();

        }

        private void BtnDrg_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            content.Content = degree;
        }

        private void BtnNewOne_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            content.Content = EmplProject;
        }

        private void BtnRloy_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            content.Content = role;
        }

        private void BtnSpecial_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            content.Content = spac;
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            content.Content = showEmploye;
        }
    }
}
