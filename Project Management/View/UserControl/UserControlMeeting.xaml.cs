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
    /// Interaction logic for UserControlMeeting.xaml
    /// </summary>
    public partial class UserControlMeeting : System.Windows.Controls.UserControl
    {
        private StackPanel StackPanel;
        private ContentControl content;
        MettingProjectUserControl metting;
        EmplProjectUserControl EmplProject;
        public UserControlMeeting()
        {
            InitializeComponent();
            StackPanel = Home.MultiSlide;
            content = Home.HoldMulti;
            metting = new MettingProjectUserControl();
            EmplProject = new EmplProjectUserControl();
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

        private void BtnNewOne_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            //grid.Children.Add(metting);
            content.Content = metting;
        }

        private void BtnEM_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            //grid.Children.Add(EmplProject);
            content.Content = EmplProject;
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            //grid.Children.Add(metting);TaskUser
            content.Content = metting;
        }
    }
}
