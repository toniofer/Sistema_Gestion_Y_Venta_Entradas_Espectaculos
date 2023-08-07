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
   public class alistadoespectaculosportipo : GXWebProcedure
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
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
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

      public alistadoespectaculosportipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public alistadoespectaculosportipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         alistadoespectaculosportipo objalistadoespectaculosportipo;
         objalistadoespectaculosportipo = new alistadoespectaculosportipo();
         objalistadoespectaculosportipo.context.SetSubmitInitialConfig(context);
         objalistadoespectaculosportipo.initialize();
         Submit( executePrivateCatch,objalistadoespectaculosportipo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alistadoespectaculosportipo)stateInfo).executePrivate();
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
         setOutputFileName("EspectaculosPorTipo.pdf");
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
            H0F0( false, 100) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("LISTADO DE ESPECT�CULOS POR TIPO", 127, Gx_line+13, 734, Gx_line+66, 1, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+100);
            /* Using cursor P000F2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A6TipoEspectaculoId = P000F2_A6TipoEspectaculoId[0];
               A16TipoEspectaculoNombre = P000F2_A16TipoEspectaculoNombre[0];
               H0F0( false, 60) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16TipoEspectaculoNombre, "")), 33, Gx_line+15, 534, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+4, 827, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+56, 827, Gx_line+56, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+60);
               /* Using cursor P000F3 */
               pr_default.execute(1, new Object[] {A6TipoEspectaculoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A3LugarId = P000F3_A3LugarId[0];
                  A1PaisId = P000F3_A1PaisId[0];
                  A40000EspectaculoAfiche_GXI = P000F3_A40000EspectaculoAfiche_GXI[0];
                  A2PaisNombre = P000F3_A2PaisNombre[0];
                  A4LugarNombre = P000F3_A4LugarNombre[0];
                  A19EspectaculoFecha = P000F3_A19EspectaculoFecha[0];
                  A8EspectaculoNombre = P000F3_A8EspectaculoNombre[0];
                  A5EspectaculoId = P000F3_A5EspectaculoId[0];
                  A20EspectaculoAfiche = P000F3_A20EspectaculoAfiche[0];
                  A1PaisId = P000F3_A1PaisId[0];
                  A4LugarNombre = P000F3_A4LugarNombre[0];
                  A2PaisNombre = P000F3_A2PaisNombre[0];
                  H0F0( false, 100) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : A20EspectaculoAfiche);
                  getPrinter().GxDrawBitMap(sImgUrl, 33, Gx_line+10, 113, Gx_line+90) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), 147, Gx_line+27, 354, Gx_line+46, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), 373, Gx_line+27, 440, Gx_line+46, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")), 460, Gx_line+27, 627, Gx_line+46, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2PaisNombre, "")), 640, Gx_line+27, 761, Gx_line+45, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
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

      protected void H0F0( bool bFoot ,
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
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         P000F2_A6TipoEspectaculoId = new short[1] ;
         P000F2_A16TipoEspectaculoNombre = new string[] {""} ;
         A16TipoEspectaculoNombre = "";
         P000F3_A3LugarId = new short[1] ;
         P000F3_A1PaisId = new short[1] ;
         P000F3_A6TipoEspectaculoId = new short[1] ;
         P000F3_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         P000F3_A2PaisNombre = new string[] {""} ;
         P000F3_A4LugarNombre = new string[] {""} ;
         P000F3_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000F3_A8EspectaculoNombre = new string[] {""} ;
         P000F3_A5EspectaculoId = new short[1] ;
         P000F3_A20EspectaculoAfiche = new string[] {""} ;
         A40000EspectaculoAfiche_GXI = "";
         A2PaisNombre = "";
         A4LugarNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         A8EspectaculoNombre = "";
         A20EspectaculoAfiche = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistadoespectaculosportipo__default(),
            new Object[][] {
                new Object[] {
               P000F2_A6TipoEspectaculoId, P000F2_A16TipoEspectaculoNombre
               }
               , new Object[] {
               P000F3_A3LugarId, P000F3_A1PaisId, P000F3_A6TipoEspectaculoId, P000F3_A40000EspectaculoAfiche_GXI, P000F3_A2PaisNombre, P000F3_A4LugarNombre, P000F3_A19EspectaculoFecha, P000F3_A8EspectaculoNombre, P000F3_A5EspectaculoId, P000F3_A20EspectaculoAfiche
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A6TipoEspectaculoId ;
      private short A3LugarId ;
      private short A1PaisId ;
      private short A5EspectaculoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A16TipoEspectaculoNombre ;
      private string A2PaisNombre ;
      private string A4LugarNombre ;
      private string A8EspectaculoNombre ;
      private string sImgUrl ;
      private DateTime A19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40000EspectaculoAfiche_GXI ;
      private string A20EspectaculoAfiche ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000F2_A6TipoEspectaculoId ;
      private string[] P000F2_A16TipoEspectaculoNombre ;
      private short[] P000F3_A3LugarId ;
      private short[] P000F3_A1PaisId ;
      private short[] P000F3_A6TipoEspectaculoId ;
      private string[] P000F3_A40000EspectaculoAfiche_GXI ;
      private string[] P000F3_A2PaisNombre ;
      private string[] P000F3_A4LugarNombre ;
      private DateTime[] P000F3_A19EspectaculoFecha ;
      private string[] P000F3_A8EspectaculoNombre ;
      private short[] P000F3_A5EspectaculoId ;
      private string[] P000F3_A20EspectaculoAfiche ;
   }

   public class alistadoespectaculosportipo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F2;
          prmP000F2 = new Object[] {
          };
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F2", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] ORDER BY [TipoEspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000F3", "SELECT T1.[LugarId], T2.[PaisId], T1.[TipoEspectaculoId], T1.[EspectaculoAfiche_GXI], T3.[PaisNombre], T2.[LugarNombre], T1.[EspectaculoFecha], T1.[EspectaculoNombre], T1.[EspectaculoId], T1.[EspectaculoAfiche] FROM (([Espectaculo] T1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = T1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) WHERE T1.[TipoEspectaculoId] = @TipoEspectaculoId ORDER BY T1.[TipoEspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 60);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 60);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
                return;
       }
    }

 }

}
