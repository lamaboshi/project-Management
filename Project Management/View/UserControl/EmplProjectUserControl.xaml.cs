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
    /// Interaction logic for EmplProjectUserControl.xaml
    /// </summary>
    public partial class EmplProjectUserControl : System.Windows.Controls.UserControl
    {
        int id;
        Model.ContactContext context;
        private BackgroundWorker backgroundWorker1 = null;
        public EmplProjectUserControl()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            FillPerson();
        }
        void FillPerson()
        {
            backgroundWorker1 = new BackgroundWorker();
            DEmp.IsOpen = true;
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync();

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            _Listpeople = context.People.Where(m => !m.IsDelete).ToObservableCollection();
            _ListRole = context.Roles.Where(m => !m.IsDelete).ToObservableCollection();
            _ListSpecia = context.Specialties.Where(m => !m.IsDelete).ToObservableCollection();
            _ListDegree = context.Degrees.Where(m => !m.IsDelete).ToObservableCollection();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DEmp.IsOpen = false;
            Parallel.ForEach(Listpeople, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    DgProject.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
            Parallel.ForEach(ListRole, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    CbRole.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
            Parallel.ForEach(ListSpecia, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    Cbsp.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
            Parallel.ForEach(ListDegree, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    CbDerg.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
            CbRole.DisplayMemberPath = "RoleEmpl";
            CbRole.SelectedValuePath = "Id";
            Cbsp.DisplayMemberPath = "Specialzation";
            Cbsp.SelectedValuePath = "Id";
            CbDerg.DisplayMemberPath = "language";
            CbDerg.SelectedValuePath = "Id";

        }
        private ObservableCollection<Model.Employee.Specialty> _ListSpecia;
        public ObservableCollection<Model.Employee.Specialty> ListSpecia
        {
            get { return _ListSpecia; }
            set
            {
                _ListSpecia = value;
            }
        }
        private ObservableCollection<Model.Employee.Degree> _ListDegree;
        public ObservableCollection<Model.Employee.Degree> ListDegree
        {
            get { return _ListDegree; }
            set
            {
                _ListDegree = value;
            }
        }
        private ObservableCollection<Model.Employee.Person> _Listpeople;
        public ObservableCollection<Model.Employee.Person> Listpeople
        {
            get { return _Listpeople; }
            set
            {
                _Listpeople = value;
            }
        }
        private ObservableCollection<Model.Employee.Role> _ListRole;
        public ObservableCollection<Model.Employee.Role> ListRole
        {
            get { return _ListRole; }
            set
            {
                _ListRole = value;
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var R = CbRole.SelectedValue;
            var S = Cbsp.SelectedValue;
            Model.Employee.Person person = new Model.Employee.Person()
            {
                Name = NameEmp.Text,
                Phone = PhoneEmp.Text,
                Email = EmailEmp.Text,
                Address = AddresEmp.Text,
                RolePeople = _ListRole.Where(t => t.Id == (int)R).Select(m => new Model.Employee.RolePerson()
                { RoleId = m.Id, }).ToList(),
                SpecialtyPeoples=_ListSpecia.Where(t=>t.Id==(int)S).Select(m=>new Model.Employee.SpecialtyPerson()
                { SpecialtyId=m.Id,}).ToList(),  
            };
            Model.Employee.Specialty specialty = new Model.Employee.Specialty()
            {

            };
            context.People.Add(person);
            context.SaveChanges();
            FillPerson();
            crl();
        }

        void crl()
        {
            NameEmp.Text = "";
            PhoneEmp.Text = "";
            EmailEmp.Text = "";
            AddresEmp.Text = "";
            CbDerg.Text = "";
            CbRole.Text = "";
            Cbsp.Text = "";
        }

        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            int idT = ((Button)sender).TabIndex;
            id = idT;
            var s = _Listpeople.FirstOrDefault(m => m.Id == id);
            NameEmp.Text = s.Name;
            PhoneEmp.Text = s.Phone.ToString();
            EmailEmp.Text = s.Email;
            AddresEmp.Text = s.Address;


        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Button)sender).TabIndex;
            var d = context.People.SingleOrDefault(s => s.Id == id);
            d.IsDelete = true;
            context.SaveChanges();
            FillPerson();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var ed = context.People.SingleOrDefault(n => n.Id == id);
            ed.Name = NameEmp.Text;
            ed.Phone = PhoneEmp.Text;
            ed.Address = AddresEmp.Text;
            ed.Email = EmailEmp.Text;
            context.SaveChanges();
            Edit.Visibility = Visibility.Hidden;
            FillPerson();
            crl();
        }

        private void AddDeg_Click(object sender, RoutedEventArgs e)
        {
            EmpD.IsOpen = true;
        }

        private void AddRol_Click(object sender, RoutedEventArgs e)
        {
            EmpR.IsOpen = true;
        }

        private void EmpSe_Click(object sender, RoutedEventArgs e)
        {
            EmpS.IsOpen = true;
        }
    }
}
