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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class invitacion_bc : GxSilentTrn, IGxSilentTrn
   {
      public invitacion_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public invitacion_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow079( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey079( ) ;
         standaloneModal( ) ;
         AddRow079( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z17InvitacionId = A17InvitacionId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_070( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls079( ) ;
            }
            else
            {
               CheckExtendedTable079( ) ;
               if ( AnyError == 0 )
               {
                  ZM079( 8) ;
               }
               CloseExtendedTableCursors079( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12072( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            context.PopUp(formatLink("aemitirinvitacion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A17InvitacionId,4,0))}, new string[] {"InvitacionId"}) , new Object[] {});
         }
      }

      protected void ZM079( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z30InvitacionNombreInvitado = A30InvitacionNombreInvitado;
            Z5EspectaculoId = A5EspectaculoId;
            Z32EspectaculoInvitacionesDisponi = A32EspectaculoInvitacionesDisponi;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z8EspectaculoNombre = A8EspectaculoNombre;
            Z19EspectaculoFecha = A19EspectaculoFecha;
            Z31EspectaculoCantidadInvitacione = A31EspectaculoCantidadInvitacione;
            Z32EspectaculoInvitacionesDisponi = A32EspectaculoInvitacionesDisponi;
         }
         if ( GX_JID == -7 )
         {
            Z17InvitacionId = A17InvitacionId;
            Z30InvitacionNombreInvitado = A30InvitacionNombreInvitado;
            Z5EspectaculoId = A5EspectaculoId;
            Z33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
            Z8EspectaculoNombre = A8EspectaculoNombre;
            Z19EspectaculoFecha = A19EspectaculoFecha;
            Z31EspectaculoCantidadInvitacione = A31EspectaculoCantidadInvitacione;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_date = DateTimeUtil.Today( context);
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A30InvitacionNombreInvitado)) && ( Gx_BScreen == 0 ) )
         {
            A30InvitacionNombreInvitado = "INVITACIÓN";
         }
      }

      protected void Load079( )
      {
         /* Using cursor BC00076 */
         pr_default.execute(4, new Object[] {A17InvitacionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A33EspectaculoInvitacionesEntrega = BC00076_A33EspectaculoInvitacionesEntrega[0];
            A30InvitacionNombreInvitado = BC00076_A30InvitacionNombreInvitado[0];
            A8EspectaculoNombre = BC00076_A8EspectaculoNombre[0];
            A19EspectaculoFecha = BC00076_A19EspectaculoFecha[0];
            A31EspectaculoCantidadInvitacione = BC00076_A31EspectaculoCantidadInvitacione[0];
            A5EspectaculoId = BC00076_A5EspectaculoId[0];
            ZM079( -7) ;
         }
         pr_default.close(4);
         OnLoadActions079( ) ;
      }

      protected void OnLoadActions079( )
      {
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         if ( IsIns( )  )
         {
            A33EspectaculoInvitacionesEntrega = (short)(O33EspectaculoInvitacionesEntrega+1);
         }
         A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
      }

      protected void CheckExtendedTable079( )
      {
         nIsDirty_9 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A33EspectaculoInvitacionesEntrega = BC00075_A33EspectaculoInvitacionesEntrega[0];
         A8EspectaculoNombre = BC00075_A8EspectaculoNombre[0];
         A19EspectaculoFecha = BC00075_A19EspectaculoFecha[0];
         A31EspectaculoCantidadInvitacione = BC00075_A31EspectaculoCantidadInvitacione[0];
         nIsDirty_9 = 1;
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         pr_default.close(3);
         if ( IsIns( )  )
         {
            nIsDirty_9 = 1;
            A33EspectaculoInvitacionesEntrega = (short)(O33EspectaculoInvitacionesEntrega+1);
         }
         nIsDirty_9 = 1;
         A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
         if ( A32EspectaculoInvitacionesDisponi < 0 )
         {
            GX_msglist.addItem("No hay más invitaciones disponibles para este espectáculo", 1, "");
            AnyError = 1;
         }
         if ( DateTimeUtil.ResetTime ( A19EspectaculoFecha ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("La fecha del espectáculo es anterior a la fecha actual", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors079( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey079( )
      {
         /* Using cursor BC00077 */
         pr_default.execute(5, new Object[] {A17InvitacionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A17InvitacionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM079( 7) ;
            RcdFound9 = 1;
            A17InvitacionId = BC00073_A17InvitacionId[0];
            A30InvitacionNombreInvitado = BC00073_A30InvitacionNombreInvitado[0];
            A5EspectaculoId = BC00073_A5EspectaculoId[0];
            Z17InvitacionId = A17InvitacionId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load079( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey079( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey079( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey079( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_070( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency079( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A17InvitacionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z30InvitacionNombreInvitado, BC00072_A30InvitacionNombreInvitado[0]) != 0 ) || ( Z5EspectaculoId != BC00072_A5EspectaculoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invitacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor BC00078 */
         pr_default.execute(6, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(6) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false || ( StringUtil.StrCmp(Z8EspectaculoNombre, BC00078_A8EspectaculoNombre[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z19EspectaculoFecha ) != DateTimeUtil.ResetTime ( BC00078_A19EspectaculoFecha[0] ) ) || ( Z31EspectaculoCantidadInvitacione != BC00078_A31EspectaculoCantidadInvitacione[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Espectaculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert079( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable079( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM079( 0) ;
            CheckOptimisticConcurrency079( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm079( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert079( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00079 */
                     pr_default.execute(7, new Object[] {A30InvitacionNombreInvitado, A5EspectaculoId});
                     A17InvitacionId = BC00079_A17InvitacionId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN1079( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load079( ) ;
            }
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void Update079( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable079( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency079( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm079( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate079( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000710 */
                     pr_default.execute(8, new Object[] {A30InvitacionNombreInvitado, A5EspectaculoId, A17InvitacionId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate079( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN1079( ) ;
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void DeferredUpdate079( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency079( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls079( ) ;
            AfterConfirm079( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete079( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000711 */
                  pr_default.execute(9, new Object[] {A17InvitacionId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN1079( ) ;
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel079( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls079( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC00075 */
            pr_default.execute(3, new Object[] {A5EspectaculoId});
            ZM079( 8) ;
            A33EspectaculoInvitacionesEntrega = BC00075_A33EspectaculoInvitacionesEntrega[0];
            A8EspectaculoNombre = BC00075_A8EspectaculoNombre[0];
            A19EspectaculoFecha = BC00075_A19EspectaculoFecha[0];
            A31EspectaculoCantidadInvitacione = BC00075_A31EspectaculoCantidadInvitacione[0];
            O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
            pr_default.close(6);
            if ( IsIns( )  )
            {
               A33EspectaculoInvitacionesEntrega = (short)(O33EspectaculoInvitacionesEntrega+1);
            }
            A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
         }
      }

      protected void UpdateTablesN1079( )
      {
         /* Using cursor BC000712 */
         pr_default.execute(10, new Object[] {A33EspectaculoInvitacionesEntrega, A5EspectaculoId});
         pr_default.close(10);
         pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
      }

      protected void EndLevel079( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(6);
         if ( AnyError == 0 )
         {
            BeforeComplete079( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart079( )
      {
         /* Scan By routine */
         /* Using cursor BC000713 */
         pr_default.execute(11, new Object[] {A17InvitacionId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A17InvitacionId = BC000713_A17InvitacionId[0];
            A33EspectaculoInvitacionesEntrega = BC000713_A33EspectaculoInvitacionesEntrega[0];
            A30InvitacionNombreInvitado = BC000713_A30InvitacionNombreInvitado[0];
            A8EspectaculoNombre = BC000713_A8EspectaculoNombre[0];
            A19EspectaculoFecha = BC000713_A19EspectaculoFecha[0];
            A31EspectaculoCantidadInvitacione = BC000713_A31EspectaculoCantidadInvitacione[0];
            A5EspectaculoId = BC000713_A5EspectaculoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext079( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound9 = 0;
         ScanKeyLoad079( ) ;
      }

      protected void ScanKeyLoad079( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A17InvitacionId = BC000713_A17InvitacionId[0];
            A33EspectaculoInvitacionesEntrega = BC000713_A33EspectaculoInvitacionesEntrega[0];
            A30InvitacionNombreInvitado = BC000713_A30InvitacionNombreInvitado[0];
            A8EspectaculoNombre = BC000713_A8EspectaculoNombre[0];
            A19EspectaculoFecha = BC000713_A19EspectaculoFecha[0];
            A31EspectaculoCantidadInvitacione = BC000713_A31EspectaculoCantidadInvitacione[0];
            A5EspectaculoId = BC000713_A5EspectaculoId[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd079( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm079( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert079( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate079( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete079( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete079( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate079( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes079( )
      {
      }

      protected void send_integrity_lvl_hashes079( )
      {
      }

      protected void AddRow079( )
      {
         VarsToRow9( bcInvitacion) ;
      }

      protected void ReadRow079( )
      {
         RowToVars9( bcInvitacion, 1) ;
      }

      protected void InitializeNonKey079( )
      {
         A33EspectaculoInvitacionesEntrega = 0;
         A32EspectaculoInvitacionesDisponi = 0;
         A5EspectaculoId = 0;
         A8EspectaculoNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         A31EspectaculoCantidadInvitacione = 0;
         A30InvitacionNombreInvitado = "INVITACIÓN";
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         Z30InvitacionNombreInvitado = "";
         Z5EspectaculoId = 0;
         Z8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
         Z31EspectaculoCantidadInvitacione = 0;
      }

      protected void InitAll079( )
      {
         A17InvitacionId = 0;
         InitializeNonKey079( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A30InvitacionNombreInvitado = i30InvitacionNombreInvitado;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow9( SdtInvitacion obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Espectaculoinvitacionesentregadas = A33EspectaculoInvitacionesEntrega;
         obj9.gxTpr_Espectaculoinvitacionesdisponibles = A32EspectaculoInvitacionesDisponi;
         obj9.gxTpr_Espectaculoid = A5EspectaculoId;
         obj9.gxTpr_Espectaculonombre = A8EspectaculoNombre;
         obj9.gxTpr_Espectaculofecha = A19EspectaculoFecha;
         obj9.gxTpr_Invitacionnombreinvitado = A30InvitacionNombreInvitado;
         obj9.gxTpr_Invitacionid = A17InvitacionId;
         obj9.gxTpr_Invitacionid_Z = Z17InvitacionId;
         obj9.gxTpr_Invitacionnombreinvitado_Z = Z30InvitacionNombreInvitado;
         obj9.gxTpr_Espectaculoid_Z = Z5EspectaculoId;
         obj9.gxTpr_Espectaculonombre_Z = Z8EspectaculoNombre;
         obj9.gxTpr_Espectaculofecha_Z = Z19EspectaculoFecha;
         obj9.gxTpr_Espectaculoinvitacionesentregadas_Z = Z33EspectaculoInvitacionesEntrega;
         obj9.gxTpr_Espectaculoinvitacionesdisponibles_Z = Z32EspectaculoInvitacionesDisponi;
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtInvitacion obj9 )
      {
         obj9.gxTpr_Invitacionid = A17InvitacionId;
         return  ;
      }

      public void RowToVars9( SdtInvitacion obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A33EspectaculoInvitacionesEntrega = obj9.gxTpr_Espectaculoinvitacionesentregadas;
         if ( forceLoad == 1 )
         {
            A32EspectaculoInvitacionesDisponi = obj9.gxTpr_Espectaculoinvitacionesdisponibles;
         }
         if ( ! ( IsUpd( )  ) || ( forceLoad == 1 ) )
         {
            A5EspectaculoId = obj9.gxTpr_Espectaculoid;
         }
         A8EspectaculoNombre = obj9.gxTpr_Espectaculonombre;
         A19EspectaculoFecha = obj9.gxTpr_Espectaculofecha;
         A30InvitacionNombreInvitado = obj9.gxTpr_Invitacionnombreinvitado;
         if ( forceLoad == 1 )
         {
            A17InvitacionId = obj9.gxTpr_Invitacionid;
         }
         Z17InvitacionId = obj9.gxTpr_Invitacionid_Z;
         Z30InvitacionNombreInvitado = obj9.gxTpr_Invitacionnombreinvitado_Z;
         Z5EspectaculoId = obj9.gxTpr_Espectaculoid_Z;
         Z8EspectaculoNombre = obj9.gxTpr_Espectaculonombre_Z;
         Z19EspectaculoFecha = obj9.gxTpr_Espectaculofecha_Z;
         Z33EspectaculoInvitacionesEntrega = obj9.gxTpr_Espectaculoinvitacionesentregadas_Z;
         O33EspectaculoInvitacionesEntrega = obj9.gxTpr_Espectaculoinvitacionesentregadas_Z;
         Z32EspectaculoInvitacionesDisponi = obj9.gxTpr_Espectaculoinvitacionesdisponibles_Z;
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A17InvitacionId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey079( ) ;
         ScanKeyStart079( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z17InvitacionId = A17InvitacionId;
            O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         }
         ZM079( -7) ;
         OnLoadActions079( ) ;
         AddRow079( ) ;
         ScanKeyEnd079( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars9( bcInvitacion, 0) ;
         ScanKeyStart079( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z17InvitacionId = A17InvitacionId;
            O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         }
         ZM079( -7) ;
         OnLoadActions079( ) ;
         AddRow079( ) ;
         ScanKeyEnd079( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey079( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert079( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A17InvitacionId != Z17InvitacionId )
               {
                  A17InvitacionId = Z17InvitacionId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update079( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A17InvitacionId != Z17InvitacionId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert079( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert079( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcInvitacion, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcInvitacion) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcInvitacion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert079( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcInvitacion) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcInvitacion) ;
         }
         else
         {
            SdtInvitacion auxBC = new SdtInvitacion(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A17InvitacionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcInvitacion);
               auxBC.Save();
               bcInvitacion.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcInvitacion, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars9( bcInvitacion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert079( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow9( bcInvitacion) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcInvitacion) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcInvitacion, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey079( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A17InvitacionId != Z17InvitacionId )
            {
               A17InvitacionId = Z17InvitacionId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A17InvitacionId != Z17InvitacionId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(3);
         context.RollbackDataStores("invitacion_bc",pr_default);
         VarsToRow9( bcInvitacion) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcInvitacion.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcInvitacion.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcInvitacion )
         {
            bcInvitacion = (SdtInvitacion)(sdt);
            if ( StringUtil.StrCmp(bcInvitacion.gxTpr_Mode, "") == 0 )
            {
               bcInvitacion.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcInvitacion) ;
            }
            else
            {
               RowToVars9( bcInvitacion, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcInvitacion.gxTpr_Mode, "") == 0 )
            {
               bcInvitacion.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcInvitacion, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtInvitacion Invitacion_BC
      {
         get {
            return bcInvitacion ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z30InvitacionNombreInvitado = "";
         A30InvitacionNombreInvitado = "";
         Z8EspectaculoNombre = "";
         A8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
         A19EspectaculoFecha = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         BC00076_A17InvitacionId = new short[1] ;
         BC00076_A33EspectaculoInvitacionesEntrega = new short[1] ;
         BC00076_A30InvitacionNombreInvitado = new string[] {""} ;
         BC00076_A8EspectaculoNombre = new string[] {""} ;
         BC00076_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC00076_A31EspectaculoCantidadInvitacione = new short[1] ;
         BC00076_A5EspectaculoId = new short[1] ;
         BC00075_A33EspectaculoInvitacionesEntrega = new short[1] ;
         BC00075_A8EspectaculoNombre = new string[] {""} ;
         BC00075_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC00075_A31EspectaculoCantidadInvitacione = new short[1] ;
         BC00077_A17InvitacionId = new short[1] ;
         BC00073_A17InvitacionId = new short[1] ;
         BC00073_A30InvitacionNombreInvitado = new string[] {""} ;
         BC00073_A5EspectaculoId = new short[1] ;
         sMode9 = "";
         BC00072_A17InvitacionId = new short[1] ;
         BC00072_A30InvitacionNombreInvitado = new string[] {""} ;
         BC00072_A5EspectaculoId = new short[1] ;
         BC00078_A33EspectaculoInvitacionesEntrega = new short[1] ;
         BC00078_A8EspectaculoNombre = new string[] {""} ;
         BC00078_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC00078_A31EspectaculoCantidadInvitacione = new short[1] ;
         BC00079_A17InvitacionId = new short[1] ;
         BC000713_A17InvitacionId = new short[1] ;
         BC000713_A33EspectaculoInvitacionesEntrega = new short[1] ;
         BC000713_A30InvitacionNombreInvitado = new string[] {""} ;
         BC000713_A8EspectaculoNombre = new string[] {""} ;
         BC000713_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000713_A31EspectaculoCantidadInvitacione = new short[1] ;
         BC000713_A5EspectaculoId = new short[1] ;
         i30InvitacionNombreInvitado = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invitacion_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A17InvitacionId, BC00072_A30InvitacionNombreInvitado, BC00072_A5EspectaculoId
               }
               , new Object[] {
               BC00073_A17InvitacionId, BC00073_A30InvitacionNombreInvitado, BC00073_A5EspectaculoId
               }
               , new Object[] {
               BC00074_A33EspectaculoInvitacionesEntrega, BC00074_A8EspectaculoNombre, BC00074_A19EspectaculoFecha, BC00074_A31EspectaculoCantidadInvitacione
               }
               , new Object[] {
               BC00075_A33EspectaculoInvitacionesEntrega, BC00075_A8EspectaculoNombre, BC00075_A19EspectaculoFecha, BC00075_A31EspectaculoCantidadInvitacione
               }
               , new Object[] {
               BC00076_A17InvitacionId, BC00076_A33EspectaculoInvitacionesEntrega, BC00076_A30InvitacionNombreInvitado, BC00076_A8EspectaculoNombre, BC00076_A19EspectaculoFecha, BC00076_A31EspectaculoCantidadInvitacione, BC00076_A5EspectaculoId
               }
               , new Object[] {
               BC00077_A17InvitacionId
               }
               , new Object[] {
               BC00078_A33EspectaculoInvitacionesEntrega, BC00078_A8EspectaculoNombre, BC00078_A19EspectaculoFecha, BC00078_A31EspectaculoCantidadInvitacione
               }
               , new Object[] {
               BC00079_A17InvitacionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000713_A17InvitacionId, BC000713_A33EspectaculoInvitacionesEntrega, BC000713_A30InvitacionNombreInvitado, BC000713_A8EspectaculoNombre, BC000713_A19EspectaculoFecha, BC000713_A31EspectaculoCantidadInvitacione, BC000713_A5EspectaculoId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Z30InvitacionNombreInvitado = "INVITACIÓN";
         A30InvitacionNombreInvitado = "INVITACIÓN";
         i30InvitacionNombreInvitado = "INVITACIÓN";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12072 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z17InvitacionId ;
      private short A17InvitacionId ;
      private short GX_JID ;
      private short Z5EspectaculoId ;
      private short A5EspectaculoId ;
      private short Z32EspectaculoInvitacionesDisponi ;
      private short A32EspectaculoInvitacionesDisponi ;
      private short Z31EspectaculoCantidadInvitacione ;
      private short A31EspectaculoCantidadInvitacione ;
      private short Z33EspectaculoInvitacionesEntrega ;
      private short A33EspectaculoInvitacionesEntrega ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short O33EspectaculoInvitacionesEntrega ;
      private short nIsDirty_9 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z30InvitacionNombreInvitado ;
      private string A30InvitacionNombreInvitado ;
      private string Z8EspectaculoNombre ;
      private string A8EspectaculoNombre ;
      private string sMode9 ;
      private string i30InvitacionNombreInvitado ;
      private DateTime Z19EspectaculoFecha ;
      private DateTime A19EspectaculoFecha ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool mustCommit ;
      private SdtInvitacion bcInvitacion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00076_A17InvitacionId ;
      private short[] BC00076_A33EspectaculoInvitacionesEntrega ;
      private string[] BC00076_A30InvitacionNombreInvitado ;
      private string[] BC00076_A8EspectaculoNombre ;
      private DateTime[] BC00076_A19EspectaculoFecha ;
      private short[] BC00076_A31EspectaculoCantidadInvitacione ;
      private short[] BC00076_A5EspectaculoId ;
      private short[] BC00075_A33EspectaculoInvitacionesEntrega ;
      private string[] BC00075_A8EspectaculoNombre ;
      private DateTime[] BC00075_A19EspectaculoFecha ;
      private short[] BC00075_A31EspectaculoCantidadInvitacione ;
      private short[] BC00077_A17InvitacionId ;
      private short[] BC00073_A17InvitacionId ;
      private string[] BC00073_A30InvitacionNombreInvitado ;
      private short[] BC00073_A5EspectaculoId ;
      private short[] BC00072_A17InvitacionId ;
      private string[] BC00072_A30InvitacionNombreInvitado ;
      private short[] BC00072_A5EspectaculoId ;
      private short[] BC00078_A33EspectaculoInvitacionesEntrega ;
      private string[] BC00078_A8EspectaculoNombre ;
      private DateTime[] BC00078_A19EspectaculoFecha ;
      private short[] BC00078_A31EspectaculoCantidadInvitacione ;
      private short[] BC00079_A17InvitacionId ;
      private short[] BC000713_A17InvitacionId ;
      private short[] BC000713_A33EspectaculoInvitacionesEntrega ;
      private string[] BC000713_A30InvitacionNombreInvitado ;
      private string[] BC000713_A8EspectaculoNombre ;
      private DateTime[] BC000713_A19EspectaculoFecha ;
      private short[] BC000713_A31EspectaculoCantidadInvitacione ;
      private short[] BC000713_A5EspectaculoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC00074_A33EspectaculoInvitacionesEntrega ;
      private string[] BC00074_A8EspectaculoNombre ;
      private DateTime[] BC00074_A19EspectaculoFecha ;
      private short[] BC00074_A31EspectaculoCantidadInvitacione ;
   }

   public class invitacion_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00074;
          prmBC00074 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00076;
          prmBC00076 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00077;
          prmBC00077 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00073;
          prmBC00073 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00072;
          prmBC00072 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00078;
          prmBC00078 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00079;
          prmBC00079 = new Object[] {
          new ParDef("@InvitacionNombreInvitado",GXType.NChar,60,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000710;
          prmBC000710 = new Object[] {
          new ParDef("@InvitacionNombreInvitado",GXType.NChar,60,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC000711;
          prmBC000711 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00075;
          prmBC00075 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000712;
          prmBC000712 = new Object[] {
          new ParDef("@EspectaculoInvitacionesEntrega",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000713;
          prmBC000713 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00072", "SELECT [InvitacionId], [InvitacionNombreInvitado], [EspectaculoId] FROM [Invitacion] WITH (UPDLOCK) WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00073", "SELECT [InvitacionId], [InvitacionNombreInvitado], [EspectaculoId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00074", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoCantidadInvitacione] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00075", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoCantidadInvitacione] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00076", "SELECT TM1.[InvitacionId], T2.[EspectaculoInvitacionesEntrega], TM1.[InvitacionNombreInvitado], T2.[EspectaculoNombre], T2.[EspectaculoFecha], T2.[EspectaculoCantidadInvitacione], TM1.[EspectaculoId] FROM ([Invitacion] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) WHERE TM1.[InvitacionId] = @InvitacionId ORDER BY TM1.[InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00076,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00077", "SELECT [InvitacionId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00078", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoCantidadInvitacione] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00079", "INSERT INTO [Invitacion]([InvitacionNombreInvitado], [EspectaculoId]) VALUES(@InvitacionNombreInvitado, @EspectaculoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00079,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000710", "UPDATE [Invitacion] SET [InvitacionNombreInvitado]=@InvitacionNombreInvitado, [EspectaculoId]=@EspectaculoId  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmBC000710)
             ,new CursorDef("BC000711", "DELETE FROM [Invitacion]  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmBC000711)
             ,new CursorDef("BC000712", "UPDATE [Espectaculo] SET [EspectaculoInvitacionesEntrega]=@EspectaculoInvitacionesEntrega  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmBC000712)
             ,new CursorDef("BC000713", "SELECT TM1.[InvitacionId], T2.[EspectaculoInvitacionesEntrega], TM1.[InvitacionNombreInvitado], T2.[EspectaculoNombre], T2.[EspectaculoFecha], T2.[EspectaculoCantidadInvitacione], TM1.[EspectaculoId] FROM ([Invitacion] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) WHERE TM1.[InvitacionId] = @InvitacionId ORDER BY TM1.[InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000713,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
