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
   public class viewlugar : GXDataArea
   {
      public viewlugar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public viewlugar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_LugarId ,
                           string aP1_TabCode )
      {
         this.AV12LugarId = aP0_LugarId;
         this.AV6TabCode = aP1_TabCode;
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "LugarId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "LugarId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "LugarId");
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
               AV12LugarId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12LugarId", StringUtil.LTrimStr( (decimal)(AV12LugarId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vLUGARID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12LugarId), "ZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV6TabCode = GetPar( "TabCode");
                  AssignAttri("", false, "AV6TabCode", AV6TabCode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6TabCode, "")), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
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

      public override short ExecuteStartEvent( )
      {
         PA082( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START082( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/BasicTabRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("viewlugar.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12LugarId,4,0)),UrlEncode(StringUtil.RTrim(AV6TabCode))}, new string[] {"LugarId","TabCode"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vLUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLUGARID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12LugarId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV6TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6TabCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ViewLugar");
         forbiddenHiddens.Add("LugarNombre", StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("viewlugar:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV11LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV7SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vLUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLUGARID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12LugarId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV6TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "TAB_Activepagecontrolname", StringUtil.RTrim( Tab_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TAB_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tab_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TAB_Class", StringUtil.RTrim( Tab_Class));
         GxWebStd.gx_hidden_field( context, "TAB_Historymanagement", StringUtil.BoolToStr( Tab_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TAB_Activepagecontrolname", StringUtil.RTrim( Tab_Activepagecontrolname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         if ( ! ( WebComp_Generalwc == null ) )
         {
            WebComp_Generalwc.componentjscripts();
         }
         if ( ! ( WebComp_Espectaculowc == null ) )
         {
            WebComp_Espectaculowc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE082( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT082( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("viewlugar.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12LugarId,4,0)),UrlEncode(StringUtil.RTrim(AV6TabCode))}, new string[] {"LugarId","TabCode"})  ;
      }

      public override string GetPgmname( )
      {
         return "ViewLugar" ;
      }

      public override string GetPgmdesc( )
      {
         return "View Lugar" ;
      }

      protected void WB080( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "ww__actions-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__button-back__cell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViewall_Internalname, "Lugares", lblViewall_Link, "", lblViewall_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ww__view__button-back", 0, "", lblViewall_Visible, 1, 0, 0, "HLP_ViewLugar.htm");
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
            GxWebStd.gx_div_start( context, divTablefixeddata_1_Internalname, 1, 0, "px", 0, "px", "Flex ww__view__title-table", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLugarNombre_Internalname, "Nombre", "gx-form-item heading-01Label", 0, true, "width: 25%;");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLugarNombre_Internalname, StringUtil.RTrim( A4LugarNombre), StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarNombre_Jsonclick, 0, "heading-01", "", "", "", "", 1, edtLugarNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ViewLugar.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTab.SetProperty("PageCount", Tab_Pagecount);
            ucTab.SetProperty("Class", Tab_Class);
            ucTab.SetProperty("HistoryManagement", Tab_Historymanagement);
            ucTab.Render(context, "basictab", Tab_Internalname, "TABContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "General", "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ViewLugar.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegeneral_Internalname, 1, 0, "px", 0, "px", "ww__view__tab__form-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0026"+"", StringUtil.RTrim( WebComp_Generalwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0026"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
                  }
                  WebComp_Generalwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEspectaculo_title_Internalname, "Espectaculo", "", "", lblEspectaculo_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ViewLugar.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Espectaculo") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableespectaculo_Internalname, 1, 0, "px", 0, "px", "ww__view__tab__form-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0034"+"", StringUtil.RTrim( WebComp_Espectaculowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0034"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Espectaculowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldEspectaculowc), StringUtil.Lower( WebComp_Espectaculowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
                  }
                  WebComp_Espectaculowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldEspectaculowc), StringUtil.Lower( WebComp_Espectaculowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START082( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_3-171579", 0) ;
            }
            Form.Meta.addItem("description", "View Lugar", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP080( ) ;
      }

      protected void WS082( )
      {
         START082( ) ;
         EVT082( ) ;
      }

      protected void EVT082( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11082 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12082 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 26 )
                        {
                           OldGeneralwc = cgiGet( "W0026");
                           if ( ( StringUtil.Len( OldGeneralwc) == 0 ) || ( StringUtil.StrCmp(OldGeneralwc, WebComp_Generalwc_Component) != 0 ) )
                           {
                              WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", OldGeneralwc, new Object[] {context} );
                              WebComp_Generalwc.ComponentInit();
                              WebComp_Generalwc.Name = "OldGeneralwc";
                              WebComp_Generalwc_Component = OldGeneralwc;
                           }
                           if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
                           {
                              WebComp_Generalwc.componentprocess("W0026", "", sEvt);
                           }
                           WebComp_Generalwc_Component = OldGeneralwc;
                        }
                        else if ( nCmpId == 34 )
                        {
                           OldEspectaculowc = cgiGet( "W0034");
                           if ( ( StringUtil.Len( OldEspectaculowc) == 0 ) || ( StringUtil.StrCmp(OldEspectaculowc, WebComp_Espectaculowc_Component) != 0 ) )
                           {
                              WebComp_Espectaculowc = getWebComponent(GetType(), "GeneXus.Programs", OldEspectaculowc, new Object[] {context} );
                              WebComp_Espectaculowc.ComponentInit();
                              WebComp_Espectaculowc.Name = "OldEspectaculowc";
                              WebComp_Espectaculowc_Component = OldEspectaculowc;
                           }
                           if ( StringUtil.Len( WebComp_Espectaculowc_Component) != 0 )
                           {
                              WebComp_Espectaculowc.componentprocess("W0034", "", sEvt);
                           }
                           WebComp_Espectaculowc_Component = OldEspectaculowc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE082( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA082( )
      {
         if ( nDonePA == 0 )
         {
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF082( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "ViewLugar";
         context.Gx_err = 0;
      }

      protected void RF082( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  WebComp_Generalwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Espectaculowc_Component) != 0 )
               {
                  WebComp_Espectaculowc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00082 */
            pr_default.execute(0, new Object[] {AV12LugarId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A3LugarId = H00082_A3LugarId[0];
               A4LugarNombre = H00082_A4LugarNombre[0];
               AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
               /* Execute user event: Load */
               E12082 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB080( ) ;
         }
      }

      protected void send_integrity_lvl_hashes082( )
      {
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "ViewLugar";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP080( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11082 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV12LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vLUGARID"), ",", "."), 18, MidpointRounding.ToEven));
            AV11LoadAllTabs = StringUtil.StrToBool( cgiGet( "vLOADALLTABS"));
            AV7SelectedTabCode = cgiGet( "vSELECTEDTABCODE");
            Tab_Activepagecontrolname = cgiGet( "TAB_Activepagecontrolname");
            Tab_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TAB_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Tab_Class = cgiGet( "TAB_Class");
            Tab_Historymanagement = StringUtil.StrToBool( cgiGet( "TAB_Historymanagement"));
            /* Read variables values. */
            A4LugarNombre = cgiGet( edtLugarNombre_Internalname);
            AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ViewLugar");
            A4LugarNombre = cgiGet( edtLugarNombre_Internalname);
            AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
            forbiddenHiddens.Add("LugarNombre", StringUtil.RTrim( context.localUtil.Format( A4LugarNombre, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("viewlugar:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E11082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11082( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV16GXLvl7 = 0;
         /* Using cursor H00083 */
         pr_default.execute(1, new Object[] {AV12LugarId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A3LugarId = H00083_A3LugarId[0];
            A4LugarNombre = H00083_A4LugarNombre[0];
            AssignAttri("", false, "A4LugarNombre", A4LugarNombre);
            AV16GXLvl7 = 1;
            Form.Caption = A4LugarNombre;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            lblViewall_Link = formatLink("wwlugar.aspx") ;
            AssignProp("", false, lblViewall_Internalname, "Link", lblViewall_Link, true);
            AV10Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV16GXLvl7 == 0 )
         {
            Form.Caption = "Record not found";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            lblViewall_Visible = 0;
            AssignProp("", false, lblViewall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblViewall_Visible), 5, 0), true);
            AV10Exists = false;
         }
         AV11LoadAllTabs = false;
         AssignAttri("", false, "AV11LoadAllTabs", AV11LoadAllTabs);
         if ( AV10Exists )
         {
            AV7SelectedTabCode = AV6TabCode;
            AssignAttri("", false, "AV7SelectedTabCode", AV7SelectedTabCode);
            Tab_Activepagecontrolname = AV7SelectedTabCode;
            ucTab.SendProperty(context, "", false, Tab_Internalname, "ActivePageControlName", Tab_Activepagecontrolname);
            /* Execute user subroutine: 'LOAD TAB' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S112( )
      {
         /* 'LOAD TAB' Routine */
         returnInSub = false;
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV7SelectedTabCode, "General") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Generalwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Generalwc_Component), StringUtil.Lower( "LugarGeneral")) != 0 )
            {
               WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", "lugargeneral", new Object[] {context} );
               WebComp_Generalwc.ComponentInit();
               WebComp_Generalwc.Name = "LugarGeneral";
               WebComp_Generalwc_Component = "LugarGeneral";
            }
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.setjustcreated();
               WebComp_Generalwc.componentprepare(new Object[] {(string)"W0026",(string)"",(short)AV12LugarId});
               WebComp_Generalwc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Generalwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
               WebComp_Generalwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV7SelectedTabCode, "Espectaculo") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Espectaculowc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Espectaculowc_Component), StringUtil.Lower( "LugarEspectaculoWC")) != 0 )
            {
               WebComp_Espectaculowc = getWebComponent(GetType(), "GeneXus.Programs", "lugarespectaculowc", new Object[] {context} );
               WebComp_Espectaculowc.ComponentInit();
               WebComp_Espectaculowc.Name = "LugarEspectaculoWC";
               WebComp_Espectaculowc_Component = "LugarEspectaculoWC";
            }
            if ( StringUtil.Len( WebComp_Espectaculowc_Component) != 0 )
            {
               WebComp_Espectaculowc.setjustcreated();
               WebComp_Espectaculowc.componentprepare(new Object[] {(string)"W0034",(string)"",(short)AV12LugarId});
               WebComp_Espectaculowc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Espectaculowc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
               WebComp_Espectaculowc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12082( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12LugarId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV12LugarId", StringUtil.LTrimStr( (decimal)(AV12LugarId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLUGARID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12LugarId), "ZZZ9"), context));
         AV6TabCode = (string)getParm(obj,1);
         AssignAttri("", false, "AV6TabCode", AV6TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6TabCode, "")), context));
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
         PA082( ) ;
         WS082( ) ;
         WE082( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("Tab/BasicTab.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Generalwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Espectaculowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Espectaculowc_Component) != 0 )
            {
               WebComp_Espectaculowc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874412447", true, true);
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
         context.AddJavascriptSource("viewlugar.js", "?2023874412447", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/BasicTabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblViewall_Internalname = "VIEWALL";
         divTabletop_Internalname = "TABLETOP";
         edtLugarNombre_Internalname = "LUGARNOMBRE";
         divTablefixeddata_1_Internalname = "TABLEFIXEDDATA_1";
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         divTablegeneral_Internalname = "TABLEGENERAL";
         lblEspectaculo_title_Internalname = "ESPECTACULO_TITLE";
         divTableespectaculo_Internalname = "TABLEESPECTACULO";
         Tab_Internalname = "TAB";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtLugarNombre_Jsonclick = "";
         edtLugarNombre_Enabled = 0;
         lblViewall_Link = "";
         lblViewall_Visible = 1;
         Tab_Historymanagement = Convert.ToBoolean( -1);
         Tab_Class = "ww__view__tab";
         Tab_Pagecount = 2;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "View Lugar";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV12LugarId',fld:'vLUGARID',pic:'ZZZ9',hsh:true},{av:'AV6TabCode',fld:'vTABCODE',pic:'',hsh:true},{av:'A4LugarNombre',fld:'LUGARNOMBRE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
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
         wcpOAV6TabCode = "";
         Tab_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         A4LugarNombre = "";
         AV7SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblViewall_Jsonclick = "";
         ucTab = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         WebComp_Generalwc_Component = "";
         OldGeneralwc = "";
         lblEspectaculo_title_Jsonclick = "";
         WebComp_Espectaculowc_Component = "";
         OldEspectaculowc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV15Pgmname = "";
         scmdbuf = "";
         H00082_A3LugarId = new short[1] ;
         H00082_A4LugarNombre = new string[] {""} ;
         hsh = "";
         H00083_A3LugarId = new short[1] ;
         H00083_A4LugarNombre = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.viewlugar__default(),
            new Object[][] {
                new Object[] {
               H00082_A3LugarId, H00082_A4LugarNombre
               }
               , new Object[] {
               H00083_A3LugarId, H00083_A4LugarNombre
               }
            }
         );
         WebComp_Generalwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Espectaculowc = new GeneXus.Http.GXNullWebComponent();
         AV15Pgmname = "ViewLugar";
         /* GeneXus formulas. */
         AV15Pgmname = "ViewLugar";
         context.Gx_err = 0;
      }

      private short AV12LugarId ;
      private short wcpOAV12LugarId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A3LugarId ;
      private short AV16GXLvl7 ;
      private short nGXWrapped ;
      private int Tab_Pagecount ;
      private int lblViewall_Visible ;
      private int edtLugarNombre_Enabled ;
      private int idxLst ;
      private string AV6TabCode ;
      private string wcpOAV6TabCode ;
      private string Tab_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A4LugarNombre ;
      private string AV7SelectedTabCode ;
      private string Tab_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblViewall_Internalname ;
      private string lblViewall_Link ;
      private string lblViewall_Jsonclick ;
      private string divTablefixeddata_1_Internalname ;
      private string edtLugarNombre_Internalname ;
      private string edtLugarNombre_Jsonclick ;
      private string Tab_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divTablegeneral_Internalname ;
      private string WebComp_Generalwc_Component ;
      private string OldGeneralwc ;
      private string lblEspectaculo_title_Internalname ;
      private string lblEspectaculo_title_Jsonclick ;
      private string divTableespectaculo_Internalname ;
      private string WebComp_Espectaculowc_Component ;
      private string OldEspectaculowc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV15Pgmname ;
      private string scmdbuf ;
      private string hsh ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11LoadAllTabs ;
      private bool Tab_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV10Exists ;
      private bool bDynCreated_Generalwc ;
      private bool bDynCreated_Espectaculowc ;
      private GXWebComponent WebComp_Generalwc ;
      private GXWebComponent WebComp_Espectaculowc ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucTab ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00082_A3LugarId ;
      private string[] H00082_A4LugarNombre ;
      private short[] H00083_A3LugarId ;
      private string[] H00083_A4LugarNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class viewlugar__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00082;
          prmH00082 = new Object[] {
          new ParDef("@AV12LugarId",GXType.Int16,4,0)
          };
          Object[] prmH00083;
          prmH00083 = new Object[] {
          new ParDef("@AV12LugarId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00082", "SELECT [LugarId], [LugarNombre] FROM [Lugar] WHERE [LugarId] = @AV12LugarId ORDER BY [LugarId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00082,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00083", "SELECT [LugarId], [LugarNombre] FROM [Lugar] WHERE [LugarId] = @AV12LugarId ORDER BY [LugarId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00083,1, GxCacheFrequency.OFF ,false,true )
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
       }
    }

 }

}
