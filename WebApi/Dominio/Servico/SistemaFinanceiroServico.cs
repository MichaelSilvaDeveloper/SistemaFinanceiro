using Dominio.Interfaces.InterfacesServicos;
using Dominio.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class SistemaFinanceiroServico : ISistemaFinanceiroServico
    {
        private readonly ISistemaFinanceiro _iSistemaFinanceiro;

        public SistemaFinanceiroServico(ISistemaFinanceiro iSistemaFinanceiro)
        {
            _iSistemaFinanceiro = iSistemaFinanceiro;
        }

        public async Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valid = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if (valid)
            {
                var data = DateTime.UtcNow;
                sistemaFinanceiro.DiaFechamento = 1;
                sistemaFinanceiro.Ano = data.Year;
                sistemaFinanceiro.Mes = data.Month;
                sistemaFinanceiro.AnoCopia = data.Year;
                sistemaFinanceiro.MesCopia = data.Month;
                sistemaFinanceiro.GerarCopiaDespesa = true;

                await _iSistemaFinanceiro.Add(sistemaFinanceiro);
            }            
        }

        public async Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valid = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if (valid)
            {
                sistemaFinanceiro.DiaFechamento = 1;

                await _iSistemaFinanceiro.Update(sistemaFinanceiro);
            }
        }
    }
}
