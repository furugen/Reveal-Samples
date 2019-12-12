using DesktopDemo.Data;
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
    public class DataGridDataProvider : IRVDataProvider
    {
        public List<IEnumerable<object>> GridData;
        public List<RVSchemaColumn> Schemas;


        public DataGridDataProvider(IEnumerable<object> Data, ObservableCollection<DataGridColumn> Columns)
        {
            // スキーマを作成
            List<RVSchemaColumn> columns = new List<RVSchemaColumn>();
            object firstRecord = null;
            foreach (object record in Data)
            {
                firstRecord = record;
                break;
            }
            foreach (DataGridColumn dataGridColumn in Columns)
            {
                var columnValue = firstRecord.GetType().GetProperty(dataGridColumn.SortMemberPath).GetValue(firstRecord);
                RVSchemaColumnType columnType = RVSchemaColumnType.Text;


                if (columnValue is DateTime)
                {
                    columnType = RVSchemaColumnType.DateTime;
                }
                else if(columnValue is double  || columnValue is decimal || columnValue is int || columnValue is float || columnValue is long)
                {
                    columnType = RVSchemaColumnType.Number;
                }           


                columns.Add(new RVSchemaColumn(
                    dataGridColumn.SortMemberPath,
                    dataGridColumn.Header.ToString(),
                    columnType
                    ));
            }
            this.Schemas = columns;


            // データを作成
            // 対象レコードのデータを作成
            List<IEnumerable<object>> records = new List<IEnumerable<object>>();
            
            foreach (object record in Data)
            {
                List<object> values = new List<object>();
                foreach (RVSchemaColumn column in this.Schemas)
                {
                    var columnValue = record.GetType().GetProperty(column.Name).GetValue(record);
                    values.Add(columnValue);
                }

                records.Add(values);
            }
            this.GridData = records;
        }

        public Task<IRVInMemoryData> GetData(RVInMemoryDataSourceItem dataSourceItem)
        {
            return Task.FromResult<IRVInMemoryData>(new RVInMemoryByDataGrid(this.GridData, this.Schemas));
        }
    }
}
