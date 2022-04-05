using System.Collections.Generic;

namespace Dtos
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<Project> Projects { get; set; }
    }
}
