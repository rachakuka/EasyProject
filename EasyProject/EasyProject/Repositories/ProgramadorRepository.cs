using EasyProject.Exceptions;
using EasyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace EasyProject.Repositories
{
    public class ProgramadorRepository : IProgramadorRepository, IDisposable
    {
        public EasyProjectEntities context = new EasyProjectEntities();

        public List<ContentProgramador> GetProgramadores()
        {
            return ListProgramador().ToList();
        }

        public Programador Get(long id)
        {
            return context.Programadors.Find(id);
        }

        public ContentProgramador GetProgramador(long id)
        {
            return ListProgramador().Where(p => p.IDProgramador == id).FirstOrDefault();
        }

        public void Add(Programador programador)
        {
            using (EasyProjectEntities db = new EasyProjectEntities())
            {
                db.Programadors.Add(programador);
                db.SaveChanges();
            }
        }

        public void Update(Programador updateProgramador)
        {
            using (EasyProjectEntities db = new EasyProjectEntities())
            {
                db.Entry(updateProgramador).State = EntityState.Modified;
                db.Entry(updateProgramador.Conhecimento).State = EntityState.Modified;
                db.SaveChanges();
            }

        }

        public void Remove(long idProgramador)
        {
            using (EasyProjectEntities db = new EasyProjectEntities())
            {
                var prog = db.Programadors.Include(b => b.Conhecimento).FirstOrDefault(b => b.IDProgramador == idProgramador);
                db.Programadors.Remove(prog);
                db.SaveChanges();
            }
        }

        private IEnumerable<ContentProgramador> ListProgramador()
        {
            IEnumerable<ContentProgramador> progs = (from i in context.Programadors
                                                     join a in context.Conhecimentoes on i.IDProgramador equals a.IDProgramador
                                                     select new ContentProgramador()
                                                     {
                                                         IDProgramador = i.IDProgramador,
                                                         EMail = i.EMail,
                                                         Nome = i.Nome,
                                                         Skype = i.Skype,
                                                         Telefone = i.Telefone,
                                                         Linkedin = i.Linkedin,
                                                         Cidade = i.Cidade,
                                                         Estado = i.Estado,
                                                         DisponibilidadeTrabalho = i.DisponibilidadeTrabalho,
                                                         MelhorHorario = i.MelhorHorario,
                                                         Pretensao = i.Pretensao,
                                                         Conhecimento = new ContentConhecimento()
                                                         {
                                                             Ionic = a.Ionic,
                                                             Reactjs = a.Reactjs,
                                                             Reactnative = a.Reactnative,
                                                             Android = a.Android,
                                                             IOS = a.IOS,
                                                             HTML = a.HTML,
                                                             CSS = a.CSS,
                                                             Bootstrap = a.Bootstrap,
                                                             Jquery = a.Jquery,
                                                             AngularJS = a.AngularJS,
                                                             Outro = a.Outro
                                                         }
                                                     });
            return progs;
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