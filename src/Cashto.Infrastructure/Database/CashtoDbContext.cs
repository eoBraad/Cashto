﻿using Cashto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cashto.Infrastructure.Database;

public class CashtoDbContext(DbContextOptions<CashtoDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}