using Dominio.Interfaces.IDespesa;
using Dominio.Interfaces.InterfacesServicos;
using Entities.Entidades;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class DespesaServico : IDespesaServico
    {
        private readonly IDespesa _iDespesa;

        public DespesaServico(IDespesa iDespesa)
        {
            _iDespesa = iDespesa;
        }

        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;
            var valid = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valid)
            {
                await _iDespesa.Add(despesa);
            }
        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataPagamento = data;

            if(despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valid = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valid)
            {
                await _iDespesa.Update(despesa);
            }
        }

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            var despesasUsuario = await _iDespesa.ListaDespesasUsuario(emailUsuario);

            var despesasAnterior = await _iDespesa.ListaDespesasUsuarioNaoPagasMesAnterior(emailUsuario);

            var despesasNaoPagasMesesAnteriores = despesasAnterior.Any() ?
                despesasAnterior.ToList().Sum(x => x.Valor) : 0;

            var despesasPagas = despesasUsuario.Where(d => d.Pago && d.TipoDespesa == EnumTipoDespesa.Contas).Sum(x => x.Valor);

            var despesasPendentes = despesasUsuario.Where(d => !d.Pago && d.TipoDespesa == EnumTipoDespesa.Contas).Sum(x => x.Valor);

            var investimentos = despesasUsuario.Where(d => d.TipoDespesa == EnumTipoDespesa.Contas).Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                despesas_Pagas = despesasPagas,
                despesas_Pendentes = despesasPendentes,
                despesas_NaoPagasMesesAnteriores = despesasNaoPagasMesesAnteriores,
                investimentos = investimentos
            };
        }
    }
}
