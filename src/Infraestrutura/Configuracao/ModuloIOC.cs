using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaceControl.Infraestrutura.Configuracao
{
    public class ModuloIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfiguracaoIOC.Load(builder);            
        }
    }
}
