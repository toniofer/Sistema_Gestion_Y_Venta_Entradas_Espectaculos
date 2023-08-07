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
   public class pase : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A5EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A5EspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A5EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A9SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
            n9SectorId = false;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A5EspectaculoId, A9SectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A15PaisCompraPaseId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisCompraPaseId"), "."), 18, MidpointRounding.ToEven));
            n15PaisCompraPaseId = false;
            AssignAttri("", false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A15PaisCompraPaseId) ;
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
               AV17PaseId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaseId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17PaseId", StringUtil.LTrimStr( (decimal)(AV17PaseId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPASEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17PaseId), "ZZZ9"), context));
               AV19PaseTipo = GetPar( "PaseTipo");
               AssignAttri("", false, "AV19PaseTipo", AV19PaseTipo);
               GxWebStd.gx_hidden_field( context, "gxhash_vPASETIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19PaseTipo, "")), context));
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
            Form.Meta.addItem("description", "Pase", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaseId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public pase( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public pase( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_PaseId ,
                           string aP2_PaseTipo )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV17PaseId = aP1_PaseId;
         this.AV19PaseTipo = aP2_PaseTipo;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbPaseTipo = new GXCombobox();
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
         if ( cmbPaseTipo.ItemCount > 0 )
         {
            A14PaseTipo = cmbPaseTipo.getValidValue(A14PaseTipo);
            AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPaseTipo.CurrentValue = StringUtil.RTrim( A14PaseTipo);
            AssignProp("", false, cmbPaseTipo_Internalname, "Values", cmbPaseTipo.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Pase", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Pase.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Pase.htm");
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
         GxWebStd.gx_div_start( context, "", edtPaseId_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaseId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaseId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaseId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PaseId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A13PaseId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaseId_Jsonclick, 0, "Attribute", "", "", "", "", edtPaseId_Visible, edtPaseId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPaseTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPaseTipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPaseTipo, cmbPaseTipo_Internalname, StringUtil.RTrim( A14PaseTipo), 1, cmbPaseTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbPaseTipo.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Pase.htm");
         cmbPaseTipo.CurrentValue = StringUtil.RTrim( A14PaseTipo);
         AssignProp("", false, cmbPaseTipo_Internalname, "Values", (string)(cmbPaseTipo.ToJavascriptSource()), true);
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
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Pase.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Pase.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEspectaculoNombre_Internalname, StringUtil.RTrim( A8EspectaculoNombre), StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Pase.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A19EspectaculoFecha, "99/99/99"), context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Pase.htm");
         GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Pase.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Pase.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_9_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_9_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Pase.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSectorNombre_Internalname, StringUtil.RTrim( A21SectorNombre), StringUtil.RTrim( context.localUtil.Format( A21SectorNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Pase.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ",", "")), StringUtil.LTrim( ((edtSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9") : context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorPrecio_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisCompraPaseId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisCompraPaseId_Internalname, "Pase Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisCompraPaseId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15PaisCompraPaseId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15PaisCompraPaseId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisCompraPaseId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisCompraPaseId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Pase.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisCompraPaseNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisCompraPaseNombre_Internalname, "Pase Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisCompraPaseNombre_Internalname, StringUtil.RTrim( A35PaisCompraPaseNombre), StringUtil.RTrim( context.localUtil.Format( A35PaisCompraPaseNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisCompraPaseNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisCompraPaseNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNombreInvitado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNombreInvitado_Internalname, "Invitado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNombreInvitado_Internalname, StringUtil.RTrim( A34NombreInvitado), StringUtil.RTrim( context.localUtil.Format( A34NombreInvitado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNombreInvitado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNombreInvitado_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Pase.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEspectaculoInvitacionesEntrega_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoInvitacionesEntrega_Enabled!=0) ? context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9") : context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoInvitacionesEntrega_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoInvitacionesEntrega_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Pase.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pase.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pase.htm");
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
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z13PaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z13PaseId"), ",", "."), 18, MidpointRounding.ToEven));
               Z14PaseTipo = cgiGet( "Z14PaseTipo");
               Z34NombreInvitado = cgiGet( "Z34NombreInvitado");
               Z5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z5EspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z9SectorId"), ",", "."), 18, MidpointRounding.ToEven));
               Z15PaisCompraPaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z15PaisCompraPaseId"), ",", "."), 18, MidpointRounding.ToEven));
               O33EspectaculoInvitacionesEntrega = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O33EspectaculoInvitacionesEntrega"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N5EspectaculoId"), ",", "."), 18, MidpointRounding.ToEven));
               N9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N9SectorId"), ",", "."), 18, MidpointRounding.ToEven));
               N15PaisCompraPaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N15PaisCompraPaseId"), ",", "."), 18, MidpointRounding.ToEven));
               AV17PaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPASEID"), ",", "."), 18, MidpointRounding.ToEven));
               AV19PaseTipo = cgiGet( "vPASETIPO");
               AV10Insert_EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESPECTACULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV15Insert_SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECTORID"), ",", "."), 18, MidpointRounding.ToEven));
               AV18Insert_PaisCompraPaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PAISCOMPRAPASEID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               AV21Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaseId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaseId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PASEID");
                  AnyError = 1;
                  GX_FocusControl = edtPaseId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13PaseId = 0;
                  AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
               }
               else
               {
                  A13PaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPaseId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
               }
               cmbPaseTipo.CurrentValue = cgiGet( cmbPaseTipo_Internalname);
               A14PaseTipo = cgiGet( cmbPaseTipo_Internalname);
               AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
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
                  n9SectorId = false;
                  AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
               }
               else
               {
                  A9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n9SectorId = false;
                  AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
               }
               A21SectorNombre = cgiGet( edtSectorNombre_Internalname);
               AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
               A23SectorPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisCompraPaseId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisCompraPaseId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISCOMPRAPASEID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisCompraPaseId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15PaisCompraPaseId = 0;
                  n15PaisCompraPaseId = false;
                  AssignAttri("", false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
               }
               else
               {
                  A15PaisCompraPaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisCompraPaseId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n15PaisCompraPaseId = false;
                  AssignAttri("", false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
               }
               A35PaisCompraPaseNombre = cgiGet( edtPaisCompraPaseNombre_Internalname);
               AssignAttri("", false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
               A34NombreInvitado = cgiGet( edtNombreInvitado_Internalname);
               n34NombreInvitado = false;
               AssignAttri("", false, "A34NombreInvitado", A34NombreInvitado);
               A33EspectaculoInvitacionesEntrega = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoInvitacionesEntrega_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Pase");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A13PaseId != Z13PaseId ) || ( StringUtil.StrCmp(A14PaseTipo, Z14PaseTipo) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("pase:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A13PaseId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaseId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
                  A14PaseTipo = GetPar( "PaseTipo");
                  AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PASEID");
                        AnyError = 1;
                        GX_FocusControl = edtPaseId_Internalname;
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
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "INSERT") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Insert */
                           E13052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "UPDATE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Update */
                           E14052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_delete( ) ;
                           }
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll057( ) ;
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
            DisableAttributes057( ) ;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate057( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls057( ) ;
            }
            else
            {
               CheckExtendedTable057( ) ;
               CloseExtendedTableCursors057( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV21Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
         AV10Insert_EspectaculoId = 0;
         AssignAttri("", false, "AV10Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV10Insert_EspectaculoId), 4, 0));
         AV15Insert_SectorId = 0;
         AssignAttri("", false, "AV15Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV15Insert_SectorId), 4, 0));
         AV18Insert_PaisCompraPaseId = 0;
         AssignAttri("", false, "AV18Insert_PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(AV18Insert_PaisCompraPaseId), 4, 0));
         if ( ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            AssignAttri("", false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            while ( AV22GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV11TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "EspectaculoId") == 0 )
               {
                  AV10Insert_EspectaculoId = (short)(Math.Round(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV10Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV10Insert_EspectaculoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "SectorId") == 0 )
               {
                  AV15Insert_SectorId = (short)(Math.Round(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV15Insert_SectorId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "PaisCompraPaseId") == 0 )
               {
                  AV18Insert_PaisCompraPaseId = (short)(Math.Round(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV18Insert_PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(AV18Insert_PaisCompraPaseId), 4, 0));
               }
               AV22GXV1 = (int)(AV22GXV1+1);
               AssignAttri("", false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
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

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV8TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpase.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E13052( )
      {
         /* Insert Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A14PaseTipo, "Invitacion") == 0 )
         {
            AV12Invitacion = new SdtInvitacion(context);
            AV12Invitacion.gxTpr_Espectaculoid = A5EspectaculoId;
            AV12Invitacion.gxTpr_Invitacionnombreinvitado = A34NombreInvitado;
            AV12Invitacion.Insert();
            AV14Messages = AV12Invitacion.GetMessages();
         }
         else
         {
            AV13Entrada = new SdtEntrada(context);
            AV13Entrada.gxTpr_Espectaculoid = A5EspectaculoId;
            AV13Entrada.gxTpr_Sectorid = A9SectorId;
            AV13Entrada.gxTpr_Paiscompraid = A15PaisCompraPaseId;
            AV13Entrada.Insert();
            AV14Messages = AV13Entrada.GetMessages();
         }
         context.GX_msglist.Append(AV14Messages);
         AnyError = context.GX_msglist.AnyError();
      }

      protected void E14052( )
      {
         /* Update Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A14PaseTipo, "Invitacion") == 0 )
         {
            AV12Invitacion.Load(A13PaseId);
            AV12Invitacion.gxTpr_Invitacionnombreinvitado = A34NombreInvitado;
            AV12Invitacion.Update();
            AV14Messages = AV12Invitacion.GetMessages();
         }
         else
         {
            AV13Entrada.Load(A13PaseId);
            AV13Entrada.gxTpr_Paiscompraid = A15PaisCompraPaseId;
            AV13Entrada.Update();
            AV14Messages = AV12Invitacion.GetMessages();
         }
         context.GX_msglist.Append(AV14Messages);
         AnyError = context.GX_msglist.AnyError();
      }

      protected void E15052( )
      {
         /* Delete Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A14PaseTipo, "Invitacion") == 0 )
         {
            AV12Invitacion.Load(A13PaseId);
            AV12Invitacion.Delete();
            AV14Messages = AV12Invitacion.GetMessages();
         }
         else
         {
            AV13Entrada.Load(A13PaseId);
            AV13Entrada.Delete();
            AV14Messages = AV13Entrada.GetMessages();
         }
         context.GX_msglist.Append(AV14Messages);
         AnyError = context.GX_msglist.AnyError();
      }

      protected void ZM057( short GX_JID )
      {
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z34NombreInvitado = T00053_A34NombreInvitado[0];
               Z5EspectaculoId = T00053_A5EspectaculoId[0];
               Z9SectorId = T00053_A9SectorId[0];
               Z15PaisCompraPaseId = T00053_A15PaisCompraPaseId[0];
            }
            else
            {
               Z34NombreInvitado = A34NombreInvitado;
               Z5EspectaculoId = A5EspectaculoId;
               Z9SectorId = A9SectorId;
               Z15PaisCompraPaseId = A15PaisCompraPaseId;
            }
         }
         if ( GX_JID == -30 )
         {
            Z13PaseId = A13PaseId;
            Z14PaseTipo = A14PaseTipo;
            Z34NombreInvitado = A34NombreInvitado;
            Z5EspectaculoId = A5EspectaculoId;
            Z9SectorId = A9SectorId;
            Z15PaisCompraPaseId = A15PaisCompraPaseId;
            Z33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
            Z8EspectaculoNombre = A8EspectaculoNombre;
            Z19EspectaculoFecha = A19EspectaculoFecha;
            Z21SectorNombre = A21SectorNombre;
            Z23SectorPrecio = A23SectorPrecio;
            Z35PaisCompraPaseNombre = A35PaisCompraPaseNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            edtPaseId_Visible = 0;
            AssignProp("", false, edtPaseId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaseId_Visible), 5, 0), true);
         }
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0041.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"SECTORID"+"'), id:'"+"SECTORID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISCOMPRAPASEID"+"'), id:'"+"PAISCOMPRAPASEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV17PaseId) )
         {
            A13PaseId = AV17PaseId;
            AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
         }
         if ( ! (0==AV17PaseId) )
         {
            edtPaseId_Enabled = 0;
            AssignProp("", false, edtPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaseId_Enabled), 5, 0), true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               edtPaseId_Enabled = 0;
               AssignProp("", false, edtPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaseId_Enabled), 5, 0), true);
            }
            else
            {
               edtPaseId_Enabled = 1;
               AssignProp("", false, edtPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaseId_Enabled), 5, 0), true);
            }
         }
         if ( ! (0==AV17PaseId) )
         {
            edtPaseId_Enabled = 0;
            AssignProp("", false, edtPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaseId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PaseTipo)) )
         {
            A14PaseTipo = AV19PaseTipo;
            AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PaseTipo)) )
         {
            cmbPaseTipo.Enabled = 0;
            AssignProp("", false, cmbPaseTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPaseTipo.Enabled), 5, 0), true);
         }
         else
         {
            cmbPaseTipo.Enabled = 1;
            AssignProp("", false, cmbPaseTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPaseTipo.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(AV19PaseTipo, "Entrada") == 0 ) )
         {
            edtNombreInvitado_Enabled = 0;
            AssignProp("", false, edtNombreInvitado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNombreInvitado_Enabled), 5, 0), true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( StringUtil.StrCmp(AV19PaseTipo, "Entrada") == 0 ) )
            {
               edtNombreInvitado_Enabled = 0;
               AssignProp("", false, edtNombreInvitado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNombreInvitado_Enabled), 5, 0), true);
            }
            else
            {
               edtNombreInvitado_Enabled = 1;
               AssignProp("", false, edtNombreInvitado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNombreInvitado_Enabled), 5, 0), true);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PaseTipo)) )
         {
            cmbPaseTipo.Enabled = 0;
            AssignProp("", false, cmbPaseTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPaseTipo.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV10Insert_EspectaculoId) )
         {
            edtEspectaculoId_Enabled = 0;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_SectorId) )
         {
            edtSectorId_Enabled = 0;
            AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               edtSectorId_Enabled = 0;
               AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
            }
            else
            {
               edtSectorId_Enabled = 1;
               AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_PaisCompraPaseId) )
         {
            edtPaisCompraPaseId_Enabled = 0;
            AssignProp("", false, edtPaisCompraPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraPaseId_Enabled), 5, 0), true);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(AV19PaseTipo, "Invitacion") == 0 ) )
            {
               edtPaisCompraPaseId_Enabled = 0;
               AssignProp("", false, edtPaisCompraPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraPaseId_Enabled), 5, 0), true);
            }
            else
            {
               edtPaisCompraPaseId_Enabled = 1;
               AssignProp("", false, edtPaisCompraPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraPaseId_Enabled), 5, 0), true);
            }
         }
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            edtEspectaculoId_Enabled = 0;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_PaisCompraPaseId) )
         {
            A15PaisCompraPaseId = AV18Insert_PaisCompraPaseId;
            n15PaisCompraPaseId = false;
            AssignAttri("", false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_SectorId) )
         {
            A9SectorId = AV15Insert_SectorId;
            n9SectorId = false;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV10Insert_EspectaculoId) )
         {
            A5EspectaculoId = AV10Insert_EspectaculoId;
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtEspectaculoId_Enabled = 0;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtSectorId_Enabled = 0;
            AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(AV19PaseTipo, "Entrada") == 0 ) )
         {
            edtNombreInvitado_Enabled = 0;
            AssignProp("", false, edtNombreInvitado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNombreInvitado_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( StringUtil.StrCmp(AV19PaseTipo, "Entrada") == 0 ) )
         {
            edtNombreInvitado_Enabled = 0;
            AssignProp("", false, edtNombreInvitado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNombreInvitado_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(AV19PaseTipo, "Invitacion") == 0 ) )
         {
            edtPaisCompraPaseId_Enabled = 0;
            AssignProp("", false, edtPaisCompraPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraPaseId_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            edtPaseId_Enabled = 0;
            AssignProp("", false, edtPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaseId_Enabled), 5, 0), true);
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
            AV21Pgmname = "Pase";
            AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
            /* Using cursor T00056 */
            pr_default.execute(4, new Object[] {n15PaisCompraPaseId, A15PaisCompraPaseId});
            A35PaisCompraPaseNombre = T00056_A35PaisCompraPaseNombre[0];
            AssignAttri("", false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
            pr_default.close(4);
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A5EspectaculoId});
            A33EspectaculoInvitacionesEntrega = T00054_A33EspectaculoInvitacionesEntrega[0];
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            A8EspectaculoNombre = T00054_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T00054_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            pr_default.close(2);
            /* Using cursor T00055 */
            pr_default.execute(3, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
            A21SectorNombre = T00055_A21SectorNombre[0];
            AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
            A23SectorPrecio = T00055_A23SectorPrecio[0];
            AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
            pr_default.close(3);
         }
      }

      protected void Load057( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A13PaseId, A14PaseTipo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
            A33EspectaculoInvitacionesEntrega = T00057_A33EspectaculoInvitacionesEntrega[0];
            AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            A8EspectaculoNombre = T00057_A8EspectaculoNombre[0];
            AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = T00057_A19EspectaculoFecha[0];
            AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            A21SectorNombre = T00057_A21SectorNombre[0];
            AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
            A23SectorPrecio = T00057_A23SectorPrecio[0];
            AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
            A35PaisCompraPaseNombre = T00057_A35PaisCompraPaseNombre[0];
            AssignAttri("", false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
            A34NombreInvitado = T00057_A34NombreInvitado[0];
            n34NombreInvitado = T00057_n34NombreInvitado[0];
            AssignAttri("", false, "A34NombreInvitado", A34NombreInvitado);
            A5EspectaculoId = T00057_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A9SectorId = T00057_A9SectorId[0];
            n9SectorId = T00057_n9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
            A15PaisCompraPaseId = T00057_A15PaisCompraPaseId[0];
            n15PaisCompraPaseId = T00057_n15PaisCompraPaseId[0];
            AssignAttri("", false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
            ZM057( -30) ;
         }
         pr_default.close(5);
         OnLoadActions057( ) ;
      }

      protected void OnLoadActions057( )
      {
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         AV21Pgmname = "Pase";
         AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
      }

      protected void CheckExtendedTable057( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV21Pgmname = "Pase";
         AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A14PaseTipo, "Entrada") == 0 ) || ( StringUtil.StrCmp(A14PaseTipo, "Invitacion") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Pase Tipo fuera de rango", "OutOfRange", 1, "PASETIPO");
            AnyError = 1;
            GX_FocusControl = cmbPaseTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A33EspectaculoInvitacionesEntrega = T00054_A33EspectaculoInvitacionesEntrega[0];
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         A8EspectaculoNombre = T00054_A8EspectaculoNombre[0];
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = T00054_A19EspectaculoFecha[0];
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         nIsDirty_7 = 1;
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A5EspectaculoId) || (0==A9SectorId) ) )
            {
               GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
               AnyError = 1;
               GX_FocusControl = edtEspectaculoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A21SectorNombre = T00055_A21SectorNombre[0];
         AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
         A23SectorPrecio = T00055_A23SectorPrecio[0];
         AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
         pr_default.close(3);
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {n15PaisCompraPaseId, A15PaisCompraPaseId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A15PaisCompraPaseId) ) )
            {
               GX_msglist.addItem("No existe 'Pais Compra Pase'.", "ForeignKeyNotFound", 1, "PAISCOMPRAPASEID");
               AnyError = 1;
               GX_FocusControl = edtPaisCompraPaseId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A35PaisCompraPaseNombre = T00056_A35PaisCompraPaseNombre[0];
         AssignAttri("", false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
         pr_default.close(4);
         if ( DateTimeUtil.ResetTime ( A19EspectaculoFecha ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("La fecha del espectáculo es anterior a la fecha actual", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors057( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_31( short A5EspectaculoId )
      {
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A33EspectaculoInvitacionesEntrega = T00058_A33EspectaculoInvitacionesEntrega[0];
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         A8EspectaculoNombre = T00058_A8EspectaculoNombre[0];
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = T00058_A19EspectaculoFecha[0];
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8EspectaculoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A19EspectaculoFecha, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_32( short A5EspectaculoId ,
                                short A9SectorId )
      {
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A5EspectaculoId) || (0==A9SectorId) ) )
            {
               GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
               AnyError = 1;
               GX_FocusControl = edtEspectaculoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A21SectorNombre = T00059_A21SectorNombre[0];
         AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
         A23SectorPrecio = T00059_A23SectorPrecio[0];
         AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A21SectorNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_33( short A15PaisCompraPaseId )
      {
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {n15PaisCompraPaseId, A15PaisCompraPaseId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A15PaisCompraPaseId) ) )
            {
               GX_msglist.addItem("No existe 'Pais Compra Pase'.", "ForeignKeyNotFound", 1, "PAISCOMPRAPASEID");
               AnyError = 1;
               GX_FocusControl = edtPaisCompraPaseId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A35PaisCompraPaseNombre = T000510_A35PaisCompraPaseNombre[0];
         AssignAttri("", false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A35PaisCompraPaseNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey057( )
      {
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {A13PaseId, A14PaseTipo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A13PaseId, A14PaseTipo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM057( 30) ;
            RcdFound7 = 1;
            A13PaseId = T00053_A13PaseId[0];
            AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
            A14PaseTipo = T00053_A14PaseTipo[0];
            AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
            A34NombreInvitado = T00053_A34NombreInvitado[0];
            n34NombreInvitado = T00053_n34NombreInvitado[0];
            AssignAttri("", false, "A34NombreInvitado", A34NombreInvitado);
            A5EspectaculoId = T00053_A5EspectaculoId[0];
            AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A9SectorId = T00053_A9SectorId[0];
            n9SectorId = T00053_n9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
            A15PaisCompraPaseId = T00053_A15PaisCompraPaseId[0];
            n15PaisCompraPaseId = T00053_n15PaisCompraPaseId[0];
            AssignAttri("", false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
            Z13PaseId = A13PaseId;
            Z14PaseTipo = A14PaseTipo;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load057( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey057( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey057( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey057( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T000512 */
         pr_default.execute(10, new Object[] {A13PaseId, A14PaseTipo});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000512_A13PaseId[0] < A13PaseId ) || ( T000512_A13PaseId[0] == A13PaseId ) && ( StringUtil.StrCmp(T000512_A14PaseTipo[0], A14PaseTipo) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000512_A13PaseId[0] > A13PaseId ) || ( T000512_A13PaseId[0] == A13PaseId ) && ( StringUtil.StrCmp(T000512_A14PaseTipo[0], A14PaseTipo) > 0 ) ) )
            {
               A13PaseId = T000512_A13PaseId[0];
               AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
               A14PaseTipo = T000512_A14PaseTipo[0];
               AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
               RcdFound7 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T000513 */
         pr_default.execute(11, new Object[] {A13PaseId, A14PaseTipo});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000513_A13PaseId[0] > A13PaseId ) || ( T000513_A13PaseId[0] == A13PaseId ) && ( StringUtil.StrCmp(T000513_A14PaseTipo[0], A14PaseTipo) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000513_A13PaseId[0] < A13PaseId ) || ( T000513_A13PaseId[0] == A13PaseId ) && ( StringUtil.StrCmp(T000513_A14PaseTipo[0], A14PaseTipo) < 0 ) ) )
            {
               A13PaseId = T000513_A13PaseId[0];
               AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
               A14PaseTipo = T000513_A14PaseTipo[0];
               AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
               RcdFound7 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey057( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaseId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert057( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( ( A13PaseId != Z13PaseId ) || ( StringUtil.StrCmp(A14PaseTipo, Z14PaseTipo) != 0 ) )
               {
                  A13PaseId = Z13PaseId;
                  AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
                  A14PaseTipo = Z14PaseTipo;
                  AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PASEID");
                  AnyError = 1;
                  GX_FocusControl = edtPaseId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaseId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update057( ) ;
                  GX_FocusControl = edtPaseId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A13PaseId != Z13PaseId ) || ( StringUtil.StrCmp(A14PaseTipo, Z14PaseTipo) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaseId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert057( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PASEID");
                     AnyError = 1;
                     GX_FocusControl = edtPaseId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPaseId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert057( ) ;
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
         if ( ( A13PaseId != Z13PaseId ) || ( StringUtil.StrCmp(A14PaseTipo, Z14PaseTipo) != 0 ) )
         {
            A13PaseId = Z13PaseId;
            AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
            A14PaseTipo = Z14PaseTipo;
            AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PASEID");
            AnyError = 1;
            GX_FocusControl = edtPaseId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaseId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency057( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A13PaseId, A14PaseTipo});
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z34NombreInvitado, T00052_A34NombreInvitado[0]) != 0 ) || ( Z5EspectaculoId != T00052_A5EspectaculoId[0] ) || ( Z9SectorId != T00052_A9SectorId[0] ) || ( Z15PaisCompraPaseId != T00052_A15PaisCompraPaseId[0] ) )
            {
               if ( StringUtil.StrCmp(Z34NombreInvitado, T00052_A34NombreInvitado[0]) != 0 )
               {
                  GXUtil.WriteLog("pase:[seudo value changed for attri]"+"NombreInvitado");
                  GXUtil.WriteLogRaw("Old: ",Z34NombreInvitado);
                  GXUtil.WriteLogRaw("Current: ",T00052_A34NombreInvitado[0]);
               }
               if ( Z5EspectaculoId != T00052_A5EspectaculoId[0] )
               {
                  GXUtil.WriteLog("pase:[seudo value changed for attri]"+"EspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z5EspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A5EspectaculoId[0]);
               }
               if ( Z9SectorId != T00052_A9SectorId[0] )
               {
                  GXUtil.WriteLog("pase:[seudo value changed for attri]"+"SectorId");
                  GXUtil.WriteLogRaw("Old: ",Z9SectorId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A9SectorId[0]);
               }
               if ( Z15PaisCompraPaseId != T00052_A15PaisCompraPaseId[0] )
               {
                  GXUtil.WriteLog("pase:[seudo value changed for attri]"+"PaisCompraPaseId");
                  GXUtil.WriteLogRaw("Old: ",Z15PaisCompraPaseId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A15PaisCompraPaseId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Pase"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert057( )
      {
         BeforeValidate057( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable057( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM057( 0) ;
            CheckOptimisticConcurrency057( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm057( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert057( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Execute user event: Insert */
                     E13052 ();
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
               Load057( ) ;
            }
            EndLevel057( ) ;
         }
         CloseExtendedTableCursors057( ) ;
      }

      protected void Update057( )
      {
         BeforeValidate057( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable057( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency057( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm057( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate057( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Execute user event: Update */
                     E14052 ();
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
            EndLevel057( ) ;
         }
         CloseExtendedTableCursors057( ) ;
      }

      protected void DeferredUpdate057( )
      {
      }

      protected void delete( )
      {
         BeforeValidate057( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency057( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls057( ) ;
            AfterConfirm057( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete057( ) ;
               if ( AnyError == 0 )
               {
                  /* Execute user event: Delete */
                  E15052 ();
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel057( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls057( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel057( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete057( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("pase",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("pase",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart057( )
      {
         /* Scan By routine */
         /* Using cursor T000514 */
         pr_default.execute(12);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A13PaseId = T000514_A13PaseId[0];
            AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
            A14PaseTipo = T000514_A14PaseTipo[0];
            AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext057( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A13PaseId = T000514_A13PaseId[0];
            AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
            A14PaseTipo = T000514_A14PaseTipo[0];
            AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
         }
      }

      protected void ScanEnd057( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm057( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert057( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate057( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete057( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete057( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate057( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes057( )
      {
         edtPaseId_Enabled = 0;
         AssignProp("", false, edtPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaseId_Enabled), 5, 0), true);
         cmbPaseTipo.Enabled = 0;
         AssignProp("", false, cmbPaseTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPaseTipo.Enabled), 5, 0), true);
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
         edtPaisCompraPaseId_Enabled = 0;
         AssignProp("", false, edtPaisCompraPaseId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraPaseId_Enabled), 5, 0), true);
         edtPaisCompraPaseNombre_Enabled = 0;
         AssignProp("", false, edtPaisCompraPaseNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCompraPaseNombre_Enabled), 5, 0), true);
         edtNombreInvitado_Enabled = 0;
         AssignProp("", false, edtNombreInvitado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNombreInvitado_Enabled), 5, 0), true);
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         AssignProp("", false, edtEspectaculoInvitacionesEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoInvitacionesEntrega_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes057( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("pase.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV17PaseId,4,0)),UrlEncode(StringUtil.RTrim(AV19PaseTipo))}, new string[] {"Gx_mode","PaseId","PaseTipo"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Pase");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("pase:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z13PaseId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13PaseId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z14PaseTipo", StringUtil.RTrim( Z14PaseTipo));
         GxWebStd.gx_hidden_field( context, "Z34NombreInvitado", StringUtil.RTrim( Z34NombreInvitado));
         GxWebStd.gx_hidden_field( context, "Z5EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z15PaisCompraPaseId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15PaisCompraPaseId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O33EspectaculoInvitacionesEntrega", StringUtil.LTrim( StringUtil.NToC( (decimal)(O33EspectaculoInvitacionesEntrega), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N5EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N15PaisCompraPaseId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15PaisCompraPaseId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV8TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV8TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPASEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17PaseId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPASEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17PaseId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPASETIPO", StringUtil.RTrim( AV19PaseTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vPASETIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19PaseTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10Insert_EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_SectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISCOMPRAPASEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Insert_PaisCompraPaseId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
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
         return formatLink("pase.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV17PaseId,4,0)),UrlEncode(StringUtil.RTrim(AV19PaseTipo))}, new string[] {"Gx_mode","PaseId","PaseTipo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Pase" ;
      }

      public override string GetPgmdesc( )
      {
         return "Pase" ;
      }

      protected void InitializeNonKey057( )
      {
         A5EspectaculoId = 0;
         AssignAttri("", false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
         A9SectorId = 0;
         n9SectorId = false;
         AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
         A15PaisCompraPaseId = 0;
         n15PaisCompraPaseId = false;
         AssignAttri("", false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
         A33EspectaculoInvitacionesEntrega = 0;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         A8EspectaculoNombre = "";
         AssignAttri("", false, "A8EspectaculoNombre", A8EspectaculoNombre);
         A19EspectaculoFecha = DateTime.MinValue;
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
         A21SectorNombre = "";
         AssignAttri("", false, "A21SectorNombre", A21SectorNombre);
         A23SectorPrecio = 0;
         AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
         A35PaisCompraPaseNombre = "";
         AssignAttri("", false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
         A34NombreInvitado = "";
         n34NombreInvitado = false;
         AssignAttri("", false, "A34NombreInvitado", A34NombreInvitado);
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
         Z34NombreInvitado = "";
         Z5EspectaculoId = 0;
         Z9SectorId = 0;
         Z15PaisCompraPaseId = 0;
      }

      protected void InitAll057( )
      {
         A13PaseId = 0;
         AssignAttri("", false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
         A14PaseTipo = "";
         AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
         InitializeNonKey057( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874412730", true, true);
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
         context.AddJavascriptSource("pase.js", "?2023874412730", false, true);
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
         edtPaseId_Internalname = "PASEID";
         cmbPaseTipo_Internalname = "PASETIPO";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoNombre_Internalname = "ESPECTACULONOMBRE";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtSectorId_Internalname = "SECTORID";
         edtSectorNombre_Internalname = "SECTORNOMBRE";
         edtSectorPrecio_Internalname = "SECTORPRECIO";
         edtPaisCompraPaseId_Internalname = "PAISCOMPRAPASEID";
         edtPaisCompraPaseNombre_Internalname = "PAISCOMPRAPASENOMBRE";
         edtNombreInvitado_Internalname = "NOMBREINVITADO";
         edtEspectaculoInvitacionesEntrega_Internalname = "ESPECTACULOINVITACIONESENTREGA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_15_Internalname = "PROMPT_15";
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
         Form.Caption = "Pase";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtEspectaculoInvitacionesEntrega_Jsonclick = "";
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         edtNombreInvitado_Jsonclick = "";
         edtNombreInvitado_Enabled = 1;
         edtPaisCompraPaseNombre_Jsonclick = "";
         edtPaisCompraPaseNombre_Enabled = 0;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtPaisCompraPaseId_Jsonclick = "";
         edtPaisCompraPaseId_Enabled = 1;
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
         cmbPaseTipo_Jsonclick = "";
         cmbPaseTipo.Enabled = 1;
         edtPaseId_Jsonclick = "";
         edtPaseId_Enabled = 1;
         edtPaseId_Visible = 1;
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
         cmbPaseTipo.Name = "PASETIPO";
         cmbPaseTipo.WebTags = "";
         cmbPaseTipo.addItem("Entrada", "Entrada", 0);
         cmbPaseTipo.addItem("Invitacion", "Invitacion", 0);
         if ( cmbPaseTipo.ItemCount > 0 )
         {
            A14PaseTipo = cmbPaseTipo.getValidValue(A14PaseTipo);
            AssignAttri("", false, "A14PaseTipo", A14PaseTipo);
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

      public void Valid_Espectaculoid( )
      {
         /* Using cursor T000515 */
         pr_default.execute(13, new Object[] {A5EspectaculoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         A33EspectaculoInvitacionesEntrega = T000515_A33EspectaculoInvitacionesEntrega[0];
         A8EspectaculoNombre = T000515_A8EspectaculoNombre[0];
         A19EspectaculoFecha = T000515_A19EspectaculoFecha[0];
         O33EspectaculoInvitacionesEntrega = A33EspectaculoInvitacionesEntrega;
         pr_default.close(13);
         if ( IsDlt( )  )
         {
            A33EspectaculoInvitacionesEntrega = (short)(O33EspectaculoInvitacionesEntrega-1);
         }
         if ( DateTimeUtil.ResetTime ( A19EspectaculoFecha ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("La fecha del espectáculo es anterior a la fecha actual", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         dynload_actions( ) ;
         if ( cmbPaseTipo.ItemCount > 0 )
         {
            A14PaseTipo = cmbPaseTipo.getValidValue(A14PaseTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPaseTipo.CurrentValue = StringUtil.RTrim( A14PaseTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "O33EspectaculoInvitacionesEntrega", StringUtil.LTrim( StringUtil.NToC( (decimal)(O33EspectaculoInvitacionesEntrega), 4, 0, ",", "")));
         AssignAttri("", false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0, ".", "")));
         AssignAttri("", false, "A8EspectaculoNombre", StringUtil.RTrim( A8EspectaculoNombre));
         AssignAttri("", false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
      }

      public void Valid_Sectorid( )
      {
         n9SectorId = false;
         /* Using cursor T000516 */
         pr_default.execute(14, new Object[] {A5EspectaculoId, n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A5EspectaculoId) || (0==A9SectorId) ) )
            {
               GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
               AnyError = 1;
               GX_FocusControl = edtEspectaculoId_Internalname;
            }
         }
         A21SectorNombre = T000516_A21SectorNombre[0];
         A23SectorPrecio = T000516_A23SectorPrecio[0];
         pr_default.close(14);
         dynload_actions( ) ;
         if ( cmbPaseTipo.ItemCount > 0 )
         {
            A14PaseTipo = cmbPaseTipo.getValidValue(A14PaseTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPaseTipo.CurrentValue = StringUtil.RTrim( A14PaseTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A21SectorNombre", StringUtil.RTrim( A21SectorNombre));
         AssignAttri("", false, "A23SectorPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ".", "")));
      }

      public void Valid_Paiscomprapaseid( )
      {
         n15PaisCompraPaseId = false;
         /* Using cursor T000517 */
         pr_default.execute(15, new Object[] {n15PaisCompraPaseId, A15PaisCompraPaseId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A15PaisCompraPaseId) ) )
            {
               GX_msglist.addItem("No existe 'Pais Compra Pase'.", "ForeignKeyNotFound", 1, "PAISCOMPRAPASEID");
               AnyError = 1;
               GX_FocusControl = edtPaisCompraPaseId_Internalname;
            }
         }
         A35PaisCompraPaseNombre = T000517_A35PaisCompraPaseNombre[0];
         pr_default.close(15);
         dynload_actions( ) ;
         if ( cmbPaseTipo.ItemCount > 0 )
         {
            A14PaseTipo = cmbPaseTipo.getValidValue(A14PaseTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPaseTipo.CurrentValue = StringUtil.RTrim( A14PaseTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A35PaisCompraPaseNombre", StringUtil.RTrim( A35PaisCompraPaseNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV17PaseId',fld:'vPASEID',pic:'ZZZ9',hsh:true},{av:'AV19PaseTipo',fld:'vPASETIPO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV17PaseId',fld:'vPASEID',pic:'ZZZ9',hsh:true},{av:'AV19PaseTipo',fld:'vPASETIPO',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PASEID","{handler:'Valid_Paseid',iparms:[]");
         setEventMetadata("VALID_PASEID",",oparms:[]}");
         setEventMetadata("VALID_PASETIPO","{handler:'Valid_Pasetipo',iparms:[]");
         setEventMetadata("VALID_PASETIPO",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'O33EspectaculoInvitacionesEntrega'},{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A33EspectaculoInvitacionesEntrega',fld:'ESPECTACULOINVITACIONESENTREGA',pic:'ZZZ9'},{av:'A19EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''},{av:'Gx_date',fld:'vTODAY',pic:''},{av:'A8EspectaculoNombre',fld:'ESPECTACULONOMBRE',pic:''}]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[{av:'O33EspectaculoInvitacionesEntrega'},{av:'A33EspectaculoInvitacionesEntrega',fld:'ESPECTACULOINVITACIONESENTREGA',pic:'ZZZ9'},{av:'A8EspectaculoNombre',fld:'ESPECTACULONOMBRE',pic:''},{av:'A19EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''}]}");
         setEventMetadata("VALID_ESPECTACULOFECHA","{handler:'Valid_Espectaculofecha',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFECHA",",oparms:[]}");
         setEventMetadata("VALID_SECTORID","{handler:'Valid_Sectorid',iparms:[{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZ9'},{av:'A21SectorNombre',fld:'SECTORNOMBRE',pic:''},{av:'A23SectorPrecio',fld:'SECTORPRECIO',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_SECTORID",",oparms:[{av:'A21SectorNombre',fld:'SECTORNOMBRE',pic:''},{av:'A23SectorPrecio',fld:'SECTORPRECIO',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_PAISCOMPRAPASEID","{handler:'Valid_Paiscomprapaseid',iparms:[{av:'A15PaisCompraPaseId',fld:'PAISCOMPRAPASEID',pic:'ZZZ9'},{av:'A35PaisCompraPaseNombre',fld:'PAISCOMPRAPASENOMBRE',pic:''}]");
         setEventMetadata("VALID_PAISCOMPRAPASEID",",oparms:[{av:'A35PaisCompraPaseNombre',fld:'PAISCOMPRAPASENOMBRE',pic:''}]}");
         setEventMetadata("VALID_ESPECTACULOINVITACIONESENTREGA","{handler:'Valid_Espectaculoinvitacionesentrega',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOINVITACIONESENTREGA",",oparms:[]}");
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
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV19PaseTipo = "";
         Z14PaseTipo = "";
         Z34NombreInvitado = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A14PaseTipo = "";
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
         imgprompt_15_gximage = "";
         A35PaisCompraPaseNombre = "";
         A34NombreInvitado = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV21Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9WebSession = context.GetSession();
         AV11TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV12Invitacion = new SdtInvitacion(context);
         AV14Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV13Entrada = new SdtEntrada(context);
         LclMsgLst = new msglist();
         Z8EspectaculoNombre = "";
         Z19EspectaculoFecha = DateTime.MinValue;
         Z21SectorNombre = "";
         Z35PaisCompraPaseNombre = "";
         T00056_A35PaisCompraPaseNombre = new string[] {""} ;
         T00054_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T00054_A8EspectaculoNombre = new string[] {""} ;
         T00054_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00055_A21SectorNombre = new string[] {""} ;
         T00055_A23SectorPrecio = new int[1] ;
         T00057_A13PaseId = new short[1] ;
         T00057_A14PaseTipo = new string[] {""} ;
         T00057_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T00057_A8EspectaculoNombre = new string[] {""} ;
         T00057_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00057_A21SectorNombre = new string[] {""} ;
         T00057_A23SectorPrecio = new int[1] ;
         T00057_A35PaisCompraPaseNombre = new string[] {""} ;
         T00057_A34NombreInvitado = new string[] {""} ;
         T00057_n34NombreInvitado = new bool[] {false} ;
         T00057_A5EspectaculoId = new short[1] ;
         T00057_A9SectorId = new short[1] ;
         T00057_n9SectorId = new bool[] {false} ;
         T00057_A15PaisCompraPaseId = new short[1] ;
         T00057_n15PaisCompraPaseId = new bool[] {false} ;
         T00058_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T00058_A8EspectaculoNombre = new string[] {""} ;
         T00058_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00059_A21SectorNombre = new string[] {""} ;
         T00059_A23SectorPrecio = new int[1] ;
         T000510_A35PaisCompraPaseNombre = new string[] {""} ;
         T000511_A13PaseId = new short[1] ;
         T000511_A14PaseTipo = new string[] {""} ;
         T00053_A13PaseId = new short[1] ;
         T00053_A14PaseTipo = new string[] {""} ;
         T00053_A34NombreInvitado = new string[] {""} ;
         T00053_n34NombreInvitado = new bool[] {false} ;
         T00053_A5EspectaculoId = new short[1] ;
         T00053_A9SectorId = new short[1] ;
         T00053_n9SectorId = new bool[] {false} ;
         T00053_A15PaisCompraPaseId = new short[1] ;
         T00053_n15PaisCompraPaseId = new bool[] {false} ;
         T000512_A13PaseId = new short[1] ;
         T000512_A14PaseTipo = new string[] {""} ;
         T000513_A13PaseId = new short[1] ;
         T000513_A14PaseTipo = new string[] {""} ;
         T00052_A13PaseId = new short[1] ;
         T00052_A14PaseTipo = new string[] {""} ;
         T00052_A34NombreInvitado = new string[] {""} ;
         T00052_n34NombreInvitado = new bool[] {false} ;
         T00052_A5EspectaculoId = new short[1] ;
         T00052_A9SectorId = new short[1] ;
         T00052_n9SectorId = new bool[] {false} ;
         T00052_A15PaisCompraPaseId = new short[1] ;
         T00052_n15PaisCompraPaseId = new bool[] {false} ;
         T000514_A13PaseId = new short[1] ;
         T000514_A14PaseTipo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000515_A33EspectaculoInvitacionesEntrega = new short[1] ;
         T000515_A8EspectaculoNombre = new string[] {""} ;
         T000515_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000516_A21SectorNombre = new string[] {""} ;
         T000516_A23SectorPrecio = new int[1] ;
         T000517_A35PaisCompraPaseNombre = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pase__default(),
            new Object[][] {
                new Object[] {
               T00052_A13PaseId, T00052_A14PaseTipo, T00052_A34NombreInvitado, T00052_n34NombreInvitado, T00052_A5EspectaculoId, T00052_A9SectorId, T00052_n9SectorId, T00052_A15PaisCompraPaseId, T00052_n15PaisCompraPaseId
               }
               , new Object[] {
               T00053_A13PaseId, T00053_A14PaseTipo, T00053_A34NombreInvitado, T00053_n34NombreInvitado, T00053_A5EspectaculoId, T00053_A9SectorId, T00053_n9SectorId, T00053_A15PaisCompraPaseId, T00053_n15PaisCompraPaseId
               }
               , new Object[] {
               T00054_A33EspectaculoInvitacionesEntrega, T00054_A8EspectaculoNombre, T00054_A19EspectaculoFecha
               }
               , new Object[] {
               T00055_A21SectorNombre, T00055_A23SectorPrecio
               }
               , new Object[] {
               T00056_A35PaisCompraPaseNombre
               }
               , new Object[] {
               T00057_A13PaseId, T00057_A14PaseTipo, T00057_A33EspectaculoInvitacionesEntrega, T00057_A8EspectaculoNombre, T00057_A19EspectaculoFecha, T00057_A21SectorNombre, T00057_A23SectorPrecio, T00057_A35PaisCompraPaseNombre, T00057_A34NombreInvitado, T00057_n34NombreInvitado,
               T00057_A5EspectaculoId, T00057_A9SectorId, T00057_n9SectorId, T00057_A15PaisCompraPaseId, T00057_n15PaisCompraPaseId
               }
               , new Object[] {
               T00058_A33EspectaculoInvitacionesEntrega, T00058_A8EspectaculoNombre, T00058_A19EspectaculoFecha
               }
               , new Object[] {
               T00059_A21SectorNombre, T00059_A23SectorPrecio
               }
               , new Object[] {
               T000510_A35PaisCompraPaseNombre
               }
               , new Object[] {
               T000511_A13PaseId, T000511_A14PaseTipo
               }
               , new Object[] {
               T000512_A13PaseId, T000512_A14PaseTipo
               }
               , new Object[] {
               T000513_A13PaseId, T000513_A14PaseTipo
               }
               , new Object[] {
               T000514_A13PaseId, T000514_A14PaseTipo
               }
               , new Object[] {
               T000515_A33EspectaculoInvitacionesEntrega, T000515_A8EspectaculoNombre, T000515_A19EspectaculoFecha
               }
               , new Object[] {
               T000516_A21SectorNombre, T000516_A23SectorPrecio
               }
               , new Object[] {
               T000517_A35PaisCompraPaseNombre
               }
            }
         );
         AV21Pgmname = "Pase";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short wcpOAV17PaseId ;
      private short Z13PaseId ;
      private short Z5EspectaculoId ;
      private short Z9SectorId ;
      private short Z15PaisCompraPaseId ;
      private short O33EspectaculoInvitacionesEntrega ;
      private short N5EspectaculoId ;
      private short N9SectorId ;
      private short N15PaisCompraPaseId ;
      private short GxWebError ;
      private short A5EspectaculoId ;
      private short A9SectorId ;
      private short A15PaisCompraPaseId ;
      private short AV17PaseId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A13PaseId ;
      private short A33EspectaculoInvitacionesEntrega ;
      private short AV10Insert_EspectaculoId ;
      private short AV15Insert_SectorId ;
      private short AV18Insert_PaisCompraPaseId ;
      private short RcdFound7 ;
      private short GX_JID ;
      private short Z33EspectaculoInvitacionesEntrega ;
      private short Gx_BScreen ;
      private short nIsDirty_7 ;
      private short gxajaxcallmode ;
      private short ZO33EspectaculoInvitacionesEntrega ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPaseId_Visible ;
      private int edtPaseId_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtEspectaculoNombre_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtSectorId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtSectorNombre_Enabled ;
      private int A23SectorPrecio ;
      private int edtSectorPrecio_Enabled ;
      private int edtPaisCompraPaseId_Enabled ;
      private int imgprompt_15_Visible ;
      private int edtPaisCompraPaseNombre_Enabled ;
      private int edtNombreInvitado_Enabled ;
      private int edtEspectaculoInvitacionesEntrega_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV22GXV1 ;
      private int Z23SectorPrecio ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV19PaseTipo ;
      private string Z14PaseTipo ;
      private string Z34NombreInvitado ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string AV19PaseTipo ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaseId_Internalname ;
      private string A14PaseTipo ;
      private string cmbPaseTipo_Internalname ;
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
      private string edtPaseId_Jsonclick ;
      private string cmbPaseTipo_Jsonclick ;
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
      private string edtPaisCompraPaseId_Internalname ;
      private string edtPaisCompraPaseId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtPaisCompraPaseNombre_Internalname ;
      private string A35PaisCompraPaseNombre ;
      private string edtPaisCompraPaseNombre_Jsonclick ;
      private string edtNombreInvitado_Internalname ;
      private string A34NombreInvitado ;
      private string edtNombreInvitado_Jsonclick ;
      private string edtEspectaculoInvitacionesEntrega_Internalname ;
      private string edtEspectaculoInvitacionesEntrega_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV21Pgmname ;
      private string hsh ;
      private string sMode7 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z8EspectaculoNombre ;
      private string Z21SectorNombre ;
      private string Z35PaisCompraPaseNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime A19EspectaculoFecha ;
      private DateTime Gx_date ;
      private DateTime Z19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n9SectorId ;
      private bool n15PaisCompraPaseId ;
      private bool wbErr ;
      private bool n34NombreInvitado ;
      private bool returnInSub ;
      private IGxSession AV9WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPaseTipo ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_default ;
      private string[] T00056_A35PaisCompraPaseNombre ;
      private short[] T00054_A33EspectaculoInvitacionesEntrega ;
      private string[] T00054_A8EspectaculoNombre ;
      private DateTime[] T00054_A19EspectaculoFecha ;
      private string[] T00055_A21SectorNombre ;
      private int[] T00055_A23SectorPrecio ;
      private short[] T00057_A13PaseId ;
      private string[] T00057_A14PaseTipo ;
      private short[] T00057_A33EspectaculoInvitacionesEntrega ;
      private string[] T00057_A8EspectaculoNombre ;
      private DateTime[] T00057_A19EspectaculoFecha ;
      private string[] T00057_A21SectorNombre ;
      private int[] T00057_A23SectorPrecio ;
      private string[] T00057_A35PaisCompraPaseNombre ;
      private string[] T00057_A34NombreInvitado ;
      private bool[] T00057_n34NombreInvitado ;
      private short[] T00057_A5EspectaculoId ;
      private short[] T00057_A9SectorId ;
      private bool[] T00057_n9SectorId ;
      private short[] T00057_A15PaisCompraPaseId ;
      private bool[] T00057_n15PaisCompraPaseId ;
      private short[] T00058_A33EspectaculoInvitacionesEntrega ;
      private string[] T00058_A8EspectaculoNombre ;
      private DateTime[] T00058_A19EspectaculoFecha ;
      private string[] T00059_A21SectorNombre ;
      private int[] T00059_A23SectorPrecio ;
      private string[] T000510_A35PaisCompraPaseNombre ;
      private short[] T000511_A13PaseId ;
      private string[] T000511_A14PaseTipo ;
      private short[] T00053_A13PaseId ;
      private string[] T00053_A14PaseTipo ;
      private string[] T00053_A34NombreInvitado ;
      private bool[] T00053_n34NombreInvitado ;
      private short[] T00053_A5EspectaculoId ;
      private short[] T00053_A9SectorId ;
      private bool[] T00053_n9SectorId ;
      private short[] T00053_A15PaisCompraPaseId ;
      private bool[] T00053_n15PaisCompraPaseId ;
      private short[] T000512_A13PaseId ;
      private string[] T000512_A14PaseTipo ;
      private short[] T000513_A13PaseId ;
      private string[] T000513_A14PaseTipo ;
      private short[] T00052_A13PaseId ;
      private string[] T00052_A14PaseTipo ;
      private string[] T00052_A34NombreInvitado ;
      private bool[] T00052_n34NombreInvitado ;
      private short[] T00052_A5EspectaculoId ;
      private short[] T00052_A9SectorId ;
      private bool[] T00052_n9SectorId ;
      private short[] T00052_A15PaisCompraPaseId ;
      private bool[] T00052_n15PaisCompraPaseId ;
      private short[] T000514_A13PaseId ;
      private string[] T000514_A14PaseTipo ;
      private short[] T000515_A33EspectaculoInvitacionesEntrega ;
      private string[] T000515_A8EspectaculoNombre ;
      private DateTime[] T000515_A19EspectaculoFecha ;
      private string[] T000516_A21SectorNombre ;
      private int[] T000516_A23SectorPrecio ;
      private string[] T000517_A35PaisCompraPaseNombre ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV14Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV8TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV11TrnContextAtt ;
      private SdtInvitacion AV12Invitacion ;
      private SdtEntrada AV13Entrada ;
   }

   public class pase__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@PaseId",GXType.Int16,4,0) ,
          new ParDef("@PaseTipo",GXType.NChar,20,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@PaisCompraPaseId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@PaisCompraPaseId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@PaseId",GXType.Int16,4,0) ,
          new ParDef("@PaseTipo",GXType.NChar,20,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@PaseId",GXType.Int16,4,0) ,
          new ParDef("@PaseTipo",GXType.NChar,20,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@PaseId",GXType.Int16,4,0) ,
          new ParDef("@PaseTipo",GXType.NChar,20,0)
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@PaseId",GXType.Int16,4,0) ,
          new ParDef("@PaseTipo",GXType.NChar,20,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@PaseId",GXType.Int16,4,0) ,
          new ParDef("@PaseTipo",GXType.NChar,20,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@PaisCompraPaseId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [PaseId], [PaseTipo], [NombreInvitado], [EspectaculoId], [SectorId], [PaisCompraPaseId] AS PaisCompraPaseId FROM [Pase] WHERE [PaseId] = @PaseId AND [PaseTipo] = @PaseTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [PaseId], [PaseTipo], [NombreInvitado], [EspectaculoId], [SectorId], [PaisCompraPaseId] AS PaisCompraPaseId FROM [Pase] WHERE [PaseId] = @PaseId AND [PaseTipo] = @PaseTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [SectorNombre], [SectorPrecio] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [PaisNombre] AS PaisCompraPaseNombre FROM [Pais] WHERE [PaisId] = @PaisCompraPaseId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT TM1.[PaseId], TM1.[PaseTipo], T2.[EspectaculoInvitacionesEntrega], T2.[EspectaculoNombre], T2.[EspectaculoFecha], T3.[SectorNombre], T3.[SectorPrecio], T4.[PaisNombre] AS PaisCompraPaseNombre, TM1.[NombreInvitado], TM1.[EspectaculoId], TM1.[SectorId], TM1.[PaisCompraPaseId] AS PaisCompraPaseId FROM ((([Pase] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) LEFT JOIN [EspectaculoSector] T3 ON T3.[EspectaculoId] = TM1.[EspectaculoId] AND T3.[SectorId] = TM1.[SectorId]) LEFT JOIN [Pais] T4 ON T4.[PaisId] = TM1.[PaisCompraPaseId]) WHERE TM1.[PaseId] = @PaseId and TM1.[PaseTipo] = @PaseTipo ORDER BY TM1.[PaseId], TM1.[PaseTipo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [SectorNombre], [SectorPrecio] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT [PaisNombre] AS PaisCompraPaseNombre FROM [Pais] WHERE [PaisId] = @PaisCompraPaseId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000511", "SELECT [PaseId], [PaseTipo] FROM [Pase] WHERE [PaseId] = @PaseId AND [PaseTipo] = @PaseTipo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000512", "SELECT TOP 1 [PaseId], [PaseTipo] FROM [Pase] WHERE ( [PaseId] > @PaseId or [PaseId] = @PaseId and [PaseTipo] > @PaseTipo) ORDER BY [PaseId], [PaseTipo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000513", "SELECT TOP 1 [PaseId], [PaseTipo] FROM [Pase] WHERE ( [PaseId] < @PaseId or [PaseId] = @PaseId and [PaseTipo] < @PaseTipo) ORDER BY [PaseId] DESC, [PaseTipo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000514", "SELECT [PaseId], [PaseTipo] FROM [Pase] ORDER BY [PaseId], [PaseTipo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000515", "SELECT [EspectaculoInvitacionesEntrega], [EspectaculoNombre], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000516", "SELECT [SectorNombre], [SectorPrecio] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000517", "SELECT [PaisNombre] AS PaisCompraPaseNombre FROM [Pais] WHERE [PaisId] = @PaisCompraPaseId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 60);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((short[]) buf[13])[0] = rslt.getShort(12);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                return;
       }
    }

 }

}
