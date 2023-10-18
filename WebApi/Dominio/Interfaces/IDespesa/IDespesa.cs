using Dominio.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.IDespesa
{
    public interface IDespesa : IGeneric<Despesa>
    {
        Task<IList<Despesa>> ListaDespesasUsuario(string emailUsuario);

        Task<IList<Despesa>> ListaDespesasUsuarioNaoPagasMesAnterior(string emailUsuario);
    }
}