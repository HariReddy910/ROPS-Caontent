using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RPOS.Models
{
    public class RPOSContext : DbContext
    {
        public RPOSContext (DbContextOptions<RPOSContext> options)
            : base(options)
        {
        }

       
    }
}
