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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Management.View.UserControl
{
    /// <summary>
    /// Interaction logic for TaskUserControl.xaml
    /// </summary>
    public partial class TaskUserControl 
    {
        int selectProject;
        public Model.ContactContext context;
        public TaskUserControl()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            FillTask();

        }
        private ObservableCollection<Model.Task> _ListProjTask;
        public ObservableCollection<Model.Task> ListProjTask
        {
            get { return _ListProjTask; }
            set
            {
                _ListProjTask = value;
            }
        }
        void FillTask()
        {
            _ListProjTask = context.Tasks.Where(m => !m.IsDelete).ToObservableCollection();
            DgProject.ItemsSource = ListProjTask;
            List<string> ProjName = new List<string>();
            var N = context.Projects.Select(t => t.Name);
            foreach (var item in N)
            {
                ProjName.Add(item);
            }

            CbProject.ItemsSource = ProjName;
            CbProject.DisplayMemberPath = "Name";
               
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Model.Task task = new Model.Task()
            {
                Name = NameProj.Text,
                DateStart = DateStart.SelectedDate.Value,
                DateEnd = DateEnd.SelectedDate.Value,
               
            };
            
            if (Stut.IsChecked == true)
                task.Stutes = true;
            context.Tasks.Add(task);
            context.SaveChanges();
            FillTask();
            DgProject.ItemsSource = ListProjTask;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
