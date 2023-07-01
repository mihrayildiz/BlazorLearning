using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLearaning.Server.Data.Model
{
    public class Suppliers
    {

        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public String Name { get; set; }

        public String WebURL { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
