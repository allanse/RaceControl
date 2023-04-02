using Autofac;

namespace RaceControl.Infraestrutura.Configuracao
{
    public class ModuloDI : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfiguracaoDI.Load(builder);            
        }
    }
}
