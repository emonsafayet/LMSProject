﻿using LbLModel.Students;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LbLModel
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext() : base("DefaultBusinessConnection")
        {

        }
        public DbSet<Student> students { get; set; }
    }
}