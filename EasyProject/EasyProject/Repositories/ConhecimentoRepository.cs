using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using EasyProject.Models;
using System.Data.Entity;

namespace EasyProject.Repositories
{
    public class ConhecimentoRepository : IConhecimentoRepository, IDisposable
    {
        private EasyProjectEntities context;

        public ConhecimentoRepository(EasyProjectEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Conhecimento> GetConhecimentos()
        {
            return context.Conhecimentoes.ToList();
        }

        public Conhecimento Get(long idProgramador)
        {
            return context.Conhecimentoes.Find(idProgramador);
        }

        public void Add(Conhecimento Conhecimento)
        {
            context.Conhecimentoes.Add(Conhecimento);
        }

        public void Remove(long idProgramador)
        {
            Conhecimento Conhecimento = context.Conhecimentoes.Find(idProgramador);
            context.Conhecimentoes.Remove(Conhecimento);
        }

        public void Update(Conhecimento Conhecimento)
        {
            context.Entry(Conhecimento).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}