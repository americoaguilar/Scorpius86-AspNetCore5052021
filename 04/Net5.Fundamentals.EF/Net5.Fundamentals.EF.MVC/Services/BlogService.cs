using Net5.Fundamentals.EF.CodeFirst.Data.Entities;
using Net5.Fundamentals.EF.CodeFirst.Data.Repositories.Base;
using Net5.Fundamentals.EF.MVC.Helper;
using Net5.Fundamentals.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Fundamentals.EF.MVC.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<PostViewModel> ListPosts()
        {
            return Mapper.PostsToPostViewModels(_unitOfWork.Posts.GetPosts());
        }
        public PostViewModel GetPostById(int postId)
        {
            return Mapper.PostToPostViewModel(_unitOfWork.Posts.GetPostById(postId));
        }
        public void InsertComment(ComentarioViewModel comentarioViewModel)
        {
            Comentario comentario = Mapper.ComentarioViewModelToComentario(comentarioViewModel);
            
            comentario.Post = null;
            comentario.UsuarioIdActualizacionNavigation = null;
            comentario.UsuarioIdCreacionNavigation = null;
            comentario.UsuarioIdPropietarioNavigation = null;

            comentario.FechaActualizacion = DateTime.Now;
            comentario.FechaCreacion = DateTime.Now;
            comentario.UsuarioIdPropietario = 1;
            comentario.UsuarioIdCreacion = 1;
            comentario.UsuarioIdActualizacion = 1;

            _unitOfWork.Comentarios.Insert(comentario);
            _unitOfWork.Save();
        }
        public void InsertPost(PostViewModel postViewModel)
        {
            Post post = Mapper.PostViewModelToPost(postViewModel);

            post.Comentarios = null;
            post.UsuarioIdActualizacionNavigation = null;
            post.UsuarioIdCreacionNavigation = null;
            post.UsuarioIdPropietarioNavigation = null;

            post.FechaCreacion = DateTime.Now;
            post.FechaActualizacion = DateTime.Now;
            post.UsuarioIdActualizacion = 1;
            post.UsuarioIdCreacion = 1;
            post.UsuarioIdPropietario = 1;

            _unitOfWork.Posts.Insert(post);
            _unitOfWork.Save();
        }
        public void UpdatePost(PostViewModel postViewModel)
        {
            Post post = _unitOfWork.Posts.GetById(postViewModel.PostId);

            post.Titulo = postViewModel.Titulo;
            post.Resumen = postViewModel.Resumen;
            post.Contenido = postViewModel.Contenido;
            post.FechaActualizacion = DateTime.Now;
            post.UsuarioIdActualizacion = 1;

            _unitOfWork.Posts.Update(post);
            _unitOfWork.Save();
        }
        public void DeletePost(int postId)
        {
            Post post = _unitOfWork.Posts.GetById(postId);

            _unitOfWork.Posts.Delete(post);
            _unitOfWork.Save();
        }
        public bool PostExists(int postId)
        {
            Post post = _unitOfWork.Posts.GetById(postId);
            return (post != null);
        }
    }
}
