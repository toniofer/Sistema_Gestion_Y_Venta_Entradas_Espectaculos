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
   public class invitacion : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A5EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A5EspectaculoId) ;
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
               AV7InvitacionId = (short)(Math.Round(NumberUtil.Val( GetPar( "InvitacionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7InvitacionId", StringUtil.LTrimStr( (decimal)(AV7InvitacionId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINVITACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvitacionId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Invitacion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtInvitacionNombreInvitado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public invitacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public invitacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_InvitacionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7InvitacionId = aP1_InvitacionId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Invitacion", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Invitacion.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Invitacion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInvitacionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvitacionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtInvitacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17InvitacionId), 4, 0, ",", "")), StringUtil.LTrim( ((edtInvitacionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A17InvitacionId), "ZZZ9") : context.localUtil.Format( (decimal)(A17InvitacionId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvitacionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvitacionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInvitacionNombreInvitado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvitacionNombreInvitado_Internalname, "Nombre Invitado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvitacionNombreInvitado_Internalname, StringUtil.RTrim( A30InvitacionNombreInvitado), StringUtil.RTrim( context.localUtil.Format( A30InvitacionNombreInvitado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvitacionNombreInvitado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvitacionNombreInvitado_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Invitacion.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Invitacion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Invitacion.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEspectaculoNombre_Internalname, StringUtil.RTrim( A8EspectaculoNombre), StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Invitacion.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A19EspectaculoFecha, "99/99/99"), context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Invitacion.htm");
         GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Invitacion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoInvitacionesEntrega_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoInvitacionesEntrega_Internalname, "Espectaculo Invitaciones Entregadas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoInvitacionesEntrega_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoInvitacionesEntrega_Enabled!=0) ? context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9") : context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoInvitacionesEntrega_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoInvitacionesEntrega_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Invitacion.htm");
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
         GxWebStd.gx_label_element( context, edtEspectaculoInvitacionesDisponi_Internalname, "Espectaculo Invitaciones Disponibles", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoInvitacionesDisponi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoInvitacionesDisponi_Enabled!=0) ? context.localUtil.Format( (decimal)(A32EspectaculoInvitacionesDisponi), "ZZZ9") : context.localUtil.Format( (decimal)(A32EspectaculoInvitacionesDisponi), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoInvitacionesDisponi_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoInvitacionesDisponi_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Invitacion.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z17InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z17InvitacionId"), ",", "."), 18, MidpointRounding.ToEven));
               Z30InvitacionNombreInvitado = cgiGet( "Z30InvitacionNombreInvitado");
               Z5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z5EspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z8EspectaculoNombre = cgiGet( "Z8EspectaculoNombre");
               Z19EspectaculoFecha = context.localUtil.CToD( cgiGet( "Z19EspectaculoFecha"), 0);
               Z31EspectaculoCantidadInvitacione = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z31EspectaculoCantidadInvitacione"), ",", "."), 18, MidpointRounding.ToEven));
               A31EspectaculoCantidadInvitacione = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z31EspectaculoCantidadInvitacione"), ",", "."), 18, MidpointRounding.ToEven));
               O33EspectaculoInvitacionesEntrega = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O33EspectaculoInvitacionesEntrega"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N5EspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               A31EspectaculoCantidadInvitacione = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ESPECTACULOCANTIDADINVITACIONE"), ",", "."), 18, MidpointRounding.ToEven));
               AV7InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINVITACIONID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESPECTACULOID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A17InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvitacionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
               A30InvitacionNombreInvitado = cgiGet( edtInvitacionNombreInvitado_Internalname);
               AssignAttri("", false, "A30InvitacionNombreInvitado", A30InvitacionNombreInvitado);
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
               A33EspectaculoInvitacionesEntrega = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoInvitacionesEntrega_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
               A32EspectaculoInvitacionesDisponi = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoInvitacionesDisponi_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Invitacion");
               A17InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvitacionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
               forbiddenHiddens.Add("InvitacionId", context.localUtil.Format( (decimal)(A17InvitacionId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A17InvitacionId != Z17InvitacionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("invitacion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A17InvitacionId = (short)(Math.Round(NumberUtil.Val( GetPar( "InvitacionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "INVITACIONID");
                        AnyError = 1;
                        GX_FocusControl = edtInvitacionId_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll079( ) ;
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
            DisableAttributes079( ) ;
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
               CloseExtendedTableCursors079( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_EspectaculoId = 0;
         AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EspectaculoId") == 0 )
               {
                  AV11Insert_EspectaculoId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
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

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            context.PopUp(formatLink("aemitirinvitacion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A17InvitacionId,4,0))}, new string[] {"InvitacionId"}) , new Object[] {});
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwinvitacion.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM079( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z30InvitacionNombreInvitado = T00073_A30InvitacionNombreInvitado[0];
               Z5EspectaculoId = T00073_A5EspectaculoId[0];
            }
            else
            {
               Z30InvitacionNombreInvitado = A30InvitacionNombreInvitado;
               Z5EspectaculoId = A5EspectaculoId;
            }
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z8EspectaculoNombre = T00075_A8EspectaculoNombre[0];
            Z19EspectaculoFecha = T00075_A19EspectaculoFecha[0];
            Z31EspectaculoCantidadInvitacione = T00075_A31EspectaculoCantidadInvitacione[0];
         }
         if ( GX_JID == -15 )
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
         edtInvitacionId_Enabled = 0;
         AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesDisponi_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesDisponi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesDisponi_Enabled), 5, 0), true);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtInvitacionId_Enabled = 0;
         AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesDisponi_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesDisponi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesDisponi_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7InvitacionId) )
         {
            A17InvitacionId = AV7InvitacionId;
            AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
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
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            edtEspectaculoId_Enabled = 0;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A30InvitacionNombreInvitado)) && ( Gx_BScreen == 0 ) )
         {
            A30InvitacionNombreInvitado = "INVITACIÓN";
            AssignAttri("", false, "A30InvitacionNombreInvitado", A30InvitacionNombreInvitado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV15Pgmname = "Invitacion";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00075 */
            pr_default.execute(3, new Object[] {A5EspectaculoId});
            ZM079( 16) ;
            A33EspectaculoInvitacionesEntrega = T00075_A33EspectaculoInvitacionesEntrega[0];
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            A8EspectaculoNombre = T00075_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T00075_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            A31EspectaculoCantidadInvitacione = T00075_A31EspectaculoCantidadInvitacione[0];
            O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            pr_default.close(3);
         }
      }

      protected void Load079( )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A17InvitacionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A33EspectaculoInvitacionesEntrega = T00076_A33EspectaculoInvitacionesEntrega[0];
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            A30InvitacionNombreInvitado = T00076_A30InvitacionNombreInvitado[0];
            AssignAttri("", false, "A30InvitacionNombreInvitado", A30InvitacionNombreInvitado);
            A8EspectaculoNombre = T00076_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T00076_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            A31EspectaculoCantidadInvitacione = T00076_A31EspectaculoCantidadInvitacione[0];
            A5EspectaculoId = T00076_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            ZM079( -15) ;
         }
         pr_default.close(4);
         OnLoadActions079( ) ;
      }

      protected void OnLoadActions079( )
      {
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         AV15Pgmname = "Invitacion";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( IsIns( )  )
         {
            A33EspectaculoInvitacionesEntrega = (short)(O33EspectaculoInvitacionesEntrega+1);
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         }
         A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
         AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
      }

      protected void CheckExtendedTable079( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "Invitacion";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A33EspectaculoInvitacionesEntrega = T00075_A33EspectaculoInvitacionesEntrega[0];
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         A8EspectaculoNombre = T00075_A8EspectaculoNombre[0];
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = T00075_A19EspectaculoFecha[0];
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         A31EspectaculoCantidadInvitacione = T00075_A31EspectaculoCantidadInvitacione[0];
         nIsDirty_9 = 1;
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         pr_default.close(3);
         if ( IsIns( )  )
         {
            nIsDirty_9 = 1;
            A33EspectaculoInvitacionesEntrega = (short)(O33EspectaculoInvitacionesEntrega+1);
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         }
         nIsDirty_9 = 1;
         A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
         AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
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

      protected void gxLoad_16( short A5EspectaculoId )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A33EspectaculoInvitacionesEntrega = T00075_A33EspectaculoInvitacionesEntrega[0];
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         A8EspectaculoNombre = T00075_A8EspectaculoNombre[0];
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = T00075_A19EspectaculoFecha[0];
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         A31EspectaculoCantidadInvitacione = T00075_A31EspectaculoCantidadInvitacione[0];
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8EspectaculoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A19EspectaculoFecha, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(3) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(3);
      }

      protected void GetKey079( )
      {
         /* Using cursor T00077 */
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
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A17InvitacionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM079( 15) ;
            RcdFound9 = 1;
            A17InvitacionId = T00073_A17InvitacionId[0];
            AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
            A30InvitacionNombreInvitado = T00073_A30InvitacionNombreInvitado[0];
            AssignAttri("", false, "A30InvitacionNombreInvitado", A30InvitacionNombreInvitado);
            A5EspectaculoId = T00073_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            Z17InvitacionId = A17InvitacionId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load079( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey079( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey079( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey079( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A17InvitacionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00078_A17InvitacionId[0] < A17InvitacionId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00078_A17InvitacionId[0] > A17InvitacionId ) ) )
            {
               A17InvitacionId = T00078_A17InvitacionId[0];
               AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A17InvitacionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00079_A17InvitacionId[0] > A17InvitacionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00079_A17InvitacionId[0] < A17InvitacionId ) ) )
            {
               A17InvitacionId = T00079_A17InvitacionId[0];
               AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey079( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtInvitacionNombreInvitado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert079( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A17InvitacionId != Z17InvitacionId )
               {
                  A17InvitacionId = Z17InvitacionId;
                  AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INVITACIONID");
                  AnyError = 1;
                  GX_FocusControl = edtInvitacionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtInvitacionNombreInvitado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update079( ) ;
                  GX_FocusControl = edtInvitacionNombreInvitado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A17InvitacionId != Z17InvitacionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtInvitacionNombreInvitado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert079( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INVITACIONID");
                     AnyError = 1;
                     GX_FocusControl = edtInvitacionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtInvitacionNombreInvitado_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert079( ) ;
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
         if ( A17InvitacionId != Z17InvitacionId )
         {
            A17InvitacionId = Z17InvitacionId;
            AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INVITACIONID");
            AnyError = 1;
            GX_FocusControl = edtInvitacionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtInvitacionNombreInvitado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency079( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A17InvitacionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z30InvitacionNombreInvitado, T00072_A30InvitacionNombreInvitado[0]) != 0 ) || ( Z5EspectaculoId != T00072_A5EspectaculoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z30InvitacionNombreInvitado, T00072_A30InvitacionNombreInvitado[0]) != 0 )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"InvitacionNombreInvitado");
                  GXUtil.WriteLogRaw("Old: ",Z30InvitacionNombreInvitado);
                  GXUtil.WriteLogRaw("Current: ",T00072_A30InvitacionNombreInvitado[0]);
               }
               if ( Z5EspectaculoId != T00072_A5EspectaculoId[0] )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"EspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z5EspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A5EspectaculoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invitacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(8) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false || ( StringUtil.StrCmp(Z8EspectaculoNombre, T000710_A8EspectaculoNombre[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z19EspectaculoFecha ) != DateTimeUtil.ResetTime ( T000710_A19EspectaculoFecha[0] ) ) || ( Z31EspectaculoCantidadInvitacione != T000710_A31EspectaculoCantidadInvitacione[0] ) )
            {
               if ( StringUtil.StrCmp(Z8EspectaculoNombre, T000710_A8EspectaculoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"EspectaculoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z8EspectaculoNombre);
                  GXUtil.WriteLogRaw("Current: ",T000710_A8EspectaculoNombre[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z19EspectaculoFecha ) != DateTimeUtil.ResetTime ( T000710_A19EspectaculoFecha[0] ) )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"EspectaculoFecha");
                  GXUtil.WriteLogRaw("Old: ",Z19EspectaculoFecha);
                  GXUtil.WriteLogRaw("Current: ",T000710_A19EspectaculoFecha[0]);
               }
               if ( Z31EspectaculoCantidadInvitacione != T000710_A31EspectaculoCantidadInvitacione[0] )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"EspectaculoCantidadInvitacione");
                  GXUtil.WriteLogRaw("Old: ",Z31EspectaculoCantidadInvitacione);
                  GXUtil.WriteLogRaw("Current: ",T000710_A31EspectaculoCantidadInvitacione[0]);
               }
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
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {A30InvitacionNombreInvitado, A5EspectaculoId});
                     A17InvitacionId = T000711_A17InvitacionId[0];
                     AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
                     pr_default.close(9);
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
                           ResetCaption070( ) ;
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
                     /* Using cursor T000712 */
                     pr_default.execute(10, new Object[] {A30InvitacionNombreInvitado, A5EspectaculoId, A17InvitacionId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( (pr_default.getStatus(10) == 103) )
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
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void DeferredUpdate079( )
      {
      }

      protected void delete( )
      {
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
                  /* Using cursor T000713 */
                  pr_default.execute(11, new Object[] {A17InvitacionId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN1079( ) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel079( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls079( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "Invitacion";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000714 */
            pr_default.execute(12, new Object[] {A5EspectaculoId});
            Z8EspectaculoNombre = T000714_A8EspectaculoNombre[0];
            Z19EspectaculoFecha = T000714_A19EspectaculoFecha[0];
            Z31EspectaculoCantidadInvitacione = T000714_A31EspectaculoCantidadInvitacione[0];
            A33EspectaculoInvitacionesEntrega = T000714_A33EspectaculoInvitacionesEntrega[0];
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            A8EspectaculoNombre = T000714_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T000714_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            A31EspectaculoCantidadInvitacione = T000714_A31EspectaculoCantidadInvitacione[0];
            O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            pr_default.close(12);
            if ( IsIns( )  )
            {
               A33EspectaculoInvitacionesEntrega = (short)(O33EspectaculoInvitacionesEntrega+1);
               AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            }
            A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
            AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         }
      }

      protected void UpdateTablesN1079( )
      {
         /* Using cursor T000715 */
         pr_default.execute(13, new Object[] {A33EspectaculoInvitacionesEntrega, A5EspectaculoId});
         pr_default.close(13);
         pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
      }

      protected void EndLevel079( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(8);
         if ( AnyError == 0 )
         {
            BeforeComplete079( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("invitacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("invitacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart079( )
      {
         /* Scan By routine */
         /* Using cursor T000716 */
         pr_default.execute(14);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound9 = 1;
            A17InvitacionId = T000716_A17InvitacionId[0];
            AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext079( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound9 = 1;
            A17InvitacionId = T000716_A17InvitacionId[0];
            AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
         }
      }

      protected void ScanEnd079( )
      {
         pr_default.close(14);
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
         edtInvitacionId_Enabled = 0;
         AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), true);
         edtInvitacionNombreInvitado_Enabled = 0;
         AssignProp("", false, edtInvitacionNombreInvitado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionNombreInvitado_Enabled), 5, 0), true);
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtEspectaculoNombre_Enabled = 0;
         AssignProp("", false, edtEspectaculoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoNombre_Enabled), 5, 0), true);
         edtEspectaculoFecha_Enabled = 0;
         AssignProp("", false, edtEspectaculoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFecha_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesEntrega_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesDisponi_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesDisponi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesDisponi_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes079( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("invitacion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvitacionId,4,0))}, new string[] {"Gx_mode","InvitacionId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Invitacion");
         forbiddenHiddens.Add("InvitacionId", context.localUtil.Format( (decimal)(A17InvitacionId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("invitacion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z17InvitacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17InvitacionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z30InvitacionNombreInvitado", StringUtil.RTrim( Z30InvitacionNombreInvitado));
         GxWebStd.gx_hidden_field( context, "Z5EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z8EspectaculoNombre", StringUtil.RTrim( Z8EspectaculoNombre));
         GxWebStd.gx_hidden_field( context, "Z19EspectaculoFecha", context.localUtil.DToC( Z19EspectaculoFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z31EspectaculoCantidadInvitacione", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31EspectaculoCantidadInvitacione), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O33EspectaculoInvitacionesEntrega", StringUtil.LTrim( StringUtil.NToC( (decimal)(O33EspectaculoInvitacionesEntrega), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N5EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "ESPECTACULOCANTIDADINVITACIONE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINVITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InvitacionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINVITACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvitacionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         return formatLink("invitacion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvitacionId,4,0))}, new string[] {"Gx_mode","InvitacionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Invitacion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Invitacion" ;
      }

      protected void InitializeNonKey079( )
      {
         A5EspectaculoId = 0;
         AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
         A33EspectaculoInvitacionesEntrega = 0;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         A32EspectaculoInvitacionesDisponi = 0;
         AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrimStr( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0));
         A8EspectaculoNombre = "";
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = DateTime.MinValue;
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         A31EspectaculoCantidadInvitacione = 0;
         AssignAttri("", false, "A31EspectaculoCantidadInvitacione", StringUtil.LTrimStr( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0));
         A30InvitacionNombreInvitado = "INVITACIÓN";
         AssignAttri("", false, "A30InvitacionNombreInvitado", A30InvitacionNombreInvitado);
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         Z30InvitacionNombreInvitado = "";
         Z5EspectaculoId = 0;
         Z8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
         Z31EspectaculoCantidadInvitacione = 0;
      }

      protected void InitAll079( )
      {
         A17InvitacionId = 0;
         AssignAttri("", false, "A17InvitacionId", StringUtil.LTrimStr( (decimal)(A17InvitacionId), 4, 0));
         InitializeNonKey079( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A30InvitacionNombreInvitado = i30InvitacionNombreInvitado;
         AssignAttri("", false, "A30InvitacionNombreInvitado", A30InvitacionNombreInvitado);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874412450", true, true);
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
         context.AddJavascriptSource("invitacion.js", "?2023874412450", false, true);
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
         edtInvitacionId_Internalname = "INVITACIONID";
         edtInvitacionNombreInvitado_Internalname = "INVITACIONNOMBREINVITADO";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoNombre_Internalname = "ESPECTACULONOMBRE";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtEspectaculoInvitacionesEntrega_Internalname = "ESPECTACULOINVITACIONESENTREGA";
         edtEspectaculoInvitacionesDisponi_Internalname = "ESPECTACULOINVITACIONESDISPONI";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
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
         Form.Caption = "Invitacion";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtEspectaculoInvitacionesDisponi_Jsonclick = "";
         edtEspectaculoInvitacionesDisponi_Enabled = 0;
         edtEspectaculoInvitacionesEntrega_Jsonclick = "";
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 0;
         edtEspectaculoNombre_Jsonclick = "";
         edtEspectaculoNombre_Enabled = 0;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 1;
         edtInvitacionNombreInvitado_Jsonclick = "";
         edtInvitacionNombreInvitado_Enabled = 1;
         edtInvitacionId_Jsonclick = "";
         edtInvitacionId_Enabled = 0;
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
         /* Using cursor T000714 */
         pr_default.execute(12, new Object[] {A5EspectaculoId});
         Z8EspectaculoNombre = T000714_A8EspectaculoNombre[0];
         Z19EspectaculoFecha = T000714_A19EspectaculoFecha[0];
         Z31EspectaculoCantidadInvitacione = T000714_A31EspectaculoCantidadInvitacione[0];
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         A33EspectaculoInvitacionesEntrega = T000714_A33EspectaculoInvitacionesEntrega[0];
         A8EspectaculoNombre = T000714_A8EspectaculoNombre[0];
         A19EspectaculoFecha = T000714_A19EspectaculoFecha[0];
         A31EspectaculoCantidadInvitacione = T000714_A31EspectaculoCantidadInvitacione[0];
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         pr_default.close(12);
         if ( IsIns( )  )
         {
            A33EspectaculoInvitacionesEntrega = (short)(O33EspectaculoInvitacionesEntrega+1);
         }
         if ( DateTimeUtil.ResetTime ( A19EspectaculoFecha ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("La fecha del espectáculo es anterior a la fecha actual", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         A32EspectaculoInvitacionesDisponi = (short)(A31EspectaculoCantidadInvitacione-A33EspectaculoInvitacionesEntrega);
         if ( A32EspectaculoInvitacionesDisponi < 0 )
         {
            GX_msglist.addItem("No hay más invitaciones disponibles para este espectáculo", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "O33EspectaculoInvitacionesEntrega", StringUtil.LTrim( StringUtil.NToC( (decimal)(O33EspectaculoInvitacionesEntrega), 4, 0, ",", "")));
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0, ".", "")));
         AssignAttri("", false, "A8EspectaculoNombre", StringUtil.RTrim( A8EspectaculoNombre));
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         AssignAttri("", false, "A31EspectaculoCantidadInvitacione", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoCantidadInvitacione), 4, 0, ".", "")));
         AssignAttri("", false, "A32EspectaculoInvitacionesDisponi", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32EspectaculoInvitacionesDisponi), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7InvitacionId',fld:'vINVITACIONID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7InvitacionId',fld:'vINVITACIONID',pic:'ZZZ9',hsh:true},{av:'A17InvitacionId',fld:'INVITACIONID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A17InvitacionId',fld:'INVITACIONID',pic:'ZZZ9'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_INVITACIONID","{handler:'Valid_Invitacionid',iparms:[]");
         setEventMetadata("VALID_INVITACIONID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'O33EspectaculoInvitacionesEntrega'},{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A33EspectaculoInvitacionesEntrega',fld:'ESPECTACULOINVITACIONESENTREGA',pic:'ZZZ9'},{av:'A19EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''},{av:'Gx_date',fld:'vTODAY',pic:''},{av:'A31EspectaculoCantidadInvitacione',fld:'ESPECTACULOCANTIDADINVITACIONE',pic:'ZZZ9'},{av:'A32EspectaculoInvitacionesDisponi',fld:'ESPECTACULOINVITACIONESDISPONI',pic:'ZZZ9'},{av:'A8EspectaculoNombre',fld:'ESPECTACULONOMBRE',pic:''}]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[{av:'O33EspectaculoInvitacionesEntrega'},{av:'A33EspectaculoInvitacionesEntrega',fld:'ESPECTACULOINVITACIONESENTREGA',pic:'ZZZ9'},{av:'A8EspectaculoNombre',fld:'ESPECTACULONOMBRE',pic:''},{av:'A19EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''},{av:'A31EspectaculoCantidadInvitacione',fld:'ESPECTACULOCANTIDADINVITACIONE',pic:'ZZZ9'},{av:'A32EspectaculoInvitacionesDisponi',fld:'ESPECTACULOINVITACIONESDISPONI',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_ESPECTACULOFECHA","{handler:'Valid_Espectaculofecha',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFECHA",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOINVITACIONESENTREGA","{handler:'Valid_Espectaculoinvitacionesentrega',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOINVITACIONESENTREGA",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOINVITACIONESDISPONI","{handler:'Valid_Espectaculoinvitacionesdisponi',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOINVITACIONESDISPONI",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z30InvitacionNombreInvitado = "";
         Z8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
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
         A30InvitacionNombreInvitado = "";
         imgprompt_5_gximage = "";
         sImgUrl = "";
         A8EspectaculoNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         T00075_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T00075_A8EspectaculoNombre = new string[] {""} ;
         T00075_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00075_A31EspectaculoCantidadInvitacione = new short[1] ;
         T00076_A17InvitacionId = new short[1] ;
         T00076_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T00076_A30InvitacionNombreInvitado = new string[] {""} ;
         T00076_A8EspectaculoNombre = new string[] {""} ;
         T00076_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00076_A31EspectaculoCantidadInvitacione = new short[1] ;
         T00076_A5EspectaculoId = new short[1] ;
         T00077_A17InvitacionId = new short[1] ;
         T00073_A17InvitacionId = new short[1] ;
         T00073_A30InvitacionNombreInvitado = new string[] {""} ;
         T00073_A5EspectaculoId = new short[1] ;
         T00078_A17InvitacionId = new short[1] ;
         T00079_A17InvitacionId = new short[1] ;
         T00072_A17InvitacionId = new short[1] ;
         T00072_A30InvitacionNombreInvitado = new string[] {""} ;
         T00072_A5EspectaculoId = new short[1] ;
         T000710_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T000710_A8EspectaculoNombre = new string[] {""} ;
         T000710_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000710_A31EspectaculoCantidadInvitacione = new short[1] ;
         T000711_A17InvitacionId = new short[1] ;
         T000714_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T000714_A8EspectaculoNombre = new string[] {""} ;
         T000714_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000714_A31EspectaculoCantidadInvitacione = new short[1] ;
         T000716_A17InvitacionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i30InvitacionNombreInvitado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invitacion__default(),
            new Object[][] {
                new Object[] {
               T00072_A17InvitacionId, T00072_A30InvitacionNombreInvitado, T00072_A5EspectaculoId
               }
               , new Object[] {
               T00073_A17InvitacionId, T00073_A30InvitacionNombreInvitado, T00073_A5EspectaculoId
               }
               , new Object[] {
               T00074_A33EspectaculoInvitacionesEntrega, T00074_A8EspectaculoNombre, T00074_A19EspectaculoFecha, T00074_A31EspectaculoCantidadInvitacione
               }
               , new Object[] {
               T00075_A33EspectaculoInvitacionesEntrega, T00075_A8EspectaculoNombre, T00075_A19EspectaculoFecha, T00075_A31EspectaculoCantidadInvitacione
               }
               , new Object[] {
               T00076_A17InvitacionId, T00076_A33EspectaculoInvitacionesEntrega, T00076_A30InvitacionNombreInvitado, T00076_A8EspectaculoNombre, T00076_A19EspectaculoFecha, T00076_A31EspectaculoCantidadInvitacione, T00076_A5EspectaculoId
               }
               , new Object[] {
               T00077_A17InvitacionId
               }
               , new Object[] {
               T00078_A17InvitacionId
               }
               , new Object[] {
               T00079_A17InvitacionId
               }
               , new Object[] {
               T000710_A33EspectaculoInvitacionesEntrega, T000710_A8EspectaculoNombre, T000710_A19EspectaculoFecha, T000710_A31EspectaculoCantidadInvitacione
               }
               , new Object[] {
               T000711_A17InvitacionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000714_A33EspectaculoInvitacionesEntrega, T000714_A8EspectaculoNombre, T000714_A19EspectaculoFecha, T000714_A31EspectaculoCantidadInvitacione
               }
               , new Object[] {
               }
               , new Object[] {
               T000716_A17InvitacionId
               }
            }
         );
         AV15Pgmname = "Invitacion";
         Gx_date = DateTimeUtil.Today( context);
         Z30InvitacionNombreInvitado = "INVITACIÓN";
         A30InvitacionNombreInvitado = "INVITACIÓN";
         i30InvitacionNombreInvitado = "INVITACIÓN";
      }

      private short wcpOAV7InvitacionId ;
      private short Z17InvitacionId ;
      private short Z5EspectaculoId ;
      private short Z31EspectaculoCantidadInvitacione ;
      private short O33EspectaculoInvitacionesEntrega ;
      private short N5EspectaculoId ;
      private short GxWebError ;
      private short A5EspectaculoId ;
      private short AV7InvitacionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A17InvitacionId ;
      private short A33EspectaculoInvitacionesEntrega ;
      private short A32EspectaculoInvitacionesDisponi ;
      private short A31EspectaculoCantidadInvitacione ;
      private short AV11Insert_EspectaculoId ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Z33EspectaculoInvitacionesEntrega ;
      private short nIsDirty_9 ;
      private short gxajaxcallmode ;
      private short ZO33EspectaculoInvitacionesEntrega ;
      private short Z32EspectaculoInvitacionesDisponi ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtInvitacionId_Enabled ;
      private int edtInvitacionNombreInvitado_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtEspectaculoNombre_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtEspectaculoInvitacionesEntrega_Enabled ;
      private int edtEspectaculoInvitacionesDisponi_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV16GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z30InvitacionNombreInvitado ;
      private string Z8EspectaculoNombre ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtInvitacionNombreInvitado_Internalname ;
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
      private string edtInvitacionId_Internalname ;
      private string edtInvitacionId_Jsonclick ;
      private string A30InvitacionNombreInvitado ;
      private string edtInvitacionNombreInvitado_Jsonclick ;
      private string edtEspectaculoId_Internalname ;
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
      private string edtEspectaculoInvitacionesEntrega_Internalname ;
      private string edtEspectaculoInvitacionesEntrega_Jsonclick ;
      private string edtEspectaculoInvitacionesDisponi_Internalname ;
      private string edtEspectaculoInvitacionesDisponi_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i30InvitacionNombreInvitado ;
      private DateTime Z19EspectaculoFecha ;
      private DateTime A19EspectaculoFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00075_A33EspectaculoInvitacionesEntrega ;
      private string[] T00075_A8EspectaculoNombre ;
      private DateTime[] T00075_A19EspectaculoFecha ;
      private short[] T00075_A31EspectaculoCantidadInvitacione ;
      private short[] T00076_A17InvitacionId ;
      private short[] T00076_A33EspectaculoInvitacionesEntrega ;
      private string[] T00076_A30InvitacionNombreInvitado ;
      private string[] T00076_A8EspectaculoNombre ;
      private DateTime[] T00076_A19EspectaculoFecha ;
      private short[] T00076_A31EspectaculoCantidadInvitacione ;
      private short[] T00076_A5EspectaculoId ;
      private short[] T00077_A17InvitacionId ;
      private short[] T00073_A17InvitacionId ;
      private string[] T00073_A30InvitacionNombreInvitado ;
      private short[] T00073_A5EspectaculoId ;
      private short[] T00078_A17InvitacionId ;
      private short[] T00079_A17InvitacionId ;
      private short[] T00072_A17InvitacionId ;
      private string[] T00072_A30InvitacionNombreInvitado ;
      private short[] T00072_A5EspectaculoId ;
      private short[] T000710_A33EspectaculoInvitacionesEntrega ;
      private string[] T000710_A8EspectaculoNombre ;
      private DateTime[] T000710_A19EspectaculoFecha ;
      private short[] T000710_A31EspectaculoCantidadInvitacione ;
      private short[] T000711_A17InvitacionId ;
      private short[] T000714_A33EspectaculoInvitacionesEntrega ;
      private string[] T000714_A8EspectaculoNombre ;
      private DateTime[] T000714_A19EspectaculoFecha ;
      private short[] T000714_A31EspectaculoCantidadInvitacione ;
      private short[] T000716_A17InvitacionId ;
      private short[] T00074_A33EspectaculoInvitacionesEntrega ;
      private string[] T00074_A8EspectaculoNombre ;
      private DateTime[] T00074_A19EspectaculoFecha ;
      private short[] T00074_A31EspectaculoCantidadInvitacione ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class invitacion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@InvitacionNombreInvitado",GXType.NChar,60,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@InvitacionNombreInvitado",GXType.NChar,60,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          new ParDef("@EspectaculoInvitacionesEntrega",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000716;
          prmT000716 = new Object[] {
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [InvitacionId], [InvitacionNombreInvitado], [EspectaculoId] FROM [Invitacion] WITH (UPDLOCK) WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [InvitacionId], [InvitacionNombreInvitado], [EspectaculoId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoCantidadInvitacione] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoCantidadInvitacione] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT TM1.[InvitacionId], T2.[EspectaculoInvitacionesEntrega], TM1.[InvitacionNombreInvitado], T2.[EspectaculoNombre], T2.[EspectaculoFecha], T2.[EspectaculoCantidadInvitacione], TM1.[EspectaculoId] FROM ([Invitacion] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) WHERE TM1.[InvitacionId] = @InvitacionId ORDER BY TM1.[InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT [InvitacionId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE ( [InvitacionId] > @InvitacionId) ORDER BY [InvitacionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00079", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE ( [InvitacionId] < @InvitacionId) ORDER BY [InvitacionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000710", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoCantidadInvitacione] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000711", "INSERT INTO [Invitacion]([InvitacionNombreInvitado], [EspectaculoId]) VALUES(@InvitacionNombreInvitado, @EspectaculoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000712", "UPDATE [Invitacion] SET [InvitacionNombreInvitado]=@InvitacionNombreInvitado, [EspectaculoId]=@EspectaculoId  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmT000712)
             ,new CursorDef("T000713", "DELETE FROM [Invitacion]  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmT000713)
             ,new CursorDef("T000714", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha], [EspectaculoCantidadInvitacione] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000715", "UPDATE [Espectaculo] SET [EspectaculoInvitacionesEntrega]=@EspectaculoInvitacionesEntrega  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000715)
             ,new CursorDef("T000716", "SELECT [InvitacionId] FROM [Invitacion] ORDER BY [InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
