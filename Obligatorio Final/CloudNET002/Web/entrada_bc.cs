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
   public class entrada_bc : GxSilentTrn, IGxSilentTrn
   {
      public entrada_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public entrada_bc( IGxContext context )
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
         ReadRow046( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey046( ) ;
         standaloneModal( ) ;
         AddRow046( ) ;
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
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z11EntradaId = A11EntradaId;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls046( ) ;
            }
            else
            {
               CheckExtendedTable046( ) ;
               if ( AnyError == 0 )
               {
                  ZM046( 6) ;
                  ZM046( 7) ;
                  ZM046( 8) ;
               }
               CloseExtendedTableCursors046( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12042( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.PopUp(formatLink("aemitirticket.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A11EntradaId,4,0))}, new string[] {"EntradaId"}) , new Object[] {});
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z5EspectaculoId = A5EspectaculoId;
            Z9SectorId = A9SectorId;
            Z12PaisCompraId = A12PaisCompraId;
            Z25SectorEntradasVendidas = A25SectorEntradasVendidas;
            Z24SectorEntradasDisponibles = A24SectorEntradasDisponibles;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z8EspectaculoNombre = A8EspectaculoNombre;
            Z19EspectaculoFecha = A19EspectaculoFecha;
            Z25SectorEntradasVendidas = A25SectorEntradasVendidas;
            Z24SectorEntradasDisponibles = A24SectorEntradasDisponibles;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z21SectorNombre = A21SectorNombre;
            Z23SectorPrecio = A23SectorPrecio;
            Z22SectorCapacidad = A22SectorCapacidad;
            Z25SectorEntradasVendidas = A25SectorEntradasVendidas;
            Z24SectorEntradasDisponibles = A24SectorEntradasDisponibles;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z27PaisCompraNombre = A27PaisCompraNombre;
            Z25SectorEntradasVendidas = A25SectorEntradasVendidas;
            Z24SectorEntradasDisponibles = A24SectorEntradasDisponibles;
         }
         if ( GX_JID == -5 )
         {
            Z11EntradaId = A11EntradaId;
            Z5EspectaculoId = A5EspectaculoId;
            Z9SectorId = A9SectorId;
            Z12PaisCompraId = A12PaisCompraId;
            Z8EspectaculoNombre = A8EspectaculoNombre;
            Z19EspectaculoFecha = A19EspectaculoFecha;
            Z21SectorNombre = A21SectorNombre;
            Z23SectorPrecio = A23SectorPrecio;
            Z22SectorCapacidad = A22SectorCapacidad;
            Z27PaisCompraNombre = A27PaisCompraNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
      }

      protected void Load046( )
      {
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {A11EntradaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
            A8EspectaculoNombre = BC00047_A8EspectaculoNombre[0];
            A19EspectaculoFecha = BC00047_A19EspectaculoFecha[0];
            A21SectorNombre = BC00047_A21SectorNombre[0];
            A23SectorPrecio = BC00047_A23SectorPrecio[0];
            A27PaisCompraNombre = BC00047_A27PaisCompraNombre[0];
            A22SectorCapacidad = BC00047_A22SectorCapacidad[0];
            A5EspectaculoId = BC00047_A5EspectaculoId[0];
            A9SectorId = BC00047_A9SectorId[0];
            A12PaisCompraId = BC00047_A12PaisCompraId[0];
            ZM046( -5) ;
         }
         pr_default.close(5);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
      }

      protected void CheckExtendedTable046( )
      {
         nIsDirty_6 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A8EspectaculoNombre = BC00044_A8EspectaculoNombre[0];
         A19EspectaculoFecha = BC00044_A19EspectaculoFecha[0];
         pr_default.close(2);
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A5EspectaculoId, A9SectorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
         }
         A21SectorNombre = BC00045_A21SectorNombre[0];
         A23SectorPrecio = BC00045_A23SectorPrecio[0];
         A22SectorCapacidad = BC00045_A22SectorCapacidad[0];
         pr_default.close(3);
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {A12PaisCompraId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais Compra'.", "ForeignKeyNotFound", 1, "PAISCOMPRAID");
            AnyError = 1;
         }
         A27PaisCompraNombre = BC00046_A27PaisCompraNombre[0];
         pr_default.close(4);
         if ( DateTimeUtil.ResetTime ( A19EspectaculoFecha ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("La fecha del espectáculo es anterior a la fecha actual", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors046( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey046( )
      {
         /* Using cursor BC00048 */
         pr_default.execute(6, new Object[] {A11EntradaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A11EntradaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 5) ;
            RcdFound6 = 1;
            A11EntradaId = BC00043_A11EntradaId[0];
            A5EspectaculoId = BC00043_A5EspectaculoId[0];
            A9SectorId = BC00043_A9SectorId[0];
            A12PaisCompraId = BC00043_A12PaisCompraId[0];
            Z11EntradaId = A11EntradaId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load046( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey046( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey046( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_040( ) ;
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

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A11EntradaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Entrada"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z5EspectaculoId != BC00042_A5EspectaculoId[0] ) || ( Z9SectorId != BC00042_A9SectorId[0] ) || ( Z12PaisCompraId != BC00042_A12PaisCompraId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Entrada"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM046( 0) ;
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00049 */
                     pr_default.execute(7, new Object[] {A5EspectaculoId, A9SectorId, A12PaisCompraId});
                     A11EntradaId = BC00049_A11EntradaId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Entrada");
                     if ( AnyError == 0 )
                     {
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
               Load046( ) ;
            }
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void Update046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000410 */
                     pr_default.execute(8, new Object[] {A5EspectaculoId, A9SectorId, A12PaisCompraId, A11EntradaId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Entrada");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Entrada"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate046( ) ;
                     if ( AnyError == 0 )
                     {
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
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void DeferredUpdate046( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls046( ) ;
            AfterConfirm046( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete046( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000411 */
                  pr_default.execute(9, new Object[] {A11EntradaId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Entrada");
                  if ( AnyError == 0 )
                  {
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel046( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000412 */
            pr_default.execute(10, new Object[] {A5EspectaculoId});
            A8EspectaculoNombre = BC000412_A8EspectaculoNombre[0];
            A19EspectaculoFecha = BC000412_A19EspectaculoFecha[0];
            pr_default.close(10);
            /* Using cursor BC000413 */
            pr_default.execute(11, new Object[] {A5EspectaculoId, A9SectorId});
            A21SectorNombre = BC000413_A21SectorNombre[0];
            A23SectorPrecio = BC000413_A23SectorPrecio[0];
            A22SectorCapacidad = BC000413_A22SectorCapacidad[0];
            pr_default.close(11);
            /* Using cursor BC000414 */
            pr_default.execute(12, new Object[] {A12PaisCompraId});
            A27PaisCompraNombre = BC000414_A27PaisCompraNombre[0];
            pr_default.close(12);
         }
      }

      protected void EndLevel046( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete046( ) ;
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

      public void ScanKeyStart046( )
      {
         /* Scan By routine */
         /* Using cursor BC000415 */
         pr_default.execute(13, new Object[] {A11EntradaId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound6 = 1;
            A11EntradaId = BC000415_A11EntradaId[0];
            A8EspectaculoNombre = BC000415_A8EspectaculoNombre[0];
            A19EspectaculoFecha = BC000415_A19EspectaculoFecha[0];
            A21SectorNombre = BC000415_A21SectorNombre[0];
            A23SectorPrecio = BC000415_A23SectorPrecio[0];
            A27PaisCompraNombre = BC000415_A27PaisCompraNombre[0];
            A22SectorCapacidad = BC000415_A22SectorCapacidad[0];
            A5EspectaculoId = BC000415_A5EspectaculoId[0];
            A9SectorId = BC000415_A9SectorId[0];
            A12PaisCompraId = BC000415_A12PaisCompraId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound6 = 0;
         ScanKeyLoad046( ) ;
      }

      protected void ScanKeyLoad046( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound6 = 1;
            A11EntradaId = BC000415_A11EntradaId[0];
            A8EspectaculoNombre = BC000415_A8EspectaculoNombre[0];
            A19EspectaculoFecha = BC000415_A19EspectaculoFecha[0];
            A21SectorNombre = BC000415_A21SectorNombre[0];
            A23SectorPrecio = BC000415_A23SectorPrecio[0];
            A27PaisCompraNombre = BC000415_A27PaisCompraNombre[0];
            A22SectorCapacidad = BC000415_A22SectorCapacidad[0];
            A5EspectaculoId = BC000415_A5EspectaculoId[0];
            A9SectorId = BC000415_A9SectorId[0];
            A12PaisCompraId = BC000415_A12PaisCompraId[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd046( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm046( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert046( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate046( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete046( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete046( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate046( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes046( )
      {
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void AddRow046( )
      {
         VarsToRow6( bcEntrada) ;
      }

      protected void ReadRow046( )
      {
         RowToVars6( bcEntrada, 1) ;
      }

      protected void InitializeNonKey046( )
      {
         A25SectorEntradasVendidas = 0;
         A24SectorEntradasDisponibles = 0;
         A5EspectaculoId = 0;
         A8EspectaculoNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         A9SectorId = 0;
         A21SectorNombre = "";
         A23SectorPrecio = 0;
         A12PaisCompraId = 0;
         A27PaisCompraNombre = "";
         A22SectorCapacidad = 0;
         O25SectorEntradasVendidas = A25SectorEntradasVendidas;
         Z5EspectaculoId = 0;
         Z9SectorId = 0;
         Z12PaisCompraId = 0;
      }

      protected void InitAll046( )
      {
         A11EntradaId = 0;
         InitializeNonKey046( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow6( SdtEntrada obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Sectorentradasvendidas = A25SectorEntradasVendidas;
         obj6.gxTpr_Sectorentradasdisponibles = A24SectorEntradasDisponibles;
         obj6.gxTpr_Espectaculoid = A5EspectaculoId;
         obj6.gxTpr_Espectaculonombre = A8EspectaculoNombre;
         obj6.gxTpr_Espectaculofecha = A19EspectaculoFecha;
         obj6.gxTpr_Sectorid = A9SectorId;
         obj6.gxTpr_Sectornombre = A21SectorNombre;
         obj6.gxTpr_Sectorprecio = A23SectorPrecio;
         obj6.gxTpr_Paiscompraid = A12PaisCompraId;
         obj6.gxTpr_Paiscompranombre = A27PaisCompraNombre;
         obj6.gxTpr_Entradaid = A11EntradaId;
         obj6.gxTpr_Entradaid_Z = Z11EntradaId;
         obj6.gxTpr_Espectaculoid_Z = Z5EspectaculoId;
         obj6.gxTpr_Espectaculonombre_Z = Z8EspectaculoNombre;
         obj6.gxTpr_Espectaculofecha_Z = Z19EspectaculoFecha;
         obj6.gxTpr_Sectorid_Z = Z9SectorId;
         obj6.gxTpr_Sectornombre_Z = Z21SectorNombre;
         obj6.gxTpr_Sectorprecio_Z = Z23SectorPrecio;
         obj6.gxTpr_Sectorentradasvendidas_Z = Z25SectorEntradasVendidas;
         obj6.gxTpr_Sectorentradasdisponibles_Z = Z24SectorEntradasDisponibles;
         obj6.gxTpr_Paiscompraid_Z = Z12PaisCompraId;
         obj6.gxTpr_Paiscompranombre_Z = Z27PaisCompraNombre;
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtEntrada obj6 )
      {
         obj6.gxTpr_Entradaid = A11EntradaId;
         return  ;
      }

      public void RowToVars6( SdtEntrada obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A25SectorEntradasVendidas = obj6.gxTpr_Sectorentradasvendidas;
         A24SectorEntradasDisponibles = obj6.gxTpr_Sectorentradasdisponibles;
         A5EspectaculoId = obj6.gxTpr_Espectaculoid;
         A8EspectaculoNombre = obj6.gxTpr_Espectaculonombre;
         A19EspectaculoFecha = obj6.gxTpr_Espectaculofecha;
         A9SectorId = obj6.gxTpr_Sectorid;
         A21SectorNombre = obj6.gxTpr_Sectornombre;
         A23SectorPrecio = obj6.gxTpr_Sectorprecio;
         A12PaisCompraId = obj6.gxTpr_Paiscompraid;
         A27PaisCompraNombre = obj6.gxTpr_Paiscompranombre;
         A11EntradaId = obj6.gxTpr_Entradaid;
         Z11EntradaId = obj6.gxTpr_Entradaid_Z;
         Z5EspectaculoId = obj6.gxTpr_Espectaculoid_Z;
         Z8EspectaculoNombre = obj6.gxTpr_Espectaculonombre_Z;
         Z19EspectaculoFecha = obj6.gxTpr_Espectaculofecha_Z;
         Z9SectorId = obj6.gxTpr_Sectorid_Z;
         Z21SectorNombre = obj6.gxTpr_Sectornombre_Z;
         Z23SectorPrecio = obj6.gxTpr_Sectorprecio_Z;
         Z25SectorEntradasVendidas = obj6.gxTpr_Sectorentradasvendidas_Z;
         O25SectorEntradasVendidas = obj6.gxTpr_Sectorentradasvendidas_Z;
         Z24SectorEntradasDisponibles = obj6.gxTpr_Sectorentradasdisponibles_Z;
         Z12PaisCompraId = obj6.gxTpr_Paiscompraid_Z;
         Z27PaisCompraNombre = obj6.gxTpr_Paiscompranombre_Z;
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A11EntradaId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey046( ) ;
         ScanKeyStart046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11EntradaId = A11EntradaId;
            O25SectorEntradasVendidas = A25SectorEntradasVendidas;
         }
         ZM046( -5) ;
         OnLoadActions046( ) ;
         AddRow046( ) ;
         ScanKeyEnd046( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcEntrada, 0) ;
         ScanKeyStart046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11EntradaId = A11EntradaId;
            O25SectorEntradasVendidas = A25SectorEntradasVendidas;
         }
         ZM046( -5) ;
         OnLoadActions046( ) ;
         AddRow046( ) ;
         ScanKeyEnd046( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey046( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert046( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A11EntradaId != Z11EntradaId )
               {
                  A11EntradaId = Z11EntradaId;
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
                  Update046( ) ;
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
                  if ( A11EntradaId != Z11EntradaId )
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
                        Insert046( ) ;
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
                        Insert046( ) ;
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
         RowToVars6( bcEntrada, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcEntrada) ;
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
         RowToVars6( bcEntrada, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert046( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcEntrada) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow6( bcEntrada) ;
         }
         else
         {
            SdtEntrada auxBC = new SdtEntrada(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A11EntradaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEntrada);
               auxBC.Save();
               bcEntrada.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars6( bcEntrada, 1) ;
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
         RowToVars6( bcEntrada, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert046( ) ;
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
               VarsToRow6( bcEntrada) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow6( bcEntrada) ;
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
         RowToVars6( bcEntrada, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey046( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A11EntradaId != Z11EntradaId )
            {
               A11EntradaId = Z11EntradaId;
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
            if ( A11EntradaId != Z11EntradaId )
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
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
         context.RollbackDataStores("entrada_bc",pr_default);
         VarsToRow6( bcEntrada) ;
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
         Gx_mode = bcEntrada.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEntrada.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEntrada )
         {
            bcEntrada = (SdtEntrada)(sdt);
            if ( StringUtil.StrCmp(bcEntrada.gxTpr_Mode, "") == 0 )
            {
               bcEntrada.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcEntrada) ;
            }
            else
            {
               RowToVars6( bcEntrada, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEntrada.gxTpr_Mode, "") == 0 )
            {
               bcEntrada.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcEntrada, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtEntrada Entrada_BC
      {
         get {
            return bcEntrada ;
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
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z8EspectaculoNombre = "";
         A8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
         A19EspectaculoFecha = DateTime.MinValue;
         Z21SectorNombre = "";
         A21SectorNombre = "";
         Z27PaisCompraNombre = "";
         A27PaisCompraNombre = "";
         Gx_date = DateTime.MinValue;
         BC00047_A11EntradaId = new short[1] ;
         BC00047_A8EspectaculoNombre = new string[] {""} ;
         BC00047_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC00047_A21SectorNombre = new string[] {""} ;
         BC00047_A23SectorPrecio = new int[1] ;
         BC00047_A27PaisCompraNombre = new string[] {""} ;
         BC00047_A22SectorCapacidad = new int[1] ;
         BC00047_A5EspectaculoId = new short[1] ;
         BC00047_A9SectorId = new short[1] ;
         BC00047_A12PaisCompraId = new short[1] ;
         BC00044_A8EspectaculoNombre = new string[] {""} ;
         BC00044_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC00045_A21SectorNombre = new string[] {""} ;
         BC00045_A23SectorPrecio = new int[1] ;
         BC00045_A22SectorCapacidad = new int[1] ;
         BC00046_A27PaisCompraNombre = new string[] {""} ;
         BC00048_A11EntradaId = new short[1] ;
         BC00043_A11EntradaId = new short[1] ;
         BC00043_A5EspectaculoId = new short[1] ;
         BC00043_A9SectorId = new short[1] ;
         BC00043_A12PaisCompraId = new short[1] ;
         sMode6 = "";
         BC00042_A11EntradaId = new short[1] ;
         BC00042_A5EspectaculoId = new short[1] ;
         BC00042_A9SectorId = new short[1] ;
         BC00042_A12PaisCompraId = new short[1] ;
         BC00049_A11EntradaId = new short[1] ;
         BC000412_A8EspectaculoNombre = new string[] {""} ;
         BC000412_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000413_A21SectorNombre = new string[] {""} ;
         BC000413_A23SectorPrecio = new int[1] ;
         BC000413_A22SectorCapacidad = new int[1] ;
         BC000414_A27PaisCompraNombre = new string[] {""} ;
         BC000415_A11EntradaId = new short[1] ;
         BC000415_A8EspectaculoNombre = new string[] {""} ;
         BC000415_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000415_A21SectorNombre = new string[] {""} ;
         BC000415_A23SectorPrecio = new int[1] ;
         BC000415_A27PaisCompraNombre = new string[] {""} ;
         BC000415_A22SectorCapacidad = new int[1] ;
         BC000415_A5EspectaculoId = new short[1] ;
         BC000415_A9SectorId = new short[1] ;
         BC000415_A12PaisCompraId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entrada_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A11EntradaId, BC00042_A5EspectaculoId, BC00042_A9SectorId, BC00042_A12PaisCompraId
               }
               , new Object[] {
               BC00043_A11EntradaId, BC00043_A5EspectaculoId, BC00043_A9SectorId, BC00043_A12PaisCompraId
               }
               , new Object[] {
               BC00044_A8EspectaculoNombre, BC00044_A19EspectaculoFecha
               }
               , new Object[] {
               BC00045_A21SectorNombre, BC00045_A23SectorPrecio, BC00045_A22SectorCapacidad
               }
               , new Object[] {
               BC00046_A27PaisCompraNombre
               }
               , new Object[] {
               BC00047_A11EntradaId, BC00047_A8EspectaculoNombre, BC00047_A19EspectaculoFecha, BC00047_A21SectorNombre, BC00047_A23SectorPrecio, BC00047_A27PaisCompraNombre, BC00047_A22SectorCapacidad, BC00047_A5EspectaculoId, BC00047_A9SectorId, BC00047_A12PaisCompraId
               }
               , new Object[] {
               BC00048_A11EntradaId
               }
               , new Object[] {
               BC00049_A11EntradaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000412_A8EspectaculoNombre, BC000412_A19EspectaculoFecha
               }
               , new Object[] {
               BC000413_A21SectorNombre, BC000413_A23SectorPrecio, BC000413_A22SectorCapacidad
               }
               , new Object[] {
               BC000414_A27PaisCompraNombre
               }
               , new Object[] {
               BC000415_A11EntradaId, BC000415_A8EspectaculoNombre, BC000415_A19EspectaculoFecha, BC000415_A21SectorNombre, BC000415_A23SectorPrecio, BC000415_A27PaisCompraNombre, BC000415_A22SectorCapacidad, BC000415_A5EspectaculoId, BC000415_A9SectorId, BC000415_A12PaisCompraId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z11EntradaId ;
      private short A11EntradaId ;
      private short GX_JID ;
      private short Z5EspectaculoId ;
      private short A5EspectaculoId ;
      private short Z9SectorId ;
      private short A9SectorId ;
      private short Z12PaisCompraId ;
      private short A12PaisCompraId ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private int trnEnded ;
      private int Z25SectorEntradasVendidas ;
      private int A25SectorEntradasVendidas ;
      private int Z24SectorEntradasDisponibles ;
      private int A24SectorEntradasDisponibles ;
      private int Z23SectorPrecio ;
      private int A23SectorPrecio ;
      private int Z22SectorCapacidad ;
      private int A22SectorCapacidad ;
      private int O25SectorEntradasVendidas ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z8EspectaculoNombre ;
      private string A8EspectaculoNombre ;
      private string Z21SectorNombre ;
      private string A21SectorNombre ;
      private string Z27PaisCompraNombre ;
      private string A27PaisCompraNombre ;
      private string sMode6 ;
      private DateTime Z19EspectaculoFecha ;
      private DateTime A19EspectaculoFecha ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool mustCommit ;
      private SdtEntrada bcEntrada ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00047_A11EntradaId ;
      private string[] BC00047_A8EspectaculoNombre ;
      private DateTime[] BC00047_A19EspectaculoFecha ;
      private string[] BC00047_A21SectorNombre ;
      private int[] BC00047_A23SectorPrecio ;
      private string[] BC00047_A27PaisCompraNombre ;
      private int[] BC00047_A22SectorCapacidad ;
      private short[] BC00047_A5EspectaculoId ;
      private short[] BC00047_A9SectorId ;
      private short[] BC00047_A12PaisCompraId ;
      private string[] BC00044_A8EspectaculoNombre ;
      private DateTime[] BC00044_A19EspectaculoFecha ;
      private string[] BC00045_A21SectorNombre ;
      private int[] BC00045_A23SectorPrecio ;
      private int[] BC00045_A22SectorCapacidad ;
      private string[] BC00046_A27PaisCompraNombre ;
      private short[] BC00048_A11EntradaId ;
      private short[] BC00043_A11EntradaId ;
      private short[] BC00043_A5EspectaculoId ;
      private short[] BC00043_A9SectorId ;
      private short[] BC00043_A12PaisCompraId ;
      private short[] BC00042_A11EntradaId ;
      private short[] BC00042_A5EspectaculoId ;
      private short[] BC00042_A9SectorId ;
      private short[] BC00042_A12PaisCompraId ;
      private short[] BC00049_A11EntradaId ;
      private string[] BC000412_A8EspectaculoNombre ;
      private DateTime[] BC000412_A19EspectaculoFecha ;
      private string[] BC000413_A21SectorNombre ;
      private int[] BC000413_A23SectorPrecio ;
      private int[] BC000413_A22SectorCapacidad ;
      private string[] BC000414_A27PaisCompraNombre ;
      private short[] BC000415_A11EntradaId ;
      private string[] BC000415_A8EspectaculoNombre ;
      private DateTime[] BC000415_A19EspectaculoFecha ;
      private string[] BC000415_A21SectorNombre ;
      private int[] BC000415_A23SectorPrecio ;
      private string[] BC000415_A27PaisCompraNombre ;
      private int[] BC000415_A22SectorCapacidad ;
      private short[] BC000415_A5EspectaculoId ;
      private short[] BC000415_A9SectorId ;
      private short[] BC000415_A12PaisCompraId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class entrada_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00047;
          prmBC00047 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00045;
          prmBC00045 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@PaisCompraId",GXType.Int16,4,0)
          };
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@PaisCompraId",GXType.Int16,4,0)
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@PaisCompraId",GXType.Int16,4,0) ,
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC000411;
          prmBC000411 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC000412;
          prmBC000412 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000413;
          prmBC000413 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000414;
          prmBC000414 = new Object[] {
          new ParDef("@PaisCompraId",GXType.Int16,4,0)
          };
          Object[] prmBC000415;
          prmBC000415 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT [EntradaId], [EspectaculoId], [SectorId], [PaisCompraId] AS PaisCompraId FROM [Entrada] WITH (UPDLOCK) WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT [EntradaId], [EspectaculoId], [SectorId], [PaisCompraId] AS PaisCompraId FROM [Entrada] WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT [EspectaculoNombre], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00045", "SELECT [SectorNombre], [SectorPrecio], [SectorCapacidad] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "SELECT [PaisNombre] AS PaisCompraNombre FROM [Pais] WHERE [PaisId] = @PaisCompraId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00047", "SELECT TM1.[EntradaId], T2.[EspectaculoNombre], T2.[EspectaculoFecha], T3.[SectorNombre], T3.[SectorPrecio], T4.[PaisNombre] AS PaisCompraNombre, T3.[SectorCapacidad], TM1.[EspectaculoId], TM1.[SectorId], TM1.[PaisCompraId] AS PaisCompraId FROM ((([Entrada] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) INNER JOIN [EspectaculoSector] T3 ON T3.[EspectaculoId] = TM1.[EspectaculoId] AND T3.[SectorId] = TM1.[SectorId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = TM1.[PaisCompraId]) WHERE TM1.[EntradaId] = @EntradaId ORDER BY TM1.[EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00048", "SELECT [EntradaId] FROM [Entrada] WHERE [EntradaId] = @EntradaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00049", "INSERT INTO [Entrada]([EspectaculoId], [SectorId], [PaisCompraId]) VALUES(@EspectaculoId, @SectorId, @PaisCompraId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00049,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000410", "UPDATE [Entrada] SET [EspectaculoId]=@EspectaculoId, [SectorId]=@SectorId, [PaisCompraId]=@PaisCompraId  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmBC000410)
             ,new CursorDef("BC000411", "DELETE FROM [Entrada]  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmBC000411)
             ,new CursorDef("BC000412", "SELECT [EspectaculoNombre], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000412,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000413", "SELECT [SectorNombre], [SectorPrecio], [SectorCapacidad] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000413,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000414", "SELECT [PaisNombre] AS PaisCompraNombre FROM [Pais] WHERE [PaisId] = @PaisCompraId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000414,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000415", "SELECT TM1.[EntradaId], T2.[EspectaculoNombre], T2.[EspectaculoFecha], T3.[SectorNombre], T3.[SectorPrecio], T4.[PaisNombre] AS PaisCompraNombre, T3.[SectorCapacidad], TM1.[EspectaculoId], TM1.[SectorId], TM1.[PaisCompraId] AS PaisCompraId FROM ((([Entrada] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) INNER JOIN [EspectaculoSector] T3 ON T3.[EspectaculoId] = TM1.[EspectaculoId] AND T3.[SectorId] = TM1.[SectorId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = TM1.[PaisCompraId]) WHERE TM1.[EntradaId] = @EntradaId ORDER BY TM1.[EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                return;
       }
    }

 }

}
