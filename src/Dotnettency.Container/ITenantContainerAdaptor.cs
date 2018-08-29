﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotnettency.Container
{
    public interface ITenantContainerAdaptor : IServiceProvider, IDisposable
    {
        ITenantContainerAdaptor CreateNestedContainer(string Name);
        ITenantContainerAdaptor CreateChildContainer(string Name);

        ITenantContainerAdaptor CreateChildContainerAndConfigure(string Name, Action<IServiceCollection> configure);
        ITenantContainerAdaptor CreateNestedContainerAndConfigure(string Name, Action<IServiceCollection> configure);

        /// <summary>
        /// Adding services to an already running / configured container is bad. Safer to treat a created container as immutable.
        /// Need to re-design modules system to solve this.
        /// </summary>
        /// <param name="configure"></param>
        void AddServices(Action<IServiceCollection> configure);

        /// <summary>
        /// Used to add services to a container AFTER its initialised.
        /// </summary>
        /// <param name="configure"></param>
     //   void Configure(Action<IServiceCollection> configure);

        string ContainerName { get; }
        Guid ContainerId { get; }
        ContainerRole Role { get; }
    }
}
