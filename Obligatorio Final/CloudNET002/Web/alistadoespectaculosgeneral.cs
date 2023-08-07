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
   public class alistadoespectaculosgeneral : GXWebProcedure
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

      public alistadoespectaculosgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public alistadoespectaculosgeneral( IGxContext context )
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
         alistadoespectaculosgeneral objalistadoespectaculosgeneral;
         objalistadoespectaculosgeneral = new alistadoespectaculosgeneral();
         objalistadoespectaculosgeneral.context.SetSubmitInitialConfig(context);
         objalistadoespectaculosgeneral.initialize();
         Submit( executePrivateCatch,objalistadoespectaculosgeneral);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alistadoespectaculosgeneral)stateInfo).executePrivate();
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
         setOutputFileName("ListadoEspectaculosGeneral.pdf");
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
            H0N0( false, 80) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("LISTADO DE ESPECTÁCULOS GENERAL", 153, Gx_line+13, 753, Gx_line+53, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+80);
            /* Using cursor P000N2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A3LugarId = P000N2_A3LugarId[0];
               A5EspectaculoId = P000N2_A5EspectaculoId[0];
               A40000EspectaculoAfiche_GXI = P000N2_A40000EspectaculoAfiche_GXI[0];
               A4LugarNombre = P000N2_A4LugarNombre[0];
               A19EspectaculoFecha = P000N2_A19EspectaculoFecha[0];
               A8EspectaculoNombre = P000N2_A8EspectaculoNombre[0];
               A20EspectaculoAfiche = P000N2_A20EspectaculoAfiche[0];
               A4LugarNombre = P000N2_A4LugarNombre[0];
               H0N0( false, 108) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 16, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), 127, Gx_line+13, 360, Gx_line+40, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : A20EspectaculoAfiche);
               getPrinter().GxDrawBitMap(sImgUrl, 20, Gx_line+13, 107, Gx_line+93) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), 447, Gx_line+13, 554, Gx_line+35, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")), 620, Gx_line+13, 753, Gx_line+35, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+107, 833, Gx_line+107, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+0, 833, Gx_line+0, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+108);
               /* Using cursor P000N4 */
               pr_default.execute(1, new Object[] {A5EspectaculoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A9SectorId = P000N4_A9SectorId[0];
                  A23SectorPrecio = P000N4_A23SectorPrecio[0];
                  A21SectorNombre = P000N4_A21SectorNombre[0];
                  A25SectorEntradasVendidas = P000N4_A25SectorEntradasVendidas[0];
                  n25SectorEntradasVendidas = P000N4_n25SectorEntradasVendidas[0];
                  A22SectorCapacidad = P000N4_A22SectorCapacidad[0];
                  A25SectorEntradasVendidas = P000N4_A25SectorEntradasVendidas[0];
                  n25SectorEntradasVendidas = P000N4_n25SectorEntradasVendidas[0];
                  A24SectorEntradasDisponibles = (int)(A22SectorCapacidad-A25SectorEntradasVendidas);
                  H0N0( false, 50) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A21SectorNombre, "")), 40, Gx_line+13, 187, Gx_line+32, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9")), 273, Gx_line+13, 360, Gx_line+32, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A24SectorEntradasDisponibles), "ZZZZ9")), 573, Gx_line+13, 740, Gx_line+32, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("Entradas disponibles:", 413, Gx_line+13, 566, Gx_line+31, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Precio:", 220, Gx_line+13, 255, Gx_line+27, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+50);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0N0( true, 0) ;
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

      protected void H0N0( bool bFoot ,
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
         P000N2_A3LugarId = new short[1] ;
         P000N2_A5EspectaculoId = new short[1] ;
         P000N2_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         P000N2_A4LugarNombre = new string[] {""} ;
         P000N2_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000N2_A8EspectaculoNombre = new string[] {""} ;
         P000N2_A20EspectaculoAfiche = new string[] {""} ;
         A40000EspectaculoAfiche_GXI = "";
         A4LugarNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         A8EspectaculoNombre = "";
         A20EspectaculoAfiche = "";
         sImgUrl = "";
         P000N4_A9SectorId = new short[1] ;
         P000N4_A5EspectaculoId = new short[1] ;
         P000N4_A23SectorPrecio = new int[1] ;
         P000N4_A21SectorNombre = new string[] {""} ;
         P000N4_A25SectorEntradasVendidas = new int[1] ;
         P000N4_n25SectorEntradasVendidas = new bool[] {false} ;
         P000N4_A22SectorCapacidad = new int[1] ;
         A21SectorNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistadoespectaculosgeneral__default(),
            new Object[][] {
                new Object[] {
               P000N2_A3LugarId, P000N2_A5EspectaculoId, P000N2_A40000EspectaculoAfiche_GXI, P000N2_A4LugarNombre, P000N2_A19EspectaculoFecha, P000N2_A8EspectaculoNombre, P000N2_A20EspectaculoAfiche
               }
               , new Object[] {
               P000N4_A9SectorId, P000N4_A5EspectaculoId, P000N4_A23SectorPrecio, P000N4_A21SectorNombre, P000N4_A25SectorEntradasVendidas, P000N4_n25SectorEntradasVendidas, P000N4_A22SectorCapacidad
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
      private short A5EspectaculoId ;
      private short A9SectorId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A23SectorPrecio ;
      private int A25SectorEntradasVendidas ;
      private int A22SectorCapacidad ;
      private int A24SectorEntradasDisponibles ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A4LugarNombre ;
      private string A8EspectaculoNombre ;
      private string sImgUrl ;
      private string A21SectorNombre ;
      private DateTime A19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n25SectorEntradasVendidas ;
      private string A40000EspectaculoAfiche_GXI ;
      private string A20EspectaculoAfiche ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000N2_A3LugarId ;
      private short[] P000N2_A5EspectaculoId ;
      private string[] P000N2_A40000EspectaculoAfiche_GXI ;
      private string[] P000N2_A4LugarNombre ;
      private DateTime[] P000N2_A19EspectaculoFecha ;
      private string[] P000N2_A8EspectaculoNombre ;
      private string[] P000N2_A20EspectaculoAfiche ;
      private short[] P000N4_A9SectorId ;
      private short[] P000N4_A5EspectaculoId ;
      private int[] P000N4_A23SectorPrecio ;
      private string[] P000N4_A21SectorNombre ;
      private int[] P000N4_A25SectorEntradasVendidas ;
      private bool[] P000N4_n25SectorEntradasVendidas ;
      private int[] P000N4_A22SectorCapacidad ;
   }

   public class alistadoespectaculosgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000N2;
          prmP000N2 = new Object[] {
          };
          Object[] prmP000N4;
          prmP000N4 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000N2", "SELECT T1.[LugarId], T1.[EspectaculoId], T1.[EspectaculoAfiche_GXI], T2.[LugarNombre], T1.[EspectaculoFecha], T1.[EspectaculoNombre], T1.[EspectaculoAfiche] FROM ([Espectaculo] T1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = T1.[LugarId]) ORDER BY T1.[EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000N4", "SELECT T1.[SectorId], T1.[EspectaculoId], T1.[SectorPrecio], T1.[SectorNombre], COALESCE( T2.[SectorEntradasVendidas], 0) AS SectorEntradasVendidas, T1.[SectorCapacidad] FROM ([EspectaculoSector] T1 LEFT JOIN (SELECT COUNT(*) AS SectorEntradasVendidas, [EspectaculoId], [SectorId] FROM [Entrada] GROUP BY [EspectaculoId], [SectorId] ) T2 ON T2.[EspectaculoId] = T1.[EspectaculoId] AND T2.[SectorId] = T1.[SectorId]) WHERE T1.[EspectaculoId] = @EspectaculoId ORDER BY T1.[EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000N4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
