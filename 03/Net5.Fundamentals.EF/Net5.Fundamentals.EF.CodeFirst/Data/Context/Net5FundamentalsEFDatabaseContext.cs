﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Net5.Fundamentals.EF.CodeFirst.Data.Context.Configurations;
using Net5.Fundamentals.EF.CodeFirst.Data.Entities;
using System;

#nullable disable

namespace Net5.Fundamentals.EF.CodeFirst.Data.Context
{
    public partial class Net5FundamentalsEFDatabaseContext : DbContext
    {
        public Net5FundamentalsEFDatabaseContext()
        {
        }

        public Net5FundamentalsEFDatabaseContext(DbContextOptions<Net5FundamentalsEFDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new Configurations.ComentarioConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PostConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UsuarioConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}