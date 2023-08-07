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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aumentarentradas : GXProcedure
   {
      public aumentarentradas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public aumentarentradas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EspectaculoId ,
                           short aP1_SectorId ,
                           short aP2_PorcentajeAumento )
      {
         this.AV8EspectaculoId = aP0_EspectaculoId;
         this.AV10SectorId = aP1_SectorId;
         this.AV9PorcentajeAumento = aP2_PorcentajeAumento;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_EspectaculoId ,
                                 short aP1_SectorId ,
                                 short aP2_PorcentajeAumento )
      {
         aumentarentradas objaumentarentradas;
         objaumentarentradas = new aumentarentradas();
         objaumentarentradas.AV8EspectaculoId = aP0_EspectaculoId;
         objaumentarentradas.AV10SectorId = aP1_SectorId;
         objaumentarentradas.AV9PorcentajeAumento = aP2_PorcentajeAumento;
         objaumentarentradas.context.SetSubmitInitialConfig(context);
         objaumentarentradas.initialize();
         Submit( executePrivateCatch,objaumentarentradas);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aumentarentradas)stateInfo).executePrivate();
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
         /* Using cursor P000P2 */
         pr_default.execute(0, new Object[] {AV8EspectaculoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5EspectaculoId = P000P2_A5EspectaculoId[0];
            if ( ! (0==AV10SectorId) )
            {
               /* Optimized UPDATE. */
               /* Using cursor P000P3 */
               pr_default.execute(1, new Object[] {AV9PorcentajeAumento, A5EspectaculoId, AV10SectorId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("EspectaculoSector");
               /* End optimized UPDATE. */
            }
            else
            {
               /* Optimized UPDATE. */
               /* Using cursor P000P4 */
               pr_default.execute(2, new Object[] {AV9PorcentajeAumento, A5EspectaculoId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("EspectaculoSector");
               /* End optimized UPDATE. */
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aumentarentradas",pr_default);
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
         scmdbuf = "";
         P000P2_A5EspectaculoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aumentarentradas__default(),
            new Object[][] {
                new Object[] {
               P000P2_A5EspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8EspectaculoId ;
      private short AV10SectorId ;
      private short AV9PorcentajeAumento ;
      private short A5EspectaculoId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000P2_A5EspectaculoId ;
   }

   public class aumentarentradas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000P2;
          prmP000P2 = new Object[] {
          new ParDef("@AV8EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmP000P3;
          prmP000P3 = new Object[] {
          new ParDef("@AV9PorcentajeAumento",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@AV10SectorId",GXType.Int16,4,0)
          };
          Object[] prmP000P4;
          prmP000P4 = new Object[] {
          new ParDef("@AV9PorcentajeAumento",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000P2", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE ([EspectaculoId] = @AV8EspectaculoId) AND (Not (@AV8EspectaculoId = convert(int, 0))) ORDER BY [EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000P2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000P3", "UPDATE [EspectaculoSector] SET [SectorPrecio]=[SectorPrecio] * CAST(( 1 + CAST(@AV9PorcentajeAumento AS decimal( 14, 10)) / 100) AS decimal( 16, 10))  WHERE [EspectaculoId] = @EspectaculoId and [SectorId] = @AV10SectorId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000P3)
             ,new CursorDef("P000P4", "UPDATE [EspectaculoSector] SET [SectorPrecio]=[SectorPrecio] * CAST(( 1 + CAST(@AV9PorcentajeAumento AS decimal( 14, 10)) / 100) AS decimal( 16, 10))  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000P4)
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
                return;
       }
    }

 }

}
