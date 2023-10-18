using Dominio.Interfaces.InterfacesServicos;
using Dominio.Interfaces.IUsuarioSistemaFinanceiro;
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
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly IUsuarioSistemaFinanceiroServico _usuarioSistemaFinanceiroServico;

        private readonly IUsuarioSistemaFinanceiro _usuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroController(IUsuarioSistemaFinanceiroServico usuarioSistemaFinanceiroServico, IUsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            _usuarioSistemaFinanceiroServico = usuarioSistemaFinanceiroServico;
            _usuarioSistemaFinanceiro = usuarioSistemaFinanceiro;
        }

        [HttpGet("/api/ListarSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarSistemasUsuario(int idSistema)
        {
            return await _usuarioSistemaFinanceiro.ListaUsuariosSistemaFinanceiro(idSistema);
        }

        [HttpPost("/api/CadastraUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastraUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _usuarioSistemaFinanceiroServico.CadastraUsuarioNoSistema(new UsuarioSistemaFinanceiro
                {
                    IdSistema = idSistema,
                    EmailUsuario = emailUsuario,
                    Admnistrador = false,
                    SistemaAtual = true
                });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _usuarioSistemaFinanceiro.GetEntityById(id);

                await _usuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
                
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}