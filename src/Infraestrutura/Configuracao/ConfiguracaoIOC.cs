using Autofac;
using AutoMapper;
using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;
using RaceControl.Dominio.Mappers;
using RaceControl.Dominio.Servicos;
using RaceControl.Infraestrutura.Data.Repositorios;

namespace RaceControl.Infraestrutura.Configuracao
{
    public class ConfiguracaoIOC
    {
        public static void Load (ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ServicoCompetidor>().AsSelf();
            containerBuilder.RegisterType<ServicoPistaCorrida>().AsSelf();
            containerBuilder.RegisterType<ServicoHistoricoCorrida>().AsSelf();
            containerBuilder.RegisterType<RepositorioBase<Competidor>>().As<IRepositorioBase<Competidor>>();
            containerBuilder.RegisterType<RepositorioBase<PistaCorrida>>().As<IRepositorioBase<PistaCorrida>>();
            containerBuilder.RegisterType<RepositorioBase<HistoricoCorrida>>().As<IRepositorioBase<HistoricoCorrida>>();
            containerBuilder.RegisterType<RepositorioHistoricoCorrida>().As<IRepositorioHistoricoCorrida>();
            containerBuilder.RegisterType<RepositorioCompetidor>().As<IRepositorioCompetidor>();

            containerBuilder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToEntidadeMappingHistoricoCorrida());
            }));

            containerBuilder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
