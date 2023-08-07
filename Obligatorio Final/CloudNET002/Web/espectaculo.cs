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
   public class espectaculo : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_34") == 0 )
         {
            A6TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A6TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A6TipoEspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_34( A6TipoEspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_35") == 0 )
         {
            A3LugarId = (short)(Math.Round(NumberUtil.Val( GetPar( "LugarId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A3LugarId", StringUtil.LTrimStr( (decimal)(A3LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_35( A3LugarId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_37") == 0 )
         {
            A1PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1PaisId", StringUtil.LTrimStr( (decimal)(A1PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_37( A1PaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_36") == 0 )
         {
            A7PaisOrigenId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisOrigenId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7PaisOrigenId", StringUtil.LTrimStr( (decimal)(A7PaisOrigenId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_36( A7PaisOrigenId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_39") == 0 )
         {
            A5EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A9SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
            n9SectorId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_39( A5EspectaculoId, A9SectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_41") == 0 )
         {
            A10ProductoId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductoId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_41( A10ProductoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridespectaculo_sector") == 0 )
         {
            gxnrGridespectaculo_sector_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridespectaculo_producto") == 0 )
         {
            gxnrGridespectaculo_producto_newrow_invoke( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV15EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15EspectaculoId", StringUtil.LTrimStr( (decimal)(AV15EspectaculoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EspectaculoId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_3-171579", 0) ;
            }
            Form.Meta.addItem("description", "Espectaculo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEspectaculoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridespectaculo_sector_newrow_invoke( )
      {
         nRC_GXsfl_113 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_113"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_113_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_113_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_113_idx = GetPar( "sGXsfl_113_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         A29CantidadSectores = (short)(Math.Round(NumberUtil.Val( GetPar( "CantidadSectores"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridespectaculo_sector_newrow( ) ;
         /* End function gxnrGridespectaculo_sector_newrow_invoke */
      }

      protected void gxnrGridespectaculo_producto_newrow_invoke( )
      {
         nRC_GXsfl_128 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_128"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_128_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_128_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_128_idx = GetPar( "sGXsfl_128_idx");
         A36CantidadProductos = (short)(Math.Round(NumberUtil.Val( GetPar( "CantidadProductos"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridespectaculo_producto_newrow( ) ;
         /* End function gxnrGridespectaculo_producto_newrow_invoke */
      }

      public espectaculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public espectaculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EspectaculoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV15EspectaculoId = aP1_EspectaculoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbProductoTipo = new GXCombobox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Espectaculo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoNombre_Internalname, StringUtil.RTrim( A8EspectaculoNombre), StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEspectaculoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A19EspectaculoFecha, "99/99/99"), context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Espectaculo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoEspectaculoId_Internalname, "Tipo Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6TipoEspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A6TipoEspectaculoId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Espectaculo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_6_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_6_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_6_Internalname, sImgUrl, imgprompt_6_Link, "", "", context.GetTheme( ), imgprompt_6_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoEspectaculoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoEspectaculoNombre_Internalname, "Tipo Espectaculo Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoNombre_Internalname, StringUtil.RTrim( A16TipoEspectaculoNombre), StringUtil.RTrim( context.localUtil.Format( A16TipoEspectaculoNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLugarId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarId_Internalname, "Lugar Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLugarId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3LugarId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A3LugarId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Espectaculo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_3_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_3_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_3_Internalname, sImgUrl, imgprompt_3_Link, "", "", context.GetTheme( ), imgprompt_3_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLugarNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarNombre_Internalname, "Lugar Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarNombre_Internalname, StringUtil.RTrim( A4LugarNombre), StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisNombre_Internalname, "Pais Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisNombre_Internalname, StringUtil.RTrim( A2PaisNombre), StringUtil.RTrim( context.localUtil.Format( A2PaisNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisOrigenId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisOrigenId_Internalname, "Origen Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisOrigenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7PaisOrigenId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A7PaisOrigenId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisOrigenId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisOrigenId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Espectaculo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_7_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_7_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_7_Internalname, sImgUrl, imgprompt_7_Link, "", "", context.GetTheme( ), imgprompt_7_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisOrigenNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisOrigenNombre_Internalname, "Origen Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisOrigenNombre_Internalname, StringUtil.RTrim( A28PaisOrigenNombre), StringUtil.RTrim( context.localUtil.Format( A28PaisOrigenNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisOrigenNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisOrigenNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgEspectaculoAfiche_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Afiche", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A20EspectaculoAfiche_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000EspectaculoAfiche_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : context.PathToRelativeUrl( A20EspectaculoAfiche));
         GxWebStd.gx_bitmap( context, imgEspectaculoAfiche_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgEspectaculoAfiche_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", "", "", 0, A20EspectaculoAfiche_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
         AssignProp("", false, imgEspectaculoAfiche_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : context.PathToRelativeUrl( A20EspectaculoAfiche)), true);
         AssignProp("", false, imgEspectaculoAfiche_Internalname, "IsBlob", StringUtil.BoolToStr( A20EspectaculoAfiche_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoCantidadInvitacione_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoCantidadInvitacione_Internalname, "Cantidad Invitaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoCantidadInvitacione_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoCantidadInvitacione_Enabled!=0) ? context.localUtil.Format( (decimal)(A31EspectaculoCantidadInvitacione), "ZZZ9") : context.localUtil.Format( (decimal)(A31EspectaculoCantidadInvitacione), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoCantidadInvitacione_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoCantidadInvitacione_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoInvitacionesDisponi_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoInvitacionesDisponi_Internalname, "Invitaciones Disponibles", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoInvitacionesDisponi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoInvitacionesDisponi_Enabled!=0) ? context.localUtil.Format( (decimal)(A32EspectaculoInvitacionesDisponi), "ZZZ9") : context.localUtil.Format( (decimal)(A32EspectaculoInvitacionesDisponi), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoInvitacionesDisponi_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoInvitacionesDisponi_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoInvitacionesEntrega_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoInvitacionesEntrega_Internalname, "Invitaciones Entregadas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoInvitacionesEntrega_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoInvitacionesEntrega_Enabled!=0) ? context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9") : context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoInvitacionesEntrega_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoInvitacionesEntrega_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCantidadProductos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCantidadProductos_Internalname, "Productos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCantidadProductos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A36CantidadProductos), 4, 0, ",", "")), StringUtil.LTrim( ((edtCantidadProductos_Enabled!=0) ? context.localUtil.Format( (decimal)(A36CantidadProductos), "ZZZ9") : context.localUtil.Format( (decimal)(A36CantidadProductos), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCantidadProductos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCantidadProductos_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectortable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlesector_Internalname, "Sector", "", "", lblTitlesector_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridespectaculo_sector( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProductotable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleproducto_Internalname, "Producto", "", "", lblTitleproducto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridespectaculo_producto( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridespectaculo_sector( )
      {
         /*  Grid Control  */
         StartGridControl113( ) ;
         nGXsfl_113_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount4 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_4 = 1;
               ScanStart034( ) ;
               while ( RcdFound4 != 0 )
               {
                  init_level_properties4( ) ;
                  getByPrimaryKey034( ) ;
                  AddRow034( ) ;
                  ScanNext034( ) ;
               }
               ScanEnd034( ) ;
               nBlankRcdCount4 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B36CantidadProductos = A36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            B29CantidadSectores = A29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            standaloneNotModal034( ) ;
            standaloneModal034( ) ;
            sMode4 = Gx_mode;
            while ( nGXsfl_113_idx < nRC_GXsfl_113 )
            {
               bGXsfl_113_Refreshing = true;
               ReadRow034( ) ;
               edtSectorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORID_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               edtSectorNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORNOMBRE_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorNombre_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               edtSectorCapacidad_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORCAPACIDAD_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorCapacidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCapacidad_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               edtSectorPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORPRECIO_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorPrecio_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               edtSectorEntradasVendidas_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORENTRADASVENDIDAS_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorEntradasVendidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorEntradasVendidas_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               edtSectorEntradasDisponibles_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORENTRADASDISPONIBLES_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorEntradasDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               if ( ( nRcdExists_4 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal034( ) ;
               }
               SendRow034( ) ;
               bGXsfl_113_Refreshing = false;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A36CantidadProductos = B36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            A29CantidadSectores = B29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount4 = 5;
            nRcdExists_4 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart034( ) ;
               while ( RcdFound4 != 0 )
               {
                  sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_1134( ) ;
                  init_level_properties4( ) ;
                  standaloneNotModal034( ) ;
                  getByPrimaryKey034( ) ;
                  standaloneModal034( ) ;
                  AddRow034( ) ;
                  ScanNext034( ) ;
               }
               ScanEnd034( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode4 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx+1), 4, 0), 4, "0");
            SubsflControlProps_1134( ) ;
            InitAll034( ) ;
            init_level_properties4( ) ;
            B36CantidadProductos = A36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            B29CantidadSectores = A29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            nRcdExists_4 = 0;
            nIsMod_4 = 0;
            nRcdDeleted_4 = 0;
            nBlankRcdCount4 = (short)(nBlankRcdUsr4+nBlankRcdCount4);
            fRowAdded = 0;
            while ( nBlankRcdCount4 > 0 )
            {
               standaloneNotModal034( ) ;
               standaloneModal034( ) ;
               AddRow034( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtSectorNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount4 = (short)(nBlankRcdCount4-1);
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A36CantidadProductos = B36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            A29CantidadSectores = B29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridespectaculo_sectorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridespectaculo_sector", Gridespectaculo_sectorContainer, subGridespectaculo_sector_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_sectorContainerData", Gridespectaculo_sectorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_sectorContainerData"+"V", Gridespectaculo_sectorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridespectaculo_sectorContainerData"+"V"+"\" value='"+Gridespectaculo_sectorContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridespectaculo_producto( )
      {
         /*  Grid Control  */
         StartGridControl128( ) ;
         nGXsfl_128_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount5 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_5 = 1;
               ScanStart035( ) ;
               while ( RcdFound5 != 0 )
               {
                  init_level_properties5( ) ;
                  getByPrimaryKey035( ) ;
                  AddRow035( ) ;
                  ScanNext035( ) ;
               }
               ScanEnd035( ) ;
               nBlankRcdCount5 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B36CantidadProductos = A36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            B29CantidadSectores = A29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            standaloneNotModal035( ) ;
            standaloneModal035( ) ;
            sMode5 = Gx_mode;
            while ( nGXsfl_128_idx < nRC_GXsfl_128 )
            {
               bGXsfl_128_Refreshing = true;
               ReadRow035( ) ;
               edtProductoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtProductoNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTONOMBRE_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoNombre_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               cmbProductoTipo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOTIPO_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbProductoTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProductoTipo.Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtProductoStockInicial_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOSTOCKINICIAL_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductoStockInicial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoStockInicial_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtProductoPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOPRECIO_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductoPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPrecio_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtProductoCantidadVendidos_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOCANTIDADVENDIDOS_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductoCantidadVendidos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoCantidadVendidos_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               edtProductoStockActual_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOSTOCKACTUAL_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductoStockActual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoStockActual_Enabled), 5, 0), !bGXsfl_128_Refreshing);
               imgprompt_6_Link = cgiGet( "PROMPT_10_"+sGXsfl_128_idx+"Link");
               if ( ( nRcdExists_5 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal035( ) ;
               }
               SendRow035( ) ;
               bGXsfl_128_Refreshing = false;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A36CantidadProductos = B36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            A29CantidadSectores = B29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount5 = 5;
            nRcdExists_5 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart035( ) ;
               while ( RcdFound5 != 0 )
               {
                  sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_1285( ) ;
                  init_level_properties5( ) ;
                  standaloneNotModal035( ) ;
                  getByPrimaryKey035( ) ;
                  standaloneModal035( ) ;
                  AddRow035( ) ;
                  ScanNext035( ) ;
               }
               ScanEnd035( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode5 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx+1), 4, 0), 4, "0");
            SubsflControlProps_1285( ) ;
            InitAll035( ) ;
            init_level_properties5( ) ;
            B36CantidadProductos = A36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            B29CantidadSectores = A29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            nRcdExists_5 = 0;
            nIsMod_5 = 0;
            nRcdDeleted_5 = 0;
            nBlankRcdCount5 = (short)(nBlankRcdUsr5+nBlankRcdCount5);
            fRowAdded = 0;
            while ( nBlankRcdCount5 > 0 )
            {
               standaloneNotModal035( ) ;
               standaloneModal035( ) ;
               AddRow035( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount5 = (short)(nBlankRcdCount5-1);
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A36CantidadProductos = B36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            A29CantidadSectores = B29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridespectaculo_productoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridespectaculo_producto", Gridespectaculo_productoContainer, subGridespectaculo_producto_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_productoContainerData", Gridespectaculo_productoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_productoContainerData"+"V", Gridespectaculo_productoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridespectaculo_productoContainerData"+"V"+"\" value='"+Gridespectaculo_productoContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z5EspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z8EspectaculoNombre = cgiGet( "Z8EspectaculoNombre");
               Z19EspectaculoFecha = context.localUtil.CToD( cgiGet( "Z19EspectaculoFecha"), 0);
               Z31EspectaculoCantidadInvitacione = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z31EspectaculoCantidadInvitacione"), ",", "."), 18, MidpointRounding.ToEven));
               Z33EspectaculoInvitacionesEntrega = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z33EspectaculoInvitacionesEntrega"), ",", "."), 18, MidpointRounding.ToEven));
               Z29CantidadSectores = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z29CantidadSectores"), ",", "."), 18, MidpointRounding.ToEven));
               Z36CantidadProductos = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z36CantidadProductos"), ",", "."), 18, MidpointRounding.ToEven));
               Z6TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z6TipoEspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z3LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z3LugarId"), ",", "."), 18, MidpointRounding.ToEven));
               Z7PaisOrigenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z7PaisOrigenId"), ",", "."), 18, MidpointRounding.ToEven));
               A29CantidadSectores = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z29CantidadSectores"), ",", "."), 18, MidpointRounding.ToEven));
               O36CantidadProductos = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O36CantidadProductos"), ",", "."), 18, MidpointRounding.ToEven));
               O29CantidadSectores = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O29CantidadSectores"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_113 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_113"), ",", "."), 18, MidpointRounding.ToEven));
               nRC_GXsfl_128 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_128"), ",", "."), 18, MidpointRounding.ToEven));
               N6TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N6TipoEspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               N3LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N3LugarId"), ",", "."), 18, MidpointRounding.ToEven));
               N7PaisOrigenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N7PaisOrigenId"), ",", "."), 18, MidpointRounding.ToEven));
               AV15EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vESPECTACULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV9Insert_TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TIPOESPECTACULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV7Insert_LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_LUGARID"), ",", "."), 18, MidpointRounding.ToEven));
               AV8Insert_PaisOrigenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PAISORIGENID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A29CantidadSectores = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CANTIDADSECTORES"), ",", "."), 18, MidpointRounding.ToEven));
               A40000EspectaculoAfiche_GXI = cgiGet( "ESPECTACULOAFICHE_GXI");
               A1PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PAISID"), ",", "."), 18, MidpointRounding.ToEven));
               AV17Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
               A8EspectaculoNombre = cgiGet( edtEspectaculoNombre_Internalname);
               AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
               if ( context.localUtil.VCDate( cgiGet( edtEspectaculoFecha_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Espectaculo Fecha"}), 1, "ESPECTACULOFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A19EspectaculoFecha = DateTime.MinValue;
                  AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
               }
               else
               {
                  A19EspectaculoFecha = context.localUtil.CToD( cgiGet( edtEspectaculoFecha_Internalname), 2);
                  AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPOESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A6TipoEspectaculoId = 0;
                  AssignAttri("", false, "A6TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A6TipoEspectaculoId), 4, 0));
               }
               else
               {
                  A6TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A6TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A6TipoEspectaculoId), 4, 0));
               }
               A16TipoEspectaculoNombre = cgiGet( edtTipoEspectaculoNombre_Internalname);
               AssignAttri("", false, "A16TipoEspectaculoNombre", A16TipoEspectaculoNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LUGARID");
                  AnyError = 1;
                  GX_FocusControl = edtLugarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3LugarId = 0;
                  AssignAttri("", false, "A3LugarId", StringUtil.LTrimStr( (decimal)(A3LugarId), 4, 0));
               }
               else
               {
                  A3LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A3LugarId", StringUtil.LTrimStr( (decimal)(A3LugarId), 4, 0));
               }
               A4LugarNombre = cgiGet( edtLugarNombre_Internalname);
               AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
               A2PaisNombre = cgiGet( edtPaisNombre_Internalname);
               AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisOrigenId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisOrigenId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISORIGENID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisOrigenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7PaisOrigenId = 0;
                  AssignAttri("", false, "A7PaisOrigenId", StringUtil.LTrimStr( (decimal)(A7PaisOrigenId), 4, 0));
               }
               else
               {
                  A7PaisOrigenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisOrigenId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A7PaisOrigenId", StringUtil.LTrimStr( (decimal)(A7PaisOrigenId), 4, 0));
               }
               A28PaisOrigenNombre = cgiGet( edtPaisOrigenNombre_Internalname);
               AssignAttri("", false, "A28PaisOrigenNombre", A28PaisOrigenNombre);
               A20EspectaculoAfiche = cgiGet( imgEspectaculoAfiche_Internalname);
               AssignAttri("", false, "A20EspectaculoAfiche", A20EspectaculoAfiche);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEspectaculoCantidadInvitacione_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspectaculoCantidadInvitacione_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESPECTACULOCANTIDADINVITACIONE");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoCantidadInvitacione_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A31EspectaculoCantidadInvitacione = 0;
                  AssignAttri("", false, "A31EspectaculoCantidadInvitacione", StringUtil.LTrimStr( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0));
               }
               else
               {
                  A31EspectaculoCantidadInvitacione = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoCantidadInvitacione_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A31EspectaculoCantidadInvitacione", StringUtil.LTrimStr( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0));
               }
               A32EspectaculoInvitacionesDisponi = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoInvitacionesDisponi_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
               A33EspectaculoInvitacionesEntrega = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoInvitacionesEntrega_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
               A36CantidadProductos = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCantidadProductos_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgEspectaculoAfiche_Internalname, ref  A20EspectaculoAfiche, ref  A40000EspectaculoAfiche_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Espectaculo");
               A5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
               forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9"));
               A33EspectaculoInvitacionesEntrega = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoInvitacionesEntrega_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
               forbiddenHiddens.Add("EspectaculoInvitacionesEntrega", context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A5EspectaculoId != Z5EspectaculoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("espectaculo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A5EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESPECTACULOID");
                        AnyError = 1;
                        GX_FocusControl = edtEspectaculoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes033( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode3 = Gx_mode;
            CONFIRM_034( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_035( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode3;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_035( )
      {
         s36CantidadProductos = O36CantidadProductos;
         AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
         nGXsfl_128_idx = 0;
         while ( nGXsfl_128_idx < nRC_GXsfl_128 )
         {
            ReadRow035( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               GetKey035( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  if ( RcdFound5 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate035( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable035( ) ;
                        CloseExtendedTableCursors035( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O36CantidadProductos = A36CantidadProductos;
                        AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTOID_" + sGXsfl_128_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( nRcdDeleted_5 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey035( ) ;
                        Load035( ) ;
                        BeforeValidate035( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls035( ) ;
                           O36CantidadProductos = A36CantidadProductos;
                           AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate035( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable035( ) ;
                              CloseExtendedTableCursors035( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O36CantidadProductos = A36CantidadProductos;
                              AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "PRODUCTOID_" + sGXsfl_128_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductoId), 4, 0, ",", ""))) ;
            ChangePostValue( edtProductoNombre_Internalname, StringUtil.RTrim( A38ProductoNombre)) ;
            ChangePostValue( cmbProductoTipo_Internalname, StringUtil.RTrim( A37ProductoTipo)) ;
            ChangePostValue( edtProductoStockInicial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A39ProductoStockInicial), 5, 0, ",", ""))) ;
            ChangePostValue( edtProductoPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40ProductoPrecio), 5, 0, ",", ""))) ;
            ChangePostValue( edtProductoCantidadVendidos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41ProductoCantidadVendidos), 5, 0, ",", ""))) ;
            ChangePostValue( edtProductoStockActual_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ProductoStockActual), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z10ProductoId_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductoId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z39ProductoStockInicial_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39ProductoStockInicial), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z40ProductoPrecio_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40ProductoPrecio), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z41ProductoCantidadVendidos_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41ProductoCantidadVendidos), 5, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ",", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "PRODUCTOID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTONOMBRE_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOTIPO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProductoTipo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOSTOCKINICIAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoStockInicial_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOPRECIO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOCANTIDADVENDIDOS_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoCantidadVendidos_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOSTOCKACTUAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoStockActual_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O36CantidadProductos = s36CantidadProductos;
         AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_034( )
      {
         s29CantidadSectores = O29CantidadSectores;
         AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         nGXsfl_113_idx = 0;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            ReadRow034( ) ;
            if ( ( nRcdExists_4 != 0 ) || ( nIsMod_4 != 0 ) )
            {
               GetKey034( ) ;
               if ( ( nRcdExists_4 == 0 ) && ( nRcdDeleted_4 == 0 ) )
               {
                  if ( RcdFound4 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate034( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable034( ) ;
                        CloseExtendedTableCursors034( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O29CantidadSectores = A29CantidadSectores;
                        AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound4 != 0 )
                  {
                     if ( nRcdDeleted_4 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey034( ) ;
                        Load034( ) ;
                        BeforeValidate034( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls034( ) ;
                           O29CantidadSectores = A29CantidadSectores;
                           AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_4 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate034( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable034( ) ;
                              CloseExtendedTableCursors034( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O29CantidadSectores = A29CantidadSectores;
                              AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_4 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", ""))) ;
            ChangePostValue( edtSectorNombre_Internalname, StringUtil.RTrim( A21SectorNombre)) ;
            ChangePostValue( edtSectorCapacidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ",", ""))) ;
            ChangePostValue( edtSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ",", ""))) ;
            ChangePostValue( edtSectorEntradasVendidas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorEntradasVendidas), 5, 0, ",", ""))) ;
            ChangePostValue( edtSectorEntradasDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24SectorEntradasDisponibles), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z9SectorId_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SectorId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z21SectorNombre_"+sGXsfl_113_idx, StringUtil.RTrim( Z21SectorNombre)) ;
            ChangePostValue( "ZT_"+"Z22SectorCapacidad_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22SectorCapacidad), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z23SectorPrecio_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23SectorPrecio), 6, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_4_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_4_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_4_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, ",", ""))) ;
            if ( nIsMod_4 != 0 )
            {
               ChangePostValue( "SECTORID_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORNOMBRE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORCAPACIDAD_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCapacidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORPRECIO_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORENTRADASVENDIDAS_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorEntradasVendidas_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORENTRADASDISPONIBLES_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O29CantidadSectores = s29CantidadSectores;
         AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         AV9Insert_TipoEspectaculoId = 0;
         AssignAttri("", false, "AV9Insert_TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV9Insert_TipoEspectaculoId), 4, 0));
         AV7Insert_LugarId = 0;
         AssignAttri("", false, "AV7Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV7Insert_LugarId), 4, 0));
         AV8Insert_PaisOrigenId = 0;
         AssignAttri("", false, "AV8Insert_PaisOrigenId", StringUtil.LTrimStr( (decimal)(AV8Insert_PaisOrigenId), 4, 0));
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            while ( AV18GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "TipoEspectaculoId") == 0 )
               {
                  AV9Insert_TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9Insert_TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV9Insert_TipoEspectaculoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "LugarId") == 0 )
               {
                  AV7Insert_LugarId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV7Insert_LugarId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PaisOrigenId") == 0 )
               {
                  AV8Insert_PaisOrigenId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV8Insert_PaisOrigenId", StringUtil.LTrimStr( (decimal)(AV8Insert_PaisOrigenId), 4, 0));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwespectaculo.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z8EspectaculoNombre = T000310_A8EspectaculoNombre[0];
               Z19EspectaculoFecha = T000310_A19EspectaculoFecha[0];
               Z31EspectaculoCantidadInvitacione = T000310_A31EspectaculoCantidadInvitacione[0];
               Z33EspectaculoInvitacionesEntrega = T000310_A33EspectaculoInvitacionesEntrega[0];
               Z29CantidadSectores = T000310_A29CantidadSectores[0];
               Z36CantidadProductos = T000310_A36CantidadProductos[0];
               Z6TipoEspectaculoId = T000310_A6TipoEspectaculoId[0];
               Z3LugarId = T000310_A3LugarId[0];
               Z7PaisOrigenId = T000310_A7PaisOrigenId[0];
            }
            else
            {
               Z8EspectaculoNombre = A8EspectaculoNombre;
               Z19EspectaculoFecha = A19EspectaculoFecha;
               Z31EspectaculoCantidadInvitacione = A31EspectaculoCantidadInvitacione;
               Z33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
               Z29CantidadSectores = A29CantidadSectores;
               Z36CantidadProductos = A36CantidadProductos;
               Z6TipoEspectaculoId = A6TipoEspectaculoId;
               Z3LugarId = A3LugarId;
               Z7PaisOrigenId = A7PaisOrigenId;
            }
         }
         if ( GX_JID == -32 )
         {
            Z5EspectaculoId = A5EspectaculoId;
            Z8EspectaculoNombre = A8EspectaculoNombre;
            Z19EspectaculoFecha = A19EspectaculoFecha;
            Z20EspectaculoAfiche = A20EspectaculoAfiche;
            Z40000EspectaculoAfiche_GXI = A40000EspectaculoAfiche_GXI;
            Z31EspectaculoCantidadInvitacione = A31EspectaculoCantidadInvitacione;
            Z33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
            Z29CantidadSectores = A29CantidadSectores;
            Z36CantidadProductos = A36CantidadProductos;
            Z6TipoEspectaculoId = A6TipoEspectaculoId;
            Z3LugarId = A3LugarId;
            Z7PaisOrigenId = A7PaisOrigenId;
            Z16TipoEspectaculoNombre = A16TipoEspectaculoNombre;
            Z1PaisId = A1PaisId;
            Z4LugarNombre = A4LugarNombre;
            Z2PaisNombre = A2PaisNombre;
            Z28PaisOrigenNombre = A28PaisOrigenNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtCantidadProductos_Enabled = 0;
         AssignProp("", false, edtCantidadProductos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCantidadProductos_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesDisponi_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesDisponi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesDisponi_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesEntrega_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_6_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOESPECTACULOID"+"'), id:'"+"TIPOESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_3_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LUGARID"+"'), id:'"+"LUGARID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISORIGENID"+"'), id:'"+"PAISORIGENID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtCantidadProductos_Enabled = 0;
         AssignProp("", false, edtCantidadProductos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCantidadProductos_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesDisponi_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesDisponi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesDisponi_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesEntrega_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV15EspectaculoId) )
         {
            A5EspectaculoId = AV15EspectaculoId;
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV9Insert_TipoEspectaculoId) )
         {
            edtTipoEspectaculoId_Enabled = 0;
            AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         }
         else
         {
            edtTipoEspectaculoId_Enabled = 1;
            AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV7Insert_LugarId) )
         {
            edtLugarId_Enabled = 0;
            AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         }
         else
         {
            edtLugarId_Enabled = 1;
            AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV8Insert_PaisOrigenId) )
         {
            edtPaisOrigenId_Enabled = 0;
            AssignProp("", false, edtPaisOrigenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisOrigenId_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisOrigenId_Enabled = 1;
            AssignProp("", false, edtPaisOrigenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisOrigenId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV8Insert_PaisOrigenId) )
         {
            A7PaisOrigenId = AV8Insert_PaisOrigenId;
            AssignAttri("", false, "A7PaisOrigenId", StringUtil.LTrimStr( (decimal)(A7PaisOrigenId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV7Insert_LugarId) )
         {
            A3LugarId = AV7Insert_LugarId;
            AssignAttri("", false, "A3LugarId", StringUtil.LTrimStr( (decimal)(A3LugarId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV9Insert_TipoEspectaculoId) )
         {
            A6TipoEspectaculoId = AV9Insert_TipoEspectaculoId;
            AssignAttri("", false, "A6TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A6TipoEspectaculoId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (0==A33EspectaculoInvitacionesEntrega) && ( Gx_BScreen == 0 ) )
         {
            A33EspectaculoInvitacionesEntrega = 0;
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A19EspectaculoFecha) && ( Gx_BScreen == 0 ) )
         {
            A19EspectaculoFecha = DateTimeUtil.Today( context);
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         }
         if ( IsIns( )  && (0==A29CantidadSectores) && ( Gx_BScreen == 0 ) )
         {
            A29CantidadSectores = 0;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV17Pgmname = "Espectaculo";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T000313 */
            pr_default.execute(10, new Object[] {A7PaisOrigenId});
            A28PaisOrigenNombre = T000313_A28PaisOrigenNombre[0];
            AssignAttri("", false, "A28PaisOrigenNombre", A28PaisOrigenNombre);
            pr_default.close(10);
            /* Using cursor T000312 */
            pr_default.execute(9, new Object[] {A3LugarId});
            A1PaisId = T000312_A1PaisId[0];
            A4LugarNombre = T000312_A4LugarNombre[0];
            AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
            pr_default.close(9);
            /* Using cursor T000314 */
            pr_default.execute(11, new Object[] {A1PaisId});
            A2PaisNombre = T000314_A2PaisNombre[0];
            AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
            pr_default.close(11);
            /* Using cursor T000311 */
            pr_default.execute(8, new Object[] {A6TipoEspectaculoId});
            A16TipoEspectaculoNombre = T000311_A16TipoEspectaculoNombre[0];
            AssignAttri("", false, "A16TipoEspectaculoNombre", A16TipoEspectaculoNombre);
            pr_default.close(8);
         }
      }

      protected void Load033( )
      {
         /* Using cursor T000315 */
         pr_default.execute(12, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A1PaisId = T000315_A1PaisId[0];
            A8EspectaculoNombre = T000315_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T000315_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            A16TipoEspectaculoNombre = T000315_A16TipoEspectaculoNombre[0];
            AssignAttri("", false, "A16TipoEspectaculoNombre", A16TipoEspectaculoNombre);
            A4LugarNombre = T000315_A4LugarNombre[0];
            AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
            A2PaisNombre = T000315_A2PaisNombre[0];
            AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
            A28PaisOrigenNombre = T000315_A28PaisOrigenNombre[0];
            AssignAttri("", false, "A28PaisOrigenNombre", A28PaisOrigenNombre);
            A40000EspectaculoAfiche_GXI = T000315_A40000EspectaculoAfiche_GXI[0];
            AssignProp("", false, imgEspectaculoAfiche_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : context.convertURL( context.PathToRelativeUrl( A20EspectaculoAfiche))), true);
            AssignProp("", false, imgEspectaculoAfiche_Internalname, "SrcSet", context.GetImageSrcSet( A20EspectaculoAfiche), true);
            A31EspectaculoCantidadInvitacione = T000315_A31EspectaculoCantidadInvitacione[0];
            AssignAttri("", false, "A31EspectaculoCantidadInvitacione", StringUtil.LTrimStr( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0));
            A33EspectaculoInvitacionesEntrega = T000315_A33EspectaculoInvitacionesEntrega[0];
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            A29CantidadSectores = T000315_A29CantidadSectores[0];
            A36CantidadProductos = T000315_A36CantidadProductos[0];
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            A6TipoEspectaculoId = T000315_A6TipoEspectaculoId[0];
            AssignAttri("", false, "A6TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A6TipoEspectaculoId), 4, 0));
            A3LugarId = T000315_A3LugarId[0];
            AssignAttri("", false, "A3LugarId", StringUtil.LTrimStr( (decimal)(A3LugarId), 4, 0));
            A7PaisOrigenId = T000315_A7PaisOrigenId[0];
            AssignAttri("", false, "A7PaisOrigenId", StringUtil.LTrimStr( (decimal)(A7PaisOrigenId), 4, 0));
            A20EspectaculoAfiche = T000315_A20EspectaculoAfiche[0];
            AssignAttri("", false, "A20EspectaculoAfiche", A20EspectaculoAfiche);
            AssignProp("", false, imgEspectaculoAfiche_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : context.convertURL( context.PathToRelativeUrl( A20EspectaculoAfiche))), true);
            AssignProp("", false, imgEspectaculoAfiche_Internalname, "SrcSet", context.GetImageSrcSet( A20EspectaculoAfiche), true);
            ZM033( -32) ;
         }
         pr_default.close(12);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV17Pgmname = "Espectaculo";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
         AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            A32EspectaculoInvitacionesDisponi = A31EspectaculoCantidadInvitacione;
            AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         }
         else
         {
            A32EspectaculoInvitacionesDisponi = 0;
            AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         }
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV17Pgmname = "Espectaculo";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         /* Using cursor T000316 */
         pr_default.execute(13, new Object[] {A8EspectaculoNombre, A5EspectaculoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Espectaculo Nombre"}), 1, "ESPECTACULONOMBRE");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(13);
         if ( ! ( (DateTime.MinValue==A19EspectaculoFecha) || ( DateTimeUtil.ResetTime ( A19EspectaculoFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Espectaculo Fecha fuera de rango", "OutOfRange", 1, "ESPECTACULOFECHA");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000311 */
         pr_default.execute(8, new Object[] {A6TipoEspectaculoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16TipoEspectaculoNombre = T000311_A16TipoEspectaculoNombre[0];
         AssignAttri("", false, "A16TipoEspectaculoNombre", A16TipoEspectaculoNombre);
         pr_default.close(8);
         /* Using cursor T000312 */
         pr_default.execute(9, new Object[] {A3LugarId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1PaisId = T000312_A1PaisId[0];
         A4LugarNombre = T000312_A4LugarNombre[0];
         AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
         pr_default.close(9);
         /* Using cursor T000314 */
         pr_default.execute(11, new Object[] {A1PaisId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A2PaisNombre = T000314_A2PaisNombre[0];
         AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
         pr_default.close(11);
         /* Using cursor T000313 */
         pr_default.execute(10, new Object[] {A7PaisOrigenId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais Origen'.", "ForeignKeyNotFound", 1, "PAISORIGENID");
            AnyError = 1;
            GX_FocusControl = edtPaisOrigenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28PaisOrigenNombre = T000313_A28PaisOrigenNombre[0];
         AssignAttri("", false, "A28PaisOrigenNombre", A28PaisOrigenNombre);
         pr_default.close(10);
         nIsDirty_3 = 1;
         A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
         AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            nIsDirty_3 = 1;
            A32EspectaculoInvitacionesDisponi = A31EspectaculoCantidadInvitacione;
            AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         }
         else
         {
            nIsDirty_3 = 1;
            A32EspectaculoInvitacionesDisponi = 0;
            AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(11);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_34( short A6TipoEspectaculoId )
      {
         /* Using cursor T000317 */
         pr_default.execute(14, new Object[] {A6TipoEspectaculoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16TipoEspectaculoNombre = T000317_A16TipoEspectaculoNombre[0];
         AssignAttri("", false, "A16TipoEspectaculoNombre", A16TipoEspectaculoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A16TipoEspectaculoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_35( short A3LugarId )
      {
         /* Using cursor T000318 */
         pr_default.execute(15, new Object[] {A3LugarId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1PaisId = T000318_A1PaisId[0];
         A4LugarNombre = T000318_A4LugarNombre[0];
         AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1PaisId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A4LugarNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_37( short A1PaisId )
      {
         /* Using cursor T000319 */
         pr_default.execute(16, new Object[] {A1PaisId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A2PaisNombre = T000319_A2PaisNombre[0];
         AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2PaisNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_36( short A7PaisOrigenId )
      {
         /* Using cursor T000320 */
         pr_default.execute(17, new Object[] {A7PaisOrigenId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais Origen'.", "ForeignKeyNotFound", 1, "PAISORIGENID");
            AnyError = 1;
            GX_FocusControl = edtPaisOrigenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28PaisOrigenNombre = T000320_A28PaisOrigenNombre[0];
         AssignAttri("", false, "A28PaisOrigenNombre", A28PaisOrigenNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A28PaisOrigenNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void GetKey033( )
      {
         /* Using cursor T000321 */
         pr_default.execute(18, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000310 */
         pr_default.execute(7, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM033( 32) ;
            RcdFound3 = 1;
            A5EspectaculoId = T000310_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A8EspectaculoNombre = T000310_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T000310_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            A40000EspectaculoAfiche_GXI = T000310_A40000EspectaculoAfiche_GXI[0];
            AssignProp("", false, imgEspectaculoAfiche_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : context.convertURL( context.PathToRelativeUrl( A20EspectaculoAfiche))), true);
            AssignProp("", false, imgEspectaculoAfiche_Internalname, "SrcSet", context.GetImageSrcSet( A20EspectaculoAfiche), true);
            A31EspectaculoCantidadInvitacione = T000310_A31EspectaculoCantidadInvitacione[0];
            AssignAttri("", false, "A31EspectaculoCantidadInvitacione", StringUtil.LTrimStr( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0));
            A33EspectaculoInvitacionesEntrega = T000310_A33EspectaculoInvitacionesEntrega[0];
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            A29CantidadSectores = T000310_A29CantidadSectores[0];
            A36CantidadProductos = T000310_A36CantidadProductos[0];
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            A6TipoEspectaculoId = T000310_A6TipoEspectaculoId[0];
            AssignAttri("", false, "A6TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A6TipoEspectaculoId), 4, 0));
            A3LugarId = T000310_A3LugarId[0];
            AssignAttri("", false, "A3LugarId", StringUtil.LTrimStr( (decimal)(A3LugarId), 4, 0));
            A7PaisOrigenId = T000310_A7PaisOrigenId[0];
            AssignAttri("", false, "A7PaisOrigenId", StringUtil.LTrimStr( (decimal)(A7PaisOrigenId), 4, 0));
            A20EspectaculoAfiche = T000310_A20EspectaculoAfiche[0];
            AssignAttri("", false, "A20EspectaculoAfiche", A20EspectaculoAfiche);
            AssignProp("", false, imgEspectaculoAfiche_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : context.convertURL( context.PathToRelativeUrl( A20EspectaculoAfiche))), true);
            AssignProp("", false, imgEspectaculoAfiche_Internalname, "SrcSet", context.GetImageSrcSet( A20EspectaculoAfiche), true);
            O36CantidadProductos = A36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            O29CantidadSectores = A29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            Z5EspectaculoId = A5EspectaculoId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T000322 */
         pr_default.execute(19, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            while ( (pr_default.getStatus(19) != 101) && ( ( T000322_A5EspectaculoId[0] < A5EspectaculoId ) ) )
            {
               pr_default.readNext(19);
            }
            if ( (pr_default.getStatus(19) != 101) && ( ( T000322_A5EspectaculoId[0] > A5EspectaculoId ) ) )
            {
               A5EspectaculoId = T000322_A5EspectaculoId[0];
               AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(19);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T000323 */
         pr_default.execute(20, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            while ( (pr_default.getStatus(20) != 101) && ( ( T000323_A5EspectaculoId[0] > A5EspectaculoId ) ) )
            {
               pr_default.readNext(20);
            }
            if ( (pr_default.getStatus(20) != 101) && ( ( T000323_A5EspectaculoId[0] < A5EspectaculoId ) ) )
            {
               A5EspectaculoId = T000323_A5EspectaculoId[0];
               AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(20);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A29CantidadSectores = O29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            A36CantidadProductos = O36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            GX_FocusControl = edtEspectaculoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A5EspectaculoId != Z5EspectaculoId )
               {
                  A5EspectaculoId = Z5EspectaculoId;
                  AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A29CantidadSectores = O29CantidadSectores;
                  AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                  A36CantidadProductos = O36CantidadProductos;
                  AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEspectaculoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A29CantidadSectores = O29CantidadSectores;
                  AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                  A36CantidadProductos = O36CantidadProductos;
                  AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                  Update033( ) ;
                  GX_FocusControl = edtEspectaculoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A5EspectaculoId != Z5EspectaculoId )
               {
                  /* Insert record */
                  A29CantidadSectores = O29CantidadSectores;
                  AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                  A36CantidadProductos = O36CantidadProductos;
                  AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                  GX_FocusControl = edtEspectaculoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESPECTACULOID");
                     AnyError = 1;
                     GX_FocusControl = edtEspectaculoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A29CantidadSectores = O29CantidadSectores;
                     AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                     A36CantidadProductos = O36CantidadProductos;
                     AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                     GX_FocusControl = edtEspectaculoNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A5EspectaculoId != Z5EspectaculoId )
         {
            A5EspectaculoId = Z5EspectaculoId;
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A29CantidadSectores = O29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            A36CantidadProductos = O36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEspectaculoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00039 */
            pr_default.execute(6, new Object[] {A5EspectaculoId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z8EspectaculoNombre, T00039_A8EspectaculoNombre[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z19EspectaculoFecha ) != DateTimeUtil.ResetTime ( T00039_A19EspectaculoFecha[0] ) ) || ( Z31EspectaculoCantidadInvitacione != T00039_A31EspectaculoCantidadInvitacione[0] ) || ( Z33EspectaculoInvitacionesEntrega != T00039_A33EspectaculoInvitacionesEntrega[0] ) || ( Z29CantidadSectores != T00039_A29CantidadSectores[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z36CantidadProductos != T00039_A36CantidadProductos[0] ) || ( Z6TipoEspectaculoId != T00039_A6TipoEspectaculoId[0] ) || ( Z3LugarId != T00039_A3LugarId[0] ) || ( Z7PaisOrigenId != T00039_A7PaisOrigenId[0] ) )
            {
               if ( StringUtil.StrCmp(Z8EspectaculoNombre, T00039_A8EspectaculoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z8EspectaculoNombre);
                  GXUtil.WriteLogRaw("Current: ",T00039_A8EspectaculoNombre[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z19EspectaculoFecha ) != DateTimeUtil.ResetTime ( T00039_A19EspectaculoFecha[0] ) )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoFecha");
                  GXUtil.WriteLogRaw("Old: ",Z19EspectaculoFecha);
                  GXUtil.WriteLogRaw("Current: ",T00039_A19EspectaculoFecha[0]);
               }
               if ( Z31EspectaculoCantidadInvitacione != T00039_A31EspectaculoCantidadInvitacione[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoCantidadInvitacione");
                  GXUtil.WriteLogRaw("Old: ",Z31EspectaculoCantidadInvitacione);
                  GXUtil.WriteLogRaw("Current: ",T00039_A31EspectaculoCantidadInvitacione[0]);
               }
               if ( Z33EspectaculoInvitacionesEntrega != T00039_A33EspectaculoInvitacionesEntrega[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoInvitacionesEntrega");
                  GXUtil.WriteLogRaw("Old: ",Z33EspectaculoInvitacionesEntrega);
                  GXUtil.WriteLogRaw("Current: ",T00039_A33EspectaculoInvitacionesEntrega[0]);
               }
               if ( Z29CantidadSectores != T00039_A29CantidadSectores[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"CantidadSectores");
                  GXUtil.WriteLogRaw("Old: ",Z29CantidadSectores);
                  GXUtil.WriteLogRaw("Current: ",T00039_A29CantidadSectores[0]);
               }
               if ( Z36CantidadProductos != T00039_A36CantidadProductos[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"CantidadProductos");
                  GXUtil.WriteLogRaw("Old: ",Z36CantidadProductos);
                  GXUtil.WriteLogRaw("Current: ",T00039_A36CantidadProductos[0]);
               }
               if ( Z6TipoEspectaculoId != T00039_A6TipoEspectaculoId[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"TipoEspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z6TipoEspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00039_A6TipoEspectaculoId[0]);
               }
               if ( Z3LugarId != T00039_A3LugarId[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"LugarId");
                  GXUtil.WriteLogRaw("Old: ",Z3LugarId);
                  GXUtil.WriteLogRaw("Current: ",T00039_A3LugarId[0]);
               }
               if ( Z7PaisOrigenId != T00039_A7PaisOrigenId[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"PaisOrigenId");
                  GXUtil.WriteLogRaw("Old: ",Z7PaisOrigenId);
                  GXUtil.WriteLogRaw("Current: ",T00039_A7PaisOrigenId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Espectaculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000324 */
                     pr_default.execute(21, new Object[] {A8EspectaculoNombre, A19EspectaculoFecha, A20EspectaculoAfiche, A40000EspectaculoAfiche_GXI, A31EspectaculoCantidadInvitacione, A33EspectaculoInvitacionesEntrega, A29CantidadSectores, A36CantidadProductos, A6TipoEspectaculoId, A3LugarId, A7PaisOrigenId});
                     A5EspectaculoId = T000324_A5EspectaculoId[0];
                     AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption030( ) ;
                           }
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000325 */
                     pr_default.execute(22, new Object[] {A8EspectaculoNombre, A19EspectaculoFecha, A31EspectaculoCantidadInvitacione, A33EspectaculoInvitacionesEntrega, A29CantidadSectores, A36CantidadProductos, A6TipoEspectaculoId, A3LugarId, A7PaisOrigenId, A5EspectaculoId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( (pr_default.getStatus(22) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
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
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000326 */
            pr_default.execute(23, new Object[] {A20EspectaculoAfiche, A40000EspectaculoAfiche_GXI, A5EspectaculoId});
            pr_default.close(23);
            pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
         }
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  A36CantidadProductos = O36CantidadProductos;
                  AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                  ScanStart035( ) ;
                  while ( RcdFound5 != 0 )
                  {
                     getByPrimaryKey035( ) ;
                     Delete035( ) ;
                     ScanNext035( ) ;
                     O36CantidadProductos = A36CantidadProductos;
                     AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
                  }
                  ScanEnd035( ) ;
                  A29CantidadSectores = O29CantidadSectores;
                  AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                  ScanStart034( ) ;
                  while ( RcdFound4 != 0 )
                  {
                     getByPrimaryKey034( ) ;
                     Delete034( ) ;
                     ScanNext034( ) ;
                     O29CantidadSectores = A29CantidadSectores;
                     AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
                  }
                  ScanEnd034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000327 */
                     pr_default.execute(24, new Object[] {A5EspectaculoId});
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV17Pgmname = "Espectaculo";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T000328 */
            pr_default.execute(25, new Object[] {A6TipoEspectaculoId});
            A16TipoEspectaculoNombre = T000328_A16TipoEspectaculoNombre[0];
            AssignAttri("", false, "A16TipoEspectaculoNombre", A16TipoEspectaculoNombre);
            pr_default.close(25);
            /* Using cursor T000329 */
            pr_default.execute(26, new Object[] {A3LugarId});
            A1PaisId = T000329_A1PaisId[0];
            A4LugarNombre = T000329_A4LugarNombre[0];
            AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
            pr_default.close(26);
            /* Using cursor T000330 */
            pr_default.execute(27, new Object[] {A1PaisId});
            A2PaisNombre = T000330_A2PaisNombre[0];
            AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
            pr_default.close(27);
            /* Using cursor T000331 */
            pr_default.execute(28, new Object[] {A7PaisOrigenId});
            A28PaisOrigenNombre = T000331_A28PaisOrigenNombre[0];
            AssignAttri("", false, "A28PaisOrigenNombre", A28PaisOrigenNombre);
            pr_default.close(28);
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               A32EspectaculoInvitacionesDisponi = A31EspectaculoCantidadInvitacione;
               AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
            }
            else
            {
               A32EspectaculoInvitacionesDisponi = 0;
               AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
            }
            A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
            AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000332 */
            pr_default.execute(29, new Object[] {A5EspectaculoId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invitacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T000333 */
            pr_default.execute(30, new Object[] {A5EspectaculoId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
         }
      }

      protected void ProcessNestedLevel034( )
      {
         s29CantidadSectores = O29CantidadSectores;
         AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         nGXsfl_113_idx = 0;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            ReadRow034( ) ;
            if ( ( nRcdExists_4 != 0 ) || ( nIsMod_4 != 0 ) )
            {
               standaloneNotModal034( ) ;
               GetKey034( ) ;
               if ( ( nRcdExists_4 == 0 ) && ( nRcdDeleted_4 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert034( ) ;
               }
               else
               {
                  if ( RcdFound4 != 0 )
                  {
                     if ( ( nRcdDeleted_4 != 0 ) && ( nRcdExists_4 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete034( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_4 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update034( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_4 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O29CantidadSectores = A29CantidadSectores;
               AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            }
            ChangePostValue( edtSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", ""))) ;
            ChangePostValue( edtSectorNombre_Internalname, StringUtil.RTrim( A21SectorNombre)) ;
            ChangePostValue( edtSectorCapacidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ",", ""))) ;
            ChangePostValue( edtSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ",", ""))) ;
            ChangePostValue( edtSectorEntradasVendidas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorEntradasVendidas), 5, 0, ",", ""))) ;
            ChangePostValue( edtSectorEntradasDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24SectorEntradasDisponibles), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z9SectorId_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SectorId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z21SectorNombre_"+sGXsfl_113_idx, StringUtil.RTrim( Z21SectorNombre)) ;
            ChangePostValue( "ZT_"+"Z22SectorCapacidad_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22SectorCapacidad), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z23SectorPrecio_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23SectorPrecio), 6, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_4_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_4_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_4_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, ",", ""))) ;
            if ( nIsMod_4 != 0 )
            {
               ChangePostValue( "SECTORID_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORNOMBRE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORCAPACIDAD_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCapacidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORPRECIO_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORENTRADASVENDIDAS_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorEntradasVendidas_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORENTRADASDISPONIBLES_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll034( ) ;
         if ( AnyError != 0 )
         {
            O29CantidadSectores = s29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         }
         nRcdExists_4 = 0;
         nIsMod_4 = 0;
         nRcdDeleted_4 = 0;
      }

      protected void ProcessNestedLevel035( )
      {
         s36CantidadProductos = O36CantidadProductos;
         AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
         nGXsfl_128_idx = 0;
         while ( nGXsfl_128_idx < nRC_GXsfl_128 )
         {
            ReadRow035( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               standaloneNotModal035( ) ;
               GetKey035( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert035( ) ;
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( ( nRcdDeleted_5 != 0 ) && ( nRcdExists_5 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete035( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update035( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "PRODUCTOID_" + sGXsfl_128_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O36CantidadProductos = A36CantidadProductos;
               AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
            }
            ChangePostValue( edtProductoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductoId), 4, 0, ",", ""))) ;
            ChangePostValue( edtProductoNombre_Internalname, StringUtil.RTrim( A38ProductoNombre)) ;
            ChangePostValue( cmbProductoTipo_Internalname, StringUtil.RTrim( A37ProductoTipo)) ;
            ChangePostValue( edtProductoStockInicial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A39ProductoStockInicial), 5, 0, ",", ""))) ;
            ChangePostValue( edtProductoPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40ProductoPrecio), 5, 0, ",", ""))) ;
            ChangePostValue( edtProductoCantidadVendidos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41ProductoCantidadVendidos), 5, 0, ",", ""))) ;
            ChangePostValue( edtProductoStockActual_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ProductoStockActual), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z10ProductoId_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductoId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z39ProductoStockInicial_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39ProductoStockInicial), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z40ProductoPrecio_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40ProductoPrecio), 5, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z41ProductoCantidadVendidos_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41ProductoCantidadVendidos), 5, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_128_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ",", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "PRODUCTOID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTONOMBRE_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOTIPO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProductoTipo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOSTOCKINICIAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoStockInicial_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOPRECIO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOCANTIDADVENDIDOS_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoCantidadVendidos_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOSTOCKACTUAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoStockActual_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll035( ) ;
         if ( AnyError != 0 )
         {
            O36CantidadProductos = s36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
         }
         nRcdExists_5 = 0;
         nIsMod_5 = 0;
         nRcdDeleted_5 = 0;
      }

      protected void ProcessLevel033( )
      {
         /* Save parent mode. */
         sMode3 = Gx_mode;
         ProcessNestedLevel034( ) ;
         ProcessNestedLevel035( ) ;
         if ( AnyError != 0 )
         {
            O29CantidadSectores = s29CantidadSectores;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            O36CantidadProductos = s36CantidadProductos;
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000334 */
         pr_default.execute(31, new Object[] {A36CantidadProductos, A29CantidadSectores, A5EspectaculoId});
         pr_default.close(31);
         pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
      }

      protected void EndLevel033( )
      {
         pr_default.close(6);
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(7);
            pr_default.close(4);
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(25);
            pr_default.close(26);
            pr_default.close(28);
            pr_default.close(27);
            pr_default.close(5);
            pr_default.close(2);
            context.CommitDataStores("espectaculo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(7);
            pr_default.close(4);
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(25);
            pr_default.close(26);
            pr_default.close(28);
            pr_default.close(27);
            pr_default.close(5);
            pr_default.close(2);
            context.RollbackDataStores("espectaculo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000335 */
         pr_default.execute(32);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound3 = 1;
            A5EspectaculoId = T000335_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound3 = 1;
            A5EspectaculoId = T000335_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtEspectaculoNombre_Enabled = 0;
         AssignProp("", false, edtEspectaculoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoNombre_Enabled), 5, 0), true);
         edtEspectaculoFecha_Enabled = 0;
         AssignProp("", false, edtEspectaculoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFecha_Enabled), 5, 0), true);
         edtTipoEspectaculoId_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         edtTipoEspectaculoNombre_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoNombre_Enabled), 5, 0), true);
         edtLugarId_Enabled = 0;
         AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         edtLugarNombre_Enabled = 0;
         AssignProp("", false, edtLugarNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarNombre_Enabled), 5, 0), true);
         edtPaisNombre_Enabled = 0;
         AssignProp("", false, edtPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisNombre_Enabled), 5, 0), true);
         edtPaisOrigenId_Enabled = 0;
         AssignProp("", false, edtPaisOrigenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisOrigenId_Enabled), 5, 0), true);
         edtPaisOrigenNombre_Enabled = 0;
         AssignProp("", false, edtPaisOrigenNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisOrigenNombre_Enabled), 5, 0), true);
         imgEspectaculoAfiche_Enabled = 0;
         AssignProp("", false, imgEspectaculoAfiche_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgEspectaculoAfiche_Enabled), 5, 0), true);
         edtEspectaculoCantidadInvitacione_Enabled = 0;
         AssignProp("", false, edtEspectaculoCantidadInvitacione_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoCantidadInvitacione_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesDisponi_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesDisponi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesDisponi_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesEntrega_Enabled), 5, 0), true);
         edtCantidadProductos_Enabled = 0;
         AssignProp("", false, edtCantidadProductos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCantidadProductos_Enabled), 5, 0), true);
      }

      protected void ZM034( short GX_JID )
      {
         if ( ( GX_JID == 38 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z21SectorNombre = T00036_A21SectorNombre[0];
               Z22SectorCapacidad = T00036_A22SectorCapacidad[0];
               Z23SectorPrecio = T00036_A23SectorPrecio[0];
            }
            else
            {
               Z21SectorNombre = A21SectorNombre;
               Z22SectorCapacidad = A22SectorCapacidad;
               Z23SectorPrecio = A23SectorPrecio;
            }
         }
         if ( GX_JID == -38 )
         {
            Z5EspectaculoId = A5EspectaculoId;
            Z9SectorId = A9SectorId;
            Z21SectorNombre = A21SectorNombre;
            Z22SectorCapacidad = A22SectorCapacidad;
            Z23SectorPrecio = A23SectorPrecio;
            Z25SectorEntradasVendidas = A25SectorEntradasVendidas;
         }
      }

      protected void standaloneNotModal034( )
      {
         edtSectorId_Enabled = 0;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtSectorEntradasDisponibles_Enabled = 0;
         AssignProp("", false, edtSectorEntradasDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void standaloneModal034( )
      {
         if ( IsIns( )  && (0==A29CantidadSectores) && ( Gx_BScreen == 0 ) )
         {
            A29CantidadSectores = 0;
            AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         }
         else
         {
            if ( IsIns( )  )
            {
               A29CantidadSectores = (short)(O29CantidadSectores+1);
               AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
            }
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A9SectorId = A29CantidadSectores;
            n9SectorId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00038 */
            pr_default.execute(5, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A25SectorEntradasVendidas = T00038_A25SectorEntradasVendidas[0];
               n25SectorEntradasVendidas = T00038_n25SectorEntradasVendidas[0];
            }
            else
            {
               A25SectorEntradasVendidas = 0;
               n25SectorEntradasVendidas = false;
            }
            pr_default.close(5);
         }
      }

      protected void Load034( )
      {
         /* Using cursor T000337 */
         pr_default.execute(33, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound4 = 1;
            A21SectorNombre = T000337_A21SectorNombre[0];
            A22SectorCapacidad = T000337_A22SectorCapacidad[0];
            A23SectorPrecio = T000337_A23SectorPrecio[0];
            A25SectorEntradasVendidas = T000337_A25SectorEntradasVendidas[0];
            n25SectorEntradasVendidas = T000337_n25SectorEntradasVendidas[0];
            ZM034( -38) ;
         }
         pr_default.close(33);
         OnLoadActions034( ) ;
      }

      protected void OnLoadActions034( )
      {
         A24SectorEntradasDisponibles = (int)(A22SectorCapacidad-A25SectorEntradasVendidas);
      }

      protected void CheckExtendedTable034( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal034( ) ;
         /* Using cursor T00038 */
         pr_default.execute(5, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A25SectorEntradasVendidas = T00038_A25SectorEntradasVendidas[0];
            n25SectorEntradasVendidas = T00038_n25SectorEntradasVendidas[0];
         }
         else
         {
            nIsDirty_4 = 1;
            A25SectorEntradasVendidas = 0;
            n25SectorEntradasVendidas = false;
         }
         pr_default.close(5);
         nIsDirty_4 = 1;
         A24SectorEntradasDisponibles = (int)(A22SectorCapacidad-A25SectorEntradasVendidas);
      }

      protected void CloseExtendedTableCursors034( )
      {
         pr_default.close(5);
      }

      protected void enableDisable034( )
      {
      }

      protected void gxLoad_39( short A5EspectaculoId ,
                                short A9SectorId )
      {
         /* Using cursor T000339 */
         pr_default.execute(34, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(34) != 101) )
         {
            A25SectorEntradasVendidas = T000339_A25SectorEntradasVendidas[0];
            n25SectorEntradasVendidas = T000339_n25SectorEntradasVendidas[0];
         }
         else
         {
            A25SectorEntradasVendidas = 0;
            n25SectorEntradasVendidas = false;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorEntradasVendidas), 5, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(34) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(34);
      }

      protected void GetKey034( )
      {
         /* Using cursor T000340 */
         pr_default.execute(35, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(35);
      }

      protected void getByPrimaryKey034( )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM034( 38) ;
            RcdFound4 = 1;
            InitializeNonKey034( ) ;
            A9SectorId = T00036_A9SectorId[0];
            n9SectorId = T00036_n9SectorId[0];
            A21SectorNombre = T00036_A21SectorNombre[0];
            A22SectorCapacidad = T00036_A22SectorCapacidad[0];
            A23SectorPrecio = T00036_A23SectorPrecio[0];
            Z5EspectaculoId = A5EspectaculoId;
            Z9SectorId = A9SectorId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load034( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey034( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal034( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes034( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency034( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00035 */
            pr_default.execute(3, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoSector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z21SectorNombre, T00035_A21SectorNombre[0]) != 0 ) || ( Z22SectorCapacidad != T00035_A22SectorCapacidad[0] ) || ( Z23SectorPrecio != T00035_A23SectorPrecio[0] ) )
            {
               if ( StringUtil.StrCmp(Z21SectorNombre, T00035_A21SectorNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"SectorNombre");
                  GXUtil.WriteLogRaw("Old: ",Z21SectorNombre);
                  GXUtil.WriteLogRaw("Current: ",T00035_A21SectorNombre[0]);
               }
               if ( Z22SectorCapacidad != T00035_A22SectorCapacidad[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"SectorCapacidad");
                  GXUtil.WriteLogRaw("Old: ",Z22SectorCapacidad);
                  GXUtil.WriteLogRaw("Current: ",T00035_A22SectorCapacidad[0]);
               }
               if ( Z23SectorPrecio != T00035_A23SectorPrecio[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"SectorPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z23SectorPrecio);
                  GXUtil.WriteLogRaw("Current: ",T00035_A23SectorPrecio[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EspectaculoSector"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM034( 0) ;
            CheckOptimisticConcurrency034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000341 */
                     pr_default.execute(36, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId, A21SectorNombre, A22SectorCapacidad, A23SectorPrecio});
                     pr_default.close(36);
                     pr_default.SmartCacheProvider.SetUpdated("EspectaculoSector");
                     if ( (pr_default.getStatus(36) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load034( ) ;
            }
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void Update034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( ( nIsMod_4 != 0 ) || ( nIsDirty_4 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency034( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm034( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate034( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000342 */
                        pr_default.execute(37, new Object[] {A21SectorNombre, A22SectorCapacidad, A23SectorPrecio, A5EspectaculoId, n9SectorId, A9SectorId});
                        pr_default.close(37);
                        pr_default.SmartCacheProvider.SetUpdated("EspectaculoSector");
                        if ( (pr_default.getStatus(37) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoSector"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate034( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey034( ) ;
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
               EndLevel034( ) ;
            }
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void DeferredUpdate034( )
      {
      }

      protected void Delete034( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency034( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls034( ) ;
            AfterConfirm034( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete034( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000343 */
                  pr_default.execute(38, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
                  pr_default.close(38);
                  pr_default.SmartCacheProvider.SetUpdated("EspectaculoSector");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel034( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls034( )
      {
         standaloneModal034( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000345 */
            pr_default.execute(39, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
            if ( (pr_default.getStatus(39) != 101) )
            {
               A25SectorEntradasVendidas = T000345_A25SectorEntradasVendidas[0];
               n25SectorEntradasVendidas = T000345_n25SectorEntradasVendidas[0];
            }
            else
            {
               A25SectorEntradasVendidas = 0;
               n25SectorEntradasVendidas = false;
            }
            pr_default.close(39);
            A24SectorEntradasDisponibles = (int)(A22SectorCapacidad-A25SectorEntradasVendidas);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000346 */
            pr_default.execute(40, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pase"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T000347 */
            pr_default.execute(41, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
         }
      }

      protected void EndLevel034( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart034( )
      {
         /* Scan By routine */
         /* Using cursor T000348 */
         pr_default.execute(42, new Object[] {A5EspectaculoId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(42) != 101) )
         {
            RcdFound4 = 1;
            A9SectorId = T000348_A9SectorId[0];
            n9SectorId = T000348_n9SectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext034( )
      {
         /* Scan next routine */
         pr_default.readNext(42);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(42) != 101) )
         {
            RcdFound4 = 1;
            A9SectorId = T000348_A9SectorId[0];
            n9SectorId = T000348_n9SectorId[0];
         }
      }

      protected void ScanEnd034( )
      {
         pr_default.close(42);
      }

      protected void AfterConfirm034( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert034( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate034( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete034( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete034( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate034( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes034( )
      {
         edtSectorId_Enabled = 0;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtSectorNombre_Enabled = 0;
         AssignProp("", false, edtSectorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorNombre_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtSectorCapacidad_Enabled = 0;
         AssignProp("", false, edtSectorCapacidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCapacidad_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtSectorPrecio_Enabled = 0;
         AssignProp("", false, edtSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorPrecio_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtSectorEntradasVendidas_Enabled = 0;
         AssignProp("", false, edtSectorEntradasVendidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorEntradasVendidas_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtSectorEntradasDisponibles_Enabled = 0;
         AssignProp("", false, edtSectorEntradasDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void send_integrity_lvl_hashes034( )
      {
      }

      protected void ZM035( short GX_JID )
      {
         if ( ( GX_JID == 40 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z39ProductoStockInicial = T00033_A39ProductoStockInicial[0];
               Z40ProductoPrecio = T00033_A40ProductoPrecio[0];
               Z41ProductoCantidadVendidos = T00033_A41ProductoCantidadVendidos[0];
            }
            else
            {
               Z39ProductoStockInicial = A39ProductoStockInicial;
               Z40ProductoPrecio = A40ProductoPrecio;
               Z41ProductoCantidadVendidos = A41ProductoCantidadVendidos;
            }
         }
         if ( GX_JID == -40 )
         {
            Z5EspectaculoId = A5EspectaculoId;
            Z39ProductoStockInicial = A39ProductoStockInicial;
            Z40ProductoPrecio = A40ProductoPrecio;
            Z41ProductoCantidadVendidos = A41ProductoCantidadVendidos;
            Z10ProductoId = A10ProductoId;
            Z38ProductoNombre = A38ProductoNombre;
            Z37ProductoTipo = A37ProductoTipo;
         }
      }

      protected void standaloneNotModal035( )
      {
         edtCantidadProductos_Enabled = 0;
         AssignProp("", false, edtCantidadProductos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCantidadProductos_Enabled), 5, 0), true);
         edtCantidadProductos_Enabled = 0;
         AssignProp("", false, edtCantidadProductos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCantidadProductos_Enabled), 5, 0), true);
      }

      protected void standaloneModal035( )
      {
         if ( IsIns( )  )
         {
            A36CantidadProductos = (short)(O36CantidadProductos+1);
            AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A10ProductoId = A36CantidadProductos;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductoId_Enabled = 0;
            AssignProp("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         }
         else
         {
            edtProductoId_Enabled = 1;
            AssignProp("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A10ProductoId});
            A38ProductoNombre = T00034_A38ProductoNombre[0];
            A37ProductoTipo = T00034_A37ProductoTipo[0];
            pr_default.close(2);
         }
      }

      protected void Load035( )
      {
         /* Using cursor T000349 */
         pr_default.execute(43, new Object[] {A5EspectaculoId, A10ProductoId});
         if ( (pr_default.getStatus(43) != 101) )
         {
            RcdFound5 = 1;
            A38ProductoNombre = T000349_A38ProductoNombre[0];
            A37ProductoTipo = T000349_A37ProductoTipo[0];
            A39ProductoStockInicial = T000349_A39ProductoStockInicial[0];
            A40ProductoPrecio = T000349_A40ProductoPrecio[0];
            A41ProductoCantidadVendidos = T000349_A41ProductoCantidadVendidos[0];
            ZM035( -40) ;
         }
         pr_default.close(43);
         OnLoadActions035( ) ;
      }

      protected void OnLoadActions035( )
      {
         A42ProductoStockActual = (int)(A39ProductoStockInicial-A41ProductoCantidadVendidos);
      }

      protected void CheckExtendedTable035( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal035( ) ;
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A10ProductoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_128_idx;
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A38ProductoNombre = T00034_A38ProductoNombre[0];
         A37ProductoTipo = T00034_A37ProductoTipo[0];
         pr_default.close(2);
         nIsDirty_5 = 1;
         A42ProductoStockActual = (int)(A39ProductoStockInicial-A41ProductoCantidadVendidos);
      }

      protected void CloseExtendedTableCursors035( )
      {
         pr_default.close(2);
      }

      protected void enableDisable035( )
      {
      }

      protected void gxLoad_41( short A10ProductoId )
      {
         /* Using cursor T000350 */
         pr_default.execute(44, new Object[] {A10ProductoId});
         if ( (pr_default.getStatus(44) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_128_idx;
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A38ProductoNombre = T000350_A38ProductoNombre[0];
         A37ProductoTipo = T000350_A37ProductoTipo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A38ProductoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A37ProductoTipo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(44) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(44);
      }

      protected void GetKey035( )
      {
         /* Using cursor T000351 */
         pr_default.execute(45, new Object[] {A5EspectaculoId, A10ProductoId});
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(45);
      }

      protected void getByPrimaryKey035( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A5EspectaculoId, A10ProductoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM035( 40) ;
            RcdFound5 = 1;
            InitializeNonKey035( ) ;
            A39ProductoStockInicial = T00033_A39ProductoStockInicial[0];
            A40ProductoPrecio = T00033_A40ProductoPrecio[0];
            A41ProductoCantidadVendidos = T00033_A41ProductoCantidadVendidos[0];
            A10ProductoId = T00033_A10ProductoId[0];
            Z5EspectaculoId = A5EspectaculoId;
            Z10ProductoId = A10ProductoId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load035( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey035( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal035( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes035( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency035( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A5EspectaculoId, A10ProductoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoProducto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z39ProductoStockInicial != T00032_A39ProductoStockInicial[0] ) || ( Z40ProductoPrecio != T00032_A40ProductoPrecio[0] ) || ( Z41ProductoCantidadVendidos != T00032_A41ProductoCantidadVendidos[0] ) )
            {
               if ( Z39ProductoStockInicial != T00032_A39ProductoStockInicial[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"ProductoStockInicial");
                  GXUtil.WriteLogRaw("Old: ",Z39ProductoStockInicial);
                  GXUtil.WriteLogRaw("Current: ",T00032_A39ProductoStockInicial[0]);
               }
               if ( Z40ProductoPrecio != T00032_A40ProductoPrecio[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"ProductoPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z40ProductoPrecio);
                  GXUtil.WriteLogRaw("Current: ",T00032_A40ProductoPrecio[0]);
               }
               if ( Z41ProductoCantidadVendidos != T00032_A41ProductoCantidadVendidos[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"ProductoCantidadVendidos");
                  GXUtil.WriteLogRaw("Old: ",Z41ProductoCantidadVendidos);
                  GXUtil.WriteLogRaw("Current: ",T00032_A41ProductoCantidadVendidos[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EspectaculoProducto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM035( 0) ;
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000352 */
                     pr_default.execute(46, new Object[] {A5EspectaculoId, A39ProductoStockInicial, A40ProductoPrecio, A41ProductoCantidadVendidos, A10ProductoId});
                     pr_default.close(46);
                     pr_default.SmartCacheProvider.SetUpdated("EspectaculoProducto");
                     if ( (pr_default.getStatus(46) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load035( ) ;
            }
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void Update035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( ( nIsMod_5 != 0 ) || ( nIsDirty_5 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency035( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm035( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate035( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000353 */
                        pr_default.execute(47, new Object[] {A39ProductoStockInicial, A40ProductoPrecio, A41ProductoCantidadVendidos, A5EspectaculoId, A10ProductoId});
                        pr_default.close(47);
                        pr_default.SmartCacheProvider.SetUpdated("EspectaculoProducto");
                        if ( (pr_default.getStatus(47) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoProducto"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate035( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey035( ) ;
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
               EndLevel035( ) ;
            }
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void DeferredUpdate035( )
      {
      }

      protected void Delete035( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls035( ) ;
            AfterConfirm035( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete035( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000354 */
                  pr_default.execute(48, new Object[] {A5EspectaculoId, A10ProductoId});
                  pr_default.close(48);
                  pr_default.SmartCacheProvider.SetUpdated("EspectaculoProducto");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel035( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls035( )
      {
         standaloneModal035( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000355 */
            pr_default.execute(49, new Object[] {A10ProductoId});
            A38ProductoNombre = T000355_A38ProductoNombre[0];
            A37ProductoTipo = T000355_A37ProductoTipo[0];
            pr_default.close(49);
            A42ProductoStockActual = (int)(A39ProductoStockInicial-A41ProductoCantidadVendidos);
         }
      }

      protected void EndLevel035( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart035( )
      {
         /* Scan By routine */
         /* Using cursor T000356 */
         pr_default.execute(50, new Object[] {A5EspectaculoId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(50) != 101) )
         {
            RcdFound5 = 1;
            A10ProductoId = T000356_A10ProductoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext035( )
      {
         /* Scan next routine */
         pr_default.readNext(50);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(50) != 101) )
         {
            RcdFound5 = 1;
            A10ProductoId = T000356_A10ProductoId[0];
         }
      }

      protected void ScanEnd035( )
      {
         pr_default.close(50);
      }

      protected void AfterConfirm035( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert035( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate035( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete035( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete035( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate035( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes035( )
      {
         edtProductoId_Enabled = 0;
         AssignProp("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtProductoNombre_Enabled = 0;
         AssignProp("", false, edtProductoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoNombre_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         cmbProductoTipo.Enabled = 0;
         AssignProp("", false, cmbProductoTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProductoTipo.Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtProductoStockInicial_Enabled = 0;
         AssignProp("", false, edtProductoStockInicial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoStockInicial_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtProductoPrecio_Enabled = 0;
         AssignProp("", false, edtProductoPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPrecio_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtProductoCantidadVendidos_Enabled = 0;
         AssignProp("", false, edtProductoCantidadVendidos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoCantidadVendidos_Enabled), 5, 0), !bGXsfl_128_Refreshing);
         edtProductoStockActual_Enabled = 0;
         AssignProp("", false, edtProductoStockActual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoStockActual_Enabled), 5, 0), !bGXsfl_128_Refreshing);
      }

      protected void send_integrity_lvl_hashes035( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void SubsflControlProps_1134( )
      {
         edtSectorId_Internalname = "SECTORID_"+sGXsfl_113_idx;
         edtSectorNombre_Internalname = "SECTORNOMBRE_"+sGXsfl_113_idx;
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD_"+sGXsfl_113_idx;
         edtSectorPrecio_Internalname = "SECTORPRECIO_"+sGXsfl_113_idx;
         edtSectorEntradasVendidas_Internalname = "SECTORENTRADASVENDIDAS_"+sGXsfl_113_idx;
         edtSectorEntradasDisponibles_Internalname = "SECTORENTRADASDISPONIBLES_"+sGXsfl_113_idx;
      }

      protected void SubsflControlProps_fel_1134( )
      {
         edtSectorId_Internalname = "SECTORID_"+sGXsfl_113_fel_idx;
         edtSectorNombre_Internalname = "SECTORNOMBRE_"+sGXsfl_113_fel_idx;
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD_"+sGXsfl_113_fel_idx;
         edtSectorPrecio_Internalname = "SECTORPRECIO_"+sGXsfl_113_fel_idx;
         edtSectorEntradasVendidas_Internalname = "SECTORENTRADASVENDIDAS_"+sGXsfl_113_fel_idx;
         edtSectorEntradasDisponibles_Internalname = "SECTORENTRADASDISPONIBLES_"+sGXsfl_113_fel_idx;
      }

      protected void AddRow034( )
      {
         nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_1134( ) ;
         SendRow034( ) ;
      }

      protected void SendRow034( )
      {
         Gridespectaculo_sectorRow = GXWebRow.GetNew(context);
         if ( subGridespectaculo_sector_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridespectaculo_sector_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridespectaculo_sector_Class, "") != 0 )
            {
               subGridespectaculo_sector_Linesclass = subGridespectaculo_sector_Class+"Odd";
            }
         }
         else if ( subGridespectaculo_sector_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridespectaculo_sector_Backstyle = 0;
            subGridespectaculo_sector_Backcolor = subGridespectaculo_sector_Allbackcolor;
            if ( StringUtil.StrCmp(subGridespectaculo_sector_Class, "") != 0 )
            {
               subGridespectaculo_sector_Linesclass = subGridespectaculo_sector_Class+"Uniform";
            }
         }
         else if ( subGridespectaculo_sector_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridespectaculo_sector_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridespectaculo_sector_Class, "") != 0 )
            {
               subGridespectaculo_sector_Linesclass = subGridespectaculo_sector_Class+"Odd";
            }
            subGridespectaculo_sector_Backcolor = (int)(0x0);
         }
         else if ( subGridespectaculo_sector_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridespectaculo_sector_Backstyle = 1;
            if ( ((int)((nGXsfl_113_idx) % (2))) == 0 )
            {
               subGridespectaculo_sector_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_sector_Class, "") != 0 )
               {
                  subGridespectaculo_sector_Linesclass = subGridespectaculo_sector_Class+"Even";
               }
            }
            else
            {
               subGridespectaculo_sector_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_sector_Class, "") != 0 )
               {
                  subGridespectaculo_sector_Linesclass = subGridespectaculo_sector_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")),StringUtil.LTrim( ((edtSectorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9") : context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9"))),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridespectaculo_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorNombre_Internalname,StringUtil.RTrim( A21SectorNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 116,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridespectaculo_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorCapacidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ",", "")),StringUtil.LTrim( ((edtSectorCapacidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A22SectorCapacidad), "ZZZZ9") : context.localUtil.Format( (decimal)(A22SectorCapacidad), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,116);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorCapacidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorCapacidad_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridespectaculo_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ",", "")),StringUtil.LTrim( ((edtSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9") : context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,117);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorPrecio_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorEntradasVendidas_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorEntradasVendidas), 5, 0, ",", "")),StringUtil.LTrim( ((edtSectorEntradasVendidas_Enabled!=0) ? context.localUtil.Format( (decimal)(A25SectorEntradasVendidas), "ZZZZ9") : context.localUtil.Format( (decimal)(A25SectorEntradasVendidas), "ZZZZ9"))),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorEntradasVendidas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorEntradasVendidas_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorEntradasDisponibles_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A24SectorEntradasDisponibles), 5, 0, ",", "")),StringUtil.LTrim( ((edtSectorEntradasDisponibles_Enabled!=0) ? context.localUtil.Format( (decimal)(A24SectorEntradasDisponibles), "ZZZZ9") : context.localUtil.Format( (decimal)(A24SectorEntradasDisponibles), "ZZZZ9"))),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorEntradasDisponibles_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorEntradasDisponibles_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridespectaculo_sectorRow);
         send_integrity_lvl_hashes034( ) ;
         GXCCtl = "Z9SectorId_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SectorId), 4, 0, ",", "")));
         GXCCtl = "Z21SectorNombre_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z21SectorNombre));
         GXCCtl = "Z22SectorCapacidad_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22SectorCapacidad), 5, 0, ",", "")));
         GXCCtl = "Z23SectorPrecio_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23SectorPrecio), 6, 0, ",", "")));
         GXCCtl = "nRcdDeleted_4_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_4_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, ",", "")));
         GXCCtl = "nIsMod_4_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_113_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vESPECTACULOID_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECTORID_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORNOMBRE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORCAPACIDAD_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCapacidad_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORPRECIO_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorPrecio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORENTRADASVENDIDAS_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorEntradasVendidas_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORENTRADASDISPONIBLES_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridespectaculo_sectorContainer.AddRow(Gridespectaculo_sectorRow);
      }

      protected void ReadRow034( )
      {
         nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_1134( ) ;
         edtSectorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORID_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtSectorNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORNOMBRE_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtSectorCapacidad_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORCAPACIDAD_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtSectorPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORPRECIO_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtSectorEntradasVendidas_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORENTRADASVENDIDAS_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtSectorEntradasDisponibles_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORENTRADASDISPONIBLES_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         A9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         A21SectorNombre = cgiGet( edtSectorNombre_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
         {
            GXCCtl = "SECTORCAPACIDAD_" + sGXsfl_113_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSectorCapacidad_Internalname;
            wbErr = true;
            A22SectorCapacidad = 0;
         }
         else
         {
            A22SectorCapacidad = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "SECTORPRECIO_" + sGXsfl_113_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSectorPrecio_Internalname;
            wbErr = true;
            A23SectorPrecio = 0;
         }
         else
         {
            A23SectorPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A25SectorEntradasVendidas = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorEntradasVendidas_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         n25SectorEntradasVendidas = false;
         A24SectorEntradasDisponibles = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorEntradasDisponibles_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z9SectorId_" + sGXsfl_113_idx;
         Z9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z21SectorNombre_" + sGXsfl_113_idx;
         Z21SectorNombre = cgiGet( GXCCtl);
         GXCCtl = "Z22SectorCapacidad_" + sGXsfl_113_idx;
         Z22SectorCapacidad = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z23SectorPrecio_" + sGXsfl_113_idx;
         Z23SectorPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_4_" + sGXsfl_113_idx;
         nRcdDeleted_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_4_" + sGXsfl_113_idx;
         nRcdExists_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_4_" + sGXsfl_113_idx;
         nIsMod_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_1285( )
      {
         edtProductoId_Internalname = "PRODUCTOID_"+sGXsfl_128_idx;
         imgprompt_10_Internalname = "PROMPT_10_"+sGXsfl_128_idx;
         edtProductoNombre_Internalname = "PRODUCTONOMBRE_"+sGXsfl_128_idx;
         cmbProductoTipo_Internalname = "PRODUCTOTIPO_"+sGXsfl_128_idx;
         edtProductoStockInicial_Internalname = "PRODUCTOSTOCKINICIAL_"+sGXsfl_128_idx;
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO_"+sGXsfl_128_idx;
         edtProductoCantidadVendidos_Internalname = "PRODUCTOCANTIDADVENDIDOS_"+sGXsfl_128_idx;
         edtProductoStockActual_Internalname = "PRODUCTOSTOCKACTUAL_"+sGXsfl_128_idx;
      }

      protected void SubsflControlProps_fel_1285( )
      {
         edtProductoId_Internalname = "PRODUCTOID_"+sGXsfl_128_fel_idx;
         imgprompt_10_Internalname = "PROMPT_10_"+sGXsfl_128_fel_idx;
         edtProductoNombre_Internalname = "PRODUCTONOMBRE_"+sGXsfl_128_fel_idx;
         cmbProductoTipo_Internalname = "PRODUCTOTIPO_"+sGXsfl_128_fel_idx;
         edtProductoStockInicial_Internalname = "PRODUCTOSTOCKINICIAL_"+sGXsfl_128_fel_idx;
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO_"+sGXsfl_128_fel_idx;
         edtProductoCantidadVendidos_Internalname = "PRODUCTOCANTIDADVENDIDOS_"+sGXsfl_128_fel_idx;
         edtProductoStockActual_Internalname = "PRODUCTOSTOCKACTUAL_"+sGXsfl_128_fel_idx;
      }

      protected void AddRow035( )
      {
         nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
         sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
         SubsflControlProps_1285( ) ;
         SendRow035( ) ;
      }

      protected void SendRow035( )
      {
         Gridespectaculo_productoRow = GXWebRow.GetNew(context);
         if ( subGridespectaculo_producto_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridespectaculo_producto_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridespectaculo_producto_Class, "") != 0 )
            {
               subGridespectaculo_producto_Linesclass = subGridespectaculo_producto_Class+"Odd";
            }
         }
         else if ( subGridespectaculo_producto_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridespectaculo_producto_Backstyle = 0;
            subGridespectaculo_producto_Backcolor = subGridespectaculo_producto_Allbackcolor;
            if ( StringUtil.StrCmp(subGridespectaculo_producto_Class, "") != 0 )
            {
               subGridespectaculo_producto_Linesclass = subGridespectaculo_producto_Class+"Uniform";
            }
         }
         else if ( subGridespectaculo_producto_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridespectaculo_producto_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridespectaculo_producto_Class, "") != 0 )
            {
               subGridespectaculo_producto_Linesclass = subGridespectaculo_producto_Class+"Odd";
            }
            subGridespectaculo_producto_Backcolor = (int)(0x0);
         }
         else if ( subGridespectaculo_producto_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridespectaculo_producto_Backstyle = 1;
            if ( ((int)((nGXsfl_128_idx) % (2))) == 0 )
            {
               subGridespectaculo_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_producto_Class, "") != 0 )
               {
                  subGridespectaculo_producto_Linesclass = subGridespectaculo_producto_Class+"Even";
               }
            }
            else
            {
               subGridespectaculo_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_producto_Class, "") != 0 )
               {
                  subGridespectaculo_producto_Linesclass = subGridespectaculo_producto_Class+"Odd";
               }
            }
         }
         imgprompt_10_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00a0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTOID_"+sGXsfl_128_idx+"'), id:'"+"PRODUCTOID_"+sGXsfl_128_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_5_"+sGXsfl_128_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridespectaculo_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10ProductoId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,129);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductoId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_10_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_10_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridespectaculo_productoRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_10_Internalname,(string)sImgUrl,(string)imgprompt_10_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_10_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoNombre_Internalname,StringUtil.RTrim( A38ProductoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductoNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         GXCCtl = "PRODUCTOTIPO_" + sGXsfl_128_idx;
         cmbProductoTipo.Name = GXCCtl;
         cmbProductoTipo.WebTags = "";
         cmbProductoTipo.addItem("Bebida", "Bebida", 0);
         cmbProductoTipo.addItem("Snack", "Snack", 0);
         cmbProductoTipo.addItem("Souvenir", "Souvenir", 0);
         if ( cmbProductoTipo.ItemCount > 0 )
         {
            A37ProductoTipo = cmbProductoTipo.getValidValue(A37ProductoTipo);
         }
         /* ComboBox */
         Gridespectaculo_productoRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProductoTipo,(string)cmbProductoTipo_Internalname,StringUtil.RTrim( A37ProductoTipo),(short)1,(string)cmbProductoTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbProductoTipo.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
         cmbProductoTipo.CurrentValue = StringUtil.RTrim( A37ProductoTipo);
         AssignProp("", false, cmbProductoTipo_Internalname, "Values", (string)(cmbProductoTipo.ToJavascriptSource()), !bGXsfl_128_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridespectaculo_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoStockInicial_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A39ProductoStockInicial), 5, 0, ",", "")),StringUtil.LTrim( ((edtProductoStockInicial_Enabled!=0) ? context.localUtil.Format( (decimal)(A39ProductoStockInicial), "ZZZZ9") : context.localUtil.Format( (decimal)(A39ProductoStockInicial), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,132);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoStockInicial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductoStockInicial_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 133,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridespectaculo_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A40ProductoPrecio), 5, 0, ",", "")),StringUtil.LTrim( ((edtProductoPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A40ProductoPrecio), "ZZZZ9") : context.localUtil.Format( (decimal)(A40ProductoPrecio), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,133);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductoPrecio_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_128_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_128_idx + "',128)\"";
         ROClassString = "Attribute";
         Gridespectaculo_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoCantidadVendidos_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41ProductoCantidadVendidos), 5, 0, ",", "")),StringUtil.LTrim( ((edtProductoCantidadVendidos_Enabled!=0) ? context.localUtil.Format( (decimal)(A41ProductoCantidadVendidos), "ZZZZ9") : context.localUtil.Format( (decimal)(A41ProductoCantidadVendidos), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,134);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoCantidadVendidos_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductoCantidadVendidos_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoStockActual_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ProductoStockActual), 5, 0, ",", "")),StringUtil.LTrim( ((edtProductoStockActual_Enabled!=0) ? context.localUtil.Format( (decimal)(A42ProductoStockActual), "ZZZZ9") : context.localUtil.Format( (decimal)(A42ProductoStockActual), "ZZZZ9"))),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoStockActual_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductoStockActual_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)128,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridespectaculo_productoRow);
         send_integrity_lvl_hashes035( ) ;
         GXCCtl = "Z10ProductoId_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductoId), 4, 0, ",", "")));
         GXCCtl = "Z39ProductoStockInicial_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39ProductoStockInicial), 5, 0, ",", "")));
         GXCCtl = "Z40ProductoPrecio_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40ProductoPrecio), 5, 0, ",", "")));
         GXCCtl = "Z41ProductoCantidadVendidos_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41ProductoCantidadVendidos), 5, 0, ",", "")));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_5_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ",", "")));
         GXCCtl = "nIsMod_5_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_128_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vESPECTACULOID_" + sGXsfl_128_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOID_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTONOMBRE_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOTIPO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProductoTipo.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOSTOCKINICIAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoStockInicial_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOPRECIO_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOCANTIDADVENDIDOS_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoCantidadVendidos_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOSTOCKACTUAL_"+sGXsfl_128_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoStockActual_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_10_"+sGXsfl_128_idx+"Link", StringUtil.RTrim( imgprompt_10_Link));
         ajax_sending_grid_row(null);
         Gridespectaculo_productoContainer.AddRow(Gridespectaculo_productoRow);
      }

      protected void ReadRow035( )
      {
         nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
         sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
         SubsflControlProps_1285( ) ;
         edtProductoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductoNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTONOMBRE_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         cmbProductoTipo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOTIPO_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductoStockInicial_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOSTOCKINICIAL_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductoPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOPRECIO_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductoCantidadVendidos_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOCANTIDADVENDIDOS_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductoStockActual_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOSTOCKACTUAL_"+sGXsfl_128_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         imgprompt_6_Link = cgiGet( "PROMPT_10_"+sGXsfl_128_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_128_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoId_Internalname;
            wbErr = true;
            A10ProductoId = 0;
         }
         else
         {
            A10ProductoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A38ProductoNombre = cgiGet( edtProductoNombre_Internalname);
         cmbProductoTipo.Name = cmbProductoTipo_Internalname;
         cmbProductoTipo.CurrentValue = cgiGet( cmbProductoTipo_Internalname);
         A37ProductoTipo = cgiGet( cmbProductoTipo_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductoStockInicial_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductoStockInicial_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
         {
            GXCCtl = "PRODUCTOSTOCKINICIAL_" + sGXsfl_128_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoStockInicial_Internalname;
            wbErr = true;
            A39ProductoStockInicial = 0;
         }
         else
         {
            A39ProductoStockInicial = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoStockInicial_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
         {
            GXCCtl = "PRODUCTOPRECIO_" + sGXsfl_128_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoPrecio_Internalname;
            wbErr = true;
            A40ProductoPrecio = 0;
         }
         else
         {
            A40ProductoPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductoCantidadVendidos_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductoCantidadVendidos_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
         {
            GXCCtl = "PRODUCTOCANTIDADVENDIDOS_" + sGXsfl_128_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoCantidadVendidos_Internalname;
            wbErr = true;
            A41ProductoCantidadVendidos = 0;
         }
         else
         {
            A41ProductoCantidadVendidos = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoCantidadVendidos_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A42ProductoStockActual = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoStockActual_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z10ProductoId_" + sGXsfl_128_idx;
         Z10ProductoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z39ProductoStockInicial_" + sGXsfl_128_idx;
         Z39ProductoStockInicial = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z40ProductoPrecio_" + sGXsfl_128_idx;
         Z40ProductoPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z41ProductoCantidadVendidos_" + sGXsfl_128_idx;
         Z41ProductoCantidadVendidos = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_128_idx;
         nRcdDeleted_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_5_" + sGXsfl_128_idx;
         nRcdExists_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_5_" + sGXsfl_128_idx;
         nIsMod_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProductoId_Enabled = edtProductoId_Enabled;
         defedtSectorEntradasDisponibles_Enabled = edtSectorEntradasDisponibles_Enabled;
         defedtSectorId_Enabled = edtSectorId_Enabled;
      }

      protected void ConfirmValues030( )
      {
         nGXsfl_113_idx = 0;
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_1134( ) ;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1134( ) ;
            ChangePostValue( "Z9SectorId_"+sGXsfl_113_idx, cgiGet( "ZT_"+"Z9SectorId_"+sGXsfl_113_idx)) ;
            DeletePostValue( "ZT_"+"Z9SectorId_"+sGXsfl_113_idx) ;
            ChangePostValue( "Z21SectorNombre_"+sGXsfl_113_idx, cgiGet( "ZT_"+"Z21SectorNombre_"+sGXsfl_113_idx)) ;
            DeletePostValue( "ZT_"+"Z21SectorNombre_"+sGXsfl_113_idx) ;
            ChangePostValue( "Z22SectorCapacidad_"+sGXsfl_113_idx, cgiGet( "ZT_"+"Z22SectorCapacidad_"+sGXsfl_113_idx)) ;
            DeletePostValue( "ZT_"+"Z22SectorCapacidad_"+sGXsfl_113_idx) ;
            ChangePostValue( "Z23SectorPrecio_"+sGXsfl_113_idx, cgiGet( "ZT_"+"Z23SectorPrecio_"+sGXsfl_113_idx)) ;
            DeletePostValue( "ZT_"+"Z23SectorPrecio_"+sGXsfl_113_idx) ;
         }
         nGXsfl_128_idx = 0;
         sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
         SubsflControlProps_1285( ) ;
         while ( nGXsfl_128_idx < nRC_GXsfl_128 )
         {
            nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
            sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
            SubsflControlProps_1285( ) ;
            ChangePostValue( "Z10ProductoId_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z10ProductoId_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z10ProductoId_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z39ProductoStockInicial_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z39ProductoStockInicial_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z39ProductoStockInicial_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z40ProductoPrecio_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z40ProductoPrecio_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z40ProductoPrecio_"+sGXsfl_128_idx) ;
            ChangePostValue( "Z41ProductoCantidadVendidos_"+sGXsfl_128_idx, cgiGet( "ZT_"+"Z41ProductoCantidadVendidos_"+sGXsfl_128_idx)) ;
            DeletePostValue( "ZT_"+"Z41ProductoCantidadVendidos_"+sGXsfl_128_idx) ;
         }
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 456460), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 456460), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 456460), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 456460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 456460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 456460), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("espectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV15EspectaculoId,4,0))}, new string[] {"Gx_mode","EspectaculoId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Espectaculo");
         forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9"));
         forbiddenHiddens.Add("EspectaculoInvitacionesEntrega", context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("espectaculo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z5EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z8EspectaculoNombre", StringUtil.RTrim( Z8EspectaculoNombre));
         GxWebStd.gx_hidden_field( context, "Z19EspectaculoFecha", context.localUtil.DToC( Z19EspectaculoFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z31EspectaculoCantidadInvitacione", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31EspectaculoCantidadInvitacione), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z33EspectaculoInvitacionesEntrega", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33EspectaculoInvitacionesEntrega), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z29CantidadSectores", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29CantidadSectores), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z36CantidadProductos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36CantidadProductos), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z6TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z3LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z7PaisOrigenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7PaisOrigenId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O36CantidadProductos", StringUtil.LTrim( StringUtil.NToC( (decimal)(O36CantidadProductos), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O29CantidadSectores", StringUtil.LTrim( StringUtil.NToC( (decimal)(O29CantidadSectores), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_113", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_113_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_128", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_128_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N6TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N3LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N7PaisOrigenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7PaisOrigenId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EspectaculoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Insert_TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Insert_LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISORIGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Insert_PaisOrigenId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CANTIDADSECTORES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29CantidadSectores), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOAFICHE_GXI", A40000EspectaculoAfiche_GXI);
         GxWebStd.gx_hidden_field( context, "PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
         GXCCtlgxBlob = "ESPECTACULOAFICHE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A20EspectaculoAfiche);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("espectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV15EspectaculoId,4,0))}, new string[] {"Gx_mode","EspectaculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Espectaculo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Espectaculo" ;
      }

      protected void InitializeNonKey033( )
      {
         A1PaisId = 0;
         AssignAttri("", false, "A1PaisId", StringUtil.LTrimStr( (decimal)(A1PaisId), 4, 0));
         A6TipoEspectaculoId = 0;
         AssignAttri("", false, "A6TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A6TipoEspectaculoId), 4, 0));
         A3LugarId = 0;
         AssignAttri("", false, "A3LugarId", StringUtil.LTrimStr( (decimal)(A3LugarId), 4, 0));
         A7PaisOrigenId = 0;
         AssignAttri("", false, "A7PaisOrigenId", StringUtil.LTrimStr( (decimal)(A7PaisOrigenId), 4, 0));
         A32EspectaculoInvitacionesDisponi = 0;
         AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         A8EspectaculoNombre = "";
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A16TipoEspectaculoNombre = "";
         AssignAttri("", false, "A16TipoEspectaculoNombre", A16TipoEspectaculoNombre);
         A4LugarNombre = "";
         AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
         A2PaisNombre = "";
         AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
         A28PaisOrigenNombre = "";
         AssignAttri("", false, "A28PaisOrigenNombre", A28PaisOrigenNombre);
         A20EspectaculoAfiche = "";
         AssignAttri("", false, "A20EspectaculoAfiche", A20EspectaculoAfiche);
         AssignProp("", false, imgEspectaculoAfiche_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : context.convertURL( context.PathToRelativeUrl( A20EspectaculoAfiche))), true);
         AssignProp("", false, imgEspectaculoAfiche_Internalname, "SrcSet", context.GetImageSrcSet( A20EspectaculoAfiche), true);
         A40000EspectaculoAfiche_GXI = "";
         AssignProp("", false, imgEspectaculoAfiche_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A20EspectaculoAfiche)) ? A40000EspectaculoAfiche_GXI : context.convertURL( context.PathToRelativeUrl( A20EspectaculoAfiche))), true);
         AssignProp("", false, imgEspectaculoAfiche_Internalname, "SrcSet", context.GetImageSrcSet( A20EspectaculoAfiche), true);
         A31EspectaculoCantidadInvitacione = 0;
         AssignAttri("", false, "A31EspectaculoCantidadInvitacione", StringUtil.LTrimStr( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0));
         A36CantidadProductos = 0;
         AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
         A19EspectaculoFecha = DateTimeUtil.Today( context);
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         A33EspectaculoInvitacionesEntrega = 0;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         A29CantidadSectores = 0;
         AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         O36CantidadProductos = A36CantidadProductos;
         AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
         O29CantidadSectores = A29CantidadSectores;
         AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
         Z8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
         Z31EspectaculoCantidadInvitacione = 0;
         Z33EspectaculoInvitacionesEntrega = 0;
         Z29CantidadSectores = 0;
         Z36CantidadProductos = 0;
         Z6TipoEspectaculoId = 0;
         Z3LugarId = 0;
         Z7PaisOrigenId = 0;
      }

      protected void InitAll033( )
      {
         A5EspectaculoId = 0;
         AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A33EspectaculoInvitacionesEntrega = i33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         A19EspectaculoFecha = i19EspectaculoFecha;
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         A29CantidadSectores = i29CantidadSectores;
         AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
      }

      protected void InitializeNonKey034( )
      {
         A24SectorEntradasDisponibles = 0;
         A21SectorNombre = "";
         A22SectorCapacidad = 0;
         A23SectorPrecio = 0;
         A25SectorEntradasVendidas = 0;
         n25SectorEntradasVendidas = false;
         Z21SectorNombre = "";
         Z22SectorCapacidad = 0;
         Z23SectorPrecio = 0;
      }

      protected void InitAll034( )
      {
         A9SectorId = 0;
         n9SectorId = false;
         InitializeNonKey034( ) ;
      }

      protected void StandaloneModalInsert034( )
      {
         A29CantidadSectores = i29CantidadSectores;
         AssignAttri("", false, "A29CantidadSectores", StringUtil.LTrimStr( (decimal)(A29CantidadSectores), 4, 0));
      }

      protected void InitializeNonKey035( )
      {
         A42ProductoStockActual = 0;
         A38ProductoNombre = "";
         A37ProductoTipo = "";
         A39ProductoStockInicial = 0;
         A40ProductoPrecio = 0;
         A41ProductoCantidadVendidos = 0;
         Z39ProductoStockInicial = 0;
         Z40ProductoPrecio = 0;
         Z41ProductoCantidadVendidos = 0;
      }

      protected void InitAll035( )
      {
         A10ProductoId = 0;
         InitializeNonKey035( ) ;
      }

      protected void StandaloneModalInsert035( )
      {
         A36CantidadProductos = i36CantidadProductos;
         AssignAttri("", false, "A36CantidadProductos", StringUtil.LTrimStr( (decimal)(A36CantidadProductos), 4, 0));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874471526", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("espectaculo.js", "?2023874471526", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties4( )
      {
         edtSectorEntradasDisponibles_Enabled = defedtSectorEntradasDisponibles_Enabled;
         AssignProp("", false, edtSectorEntradasDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtSectorId_Enabled = defedtSectorId_Enabled;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void init_level_properties5( )
      {
         edtProductoId_Enabled = defedtProductoId_Enabled;
         AssignProp("", false, edtProductoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoId_Enabled), 5, 0), !bGXsfl_128_Refreshing);
      }

      protected void StartGridControl113( )
      {
         Gridespectaculo_sectorContainer.AddObjectProperty("GridName", "Gridespectaculo_sector");
         Gridespectaculo_sectorContainer.AddObjectProperty("Header", subGridespectaculo_sector_Header);
         Gridespectaculo_sectorContainer.AddObjectProperty("Class", "Grid");
         Gridespectaculo_sectorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_sector_Backcolorstyle), 1, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("CmpContext", "");
         Gridespectaculo_sectorContainer.AddObjectProperty("InMasterPage", "false");
         Gridespectaculo_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_sectorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ".", ""))));
         Gridespectaculo_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorId_Enabled), 5, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddColumnProperties(Gridespectaculo_sectorColumn);
         Gridespectaculo_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_sectorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A21SectorNombre)));
         Gridespectaculo_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorNombre_Enabled), 5, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddColumnProperties(Gridespectaculo_sectorColumn);
         Gridespectaculo_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_sectorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ".", ""))));
         Gridespectaculo_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCapacidad_Enabled), 5, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddColumnProperties(Gridespectaculo_sectorColumn);
         Gridespectaculo_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_sectorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ".", ""))));
         Gridespectaculo_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorPrecio_Enabled), 5, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddColumnProperties(Gridespectaculo_sectorColumn);
         Gridespectaculo_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_sectorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorEntradasVendidas), 5, 0, ".", ""))));
         Gridespectaculo_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorEntradasVendidas_Enabled), 5, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddColumnProperties(Gridespectaculo_sectorColumn);
         Gridespectaculo_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_sectorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A24SectorEntradasDisponibles), 5, 0, ".", ""))));
         Gridespectaculo_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddColumnProperties(Gridespectaculo_sectorColumn);
         Gridespectaculo_sectorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_sector_Selectedindex), 4, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_sector_Allowselection), 1, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_sector_Selectioncolor), 9, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_sector_Allowhovering), 1, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_sector_Hoveringcolor), 9, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_sector_Allowcollapsing), 1, 0, ".", "")));
         Gridespectaculo_sectorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_sector_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl128( )
      {
         Gridespectaculo_productoContainer.AddObjectProperty("GridName", "Gridespectaculo_producto");
         Gridespectaculo_productoContainer.AddObjectProperty("Header", subGridespectaculo_producto_Header);
         Gridespectaculo_productoContainer.AddObjectProperty("Class", "Grid");
         Gridespectaculo_productoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_producto_Backcolorstyle), 1, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("CmpContext", "");
         Gridespectaculo_productoContainer.AddObjectProperty("InMasterPage", "false");
         Gridespectaculo_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductoId), 4, 0, ".", ""))));
         Gridespectaculo_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoId_Enabled), 5, 0, ".", "")));
         Gridespectaculo_productoContainer.AddColumnProperties(Gridespectaculo_productoColumn);
         Gridespectaculo_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_productoContainer.AddColumnProperties(Gridespectaculo_productoColumn);
         Gridespectaculo_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A38ProductoNombre)));
         Gridespectaculo_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoNombre_Enabled), 5, 0, ".", "")));
         Gridespectaculo_productoContainer.AddColumnProperties(Gridespectaculo_productoColumn);
         Gridespectaculo_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A37ProductoTipo)));
         Gridespectaculo_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProductoTipo.Enabled), 5, 0, ".", "")));
         Gridespectaculo_productoContainer.AddColumnProperties(Gridespectaculo_productoColumn);
         Gridespectaculo_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A39ProductoStockInicial), 5, 0, ".", ""))));
         Gridespectaculo_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoStockInicial_Enabled), 5, 0, ".", "")));
         Gridespectaculo_productoContainer.AddColumnProperties(Gridespectaculo_productoColumn);
         Gridespectaculo_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A40ProductoPrecio), 5, 0, ".", ""))));
         Gridespectaculo_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", "")));
         Gridespectaculo_productoContainer.AddColumnProperties(Gridespectaculo_productoColumn);
         Gridespectaculo_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41ProductoCantidadVendidos), 5, 0, ".", ""))));
         Gridespectaculo_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoCantidadVendidos_Enabled), 5, 0, ".", "")));
         Gridespectaculo_productoContainer.AddColumnProperties(Gridespectaculo_productoColumn);
         Gridespectaculo_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_productoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ProductoStockActual), 5, 0, ".", ""))));
         Gridespectaculo_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoStockActual_Enabled), 5, 0, ".", "")));
         Gridespectaculo_productoContainer.AddColumnProperties(Gridespectaculo_productoColumn);
         Gridespectaculo_productoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_producto_Selectedindex), 4, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_producto_Allowselection), 1, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_producto_Selectioncolor), 9, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_producto_Allowhovering), 1, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_producto_Hoveringcolor), 9, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_producto_Allowcollapsing), 1, 0, ".", "")));
         Gridespectaculo_productoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_producto_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoNombre_Internalname = "ESPECTACULONOMBRE";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtTipoEspectaculoId_Internalname = "TIPOESPECTACULOID";
         edtTipoEspectaculoNombre_Internalname = "TIPOESPECTACULONOMBRE";
         edtLugarId_Internalname = "LUGARID";
         edtLugarNombre_Internalname = "LUGARNOMBRE";
         edtPaisNombre_Internalname = "PAISNOMBRE";
         edtPaisOrigenId_Internalname = "PAISORIGENID";
         edtPaisOrigenNombre_Internalname = "PAISORIGENNOMBRE";
         imgEspectaculoAfiche_Internalname = "ESPECTACULOAFICHE";
         edtEspectaculoCantidadInvitacione_Internalname = "ESPECTACULOCANTIDADINVITACIONE";
         edtEspectaculoInvitacionesDisponi_Internalname = "ESPECTACULOINVITACIONESDISPONI";
         edtEspectaculoInvitacionesEntrega_Internalname = "ESPECTACULOINVITACIONESENTREGA";
         edtCantidadProductos_Internalname = "CANTIDADPRODUCTOS";
         lblTitlesector_Internalname = "TITLESECTOR";
         edtSectorId_Internalname = "SECTORID";
         edtSectorNombre_Internalname = "SECTORNOMBRE";
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD";
         edtSectorPrecio_Internalname = "SECTORPRECIO";
         edtSectorEntradasVendidas_Internalname = "SECTORENTRADASVENDIDAS";
         edtSectorEntradasDisponibles_Internalname = "SECTORENTRADASDISPONIBLES";
         divSectortable_Internalname = "SECTORTABLE";
         lblTitleproducto_Internalname = "TITLEPRODUCTO";
         edtProductoId_Internalname = "PRODUCTOID";
         edtProductoNombre_Internalname = "PRODUCTONOMBRE";
         cmbProductoTipo_Internalname = "PRODUCTOTIPO";
         edtProductoStockInicial_Internalname = "PRODUCTOSTOCKINICIAL";
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO";
         edtProductoCantidadVendidos_Internalname = "PRODUCTOCANTIDADVENDIDOS";
         edtProductoStockActual_Internalname = "PRODUCTOSTOCKACTUAL";
         divProductotable_Internalname = "PRODUCTOTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_6_Internalname = "PROMPT_6";
         imgprompt_3_Internalname = "PROMPT_3";
         imgprompt_7_Internalname = "PROMPT_7";
         imgprompt_10_Internalname = "PROMPT_10";
         subGridespectaculo_sector_Internalname = "GRIDESPECTACULO_SECTOR";
         subGridespectaculo_producto_Internalname = "GRIDESPECTACULO_PRODUCTO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridespectaculo_producto_Allowcollapsing = 0;
         subGridespectaculo_producto_Allowselection = 0;
         subGridespectaculo_producto_Header = "";
         subGridespectaculo_sector_Allowcollapsing = 0;
         subGridespectaculo_sector_Allowselection = 0;
         subGridespectaculo_sector_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Espectaculo";
         edtProductoStockActual_Jsonclick = "";
         edtProductoCantidadVendidos_Jsonclick = "";
         edtProductoPrecio_Jsonclick = "";
         edtProductoStockInicial_Jsonclick = "";
         cmbProductoTipo_Jsonclick = "";
         edtProductoNombre_Jsonclick = "";
         imgprompt_10_Visible = 1;
         imgprompt_10_Link = "";
         imgprompt_6_Visible = 1;
         edtProductoId_Jsonclick = "";
         subGridespectaculo_producto_Class = "Grid";
         subGridespectaculo_producto_Backcolorstyle = 0;
         edtSectorEntradasDisponibles_Jsonclick = "";
         edtSectorEntradasVendidas_Jsonclick = "";
         edtSectorPrecio_Jsonclick = "";
         edtSectorCapacidad_Jsonclick = "";
         edtSectorNombre_Jsonclick = "";
         edtSectorId_Jsonclick = "";
         subGridespectaculo_sector_Class = "Grid";
         subGridespectaculo_sector_Backcolorstyle = 0;
         edtProductoStockActual_Enabled = 0;
         edtProductoCantidadVendidos_Enabled = 1;
         edtProductoPrecio_Enabled = 1;
         edtProductoStockInicial_Enabled = 1;
         cmbProductoTipo.Enabled = 0;
         edtProductoNombre_Enabled = 0;
         edtProductoId_Enabled = 1;
         edtSectorEntradasDisponibles_Enabled = 0;
         edtSectorEntradasVendidas_Enabled = 0;
         edtSectorPrecio_Enabled = 1;
         edtSectorCapacidad_Enabled = 1;
         edtSectorNombre_Enabled = 1;
         edtSectorId_Enabled = 0;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCantidadProductos_Jsonclick = "";
         edtCantidadProductos_Enabled = 0;
         edtEspectaculoInvitacionesEntrega_Jsonclick = "";
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         edtEspectaculoInvitacionesDisponi_Jsonclick = "";
         edtEspectaculoInvitacionesDisponi_Enabled = 0;
         edtEspectaculoCantidadInvitacione_Jsonclick = "";
         edtEspectaculoCantidadInvitacione_Enabled = 1;
         imgEspectaculoAfiche_Enabled = 1;
         edtPaisOrigenNombre_Jsonclick = "";
         edtPaisOrigenNombre_Enabled = 0;
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         edtPaisOrigenId_Jsonclick = "";
         edtPaisOrigenId_Enabled = 1;
         edtPaisNombre_Jsonclick = "";
         edtPaisNombre_Enabled = 0;
         edtLugarNombre_Jsonclick = "";
         edtLugarNombre_Enabled = 0;
         imgprompt_3_Visible = 1;
         imgprompt_3_Link = "";
         edtLugarId_Jsonclick = "";
         edtLugarId_Enabled = 1;
         edtTipoEspectaculoNombre_Jsonclick = "";
         edtTipoEspectaculoNombre_Enabled = 0;
         imgprompt_6_Visible = 1;
         imgprompt_6_Link = "";
         edtTipoEspectaculoId_Jsonclick = "";
         edtTipoEspectaculoId_Enabled = 1;
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 1;
         edtEspectaculoNombre_Jsonclick = "";
         edtEspectaculoNombre_Enabled = 1;
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridespectaculo_sector_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_1134( ) ;
         while ( nGXsfl_113_idx <= nRC_GXsfl_113 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal034( ) ;
            standaloneModal034( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow034( ) ;
            nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1134( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridespectaculo_sectorContainer)) ;
         /* End function gxnrGridespectaculo_sector_newrow */
      }

      protected void gxnrGridespectaculo_producto_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_1285( ) ;
         while ( nGXsfl_128_idx <= nRC_GXsfl_128 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal035( ) ;
            standaloneModal035( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow035( ) ;
            nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
            sGXsfl_128_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_128_idx), 4, 0), 4, "0");
            SubsflControlProps_1285( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridespectaculo_productoContainer)) ;
         /* End function gxnrGridespectaculo_producto_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PRODUCTOTIPO_" + sGXsfl_128_idx;
         cmbProductoTipo.Name = GXCCtl;
         cmbProductoTipo.WebTags = "";
         cmbProductoTipo.addItem("Bebida", "Bebida", 0);
         cmbProductoTipo.addItem("Snack", "Snack", 0);
         cmbProductoTipo.addItem("Souvenir", "Souvenir", 0);
         if ( cmbProductoTipo.ItemCount > 0 )
         {
            A37ProductoTipo = cmbProductoTipo.getValidValue(A37ProductoTipo);
         }
         /* End function init_web_controls */
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

      public void Valid_Espectaculonombre( )
      {
         /* Using cursor T000357 */
         pr_default.execute(51, new Object[] {A8EspectaculoNombre, A5EspectaculoId});
         if ( (pr_default.getStatus(51) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Espectaculo Nombre"}), 1, "ESPECTACULONOMBRE");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoNombre_Internalname;
         }
         pr_default.close(51);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipoespectaculoid( )
      {
         /* Using cursor T000328 */
         pr_default.execute(25, new Object[] {A6TipoEspectaculoId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
         }
         A16TipoEspectaculoNombre = T000328_A16TipoEspectaculoNombre[0];
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A16TipoEspectaculoNombre", StringUtil.RTrim( A16TipoEspectaculoNombre));
      }

      public void Valid_Lugarid( )
      {
         /* Using cursor T000329 */
         pr_default.execute(26, new Object[] {A3LugarId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
         }
         A1PaisId = T000329_A1PaisId[0];
         A4LugarNombre = T000329_A4LugarNombre[0];
         pr_default.close(26);
         /* Using cursor T000330 */
         pr_default.execute(27, new Object[] {A1PaisId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A2PaisNombre = T000330_A2PaisNombre[0];
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1PaisId), 4, 0, ".", "")));
         AssignAttri("", false, "A4LugarNombre", StringUtil.RTrim( A4LugarNombre));
         AssignAttri("", false, "A2PaisNombre", StringUtil.RTrim( A2PaisNombre));
      }

      public void Valid_Paisorigenid( )
      {
         /* Using cursor T000331 */
         pr_default.execute(28, new Object[] {A7PaisOrigenId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais Origen'.", "ForeignKeyNotFound", 1, "PAISORIGENID");
            AnyError = 1;
            GX_FocusControl = edtPaisOrigenId_Internalname;
         }
         A28PaisOrigenNombre = T000331_A28PaisOrigenNombre[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28PaisOrigenNombre", StringUtil.RTrim( A28PaisOrigenNombre));
      }

      public void Valid_Sectorid( )
      {
         n9SectorId = false;
         n25SectorEntradasVendidas = false;
         /* Using cursor T000345 */
         pr_default.execute(39, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(39) != 101) )
         {
            A25SectorEntradasVendidas = T000345_A25SectorEntradasVendidas[0];
            n25SectorEntradasVendidas = T000345_n25SectorEntradasVendidas[0];
         }
         else
         {
            A25SectorEntradasVendidas = 0;
            n25SectorEntradasVendidas = false;
         }
         pr_default.close(39);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A25SectorEntradasVendidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorEntradasVendidas), 5, 0, ".", "")));
      }

      public void Valid_Productoid( )
      {
         A37ProductoTipo = cmbProductoTipo.CurrentValue;
         cmbProductoTipo.CurrentValue = A37ProductoTipo;
         /* Using cursor T000355 */
         pr_default.execute(49, new Object[] {A10ProductoId});
         if ( (pr_default.getStatus(49) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PRODUCTOID");
            AnyError = 1;
            GX_FocusControl = edtProductoId_Internalname;
         }
         A38ProductoNombre = T000355_A38ProductoNombre[0];
         A37ProductoTipo = T000355_A37ProductoTipo[0];
         cmbProductoTipo.CurrentValue = A37ProductoTipo;
         pr_default.close(49);
         dynload_actions( ) ;
         if ( cmbProductoTipo.ItemCount > 0 )
         {
            A37ProductoTipo = cmbProductoTipo.getValidValue(A37ProductoTipo);
            cmbProductoTipo.CurrentValue = A37ProductoTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProductoTipo.CurrentValue = StringUtil.RTrim( A37ProductoTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A38ProductoNombre", StringUtil.RTrim( A38ProductoNombre));
         AssignAttri("", false, "A37ProductoTipo", StringUtil.RTrim( A37ProductoTipo));
         cmbProductoTipo.CurrentValue = StringUtil.RTrim( A37ProductoTipo);
         AssignProp("", false, cmbProductoTipo_Internalname, "Values", cmbProductoTipo.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV15EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV15EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9',hsh:true},{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A33EspectaculoInvitacionesEntrega',fld:'ESPECTACULOINVITACIONESENTREGA',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULONOMBRE","{handler:'Valid_Espectaculonombre',iparms:[{av:'A8EspectaculoNombre',fld:'ESPECTACULONOMBRE',pic:''},{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_ESPECTACULONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOFECHA","{handler:'Valid_Espectaculofecha',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFECHA",",oparms:[]}");
         setEventMetadata("VALID_TIPOESPECTACULOID","{handler:'Valid_Tipoespectaculoid',iparms:[{av:'A6TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A16TipoEspectaculoNombre',fld:'TIPOESPECTACULONOMBRE',pic:''}]");
         setEventMetadata("VALID_TIPOESPECTACULOID",",oparms:[{av:'A16TipoEspectaculoNombre',fld:'TIPOESPECTACULONOMBRE',pic:''}]}");
         setEventMetadata("VALID_LUGARID","{handler:'Valid_Lugarid',iparms:[{av:'A3LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A1PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A4LugarNombre',fld:'LUGARNOMBRE',pic:''},{av:'A2PaisNombre',fld:'PAISNOMBRE',pic:''}]");
         setEventMetadata("VALID_LUGARID",",oparms:[{av:'A1PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A4LugarNombre',fld:'LUGARNOMBRE',pic:''},{av:'A2PaisNombre',fld:'PAISNOMBRE',pic:''}]}");
         setEventMetadata("VALID_PAISORIGENID","{handler:'Valid_Paisorigenid',iparms:[{av:'A7PaisOrigenId',fld:'PAISORIGENID',pic:'ZZZ9'},{av:'A28PaisOrigenNombre',fld:'PAISORIGENNOMBRE',pic:''}]");
         setEventMetadata("VALID_PAISORIGENID",",oparms:[{av:'A28PaisOrigenNombre',fld:'PAISORIGENNOMBRE',pic:''}]}");
         setEventMetadata("VALID_ESPECTACULOCANTIDADINVITACIONE","{handler:'Valid_Espectaculocantidadinvitacione',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOCANTIDADINVITACIONE",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOINVITACIONESENTREGA","{handler:'Valid_Espectaculoinvitacionesentrega',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOINVITACIONESENTREGA",",oparms:[]}");
         setEventMetadata("VALID_CANTIDADPRODUCTOS","{handler:'Valid_Cantidadproductos',iparms:[]");
         setEventMetadata("VALID_CANTIDADPRODUCTOS",",oparms:[]}");
         setEventMetadata("VALID_SECTORID","{handler:'Valid_Sectorid',iparms:[{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZ9'},{av:'A25SectorEntradasVendidas',fld:'SECTORENTRADASVENDIDAS',pic:'ZZZZ9'}]");
         setEventMetadata("VALID_SECTORID",",oparms:[{av:'A25SectorEntradasVendidas',fld:'SECTORENTRADASVENDIDAS',pic:'ZZZZ9'}]}");
         setEventMetadata("VALID_SECTORCAPACIDAD","{handler:'Valid_Sectorcapacidad',iparms:[]");
         setEventMetadata("VALID_SECTORCAPACIDAD",",oparms:[]}");
         setEventMetadata("VALID_SECTORENTRADASVENDIDAS","{handler:'Valid_Sectorentradasvendidas',iparms:[]");
         setEventMetadata("VALID_SECTORENTRADASVENDIDAS",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Sectorentradasdisponibles',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTOID","{handler:'Valid_Productoid',iparms:[{av:'A10ProductoId',fld:'PRODUCTOID',pic:'ZZZ9'},{av:'A38ProductoNombre',fld:'PRODUCTONOMBRE',pic:''},{av:'cmbProductoTipo'},{av:'A37ProductoTipo',fld:'PRODUCTOTIPO',pic:''}]");
         setEventMetadata("VALID_PRODUCTOID",",oparms:[{av:'A38ProductoNombre',fld:'PRODUCTONOMBRE',pic:''},{av:'cmbProductoTipo'},{av:'A37ProductoTipo',fld:'PRODUCTOTIPO',pic:''}]}");
         setEventMetadata("VALID_PRODUCTOSTOCKINICIAL","{handler:'Valid_Productostockinicial',iparms:[]");
         setEventMetadata("VALID_PRODUCTOSTOCKINICIAL",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTOCANTIDADVENDIDOS","{handler:'Valid_Productocantidadvendidos',iparms:[]");
         setEventMetadata("VALID_PRODUCTOCANTIDADVENDIDOS",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Productostockactual',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
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
         pr_default.close(49);
         pr_default.close(4);
         pr_default.close(39);
         pr_default.close(7);
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(28);
         pr_default.close(27);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
         Z21SectorNombre = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A8EspectaculoNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         imgprompt_6_gximage = "";
         sImgUrl = "";
         A16TipoEspectaculoNombre = "";
         imgprompt_3_gximage = "";
         A4LugarNombre = "";
         A2PaisNombre = "";
         imgprompt_7_gximage = "";
         A28PaisOrigenNombre = "";
         A20EspectaculoAfiche = "";
         A40000EspectaculoAfiche_GXI = "";
         lblTitlesector_Jsonclick = "";
         lblTitleproducto_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridespectaculo_sectorContainer = new GXWebGrid( context);
         sMode4 = "";
         sStyleString = "";
         Gridespectaculo_productoContainer = new GXWebGrid( context);
         sMode5 = "";
         AV17Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A38ProductoNombre = "";
         A37ProductoTipo = "";
         A21SectorNombre = "";
         AV11TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z20EspectaculoAfiche = "";
         Z40000EspectaculoAfiche_GXI = "";
         Z16TipoEspectaculoNombre = "";
         Z4LugarNombre = "";
         Z2PaisNombre = "";
         Z28PaisOrigenNombre = "";
         T000313_A28PaisOrigenNombre = new string[] {""} ;
         T000312_A1PaisId = new short[1] ;
         T000312_A4LugarNombre = new string[] {""} ;
         T000314_A2PaisNombre = new string[] {""} ;
         T000311_A16TipoEspectaculoNombre = new string[] {""} ;
         T000315_A1PaisId = new short[1] ;
         T000315_A5EspectaculoId = new short[1] ;
         T000315_A8EspectaculoNombre = new string[] {""} ;
         T000315_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000315_A16TipoEspectaculoNombre = new string[] {""} ;
         T000315_A4LugarNombre = new string[] {""} ;
         T000315_A2PaisNombre = new string[] {""} ;
         T000315_A28PaisOrigenNombre = new string[] {""} ;
         T000315_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         T000315_A31EspectaculoCantidadInvitacione = new short[1] ;
         T000315_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T000315_A29CantidadSectores = new short[1] ;
         T000315_A36CantidadProductos = new short[1] ;
         T000315_A6TipoEspectaculoId = new short[1] ;
         T000315_A3LugarId = new short[1] ;
         T000315_A7PaisOrigenId = new short[1] ;
         T000315_A20EspectaculoAfiche = new string[] {""} ;
         T000316_A8EspectaculoNombre = new string[] {""} ;
         T000317_A16TipoEspectaculoNombre = new string[] {""} ;
         T000318_A1PaisId = new short[1] ;
         T000318_A4LugarNombre = new string[] {""} ;
         T000319_A2PaisNombre = new string[] {""} ;
         T000320_A28PaisOrigenNombre = new string[] {""} ;
         T000321_A5EspectaculoId = new short[1] ;
         T000310_A5EspectaculoId = new short[1] ;
         T000310_A8EspectaculoNombre = new string[] {""} ;
         T000310_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000310_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         T000310_A31EspectaculoCantidadInvitacione = new short[1] ;
         T000310_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T000310_A29CantidadSectores = new short[1] ;
         T000310_A36CantidadProductos = new short[1] ;
         T000310_A6TipoEspectaculoId = new short[1] ;
         T000310_A3LugarId = new short[1] ;
         T000310_A7PaisOrigenId = new short[1] ;
         T000310_A20EspectaculoAfiche = new string[] {""} ;
         T000322_A5EspectaculoId = new short[1] ;
         T000323_A5EspectaculoId = new short[1] ;
         T00039_A5EspectaculoId = new short[1] ;
         T00039_A8EspectaculoNombre = new string[] {""} ;
         T00039_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00039_A40000EspectaculoAfiche_GXI = new string[] {""} ;
         T00039_A31EspectaculoCantidadInvitacione = new short[1] ;
         T00039_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T00039_A29CantidadSectores = new short[1] ;
         T00039_A36CantidadProductos = new short[1] ;
         T00039_A6TipoEspectaculoId = new short[1] ;
         T00039_A3LugarId = new short[1] ;
         T00039_A7PaisOrigenId = new short[1] ;
         T00039_A20EspectaculoAfiche = new string[] {""} ;
         T000324_A5EspectaculoId = new short[1] ;
         T000328_A16TipoEspectaculoNombre = new string[] {""} ;
         T000329_A1PaisId = new short[1] ;
         T000329_A4LugarNombre = new string[] {""} ;
         T000330_A2PaisNombre = new string[] {""} ;
         T000331_A28PaisOrigenNombre = new string[] {""} ;
         T000332_A17InvitacionId = new short[1] ;
         T000333_A11EntradaId = new short[1] ;
         T000335_A5EspectaculoId = new short[1] ;
         T00038_A25SectorEntradasVendidas = new int[1] ;
         T00038_n25SectorEntradasVendidas = new bool[] {false} ;
         T000337_A5EspectaculoId = new short[1] ;
         T000337_A9SectorId = new short[1] ;
         T000337_n9SectorId = new bool[] {false} ;
         T000337_A21SectorNombre = new string[] {""} ;
         T000337_A22SectorCapacidad = new int[1] ;
         T000337_A23SectorPrecio = new int[1] ;
         T000337_A25SectorEntradasVendidas = new int[1] ;
         T000337_n25SectorEntradasVendidas = new bool[] {false} ;
         T000339_A25SectorEntradasVendidas = new int[1] ;
         T000339_n25SectorEntradasVendidas = new bool[] {false} ;
         T000340_A5EspectaculoId = new short[1] ;
         T000340_A9SectorId = new short[1] ;
         T000340_n9SectorId = new bool[] {false} ;
         T00036_A5EspectaculoId = new short[1] ;
         T00036_A9SectorId = new short[1] ;
         T00036_n9SectorId = new bool[] {false} ;
         T00036_A21SectorNombre = new string[] {""} ;
         T00036_A22SectorCapacidad = new int[1] ;
         T00036_A23SectorPrecio = new int[1] ;
         T00035_A5EspectaculoId = new short[1] ;
         T00035_A9SectorId = new short[1] ;
         T00035_n9SectorId = new bool[] {false} ;
         T00035_A21SectorNombre = new string[] {""} ;
         T00035_A22SectorCapacidad = new int[1] ;
         T00035_A23SectorPrecio = new int[1] ;
         T000345_A25SectorEntradasVendidas = new int[1] ;
         T000345_n25SectorEntradasVendidas = new bool[] {false} ;
         T000346_A13PaseId = new short[1] ;
         T000346_A14PaseTipo = new string[] {""} ;
         T000347_A11EntradaId = new short[1] ;
         T000348_A5EspectaculoId = new short[1] ;
         T000348_A9SectorId = new short[1] ;
         T000348_n9SectorId = new bool[] {false} ;
         Z38ProductoNombre = "";
         Z37ProductoTipo = "";
         T00034_A38ProductoNombre = new string[] {""} ;
         T00034_A37ProductoTipo = new string[] {""} ;
         T000349_A5EspectaculoId = new short[1] ;
         T000349_A38ProductoNombre = new string[] {""} ;
         T000349_A37ProductoTipo = new string[] {""} ;
         T000349_A39ProductoStockInicial = new int[1] ;
         T000349_A40ProductoPrecio = new int[1] ;
         T000349_A41ProductoCantidadVendidos = new int[1] ;
         T000349_A10ProductoId = new short[1] ;
         T000350_A38ProductoNombre = new string[] {""} ;
         T000350_A37ProductoTipo = new string[] {""} ;
         T000351_A5EspectaculoId = new short[1] ;
         T000351_A10ProductoId = new short[1] ;
         T00033_A5EspectaculoId = new short[1] ;
         T00033_A39ProductoStockInicial = new int[1] ;
         T00033_A40ProductoPrecio = new int[1] ;
         T00033_A41ProductoCantidadVendidos = new int[1] ;
         T00033_A10ProductoId = new short[1] ;
         T00032_A5EspectaculoId = new short[1] ;
         T00032_A39ProductoStockInicial = new int[1] ;
         T00032_A40ProductoPrecio = new int[1] ;
         T00032_A41ProductoCantidadVendidos = new int[1] ;
         T00032_A10ProductoId = new short[1] ;
         T000355_A38ProductoNombre = new string[] {""} ;
         T000355_A37ProductoTipo = new string[] {""} ;
         T000356_A5EspectaculoId = new short[1] ;
         T000356_A10ProductoId = new short[1] ;
         Gridespectaculo_sectorRow = new GXWebRow();
         subGridespectaculo_sector_Linesclass = "";
         ROClassString = "";
         Gridespectaculo_productoRow = new GXWebRow();
         subGridespectaculo_producto_Linesclass = "";
         imgprompt_10_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i19EspectaculoFecha = DateTime.MinValue;
         Gridespectaculo_sectorColumn = new GXWebColumn();
         Gridespectaculo_productoColumn = new GXWebColumn();
         T000357_A8EspectaculoNombre = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.espectaculo__default(),
            new Object[][] {
                new Object[] {
               T00032_A5EspectaculoId, T00032_A39ProductoStockInicial, T00032_A40ProductoPrecio, T00032_A41ProductoCantidadVendidos, T00032_A10ProductoId
               }
               , new Object[] {
               T00033_A5EspectaculoId, T00033_A39ProductoStockInicial, T00033_A40ProductoPrecio, T00033_A41ProductoCantidadVendidos, T00033_A10ProductoId
               }
               , new Object[] {
               T00034_A38ProductoNombre, T00034_A37ProductoTipo
               }
               , new Object[] {
               T00035_A5EspectaculoId, T00035_A9SectorId, T00035_A21SectorNombre, T00035_A22SectorCapacidad, T00035_A23SectorPrecio
               }
               , new Object[] {
               T00036_A5EspectaculoId, T00036_A9SectorId, T00036_A21SectorNombre, T00036_A22SectorCapacidad, T00036_A23SectorPrecio
               }
               , new Object[] {
               T00038_A25SectorEntradasVendidas, T00038_n25SectorEntradasVendidas
               }
               , new Object[] {
               T00039_A5EspectaculoId, T00039_A8EspectaculoNombre, T00039_A19EspectaculoFecha, T00039_A40000EspectaculoAfiche_GXI, T00039_A31EspectaculoCantidadInvitacione, T00039_A33EspectaculoInvitacionesEntrega, T00039_A29CantidadSectores, T00039_A36CantidadProductos, T00039_A6TipoEspectaculoId, T00039_A3LugarId,
               T00039_A7PaisOrigenId, T00039_A20EspectaculoAfiche
               }
               , new Object[] {
               T000310_A5EspectaculoId, T000310_A8EspectaculoNombre, T000310_A19EspectaculoFecha, T000310_A40000EspectaculoAfiche_GXI, T000310_A31EspectaculoCantidadInvitacione, T000310_A33EspectaculoInvitacionesEntrega, T000310_A29CantidadSectores, T000310_A36CantidadProductos, T000310_A6TipoEspectaculoId, T000310_A3LugarId,
               T000310_A7PaisOrigenId, T000310_A20EspectaculoAfiche
               }
               , new Object[] {
               T000311_A16TipoEspectaculoNombre
               }
               , new Object[] {
               T000312_A1PaisId, T000312_A4LugarNombre
               }
               , new Object[] {
               T000313_A28PaisOrigenNombre
               }
               , new Object[] {
               T000314_A2PaisNombre
               }
               , new Object[] {
               T000315_A1PaisId, T000315_A5EspectaculoId, T000315_A8EspectaculoNombre, T000315_A19EspectaculoFecha, T000315_A16TipoEspectaculoNombre, T000315_A4LugarNombre, T000315_A2PaisNombre, T000315_A28PaisOrigenNombre, T000315_A40000EspectaculoAfiche_GXI, T000315_A31EspectaculoCantidadInvitacione,
               T000315_A33EspectaculoInvitacionesEntrega, T000315_A29CantidadSectores, T000315_A36CantidadProductos, T000315_A6TipoEspectaculoId, T000315_A3LugarId, T000315_A7PaisOrigenId, T000315_A20EspectaculoAfiche
               }
               , new Object[] {
               T000316_A8EspectaculoNombre
               }
               , new Object[] {
               T000317_A16TipoEspectaculoNombre
               }
               , new Object[] {
               T000318_A1PaisId, T000318_A4LugarNombre
               }
               , new Object[] {
               T000319_A2PaisNombre
               }
               , new Object[] {
               T000320_A28PaisOrigenNombre
               }
               , new Object[] {
               T000321_A5EspectaculoId
               }
               , new Object[] {
               T000322_A5EspectaculoId
               }
               , new Object[] {
               T000323_A5EspectaculoId
               }
               , new Object[] {
               T000324_A5EspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000328_A16TipoEspectaculoNombre
               }
               , new Object[] {
               T000329_A1PaisId, T000329_A4LugarNombre
               }
               , new Object[] {
               T000330_A2PaisNombre
               }
               , new Object[] {
               T000331_A28PaisOrigenNombre
               }
               , new Object[] {
               T000332_A17InvitacionId
               }
               , new Object[] {
               T000333_A11EntradaId
               }
               , new Object[] {
               }
               , new Object[] {
               T000335_A5EspectaculoId
               }
               , new Object[] {
               T000337_A5EspectaculoId, T000337_A9SectorId, T000337_A21SectorNombre, T000337_A22SectorCapacidad, T000337_A23SectorPrecio, T000337_A25SectorEntradasVendidas, T000337_n25SectorEntradasVendidas
               }
               , new Object[] {
               T000339_A25SectorEntradasVendidas, T000339_n25SectorEntradasVendidas
               }
               , new Object[] {
               T000340_A5EspectaculoId, T000340_A9SectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000345_A25SectorEntradasVendidas, T000345_n25SectorEntradasVendidas
               }
               , new Object[] {
               T000346_A13PaseId, T000346_A14PaseTipo
               }
               , new Object[] {
               T000347_A11EntradaId
               }
               , new Object[] {
               T000348_A5EspectaculoId, T000348_A9SectorId
               }
               , new Object[] {
               T000349_A5EspectaculoId, T000349_A38ProductoNombre, T000349_A37ProductoTipo, T000349_A39ProductoStockInicial, T000349_A40ProductoPrecio, T000349_A41ProductoCantidadVendidos, T000349_A10ProductoId
               }
               , new Object[] {
               T000350_A38ProductoNombre, T000350_A37ProductoTipo
               }
               , new Object[] {
               T000351_A5EspectaculoId, T000351_A10ProductoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000355_A38ProductoNombre, T000355_A37ProductoTipo
               }
               , new Object[] {
               T000356_A5EspectaculoId, T000356_A10ProductoId
               }
               , new Object[] {
               T000357_A8EspectaculoNombre
               }
            }
         );
         Z33EspectaculoInvitacionesEntrega = 0;
         A33EspectaculoInvitacionesEntrega = 0;
         i33EspectaculoInvitacionesEntrega = 0;
         AV17Pgmname = "Espectaculo";
         Z29CantidadSectores = 0;
         O29CantidadSectores = 0;
         A29CantidadSectores = 0;
         i29CantidadSectores = 0;
         Z19EspectaculoFecha = DateTimeUtil.Today( context);
         A19EspectaculoFecha = DateTimeUtil.Today( context);
         i19EspectaculoFecha = DateTimeUtil.Today( context);
      }

      private short nIsMod_5 ;
      private short wcpOAV15EspectaculoId ;
      private short Z5EspectaculoId ;
      private short Z31EspectaculoCantidadInvitacione ;
      private short Z33EspectaculoInvitacionesEntrega ;
      private short Z29CantidadSectores ;
      private short Z36CantidadProductos ;
      private short Z6TipoEspectaculoId ;
      private short Z3LugarId ;
      private short Z7PaisOrigenId ;
      private short O36CantidadProductos ;
      private short O29CantidadSectores ;
      private short N6TipoEspectaculoId ;
      private short N3LugarId ;
      private short N7PaisOrigenId ;
      private short Z9SectorId ;
      private short nRcdDeleted_4 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short Z10ProductoId ;
      private short nRcdDeleted_5 ;
      private short nRcdExists_5 ;
      private short GxWebError ;
      private short A6TipoEspectaculoId ;
      private short A3LugarId ;
      private short A1PaisId ;
      private short A7PaisOrigenId ;
      private short A5EspectaculoId ;
      private short A9SectorId ;
      private short A10ProductoId ;
      private short AV15EspectaculoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A29CantidadSectores ;
      private short A36CantidadProductos ;
      private short initialized ;
      private short A31EspectaculoCantidadInvitacione ;
      private short A32EspectaculoInvitacionesDisponi ;
      private short A33EspectaculoInvitacionesEntrega ;
      private short nBlankRcdCount4 ;
      private short RcdFound4 ;
      private short B36CantidadProductos ;
      private short B29CantidadSectores ;
      private short nBlankRcdUsr4 ;
      private short nBlankRcdCount5 ;
      private short RcdFound5 ;
      private short nBlankRcdUsr5 ;
      private short AV9Insert_TipoEspectaculoId ;
      private short AV7Insert_LugarId ;
      private short AV8Insert_PaisOrigenId ;
      private short RcdFound3 ;
      private short s36CantidadProductos ;
      private short s29CantidadSectores ;
      private short GX_JID ;
      private short Z1PaisId ;
      private short nIsDirty_3 ;
      private short nIsDirty_4 ;
      private short nIsDirty_5 ;
      private short subGridespectaculo_sector_Backcolorstyle ;
      private short subGridespectaculo_sector_Backstyle ;
      private short subGridespectaculo_producto_Backcolorstyle ;
      private short subGridespectaculo_producto_Backstyle ;
      private short gxajaxcallmode ;
      private short i33EspectaculoInvitacionesEntrega ;
      private short i29CantidadSectores ;
      private short i36CantidadProductos ;
      private short subGridespectaculo_sector_Allowselection ;
      private short subGridespectaculo_sector_Allowhovering ;
      private short subGridespectaculo_sector_Allowcollapsing ;
      private short subGridespectaculo_sector_Collapsed ;
      private short subGridespectaculo_producto_Allowselection ;
      private short subGridespectaculo_producto_Allowhovering ;
      private short subGridespectaculo_producto_Allowcollapsing ;
      private short subGridespectaculo_producto_Collapsed ;
      private int nRC_GXsfl_113 ;
      private int nGXsfl_113_idx=1 ;
      private int nRC_GXsfl_128 ;
      private int nGXsfl_128_idx=1 ;
      private int Z22SectorCapacidad ;
      private int Z23SectorPrecio ;
      private int Z39ProductoStockInicial ;
      private int Z40ProductoPrecio ;
      private int Z41ProductoCantidadVendidos ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEspectaculoId_Enabled ;
      private int edtEspectaculoNombre_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtTipoEspectaculoId_Enabled ;
      private int imgprompt_6_Visible ;
      private int edtTipoEspectaculoNombre_Enabled ;
      private int edtLugarId_Enabled ;
      private int imgprompt_3_Visible ;
      private int edtLugarNombre_Enabled ;
      private int edtPaisNombre_Enabled ;
      private int edtPaisOrigenId_Enabled ;
      private int imgprompt_7_Visible ;
      private int edtPaisOrigenNombre_Enabled ;
      private int imgEspectaculoAfiche_Enabled ;
      private int edtEspectaculoCantidadInvitacione_Enabled ;
      private int edtEspectaculoInvitacionesDisponi_Enabled ;
      private int edtEspectaculoInvitacionesEntrega_Enabled ;
      private int edtCantidadProductos_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtSectorId_Enabled ;
      private int edtSectorNombre_Enabled ;
      private int edtSectorCapacidad_Enabled ;
      private int edtSectorPrecio_Enabled ;
      private int edtSectorEntradasVendidas_Enabled ;
      private int edtSectorEntradasDisponibles_Enabled ;
      private int fRowAdded ;
      private int edtProductoId_Enabled ;
      private int edtProductoNombre_Enabled ;
      private int edtProductoStockInicial_Enabled ;
      private int edtProductoPrecio_Enabled ;
      private int edtProductoCantidadVendidos_Enabled ;
      private int edtProductoStockActual_Enabled ;
      private int A39ProductoStockInicial ;
      private int A40ProductoPrecio ;
      private int A41ProductoCantidadVendidos ;
      private int A42ProductoStockActual ;
      private int A22SectorCapacidad ;
      private int A23SectorPrecio ;
      private int A25SectorEntradasVendidas ;
      private int A24SectorEntradasDisponibles ;
      private int AV18GXV1 ;
      private int Z25SectorEntradasVendidas ;
      private int subGridespectaculo_sector_Backcolor ;
      private int subGridespectaculo_sector_Allbackcolor ;
      private int subGridespectaculo_producto_Backcolor ;
      private int subGridespectaculo_producto_Allbackcolor ;
      private int imgprompt_10_Visible ;
      private int defedtProductoId_Enabled ;
      private int defedtSectorEntradasDisponibles_Enabled ;
      private int defedtSectorId_Enabled ;
      private int idxLst ;
      private int subGridespectaculo_sector_Selectedindex ;
      private int subGridespectaculo_sector_Selectioncolor ;
      private int subGridespectaculo_sector_Hoveringcolor ;
      private int subGridespectaculo_producto_Selectedindex ;
      private int subGridespectaculo_producto_Selectioncolor ;
      private int subGridespectaculo_producto_Hoveringcolor ;
      private long GRIDESPECTACULO_SECTOR_nFirstRecordOnPage ;
      private long GRIDESPECTACULO_PRODUCTO_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_128_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z8EspectaculoNombre ;
      private string Z21SectorNombre ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEspectaculoNombre_Internalname ;
      private string sGXsfl_113_idx="0001" ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string A8EspectaculoNombre ;
      private string edtEspectaculoNombre_Jsonclick ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtTipoEspectaculoId_Internalname ;
      private string edtTipoEspectaculoId_Jsonclick ;
      private string imgprompt_6_gximage ;
      private string sImgUrl ;
      private string imgprompt_6_Internalname ;
      private string imgprompt_6_Link ;
      private string edtTipoEspectaculoNombre_Internalname ;
      private string A16TipoEspectaculoNombre ;
      private string edtTipoEspectaculoNombre_Jsonclick ;
      private string edtLugarId_Internalname ;
      private string edtLugarId_Jsonclick ;
      private string imgprompt_3_gximage ;
      private string imgprompt_3_Internalname ;
      private string imgprompt_3_Link ;
      private string edtLugarNombre_Internalname ;
      private string A4LugarNombre ;
      private string edtLugarNombre_Jsonclick ;
      private string edtPaisNombre_Internalname ;
      private string A2PaisNombre ;
      private string edtPaisNombre_Jsonclick ;
      private string edtPaisOrigenId_Internalname ;
      private string edtPaisOrigenId_Jsonclick ;
      private string imgprompt_7_gximage ;
      private string imgprompt_7_Internalname ;
      private string imgprompt_7_Link ;
      private string edtPaisOrigenNombre_Internalname ;
      private string A28PaisOrigenNombre ;
      private string edtPaisOrigenNombre_Jsonclick ;
      private string imgEspectaculoAfiche_Internalname ;
      private string edtEspectaculoCantidadInvitacione_Internalname ;
      private string edtEspectaculoCantidadInvitacione_Jsonclick ;
      private string edtEspectaculoInvitacionesDisponi_Internalname ;
      private string edtEspectaculoInvitacionesDisponi_Jsonclick ;
      private string edtEspectaculoInvitacionesEntrega_Internalname ;
      private string edtEspectaculoInvitacionesEntrega_Jsonclick ;
      private string edtCantidadProductos_Internalname ;
      private string edtCantidadProductos_Jsonclick ;
      private string divSectortable_Internalname ;
      private string lblTitlesector_Internalname ;
      private string lblTitlesector_Jsonclick ;
      private string divProductotable_Internalname ;
      private string lblTitleproducto_Internalname ;
      private string lblTitleproducto_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode4 ;
      private string edtSectorId_Internalname ;
      private string edtSectorNombre_Internalname ;
      private string edtSectorCapacidad_Internalname ;
      private string edtSectorPrecio_Internalname ;
      private string edtSectorEntradasVendidas_Internalname ;
      private string edtSectorEntradasDisponibles_Internalname ;
      private string sStyleString ;
      private string subGridespectaculo_sector_Internalname ;
      private string sMode5 ;
      private string edtProductoId_Internalname ;
      private string edtProductoNombre_Internalname ;
      private string cmbProductoTipo_Internalname ;
      private string edtProductoStockInicial_Internalname ;
      private string edtProductoPrecio_Internalname ;
      private string edtProductoCantidadVendidos_Internalname ;
      private string edtProductoStockActual_Internalname ;
      private string subGridespectaculo_producto_Internalname ;
      private string AV17Pgmname ;
      private string hsh ;
      private string sMode3 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A38ProductoNombre ;
      private string A37ProductoTipo ;
      private string A21SectorNombre ;
      private string Z16TipoEspectaculoNombre ;
      private string Z4LugarNombre ;
      private string Z2PaisNombre ;
      private string Z28PaisOrigenNombre ;
      private string Z38ProductoNombre ;
      private string Z37ProductoTipo ;
      private string sGXsfl_113_fel_idx="0001" ;
      private string subGridespectaculo_sector_Class ;
      private string subGridespectaculo_sector_Linesclass ;
      private string ROClassString ;
      private string edtSectorId_Jsonclick ;
      private string edtSectorNombre_Jsonclick ;
      private string edtSectorCapacidad_Jsonclick ;
      private string edtSectorPrecio_Jsonclick ;
      private string edtSectorEntradasVendidas_Jsonclick ;
      private string edtSectorEntradasDisponibles_Jsonclick ;
      private string imgprompt_10_Internalname ;
      private string sGXsfl_128_fel_idx="0001" ;
      private string subGridespectaculo_producto_Class ;
      private string subGridespectaculo_producto_Linesclass ;
      private string imgprompt_10_Link ;
      private string edtProductoId_Jsonclick ;
      private string imgprompt_10_gximage ;
      private string edtProductoNombre_Jsonclick ;
      private string cmbProductoTipo_Jsonclick ;
      private string edtProductoStockInicial_Jsonclick ;
      private string edtProductoPrecio_Jsonclick ;
      private string edtProductoCantidadVendidos_Jsonclick ;
      private string edtProductoStockActual_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridespectaculo_sector_Header ;
      private string subGridespectaculo_producto_Header ;
      private DateTime Z19EspectaculoFecha ;
      private DateTime A19EspectaculoFecha ;
      private DateTime i19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n9SectorId ;
      private bool wbErr ;
      private bool A20EspectaculoAfiche_IsBlob ;
      private bool bGXsfl_113_Refreshing=false ;
      private bool bGXsfl_128_Refreshing=false ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool n25SectorEntradasVendidas ;
      private string A40000EspectaculoAfiche_GXI ;
      private string Z40000EspectaculoAfiche_GXI ;
      private string A20EspectaculoAfiche ;
      private string Z20EspectaculoAfiche ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridespectaculo_sectorContainer ;
      private GXWebGrid Gridespectaculo_productoContainer ;
      private GXWebRow Gridespectaculo_sectorRow ;
      private GXWebRow Gridespectaculo_productoRow ;
      private GXWebColumn Gridespectaculo_sectorColumn ;
      private GXWebColumn Gridespectaculo_productoColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProductoTipo ;
      private IDataStoreProvider pr_default ;
      private string[] T000313_A28PaisOrigenNombre ;
      private short[] T000312_A1PaisId ;
      private string[] T000312_A4LugarNombre ;
      private string[] T000314_A2PaisNombre ;
      private string[] T000311_A16TipoEspectaculoNombre ;
      private short[] T000315_A1PaisId ;
      private short[] T000315_A5EspectaculoId ;
      private string[] T000315_A8EspectaculoNombre ;
      private DateTime[] T000315_A19EspectaculoFecha ;
      private string[] T000315_A16TipoEspectaculoNombre ;
      private string[] T000315_A4LugarNombre ;
      private string[] T000315_A2PaisNombre ;
      private string[] T000315_A28PaisOrigenNombre ;
      private string[] T000315_A40000EspectaculoAfiche_GXI ;
      private short[] T000315_A31EspectaculoCantidadInvitacione ;
      private short[] T000315_A33EspectaculoInvitacionesEntrega ;
      private short[] T000315_A29CantidadSectores ;
      private short[] T000315_A36CantidadProductos ;
      private short[] T000315_A6TipoEspectaculoId ;
      private short[] T000315_A3LugarId ;
      private short[] T000315_A7PaisOrigenId ;
      private string[] T000315_A20EspectaculoAfiche ;
      private string[] T000316_A8EspectaculoNombre ;
      private string[] T000317_A16TipoEspectaculoNombre ;
      private short[] T000318_A1PaisId ;
      private string[] T000318_A4LugarNombre ;
      private string[] T000319_A2PaisNombre ;
      private string[] T000320_A28PaisOrigenNombre ;
      private short[] T000321_A5EspectaculoId ;
      private short[] T000310_A5EspectaculoId ;
      private string[] T000310_A8EspectaculoNombre ;
      private DateTime[] T000310_A19EspectaculoFecha ;
      private string[] T000310_A40000EspectaculoAfiche_GXI ;
      private short[] T000310_A31EspectaculoCantidadInvitacione ;
      private short[] T000310_A33EspectaculoInvitacionesEntrega ;
      private short[] T000310_A29CantidadSectores ;
      private short[] T000310_A36CantidadProductos ;
      private short[] T000310_A6TipoEspectaculoId ;
      private short[] T000310_A3LugarId ;
      private short[] T000310_A7PaisOrigenId ;
      private string[] T000310_A20EspectaculoAfiche ;
      private short[] T000322_A5EspectaculoId ;
      private short[] T000323_A5EspectaculoId ;
      private short[] T00039_A5EspectaculoId ;
      private string[] T00039_A8EspectaculoNombre ;
      private DateTime[] T00039_A19EspectaculoFecha ;
      private string[] T00039_A40000EspectaculoAfiche_GXI ;
      private short[] T00039_A31EspectaculoCantidadInvitacione ;
      private short[] T00039_A33EspectaculoInvitacionesEntrega ;
      private short[] T00039_A29CantidadSectores ;
      private short[] T00039_A36CantidadProductos ;
      private short[] T00039_A6TipoEspectaculoId ;
      private short[] T00039_A3LugarId ;
      private short[] T00039_A7PaisOrigenId ;
      private string[] T00039_A20EspectaculoAfiche ;
      private short[] T000324_A5EspectaculoId ;
      private string[] T000328_A16TipoEspectaculoNombre ;
      private short[] T000329_A1PaisId ;
      private string[] T000329_A4LugarNombre ;
      private string[] T000330_A2PaisNombre ;
      private string[] T000331_A28PaisOrigenNombre ;
      private short[] T000332_A17InvitacionId ;
      private short[] T000333_A11EntradaId ;
      private short[] T000335_A5EspectaculoId ;
      private int[] T00038_A25SectorEntradasVendidas ;
      private bool[] T00038_n25SectorEntradasVendidas ;
      private short[] T000337_A5EspectaculoId ;
      private short[] T000337_A9SectorId ;
      private bool[] T000337_n9SectorId ;
      private string[] T000337_A21SectorNombre ;
      private int[] T000337_A22SectorCapacidad ;
      private int[] T000337_A23SectorPrecio ;
      private int[] T000337_A25SectorEntradasVendidas ;
      private bool[] T000337_n25SectorEntradasVendidas ;
      private int[] T000339_A25SectorEntradasVendidas ;
      private bool[] T000339_n25SectorEntradasVendidas ;
      private short[] T000340_A5EspectaculoId ;
      private short[] T000340_A9SectorId ;
      private bool[] T000340_n9SectorId ;
      private short[] T00036_A5EspectaculoId ;
      private short[] T00036_A9SectorId ;
      private bool[] T00036_n9SectorId ;
      private string[] T00036_A21SectorNombre ;
      private int[] T00036_A22SectorCapacidad ;
      private int[] T00036_A23SectorPrecio ;
      private short[] T00035_A5EspectaculoId ;
      private short[] T00035_A9SectorId ;
      private bool[] T00035_n9SectorId ;
      private string[] T00035_A21SectorNombre ;
      private int[] T00035_A22SectorCapacidad ;
      private int[] T00035_A23SectorPrecio ;
      private int[] T000345_A25SectorEntradasVendidas ;
      private bool[] T000345_n25SectorEntradasVendidas ;
      private short[] T000346_A13PaseId ;
      private string[] T000346_A14PaseTipo ;
      private short[] T000347_A11EntradaId ;
      private short[] T000348_A5EspectaculoId ;
      private short[] T000348_A9SectorId ;
      private bool[] T000348_n9SectorId ;
      private string[] T00034_A38ProductoNombre ;
      private string[] T00034_A37ProductoTipo ;
      private short[] T000349_A5EspectaculoId ;
      private string[] T000349_A38ProductoNombre ;
      private string[] T000349_A37ProductoTipo ;
      private int[] T000349_A39ProductoStockInicial ;
      private int[] T000349_A40ProductoPrecio ;
      private int[] T000349_A41ProductoCantidadVendidos ;
      private short[] T000349_A10ProductoId ;
      private string[] T000350_A38ProductoNombre ;
      private string[] T000350_A37ProductoTipo ;
      private short[] T000351_A5EspectaculoId ;
      private short[] T000351_A10ProductoId ;
      private short[] T00033_A5EspectaculoId ;
      private int[] T00033_A39ProductoStockInicial ;
      private int[] T00033_A40ProductoPrecio ;
      private int[] T00033_A41ProductoCantidadVendidos ;
      private short[] T00033_A10ProductoId ;
      private short[] T00032_A5EspectaculoId ;
      private int[] T00032_A39ProductoStockInicial ;
      private int[] T00032_A40ProductoPrecio ;
      private int[] T00032_A41ProductoCantidadVendidos ;
      private short[] T00032_A10ProductoId ;
      private string[] T000355_A38ProductoNombre ;
      private string[] T000355_A37ProductoTipo ;
      private short[] T000356_A5EspectaculoId ;
      private short[] T000356_A10ProductoId ;
      private string[] T000357_A8EspectaculoNombre ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV11TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class espectaculo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new UpdateCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new UpdateCursor(def[36])
         ,new UpdateCursor(def[37])
         ,new UpdateCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
         ,new ForEachCursor(def[41])
         ,new ForEachCursor(def[42])
         ,new ForEachCursor(def[43])
         ,new ForEachCursor(def[44])
         ,new ForEachCursor(def[45])
         ,new UpdateCursor(def[46])
         ,new UpdateCursor(def[47])
         ,new UpdateCursor(def[48])
         ,new ForEachCursor(def[49])
         ,new ForEachCursor(def[50])
         ,new ForEachCursor(def[51])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000315;
          prmT000315 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          new ParDef("@EspectaculoNombre",GXType.NChar,60,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@PaisOrigenId",GXType.Int16,4,0)
          };
          Object[] prmT000317;
          prmT000317 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000318;
          prmT000318 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000319;
          prmT000319 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000320;
          prmT000320 = new Object[] {
          new ParDef("@PaisOrigenId",GXType.Int16,4,0)
          };
          Object[] prmT000321;
          prmT000321 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000322;
          prmT000322 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000323;
          prmT000323 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000324;
          prmT000324 = new Object[] {
          new ParDef("@EspectaculoNombre",GXType.NChar,60,0) ,
          new ParDef("@EspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@EspectaculoAfiche",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoAfiche_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Espectaculo", Fld="EspectaculoAfiche"} ,
          new ParDef("@EspectaculoCantidadInvitacione",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoInvitacionesEntrega",GXType.Int16,4,0) ,
          new ParDef("@CantidadSectores",GXType.Int16,4,0) ,
          new ParDef("@CantidadProductos",GXType.Int16,4,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@PaisOrigenId",GXType.Int16,4,0)
          };
          Object[] prmT000325;
          prmT000325 = new Object[] {
          new ParDef("@EspectaculoNombre",GXType.NChar,60,0) ,
          new ParDef("@EspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@EspectaculoCantidadInvitacione",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoInvitacionesEntrega",GXType.Int16,4,0) ,
          new ParDef("@CantidadSectores",GXType.Int16,4,0) ,
          new ParDef("@CantidadProductos",GXType.Int16,4,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@PaisOrigenId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000326;
          prmT000326 = new Object[] {
          new ParDef("@EspectaculoAfiche",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoAfiche_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Espectaculo", Fld="EspectaculoAfiche"} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000327;
          prmT000327 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000332;
          prmT000332 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000333;
          prmT000333 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000334;
          prmT000334 = new Object[] {
          new ParDef("@CantidadProductos",GXType.Int16,4,0) ,
          new ParDef("@CantidadSectores",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000335;
          prmT000335 = new Object[] {
          };
          Object[] prmT000337;
          prmT000337 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000339;
          prmT000339 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000340;
          prmT000340 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000341;
          prmT000341 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@SectorNombre",GXType.NChar,60,0) ,
          new ParDef("@SectorCapacidad",GXType.Int32,5,0) ,
          new ParDef("@SectorPrecio",GXType.Int32,6,0)
          };
          Object[] prmT000342;
          prmT000342 = new Object[] {
          new ParDef("@SectorNombre",GXType.NChar,60,0) ,
          new ParDef("@SectorCapacidad",GXType.Int32,5,0) ,
          new ParDef("@SectorPrecio",GXType.Int32,6,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000343;
          prmT000343 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000346;
          prmT000346 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000347;
          prmT000347 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000348;
          prmT000348 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000349;
          prmT000349 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT000350;
          prmT000350 = new Object[] {
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT000351;
          prmT000351 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT000352;
          prmT000352 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@ProductoStockInicial",GXType.Int32,5,0) ,
          new ParDef("@ProductoPrecio",GXType.Int32,5,0) ,
          new ParDef("@ProductoCantidadVendidos",GXType.Int32,5,0) ,
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT000353;
          prmT000353 = new Object[] {
          new ParDef("@ProductoStockInicial",GXType.Int32,5,0) ,
          new ParDef("@ProductoPrecio",GXType.Int32,5,0) ,
          new ParDef("@ProductoCantidadVendidos",GXType.Int32,5,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT000354;
          prmT000354 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          Object[] prmT000356;
          prmT000356 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000357;
          prmT000357 = new Object[] {
          new ParDef("@EspectaculoNombre",GXType.NChar,60,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000328;
          prmT000328 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000329;
          prmT000329 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000330;
          prmT000330 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000331;
          prmT000331 = new Object[] {
          new ParDef("@PaisOrigenId",GXType.Int16,4,0)
          };
          Object[] prmT000345;
          prmT000345 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000355;
          prmT000355 = new Object[] {
          new ParDef("@ProductoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [EspectaculoId], [ProductoStockInicial], [ProductoPrecio], [ProductoCantidadVendidos], [ProductoId] FROM [EspectaculoProducto] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId AND [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [EspectaculoId], [ProductoStockInicial], [ProductoPrecio], [ProductoCantidadVendidos], [ProductoId] FROM [EspectaculoProducto] WHERE [EspectaculoId] = @EspectaculoId AND [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [ProductoNombre], [ProductoTipo] FROM [Producto] WHERE [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT [EspectaculoId], [SectorId], [SectorNombre], [SectorCapacidad], [SectorPrecio] FROM [EspectaculoSector] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT [EspectaculoId], [SectorId], [SectorNombre], [SectorCapacidad], [SectorPrecio] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT COALESCE( T1.[SectorEntradasVendidas], 0) AS SectorEntradasVendidas FROM (SELECT COUNT(*) AS SectorEntradasVendidas, [EspectaculoId], [SectorId] FROM [Entrada] GROUP BY [EspectaculoId], [SectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00039", "SELECT [EspectaculoId], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoAfiche_GXI], [EspectaculoCantidadInvitacione], [EspectaculoInvitacionesEntrega], [CantidadSectores], [CantidadProductos], [TipoEspectaculoId], [LugarId], [PaisOrigenId] AS PaisOrigenId, [EspectaculoAfiche] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000310", "SELECT [EspectaculoId], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoAfiche_GXI], [EspectaculoCantidadInvitacione], [EspectaculoInvitacionesEntrega], [CantidadSectores], [CantidadProductos], [TipoEspectaculoId], [LugarId], [PaisOrigenId] AS PaisOrigenId, [EspectaculoAfiche] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000311", "SELECT [TipoEspectaculoNombre] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000311,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000312", "SELECT [PaisId], [LugarNombre] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000312,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000313", "SELECT [PaisNombre] AS PaisOrigenNombre FROM [Pais] WHERE [PaisId] = @PaisOrigenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000314", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000315", "SELECT T3.[PaisId], TM1.[EspectaculoId], TM1.[EspectaculoNombre], TM1.[EspectaculoFecha], T2.[TipoEspectaculoNombre], T3.[LugarNombre], T4.[PaisNombre], T5.[PaisNombre] AS PaisOrigenNombre, TM1.[EspectaculoAfiche_GXI], TM1.[EspectaculoCantidadInvitacione], TM1.[EspectaculoInvitacionesEntrega], TM1.[CantidadSectores], TM1.[CantidadProductos], TM1.[TipoEspectaculoId], TM1.[LugarId], TM1.[PaisOrigenId] AS PaisOrigenId, TM1.[EspectaculoAfiche] FROM (((([Espectaculo] TM1 INNER JOIN [TipoEspectaculo] T2 ON T2.[TipoEspectaculoId] = TM1.[TipoEspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = TM1.[LugarId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisId]) INNER JOIN [Pais] T5 ON T5.[PaisId] = TM1.[PaisOrigenId]) WHERE TM1.[EspectaculoId] = @EspectaculoId ORDER BY TM1.[EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000316", "SELECT [EspectaculoNombre] FROM [Espectaculo] WHERE ([EspectaculoNombre] = @EspectaculoNombre) AND (Not ( [EspectaculoId] = @EspectaculoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000317", "SELECT [TipoEspectaculoNombre] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000318", "SELECT [PaisId], [LugarNombre] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000318,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000319", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000319,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000320", "SELECT [PaisNombre] AS PaisOrigenNombre FROM [Pais] WHERE [PaisId] = @PaisOrigenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000320,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000321", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000321,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000322", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE ( [EspectaculoId] > @EspectaculoId) ORDER BY [EspectaculoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000322,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000323", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE ( [EspectaculoId] < @EspectaculoId) ORDER BY [EspectaculoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000323,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000324", "INSERT INTO [Espectaculo]([EspectaculoNombre], [EspectaculoFecha], [EspectaculoAfiche], [EspectaculoAfiche_GXI], [EspectaculoCantidadInvitacione], [EspectaculoInvitacionesEntrega], [CantidadSectores], [CantidadProductos], [TipoEspectaculoId], [LugarId], [PaisOrigenId]) VALUES(@EspectaculoNombre, @EspectaculoFecha, @EspectaculoAfiche, @EspectaculoAfiche_GXI, @EspectaculoCantidadInvitacione, @EspectaculoInvitacionesEntrega, @CantidadSectores, @CantidadProductos, @TipoEspectaculoId, @LugarId, @PaisOrigenId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000324,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000325", "UPDATE [Espectaculo] SET [EspectaculoNombre]=@EspectaculoNombre, [EspectaculoFecha]=@EspectaculoFecha, [EspectaculoCantidadInvitacione]=@EspectaculoCantidadInvitacione, [EspectaculoInvitacionesEntrega]=@EspectaculoInvitacionesEntrega, [CantidadSectores]=@CantidadSectores, [CantidadProductos]=@CantidadProductos, [TipoEspectaculoId]=@TipoEspectaculoId, [LugarId]=@LugarId, [PaisOrigenId]=@PaisOrigenId  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000325)
             ,new CursorDef("T000326", "UPDATE [Espectaculo] SET [EspectaculoAfiche]=@EspectaculoAfiche, [EspectaculoAfiche_GXI]=@EspectaculoAfiche_GXI  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000326)
             ,new CursorDef("T000327", "DELETE FROM [Espectaculo]  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000327)
             ,new CursorDef("T000328", "SELECT [TipoEspectaculoNombre] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000328,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000329", "SELECT [PaisId], [LugarNombre] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000329,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000330", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000330,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000331", "SELECT [PaisNombre] AS PaisOrigenNombre FROM [Pais] WHERE [PaisId] = @PaisOrigenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000331,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000332", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000332,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000333", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000333,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000334", "UPDATE [Espectaculo] SET [CantidadProductos]=@CantidadProductos, [CantidadSectores]=@CantidadSectores  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000334)
             ,new CursorDef("T000335", "SELECT [EspectaculoId] FROM [Espectaculo] ORDER BY [EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000335,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000337", "SELECT T1.[EspectaculoId], T1.[SectorId], T1.[SectorNombre], T1.[SectorCapacidad], T1.[SectorPrecio], COALESCE( T2.[SectorEntradasVendidas], 0) AS SectorEntradasVendidas FROM ([EspectaculoSector] T1 LEFT JOIN (SELECT COUNT(*) AS SectorEntradasVendidas, [EspectaculoId], [SectorId] FROM [Entrada] GROUP BY [EspectaculoId], [SectorId] ) T2 ON T2.[EspectaculoId] = T1.[EspectaculoId] AND T2.[SectorId] = T1.[SectorId]) WHERE T1.[EspectaculoId] = @EspectaculoId and T1.[SectorId] = @SectorId ORDER BY T1.[EspectaculoId], T1.[SectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000337,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000339", "SELECT COALESCE( T1.[SectorEntradasVendidas], 0) AS SectorEntradasVendidas FROM (SELECT COUNT(*) AS SectorEntradasVendidas, [EspectaculoId], [SectorId] FROM [Entrada] GROUP BY [EspectaculoId], [SectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000339,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000340", "SELECT [EspectaculoId], [SectorId] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000340,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000341", "INSERT INTO [EspectaculoSector]([EspectaculoId], [SectorId], [SectorNombre], [SectorCapacidad], [SectorPrecio]) VALUES(@EspectaculoId, @SectorId, @SectorNombre, @SectorCapacidad, @SectorPrecio)", GxErrorMask.GX_NOMASK,prmT000341)
             ,new CursorDef("T000342", "UPDATE [EspectaculoSector] SET [SectorNombre]=@SectorNombre, [SectorCapacidad]=@SectorCapacidad, [SectorPrecio]=@SectorPrecio  WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmT000342)
             ,new CursorDef("T000343", "DELETE FROM [EspectaculoSector]  WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmT000343)
             ,new CursorDef("T000345", "SELECT COALESCE( T1.[SectorEntradasVendidas], 0) AS SectorEntradasVendidas FROM (SELECT COUNT(*) AS SectorEntradasVendidas, [EspectaculoId], [SectorId] FROM [Entrada] GROUP BY [EspectaculoId], [SectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000345,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000346", "SELECT TOP 1 [PaseId], [PaseTipo] FROM [Pase] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000346,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000347", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000347,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000348", "SELECT [EspectaculoId], [SectorId] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId ORDER BY [EspectaculoId], [SectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000348,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000349", "SELECT T1.[EspectaculoId], T2.[ProductoNombre], T2.[ProductoTipo], T1.[ProductoStockInicial], T1.[ProductoPrecio], T1.[ProductoCantidadVendidos], T1.[ProductoId] FROM ([EspectaculoProducto] T1 INNER JOIN [Producto] T2 ON T2.[ProductoId] = T1.[ProductoId]) WHERE T1.[EspectaculoId] = @EspectaculoId and T1.[ProductoId] = @ProductoId ORDER BY T1.[EspectaculoId], T1.[ProductoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000349,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000350", "SELECT [ProductoNombre], [ProductoTipo] FROM [Producto] WHERE [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000350,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000351", "SELECT [EspectaculoId], [ProductoId] FROM [EspectaculoProducto] WHERE [EspectaculoId] = @EspectaculoId AND [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000351,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000352", "INSERT INTO [EspectaculoProducto]([EspectaculoId], [ProductoStockInicial], [ProductoPrecio], [ProductoCantidadVendidos], [ProductoId]) VALUES(@EspectaculoId, @ProductoStockInicial, @ProductoPrecio, @ProductoCantidadVendidos, @ProductoId)", GxErrorMask.GX_NOMASK,prmT000352)
             ,new CursorDef("T000353", "UPDATE [EspectaculoProducto] SET [ProductoStockInicial]=@ProductoStockInicial, [ProductoPrecio]=@ProductoPrecio, [ProductoCantidadVendidos]=@ProductoCantidadVendidos  WHERE [EspectaculoId] = @EspectaculoId AND [ProductoId] = @ProductoId", GxErrorMask.GX_NOMASK,prmT000353)
             ,new CursorDef("T000354", "DELETE FROM [EspectaculoProducto]  WHERE [EspectaculoId] = @EspectaculoId AND [ProductoId] = @ProductoId", GxErrorMask.GX_NOMASK,prmT000354)
             ,new CursorDef("T000355", "SELECT [ProductoNombre], [ProductoTipo] FROM [Producto] WHERE [ProductoId] = @ProductoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000355,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000356", "SELECT [EspectaculoId], [ProductoId] FROM [EspectaculoProducto] WHERE [EspectaculoId] = @EspectaculoId ORDER BY [EspectaculoId], [ProductoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000356,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000357", "SELECT [EspectaculoNombre] FROM [Espectaculo] WHERE ([EspectaculoNombre] = @EspectaculoNombre) AND (Not ( [EspectaculoId] = @EspectaculoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000357,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(4));
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(4));
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 60);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 60);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((short[]) buf[14])[0] = rslt.getShort(15);
                ((short[]) buf[15])[0] = rslt.getShort(16);
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(9));
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
             case 34 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 35 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 39 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 40 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 41 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 42 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 43 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getString(3, 40);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 44 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                return;
             case 45 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 49 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                return;
             case 50 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 51 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
       }
    }

 }

}
