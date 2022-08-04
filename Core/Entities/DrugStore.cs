using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DrugStore : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public  List<Drug> Drugs { get; set; }
        public Owner Owner { get; set; }
        public List<DrugGist> DrugGists { get; set; }
        
        

    }   
}
