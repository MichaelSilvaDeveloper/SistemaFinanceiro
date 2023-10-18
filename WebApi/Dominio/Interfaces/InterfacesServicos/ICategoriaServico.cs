using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfacesServicos
{
    public interface ICategoriaServico
    {
        Task AdicionarCategoria(Categoria categoria);

        Task AtualizarCategoria(Categoria categoria);
    }
}
