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

            builder.RegisterType<InventoryBL._001_invRefCategory1BL>().As<InventoryBL.I_001_invRefCategory1BL<Models._001_invRefCategory1Domain>>();
            builder.RegisterType<InventoryBL._002_invRefCategory2BL>().As<InventoryBL.I_002_invRefCategory2BL<Models._002_invRefCategory2Domain>>();
            builder.RegisterType<InventoryBL._003_invRefItemFullNameBL>().As<InventoryBL.I_003_invRefItemFullNameBL<Models._003_invRefItemFullNameDomain>>();
            builder.RegisterType<InventoryBL._004_invRefPropertyName1BL>().As<InventoryBL.I_004_invRefPropertyName1BL<Models._004_invRefPropertyName1Domain>>();
            builder.RegisterType<InventoryBL._005_invRefPropertyName2BL>().As<InventoryBL.I_005_invRefPropertyName2BL<Models._005_invRefPropertyName2Domain>>();
            builder.RegisterType<InventoryBL._006_invRefAttributeBL>().As<InventoryBL.I_006_invRefAttributeBL<Models._006_invRefAttributeDomain>>();
            builder.RegisterType<InventoryBL._007_invNewItemHeaderListBL>().As<InventoryBL.I_007_invNewItemHeaderListBL<Models._007_invNewItemHeaderListDomain>>();
            builder.RegisterType<InventoryBL._008_invRefDelMethodAttributeBL>().As<InventoryBL.I_008_invRefDelMethodAttributeBL<Models._008_invRefDelMethodAttributeDomain>>();
            builder.RegisterType<InventoryBL._008a_invRefDelMethodAttrValueBL>().As<InventoryBL.I_008a_invRefDelMethodAttrValueBL<Models._008a_invRefDelMethodAttrValueDomain>>();
            builder.RegisterType<InventoryBL._009_invRefUnitsBL>().As<InventoryBL.I_009_invRefUnitsBL<Models._009_invRefUnitsDomain>>();
            builder.RegisterType<InventoryBL._010_invRefDeliveryMethodBL>().As<InventoryBL.I_010_invRefDeliveryMethodBL<Models._010_invRefDeliveryMethodDomain>>();
            builder.RegisterType<InventoryBL._011_invRefItemsMasterListBL>().As<InventoryBL.I_011_invRefItemsMasterListBL<Models._011_invRefItemsMasterListDomain>>();
            builder.RegisterType<InventoryBL._012_invItemAttrivbuteBL>().As<InventoryBL.I_012_invItemAttributeBL<Models._012_invItemAttributeDomain>>();
            builder.RegisterType<InventoryBL._013_invNewItemEntryListBL>().As<InventoryBL.I_013_invNewItemEntryListBL<Models._013_invNewItemEntryListDomain>>();
            builder.RegisterType<InventoryBL._014_invRefItemImageBL>().As<InventoryBL.I_014_invRefItemImageBL<Models._014_invRefItemImageDomain>>();
            builder.RegisterType<InventoryBL._015_invRefItemPropListBL>().As<InventoryBL.I_015_invRefItemPropListBL<Models._015_invRefItemPropListDomain>>();
            builder.RegisterType<InventoryBL._017_invNewInfoDelMetAttrValueBL>().As<InventoryBL.I_017_invNewInfoDelMetAttrValueBL<Models._017_invNewInfoDelMetAttrValueDomain>>();
            builder.RegisterType<InventoryBL._018_invRefItemConditiontBL>().As<InventoryBL.I_018_invRefItemConditiontBL<Models._018_invRefItemConditionDomain>>();
            builder.RegisterType<InventoryBL._019_invReleasedItemHeaderBL>().As<InventoryBL.I_019_invReleasedItemHeaderBL<Models._019_invReleasedItemHeaderDomain>>();
            builder.RegisterType<InventoryBL._020_invReleasedItemDetailsBL>().As<InventoryBL.I_020_invReleasedItemDetailsBL<Models._020_invReleasedItemDetailsDomain>>();
            builder.RegisterType<InventoryBL._021_invTransMasterListBL>().As<InventoryBL.I_021_invTransMasterListBL<Models._021_invTransMasterListDomain>>();
            builder.RegisterType<InventoryBL._022_invTransInfoOriginBL>().As<InventoryBL.I_022_invTransInfoOriginBL<Models._022_invTransInfoOriginDomain>>();
            builder.RegisterType<InventoryBL._023_invTransInfoDestinationBL>().As<InventoryBL.I_023_invTransInfoDestinationBL<Models._023_invTransInfoDestinationDomain>>();
            builder.RegisterType<InventoryBL._024_invTransInfoDelMetAttrValueBL>().As<InventoryBL.I_024_invTransInfoDelMetAttrValueBL<Models._024_invTransInfoDelMetAttrValueDomain>>();
            builder.RegisterType<InventoryBL._025_invTransItemEntryListBL>().As<InventoryBL.I_025_invTransItemEntryListBL<Models._025_invTransItemEntryListDomain>>();
            builder.RegisterType<InventoryBL._026_invTransItemRecievedListBL>().As<InventoryBL.I_026_invTransItemRecievedListBL<Models._026_invTransItemReceivedListDomain>>();
            builder.RegisterType<InventoryBL._027_invWithdrawMasterListBL>().As<InventoryBL.I_027_invWithdrawMasterListBL<Models._027_invWithdrawMasterListDomain>>();
            builder.RegisterType<InventoryBL._028_invWithdrawItemEntryListBL>().As<InventoryBL.I_028_invWithdrawItemEntryListBL<Models._028_invWithdrawItemEntryListDomain>>();
            builder.RegisterType<InventoryBL._029_invRefFormListBL>().As<InventoryBL.I_029_invRefFormListBL<Models._029_invRefFormListDomain>>();
            builder.RegisterType<InventoryBL._030_invRefFormHardCopySeriesBL>().As<InventoryBL.I_030_invRefFormHardCopySeriesBL<Models._030_invRefFormHardCopySeriesDomain>>();
            builder.RegisterType<InventoryBL._031_invRefTransferListBL>().As<InventoryBL.I_031_invRefFormTransferListBL<Models._031_invRefFormTransferListDomain>>();
            builder.RegisterType<InventoryBL._032_LoginBL>().As<InventoryBL.I_032_LoginBL<Models._032_LoginDomain>>();
            builder.RegisterType<InventoryBL._033_invRefCategory3DefaultAttributeBL>().As<InventoryBL.I_033_invRefCategory3DefaultAttributeBL<Models._033_invRefCategory3DefaultAttributeDomain>>();

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