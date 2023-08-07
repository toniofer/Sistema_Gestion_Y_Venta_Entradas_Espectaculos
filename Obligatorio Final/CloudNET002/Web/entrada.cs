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
   public class entrada : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A5EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A5EspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A5EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A9SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A5EspectaculoId, A9SectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A12PaisCompraId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisCompraId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A12PaisCompraId", StringUtil.LTrimStr( (decimal)(A12PaisCompraId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A12PaisCompraId) ;
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
               AV7EntradaId = (short)(Math.Round(NumberUtil.Val( GetPar( "EntradaId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7EntradaId", StringUtil.LTrimStr( (decimal)(AV7EntradaId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vENTRADAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EntradaId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Entrada", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public entrada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public entrada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EntradaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EntradaId = aP1_EntradaId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Entrada", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Entrada.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Entrada.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEntradaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEntradaId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEntradaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11EntradaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEntradaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A11EntradaId), "ZZZ9") : context.localUtil.Format( (decimal)(A11EntradaId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntradaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntradaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Entrada.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Entrada.htm");
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
         GxWebStd.gx_label_element( context, edtEspectaculoNombre_Internalname, "Espectaculo Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoNombre_Internalname, StringUtil.RTrim( A8EspectaculoNombre), StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_label_element( context, edtEspectaculoFecha_Internalname, "Espectaculo Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtEspectaculoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A19EspectaculoFecha, "99/99/99"), context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorId_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Entrada.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_9_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_9_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorNombre_Internalname, "Sector Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSectorNombre_Internalname, StringUtil.RTrim( A21SectorNombre), StringUtil.RTrim( context.localUtil.Format( A21SectorNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorPrecio_Internalname, "Sector Precio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ",", "")), StringUtil.LTrim( ((edtSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9") : context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorPrecio_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorEntradasVendidas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorEntradasVendidas_Internalname, "Sector Entradas Vendidas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSectorEntradasVendidas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorEntradasVendidas), 5, 0, ",", "")), StringUtil.LTrim( ((edtSectorEntradasVendidas_Enabled!=0) ? context.localUtil.Format( (decimal)(A25SectorEntradasVendidas), "ZZZZ9") : context.localUtil.Format( (decimal)(A25SectorEntradasVendidas), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorEntradasVendidas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorEntradasVendidas_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorEntradasDisponibles_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorEntradasDisponibles_Internalname, "Sector Entradas Disponibles", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSectorEntradasDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24SectorEntradasDisponibles), 5, 0, ",", "")), StringUtil.LTrim( ((edtSectorEntradasDisponibles_Enabled!=0) ? context.localUtil.Format( (decimal)(A24SectorEntradasDisponibles), "ZZZZ9") : context.localUtil.Format( (decimal)(A24SectorEntradasDisponibles), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorEntradasDisponibles_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorEntradasDisponibles_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisCompraId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisCompraId_Internalname, "Compra Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisCompraId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12PaisCompraId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A12PaisCompraId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisCompraId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisCompraId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Entrada.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_12_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_12_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_12_Internalname, sImgUrl, imgprompt_12_Link, "", "", context.GetTheme( ), imgprompt_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisCompraNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisCompraNombre_Internalname, "Compra Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisCompraNombre_Internalname, StringUtil.RTrim( A27PaisCompraNombre), StringUtil.RTrim( context.localUtil.Format( A27PaisCompraNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisCompraNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisCompraNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Entrada.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z11EntradaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z11EntradaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z5EspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z9SectorId"), ",", "."), 18, MidpointRounding.ToEven));
               Z12PaisCompraId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z12PaisCompraId"), ",", "."), 18, MidpointRounding.ToEven));
               O25SectorEntradasVendidas = (int)(Math.Round(context.localUtil.CToN( cgiGet( "O25SectorEntradasVendidas"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N5EspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               N9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N9SectorId"), ",", "."), 18, MidpointRounding.ToEven));
               N12PaisCompraId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N12PaisCompraId"), ",", "."), 18, MidpointRounding.ToEven));
               A22SectorCapacidad = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORCAPACIDAD"), ",", "."), 18, MidpointRounding.ToEven));
               AV7EntradaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vENTRADAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESPECTACULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECTORID"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Insert_PaisCompraId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PAISCOMPRAID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A11EntradaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEntradaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A5EspectaculoId = 0;
                  AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
               }
               else
               {
                  A5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
               }
               A8EspectaculoNombre = cgiGet( edtEspectaculoNombre_Internalname);
               AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
               A19EspectaculoFecha = context.localUtil.CToD( cgiGet( edtEspectaculoFecha_Internalname), 2);
               AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
               if ( ( ( context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECTORID");
                  AnyError = 1;
                  GX_FocusControl = edtSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9SectorId = 0;
                  AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
               }
               else
               {
                  A9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
               }
               A21SectorNombre = cgiGet( edtSectorNombre_Internalname);
               AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
               A23SectorPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
               A25SectorEntradasVendidas = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorEntradasVendidas_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A25SectorEntradasVendidas", StringUtil.LTrimStr( (decimal)(A25SectorEntradasVendidas), 5, 0));
               A24SectorEntradasDisponibles = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorEntradasDisponibles_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A24SectorEntradasDisponibles", StringUtil.LTrimStr( (decimal)(A24SectorEntradasDisponibles), 5, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisCompraId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisCompraId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISCOMPRAID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisCompraId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A12PaisCompraId = 0;
                  AssignAttri("", false, "A12PaisCompraId", StringUtil.LTrimStr( (decimal)(A12PaisCompraId), 4, 0));
               }
               else
               {
                  A12PaisCompraId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisCompraId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A12PaisCompraId", StringUtil.LTrimStr( (decimal)(A12PaisCompraId), 4, 0));
               }
               A27PaisCompraNombre = cgiGet( edtPaisCompraNombre_Internalname);
               AssignAttri("", false, "A27PaisCompraNombre", A27PaisCompraNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Entrada");
               A11EntradaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEntradaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
               forbiddenHiddens.Add("EntradaId", context.localUtil.Format( (decimal)(A11EntradaId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A11EntradaId != Z11EntradaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("entrada:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A11EntradaId = (short)(Math.Round(NumberUtil.Val( GetPar( "EntradaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ENTRADAID");
                        AnyError = 1;
                        GX_FocusControl = edtEntradaId_Internalname;
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
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll046( ) ;
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
            DisableAttributes046( ) ;
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
               CloseExtendedTableCursors046( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_EspectaculoId = 0;
         AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
         AV12Insert_SectorId = 0;
         AssignAttri("", false, "AV12Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV12Insert_SectorId), 4, 0));
         AV13Insert_PaisCompraId = 0;
         AssignAttri("", false, "AV13Insert_PaisCompraId", StringUtil.LTrimStr( (decimal)(AV13Insert_PaisCompraId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "EspectaculoId") == 0 )
               {
                  AV11Insert_EspectaculoId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SectorId") == 0 )
               {
                  AV12Insert_SectorId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV12Insert_SectorId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "PaisCompraId") == 0 )
               {
                  AV13Insert_PaisCompraId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_PaisCompraId", StringUtil.LTrimStr( (decimal)(AV13Insert_PaisCompraId), 4, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
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

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.PopUp(formatLink("aemitirticket.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A11EntradaId,4,0))}, new string[] {"EntradaId"}) , new Object[] {});
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwentrada.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z5EspectaculoId = T00043_A5EspectaculoId[0];
               Z9SectorId = T00043_A9SectorId[0];
               Z12PaisCompraId = T00043_A12PaisCompraId[0];
            }
            else
            {
               Z5EspectaculoId = A5EspectaculoId;
               Z9SectorId = A9SectorId;
               Z12PaisCompraId = A12PaisCompraId;
            }
         }
         if ( GX_JID == -18 )
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
         edtEntradaId_Enabled = 0;
         AssignProp("", false, edtEntradaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaId_Enabled), 5, 0), true);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0041.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"SECTORID"+"'), id:'"+"SECTORID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISCOMPRAID"+"'), id:'"+"PAISCOMPRAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtEntradaId_Enabled = 0;
         AssignProp("", false, edtEntradaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EntradaId) )
         {
            A11EntradaId = AV7EntradaId;
            AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspectaculoId) )
         {
            edtEspectaculoId_Enabled = 0;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         else
         {
            edtEspectaculoId_Enabled = 1;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SectorId) )
         {
            edtSectorId_Enabled = 0;
            AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         }
         else
         {
            edtSectorId_Enabled = 1;
            AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_PaisCompraId) )
         {
            edtPaisCompraId_Enabled = 0;
            AssignProp("", false, edtPaisCompraId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraId_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisCompraId_Enabled = 1;
            AssignProp("", false, edtPaisCompraId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_PaisCompraId) )
         {
            A12PaisCompraId = AV13Insert_PaisCompraId;
            AssignAttri("", false, "A12PaisCompraId", StringUtil.LTrimStr( (decimal)(A12PaisCompraId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SectorId) )
         {
            A9SectorId = AV12Insert_SectorId;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspectaculoId) )
         {
            A5EspectaculoId = AV11Insert_EspectaculoId;
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV16Pgmname = "Entrada";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T00046 */
            pr_default.execute(4, new Object[] {A12PaisCompraId});
            A27PaisCompraNombre = T00046_A27PaisCompraNombre[0];
            AssignAttri("", false, "A27PaisCompraNombre", A27PaisCompraNombre);
            pr_default.close(4);
            /* Using cursor T00044 */
            pr_default.execute(2, new Object[] {A5EspectaculoId});
            A8EspectaculoNombre = T00044_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T00044_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            pr_default.close(2);
            /* Using cursor T00045 */
            pr_default.execute(3, new Object[] {A5EspectaculoId, A9SectorId});
            A21SectorNombre = T00045_A21SectorNombre[0];
            AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
            A23SectorPrecio = T00045_A23SectorPrecio[0];
            AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
            A22SectorCapacidad = T00045_A22SectorCapacidad[0];
            pr_default.close(3);
         }
      }

      protected void Load046( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A11EntradaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
            A8EspectaculoNombre = T00047_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T00047_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            A21SectorNombre = T00047_A21SectorNombre[0];
            AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
            A23SectorPrecio = T00047_A23SectorPrecio[0];
            AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
            A27PaisCompraNombre = T00047_A27PaisCompraNombre[0];
            AssignAttri("", false, "A27PaisCompraNombre", A27PaisCompraNombre);
            A22SectorCapacidad = T00047_A22SectorCapacidad[0];
            A5EspectaculoId = T00047_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A9SectorId = T00047_A9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
            A12PaisCompraId = T00047_A12PaisCompraId[0];
            AssignAttri("", false, "A12PaisCompraId", StringUtil.LTrimStr( (decimal)(A12PaisCompraId), 4, 0));
            ZM046( -18) ;
         }
         pr_default.close(5);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
         AV16Pgmname = "Entrada";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable046( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV16Pgmname = "Entrada";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8EspectaculoNombre = T00044_A8EspectaculoNombre[0];
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = T00044_A19EspectaculoFecha[0];
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         pr_default.close(2);
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A5EspectaculoId, A9SectorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21SectorNombre = T00045_A21SectorNombre[0];
         AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
         A23SectorPrecio = T00045_A23SectorPrecio[0];
         AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
         A22SectorCapacidad = T00045_A22SectorCapacidad[0];
         pr_default.close(3);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A12PaisCompraId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais Compra'.", "ForeignKeyNotFound", 1, "PAISCOMPRAID");
            AnyError = 1;
            GX_FocusControl = edtPaisCompraId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A27PaisCompraNombre = T00046_A27PaisCompraNombre[0];
         AssignAttri("", false, "A27PaisCompraNombre", A27PaisCompraNombre);
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

      protected void gxLoad_19( short A5EspectaculoId )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8EspectaculoNombre = T00048_A8EspectaculoNombre[0];
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = T00048_A19EspectaculoFecha[0];
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8EspectaculoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A19EspectaculoFecha, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_20( short A5EspectaculoId ,
                                short A9SectorId )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A5EspectaculoId, A9SectorId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21SectorNombre = T00049_A21SectorNombre[0];
         AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
         A23SectorPrecio = T00049_A23SectorPrecio[0];
         AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
         A22SectorCapacidad = T00049_A22SectorCapacidad[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A21SectorNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_21( short A12PaisCompraId )
      {
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A12PaisCompraId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais Compra'.", "ForeignKeyNotFound", 1, "PAISCOMPRAID");
            AnyError = 1;
            GX_FocusControl = edtPaisCompraId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A27PaisCompraNombre = T000410_A27PaisCompraNombre[0];
         AssignAttri("", false, "A27PaisCompraNombre", A27PaisCompraNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A27PaisCompraNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey046( )
      {
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A11EntradaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A11EntradaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 18) ;
            RcdFound6 = 1;
            A11EntradaId = T00043_A11EntradaId[0];
            AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
            A5EspectaculoId = T00043_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A9SectorId = T00043_A9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
            A12PaisCompraId = T00043_A12PaisCompraId[0];
            AssignAttri("", false, "A12PaisCompraId", StringUtil.LTrimStr( (decimal)(A12PaisCompraId), 4, 0));
            Z11EntradaId = A11EntradaId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load046( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey046( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey046( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000412 */
         pr_default.execute(10, new Object[] {A11EntradaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000412_A11EntradaId[0] < A11EntradaId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000412_A11EntradaId[0] > A11EntradaId ) ) )
            {
               A11EntradaId = T000412_A11EntradaId[0];
               AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000413 */
         pr_default.execute(11, new Object[] {A11EntradaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000413_A11EntradaId[0] > A11EntradaId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000413_A11EntradaId[0] < A11EntradaId ) ) )
            {
               A11EntradaId = T000413_A11EntradaId[0];
               AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey046( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert046( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A11EntradaId != Z11EntradaId )
               {
                  A11EntradaId = Z11EntradaId;
                  AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ENTRADAID");
                  AnyError = 1;
                  GX_FocusControl = edtEntradaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update046( ) ;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A11EntradaId != Z11EntradaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert046( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTRADAID");
                     AnyError = 1;
                     GX_FocusControl = edtEntradaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEspectaculoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert046( ) ;
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
         if ( A11EntradaId != Z11EntradaId )
         {
            A11EntradaId = Z11EntradaId;
            AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ENTRADAID");
            AnyError = 1;
            GX_FocusControl = edtEntradaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A11EntradaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Entrada"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z5EspectaculoId != T00042_A5EspectaculoId[0] ) || ( Z9SectorId != T00042_A9SectorId[0] ) || ( Z12PaisCompraId != T00042_A12PaisCompraId[0] ) )
            {
               if ( Z5EspectaculoId != T00042_A5EspectaculoId[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"EspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z5EspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A5EspectaculoId[0]);
               }
               if ( Z9SectorId != T00042_A9SectorId[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"SectorId");
                  GXUtil.WriteLogRaw("Old: ",Z9SectorId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A9SectorId[0]);
               }
               if ( Z12PaisCompraId != T00042_A12PaisCompraId[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"PaisCompraId");
                  GXUtil.WriteLogRaw("Old: ",Z12PaisCompraId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A12PaisCompraId[0]);
               }
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
                     /* Using cursor T000414 */
                     pr_default.execute(12, new Object[] {A5EspectaculoId, A9SectorId, A12PaisCompraId});
                     A11EntradaId = T000414_A11EntradaId[0];
                     AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
                     pr_default.close(12);
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
                           ResetCaption040( ) ;
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
                     /* Using cursor T000415 */
                     pr_default.execute(13, new Object[] {A5EspectaculoId, A9SectorId, A12PaisCompraId, A11EntradaId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Entrada");
                     if ( (pr_default.getStatus(13) == 103) )
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
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void DeferredUpdate046( )
      {
      }

      protected void delete( )
      {
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
                  /* Using cursor T000416 */
                  pr_default.execute(14, new Object[] {A11EntradaId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Entrada");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel046( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Entrada";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000417 */
            pr_default.execute(15, new Object[] {A5EspectaculoId});
            A8EspectaculoNombre = T000417_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T000417_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            pr_default.close(15);
            /* Using cursor T000418 */
            pr_default.execute(16, new Object[] {A5EspectaculoId, A9SectorId});
            A21SectorNombre = T000418_A21SectorNombre[0];
            AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
            A23SectorPrecio = T000418_A23SectorPrecio[0];
            AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
            A22SectorCapacidad = T000418_A22SectorCapacidad[0];
            pr_default.close(16);
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {A12PaisCompraId});
            A27PaisCompraNombre = T000419_A27PaisCompraNombre[0];
            AssignAttri("", false, "A27PaisCompraNombre", A27PaisCompraNombre);
            pr_default.close(17);
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
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.CommitDataStores("entrada",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.RollbackDataStores("entrada",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart046( )
      {
         /* Scan By routine */
         /* Using cursor T000420 */
         pr_default.execute(18);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound6 = 1;
            A11EntradaId = T000420_A11EntradaId[0];
            AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound6 = 1;
            A11EntradaId = T000420_A11EntradaId[0];
            AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
         }
      }

      protected void ScanEnd046( )
      {
         pr_default.close(18);
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
         edtEntradaId_Enabled = 0;
         AssignProp("", false, edtEntradaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaId_Enabled), 5, 0), true);
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtEspectaculoNombre_Enabled = 0;
         AssignProp("", false, edtEspectaculoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoNombre_Enabled), 5, 0), true);
         edtEspectaculoFecha_Enabled = 0;
         AssignProp("", false, edtEspectaculoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFecha_Enabled), 5, 0), true);
         edtSectorId_Enabled = 0;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         edtSectorNombre_Enabled = 0;
         AssignProp("", false, edtSectorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorNombre_Enabled), 5, 0), true);
         edtSectorPrecio_Enabled = 0;
         AssignProp("", false, edtSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorPrecio_Enabled), 5, 0), true);
         edtSectorEntradasVendidas_Enabled = 0;
         AssignProp("", false, edtSectorEntradasVendidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorEntradasVendidas_Enabled), 5, 0), true);
         edtSectorEntradasDisponibles_Enabled = 0;
         AssignProp("", false, edtSectorEntradasDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorEntradasDisponibles_Enabled), 5, 0), true);
         edtPaisCompraId_Enabled = 0;
         AssignProp("", false, edtPaisCompraId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraId_Enabled), 5, 0), true);
         edtPaisCompraNombre_Enabled = 0;
         AssignProp("", false, edtPaisCompraNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
      {
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("entrada.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EntradaId,4,0))}, new string[] {"Gx_mode","EntradaId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Entrada");
         forbiddenHiddens.Add("EntradaId", context.localUtil.Format( (decimal)(A11EntradaId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("entrada:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z11EntradaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11EntradaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z12PaisCompraId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12PaisCompraId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O25SectorEntradasVendidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(O25SectorEntradasVendidas), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N5EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N12PaisCompraId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12PaisCompraId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "SECTORCAPACIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vENTRADAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EntradaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vENTRADAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EntradaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISCOMPRAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_PaisCompraId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
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
         return formatLink("entrada.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EntradaId,4,0))}, new string[] {"Gx_mode","EntradaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Entrada" ;
      }

      public override string GetPgmdesc( )
      {
         return "Entrada" ;
      }

      protected void InitializeNonKey046( )
      {
         A5EspectaculoId = 0;
         AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
         A9SectorId = 0;
         AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
         A12PaisCompraId = 0;
         AssignAttri("", false, "A12PaisCompraId", StringUtil.LTrimStr( (decimal)(A12PaisCompraId), 4, 0));
         A25SectorEntradasVendidas = 0;
         AssignAttri("", false, "A25SectorEntradasVendidas", StringUtil.LTrimStr( (decimal)(A25SectorEntradasVendidas), 5, 0));
         A24SectorEntradasDisponibles = 0;
         AssignAttri("", false, "A24SectorEntradasDisponibles", StringUtil.LTrimStr( (decimal)(A24SectorEntradasDisponibles), 5, 0));
         A8EspectaculoNombre = "";
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = DateTime.MinValue;
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         A21SectorNombre = "";
         AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
         A23SectorPrecio = 0;
         AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
         A27PaisCompraNombre = "";
         AssignAttri("", false, "A27PaisCompraNombre", A27PaisCompraNombre);
         A22SectorCapacidad = 0;
         AssignAttri("", false, "A22SectorCapacidad", StringUtil.LTrimStr( (decimal)(A22SectorCapacidad), 5, 0));
         O25SectorEntradasVendidas = A25SectorEntradasVendidas;
         AssignAttri("", false, "A25SectorEntradasVendidas", StringUtil.LTrimStr( (decimal)(A25SectorEntradasVendidas), 5, 0));
         Z5EspectaculoId = 0;
         Z9SectorId = 0;
         Z12PaisCompraId = 0;
      }

      protected void InitAll046( )
      {
         A11EntradaId = 0;
         AssignAttri("", false, "A11EntradaId", StringUtil.LTrimStr( (decimal)(A11EntradaId), 4, 0));
         InitializeNonKey046( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874412510", true, true);
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
         context.AddJavascriptSource("entrada.js", "?2023874412511", false, true);
         /* End function include_jscripts */
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
         edtEntradaId_Internalname = "ENTRADAID";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoNombre_Internalname = "ESPECTACULONOMBRE";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtSectorId_Internalname = "SECTORID";
         edtSectorNombre_Internalname = "SECTORNOMBRE";
         edtSectorPrecio_Internalname = "SECTORPRECIO";
         edtSectorEntradasVendidas_Internalname = "SECTORENTRADASVENDIDAS";
         edtSectorEntradasDisponibles_Internalname = "SECTORENTRADASDISPONIBLES";
         edtPaisCompraId_Internalname = "PAISCOMPRAID";
         edtPaisCompraNombre_Internalname = "PAISCOMPRANOMBRE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_12_Internalname = "PROMPT_12";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Entrada";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPaisCompraNombre_Jsonclick = "";
         edtPaisCompraNombre_Enabled = 0;
         imgprompt_12_Visible = 1;
         imgprompt_12_Link = "";
         edtPaisCompraId_Jsonclick = "";
         edtPaisCompraId_Enabled = 1;
         edtSectorEntradasDisponibles_Jsonclick = "";
         edtSectorEntradasDisponibles_Enabled = 0;
         edtSectorEntradasVendidas_Jsonclick = "";
         edtSectorEntradasVendidas_Enabled = 0;
         edtSectorPrecio_Jsonclick = "";
         edtSectorPrecio_Enabled = 0;
         edtSectorNombre_Jsonclick = "";
         edtSectorNombre_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtSectorId_Jsonclick = "";
         edtSectorId_Enabled = 1;
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 0;
         edtEspectaculoNombre_Jsonclick = "";
         edtEspectaculoNombre_Enabled = 0;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 1;
         edtEntradaId_Jsonclick = "";
         edtEntradaId_Enabled = 0;
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

      protected void init_web_controls( )
      {
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

      public void Valid_Espectaculoid( )
      {
         /* Using cursor T000417 */
         pr_default.execute(15, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         A8EspectaculoNombre = T000417_A8EspectaculoNombre[0];
         A19EspectaculoFecha = T000417_A19EspectaculoFecha[0];
         pr_default.close(15);
         if ( DateTimeUtil.ResetTime ( A19EspectaculoFecha ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("La fecha del espectáculo es anterior a la fecha actual", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8EspectaculoNombre", StringUtil.RTrim( A8EspectaculoNombre));
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
      }

      public void Valid_Sectorid( )
      {
         /* Using cursor T000418 */
         pr_default.execute(16, new Object[] {A5EspectaculoId, A9SectorId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         A21SectorNombre = T000418_A21SectorNombre[0];
         A23SectorPrecio = T000418_A23SectorPrecio[0];
         A22SectorCapacidad = T000418_A22SectorCapacidad[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A21SectorNombre", StringUtil.RTrim( A21SectorNombre));
         AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ".", "")));
         AssignAttri("", false, "A22SectorCapacidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ".", "")));
      }

      public void Valid_Paiscompraid( )
      {
         /* Using cursor T000419 */
         pr_default.execute(17, new Object[] {A12PaisCompraId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais Compra'.", "ForeignKeyNotFound", 1, "PAISCOMPRAID");
            AnyError = 1;
            GX_FocusControl = edtPaisCompraId_Internalname;
         }
         A27PaisCompraNombre = T000419_A27PaisCompraNombre[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A27PaisCompraNombre", StringUtil.RTrim( A27PaisCompraNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7EntradaId',fld:'vENTRADAID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EntradaId',fld:'vENTRADAID',pic:'ZZZ9',hsh:true},{av:'A11EntradaId',fld:'ENTRADAID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12042',iparms:[{av:'A11EntradaId',fld:'ENTRADAID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ENTRADAID","{handler:'Valid_Entradaid',iparms:[]");
         setEventMetadata("VALID_ENTRADAID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A19EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''},{av:'Gx_date',fld:'vTODAY',pic:''},{av:'A8EspectaculoNombre',fld:'ESPECTACULONOMBRE',pic:''}]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[{av:'A8EspectaculoNombre',fld:'ESPECTACULONOMBRE',pic:''},{av:'A19EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''}]}");
         setEventMetadata("VALID_ESPECTACULOFECHA","{handler:'Valid_Espectaculofecha',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFECHA",",oparms:[]}");
         setEventMetadata("VALID_SECTORID","{handler:'Valid_Sectorid',iparms:[{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZ9'},{av:'A21SectorNombre',fld:'SECTORNOMBRE',pic:''},{av:'A23SectorPrecio',fld:'SECTORPRECIO',pic:'ZZZZZ9'},{av:'A22SectorCapacidad',fld:'SECTORCAPACIDAD',pic:'ZZZZ9'}]");
         setEventMetadata("VALID_SECTORID",",oparms:[{av:'A21SectorNombre',fld:'SECTORNOMBRE',pic:''},{av:'A23SectorPrecio',fld:'SECTORPRECIO',pic:'ZZZZZ9'},{av:'A22SectorCapacidad',fld:'SECTORCAPACIDAD',pic:'ZZZZ9'}]}");
         setEventMetadata("VALID_SECTORENTRADASVENDIDAS","{handler:'Valid_Sectorentradasvendidas',iparms:[]");
         setEventMetadata("VALID_SECTORENTRADASVENDIDAS",",oparms:[]}");
         setEventMetadata("VALID_SECTORENTRADASDISPONIBLES","{handler:'Valid_Sectorentradasdisponibles',iparms:[]");
         setEventMetadata("VALID_SECTORENTRADASDISPONIBLES",",oparms:[]}");
         setEventMetadata("VALID_PAISCOMPRAID","{handler:'Valid_Paiscompraid',iparms:[{av:'A12PaisCompraId',fld:'PAISCOMPRAID',pic:'ZZZ9'},{av:'A27PaisCompraNombre',fld:'PAISCOMPRANOMBRE',pic:''}]");
         setEventMetadata("VALID_PAISCOMPRAID",",oparms:[{av:'A27PaisCompraNombre',fld:'PAISCOMPRANOMBRE',pic:''}]}");
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
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
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
         imgprompt_5_gximage = "";
         sImgUrl = "";
         A8EspectaculoNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         imgprompt_9_gximage = "";
         A21SectorNombre = "";
         imgprompt_12_gximage = "";
         A27PaisCompraNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
         Z21SectorNombre = "";
         Z27PaisCompraNombre = "";
         T00046_A27PaisCompraNombre = new string[] {""} ;
         T00044_A8EspectaculoNombre = new string[] {""} ;
         T00044_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00045_A21SectorNombre = new string[] {""} ;
         T00045_A23SectorPrecio = new int[1] ;
         T00045_A22SectorCapacidad = new int[1] ;
         T00047_A11EntradaId = new short[1] ;
         T00047_A8EspectaculoNombre = new string[] {""} ;
         T00047_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00047_A21SectorNombre = new string[] {""} ;
         T00047_A23SectorPrecio = new int[1] ;
         T00047_A27PaisCompraNombre = new string[] {""} ;
         T00047_A22SectorCapacidad = new int[1] ;
         T00047_A5EspectaculoId = new short[1] ;
         T00047_A9SectorId = new short[1] ;
         T00047_A12PaisCompraId = new short[1] ;
         T00048_A8EspectaculoNombre = new string[] {""} ;
         T00048_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00049_A21SectorNombre = new string[] {""} ;
         T00049_A23SectorPrecio = new int[1] ;
         T00049_A22SectorCapacidad = new int[1] ;
         T000410_A27PaisCompraNombre = new string[] {""} ;
         T000411_A11EntradaId = new short[1] ;
         T00043_A11EntradaId = new short[1] ;
         T00043_A5EspectaculoId = new short[1] ;
         T00043_A9SectorId = new short[1] ;
         T00043_A12PaisCompraId = new short[1] ;
         T000412_A11EntradaId = new short[1] ;
         T000413_A11EntradaId = new short[1] ;
         T00042_A11EntradaId = new short[1] ;
         T00042_A5EspectaculoId = new short[1] ;
         T00042_A9SectorId = new short[1] ;
         T00042_A12PaisCompraId = new short[1] ;
         T000414_A11EntradaId = new short[1] ;
         T000417_A8EspectaculoNombre = new string[] {""} ;
         T000417_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000418_A21SectorNombre = new string[] {""} ;
         T000418_A23SectorPrecio = new int[1] ;
         T000418_A22SectorCapacidad = new int[1] ;
         T000419_A27PaisCompraNombre = new string[] {""} ;
         T000420_A11EntradaId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entrada__default(),
            new Object[][] {
                new Object[] {
               T00042_A11EntradaId, T00042_A5EspectaculoId, T00042_A9SectorId, T00042_A12PaisCompraId
               }
               , new Object[] {
               T00043_A11EntradaId, T00043_A5EspectaculoId, T00043_A9SectorId, T00043_A12PaisCompraId
               }
               , new Object[] {
               T00044_A8EspectaculoNombre, T00044_A19EspectaculoFecha
               }
               , new Object[] {
               T00045_A21SectorNombre, T00045_A23SectorPrecio, T00045_A22SectorCapacidad
               }
               , new Object[] {
               T00046_A27PaisCompraNombre
               }
               , new Object[] {
               T00047_A11EntradaId, T00047_A8EspectaculoNombre, T00047_A19EspectaculoFecha, T00047_A21SectorNombre, T00047_A23SectorPrecio, T00047_A27PaisCompraNombre, T00047_A22SectorCapacidad, T00047_A5EspectaculoId, T00047_A9SectorId, T00047_A12PaisCompraId
               }
               , new Object[] {
               T00048_A8EspectaculoNombre, T00048_A19EspectaculoFecha
               }
               , new Object[] {
               T00049_A21SectorNombre, T00049_A23SectorPrecio, T00049_A22SectorCapacidad
               }
               , new Object[] {
               T000410_A27PaisCompraNombre
               }
               , new Object[] {
               T000411_A11EntradaId
               }
               , new Object[] {
               T000412_A11EntradaId
               }
               , new Object[] {
               T000413_A11EntradaId
               }
               , new Object[] {
               T000414_A11EntradaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000417_A8EspectaculoNombre, T000417_A19EspectaculoFecha
               }
               , new Object[] {
               T000418_A21SectorNombre, T000418_A23SectorPrecio, T000418_A22SectorCapacidad
               }
               , new Object[] {
               T000419_A27PaisCompraNombre
               }
               , new Object[] {
               T000420_A11EntradaId
               }
            }
         );
         AV16Pgmname = "Entrada";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short wcpOAV7EntradaId ;
      private short Z11EntradaId ;
      private short Z5EspectaculoId ;
      private short Z9SectorId ;
      private short Z12PaisCompraId ;
      private short N5EspectaculoId ;
      private short N9SectorId ;
      private short N12PaisCompraId ;
      private short GxWebError ;
      private short A5EspectaculoId ;
      private short A9SectorId ;
      private short A12PaisCompraId ;
      private short AV7EntradaId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A11EntradaId ;
      private short AV11Insert_EspectaculoId ;
      private short AV12Insert_SectorId ;
      private short AV13Insert_PaisCompraId ;
      private short RcdFound6 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_6 ;
      private short gxajaxcallmode ;
      private int O25SectorEntradasVendidas ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEntradaId_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtEspectaculoNombre_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtSectorId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtSectorNombre_Enabled ;
      private int A23SectorPrecio ;
      private int edtSectorPrecio_Enabled ;
      private int A25SectorEntradasVendidas ;
      private int edtSectorEntradasVendidas_Enabled ;
      private int A24SectorEntradasDisponibles ;
      private int edtSectorEntradasDisponibles_Enabled ;
      private int edtPaisCompraId_Enabled ;
      private int imgprompt_12_Visible ;
      private int edtPaisCompraNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int A22SectorCapacidad ;
      private int AV17GXV1 ;
      private int Z23SectorPrecio ;
      private int Z22SectorCapacidad ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEspectaculoId_Internalname ;
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
      private string edtEntradaId_Internalname ;
      private string edtEntradaId_Jsonclick ;
      private string edtEspectaculoId_Jsonclick ;
      private string imgprompt_5_gximage ;
      private string sImgUrl ;
      private string imgprompt_5_Internalname ;
      private string imgprompt_5_Link ;
      private string edtEspectaculoNombre_Internalname ;
      private string A8EspectaculoNombre ;
      private string edtEspectaculoNombre_Jsonclick ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtSectorId_Internalname ;
      private string edtSectorId_Jsonclick ;
      private string imgprompt_9_gximage ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtSectorNombre_Internalname ;
      private string A21SectorNombre ;
      private string edtSectorNombre_Jsonclick ;
      private string edtSectorPrecio_Internalname ;
      private string edtSectorPrecio_Jsonclick ;
      private string edtSectorEntradasVendidas_Internalname ;
      private string edtSectorEntradasVendidas_Jsonclick ;
      private string edtSectorEntradasDisponibles_Internalname ;
      private string edtSectorEntradasDisponibles_Jsonclick ;
      private string edtPaisCompraId_Internalname ;
      private string edtPaisCompraId_Jsonclick ;
      private string imgprompt_12_gximage ;
      private string imgprompt_12_Internalname ;
      private string imgprompt_12_Link ;
      private string edtPaisCompraNombre_Internalname ;
      private string A27PaisCompraNombre ;
      private string edtPaisCompraNombre_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode6 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z8EspectaculoNombre ;
      private string Z21SectorNombre ;
      private string Z27PaisCompraNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime A19EspectaculoFecha ;
      private DateTime Gx_date ;
      private DateTime Z19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00046_A27PaisCompraNombre ;
      private string[] T00044_A8EspectaculoNombre ;
      private DateTime[] T00044_A19EspectaculoFecha ;
      private string[] T00045_A21SectorNombre ;
      private int[] T00045_A23SectorPrecio ;
      private int[] T00045_A22SectorCapacidad ;
      private short[] T00047_A11EntradaId ;
      private string[] T00047_A8EspectaculoNombre ;
      private DateTime[] T00047_A19EspectaculoFecha ;
      private string[] T00047_A21SectorNombre ;
      private int[] T00047_A23SectorPrecio ;
      private string[] T00047_A27PaisCompraNombre ;
      private int[] T00047_A22SectorCapacidad ;
      private short[] T00047_A5EspectaculoId ;
      private short[] T00047_A9SectorId ;
      private short[] T00047_A12PaisCompraId ;
      private string[] T00048_A8EspectaculoNombre ;
      private DateTime[] T00048_A19EspectaculoFecha ;
      private string[] T00049_A21SectorNombre ;
      private int[] T00049_A23SectorPrecio ;
      private int[] T00049_A22SectorCapacidad ;
      private string[] T000410_A27PaisCompraNombre ;
      private short[] T000411_A11EntradaId ;
      private short[] T00043_A11EntradaId ;
      private short[] T00043_A5EspectaculoId ;
      private short[] T00043_A9SectorId ;
      private short[] T00043_A12PaisCompraId ;
      private short[] T000412_A11EntradaId ;
      private short[] T000413_A11EntradaId ;
      private short[] T00042_A11EntradaId ;
      private short[] T00042_A5EspectaculoId ;
      private short[] T00042_A9SectorId ;
      private short[] T00042_A12PaisCompraId ;
      private short[] T000414_A11EntradaId ;
      private string[] T000417_A8EspectaculoNombre ;
      private DateTime[] T000417_A19EspectaculoFecha ;
      private string[] T000418_A21SectorNombre ;
      private int[] T000418_A23SectorPrecio ;
      private int[] T000418_A22SectorCapacidad ;
      private string[] T000419_A27PaisCompraNombre ;
      private short[] T000420_A11EntradaId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class entrada__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00047;
          prmT00047 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00045;
          prmT00045 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@PaisCompraId",GXType.Int16,4,0)
          };
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@PaisCompraId",GXType.Int16,4,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000412;
          prmT000412 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000414;
          prmT000414 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@PaisCompraId",GXType.Int16,4,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@PaisCompraId",GXType.Int16,4,0) ,
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000420;
          prmT000420 = new Object[] {
          };
          Object[] prmT000417;
          prmT000417 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000418;
          prmT000418 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000419;
          prmT000419 = new Object[] {
          new ParDef("@PaisCompraId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [EntradaId], [EspectaculoId], [SectorId], [PaisCompraId] AS PaisCompraId FROM [Entrada] WITH (UPDLOCK) WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [EntradaId], [EspectaculoId], [SectorId], [PaisCompraId] AS PaisCompraId FROM [Entrada] WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [EspectaculoNombre], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT [SectorNombre], [SectorPrecio], [SectorCapacidad] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT [PaisNombre] AS PaisCompraNombre FROM [Pais] WHERE [PaisId] = @PaisCompraId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00047", "SELECT TM1.[EntradaId], T2.[EspectaculoNombre], T2.[EspectaculoFecha], T3.[SectorNombre], T3.[SectorPrecio], T4.[PaisNombre] AS PaisCompraNombre, T3.[SectorCapacidad], TM1.[EspectaculoId], TM1.[SectorId], TM1.[PaisCompraId] AS PaisCompraId FROM ((([Entrada] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) INNER JOIN [EspectaculoSector] T3 ON T3.[EspectaculoId] = TM1.[EspectaculoId] AND T3.[SectorId] = TM1.[SectorId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = TM1.[PaisCompraId]) WHERE TM1.[EntradaId] = @EntradaId ORDER BY TM1.[EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT [EspectaculoNombre], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00049", "SELECT [SectorNombre], [SectorPrecio], [SectorCapacidad] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000410", "SELECT [PaisNombre] AS PaisCompraNombre FROM [Pais] WHERE [PaisId] = @PaisCompraId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000411", "SELECT [EntradaId] FROM [Entrada] WHERE [EntradaId] = @EntradaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000412", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE ( [EntradaId] > @EntradaId) ORDER BY [EntradaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000413", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE ( [EntradaId] < @EntradaId) ORDER BY [EntradaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000414", "INSERT INTO [Entrada]([EspectaculoId], [SectorId], [PaisCompraId]) VALUES(@EspectaculoId, @SectorId, @PaisCompraId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000415", "UPDATE [Entrada] SET [EspectaculoId]=@EspectaculoId, [SectorId]=@SectorId, [PaisCompraId]=@PaisCompraId  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmT000415)
             ,new CursorDef("T000416", "DELETE FROM [Entrada]  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmT000416)
             ,new CursorDef("T000417", "SELECT [EspectaculoNombre], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000418", "SELECT [SectorNombre], [SectorPrecio], [SectorCapacidad] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000419", "SELECT [PaisNombre] AS PaisCompraNombre FROM [Pais] WHERE [PaisId] = @PaisCompraId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000420", "SELECT [EntradaId] FROM [Entrada] ORDER BY [EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
