using Project_Management.Model;
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
    /// Interaction logic for MettingProjectUserControl.xaml
    /// </summary>
    public partial class MettingProjectUserControl 
    {
        int id;
        public Model.ContactContext context;
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
            _ListProjMeet = context.Meetings.Where(m => !m.IsDelete).ToObservableCollection();
            DgProject.ItemsSource = ListProjMeet;
            _ListProject = context.Projects.Where(m => !m.IsDelete).ToObservableCollection();
            CbProject.ItemsSource = ListProject.ToList();
            CbProject.DisplayMemberPath = "Name";
            CbProject.SelectedValuePath = "Id";
            _ListTask = context.Tasks.Where(m => !m.IsDelete).ToObservableCollection();
            CbTask.ItemsSource = ListTask.ToList();
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
            DgProject.ItemsSource = ListProjMeet;
            FillMetting();
            clr();
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
            //var s = CbProject.SelectedValue;
            var ed = context.Meetings.SingleOrDefault(n => n.Id == id);
            ed.Name = NameProj.Text;
            ed.DateStart = DateStart.SelectedDate.Value;
            ed.DateEnd = DateEnd.SelectedDate.Value;
            //ed.ProjectId = (int)s;
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
            

            if (s.Stutes == false)
                Stut.IsChecked = false;
            else if (s.Stutes == true)
                Stut.IsChecked = true;
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
