using AlphaStellarProjects.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaStellarProjects.Data.FakeContext
{
    public class FakeContext<T> where T : class
    {
        public List<Cars> Cars { get; set; }
        public List<Boats> Boats { get; set; }
        public List<Buses> Buses { get; set; }

        public void Update(T vehicle)
        {
            //Fake update
        }
        public int SaveChanges()
        {
            return 1;
        }
        public void Remove(T vehicle)
        {
            //Fake update
        }
    }
}
