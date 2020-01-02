using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserControlEmpSpac.xaml
    /// </summary>
    
    public partial class UserControlEmpSpac : System.Windows.Controls.UserControl
    {

        private BackgroundWorker backgroundWorker1 = null;
        Model.ContactContext context;
        public UserControlEmpSpac()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            FillData();
        }
        List<Model.Employee.Degree> degrees;
        void FillData()
        {
            degrees = new List<Model.Employee.Degree>();
            backgroundWorker1 = new BackgroundWorker();
           
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            degrees = context.Degrees.Where(m => !m.IsDelete).ToList();
   
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            ChDer.ItemsSource = degrees.ToList();
            ChDer.DisplayMemberPath = "language";
            ChDer.SelectedValuePath = "Id";

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var s = ChDer.SelectedValue;
            Model.Employee.Specialty specialty = new Model.Employee.Specialty()
            {
                Specialzation = spacname.Text,
                DegreeId=(int)s
            };
            context.Specialties.Add(specialty);
            context.SaveChanges();
            spacname.Text = "";
            ChDer.Text = "";
        }
    }
}
