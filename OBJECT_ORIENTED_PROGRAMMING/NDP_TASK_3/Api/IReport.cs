using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Api
{
    internal interface IReport
    {
        public List<string> getColumns();
        public List<List<string>> getRows();
    }
}
