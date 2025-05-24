using Microsoft.EntityFrameworkCore;
using practica3.Models;

namespace practica3.Data
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks => Set<Feedback>();
    }
}