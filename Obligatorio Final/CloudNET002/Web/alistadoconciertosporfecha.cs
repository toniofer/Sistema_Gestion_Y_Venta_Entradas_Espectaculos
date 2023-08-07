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
   public class alistadoconciertosporfecha : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "FechaConcierto");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8FechaConcierto = context.localUtil.ParseDateParm( gxfirstwebparm);
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

      public alistadoconciertosporfecha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public alistadoconciertosporfecha( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FechaConcierto )
      {
         this.AV8FechaConcierto = aP0_FechaConcierto;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_FechaConcierto )
      {
         alistadoconciertosporfecha objalistadoconciertosporfecha;
         objalistadoconciertosporfecha = new alistadoconciertosporfecha();
         objalistadoconciertosporfecha.AV8FechaConcierto = aP0_FechaConcierto;
         objalistadoconciertosporfecha.context.SetSubmitInitialConfig(context);
         objalistadoconciertosporfecha.initialize();
         Submit( executePrivateCatch,objalistadoconciertosporfecha);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alistadoconciertosporfecha)stateInfo).executePrivate();
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
         setOutputFileName("ConciertosPorFecha.pdf");
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
            H0O0( false, 100) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("LISTADO DE CONCIERTOS EN FECHA:", 160, Gx_line+27, 467, Gx_line+48, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV8FechaConcierto, "99/99/99"), 493, Gx_line+27, 559, Gx_line+49, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+100);
            /* Using cursor P000O2 */
            pr_default.execute(0, new Object[] {AV8FechaConcierto});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A3LugarId = P000O2_A3LugarId[0];
               A19EspectaculoFecha = P000O2_A19EspectaculoFecha[0];
               A6TipoEspectaculoId = P000O2_A6TipoEspectaculoId[0];
               A40000EspectaculoAfiche_GXI = P000O2_A40000EspectaculoAfiche_GXI[0];
               A4LugarNombre = P000O2_A4LugarNombre[0];
               A8EspectaculoNombre = P000O2_A8EspectaculoNombre[0];
               A5EspectaculoId = P000O2_A5EspectaculoId[0];
               A20EspectaculoAfiche = P000O2_A20EspectaculoAfiche[0];
               A4LugarNombre = P000O2_A4LugarNombre[0];
               H0O0( false, 70) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : A20EspectaculoAfiche);
               getPrinter().GxDrawBitMap(sImgUrl, 67, Gx_line+13, 134, Gx_line+53) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), 187, Gx_line+27, 563, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")), 453, Gx_line+27, 829, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+0, 820, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+67, 833, Gx_line+67, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+70);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0O0( true, 0) ;
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

      protected void H0O0( bool bFoot ,
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
      }

      protected void add_metrics0( )
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
         P000O2_A3LugarId = new short[1] ;
         P000O2_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000O2_A6TipoEspectaculoId = new short[1] ;
         P000O2_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         P000O2_A4LugarNombre = new string[] {""} ;
         P000O2_A8EspectaculoNombre = new string[] {""} ;
         P000O2_A5EspectaculoId = new short[1] ;
         P000O2_A20EspectaculoAfiche = new string[] {""} ;
         A19EspectaculoFecha = DateTime.MinValue;
         A40000EspectaculoAfiche_GXI = "";
         A4LugarNombre = "";
         A8EspectaculoNombre = "";
         A20EspectaculoAfiche = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistadoconciertosporfecha__default(),
            new Object[][] {
                new Object[] {
               P000O2_A3LugarId, P000O2_A19EspectaculoFecha, P000O2_A6TipoEspectaculoId, P000O2_A40000EspectaculoAfiche_GXI, P000O2_A4LugarNombre, P000O2_A8EspectaculoNombre, P000O2_A5EspectaculoId, P000O2_A20EspectaculoAfiche
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
      private short A3LugarId ;
      private short A6TipoEspectaculoId ;
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
      private string A4LugarNombre ;
      private string A8EspectaculoNombre ;
      private string sImgUrl ;
      private DateTime AV8FechaConcierto ;
      private DateTime A19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40000EspectaculoAfiche_GXI ;
      private string A20EspectaculoAfiche ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000O2_A3LugarId ;
      private DateTime[] P000O2_A19EspectaculoFecha ;
      private short[] P000O2_A6TipoEspectaculoId ;
      private string[] P000O2_A40000EspectaculoAfiche_GXI ;
      private string[] P000O2_A4LugarNombre ;
      private string[] P000O2_A8EspectaculoNombre ;
      private short[] P000O2_A5EspectaculoId ;
      private string[] P000O2_A20EspectaculoAfiche ;
   }

   public class alistadoconciertosporfecha__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000O2;
          prmP000O2 = new Object[] {
          new ParDef("@AV8FechaConcierto",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000O2", "SELECT T1.[LugarId], T1.[EspectaculoFecha], T1.[TipoEspectaculoId], T1.[EspectaculoAfiche_GXI], T2.[LugarNombre], T1.[EspectaculoNombre], T1.[EspectaculoId], T1.[EspectaculoAfiche] FROM ([Espectaculo] T1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = T1.[LugarId]) WHERE (T1.[TipoEspectaculoId] = 2) AND (T1.[EspectaculoFecha] = @AV8FechaConcierto) ORDER BY T1.[TipoEspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000O2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 60);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
                return;
       }
    }

 }

}
