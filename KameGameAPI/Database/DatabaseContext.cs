using KameGameAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Database
{
    public class DatabaseContext : DbContext
    {
        #region Construktor
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        #endregion

        #region Dbsets
        public DbSet<AddressModel> addresses { get; set; }
        public DbSet<CardModel> cards { get; set; }
        public DbSet<CardTypeModel> cardTypes { get; set; }
        public DbSet<RoleModel> roles { get; set; }
        public DbSet<UserModel> users { get; set; }
        public DbSet<ShopModel> shops { get; set; }
        public DbSet<PostcodeModel> postcodes { get; set; }
        #endregion
    }
}
