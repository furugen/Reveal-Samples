using Infragistics.Sdk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopDemo
{
    public class RVInMemoryByDataGrid : RVInMemoryData
    {
        public IEnumerable<IEnumerable<object>> GridData;
        public IEnumerable<RVSchemaColumn> Schemas;


        public RVInMemoryByDataGrid(IEnumerable<IEnumerable<object>> Data, IEnumerable<RVSchemaColumn> schemas)
        {
            this.Schemas = schemas;
            this.GridData = Data;
        }

        public override IEnumerable<IEnumerable<object>> GetData()
        {   
            return this.GridData;
        }

        public override IEnumerable<RVSchemaColumn> GetSchema()
        {
            return this.Schemas;
        }
    }
}
