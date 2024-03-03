using Microsoft.EntityFrameworkCore;

namespace ExpenseDiary.Models
{
    public class ExpenseDBContext:DbContext
    {

    //Constructor with Parameters
    public ExpenseDBContext(DbContextOptions<ExpenseDBContext> options) : base(options)
        {}

        /*Table for the model class*/
        public DbSet<ExpenseReport> Expenses { get; set; }
    }
}

