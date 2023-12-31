﻿using FieldCoreAPI.Datas;
using FieldCoreAPI.Models;
using FieldCoreAPI.Models.Dtos;
using FieldCoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FieldCoreAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly FieldCoreAPIDBContext _dbContext;

        public UserRepository(FieldCoreAPIDBContext fieldCoreAPIDBContext)
        {
            _dbContext = fieldCoreAPIDBContext;
        }

        public async Task<List<UserDto>> GetAll()
        {
            List<UserModel> users = await _dbContext.Users.
                Include(x => x.Unidades)
                .ToListAsync();

            List<UserDto> userDtos = new();

            foreach (var user in users) {

                userDtos.Add(
                    new UserDto
                    {
                        Email = user.Email,
                        Id = user.Id,
                        Id_Corporate = user.Id_Corporate,
                        Name = user.Name,
                        Unidades = user.Unidades,
                    });
            }

            return userDtos;
        }

        public async Task<UserModel> GetById(int id) => await _dbContext.Users.
                Include(x => x.Unidades)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteById(int id)
        {
            UserModel thisUser = await GetById(id);

            if (thisUser != null)
            {
                _dbContext.Remove(thisUser);
                await _dbContext.SaveChangesAsync();

                return true;
            }



            throw new Exception($"User ID: {id} not found.");
        }


        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel thisUser = await GetById(id);
            //List<UnidadeModel> unidades = thisUser.Unidades;

            if (thisUser != null)
            {
                thisUser.Name = user.Name;
                thisUser.Email = user.Email;
                thisUser.Id_Corporate = user.Id_Corporate;

                user.Unidades?.ForEach(unidade=>thisUser.Unidades.Add(unidade));


                _dbContext.Update(thisUser);
                await _dbContext.SaveChangesAsync();

                return thisUser;
            }

            throw new Exception($"User ID: {id} not found.");


        }

        public async Task<UserModel> Auth(string email, string password)
        {

            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

        }
    }
}
