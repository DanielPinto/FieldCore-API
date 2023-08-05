using FieldCoreAPI.Datas;
using FieldCoreAPI.Models;
using FieldCoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FieldCoreAPI.Repositories
{
    public class UnidadeRepository : IUnidadeRepository
    {

        private readonly FieldCoreAPIDBContext _dbContext;

        public UnidadeRepository(FieldCoreAPIDBContext fieldCoreAPIDBContext)
        {
            _dbContext = fieldCoreAPIDBContext;
        }

        public async Task<List<UnidadeModel>> GetAll() => await _dbContext.Unidades
            .Include(x => x.Users)
            .Include(x => x.Regional)
            .ToListAsync();


        public async Task<UnidadeModel> GetById(int id) => await _dbContext.Unidades
            .Include(x => x.Users)
            .Include(x=>x.Regional)
            .FirstOrDefaultAsync(x => x.Id == id);
        

        public async Task<UnidadeModel> Add(UnidadeModel unidade)
        {
            await _dbContext.Unidades.AddAsync(unidade);
            await _dbContext.SaveChangesAsync();

            return unidade;
        }

        public async Task<bool> DeleteById(int id)
        {
            UnidadeModel thisUnidade = await GetById(id);

            if (thisUnidade != null)
            {
                _dbContext.Remove(thisUnidade);
                await _dbContext.SaveChangesAsync();

                return true;
            }



            throw new Exception($"Unidade ID: {id} not found.");
        }


        public async Task<UnidadeModel> Update(UnidadeModel unidade, int id)
        {
            UnidadeModel thisUnidade = await GetById(id);

            if (thisUnidade != null)
            {
                thisUnidade.Name = unidade.Name;
                thisUnidade.Descricao = unidade.Descricao;

                unidade.Users?.ForEach(user => thisUnidade.Users.Add(user));
                

                _dbContext.Update(thisUnidade);
                await _dbContext.SaveChangesAsync();

                return thisUnidade;
            }

            throw new Exception($"User ID: {id} not found.");


        }
    }
}
