using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfacesServicos
{
    public interface ISistemaFinanceiroServico
    {
        Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);

        Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);



    }
}