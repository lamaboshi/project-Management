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
    /// Interaction logic for UserControlShowEmploye.xaml
    /// </summary>
    public partial class UserControlShowEmploye : System.Windows.Controls.UserControl
    {
        private BackgroundWorker backgroundWorker1 = null;
      
        Model.ContactContext context;
        List<InnerClass.EmployeeInfo> _Listpeople = new List<InnerClass.EmployeeInfo>();
        public UserControlShowEmploye()
        {
            InitializeComponent();
            context = new Model.ContactContext();
            
            Filldata();
        }
        void Filldata()
        {
            backgroundWorker1 = new BackgroundWorker();
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync();


        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var d = context.People.Where(c => !c.IsDelete);
            foreach (var item in d)
            {
                _Listpeople.Add(new InnerClass.EmployeeInfo()
                {
                     Id=item.Id,
                    Name=item.Name,
                    Address=item.Address,
                    Email=item.Email,
                    Phone=item.Phone
                });
               
            }

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
