﻿using Hero.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hero.Repo
{
    public interface IHeroRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();

        Task<Heroi[]> GetAllHerois(bool incluirBatalha = false);
        Task<Heroi> GetHeroiById(int id, bool incluirBatalha = false);
        Task<Heroi[]> GetHeroisByNome(string nome, bool incluirBatalha = false);
        Task<Batalha[]> GetAllBatalhas(bool incluirHerois = false);
        Task<Batalha> GetBatalhaById(int id, bool incluirHerois = false);
    }
}
