using Livraria.Domain.Abstractions;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Repositories
{
    internal class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LivroRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Livro?> ObterLivroPorId(int id)
        {
            var livroDataBase = await _dbContext.Livros.SingleOrDefaultAsync(livro => livro.Id == id);

            if (livroDataBase is not null)
                throw new InvalidOperationException($"Livro com ID {id} não encontrado");

            return livroDataBase;
        }

        public async Task<IEnumerable<Livro>> ObterLivros()
        {
            if (_dbContext is not null && _dbContext.Livros is not null)
            {
                var livrosDataBase = await _dbContext.Livros.ToListAsync();

                return livrosDataBase;
            }
            else
            {
                return new List<Livro>();
            }
        }

        public async Task<Livro> AdicionarLivro(Livro livro)
        {
            if (livro is not null && _dbContext is not null && _dbContext.Livros is not null)
            {
                await _dbContext.Livros.AddAsync(livro);
                await _dbContext.SaveChangesAsync();

                return livro;
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos...");
            }
        }

        public async Task AtualizarLivro(Livro livro)
        {
            if (livro is not null)
            {
                _dbContext.Entry(livro).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos...");
            }
        }

        public async Task DeletarLivro(int id)
        {
            var livroDataBase = await ObterLivroPorId(id);

            if (livroDataBase is not null)
            {
                _dbContext.Livros.Remove(livroDataBase);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos...");
            }
        }
    }
}
