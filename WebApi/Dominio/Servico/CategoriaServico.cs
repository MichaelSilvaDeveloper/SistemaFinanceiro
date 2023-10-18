using Dominio.Interfaces.ICategoria;
using Dominio.Interfaces.InterfacesServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoria _iCategoria;

        public CategoriaServico(ICategoria iCategoria)
        {
            _iCategoria = iCategoria;
        }

        public async Task AdicionarCategoria(Categoria categoria)
        {
            var valid = categoria.ValidaPropriedadeString(categoria.Nome, "Nome");
            if (valid)
            {
                await _iCategoria.Add(categoria);
            }         
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            var valid = categoria.ValidaPropriedadeString(categoria.Nome, "Nome");
            if (valid)
            {
                await _iCategoria.Update(categoria);
            }
        }
    }
}