﻿using Net5.AspNet.MVC.Infrastructure.Data.Contexts;
using Net5.AspNet.MVC.Infrastructure.Data.Entities;
using Net5.AspNet.MVC.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.MVC.Infrastructure.Data.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsuarioRepository Usuarios { get; }
        public IPostRepository Posts { get; }
        public IComentarioRepository Comentarios { get; }
        private BlogContext _context;        

        public UnitOfWork(
            BlogContext context,
            IUsuarioRepository usuarioRepository,
            IPostRepository postRepository,
            IComentarioRepository comentarioRepository
        )
        {
            _context = context;
            Usuarios = usuarioRepository;
            Posts = postRepository;
            Comentarios = comentarioRepository;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
