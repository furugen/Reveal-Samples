using DesktopDemo.Data;
using Infragistics.Sdk;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopDemo
{
    public class EmbedDataProvider : IRVDataProvider
    {
        public Task<IRVInMemoryData> GetData(RVInMemoryDataSourceItem dataSourceItem)
        {
            var datasetId = dataSourceItem.DatasetId;
            switch (datasetId)
            {
                case "employees":
                    var employees = new List<Employee>()
                    {
                        new Employee(){ EmployeeID = "1", Fullname="社員1", Wage = 80325.61 },
                        new Employee(){ EmployeeID = "2", Fullname="社員2", Wage = 10325.61 },
                    };
                    return Task.FromResult<IRVInMemoryData>(new RVInMemoryData<Employee>(employees));

                case "products":
                    var products = new List<Product>()
                    {
                        new Product(){ ProductID = "1", ProductName="製品A", Price = 980 },
                        new Product(){ ProductID = "2", ProductName="製品B", Price = 1050 },
                    };
                    return Task.FromResult<IRVInMemoryData>(new RVInMemoryData<Product>(products));
            }


            throw new Exception("Invalid data requested");
        }


    }
}
