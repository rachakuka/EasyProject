using EasyProject.Exceptions;
using EasyProject.Models;
using EasyProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace EasyProject.BusinessLogic
{
    public class ProgramadorBLL
    {
        public EasyProjectEntities context = new EasyProjectEntities();
        public List<ContentProgramador> GetProgramadores()
        {
            return new ProgramadorRepository().GetProgramadores();
        }

        public Programador Get(long idProgramador)
        {
            Programador prog = new ProgramadorRepository().Get(idProgramador);
            if (prog == null)
                throw new BusinessRuleException("Atenção: Programador Não foi encontrado.", ExceptionHandlerSeverity.ALERTA);
            return prog;
        }

        public ContentProgramador GetProgramador(long idProgramador)
        {
            ContentProgramador prog = new ProgramadorRepository().GetProgramador(idProgramador);
            if (prog == null)
                throw new BusinessRuleException("Atenção: Programador Não foi encontrado.", ExceptionHandlerSeverity.ALERTA);
            return prog;
        }
        
        public ContentProgramador Add(Programador programador)
        {
            if (programador == null)
                throw new BusinessRuleException("Atenção: Ocorreu um erro durante o cadastro de programador tente de novo mais tarde", ExceptionHandlerSeverity.ALERTA);
            ValidaSalvar(programador);
            new ProgramadorRepository().Add(programador);
            return GetProgramador(programador.IDProgramador);
        }

        public void Update(Programador updateProgramador)
        {
            if (updateProgramador == null)
                throw new BusinessRuleException("Atenção: Programador não foi encontrado.", ExceptionHandlerSeverity.ALERTA);
            Programador prog = new ProgramadorRepository().Get(updateProgramador.IDProgramador);
            if (prog == null)
                throw new BusinessRuleException("Atenção: Programador Não foi encontrado.", ExceptionHandlerSeverity.ALERTA);

            Conhecimento conhecimento = new ConhecimentoRepository(context).Get(updateProgramador.Conhecimento.IDProgramador);
            if (conhecimento == null)
                throw new BusinessRuleException("Atenção: Programador Não foi encontrado conhecimentos, por favor cadastre um novo registro.", ExceptionHandlerSeverity.ALERTA);

            ValidaSalvar(updateProgramador);
            new ProgramadorRepository().Update(updateProgramador);
        }

        private void ValidaSalvar(Programador programador)
        {
            if (programador.Conhecimento.Ionic == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para Ionic.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.Reactjs == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para Reactjs.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.Reactnative == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para React Native.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.Android == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para Android.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.IOS == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para IOS.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.HTML == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para HTML.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.CSS == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para CSS.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.Bootstrap == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para Bootstrap.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.Jquery == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para Jquery.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Conhecimento.AngularJS == 0)
                throw new BusinessRuleException("Atenção: Informe uma classificação para AngularJS.", ExceptionHandlerSeverity.ALERTA);
            if (programador.EMail == null || programador.EMail == "")
                throw new BusinessRuleException("Atenção: Informe o campo E-Mail.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Skype == null || programador.Skype == "")
                throw new BusinessRuleException("Atenção: Informe o campo Skype.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Telefone == 0)
                throw new BusinessRuleException("Atenção: Informe o campo Telefone.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Linkedin == null || programador.Linkedin == "")
                throw new BusinessRuleException("Atenção: Informe o campo Linkedin.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Cidade == null || programador.Cidade == "")
                throw new BusinessRuleException("Atenção: Informe o campo Cidade.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Estado == null || programador.Estado == "")
                throw new BusinessRuleException("Atenção: Informe o campo Estado.", ExceptionHandlerSeverity.ALERTA);
            if (programador.DisponibilidadeTrabalho == null || programador.DisponibilidadeTrabalho == "")
                throw new BusinessRuleException("Atenção: Informe disponibilidade de trabalho.", ExceptionHandlerSeverity.ALERTA);
            if (programador.MelhorHorario == null || programador.MelhorHorario == "")
                throw new BusinessRuleException("Atenção: Informe o melhor horário de trabalho.", ExceptionHandlerSeverity.ALERTA);
            if (programador.Pretensao == 0)
                throw new BusinessRuleException("Atenção: Pretenção salárial tem que ser maior que 0.", ExceptionHandlerSeverity.ALERTA);

        }

        public void Remove(long idProgramador)
        {
            Programador prog = new ProgramadorRepository().Get(idProgramador);
            if (prog == null)
                throw new BusinessRuleException("Atenção: Programador Não foi encontrado.", ExceptionHandlerSeverity.ALERTA);
            Conhecimento conhecimento = new ConhecimentoRepository(context).Get(idProgramador);
            if (conhecimento == null)
                throw new BusinessRuleException("Atenção: Programador Não foi encontrado conhecimentos, por favor cadastre um novo registro.", ExceptionHandlerSeverity.ALERTA);

            new ProgramadorRepository().Remove(idProgramador);
        }
        
    }
}