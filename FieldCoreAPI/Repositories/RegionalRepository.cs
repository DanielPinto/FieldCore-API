using FieldCoreAPI.Datas;
using FieldCoreAPI.Models;
using FieldCoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FieldCoreAPI.Repositories
{
    public class RegionalRepository : IRegionalRepository
    {

        private readonly FieldCoreAPIDBContext _dbContext;

        public RegionalRepository(FieldCoreAPIDBContext fieldCoreAPIDBContext)
        {
            _dbContext = fieldCoreAPIDBContext;
        }

        public async Task<List<RegionalModel>> GetAll() => await _dbContext.Regionais.Include(x => x.Unidades).ToListAsync();
        

        public async Task<RegionalModel> GetById(int id) => await _dbContext.Regionais.
                Include(x=>x.Unidades)
                .FirstOrDefaultAsync(x => x.Id == id);
        

        public async Task<RegionalModel> Add(RegionalModel regional)
        {
            await _dbContext.Regionais.AddAsync(regional);
            await _dbContext.SaveChangesAsync();

            return regional;
        }

        public async Task<bool> DeleteById(int id)
        {
            RegionalModel thisRegional = await GetById(id);

            if (thisRegional != null)
            {
                _dbContext.Remove(thisRegional);
                await _dbContext.SaveChangesAsync();

                return true;
            }



            throw new Exception($"Regional ID: {id} not found.");
        }


        public async Task<RegionalModel> Update(RegionalModel regional, int id)
        {
            RegionalModel thisRegional = await GetById(id);

            if (thisRegional != null)
            {
                thisRegional.Name = regional.Name;
                thisRegional.Descricao = regional.Descricao;

                regional.Unidades.ForEach(x => thisRegional.Unidades.Add(x));



                _dbContext.Update(thisRegional);
                await _dbContext.SaveChangesAsync();

                return thisRegional;
            }

            throw new Exception($"Regional ID: {id} not found.");


        }

    }
}
