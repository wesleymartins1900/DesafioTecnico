using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFilmes.Tests
{
    internal class Repository : IRepository<Filme>
    {
        private List<Filme> filmes = new List<Filme>();

        public Task<Filme[]> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AlterAsync(params Filme[] entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(params Filme[] entities)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(params Filme[] entities)
        {
            throw new NotImplementedException();
        }

        public Task<Filme[]> SelectByIdAsync(params int[] id)
        {
            throw new NotImplementedException();
        }
    }
}