using Dominio.Interfaces.InterfacesServicos;
using Dominio.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class UsuarioSistemaFinanceiroServico : IUsuarioSistemaFinanceiroServico
    {
        private readonly IUsuarioSistemaFinanceiro _iUsuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroServico(IUsuarioSistemaFinanceiro iUsuarioSistemaFinanceiro)
        {
            _iUsuarioSistemaFinanceiro = iUsuarioSistemaFinanceiro;
        }

        public async Task CadastraUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _iUsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}