using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyProject.Models
{
    public class ContentProgramador
    {
        public long IDProgramador { get; set; }
        public string EMail { get; set; }
        public string Nome { get; set; }
        public string Skype { get; set; }
        public long Telefone { get; set; }
        public string Linkedin { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string DisponibilidadeTrabalho { get; set; }
        public string MelhorHorario { get; set; }
        public int Pretensao { get; set; }

        public ContentConhecimento Conhecimento { get; set; }
    }
}