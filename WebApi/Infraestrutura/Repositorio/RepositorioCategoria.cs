using Dominio.Interfaces.ICategoria;
using Entities.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioCategoria : RepositoryGenerics<Categoria>, ICategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioCategoria()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Categoria>> ListarCategoriasDoUsuario(string email)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await
                            (
                             from s in data.SistemaFinanceiro
                             join c in data.Categoria on s.Id equals c.IdSistema
                             join us in data.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                             where us.EmailUsuario.Equals(email) && us.SistemaAtual
                             select c
                            ).AsNoTracking().ToListAsync();
            }
        }
    }
}