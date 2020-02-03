using System.Reflection;
using System.Web.Mvc;
using Autofac;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Collections;
using System.Collections.Generic;

namespace Inventory_API4.App_Start
{
    public class ContainerConfig
    {

        public static void Configure()
        {
            
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //builder.RegisterType<ValuesController>().InstancePerRequest();
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Item Data Registering.....
            //builder.RegisterType<SQLBL>().As<ISQLBL>().WithParameter("connectionString", Properties.Settings.Default.connectionString);

            builder.RegisterType<InventoryBL._001_invRefCategory1BL>().As<InventoryBL.I_001_invRefCategory1BL<Inventory_Domain_Layer._001_invRefCategory1Domain>>();
            builder.RegisterType<InventoryBL._002_invRefCategory2BL>().As<InventoryBL.I_002_invRefCategory2BL<Inventory_Domain_Layer._002_invRefCategory2Domain>>();
            builder.RegisterType<InventoryBL._003_invRefCategory3BL>().As<InventoryBL.I_003_invRefCategory3BL<Inventory_Domain_Layer._003_invRefCategory3Domain>>();
            builder.RegisterType<InventoryBL._004_invRefPropertyName1BL>().As<InventoryBL.I_004_invRefPropertyName1BL<Inventory_Domain_Layer._004_invRefPropertyName1Domain>>();
            builder.RegisterType<InventoryBL._005_invRefPropertyName2BL>().As<InventoryBL.I_005_invRefPropertyName2BL<Inventory_Domain_Layer._005_invRefPropertyName2Domain>>();
            builder.RegisterType<InventoryBL._006_invRefAttributeBL>().As<InventoryBL.I_006_invRefAttributeBL<Inventory_Domain_Layer._006_invRefAttributeDomain>>();
            builder.RegisterType<InventoryBL._007_invRefDocEntryListBL>().As<InventoryBL.I_007_invRefDocEntryListBL<Inventory_Domain_Layer._007_invRefDocEntryListDomain>>();
            builder.RegisterType<InventoryBL._008_invRefDelMethodAttributeBL>().As<InventoryBL.I_008_invRefDelMethodAttributeBL<Inventory_Domain_Layer._008_invRefDelMethodAttributeDomain>>();
            builder.RegisterType<InventoryBL._009_invRefUnitsBL>().As<InventoryBL.I_009_invRefUnitsBL<Inventory_Domain_Layer._009_invRefUnitsDomain>>();
            builder.RegisterType<InventoryBL._010_invRefDeliveryMethodBL>().As<InventoryBL.I_010_invRefDeliveryMethodBL<Inventory_Domain_Layer._010_invRefDeliveryMethodDomain>>();
            builder.RegisterType<InventoryBL._011_invRefItemsMasterListBL>().As<InventoryBL.I_011_invRefItemsMasterListBL<Inventory_Domain_Layer._011_invRefItemsMasterListDomain>>();
            builder.RegisterType<InventoryBL._012_invItemAttrivbuteBL>().As<InventoryBL.I_012_invItemAttributeBL<Inventory_Domain_Layer._012_invItemAttributeDomain>>();
            builder.RegisterType<InventoryBL._013_invItemsEntryListBL>().As<InventoryBL.I_013_invItemsEntryListBL<Inventory_Domain_Layer._013_invItemsEntryListDomain>>();
            builder.RegisterType<InventoryBL._014_invRefItemImageBL>().As<InventoryBL.I_014_invRefItemImageBL<Inventory_Domain_Layer._014_invRefItemImageDomain>>();
            builder.RegisterType<InventoryBL._015_invRefItemPropListBL>().As<InventoryBL.I_015_invRefItemPropListBL<Inventory_Domain_Layer._015_invRefItemPropListDomain>>();
            builder.RegisterType<InventoryBL._016_invRefItemCategoryBL>().As<InventoryBL.I_016_invRefItemCategoryBL<Inventory_Domain_Layer._016_invRefItemCategoryDomain>>();
            builder.RegisterType<InventoryBL._017_invDeliveryMethodEntryListBL>().As<InventoryBL.I_017_invDeliveryMethodEntryListBL<Inventory_Domain_Layer._017_invDeliveryMethodEntryListDomain>>();
            builder.RegisterType<InventoryBL._018_invRefItemConditiontBL>().As<InventoryBL.I_018_invRefItemConditiontBL<Inventory_Domain_Layer._018_invRefItemConditionDomain>>();
            builder.RegisterType<InventoryBL._019_invReleasedItemHeaderBL>().As<InventoryBL.I_019_invReleasedItemHeaderBL<Inventory_Domain_Layer._019_invReleasedItemHeaderDomain>>();
            builder.RegisterType<InventoryBL._020_invReleasedItemDetailsBL>().As<InventoryBL.I_020_invReleasedItemDetailsBL<Inventory_Domain_Layer._020_invReleasedItemDetailsDomain>>();
            builder.RegisterType<InventoryBL._021_invTransferedItemsHeaderBL>().As<InventoryBL.I_021_invTransferedItemsHeaderBL<Inventory_Domain_Layer._021_invTransferedItemsHeaderDomain>>();
            builder.RegisterType<InventoryBL._022_invTransferedItemsDetailsBL>().As<InventoryBL.I_022_invTransferedItemsDetailsBL<Inventory_Domain_Layer._022_invTransferedItemsDetailsDomain>>();
            builder.RegisterType<InventoryBL._023_invTransItemsDelMethodAttributeBL>().As<InventoryBL.I_023_invTransItemsDelMethodAttributeBL<Inventory_Domain_Layer._023_invTransItemsDelMethodAttributeDomain>>();

            List<Autofac.Core.Parameter> pars = new List<Autofac.Core.Parameter>();
            //pars.Add( new Autofac.Core.Parameter(""))

            
            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            //builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //return container;
            

            /*var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<InventoryBL._001_invRefCategory1BL>().As<InventoryBL.I_001_invRefCategory1BL<Inventory_Domain_Layer._001_invRefCategory1Domain>>();

            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            */
            
        }

    }
}