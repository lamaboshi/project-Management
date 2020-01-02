using Project_Management.Util.Extension_Method;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class TaskUserControl : System.Windows.Controls.UserControl
    {
        int id;
        private BackgroundWorker backgroundWorker1 = null;
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
        private ObservableCollection<Model.Project> _ListProjectTa;
        public ObservableCollection<Model.Project> ListProjectTa
        {
            get { return _ListProjectTa; }
            set
            {
                _ListProjectTa = value;
            }
        }
        void FillTask()
        {
            backgroundWorker1 = new BackgroundWorker();
            DTask.IsOpen = true;
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync();
           

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            _ListProjTask = context.Tasks.Where(m => !m.IsDelete).ToObservableCollection();
            _ListProjectTa = context.Projects.Where(m => !m.IsDelete).ToObservableCollection();
            _ListProjectTa = context.Projects.Where(m => !m.IsDelete).ToObservableCollection();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DTask.IsOpen = false;
            Parallel.ForEach(ListProjTask, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    DgProject.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
            Parallel.ForEach(ListProjectTa, m =>
             {
                 Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                 {
                     CbProject.Items.Add(m);
                 }),
                System.Windows.Threading.DispatcherPriority.Background);
             });
            CbProject.DisplayMemberPath = "Name";
            CbProject.SelectedValuePath = "Id";

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            var s = CbProject.SelectedValue;
            Model.Task task = new Model.Task()
            {
                Name = NameProj.Text,
                DateStart = DateStart.SelectedDate.Value,
                DateEnd = DateEnd.SelectedDate.Value,
                ProjectId =(int)s
            };

            if (Stut.IsChecked == true)
                task.Stutes = true;
            else if (Stut.IsChecked == false)
                task.Stutes = false;
            context.Tasks.Add(task);
            context.SaveChanges();
            FillTask();
            DgProject.ItemsSource = ListProjTask;
            clr();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var s = CbProject.SelectedValue;
            var ed = context.Tasks.SingleOrDefault(n => n.Id == id);
            ed.Name = NameProj.Text;
            ed.DateStart = DateStart.SelectedDate.Value;
            ed.DateEnd = DateEnd.SelectedDate.Value;
            ed.ProjectId = (int)s;
            if (Stut.IsChecked == true)
                ed.Stutes = true;
            else if (Stut.IsChecked == false)
                ed.Stutes = false;
            context.SaveChanges();
            Edit.Visibility = Visibility.Hidden;
            FillTask();
            clr();
        }
        private void clr()
        {
            NameProj.Text = "";
            DateStart.Text = "";
            DateEnd.Text = "";
            CbProject.Text = "";
            Stut.IsChecked = false;
        }

        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            int idT = ((Button)sender).TabIndex;
            id = idT;
            var s = _ListProjTask.FirstOrDefault(m => m.Id == idT);
            NameProj.Text = s.Name;
            DateStart.Text = s.DateStart.ToString();
            DateEnd.Text = s.DateEnd.ToString();
            CbProject.Text = s.Project.Name;
            if (s.Stutes == false)
                Stut.IsChecked = false;
            else if (s.Stutes == true)
                Stut.IsChecked = true;

        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Button)sender).TabIndex;
            var d = context.Tasks.SingleOrDefault(s => s.Id == id);
            d.IsDelete = true;
            context.SaveChanges();
            FillTask();
        }
    }
}
