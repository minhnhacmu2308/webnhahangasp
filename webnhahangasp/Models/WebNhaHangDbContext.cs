using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace webnhahangasp.Models
{
    public class WebNhaHangDbContext : DbContext
    {
        public WebNhaHangDbContext() : base("DBConnectionString")
        {

        }

        public DbSet<User> users { get; set; }

        public DbSet<Branch> branches { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<TypeFood> typeFoods { get; set; }
        public DbSet<Food> foods { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        public DbSet<News> news { get; set; }
        public DbSet<Menu> menus { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    }
}