if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Conhecimento') and o.name = 'FK_CONHECIM_REFERENCE_PROGRAMA')
alter table Conhecimento
   drop constraint FK_CONHECIM_REFERENCE_PROGRAMA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Conhecimento')
            and   type = 'U')
   drop table Conhecimento
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Programador')
            and   type = 'U')
   drop table Programador
go

/*==============================================================*/
/* Table: Conhecimento                                          */
/*==============================================================*/
create table Conhecimento (
   IDProgramador        bigint               not null,
   Ionic                int                  not null,
   Reactjs              int                  not null,
   Reactnative          int                  not null,
   Android              int                  not null,
   IOS                  int                  not null,
   HTML                 int                  not null,
   CSS                  int                  not null,
   Bootstrap            int                  not null,
   Jquery               int                  not null,
   AngularJS            int                  not null,
   Outro                varchar(500)         null,
   constraint PK_CONHECIMENTO primary key (IDPROGRAMADOR)
)
go

/*==============================================================*/
/* Table: Programador                                           */
/*==============================================================*/
create table Programador (
   IDProgramador        bigint IDENTITY(1,1) not null,
   EMail                varchar(120)         not null,
   Nome                 varchar(120)         not null,
   Skype                varchar(120)         not null,
   Telefone             bigint               not null,
   Linkedin             varchar(120)         not null,
   Cidade               varchar(120)         not null,
   Estado               varchar(120)         not null,
   DisponibilidadeTrabalho varchar(1)           not null,
   MelhorHorario        varchar(1)           not null,
   Pretensao            int                  not null,
   constraint PK_PROGRAMADOR primary key (IDProgramador)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Programador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DisponibilidadeTrabalho')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Programador', 'column', 'DisponibilidadeTrabalho'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Qual é sua disponibilidade para trabalhar hoje?
   1 - Up to 4 hours per day / Até 4 horas por dia
   2 - 4 to 6 hours per day / De 4 á 6 horas por dia
   3 - 6 to 8 hours per day /De 6 á 8 horas por dia
   4 - Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)
   5 - Only weekends / Apenas finais de semana
   6 - Horário a definir (Qualquer horário)',
   'user', @CurrentUser, 'table', 'Programador', 'column', 'DisponibilidadeTrabalho'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Programador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MelhorHorario')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Programador', 'column', 'MelhorHorario'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Pra você qual é o melhor horário para trabalhar?
   1 - Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)
   2 - Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)
   3 - Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)
   4 - Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)
   5 - Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)
   6 - Horário a definir (Qualquer horário)',
   'user', @CurrentUser, 'table', 'Programador', 'column', 'MelhorHorario'
go

alter table Conhecimento
   add constraint FK_CONHECIM_REFERENCE_PROGRAMA foreign key (IDProgramador)
      references Programador (IDProgramador)
go
