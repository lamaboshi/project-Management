using Project_Management.Util.Extension_Method;
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
    /// Interaction logic for AllProjectUserControl.xaml
    /// </summary>
    public partial class AllProjectUserControl : System.Windows.Controls.UserControl
    {
        private BackgroundWorker backgroundWorker1 = null;
        Model.ContactContext context;
        List<InnerClass.projectclass> prclass;
        List<Model.Employee.Degree> degrees;
        List<Model.Employee.Role> roles;
        public AllProjectUserControl()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            FillData();
         
        }
        void FillData()
        {
            prclass = new List<InnerClass.projectclass>();
            degrees = new List<Model.Employee.Degree>();
            roles = new List<Model.Employee.Role>();

            backgroundWorker1 = new BackgroundWorker();
            Dh.IsOpen = true;

            this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync();
          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var q = context.Projects.Where(i => !i.IsDelete).ToList();
     
           
            foreach (var item in q)
            {
                var setinnerclass = new View.InnerClass.projectclass()
                {
                    Name = item.Name,
                    DateIn = item.DateIn,
                    Id = item.Id,
                    End = item.End,
                    Note = item.Note,
                    stutas = item.stutas,
                    Start = item.Start,
                    IsDelete = item.IsDelete,
                    CountTask = context.Tasks.Where(r => r.ProjectId == item.Id).Count(),
                    CountMetting = context.Meetings.Where(b => b.ProjectId == item.Id).Count(),
                
                };
                var y = context.Roles.Where(i => !i.IsDelete && i.RolePeople.Select(l=>l.PersonId).FirstOrDefault()==item.Id).ToList();
                var v = context.Degrees.Where(t => !t.IsDelete && t.Specialties.Select(g => g.SpecialtyPeoples.Select(m => m.PersonId).FirstOrDefault()).FirstOrDefault() == item.Id).ToList();
                foreach (var j in y)
                {
                    setinnerclass.RoleEmp.Add(new InnerClass.EmployeeClass()
                    {
                        Role = j.RoleEmpl,
                        CountRole=context.Roles.Where(a=>a.Id==j.Id).Count()

                    });
                }
                setinnerclass.EmpDeg = v.ToList();
                prclass.Add(setinnerclass);
            }
        }
        
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dh.IsOpen = false;

            Parallel.ForEach(prclass, p => {

                Application.Current.Dispatcher.
                BeginInvoke(new Action(() => {
                    CardProject.Items.Add(p);
                }),

                System.Windows.Threading.DispatcherPriority.Background);
            });
            // var s= ListProject.Skip(0).Take(3);
            //Parallel.ForEach(ListProj, p =>
            //{
            //    Application.Current.Dispatcher.
            //    BeginInvoke(new Action(() =>
            //    {
            //        CardProject.Items.Add(p);
            //    }),
            //    System.Windows.Threading.DispatcherPriority.Background);
            //});
            //CardProject.ItemsSource = ListProj;


        }

    }
}
