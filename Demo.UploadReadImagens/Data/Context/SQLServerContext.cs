using Microsoft.EntityFrameworkCore;
using Demo.UploadReadImagens.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Demo.UploadReadImagens.Data.Context
{
        public class SQLServerContext : DbContext
        {
            public SQLServerContext(DbContextOptions<SQLServerContext> options)
            : base(options)
            {

            }

            #region DBSets<Tables>

            public DbSet<Gato> Gatos { get; set; }
            public DbSet<Image> Imagens { get; set; }
            #endregion
        }
    }
