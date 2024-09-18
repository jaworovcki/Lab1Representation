using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace yavandriilab1.Data;
public class LabDataContext : DbContext
{
    public LabDataContext(DbContextOptions<LabDataContext> options)
            : base(options)
    {

    }

    public DbSet<Task> Tasks { get; set; }
}