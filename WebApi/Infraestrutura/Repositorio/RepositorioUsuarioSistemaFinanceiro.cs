using Dominio.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, IUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUsuarioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListaUsuariosSistemaFinanceiro(int IdSistema)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.UsuarioSistemaFinanceiro.Where(s => s.IdSistema == IdSistema).AsNoTracking().ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.UsuarioSistemaFinanceiro.AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.UsuarioSistemaFinanceiro.RemoveRange(usuarios);
                await data.SaveChangesAsync();
            }
        }
    }
}