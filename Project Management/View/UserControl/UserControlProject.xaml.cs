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
    /// Interaction logic for UserControlProject.xaml
    /// </summary>
    public partial class UserControlProject : System.Windows.Controls.UserControl
    {

        private StackPanel StackPanel;
        AddProject addProject;
        TaskUserControl TaskUser;
        MettingProjectUserControl metting;
        EmplProjectUserControl EmplProject;
        private ContentControl content;
        UserControl.AllProjectUserControl AllProject;
        public UserControlProject()
        {
            InitializeComponent();

            StackPanel= Home.MultiSlide;
            content = Home.HoldMulti;
        }
        public void HideStack()
        {
            Storyboard sb = new Storyboard();
            ThicknessAnimation thickness = new ThicknessAnimation()
            {
                BeginTime = new TimeSpan(0),
                From = new Thickness(-440, 35, 0, 0),
                To = new Thickness(0,0,0,0),
                Duration = new Duration(TimeSpan.FromSeconds(0.2))
            };
            Storyboard.SetTarget(thickness, StackPanel);
            sb.Children.Add(thickness);
            Storyboard.SetTargetProperty(thickness, new PropertyPath(StackPanel.MarginProperty));
            sb.Begin();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HideStack();

            addProject = new AddProject();
            //grid.Children.Add(addProject);
            content.Content = addProject;
        }
        private void BtnMetProjecrt_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            metting = new MettingProjectUserControl();
            //grid.Children.Add(metting);
            content.Content = metting;
        }

        private void BtnTasProjecrt_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            TaskUser = new TaskUserControl();
            //grid.Children.Add(TaskUser);
            content.Content = TaskUser;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HideStack();
            EmplProject = new EmplProjectUserControl();
            //grid.Children.Add(EmplProject);
            content.Content = EmplProject;
        }

        private void  BtnProjecrts_Click(object sender, RoutedEventArgs e)
        {
            HideStack();
            AllProject = new AllProjectUserControl();
            content.Content = AllProject;

        }
    }
}
