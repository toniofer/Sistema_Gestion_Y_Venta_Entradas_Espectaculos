using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aemitirticket : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "EntradaId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               A11EntradaId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public aemitirticket( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public aemitirticket( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EntradaId )
      {
         this.A11EntradaId = aP0_EntradaId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_EntradaId )
      {
         aemitirticket objaemitirticket;
         objaemitirticket = new aemitirticket();
         objaemitirticket.A11EntradaId = aP0_EntradaId;
         objaemitirticket.context.SetSubmitInitialConfig(context);
         objaemitirticket.initialize();
         Submit( executePrivateCatch,objaemitirticket);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aemitirticket)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("Entrada.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            /* Using cursor P000G2 */
            pr_default.execute(0, new Object[] {A11EntradaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A5EspectaculoId = P000G2_A5EspectaculoId[0];
               A3LugarId = P000G2_A3LugarId[0];
               A9SectorId = P000G2_A9SectorId[0];
               A40000EspectaculoAfiche_GXI = P000G2_A40000EspectaculoAfiche_GXI[0];
               A23SectorPrecio = P000G2_A23SectorPrecio[0];
               A21SectorNombre = P000G2_A21SectorNombre[0];
               A18LugarDireccion = P000G2_A18LugarDireccion[0];
               A4LugarNombre = P000G2_A4LugarNombre[0];
               A19EspectaculoFecha = P000G2_A19EspectaculoFecha[0];
               A8EspectaculoNombre = P000G2_A8EspectaculoNombre[0];
               A20EspectaculoAfiche = P000G2_A20EspectaculoAfiche[0];
               A3LugarId = P000G2_A3LugarId[0];
               A40000EspectaculoAfiche_GXI = P000G2_A40000EspectaculoAfiche_GXI[0];
               A19EspectaculoFecha = P000G2_A19EspectaculoFecha[0];
               A8EspectaculoNombre = P000G2_A8EspectaculoNombre[0];
               A20EspectaculoAfiche = P000G2_A20EspectaculoAfiche[0];
               A18LugarDireccion = P000G2_A18LugarDireccion[0];
               A4LugarNombre = P000G2_A4LugarNombre[0];
               A23SectorPrecio = P000G2_A23SectorPrecio[0];
               A21SectorNombre = P000G2_A21SectorNombre[0];
               H0G0( false, 298) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), 260, Gx_line+13, 886, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), 573, Gx_line+67, 693, Gx_line+80, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")), 260, Gx_line+67, 407, Gx_line+82, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A18LugarDireccion, "")), 427, Gx_line+67, 560, Gx_line+82, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : A20EspectaculoAfiche);
               getPrinter().GxDrawBitMap(sImgUrl, 27, Gx_line+13, 234, Gx_line+200) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 387, Gx_line+147, 507, Gx_line+162, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A21SectorNombre, "")), 327, Gx_line+107, 467, Gx_line+122, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9")), 600, Gx_line+107, 693, Gx_line+122, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A11EntradaId), "ZZZ9")), 340, Gx_line+187, 440, Gx_line+202, 2, 0, 0, 0) ;
               getPrinter().GxDrawText("Nº entrada:", 260, Gx_line+187, 317, Gx_line+201, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha de emisión:", 260, Gx_line+147, 351, Gx_line+161, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Sector:", 260, Gx_line+107, 320, Gx_line+121, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio:", 513, Gx_line+107, 566, Gx_line+121, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+298);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0G0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0G0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000G2_A5EspectaculoId = new short[1] ;
         P000G2_A3LugarId = new short[1] ;
         P000G2_A9SectorId = new short[1] ;
         P000G2_A11EntradaId = new short[1] ;
         P000G2_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         P000G2_A23SectorPrecio = new int[1] ;
         P000G2_A21SectorNombre = new string[] {""} ;
         P000G2_A18LugarDireccion = new string[] {""} ;
         P000G2_A4LugarNombre = new string[] {""} ;
         P000G2_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000G2_A8EspectaculoNombre = new string[] {""} ;
         P000G2_A20EspectaculoAfiche = new string[] {""} ;
         A40000EspectaculoAfiche_GXI = "";
         A21SectorNombre = "";
         A18LugarDireccion = "";
         A4LugarNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         A8EspectaculoNombre = "";
         A20EspectaculoAfiche = "";
         sImgUrl = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemitirticket__default(),
            new Object[][] {
                new Object[] {
               P000G2_A5EspectaculoId, P000G2_A3LugarId, P000G2_A9SectorId, P000G2_A11EntradaId, P000G2_A40000EspectaculoAfiche_GXI, P000G2_A23SectorPrecio, P000G2_A21SectorNombre, P000G2_A18LugarDireccion, P000G2_A4LugarNombre, P000G2_A19EspectaculoFecha,
               P000G2_A8EspectaculoNombre, P000G2_A20EspectaculoAfiche
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short A11EntradaId ;
      private short GxWebError ;
      private short A5EspectaculoId ;
      private short A3LugarId ;
      private short A9SectorId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A23SectorPrecio ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A21SectorNombre ;
      private string A18LugarDireccion ;
      private string A4LugarNombre ;
      private string A8EspectaculoNombre ;
      private string sImgUrl ;
      private DateTime A19EspectaculoFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40000EspectaculoAfiche_GXI ;
      private string A20EspectaculoAfiche ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_A5EspectaculoId ;
      private short[] P000G2_A3LugarId ;
      private short[] P000G2_A9SectorId ;
      private short[] P000G2_A11EntradaId ;
      private string[] P000G2_A40000EspectaculoAfiche_GXI ;
      private int[] P000G2_A23SectorPrecio ;
      private string[] P000G2_A21SectorNombre ;
      private string[] P000G2_A18LugarDireccion ;
      private string[] P000G2_A4LugarNombre ;
      private DateTime[] P000G2_A19EspectaculoFecha ;
      private string[] P000G2_A8EspectaculoNombre ;
      private string[] P000G2_A20EspectaculoAfiche ;
   }

   public class aemitirticket__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT T1.[EspectaculoId], T2.[LugarId], T1.[SectorId], T1.[EntradaId], T2.[EspectaculoAfiche_GXI], T4.[SectorPrecio], T4.[SectorNombre], T3.[LugarDireccion], T3.[LugarNombre], T2.[EspectaculoFecha], T2.[EspectaculoNombre], T2.[EspectaculoAfiche] FROM ((([Entrada] T1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = T1.[EspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T2.[LugarId]) INNER JOIN [EspectaculoSector] T4 ON T4.[EspectaculoId] = T1.[EspectaculoId] AND T4.[SectorId] = T1.[SectorId]) WHERE T1.[EntradaId] = @EntradaId ORDER BY T1.[EntradaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 40);
                ((string[]) buf[8])[0] = rslt.getString(9, 60);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 60);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(5));
                return;
       }
    }

 }

}
