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
   public class alistadopasesporpaisyespectaculo : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "EspectaculoId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9EspectaculoId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
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

      public alistadopasesporpaisyespectaculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public alistadopasesporpaisyespectaculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EspectaculoId )
      {
         this.AV9EspectaculoId = aP0_EspectaculoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_EspectaculoId )
      {
         alistadopasesporpaisyespectaculo objalistadopasesporpaisyespectaculo;
         objalistadopasesporpaisyespectaculo = new alistadopasesporpaisyespectaculo();
         objalistadopasesporpaisyespectaculo.AV9EspectaculoId = aP0_EspectaculoId;
         objalistadopasesporpaisyespectaculo.context.SetSubmitInitialConfig(context);
         objalistadopasesporpaisyespectaculo.initialize();
         Submit( executePrivateCatch,objalistadopasesporpaisyespectaculo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alistadopasesporpaisyespectaculo)stateInfo).executePrivate();
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
         setOutputFileName("PasesPorPaisYEspectaculo.pdf");
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
            /* Using cursor P000R2 */
            pr_default.execute(0, new Object[] {AV9EspectaculoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A3LugarId = P000R2_A3LugarId[0];
               A1PaisId = P000R2_A1PaisId[0];
               A5EspectaculoId = P000R2_A5EspectaculoId[0];
               A40000EspectaculoAfiche_GXI = P000R2_A40000EspectaculoAfiche_GXI[0];
               A4LugarNombre = P000R2_A4LugarNombre[0];
               A19EspectaculoFecha = P000R2_A19EspectaculoFecha[0];
               A8EspectaculoNombre = P000R2_A8EspectaculoNombre[0];
               A2PaisNombre = P000R2_A2PaisNombre[0];
               A20EspectaculoAfiche = P000R2_A20EspectaculoAfiche[0];
               A1PaisId = P000R2_A1PaisId[0];
               A4LugarNombre = P000R2_A4LugarNombre[0];
               A2PaisNombre = P000R2_A2PaisNombre[0];
               H0R0( false, 238) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2PaisNombre, "")), 367, Gx_line+133, 560, Gx_line+157, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 16, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), 173, Gx_line+80, 733, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), 587, Gx_line+133, 687, Gx_line+157, 2, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : A20EspectaculoAfiche);
               getPrinter().GxDrawBitMap(sImgUrl, 53, Gx_line+80, 140, Gx_line+160) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 16, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Listado de pases de un espectáculo ordenados alfabéticamente ", 27, Gx_line+13, 807, Gx_line+53, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")), 173, Gx_line+133, 346, Gx_line+157, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+173, 813, Gx_line+173, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+67, 813, Gx_line+67, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Id Pase:", 120, Gx_line+187, 174, Gx_line+206, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de pase:", 247, Gx_line+187, 347, Gx_line+206, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre invitado:", 513, Gx_line+187, 720, Gx_line+206, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+227, 813, Gx_line+227, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+238);
               /* Using cursor P000R3 */
               pr_default.execute(1, new Object[] {A5EspectaculoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A14PaseTipo = P000R3_A14PaseTipo[0];
                  A13PaseId = P000R3_A13PaseId[0];
                  A34NombreInvitado = P000R3_A34NombreInvitado[0];
                  n34NombreInvitado = P000R3_n34NombreInvitado[0];
                  H0R0( false, 78) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A13PaseId), "ZZZ9")), 127, Gx_line+27, 166, Gx_line+49, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14PaseTipo, "")), 253, Gx_line+27, 400, Gx_line+49, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A34NombreInvitado, "")), 520, Gx_line+27, 718, Gx_line+49, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+78);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0R0( true, 0) ;
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

      protected void H0R0( bool bFoot ,
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
         P000R2_A3LugarId = new short[1] ;
         P000R2_A1PaisId = new short[1] ;
         P000R2_A5EspectaculoId = new short[1] ;
         P000R2_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         P000R2_A4LugarNombre = new string[] {""} ;
         P000R2_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000R2_A8EspectaculoNombre = new string[] {""} ;
         P000R2_A2PaisNombre = new string[] {""} ;
         P000R2_A20EspectaculoAfiche = new string[] {""} ;
         A40000EspectaculoAfiche_GXI = "";
         A4LugarNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         A8EspectaculoNombre = "";
         A2PaisNombre = "";
         A20EspectaculoAfiche = "";
         sImgUrl = "";
         P000R3_A5EspectaculoId = new short[1] ;
         P000R3_A14PaseTipo = new string[] {""} ;
         P000R3_A13PaseId = new short[1] ;
         P000R3_A34NombreInvitado = new string[] {""} ;
         P000R3_n34NombreInvitado = new bool[] {false} ;
         A14PaseTipo = "";
         A34NombreInvitado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistadopasesporpaisyespectaculo__default(),
            new Object[][] {
                new Object[] {
               P000R2_A3LugarId, P000R2_A1PaisId, P000R2_A5EspectaculoId, P000R2_A40000EspectaculoAfiche_GXI, P000R2_A4LugarNombre, P000R2_A19EspectaculoFecha, P000R2_A8EspectaculoNombre, P000R2_A2PaisNombre, P000R2_A20EspectaculoAfiche
               }
               , new Object[] {
               P000R3_A5EspectaculoId, P000R3_A14PaseTipo, P000R3_A13PaseId, P000R3_A34NombreInvitado, P000R3_n34NombreInvitado
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV9EspectaculoId ;
      private short GxWebError ;
      private short A3LugarId ;
      private short A1PaisId ;
      private short A5EspectaculoId ;
      private short A13PaseId ;
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
      private string A2PaisNombre ;
      private string sImgUrl ;
      private string A14PaseTipo ;
      private string A34NombreInvitado ;
      private DateTime A19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n34NombreInvitado ;
      private string A40000EspectaculoAfiche_GXI ;
      private string A20EspectaculoAfiche ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000R2_A3LugarId ;
      private short[] P000R2_A1PaisId ;
      private short[] P000R2_A5EspectaculoId ;
      private string[] P000R2_A40000EspectaculoAfiche_GXI ;
      private string[] P000R2_A4LugarNombre ;
      private DateTime[] P000R2_A19EspectaculoFecha ;
      private string[] P000R2_A8EspectaculoNombre ;
      private string[] P000R2_A2PaisNombre ;
      private string[] P000R2_A20EspectaculoAfiche ;
      private short[] P000R3_A5EspectaculoId ;
      private string[] P000R3_A14PaseTipo ;
      private short[] P000R3_A13PaseId ;
      private string[] P000R3_A34NombreInvitado ;
      private bool[] P000R3_n34NombreInvitado ;
   }

   public class alistadopasesporpaisyespectaculo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000R2;
          prmP000R2 = new Object[] {
          new ParDef("@AV9EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmP000R3;
          prmP000R3 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000R2", "SELECT T1.[LugarId], T2.[PaisId], T1.[EspectaculoId], T1.[EspectaculoAfiche_GXI], T2.[LugarNombre], T1.[EspectaculoFecha], T1.[EspectaculoNombre], T3.[PaisNombre], T1.[EspectaculoAfiche] FROM (([Espectaculo] T1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = T1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) WHERE T1.[EspectaculoId] = @AV9EspectaculoId ORDER BY T1.[EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000R2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000R3", "SELECT [EspectaculoId], [PaseTipo], [PaseId], [NombreInvitado] FROM [Pase] WHERE [EspectaculoId] = @EspectaculoId ORDER BY [NombreInvitado] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000R3,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 60);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
