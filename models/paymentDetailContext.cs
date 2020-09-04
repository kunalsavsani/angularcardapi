using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularApp.models;

namespace angularApp.models
{
    public class paymentDetailContext: DbContext
    {
        public paymentDetailContext(DbContextOptions<paymentDetailContext> options):base(options)
        {
                
        }
        public DbSet<angularApp.models.paymentDetails> paymentDetails { get; set; }
    }
}
