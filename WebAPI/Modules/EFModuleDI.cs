﻿using Autofac;
using DAL;
using Repository;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Modules
{
    public class EFModuleDI : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType(typeof(VehicleContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

        }
    }
}