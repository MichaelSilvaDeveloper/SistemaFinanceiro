using Dominio.Interfaces.IDespesa;
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
    public class DespesasController : ControllerBase
    {
        private readonly IDespesa _iDespesa;

        private readonly IDespesaServico _iDespesaServico;

        public DespesasController(IDespesa iDespesa, IDespesaServico iDespesaServico)
        {
            _iDespesa = iDespesa;
            _iDespesaServico = iDespesaServico;
        }

        [HttpGet("/api/ListaDespesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaDespesasUsuario(string emailUsuario)
        {
            return await _iDespesa.ListaDespesasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesa(Despesa despesa)
        {
            await _iDespesaServico.AdicionarDespesa(despesa);
            return despesa;
        }

        [HttpPut("/api/AtualizarDespesa")]
        [Produces("application/json")]
        public async Task<object> AtualizarDespesa(Despesa despesa)
        {
            await _iDespesaServico.AtualizarDespesa(despesa);
            return despesa;
        }

        [HttpGet("/api/ObterDespesa")]
        [Produces("application/json")]
        public async Task<object> ObterDespesa(int id)
        {
            return await _iDespesa.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteDespesa")]
        [Produces("application/json")]
        public async Task<object> DeleteDespesa(int id)
        {
            try
            {
                var deleteDespesa = await _iDespesa.GetEntityById(id);
                await _iDespesa.Delete(deleteDespesa);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [HttpGet("/api/CarregarGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregarGraficos(string emailUsuario)
        {
            return await _iDespesaServico.CarregaGraficos(emailUsuario);
        }
    }
}