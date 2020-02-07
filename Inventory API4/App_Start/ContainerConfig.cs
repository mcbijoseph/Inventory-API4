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
            builder.RegisterType<InventoryBL._007_invNewItemHeaderListBL>().As<InventoryBL.I_007_invNewItemHeaderListBL<Inventory_Domain_Layer._007_invNewItemHeaderListDomain>>();
            builder.RegisterType<InventoryBL._008_invRefDelMethodAttributeBL>().As<InventoryBL.I_008_invRefDelMethodAttributeBL<Inventory_Domain_Layer._008_invRefDelMethodAttributeDomain>>();
            builder.RegisterType<InventoryBL._008a_invRefDelMethodAttrValueBL>().As<InventoryBL.I_008a_invRefDelMethodAttrValueBL<Inventory_Domain_Layer._008a_invRefDelMethodAttrValueDomain>>();
            builder.RegisterType<InventoryBL._009_invRefUnitsBL>().As<InventoryBL.I_009_invRefUnitsBL<Inventory_Domain_Layer._009_invRefUnitsDomain>>();
            builder.RegisterType<InventoryBL._010_invRefDeliveryMethodBL>().As<InventoryBL.I_010_invRefDeliveryMethodBL<Inventory_Domain_Layer._010_invRefDeliveryMethodDomain>>();
            builder.RegisterType<InventoryBL._011_invRefItemsMasterListBL>().As<InventoryBL.I_011_invRefItemsMasterListBL<Inventory_Domain_Layer._011_invRefItemsMasterListDomain>>();
            builder.RegisterType<InventoryBL._012_invItemAttrivbuteBL>().As<InventoryBL.I_012_invItemAttributeBL<Inventory_Domain_Layer._012_invItemAttributeDomain>>();
            builder.RegisterType<InventoryBL._013_invNewItemEntryListBL>().As<InventoryBL.I_013_invNewItemEntryListBL<Inventory_Domain_Layer._013_invNewItemEntryListDomain>>();
            builder.RegisterType<InventoryBL._014_invRefItemImageBL>().As<InventoryBL.I_014_invRefItemImageBL<Inventory_Domain_Layer._014_invRefItemImageDomain>>();
            builder.RegisterType<InventoryBL._015_invRefItemPropListBL>().As<InventoryBL.I_015_invRefItemPropListBL<Inventory_Domain_Layer._015_invRefItemPropListDomain>>();
            builder.RegisterType<InventoryBL._017_invNewInfoDelMetAttrValueBL>().As<InventoryBL.I_017_invNewInfoDelMetAttrValueBL<Inventory_Domain_Layer._017_invNewInfoDelMetAttrValueDomain>>();
            builder.RegisterType<InventoryBL._018_invRefItemConditiontBL>().As<InventoryBL.I_018_invRefItemConditiontBL<Inventory_Domain_Layer._018_invRefItemConditionDomain>>();
            builder.RegisterType<InventoryBL._019_invReleasedItemHeaderBL>().As<InventoryBL.I_019_invReleasedItemHeaderBL<Inventory_Domain_Layer._019_invReleasedItemHeaderDomain>>();
            builder.RegisterType<InventoryBL._020_invReleasedItemDetailsBL>().As<InventoryBL.I_020_invReleasedItemDetailsBL<Inventory_Domain_Layer._020_invReleasedItemDetailsDomain>>();
            builder.RegisterType<InventoryBL._021_invTransMasterListBL>().As<InventoryBL.I_021_invTransMasterListBL<Inventory_Domain_Layer._021_invTransMasterListDomain>>();
            builder.RegisterType<InventoryBL._022_invTransInfoOriginBL>().As<InventoryBL.I_022_invTransInfoOriginBL<Inventory_Domain_Layer._022_invTransInfoOriginDomain>>();
            builder.RegisterType<InventoryBL._023_invTransInfoDestinationBL>().As<InventoryBL.I_023_invTransInfoDestinationBL<Inventory_Domain_Layer._023_invTransInfoDestinationDomain>>();
            builder.RegisterType<InventoryBL._024_invTransInfoDelMetAttrValueBL>().As<InventoryBL.I_024_invTransInfoDelMetAttrValueBL<Inventory_Domain_Layer._024_invTransInfoDelMetAttrValueDomain>>();
            builder.RegisterType<InventoryBL._025_invTransItemEntryListBL>().As<InventoryBL.I_025_invTransItemEntryListBL<Inventory_Domain_Layer._025_invTransItemEntryListDomain>>();
            builder.RegisterType<InventoryBL._026_invTransItemRecievedListBL>().As<InventoryBL.I_026_invTransItemRecievedListBL<Inventory_Domain_Layer._026_invTransItemReceivedListDomain>>();
            builder.RegisterType<InventoryBL._027_invWithdrawMasterListBL>().As<InventoryBL.I_027_invWithdrawMasterListBL<Inventory_Domain_Layer._027_invWithdrawMasterListDomain>>();
            builder.RegisterType<InventoryBL._028_invWithdrawItemEntryListBL>().As<InventoryBL.I_028_invWithdrawItemEntryListBL<Inventory_Domain_Layer._028_invWithdrawItemEntryListDomain>>();
            builder.RegisterType<InventoryBL._029_invRefFormListBL>().As<InventoryBL.I_029_invRefFormListBL<Inventory_Domain_Layer._029_invRefFormListDomain>>();
            builder.RegisterType<InventoryBL._030_invRefFormHardCopySeriesBL>().As<InventoryBL.I_030_invRefFormHardCopySeriesBL<Inventory_Domain_Layer._030_invRefFormHardCopySeriesDomain>>();
            builder.RegisterType<InventoryBL._031_invRefTransferListBL>().As<InventoryBL.I_031_invRefFormTransferListBL<Inventory_Domain_Layer._031_invRefFormTransferListDomain>>();
            builder.RegisterType<InventoryBL.vwItemProjectQuantityBL>().As<InventoryBL.IvwItemProjectQuantityBL>();

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