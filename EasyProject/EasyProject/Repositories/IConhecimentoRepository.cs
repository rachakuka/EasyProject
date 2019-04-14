using EasyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyProject.Repositories
{
    public interface IConhecimentoRepository : IDisposable
    {
        IEnumerable<Conhecimento> GetConhecimentos();
        Conhecimento Get(long idProgramador);
        void Add(Conhecimento conhecimento);
        void Remove(long idProgramador);
        void Update(Conhecimento conhecimento);
    }
}