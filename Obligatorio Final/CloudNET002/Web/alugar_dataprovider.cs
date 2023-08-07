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
   public class alugar_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new alugar_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<SdtLugar> aP0_Gxm2rootcol = new GXBCCollection<SdtLugar>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      public alugar_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public alugar_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtLugar> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtLugar>( context, "Lugar", "ObligatorioFinal") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtLugar> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtLugar> aP0_Gxm2rootcol )
      {
         alugar_dataprovider objalugar_dataprovider;
         objalugar_dataprovider = new alugar_dataprovider();
         objalugar_dataprovider.Gxm2rootcol = new GXBCCollection<SdtLugar>( context, "Lugar", "ObligatorioFinal") ;
         objalugar_dataprovider.context.SetSubmitInitialConfig(context);
         objalugar_dataprovider.initialize();
         Submit( executePrivateCatch,objalugar_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alugar_dataprovider)stateInfo).executePrivate();
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
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Estadio Centenario";
         Gxm1lugar.gxTpr_Paisid = 1;
         Gxm1lugar.gxTpr_Lugardireccion = "Av. Ricaldoni s/n";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "706d6e66-23a6-4f05-bd57-9a58915e2044", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Estadio Nacional de Chile";
         Gxm1lugar.gxTpr_Paisid = 5;
         Gxm1lugar.gxTpr_Lugardireccion = "Av. Richeti s/n";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "f7045811-d9e9-41f4-9c71-a3c15de91608", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Sodre";
         Gxm1lugar.gxTpr_Paisid = 1;
         Gxm1lugar.gxTpr_Lugardireccion = "18 de Julio 1124";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "f2fafff9-d779-4c09-8b70-c7c695461848", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Luna Park";
         Gxm1lugar.gxTpr_Paisid = 3;
         Gxm1lugar.gxTpr_Lugardireccion = "Av. Pueyredón 3215";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "d4b21dab-399b-4393-adc2-fcac72a3b59d", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Teatro Solis";
         Gxm1lugar.gxTpr_Paisid = 1;
         Gxm1lugar.gxTpr_Lugardireccion = "Buenos Aires 842";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "7d0ed2e4-320f-4371-ad3e-dd1cdb3d850c", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Teatro Colón";
         Gxm1lugar.gxTpr_Paisid = 3;
         Gxm1lugar.gxTpr_Lugardireccion = "Av. Corrientes 8455";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "70da7154-2c3e-4d34-95da-06a63af63fdc", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Auditorio Nacional de México";
         Gxm1lugar.gxTpr_Paisid = 4;
         Gxm1lugar.gxTpr_Lugardireccion = "Av. Sánchez Pijuán 5546";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "1175da88-0768-4c96-988f-a745b31b81d1", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Teatro Sao Pedro";
         Gxm1lugar.gxTpr_Paisid = 2;
         Gxm1lugar.gxTpr_Lugardireccion = "Av. Cuitiño 45644";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "1aebada8-1ea9-470c-9e6a-aeb9d2a9bb2b", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Municipal de Santiago";
         Gxm1lugar.gxTpr_Paisid = 5;
         Gxm1lugar.gxTpr_Lugardireccion = "Av. San José 4655";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "f417cea3-4085-46ae-b38f-b392fe6fa55d", "", context.GetTheme( ))));
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Antel Arena";
         Gxm1lugar.gxTpr_Paisid = 1;
         Gxm1lugar.gxTpr_Lugardireccion = "Av. Centenario 4566";
         Gxm1lugar.gxTpr_Lugarfoto = context.convertURL( (string)(context.GetImagePath( "56d6d1eb-c2fa-4d0d-ba8d-50f54c2ad7d4", "", context.GetTheme( ))));
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
         Gxm1lugar = new SdtLugar(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtLugar> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtLugar> Gxm2rootcol ;
      private SdtLugar Gxm1lugar ;
   }

}
