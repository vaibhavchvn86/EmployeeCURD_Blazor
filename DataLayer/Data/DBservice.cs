using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class DBservice : IDBservice
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDBservice
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
