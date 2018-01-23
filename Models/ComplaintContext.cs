
using Microsoft.EntityFrameworkCore;

namespace yourComplaint.Models
{
    public class ComplaintContext : DbContext
    {
        public ComplaintContext(DbContextOptions<ComplaintContext> options)
         : base(options)
         {
         }

         public DbSet<yourComplaint.Models.Complaint> Complaint{get; set;}
    }
}