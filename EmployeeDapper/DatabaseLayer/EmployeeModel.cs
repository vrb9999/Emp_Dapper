using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DatabaseLayer
{
    public class EmployeeModel
    {
        [JsonIgnore]
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }
    }
}
