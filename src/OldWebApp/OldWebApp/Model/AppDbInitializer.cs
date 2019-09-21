using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OldWebApp.Model
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            context.Customers.AddRange(new [] {
                new Customer()
                {
                    FirstName = "Dani",
                    LastName = "Michele"
                }, 
                new Customer()
                {
                    FirstName = "Elissa",
                    LastName = "Malone"
                }, 
                new Customer()
                {
                    FirstName = "Raine",
                    LastName = "Damian"
                },
                new Customer()
                {
                    FirstName = "Gerrard",
                    LastName = "Petra"
                }, 
                new Customer()
                {
                    FirstName = "Clement",
                    LastName = "Ernie"
                }, 
                new Customer()
                {
                    FirstName = "Rod",
                    LastName = "Fred"
                },
                new Customer()
                {
                    FirstName = "Oliver",
                    LastName = "Carr"
                }, 
                new Customer()
                {
                    FirstName = "Jackson",
                    LastName = "James"
                }, 
                new Customer()
                {
                    FirstName = "Dexter",
                    LastName = "Nicholson"
                },
                new Customer()
                {
                    FirstName = "Jamie",
                    LastName = "Rees"
                }, 
                new Customer()
                {
                    FirstName = "Jackson",
                    LastName = "Ross"
                }, 
                new Customer()
                {
                    FirstName = "Alonso",
                    LastName = "Sims"
                },
                new Customer()
                {
                    FirstName = "Zander",
                    LastName = "Britt"
                }, 
                new Customer()
                {
                    FirstName = "Isaias",
                    LastName = "Ford"
                }, 
                new Customer()
                {
                    FirstName = "Braden",
                    LastName = "Huffman"
                },
                new Customer()
                {
                    FirstName = "Frederick",
                    LastName = "Simpson"
                },
                new Customer()
                {
                    FirstName = "Charlie",
                    LastName = "Andrews"
                },
                new Customer()
                {
                    FirstName = "Reuben",
                    LastName = "Byrne"
                }
            });

            base.Seed(context);
        }
    }
}