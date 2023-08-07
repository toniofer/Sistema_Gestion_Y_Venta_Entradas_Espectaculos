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
   public class listadoconciertosporfecha : GXProcedure
   {
      public listadoconciertosporfecha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public listadoconciertosporfecha( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FechaConcierto )
      {
         this.AV2FechaConcierto = aP0_FechaConcierto;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_FechaConcierto )
      {
         listadoconciertosporfecha objlistadoconciertosporfecha;
         objlistadoconciertosporfecha = new listadoconciertosporfecha();
         objlistadoconciertosporfecha.AV2FechaConcierto = aP0_FechaConcierto;
         objlistadoconciertosporfecha.context.SetSubmitInitialConfig(context);
         objlistadoconciertosporfecha.initialize();
         Submit( executePrivateCatch,objlistadoconciertosporfecha);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listadoconciertosporfecha)stateInfo).executePrivate();
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
         args = new Object[] {(DateTime)AV2FechaConcierto} ;
         ClassLoader.Execute("alistadoconciertosporfecha","GeneXus.Programs","alistadoconciertosporfecha", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private DateTime AV2FechaConcierto ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
