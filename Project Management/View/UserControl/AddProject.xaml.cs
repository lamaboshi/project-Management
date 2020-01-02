using Project_Management.Util.Extension_Method;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Project_Management.View.UserControl
{
    /// <summary>
    /// Interaction logic for AddProject.xaml
    /// </summary>
    public partial class AddProject : System.Windows.Controls.UserControl
    {
        int id;
        public Model.ContactContext context;
        private BackgroundWorker backgroundWorker1 = null;
        public AddProject()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            FillDate();
          
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Model.Project project = new Model.Project()
            {
                Name = NameProj.Text,
                DateIn = DateIn.SelectedDate.Value,
                Start=DateStart.SelectedDate.Value,
                End= DateEnd.SelectedDate.Value,
                Note=note.Text,
            };
            if (Stut.IsChecked == true)
                project.stutas = true;
       else if (Stut.IsChecked == false)
                project.stutas = false;
            context.Projects.Add(project);
            context.SaveChanges();
            FillDate();
            clr();

        }
        public void FillDate()
        {

            backgroundWorker1 = new BackgroundWorker();
            Dh.IsOpen = true;
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync();
            
        }
        private  void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _ListProject = context.Projects.Where(m => !m.IsDelete).ToObservableCollection();
        }
        
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dh.IsOpen = false;
            Parallel.ForEach(ListProject,p=> {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    DgProject.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
           
        }
        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            int idP= ((Button)sender).TabIndex;
            id = idP;

            var s = _ListProject.FirstOrDefault(m => m.Id == idP);
            NameProj.Text = s.Name;
            DateStart.Text = s.Start.ToString();
            DateEnd.Text = s.End.ToString();
            note.Text = s.Note;
            DateIn.IsEnabled = false;
            if (s.stutas == false)
                Stut.IsChecked = false;
            else if (s.stutas == true)
                Stut.IsChecked = true;

        }
        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Button)sender).TabIndex;
            var d = context.Projects.SingleOrDefault(s => s.Id == id);
            d.IsDelete = true;
            context.SaveChanges();
            FillDate();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            var ed = context.Projects.SingleOrDefault(n => n.Id == id);
            ed.Name = NameProj.Text;
            ed.Start = DateStart.SelectedDate.Value;
            ed.End = DateEnd.SelectedDate.Value;
            ed.Note = note.Text;
            if (Stut.IsChecked == true)
                ed.stutas = true;
            else if (Stut.IsChecked == false)
                ed.stutas = false;
            context.SaveChanges();
            Edit.Visibility = Visibility.Hidden;
            FillDate();
            clr();
        }
       private void clr()
        {
            NameProj.Text = "";
            DateStart.Text = "";
            DateEnd.Text = "";
            note.Text = "";
            Stut.IsChecked = false;
        }
    }
}
