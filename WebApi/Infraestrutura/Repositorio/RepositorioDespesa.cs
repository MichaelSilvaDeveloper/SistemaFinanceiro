using Dominio.Interfaces.IDespesa;
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
    public class RepositorioDespesa : RepositoryGenerics<Despesa>, IDespesa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioDespesa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Despesa>> ListaDespesasUsuario(string emailUsuario)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await
                            (
                             from s in data.SistemaFinanceiro
                             join c in data.Categoria on s.Id equals c.IdSistema
                             join us in data.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                             join d in data.Despesa on c.Id equals d.IdCategoria
                             where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                             select d
                            ).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListaDespesasUsuarioNaoPagasMesAnterior(string emailUsuario)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await
                            (
                             from s in data.SistemaFinanceiro
                             join c in data.Categoria on s.Id equals c.IdSistema
                             join us in data.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                             join d in data.Despesa on c.Id equals d.IdCategoria
                             where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                             select d
                            ).AsNoTracking().ToListAsync();
            }
        }
    }
}