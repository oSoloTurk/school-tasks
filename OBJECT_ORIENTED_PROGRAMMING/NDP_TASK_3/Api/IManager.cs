using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP_TASK_3.Api
{
    internal interface IManager<T>
    {
        public List<T> GetElements();
        public void SaveToFile();
    }
}
