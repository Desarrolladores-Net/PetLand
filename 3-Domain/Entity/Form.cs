using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Form
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Question> Question { get; set; }
    }
}