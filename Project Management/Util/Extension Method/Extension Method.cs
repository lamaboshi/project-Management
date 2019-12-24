using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Util.Extension_Method
{
    public static class Extension_Method
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> Enum) where T : class
        {
            return new ObservableCollection<T>(Enum);
        }
    }
}
