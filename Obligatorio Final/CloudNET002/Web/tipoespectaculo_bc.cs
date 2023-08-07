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
   public class tipoespectaculo_bc : GxSilentTrn, IGxSilentTrn
   {
      public tipoespectaculo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public tipoespectaculo_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<SdtTipoEspectaculo> GetAll( int Start ,
                                                        int Count )
      {
         GXPagingFrom8 = Start;
         GXPagingTo8 = Count;
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {GXPagingFrom8, GXPagingTo8});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A6TipoEspectaculoId = BC00064_A6TipoEspectaculoId[0];
            A16TipoEspectaculoNombre = BC00064_A16TipoEspectaculoNombre[0];
         }
         bcTipoEspectaculo = new SdtTipoEspectaculo(context);
         gx_restcollection.Clear();
         while ( RcdFound8 != 0 )
         {
            OnLoadActions068( ) ;
            AddRow068( ) ;
            gx_sdt_item = (SdtTipoEspectaculo)(bcTipoEspectaculo.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(2);
            RcdFound8 = 0;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(2) != 101) )
            {
               RcdFound8 = 1;
               A6TipoEspectaculoId = BC00064_A6TipoEspectaculoId[0];
               A16TipoEspectaculoNombre = BC00064_A16TipoEspectaculoNombre[0];
            }
            Gx_mode = sMode8;
         }
         pr_default.close(2);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM068( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow068( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey068( ) ;
         standaloneModal( ) ;
         AddRow068( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z6TipoEspectaculoId = A6TipoEspectaculoId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls068( ) ;
            }
            else
            {
               CheckExtendedTable068( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors068( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM068( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z16TipoEspectaculoNombre = A16TipoEspectaculoNombre;
         }
         if ( GX_JID == -1 )
         {
            Z6TipoEspectaculoId = A6TipoEspectaculoId;
            Z16TipoEspectaculoNombre = A16TipoEspectaculoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load068( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A6TipoEspectaculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
            A16TipoEspectaculoNombre = BC00065_A16TipoEspectaculoNombre[0];
            ZM068( -1) ;
         }
         pr_default.close(3);
         OnLoadActions068( ) ;
      }

      protected void OnLoadActions068( )
      {
      }

      protected void CheckExtendedTable068( )
      {
         nIsDirty_8 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A16TipoEspectaculoNombre, A6TipoEspectaculoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Tipo Espectaculo Nombre"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors068( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey068( )
      {
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {A6TipoEspectaculoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A6TipoEspectaculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM068( 1) ;
            RcdFound8 = 1;
            A6TipoEspectaculoId = BC00063_A6TipoEspectaculoId[0];
            A16TipoEspectaculoNombre = BC00063_A16TipoEspectaculoNombre[0];
            Z6TipoEspectaculoId = A6TipoEspectaculoId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load068( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey068( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey068( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey068( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_060( ) ;
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

      protected void CheckOptimisticConcurrency068( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A6TipoEspectaculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoEspectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z16TipoEspectaculoNombre, BC00062_A16TipoEspectaculoNombre[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoEspectaculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert068( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable068( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM068( 0) ;
            CheckOptimisticConcurrency068( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm068( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert068( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00068 */
                     pr_default.execute(6, new Object[] {A16TipoEspectaculoNombre});
                     A6TipoEspectaculoId = BC00068_A6TipoEspectaculoId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
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
               Load068( ) ;
            }
            EndLevel068( ) ;
         }
         CloseExtendedTableCursors068( ) ;
      }

      protected void Update068( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable068( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency068( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm068( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate068( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00069 */
                     pr_default.execute(7, new Object[] {A16TipoEspectaculoNombre, A6TipoEspectaculoId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoEspectaculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate068( ) ;
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
            EndLevel068( ) ;
         }
         CloseExtendedTableCursors068( ) ;
      }

      protected void DeferredUpdate068( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency068( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls068( ) ;
            AfterConfirm068( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete068( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000610 */
                  pr_default.execute(8, new Object[] {A6TipoEspectaculoId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel068( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls068( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000611 */
            pr_default.execute(9, new Object[] {A6TipoEspectaculoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Espectaculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel068( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete068( ) ;
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

      public void ScanKeyStart068( )
      {
         /* Scan By routine */
         /* Using cursor BC000612 */
         pr_default.execute(10, new Object[] {A6TipoEspectaculoId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A6TipoEspectaculoId = BC000612_A6TipoEspectaculoId[0];
            A16TipoEspectaculoNombre = BC000612_A16TipoEspectaculoNombre[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext068( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound8 = 0;
         ScanKeyLoad068( ) ;
      }

      protected void ScanKeyLoad068( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A6TipoEspectaculoId = BC000612_A6TipoEspectaculoId[0];
            A16TipoEspectaculoNombre = BC000612_A16TipoEspectaculoNombre[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd068( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm068( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert068( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate068( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete068( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete068( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate068( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes068( )
      {
      }

      protected void send_integrity_lvl_hashes068( )
      {
      }

      protected void AddRow068( )
      {
         VarsToRow8( bcTipoEspectaculo) ;
      }

      protected void ReadRow068( )
      {
         RowToVars8( bcTipoEspectaculo, 1) ;
      }

      protected void InitializeNonKey068( )
      {
         A16TipoEspectaculoNombre = "";
         Z16TipoEspectaculoNombre = "";
      }

      protected void InitAll068( )
      {
         A6TipoEspectaculoId = 0;
         InitializeNonKey068( ) ;
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

      public void VarsToRow8( SdtTipoEspectaculo obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Tipoespectaculonombre = A16TipoEspectaculoNombre;
         obj8.gxTpr_Tipoespectaculoid = A6TipoEspectaculoId;
         obj8.gxTpr_Tipoespectaculoid_Z = Z6TipoEspectaculoId;
         obj8.gxTpr_Tipoespectaculonombre_Z = Z16TipoEspectaculoNombre;
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( SdtTipoEspectaculo obj8 )
      {
         obj8.gxTpr_Tipoespectaculoid = A6TipoEspectaculoId;
         return  ;
      }

      public void RowToVars8( SdtTipoEspectaculo obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A16TipoEspectaculoNombre = obj8.gxTpr_Tipoespectaculonombre;
         A6TipoEspectaculoId = obj8.gxTpr_Tipoespectaculoid;
         Z6TipoEspectaculoId = obj8.gxTpr_Tipoespectaculoid_Z;
         Z16TipoEspectaculoNombre = obj8.gxTpr_Tipoespectaculonombre_Z;
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A6TipoEspectaculoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey068( ) ;
         ScanKeyStart068( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z6TipoEspectaculoId = A6TipoEspectaculoId;
         }
         ZM068( -1) ;
         OnLoadActions068( ) ;
         AddRow068( ) ;
         ScanKeyEnd068( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcTipoEspectaculo, 0) ;
         ScanKeyStart068( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z6TipoEspectaculoId = A6TipoEspectaculoId;
         }
         ZM068( -1) ;
         OnLoadActions068( ) ;
         AddRow068( ) ;
         ScanKeyEnd068( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey068( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert068( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A6TipoEspectaculoId != Z6TipoEspectaculoId )
               {
                  A6TipoEspectaculoId = Z6TipoEspectaculoId;
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
                  Update068( ) ;
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
                  if ( A6TipoEspectaculoId != Z6TipoEspectaculoId )
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
                        Insert068( ) ;
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
                        Insert068( ) ;
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
         RowToVars8( bcTipoEspectaculo, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcTipoEspectaculo) ;
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
         RowToVars8( bcTipoEspectaculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert068( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcTipoEspectaculo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow8( bcTipoEspectaculo) ;
         }
         else
         {
            SdtTipoEspectaculo auxBC = new SdtTipoEspectaculo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A6TipoEspectaculoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTipoEspectaculo);
               auxBC.Save();
               bcTipoEspectaculo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars8( bcTipoEspectaculo, 1) ;
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
         RowToVars8( bcTipoEspectaculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert068( ) ;
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
               VarsToRow8( bcTipoEspectaculo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow8( bcTipoEspectaculo) ;
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
         RowToVars8( bcTipoEspectaculo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey068( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A6TipoEspectaculoId != Z6TipoEspectaculoId )
            {
               A6TipoEspectaculoId = Z6TipoEspectaculoId;
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
            if ( A6TipoEspectaculoId != Z6TipoEspectaculoId )
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
         context.RollbackDataStores("tipoespectaculo_bc",pr_default);
         VarsToRow8( bcTipoEspectaculo) ;
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
         Gx_mode = bcTipoEspectaculo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTipoEspectaculo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTipoEspectaculo )
         {
            bcTipoEspectaculo = (SdtTipoEspectaculo)(sdt);
            if ( StringUtil.StrCmp(bcTipoEspectaculo.gxTpr_Mode, "") == 0 )
            {
               bcTipoEspectaculo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcTipoEspectaculo) ;
            }
            else
            {
               RowToVars8( bcTipoEspectaculo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTipoEspectaculo.gxTpr_Mode, "") == 0 )
            {
               bcTipoEspectaculo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcTipoEspectaculo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTipoEspectaculo TipoEspectaculo_BC
      {
         get {
            return bcTipoEspectaculo ;
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
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         BC00064_A6TipoEspectaculoId = new short[1] ;
         BC00064_A16TipoEspectaculoNombre = new string[] {""} ;
         A16TipoEspectaculoNombre = "";
         gx_restcollection = new GXBCCollection<SdtTipoEspectaculo>( context, "TipoEspectaculo", "ObligatorioFinal");
         sMode8 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z16TipoEspectaculoNombre = "";
         BC00065_A6TipoEspectaculoId = new short[1] ;
         BC00065_A16TipoEspectaculoNombre = new string[] {""} ;
         BC00066_A16TipoEspectaculoNombre = new string[] {""} ;
         BC00067_A6TipoEspectaculoId = new short[1] ;
         BC00063_A6TipoEspectaculoId = new short[1] ;
         BC00063_A16TipoEspectaculoNombre = new string[] {""} ;
         BC00062_A6TipoEspectaculoId = new short[1] ;
         BC00062_A16TipoEspectaculoNombre = new string[] {""} ;
         BC00068_A6TipoEspectaculoId = new short[1] ;
         BC000611_A5EspectaculoId = new short[1] ;
         BC000612_A6TipoEspectaculoId = new short[1] ;
         BC000612_A16TipoEspectaculoNombre = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipoespectaculo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A6TipoEspectaculoId, BC00062_A16TipoEspectaculoNombre
               }
               , new Object[] {
               BC00063_A6TipoEspectaculoId, BC00063_A16TipoEspectaculoNombre
               }
               , new Object[] {
               BC00064_A6TipoEspectaculoId, BC00064_A16TipoEspectaculoNombre
               }
               , new Object[] {
               BC00065_A6TipoEspectaculoId, BC00065_A16TipoEspectaculoNombre
               }
               , new Object[] {
               BC00066_A16TipoEspectaculoNombre
               }
               , new Object[] {
               BC00067_A6TipoEspectaculoId
               }
               , new Object[] {
               BC00068_A6TipoEspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000611_A5EspectaculoId
               }
               , new Object[] {
               BC000612_A6TipoEspectaculoId, BC000612_A16TipoEspectaculoNombre
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short RcdFound8 ;
      private short A6TipoEspectaculoId ;
      private short Z6TipoEspectaculoId ;
      private short GX_JID ;
      private short nIsDirty_8 ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom8 ;
      private int GXPagingTo8 ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string A16TipoEspectaculoNombre ;
      private string sMode8 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z16TipoEspectaculoNombre ;
      private bool returnInSub ;
      private bool mustCommit ;
      private GXBCCollection<SdtTipoEspectaculo> gx_restcollection ;
      private SdtTipoEspectaculo bcTipoEspectaculo ;
      private SdtTipoEspectaculo gx_sdt_item ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00064_A6TipoEspectaculoId ;
      private string[] BC00064_A16TipoEspectaculoNombre ;
      private short[] BC00065_A6TipoEspectaculoId ;
      private string[] BC00065_A16TipoEspectaculoNombre ;
      private string[] BC00066_A16TipoEspectaculoNombre ;
      private short[] BC00067_A6TipoEspectaculoId ;
      private short[] BC00063_A6TipoEspectaculoId ;
      private string[] BC00063_A16TipoEspectaculoNombre ;
      private short[] BC00062_A6TipoEspectaculoId ;
      private string[] BC00062_A16TipoEspectaculoNombre ;
      private short[] BC00068_A6TipoEspectaculoId ;
      private short[] BC000611_A5EspectaculoId ;
      private short[] BC000612_A6TipoEspectaculoId ;
      private string[] BC000612_A16TipoEspectaculoNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tipoespectaculo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@GXPagingFrom8",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo8",GXType.Int32,9,0)
          };
          Object[] prmBC00065;
          prmBC00065 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00066;
          prmBC00066 = new Object[] {
          new ParDef("@TipoEspectaculoNombre",GXType.NChar,60,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00067;
          prmBC00067 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@TipoEspectaculoNombre",GXType.NChar,60,0)
          };
          Object[] prmBC00069;
          prmBC00069 = new Object[] {
          new ParDef("@TipoEspectaculoNombre",GXType.NChar,60,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000610;
          prmBC000610 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000611;
          prmBC000611 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000612;
          prmBC000612 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] WITH (UPDLOCK) WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT TM1.[TipoEspectaculoId], TM1.[TipoEspectaculoNombre] FROM [TipoEspectaculo] TM1 ORDER BY TM1.[TipoEspectaculoId]  OFFSET @GXPagingFrom8 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo8 > 0 THEN @GXPagingTo8 ELSE 1e9 END) AS INTEGER) ROWS ONLY",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00065", "SELECT TM1.[TipoEspectaculoId], TM1.[TipoEspectaculoNombre] FROM [TipoEspectaculo] TM1 WHERE TM1.[TipoEspectaculoId] = @TipoEspectaculoId ORDER BY TM1.[TipoEspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00066", "SELECT [TipoEspectaculoNombre] FROM [TipoEspectaculo] WHERE ([TipoEspectaculoNombre] = @TipoEspectaculoNombre) AND (Not ( [TipoEspectaculoId] = @TipoEspectaculoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00067", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00068", "INSERT INTO [TipoEspectaculo]([TipoEspectaculoNombre]) VALUES(@TipoEspectaculoNombre); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00068,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00069", "UPDATE [TipoEspectaculo] SET [TipoEspectaculoNombre]=@TipoEspectaculoNombre  WHERE [TipoEspectaculoId] = @TipoEspectaculoId", GxErrorMask.GX_NOMASK,prmBC00069)
             ,new CursorDef("BC000610", "DELETE FROM [TipoEspectaculo]  WHERE [TipoEspectaculoId] = @TipoEspectaculoId", GxErrorMask.GX_NOMASK,prmBC000610)
             ,new CursorDef("BC000611", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000612", "SELECT TM1.[TipoEspectaculoId], TM1.[TipoEspectaculoNombre] FROM [TipoEspectaculo] TM1 WHERE TM1.[TipoEspectaculoId] = @TipoEspectaculoId ORDER BY TM1.[TipoEspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
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
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
       }
    }

 }

}
