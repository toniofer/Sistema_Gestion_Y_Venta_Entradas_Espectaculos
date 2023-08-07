using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class apais_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new apais_dataprovider().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         GXBCCollection<SdtPais> aP0_Gxm2rootcol = new GXBCCollection<SdtPais>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      public apais_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public apais_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtPais> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "ObligatorioFinal") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtPais> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtPais> aP0_Gxm2rootcol )
      {
         apais_dataprovider objapais_dataprovider;
         objapais_dataprovider = new apais_dataprovider();
         objapais_dataprovider.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "ObligatorioFinal") ;
         objapais_dataprovider.context.SetSubmitInitialConfig(context);
         objapais_dataprovider.initialize();
         Submit( executePrivateCatch,objapais_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apais_dataprovider)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Uruguay";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "f22417a9-5ea2-4532-970e-612922ce7390", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Brasil";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "8b718563-4aa1-454b-8c63-2ebe5d878c6f", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Argentina";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "3818ff92-3a25-477f-b1d3-9a9b61bd1990", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "México";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "b2151df5-36a0-4cfe-b0aa-d7768c6f5162", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Chile";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "e1aeaf5d-da39-468e-8ceb-54c76913b80f", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "España";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "5db48f68-639f-4d61-9f8f-518bcd4cdd0d", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Francia";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "b2abe805-a122-420a-a7c9-5e6a415e1662", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Italia";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "466e2e48-64d2-434f-b02a-8efa7d31c714", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Reino Unido";
         Gxm1pais.gxTpr_Paisbandera = context.convertURL( (string)(context.GetImagePath( "6c3cf213-1976-4a2f-9ea0-52863a1bb5ea", "", context.GetTheme( ))));
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Gxm1pais = new SdtPais(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtPais> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtPais> Gxm2rootcol ;
      private SdtPais Gxm1pais ;
   }

}
