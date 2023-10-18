using Dominio.Interfaces.ICategoria;
using Dominio.Interfaces.InterfacesServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _iCategoria;

        private readonly ICategoriaServico  _iCategoriaServico;

        public CategoriaController(ICategoria iCategoria, ICategoriaServico iCategoriaServico)
        {
            _iCategoria = iCategoria;
            _iCategoriaServico = iCategoriaServico;
        }

        [HttpGet("/api/ListarCategoriasDoUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriasDoUsuario(string emailUsuario)
        {
            return await _iCategoria.ListarCategoriasDoUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _iCategoriaServico.AdicionarCategoria(categoria);
            return categoria;
        }

        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _iCategoriaServico.AtualizarCategoria(categoria);
            return categoria;
        }

        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _iCategoria.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteCategoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var deleteCategoria = await _iCategoria.GetEntityById(id);
                await _iCategoria.Delete(deleteCategoria);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
