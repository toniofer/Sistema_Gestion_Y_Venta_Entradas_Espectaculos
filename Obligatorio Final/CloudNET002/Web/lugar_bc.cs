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
   public class lugar_bc : GxSilentTrn, IGxSilentTrn
   {
      public lugar_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public lugar_bc( IGxContext context )
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
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
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
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z3LugarId = A3LugarId;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
                  ZM022( 3) ;
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z4LugarNombre = A4LugarNombre;
            Z18LugarDireccion = A18LugarDireccion;
            Z1PaisId = A1PaisId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z2PaisNombre = A2PaisNombre;
         }
         if ( GX_JID == -1 )
         {
            Z3LugarId = A3LugarId;
            Z4LugarNombre = A4LugarNombre;
            Z44LugarFoto = A44LugarFoto;
            Z40000LugarFoto_GXI = A40000LugarFoto_GXI;
            Z18LugarDireccion = A18LugarDireccion;
            Z1PaisId = A1PaisId;
            Z2PaisNombre = A2PaisNombre;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A3LugarId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A4LugarNombre = BC00025_A4LugarNombre[0];
            A40000LugarFoto_GXI = BC00025_A40000LugarFoto_GXI[0];
            n40000LugarFoto_GXI = BC00025_n40000LugarFoto_GXI[0];
            A2PaisNombre = BC00025_A2PaisNombre[0];
            A18LugarDireccion = BC00025_A18LugarDireccion[0];
            A1PaisId = BC00025_A1PaisId[0];
            A44LugarFoto = BC00025_A44LugarFoto[0];
            n44LugarFoto = BC00025_n44LugarFoto[0];
            ZM022( -1) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {A4LugarNombre, A3LugarId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Lugar Nombre"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A1PaisId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A2PaisNombre = BC00024_A2PaisNombre[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00027 */
         pr_default.execute(5, new Object[] {A3LugarId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A3LugarId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 1) ;
            RcdFound2 = 1;
            A3LugarId = BC00023_A3LugarId[0];
            A4LugarNombre = BC00023_A4LugarNombre[0];
            A40000LugarFoto_GXI = BC00023_A40000LugarFoto_GXI[0];
            n40000LugarFoto_GXI = BC00023_n40000LugarFoto_GXI[0];
            A18LugarDireccion = BC00023_A18LugarDireccion[0];
            A1PaisId = BC00023_A1PaisId[0];
            A44LugarFoto = BC00023_A44LugarFoto[0];
            n44LugarFoto = BC00023_n44LugarFoto[0];
            Z3LugarId = A3LugarId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         CONFIRM_020( ) ;
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

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A3LugarId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lugar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z4LugarNombre, BC00022_A4LugarNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z18LugarDireccion, BC00022_A18LugarDireccion[0]) != 0 ) || ( Z1PaisId != BC00022_A1PaisId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Lugar"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00028 */
                     pr_default.execute(6, new Object[] {A4LugarNombre, n44LugarFoto, A44LugarFoto, n40000LugarFoto_GXI, A40000LugarFoto_GXI, A18LugarDireccion, A1PaisId});
                     A3LugarId = BC00028_A3LugarId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Lugar");
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00029 */
                     pr_default.execute(7, new Object[] {A4LugarNombre, A18LugarDireccion, A1PaisId, A3LugarId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Lugar");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lugar"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000210 */
            pr_default.execute(8, new Object[] {n44LugarFoto, A44LugarFoto, n40000LugarFoto_GXI, A40000LugarFoto_GXI, A3LugarId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Lugar");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000211 */
                  pr_default.execute(9, new Object[] {A3LugarId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Lugar");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000212 */
            pr_default.execute(10, new Object[] {A1PaisId});
            A2PaisNombre = BC000212_A2PaisNombre[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000213 */
            pr_default.execute(11, new Object[] {A3LugarId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Espectaculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
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

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000214 */
         pr_default.execute(12, new Object[] {A3LugarId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A3LugarId = BC000214_A3LugarId[0];
            A4LugarNombre = BC000214_A4LugarNombre[0];
            A40000LugarFoto_GXI = BC000214_A40000LugarFoto_GXI[0];
            n40000LugarFoto_GXI = BC000214_n40000LugarFoto_GXI[0];
            A2PaisNombre = BC000214_A2PaisNombre[0];
            A18LugarDireccion = BC000214_A18LugarDireccion[0];
            A1PaisId = BC000214_A1PaisId[0];
            A44LugarFoto = BC000214_A44LugarFoto[0];
            n44LugarFoto = BC000214_n44LugarFoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A3LugarId = BC000214_A3LugarId[0];
            A4LugarNombre = BC000214_A4LugarNombre[0];
            A40000LugarFoto_GXI = BC000214_A40000LugarFoto_GXI[0];
            n40000LugarFoto_GXI = BC000214_n40000LugarFoto_GXI[0];
            A2PaisNombre = BC000214_A2PaisNombre[0];
            A18LugarDireccion = BC000214_A18LugarDireccion[0];
            A1PaisId = BC000214_A1PaisId[0];
            A44LugarFoto = BC000214_A44LugarFoto[0];
            n44LugarFoto = BC000214_n44LugarFoto[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcLugar) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcLugar, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A4LugarNombre = "";
         A44LugarFoto = "";
         n44LugarFoto = false;
         A40000LugarFoto_GXI = "";
         n40000LugarFoto_GXI = false;
         A1PaisId = 0;
         A2PaisNombre = "";
         A18LugarDireccion = "";
         Z4LugarNombre = "";
         Z18LugarDireccion = "";
         Z1PaisId = 0;
      }

      protected void InitAll022( )
      {
         A3LugarId = 0;
         InitializeNonKey022( ) ;
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

      public void VarsToRow2( SdtLugar obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Lugarnombre = A4LugarNombre;
         obj2.gxTpr_Lugarfoto = A44LugarFoto;
         obj2.gxTpr_Lugarfoto_gxi = A40000LugarFoto_GXI;
         obj2.gxTpr_Paisid = A1PaisId;
         obj2.gxTpr_Paisnombre = A2PaisNombre;
         obj2.gxTpr_Lugardireccion = A18LugarDireccion;
         obj2.gxTpr_Lugarid = A3LugarId;
         obj2.gxTpr_Lugarid_Z = Z3LugarId;
         obj2.gxTpr_Lugarnombre_Z = Z4LugarNombre;
         obj2.gxTpr_Paisid_Z = Z1PaisId;
         obj2.gxTpr_Paisnombre_Z = Z2PaisNombre;
         obj2.gxTpr_Lugardireccion_Z = Z18LugarDireccion;
         obj2.gxTpr_Lugarfoto_gxi_Z = Z40000LugarFoto_GXI;
         obj2.gxTpr_Lugarfoto_N = (short)(Convert.ToInt16(n44LugarFoto));
         obj2.gxTpr_Lugarfoto_gxi_N = (short)(Convert.ToInt16(n40000LugarFoto_GXI));
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( SdtLugar obj2 )
      {
         obj2.gxTpr_Lugarid = A3LugarId;
         return  ;
      }

      public void RowToVars2( SdtLugar obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A4LugarNombre = obj2.gxTpr_Lugarnombre;
         A44LugarFoto = obj2.gxTpr_Lugarfoto;
         n44LugarFoto = false;
         A40000LugarFoto_GXI = obj2.gxTpr_Lugarfoto_gxi;
         n40000LugarFoto_GXI = false;
         A1PaisId = obj2.gxTpr_Paisid;
         A2PaisNombre = obj2.gxTpr_Paisnombre;
         A18LugarDireccion = obj2.gxTpr_Lugardireccion;
         A3LugarId = obj2.gxTpr_Lugarid;
         Z3LugarId = obj2.gxTpr_Lugarid_Z;
         Z4LugarNombre = obj2.gxTpr_Lugarnombre_Z;
         Z1PaisId = obj2.gxTpr_Paisid_Z;
         Z2PaisNombre = obj2.gxTpr_Paisnombre_Z;
         Z18LugarDireccion = obj2.gxTpr_Lugardireccion_Z;
         Z40000LugarFoto_GXI = obj2.gxTpr_Lugarfoto_gxi_Z;
         n44LugarFoto = (bool)(Convert.ToBoolean(obj2.gxTpr_Lugarfoto_N));
         n40000LugarFoto_GXI = (bool)(Convert.ToBoolean(obj2.gxTpr_Lugarfoto_gxi_N));
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A3LugarId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z3LugarId = A3LugarId;
         }
         ZM022( -1) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
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
         RowToVars2( bcLugar, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z3LugarId = A3LugarId;
         }
         ZM022( -1) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A3LugarId != Z3LugarId )
               {
                  A3LugarId = Z3LugarId;
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
                  Update022( ) ;
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
                  if ( A3LugarId != Z3LugarId )
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
                        Insert022( ) ;
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
                        Insert022( ) ;
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
         RowToVars2( bcLugar, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcLugar) ;
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
         RowToVars2( bcLugar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow2( bcLugar) ;
         }
         else
         {
            SdtLugar auxBC = new SdtLugar(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A3LugarId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLugar);
               auxBC.Save();
               bcLugar.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars2( bcLugar, 1) ;
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
         RowToVars2( bcLugar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
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
               VarsToRow2( bcLugar) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow2( bcLugar) ;
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
         RowToVars2( bcLugar, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A3LugarId != Z3LugarId )
            {
               A3LugarId = Z3LugarId;
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
            if ( A3LugarId != Z3LugarId )
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
         context.RollbackDataStores("lugar_bc",pr_default);
         VarsToRow2( bcLugar) ;
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
         Gx_mode = bcLugar.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLugar.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLugar )
         {
            bcLugar = (SdtLugar)(sdt);
            if ( StringUtil.StrCmp(bcLugar.gxTpr_Mode, "") == 0 )
            {
               bcLugar.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcLugar) ;
            }
            else
            {
               RowToVars2( bcLugar, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLugar.gxTpr_Mode, "") == 0 )
            {
               bcLugar.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcLugar, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtLugar Lugar_BC
      {
         get {
            return bcLugar ;
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
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z4LugarNombre = "";
         A4LugarNombre = "";
         Z18LugarDireccion = "";
         A18LugarDireccion = "";
         Z2PaisNombre = "";
         A2PaisNombre = "";
         Z44LugarFoto = "";
         A44LugarFoto = "";
         Z40000LugarFoto_GXI = "";
         A40000LugarFoto_GXI = "";
         BC00025_A3LugarId = new short[1] ;
         BC00025_A4LugarNombre = new string[] {""} ;
         BC00025_A40000LugarFoto_GXI = new string[] {""} ;
         BC00025_n40000LugarFoto_GXI = new bool[] {false} ;
         BC00025_A2PaisNombre = new string[] {""} ;
         BC00025_A18LugarDireccion = new string[] {""} ;
         BC00025_A1PaisId = new short[1] ;
         BC00025_A44LugarFoto = new string[] {""} ;
         BC00025_n44LugarFoto = new bool[] {false} ;
         BC00026_A4LugarNombre = new string[] {""} ;
         BC00024_A2PaisNombre = new string[] {""} ;
         BC00027_A3LugarId = new short[1] ;
         BC00023_A3LugarId = new short[1] ;
         BC00023_A4LugarNombre = new string[] {""} ;
         BC00023_A40000LugarFoto_GXI = new string[] {""} ;
         BC00023_n40000LugarFoto_GXI = new bool[] {false} ;
         BC00023_A18LugarDireccion = new string[] {""} ;
         BC00023_A1PaisId = new short[1] ;
         BC00023_A44LugarFoto = new string[] {""} ;
         BC00023_n44LugarFoto = new bool[] {false} ;
         sMode2 = "";
         BC00022_A3LugarId = new short[1] ;
         BC00022_A4LugarNombre = new string[] {""} ;
         BC00022_A40000LugarFoto_GXI = new string[] {""} ;
         BC00022_n40000LugarFoto_GXI = new bool[] {false} ;
         BC00022_A18LugarDireccion = new string[] {""} ;
         BC00022_A1PaisId = new short[1] ;
         BC00022_A44LugarFoto = new string[] {""} ;
         BC00022_n44LugarFoto = new bool[] {false} ;
         BC00028_A3LugarId = new short[1] ;
         BC000212_A2PaisNombre = new string[] {""} ;
         BC000213_A5EspectaculoId = new short[1] ;
         BC000214_A3LugarId = new short[1] ;
         BC000214_A4LugarNombre = new string[] {""} ;
         BC000214_A40000LugarFoto_GXI = new string[] {""} ;
         BC000214_n40000LugarFoto_GXI = new bool[] {false} ;
         BC000214_A2PaisNombre = new string[] {""} ;
         BC000214_A18LugarDireccion = new string[] {""} ;
         BC000214_A1PaisId = new short[1] ;
         BC000214_A44LugarFoto = new string[] {""} ;
         BC000214_n44LugarFoto = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.lugar_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A3LugarId, BC00022_A4LugarNombre, BC00022_A40000LugarFoto_GXI, BC00022_n40000LugarFoto_GXI, BC00022_A18LugarDireccion, BC00022_A1PaisId, BC00022_A44LugarFoto, BC00022_n44LugarFoto
               }
               , new Object[] {
               BC00023_A3LugarId, BC00023_A4LugarNombre, BC00023_A40000LugarFoto_GXI, BC00023_n40000LugarFoto_GXI, BC00023_A18LugarDireccion, BC00023_A1PaisId, BC00023_A44LugarFoto, BC00023_n44LugarFoto
               }
               , new Object[] {
               BC00024_A2PaisNombre
               }
               , new Object[] {
               BC00025_A3LugarId, BC00025_A4LugarNombre, BC00025_A40000LugarFoto_GXI, BC00025_n40000LugarFoto_GXI, BC00025_A2PaisNombre, BC00025_A18LugarDireccion, BC00025_A1PaisId, BC00025_A44LugarFoto, BC00025_n44LugarFoto
               }
               , new Object[] {
               BC00026_A4LugarNombre
               }
               , new Object[] {
               BC00027_A3LugarId
               }
               , new Object[] {
               BC00028_A3LugarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000212_A2PaisNombre
               }
               , new Object[] {
               BC000213_A5EspectaculoId
               }
               , new Object[] {
               BC000214_A3LugarId, BC000214_A4LugarNombre, BC000214_A40000LugarFoto_GXI, BC000214_n40000LugarFoto_GXI, BC000214_A2PaisNombre, BC000214_A18LugarDireccion, BC000214_A1PaisId, BC000214_A44LugarFoto, BC000214_n44LugarFoto
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z3LugarId ;
      private short A3LugarId ;
      private short GX_JID ;
      private short Z1PaisId ;
      private short A1PaisId ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z4LugarNombre ;
      private string A4LugarNombre ;
      private string Z18LugarDireccion ;
      private string A18LugarDireccion ;
      private string Z2PaisNombre ;
      private string A2PaisNombre ;
      private string sMode2 ;
      private bool returnInSub ;
      private bool n40000LugarFoto_GXI ;
      private bool n44LugarFoto ;
      private bool mustCommit ;
      private string Z40000LugarFoto_GXI ;
      private string A40000LugarFoto_GXI ;
      private string Z44LugarFoto ;
      private string A44LugarFoto ;
      private SdtLugar bcLugar ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00025_A3LugarId ;
      private string[] BC00025_A4LugarNombre ;
      private string[] BC00025_A40000LugarFoto_GXI ;
      private bool[] BC00025_n40000LugarFoto_GXI ;
      private string[] BC00025_A2PaisNombre ;
      private string[] BC00025_A18LugarDireccion ;
      private short[] BC00025_A1PaisId ;
      private string[] BC00025_A44LugarFoto ;
      private bool[] BC00025_n44LugarFoto ;
      private string[] BC00026_A4LugarNombre ;
      private string[] BC00024_A2PaisNombre ;
      private short[] BC00027_A3LugarId ;
      private short[] BC00023_A3LugarId ;
      private string[] BC00023_A4LugarNombre ;
      private string[] BC00023_A40000LugarFoto_GXI ;
      private bool[] BC00023_n40000LugarFoto_GXI ;
      private string[] BC00023_A18LugarDireccion ;
      private short[] BC00023_A1PaisId ;
      private string[] BC00023_A44LugarFoto ;
      private bool[] BC00023_n44LugarFoto ;
      private short[] BC00022_A3LugarId ;
      private string[] BC00022_A4LugarNombre ;
      private string[] BC00022_A40000LugarFoto_GXI ;
      private bool[] BC00022_n40000LugarFoto_GXI ;
      private string[] BC00022_A18LugarDireccion ;
      private short[] BC00022_A1PaisId ;
      private string[] BC00022_A44LugarFoto ;
      private bool[] BC00022_n44LugarFoto ;
      private short[] BC00028_A3LugarId ;
      private string[] BC000212_A2PaisNombre ;
      private short[] BC000213_A5EspectaculoId ;
      private short[] BC000214_A3LugarId ;
      private string[] BC000214_A4LugarNombre ;
      private string[] BC000214_A40000LugarFoto_GXI ;
      private bool[] BC000214_n40000LugarFoto_GXI ;
      private string[] BC000214_A2PaisNombre ;
      private string[] BC000214_A18LugarDireccion ;
      private short[] BC000214_A1PaisId ;
      private string[] BC000214_A44LugarFoto ;
      private bool[] BC000214_n44LugarFoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class lugar_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@LugarNombre",GXType.NChar,60,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@LugarNombre",GXType.NChar,60,0) ,
          new ParDef("@LugarFoto",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
          new ParDef("@LugarFoto_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=1, Tbl="Lugar", Fld="LugarFoto"} ,
          new ParDef("@LugarDireccion",GXType.NChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@LugarNombre",GXType.NChar,60,0) ,
          new ParDef("@LugarDireccion",GXType.NChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@LugarFoto",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
          new ParDef("@LugarFoto_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Lugar", Fld="LugarFoto"} ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000213;
          prmBC000213 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000214;
          prmBC000214 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [LugarId], [LugarNombre], [LugarFoto_GXI], [LugarDireccion], [PaisId], [LugarFoto] FROM [Lugar] WITH (UPDLOCK) WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [LugarId], [LugarNombre], [LugarFoto_GXI], [LugarDireccion], [PaisId], [LugarFoto] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT TM1.[LugarId], TM1.[LugarNombre], TM1.[LugarFoto_GXI], T2.[PaisNombre], TM1.[LugarDireccion], TM1.[PaisId], TM1.[LugarFoto] FROM ([Lugar] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisId]) WHERE TM1.[LugarId] = @LugarId ORDER BY TM1.[LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT [LugarNombre] FROM [Lugar] WHERE ([LugarNombre] = @LugarNombre) AND (Not ( [LugarId] = @LugarId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00028", "INSERT INTO [Lugar]([LugarNombre], [LugarFoto], [LugarFoto_GXI], [LugarDireccion], [PaisId]) VALUES(@LugarNombre, @LugarFoto, @LugarFoto_GXI, @LugarDireccion, @PaisId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00029", "UPDATE [Lugar] SET [LugarNombre]=@LugarNombre, [LugarDireccion]=@LugarDireccion, [PaisId]=@PaisId  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmBC00029)
             ,new CursorDef("BC000210", "UPDATE [Lugar] SET [LugarFoto]=@LugarFoto, [LugarFoto_GXI]=@LugarFoto_GXI  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmBC000210)
             ,new CursorDef("BC000211", "DELETE FROM [Lugar]  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmBC000211)
             ,new CursorDef("BC000212", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000213", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000214", "SELECT TM1.[LugarId], TM1.[LugarNombre], TM1.[LugarFoto_GXI], T2.[PaisNombre], TM1.[LugarDireccion], TM1.[PaisId], TM1.[LugarFoto] FROM ([Lugar] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisId]) WHERE TM1.[LugarId] = @LugarId ORDER BY TM1.[LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 40);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 40);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 60);
                ((string[]) buf[5])[0] = rslt.getString(5, 40);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 60);
                ((string[]) buf[5])[0] = rslt.getString(5, 40);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
