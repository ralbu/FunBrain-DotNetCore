﻿using System.Collections;
using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Models;

namespace FunBrainInfrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User GetById(int id);
        IEnumerable<User> GetByIds(IEnumerable<int> users);
        User Create(UserCreate newUser);
        User Update(int id, UserUpdate updateUser);
        bool Delete(int userId);
    }
}