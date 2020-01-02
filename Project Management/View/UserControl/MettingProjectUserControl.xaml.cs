using Project_Management.Model;
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
    /// Interaction logic for MettingProjectUserControl.xaml
    /// </summary>
    public partial class MettingProjectUserControl : System.Windows.Controls.UserControl
    {
        int id;
        public Model.ContactContext context;
        private BackgroundWorker backgroundWorker1 = null;
        public MettingProjectUserControl()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            FillMetting();
        }
        private ObservableCollection<Model.Meeting> _ListProjMeet;
        public ObservableCollection<Model.Meeting> ListProjMeet
        {
            get { return _ListProjMeet; }
            set
            {
                _ListProjMeet = value;
            }
        }
        private ObservableCollection<Model.Task> _ListTask;
        public ObservableCollection<Model.Task> ListTask
        {
            get { return _ListTask; }
            set
            {
                _ListTask = value;
            }
        }
        private ObservableCollection<Model.Project> _ListProject;
        public ObservableCollection<Model.Project> ListProject
        {
            get { return _ListProject; }
            set
            {
                _ListProject = value;
            }
        }
        void FillMetting()
        {
            backgroundWorker1 = new BackgroundWorker();
            DMett.IsOpen = true;
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync();

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            _ListProjMeet = context.Meetings.Where(m => !m.IsDelete).ToObservableCollection();
            _ListProject = context.Projects.Where(m => !m.IsDelete).ToObservableCollection();
            _ListTask = context.Tasks.Where(m => !m.IsDelete).ToObservableCollection();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DMett.IsOpen = false;
            Parallel.ForEach(ListProjMeet, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    DgProject.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
            Parallel.ForEach(ListProject, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    CbProject.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
            Parallel.ForEach(ListTask, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    CbTask.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });

            CbProject.DisplayMemberPath = "Name";
            CbProject.SelectedValuePath = "Id";
            CbTask.DisplayMemberPath = "Name";
            CbTask.SelectedValuePath = "Id";
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var s = CbProject.SelectedValue;
            var T = CbTask.SelectedValue;
            Model.Meeting meeting = new Model.Meeting()
            {
                Name = NameProj.Text,
                DateStart = DateStart.SelectedDate.Value,
                DateEnd = DateEnd.SelectedDate.Value,
                ProjectId = (int)s,
                TaskMeetings = _ListTask.Where(t =>t.Id==(int)T).Select(m => new TaskMeeting()
                  { TaskId = m.Id, }).ToList()

            };
            if (Stut.IsChecked == true)
                meeting.Stutes = true;
            else if (Stut.IsChecked == false)
                meeting.Stutes = false;
            context.Meetings.Add(meeting);
            context.SaveChanges();
            clr();
            FillMetting();
        }
        private void clr()
        {
            NameProj.Text = "";
            DateStart.Text = "";
            DateEnd.Text = "";
            CbProject.Text = "";
            CbTask.Text = "";

            Stut.IsChecked = false;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var s = CbProject.SelectedValue;
            var T = CbTask.SelectedValue;
            var ed = context.Meetings.SingleOrDefault(n => n.Id == id);
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
            FillMetting();
            clr();
        }

        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            int idT = ((Button)sender).TabIndex;
            id = idT;
            var s = _ListProjMeet.FirstOrDefault(m => m.Id == idT);
            NameProj.Text = s.Name;
            DateStart.Text = s.DateStart.ToString();
            DateEnd.Text = s.DateEnd.ToString();
            CbProject.Text = s.Project.Name;
            if (s.Stutes == false)
                Stut.IsChecked = false;
            else if (s.Stutes == true)
                Stut.IsChecked = true;
            CbTask.Text = _ListTask.Where(b => b.ProjectId == s.ProjectId).Select(h => h.Name).First();
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Button)sender).TabIndex;
            var d = context.Meetings.SingleOrDefault(s => s.Id == id);
            d.IsDelete = true;
            context.SaveChanges();
            FillMetting();
        }
    }
}
