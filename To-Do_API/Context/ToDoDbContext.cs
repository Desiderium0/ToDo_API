﻿using Microsoft.EntityFrameworkCore;

using To_Do_API.Models;

namespace To_Do_API.Context
{
    public class ToDoDbContext(DbContextOptions<ToDoDbContext> options) : DbContext(options)
    {
        public DbSet<Todo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = 1,
                    Title = "Testing 1",
                    Description = "Завтра поехать купить масла."
                },
                new Todo
                {
                    Id = 2,
                    Title = "Testing 2",
                    Description = "Изучить полностью backend."
                });
        }
    }
}
