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
   public class aemitirinvitacion : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "InvitacionId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               A17InvitacionId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
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

      public aemitirinvitacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public aemitirinvitacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_InvitacionId )
      {
         this.A17InvitacionId = aP0_InvitacionId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_InvitacionId )
      {
         aemitirinvitacion objaemitirinvitacion;
         objaemitirinvitacion = new aemitirinvitacion();
         objaemitirinvitacion.A17InvitacionId = aP0_InvitacionId;
         objaemitirinvitacion.context.SetSubmitInitialConfig(context);
         objaemitirinvitacion.initialize();
         Submit( executePrivateCatch,objaemitirinvitacion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aemitirinvitacion)stateInfo).executePrivate();
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
         setOutputFileName("Invitacion.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 12125, 0, 1, 1, 0, 1, 1) )
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
            /* Using cursor P000H2 */
            pr_default.execute(0, new Object[] {A17InvitacionId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A5EspectaculoId = P000H2_A5EspectaculoId[0];
               A3LugarId = P000H2_A3LugarId[0];
               A40000EspectaculoAfiche_GXI = P000H2_A40000EspectaculoAfiche_GXI[0];
               A30InvitacionNombreInvitado = P000H2_A30InvitacionNombreInvitado[0];
               A8EspectaculoNombre = P000H2_A8EspectaculoNombre[0];
               A4LugarNombre = P000H2_A4LugarNombre[0];
               A18LugarDireccion = P000H2_A18LugarDireccion[0];
               A19EspectaculoFecha = P000H2_A19EspectaculoFecha[0];
               A20EspectaculoAfiche = P000H2_A20EspectaculoAfiche[0];
               A3LugarId = P000H2_A3LugarId[0];
               A40000EspectaculoAfiche_GXI = P000H2_A40000EspectaculoAfiche_GXI[0];
               A8EspectaculoNombre = P000H2_A8EspectaculoNombre[0];
               A19EspectaculoFecha = P000H2_A19EspectaculoFecha[0];
               A20EspectaculoAfiche = P000H2_A20EspectaculoAfiche[0];
               A4LugarNombre = P000H2_A4LugarNombre[0];
               A18LugarDireccion = P000H2_A18LugarDireccion[0];
               H0H0( false, 242) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nº invitacion:", 247, Gx_line+200, 340, Gx_line+214, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 407, Gx_line+120, 527, Gx_line+135, 2, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha de emisión:", 240, Gx_line+120, 331, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), 553, Gx_line+80, 673, Gx_line+93, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A18LugarDireccion, "")), 407, Gx_line+80, 540, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")), 240, Gx_line+80, 387, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), 240, Gx_line+27, 713, Gx_line+54, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : A20EspectaculoAfiche);
               getPrinter().GxDrawBitMap(sImgUrl, 13, Gx_line+27, 220, Gx_line+214) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A17InvitacionId), "ZZZ9")), 380, Gx_line+200, 480, Gx_line+215, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A30InvitacionNombreInvitado, "")), 407, Gx_line+160, 594, Gx_line+175, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre invitado:", 240, Gx_line+160, 324, Gx_line+174, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+242);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0H0( true, 0) ;
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

      protected void H0H0( bool bFoot ,
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
         P000H2_A5EspectaculoId = new short[1] ;
         P000H2_A3LugarId = new short[1] ;
         P000H2_A17InvitacionId = new short[1] ;
         P000H2_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         P000H2_A30InvitacionNombreInvitado = new string[] {""} ;
         P000H2_A8EspectaculoNombre = new string[] {""} ;
         P000H2_A4LugarNombre = new string[] {""} ;
         P000H2_A18LugarDireccion = new string[] {""} ;
         P000H2_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000H2_A20EspectaculoAfiche = new string[] {""} ;
         A40000EspectaculoAfiche_GXI = "";
         A30InvitacionNombreInvitado = "";
         A8EspectaculoNombre = "";
         A4LugarNombre = "";
         A18LugarDireccion = "";
         A19EspectaculoFecha = DateTime.MinValue;
         A20EspectaculoAfiche = "";
         Gx_date = DateTime.MinValue;
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemitirinvitacion__default(),
            new Object[][] {
                new Object[] {
               P000H2_A5EspectaculoId, P000H2_A3LugarId, P000H2_A17InvitacionId, P000H2_A40000EspectaculoAfiche_GXI, P000H2_A30InvitacionNombreInvitado, P000H2_A8EspectaculoNombre, P000H2_A4LugarNombre, P000H2_A18LugarDireccion, P000H2_A19EspectaculoFecha, P000H2_A20EspectaculoAfiche
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
      private short A17InvitacionId ;
      private short GxWebError ;
      private short A5EspectaculoId ;
      private short A3LugarId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A30InvitacionNombreInvitado ;
      private string A8EspectaculoNombre ;
      private string A4LugarNombre ;
      private string A18LugarDireccion ;
      private string sImgUrl ;
      private DateTime A19EspectaculoFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40000EspectaculoAfiche_GXI ;
      private string A20EspectaculoAfiche ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000H2_A5EspectaculoId ;
      private short[] P000H2_A3LugarId ;
      private short[] P000H2_A17InvitacionId ;
      private string[] P000H2_A40000EspectaculoAfiche_GXI ;
      private string[] P000H2_A30InvitacionNombreInvitado ;
      private string[] P000H2_A8EspectaculoNombre ;
      private string[] P000H2_A4LugarNombre ;
      private string[] P000H2_A18LugarDireccion ;
      private DateTime[] P000H2_A19EspectaculoFecha ;
      private string[] P000H2_A20EspectaculoAfiche ;
   }

   public class aemitirinvitacion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT T1.[EspectaculoId], T2.[LugarId], T1.[InvitacionId], T2.[EspectaculoAfiche_GXI], T1.[InvitacionNombreInvitado], T2.[EspectaculoNombre], T3.[LugarNombre], T3.[LugarDireccion], T2.[EspectaculoFecha], T2.[EspectaculoAfiche] FROM (([Invitacion] T1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = T1.[EspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T2.[LugarId]) WHERE T1.[InvitacionId] = @InvitacionId ORDER BY T1.[InvitacionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 60);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 40);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
                return;
       }
    }

 }

}
