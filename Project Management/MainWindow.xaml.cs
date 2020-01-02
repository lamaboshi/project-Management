using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Project_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Model.ContactContext context;
        List<Model.Project> ListProj;
        List<View.InnerClass.projectclass> projclass;
       
        public MainWindow()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            ListProj = new List<Model.Project>();
            projclass = new List<View.InnerClass.projectclass>();

            FillData();
        }
        void FillData()
        {
            //List<projectclass> pc = new List<projectclass>();
            //var result = pc.SelectMany(b => b.Name).Distinct();
            //show.ItemsSource = result.ToList();
            //ListProj = context.Projects.Where(i => !i.IsDelete).ToList();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btnclick_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}


