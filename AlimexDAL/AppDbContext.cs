using AlimexDAL.Entity;
using AlimexDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AlimexDAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbParameter parameter)
            : base(CreateConnectionString(parameter))
        {

        }
        /// <summary>
        /// entity dinamik connection string oluşturucu
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string CreateConnectionString(DbParameter parameter)
        {
            var defaultString = String.Format("data source={0};initial catalog={1};integrated security={2};MultipleActiveResultSets=True;App=EntityFramework;User Id={3};Password={4}", parameter.dataSource, parameter.initialCatalog, parameter.IntegratedSecurity,parameter.dbUserId,parameter.dbPassword);
          return defaultString;
        }      

        //User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Kategory> Kategories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineCopmany> MedicineCompanies { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }


    }
}
