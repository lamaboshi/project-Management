using Project_Management.Util.Extension_Method;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Project_Management.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        bool IsMix;
        int index;
        UserControl.UserControlProject project;
        UserControl.UserControlTask task;
        UserControl.UserControlMeeting meeting;
        UserControl.UserControlEmploye employe;
        private Model.ContactContext context;
        public static StackPanel MultiSlide;
        public static Grid HoldMulti;
        public Home()
        {
            InitializeComponent();
            HoldMulti = Holduser;
            MultiSlide= SpMove;
            Mix.Click += (s, e) => {
                IsMix = !IsMix;
                if (IsMix)
                    WindowState = WindowState.Maximized;
                else
                    WindowState = WindowState.Normal;
            };
            Close.Click += (s, e) => Close();
            project = new UserControl.UserControlProject();
            task = new UserControl.UserControlTask();
            meeting = new UserControl.UserControlMeeting();
            employe = new UserControl.UserControlEmploye();
            context = new Model.ContactContext();
    }
        
        

        private void  ButtenSlide_Click(object sender, RoutedEventArgs e)
        {

            SpMove.Children.Clear();
            index = ((Button)sender).TabIndex;
            
            if (index == 1) { 
            SpMove.Children.Add(project);

                index = 0;
            }
            else if (index == 2) { 
                SpMove.Children.Add(meeting);
                index = 0;
            }
            else if (index == 3) { 
                SpMove.Children.Add(task);
                index = 0;
            }
            else if (index == 4) { 
                SpMove.Children.Add(employe);
                index = 0;
            }


            
            Storyboard sb = new Storyboard();
            Storyboard stb = new Storyboard();
            ThicknessAnimation thickness = new ThicknessAnimation() {
                BeginTime = new TimeSpan(0),
                From = new Thickness(0, 0, 0, 0),
                To = new Thickness(0, 35, -440, 0),
                 Duration = new Duration(TimeSpan.FromSeconds(0.3))
           };
            DoubleAnimation animation = new DoubleAnimation()
            {
                BeginTime = new TimeSpan(0),
                To= 1,
                Duration=new Duration(TimeSpan.FromSeconds(1.1))
            };
        Storyboard.SetTarget(thickness, SpMove);
            Storyboard.SetTarget(animation, SpMove);
            sb.Children.Add(thickness);
            stb.Children.Add(animation);
            Storyboard.SetTargetProperty(animation, new PropertyPath(StackPanel.OpacityProperty));
            Storyboard.SetTargetProperty(thickness, new PropertyPath(StackPanel.MarginProperty));
            stb.Begin();
            sb.Begin();
            if (Holduser != null)
            {
                Holduser.Children.Clear();
                if (index == 1)
                {
                    SpMove.Children.Add(project);

                    index = 0;
                }
                else if (index == 2)
                {
                    SpMove.Children.Add(meeting);
                    index = 0;
                }
                else if (index == 3)
                {
                    SpMove.Children.Add(task);
                    index = 0;
                }
                else if (index == 4)
                {
                    SpMove.Children.Add(employe);
                    index = 0;
                }

            }

        }
   
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            FillProject();
        }
        public void FillProject()
        {

        }
    }
}
