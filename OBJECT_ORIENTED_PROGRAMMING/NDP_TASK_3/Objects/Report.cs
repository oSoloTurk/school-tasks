using NDP_TASK_3.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_TASK_3.Objects
{
    internal class Report : IReport
    {
        private List<String> Columns;
        private List<List<String>> Rows;

        public Report()
        {
            Columns = new List<String>();
            Rows = new List<List<String>>();
        }

        public List<string> getColumns()
        {
            return Columns;
        }

        public List<List<string>> getRows()
        {
            return Rows;
        }
    }
}
