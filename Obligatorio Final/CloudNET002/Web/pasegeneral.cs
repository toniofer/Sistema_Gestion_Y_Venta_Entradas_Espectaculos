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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pasegeneral : GXWebComponent
   {
      public pasegeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("ObligatorioPrueba001", true);
         }
      }

      public pasegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_PaseId ,
                           string aP1_PaseTipo )
      {
         this.A13PaseId = aP0_PaseId;
         this.A14PaseTipo = aP1_PaseTipo;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbPaseTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "PaseId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A13PaseId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaseId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
                  A14PaseTipo = GetPar( "PaseTipo");
                  AssignAttri(sPrefix, false, "A14PaseTipo", A14PaseTipo);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A13PaseId,(string)A14PaseTipo});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "PaseId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "PaseId");
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV14Pgmname = "PaseGeneral";
               context.Gx_err = 0;
               WS0X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Pase General") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("pasegeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A13PaseId,4,0)),UrlEncode(StringUtil.RTrim(A14PaseTipo))}, new string[] {"PaseId","PaseTipo"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"PaseGeneral");
         forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("pasegeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA13PaseId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA13PaseId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA14PaseTipo", StringUtil.RTrim( wcpOA14PaseTipo));
      }

      protected void RenderHtmlCloseForm0X2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "PaseGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Pase General" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "pasegeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 7, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110x1_client"+"'", TempTags, "", 2, "HLP_PaseGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120x1_client"+"'", TempTags, "", 2, "HLP_PaseGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaseId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaseId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaseId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PaseId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaseId_Enabled!=0) ? context.localUtil.Format( (decimal)(A13PaseId), "ZZZ9") : context.localUtil.Format( (decimal)(A13PaseId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaseId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaseId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PaseGeneral.htm");
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
            GxWebStd.gx_label_element( context, cmbPaseTipo_Internalname, "Tipo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbPaseTipo, cmbPaseTipo_Internalname, StringUtil.RTrim( A14PaseTipo), 1, cmbPaseTipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbPaseTipo.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", "", "", true, 0, "HLP_PaseGeneral.htm");
            cmbPaseTipo.CurrentValue = StringUtil.RTrim( A14PaseTipo);
            AssignProp(sPrefix, false, cmbPaseTipo_Internalname, "Values", (string)(cmbPaseTipo.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_element( context, edtEspectaculoNombre_Internalname, "Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoNombre_Internalname, StringUtil.RTrim( A8EspectaculoNombre), StringUtil.RTrim( context.localUtil.Format( A8EspectaculoNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtEspectaculoNombre_Link, "", "", "", edtEspectaculoNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_PaseGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEspectaculoFecha_Internalname, "Fecha", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtEspectaculoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A19EspectaculoFecha, "99/99/99"), context.localUtil.Format( A19EspectaculoFecha, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PaseGeneral.htm");
            GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PaseGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSectorNombre_Internalname, "Sector", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSectorNombre_Internalname, StringUtil.RTrim( A21SectorNombre), StringUtil.RTrim( context.localUtil.Format( A21SectorNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtSectorNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_PaseGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtSectorPrecio_Internalname, "Precio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ",", "")), StringUtil.LTrim( ((edtSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9") : context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorPrecio_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtSectorPrecio_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PaseGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtPaisCompraPaseNombre_Internalname, "Pais Compra", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisCompraPaseNombre_Internalname, StringUtil.RTrim( A35PaisCompraPaseNombre), StringUtil.RTrim( context.localUtil.Format( A35PaisCompraPaseNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisCompraPaseNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisCompraPaseNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_PaseGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtNombreInvitado_Internalname, "Invitado", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtNombreInvitado_Internalname, StringUtil.RTrim( A34NombreInvitado), StringUtil.RTrim( context.localUtil.Format( A34NombreInvitado, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNombreInvitado_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtNombreInvitado_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PaseGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Espectaculo Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PaseGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSectorId_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSectorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9") : context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PaseGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaisCompraPaseId_Internalname, "Pais Compra Pase Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisCompraPaseId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15PaisCompraPaseId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisCompraPaseId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15PaisCompraPaseId), "ZZZ9") : context.localUtil.Format( (decimal)(A15PaisCompraPaseId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisCompraPaseId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisCompraPaseId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PaseGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoInvitacionesEntrega_Internalname, "Espectaculo Invitaciones Entregadas", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoInvitacionesEntrega_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoInvitacionesEntrega_Enabled!=0) ? context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9") : context.localUtil.Format( (decimal)(A33EspectaculoInvitacionesEntrega), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoInvitacionesEntrega_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoInvitacionesEntrega_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PaseGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_3-171579", 0) ;
               }
               Form.Meta.addItem("description", "Pase General", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0X0( ) ;
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbPaseTipo.ItemCount > 0 )
         {
            A14PaseTipo = cmbPaseTipo.getValidValue(A14PaseTipo);
            AssignAttri(sPrefix, false, "A14PaseTipo", A14PaseTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPaseTipo.CurrentValue = StringUtil.RTrim( A14PaseTipo);
            AssignProp(sPrefix, false, cmbPaseTipo_Internalname, "Values", cmbPaseTipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV14Pgmname = "PaseGeneral";
         context.Gx_err = 0;
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000X2 */
            pr_default.execute(0, new Object[] {A13PaseId, A14PaseTipo});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A33EspectaculoInvitacionesEntrega = H000X2_A33EspectaculoInvitacionesEntrega[0];
               AssignAttri(sPrefix, false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
               A15PaisCompraPaseId = H000X2_A15PaisCompraPaseId[0];
               n15PaisCompraPaseId = H000X2_n15PaisCompraPaseId[0];
               AssignAttri(sPrefix, false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
               A9SectorId = H000X2_A9SectorId[0];
               n9SectorId = H000X2_n9SectorId[0];
               AssignAttri(sPrefix, false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
               A5EspectaculoId = H000X2_A5EspectaculoId[0];
               AssignAttri(sPrefix, false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
               A34NombreInvitado = H000X2_A34NombreInvitado[0];
               n34NombreInvitado = H000X2_n34NombreInvitado[0];
               AssignAttri(sPrefix, false, "A34NombreInvitado", A34NombreInvitado);
               A35PaisCompraPaseNombre = H000X2_A35PaisCompraPaseNombre[0];
               AssignAttri(sPrefix, false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
               A23SectorPrecio = H000X2_A23SectorPrecio[0];
               AssignAttri(sPrefix, false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
               A21SectorNombre = H000X2_A21SectorNombre[0];
               AssignAttri(sPrefix, false, "A21SectorNombre", A21SectorNombre);
               A19EspectaculoFecha = H000X2_A19EspectaculoFecha[0];
               AssignAttri(sPrefix, false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
               A8EspectaculoNombre = H000X2_A8EspectaculoNombre[0];
               AssignAttri(sPrefix, false, "A8EspectaculoNombre", A8EspectaculoNombre);
               A35PaisCompraPaseNombre = H000X2_A35PaisCompraPaseNombre[0];
               AssignAttri(sPrefix, false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
               A33EspectaculoInvitacionesEntrega = H000X2_A33EspectaculoInvitacionesEntrega[0];
               AssignAttri(sPrefix, false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
               A19EspectaculoFecha = H000X2_A19EspectaculoFecha[0];
               AssignAttri(sPrefix, false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
               A8EspectaculoNombre = H000X2_A8EspectaculoNombre[0];
               AssignAttri(sPrefix, false, "A8EspectaculoNombre", A8EspectaculoNombre);
               A23SectorPrecio = H000X2_A23SectorPrecio[0];
               AssignAttri(sPrefix, false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
               A21SectorNombre = H000X2_A21SectorNombre[0];
               AssignAttri(sPrefix, false, "A21SectorNombre", A21SectorNombre);
               /* Execute user event: Load */
               E140X2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV14Pgmname = "PaseGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130X2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA13PaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA13PaseId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOA14PaseTipo = cgiGet( sPrefix+"wcpOA14PaseTipo");
            /* Read variables values. */
            A8EspectaculoNombre = cgiGet( edtEspectaculoNombre_Internalname);
            AssignAttri(sPrefix, false, "A8EspectaculoNombre", A8EspectaculoNombre);
            A19EspectaculoFecha = context.localUtil.CToD( cgiGet( edtEspectaculoFecha_Internalname), 2);
            AssignAttri(sPrefix, false, "A19EspectaculoFecha", context.localUtil.Format(A19EspectaculoFecha, "99/99/99"));
            A21SectorNombre = cgiGet( edtSectorNombre_Internalname);
            AssignAttri(sPrefix, false, "A21SectorNombre", A21SectorNombre);
            A23SectorPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A23SectorPrecio", StringUtil.LTrimStr( (decimal)(A23SectorPrecio), 6, 0));
            A35PaisCompraPaseNombre = cgiGet( edtPaisCompraPaseNombre_Internalname);
            AssignAttri(sPrefix, false, "A35PaisCompraPaseNombre", A35PaisCompraPaseNombre);
            A34NombreInvitado = cgiGet( edtNombreInvitado_Internalname);
            n34NombreInvitado = false;
            AssignAttri(sPrefix, false, "A34NombreInvitado", A34NombreInvitado);
            A5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            A9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n9SectorId = false;
            AssignAttri(sPrefix, false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 4, 0));
            A15PaisCompraPaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisCompraPaseId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n15PaisCompraPaseId = false;
            AssignAttri(sPrefix, false, "A15PaisCompraPaseId", StringUtil.LTrimStr( (decimal)(A15PaisCompraPaseId), 4, 0));
            A33EspectaculoInvitacionesEntrega = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoInvitacionesEntrega_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A33EspectaculoInvitacionesEntrega", StringUtil.LTrimStr( (decimal)(A33EspectaculoInvitacionesEntrega), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"PaseGeneral");
            A5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A5EspectaculoId", StringUtil.LTrimStr( (decimal)(A5EspectaculoId), 4, 0));
            forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("pasegeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E130X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130X2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140X2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtEspectaculoNombre_Link = formatLink("viewespectaculo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A5EspectaculoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EspectaculoId","TabCode"}) ;
         AssignProp(sPrefix, false, edtEspectaculoNombre_Internalname, "Link", edtEspectaculoNombre_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV14Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Pase";
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "PaseId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6PaseId), 4, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "PaseTipo";
         AV9TrnContextAtt.gxTpr_Attributevalue = AV7PaseTipo;
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A13PaseId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
         A14PaseTipo = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "A14PaseTipo", A14PaseTipo);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA13PaseId = (string)((string)getParm(obj,0));
         sCtrlA14PaseTipo = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "pasegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0X2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A13PaseId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
            A14PaseTipo = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "A14PaseTipo", A14PaseTipo);
         }
         wcpOA13PaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA13PaseId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOA14PaseTipo = cgiGet( sPrefix+"wcpOA14PaseTipo");
         if ( ! GetJustCreated( ) && ( ( A13PaseId != wcpOA13PaseId ) || ( StringUtil.StrCmp(A14PaseTipo, wcpOA14PaseTipo) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOA13PaseId = A13PaseId;
         wcpOA14PaseTipo = A14PaseTipo;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA13PaseId = cgiGet( sPrefix+"A13PaseId_CTRL");
         if ( StringUtil.Len( sCtrlA13PaseId) > 0 )
         {
            A13PaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA13PaseId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A13PaseId", StringUtil.LTrimStr( (decimal)(A13PaseId), 4, 0));
         }
         else
         {
            A13PaseId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A13PaseId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlA14PaseTipo = cgiGet( sPrefix+"A14PaseTipo_CTRL");
         if ( StringUtil.Len( sCtrlA14PaseTipo) > 0 )
         {
            A14PaseTipo = cgiGet( sCtrlA14PaseTipo);
            AssignAttri(sPrefix, false, "A14PaseTipo", A14PaseTipo);
         }
         else
         {
            A14PaseTipo = cgiGet( sPrefix+"A14PaseTipo_PARM");
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A13PaseId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PaseId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA13PaseId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A13PaseId_CTRL", StringUtil.RTrim( sCtrlA13PaseId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A14PaseTipo_PARM", StringUtil.RTrim( A14PaseTipo));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA14PaseTipo)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A14PaseTipo_CTRL", StringUtil.RTrim( sCtrlA14PaseTipo));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874412433", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("pasegeneral.js", "?2023874412433", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbPaseTipo.Name = "PASETIPO";
         cmbPaseTipo.WebTags = "";
         cmbPaseTipo.addItem("Entrada", "Entrada", 0);
         cmbPaseTipo.addItem("Invitacion", "Invitacion", 0);
         if ( cmbPaseTipo.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtPaseId_Internalname = sPrefix+"PASEID";
         cmbPaseTipo_Internalname = sPrefix+"PASETIPO";
         edtEspectaculoNombre_Internalname = sPrefix+"ESPECTACULONOMBRE";
         edtEspectaculoFecha_Internalname = sPrefix+"ESPECTACULOFECHA";
         edtSectorNombre_Internalname = sPrefix+"SECTORNOMBRE";
         edtSectorPrecio_Internalname = sPrefix+"SECTORPRECIO";
         edtPaisCompraPaseNombre_Internalname = sPrefix+"PAISCOMPRAPASENOMBRE";
         edtNombreInvitado_Internalname = sPrefix+"NOMBREINVITADO";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         edtEspectaculoId_Internalname = sPrefix+"ESPECTACULOID";
         edtSectorId_Internalname = sPrefix+"SECTORID";
         edtPaisCompraPaseId_Internalname = sPrefix+"PAISCOMPRAPASEID";
         edtEspectaculoInvitacionesEntrega_Internalname = sPrefix+"ESPECTACULOINVITACIONESENTREGA";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("ObligatorioPrueba001", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtEspectaculoInvitacionesEntrega_Jsonclick = "";
         edtEspectaculoInvitacionesEntrega_Enabled = 0;
         edtPaisCompraPaseId_Jsonclick = "";
         edtPaisCompraPaseId_Enabled = 0;
         edtSectorId_Jsonclick = "";
         edtSectorId_Enabled = 0;
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 0;
         edtNombreInvitado_Jsonclick = "";
         edtNombreInvitado_Enabled = 0;
         edtPaisCompraPaseNombre_Jsonclick = "";
         edtPaisCompraPaseNombre_Enabled = 0;
         edtSectorPrecio_Jsonclick = "";
         edtSectorPrecio_Enabled = 0;
         edtSectorNombre_Jsonclick = "";
         edtSectorNombre_Enabled = 0;
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 0;
         edtEspectaculoNombre_Jsonclick = "";
         edtEspectaculoNombre_Link = "";
         edtEspectaculoNombre_Enabled = 0;
         cmbPaseTipo_Jsonclick = "";
         cmbPaseTipo.Enabled = 0;
         edtPaseId_Jsonclick = "";
         edtPaseId_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A13PaseId',fld:'PASEID',pic:'ZZZ9'},{av:'cmbPaseTipo'},{av:'A14PaseTipo',fld:'PASETIPO',pic:''},{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110X1',iparms:[{av:'A13PaseId',fld:'PASEID',pic:'ZZZ9'},{av:'cmbPaseTipo'},{av:'A14PaseTipo',fld:'PASETIPO',pic:''}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120X1',iparms:[{av:'A13PaseId',fld:'PASEID',pic:'ZZZ9'},{av:'cmbPaseTipo'},{av:'A14PaseTipo',fld:'PASETIPO',pic:''}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_PASEID","{handler:'Valid_Paseid',iparms:[]");
         setEventMetadata("VALID_PASEID",",oparms:[]}");
         setEventMetadata("VALID_PASETIPO","{handler:'Valid_Pasetipo',iparms:[]");
         setEventMetadata("VALID_PASETIPO",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[]}");
         setEventMetadata("VALID_SECTORID","{handler:'Valid_Sectorid',iparms:[]");
         setEventMetadata("VALID_SECTORID",",oparms:[]}");
         setEventMetadata("VALID_PAISCOMPRAPASEID","{handler:'Valid_Paiscomprapaseid',iparms:[]");
         setEventMetadata("VALID_PAISCOMPRAPASEID",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         wcpOA14PaseTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV14Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A8EspectaculoNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         A21SectorNombre = "";
         A35PaisCompraPaseNombre = "";
         A34NombreInvitado = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000X2_A13PaseId = new short[1] ;
         H000X2_A14PaseTipo = new string[] {""} ;
         H000X2_A33EspectaculoInvitacionesEntrega = new short[1] ;
         H000X2_A15PaisCompraPaseId = new short[1] ;
         H000X2_n15PaisCompraPaseId = new bool[] {false} ;
         H000X2_A9SectorId = new short[1] ;
         H000X2_n9SectorId = new bool[] {false} ;
         H000X2_A5EspectaculoId = new short[1] ;
         H000X2_A34NombreInvitado = new string[] {""} ;
         H000X2_n34NombreInvitado = new bool[] {false} ;
         H000X2_A35PaisCompraPaseNombre = new string[] {""} ;
         H000X2_A23SectorPrecio = new int[1] ;
         H000X2_A21SectorNombre = new string[] {""} ;
         H000X2_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         H000X2_A8EspectaculoNombre = new string[] {""} ;
         hsh = "";
         AV8TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV7PaseTipo = "";
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA13PaseId = "";
         sCtrlA14PaseTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pasegeneral__default(),
            new Object[][] {
                new Object[] {
               H000X2_A13PaseId, H000X2_A14PaseTipo, H000X2_A33EspectaculoInvitacionesEntrega, H000X2_A15PaisCompraPaseId, H000X2_n15PaisCompraPaseId, H000X2_A9SectorId, H000X2_n9SectorId, H000X2_A5EspectaculoId, H000X2_A34NombreInvitado, H000X2_n34NombreInvitado,
               H000X2_A35PaisCompraPaseNombre, H000X2_A23SectorPrecio, H000X2_A21SectorNombre, H000X2_A19EspectaculoFecha, H000X2_A8EspectaculoNombre
               }
            }
         );
         AV14Pgmname = "PaseGeneral";
         /* GeneXus formulas. */
         AV14Pgmname = "PaseGeneral";
         context.Gx_err = 0;
      }

      private short A13PaseId ;
      private short wcpOA13PaseId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A5EspectaculoId ;
      private short wbEnd ;
      private short wbStart ;
      private short A9SectorId ;
      private short A15PaisCompraPaseId ;
      private short A33EspectaculoInvitacionesEntrega ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6PaseId ;
      private short nGXWrapped ;
      private int edtPaseId_Enabled ;
      private int edtEspectaculoNombre_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtSectorNombre_Enabled ;
      private int A23SectorPrecio ;
      private int edtSectorPrecio_Enabled ;
      private int edtPaisCompraPaseNombre_Enabled ;
      private int edtNombreInvitado_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int edtSectorId_Enabled ;
      private int edtPaisCompraPaseId_Enabled ;
      private int edtEspectaculoInvitacionesEntrega_Enabled ;
      private int idxLst ;
      private string A14PaseTipo ;
      private string wcpOA14PaseTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV14Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtPaseId_Internalname ;
      private string edtPaseId_Jsonclick ;
      private string cmbPaseTipo_Internalname ;
      private string cmbPaseTipo_Jsonclick ;
      private string edtEspectaculoNombre_Internalname ;
      private string A8EspectaculoNombre ;
      private string edtEspectaculoNombre_Link ;
      private string edtEspectaculoNombre_Jsonclick ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtSectorNombre_Internalname ;
      private string A21SectorNombre ;
      private string edtSectorNombre_Jsonclick ;
      private string edtSectorPrecio_Internalname ;
      private string edtSectorPrecio_Jsonclick ;
      private string edtPaisCompraPaseNombre_Internalname ;
      private string A35PaisCompraPaseNombre ;
      private string edtPaisCompraPaseNombre_Jsonclick ;
      private string edtNombreInvitado_Internalname ;
      private string A34NombreInvitado ;
      private string edtNombreInvitado_Jsonclick ;
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string edtSectorId_Internalname ;
      private string edtSectorId_Jsonclick ;
      private string edtPaisCompraPaseId_Internalname ;
      private string edtPaisCompraPaseId_Jsonclick ;
      private string edtEspectaculoInvitacionesEntrega_Internalname ;
      private string edtEspectaculoInvitacionesEntrega_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string hsh ;
      private string AV7PaseTipo ;
      private string sCtrlA13PaseId ;
      private string sCtrlA14PaseTipo ;
      private DateTime A19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n15PaisCompraPaseId ;
      private bool n9SectorId ;
      private bool n34NombreInvitado ;
      private bool returnInSub ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPaseTipo ;
      private IDataStoreProvider pr_default ;
      private short[] H000X2_A13PaseId ;
      private string[] H000X2_A14PaseTipo ;
      private short[] H000X2_A33EspectaculoInvitacionesEntrega ;
      private short[] H000X2_A15PaisCompraPaseId ;
      private bool[] H000X2_n15PaisCompraPaseId ;
      private short[] H000X2_A9SectorId ;
      private bool[] H000X2_n9SectorId ;
      private short[] H000X2_A5EspectaculoId ;
      private string[] H000X2_A34NombreInvitado ;
      private bool[] H000X2_n34NombreInvitado ;
      private string[] H000X2_A35PaisCompraPaseNombre ;
      private int[] H000X2_A23SectorPrecio ;
      private string[] H000X2_A21SectorNombre ;
      private DateTime[] H000X2_A19EspectaculoFecha ;
      private string[] H000X2_A8EspectaculoNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV8TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV9TrnContextAtt ;
   }

   public class pasegeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000X2;
          prmH000X2 = new Object[] {
          new ParDef("@PaseId",GXType.Int16,4,0) ,
          new ParDef("@PaseTipo",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000X2", "SELECT T1.[PaseId], T1.[PaseTipo], T3.[EspectaculoInvitacionesEntrega], T1.[PaisCompraPaseId] AS PaisCompraPaseId, T1.[SectorId], T1.[EspectaculoId], T1.[NombreInvitado], T2.[PaisNombre] AS PaisCompraPaseNombre, T4.[SectorPrecio], T4.[SectorNombre], T3.[EspectaculoFecha], T3.[EspectaculoNombre] FROM ((([Pase] T1 LEFT JOIN [Pais] T2 ON T2.[PaisId] = T1.[PaisCompraPaseId]) INNER JOIN [Espectaculo] T3 ON T3.[EspectaculoId] = T1.[EspectaculoId]) LEFT JOIN [EspectaculoSector] T4 ON T4.[EspectaculoId] = T1.[EspectaculoId] AND T4.[SectorId] = T1.[SectorId]) WHERE T1.[PaseId] = @PaseId and T1.[PaseTipo] = @PaseTipo ORDER BY T1.[PaseId], T1.[PaseTipo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X2,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 50);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 60);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 60);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 60);
                return;
       }
    }

 }

}
