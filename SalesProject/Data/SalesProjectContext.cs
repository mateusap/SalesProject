﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesProject.Models;

namespace SalesProject.Data
{
    public class SalesProjectContext : DbContext
    {
        public SalesProjectContext (DbContextOptions<SalesProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SalesProject.Models.Department> Department { get; set; }
    }
}
