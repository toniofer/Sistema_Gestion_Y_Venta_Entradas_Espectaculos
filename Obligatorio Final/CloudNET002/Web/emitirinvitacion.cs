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
   public class emitirinvitacion : GXProcedure
   {
      public emitirinvitacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public emitirinvitacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_InvitacionId )
      {
         this.AV2InvitacionId = aP0_InvitacionId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_InvitacionId )
      {
         emitirinvitacion objemitirinvitacion;
         objemitirinvitacion = new emitirinvitacion();
         objemitirinvitacion.AV2InvitacionId = aP0_InvitacionId;
         objemitirinvitacion.context.SetSubmitInitialConfig(context);
         objemitirinvitacion.initialize();
         Submit( executePrivateCatch,objemitirinvitacion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((emitirinvitacion)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2InvitacionId} ;
         ClassLoader.Execute("aemitirinvitacion","GeneXus.Programs","aemitirinvitacion", new Object[] {context }, "execute", args);
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

      private short AV2InvitacionId ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
