﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Net5.Fundamentals.EF.CodeFirst.Data.Contexts;
using Net5.Fundamentals.EF.CodeFirst.Data.Entities;
using System;


namespace Net5.Fundamentals.EF.CodeFirst.Data.Contexts.Configurations
{
    public partial class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
        {
            entity.ToTable("Post", "Blog");

            entity.Property(e => e.Contenido)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.UsuarioIdActualizacionNavigation)
                .WithMany(p => p.PostUsuarioIdActualizacionNavigations)
                .HasForeignKey(d => d.UsuarioIdActualizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostUsuarioActualizacion");

            entity.HasOne(d => d.UsuarioIdCreacionNavigation)
                .WithMany(p => p.PostUsuarioIdCreacionNavigations)
                .HasForeignKey(d => d.UsuarioIdCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostUsuarioCreacion");

            entity.HasOne(d => d.UsuarioIdPropietarioNavigation)
                .WithMany(p => p.PostUsuarioIdPropietarioNavigations)
                .HasForeignKey(d => d.UsuarioIdPropietario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostUsuarioPropietario");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Post> entity);
    }
}
