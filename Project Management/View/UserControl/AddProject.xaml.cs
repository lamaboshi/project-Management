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
    /// Interaction logic for AddProject.xaml
    /// </summary>
    public partial class AddProject 
    {
        public Model.ContactContext context;
        public AddProject()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            FillDate();
            DgProject.ItemsSource = ListProject;
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
            context.Projects.Add(project);
            context.SaveChanges();
            FillDate();
            DgProject.ItemsSource = ListProject;

        }
        public void FillDate()
        { 
            _ListProject = context.Projects.Where(m => !m.IsDelete).ToObservableCollection();
            DgProject.ItemsSource = ListProject;
        }

        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            int id= ((Button)sender).TabIndex;
            var s = _ListProject.FirstOrDefault(m => m.Id == id);
            NameProj.Text = s.Name;
            DateStart.Text = s.Start.ToString();
            DateEnd.Text = s.End.ToString();
            note.Text = s.Note;
            DateIn.IsEnabled = false;

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
            var ed = context.Projects.SingleOrDefault(n => n.Name == NameProj.Text);
            ed.Name = NameProj.Text;
            ed.Start = DateStart.SelectedDate.Value;
            ed.End = DateEnd.SelectedDate.Value;
            ed.Note = note.Text;
            if (Stut.IsChecked == true)
                ed.stutas = true;
            context.SaveChanges();
            Edit.Visibility = Visibility.Hidden;
            FillDate();
        }
    }
}
