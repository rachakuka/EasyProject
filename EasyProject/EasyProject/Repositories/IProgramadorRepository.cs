using EasyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyProject.Repositories
{
    public interface IProgramadorRepository : IDisposable
    {
        List<ContentProgramador> GetProgramadores();
        Programador Get(long idProgramador);
        ContentProgramador GetProgramador(long idProgramador);
        void Add(Programador programador);
        void Update(Programador programador);
        void Remove(long idProgramador);
    }
}