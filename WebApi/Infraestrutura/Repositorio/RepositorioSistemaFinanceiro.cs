using Dominio.Interfaces.ISistemaFinanceiro;
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
    public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, ISistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await
                            (
                             from s in data.SistemaFinanceiro
                             join us in data.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                             where us.EmailUsuario.Equals(emailUsuario)
                             select s
                            ).AsNoTracking().ToListAsync();
            }
        }
    }
}