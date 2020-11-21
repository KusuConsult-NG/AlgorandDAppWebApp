using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlgorandWebApplicationDemo.Models;

namespace AlgorandWebApplicationDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AlgorandWebApplicationDemo.Models.AccountAddressModel> AccountAddressModel { get; set; }
    }
}
