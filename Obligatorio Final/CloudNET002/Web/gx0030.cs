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
   public class gx0030 : GXDataArea
   {
      public gx0030( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public gx0030( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pEspectaculoId )
      {
         this.AV13pEspectaculoId = 0 ;
         executePrivate();
         aP0_pEspectaculoId=this.AV13pEspectaculoId;
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
            gxfirstwebparm = GetFirstPar( "pEspectaculoId");
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
               gxfirstwebparm = GetFirstPar( "pEspectaculoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pEspectaculoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
               AV13pEspectaculoId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pEspectaculoId", StringUtil.LTrimStr( (decimal)(AV13pEspectaculoId), 4, 0));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cEspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "cEspectaculoId"), "."), 18, MidpointRounding.ToEven));
         AV7cEspectaculoNombre = GetPar( "cEspectaculoNombre");
         AV8cEspectaculoFecha = context.localUtil.ParseDateParm( GetPar( "cEspectaculoFecha"));
         AV9cTipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "cTipoEspectaculoId"), "."), 18, MidpointRounding.ToEven));
         AV10cLugarId = (short)(Math.Round(NumberUtil.Val( GetPar( "cLugarId"), "."), 18, MidpointRounding.ToEven));
         AV11cPaisOrigenId = (short)(Math.Round(NumberUtil.Val( GetPar( "cPaisOrigenId"), "."), 18, MidpointRounding.ToEven));
         AV12cEspectaculoCantidadInvitaciones = (short)(Math.Round(NumberUtil.Val( GetPar( "cEspectaculoCantidadInvitaciones"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoId, AV7cEspectaculoNombre, AV8cEspectaculoFecha, AV9cTipoEspectaculoId, AV10cLugarId, AV11cPaisOrigenId, AV12cEspectaculoCantidadInvitaciones) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA182( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START182( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0030.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pEspectaculoId,4,0))}, new string[] {"pEspectaculoId"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULONOMBRE", StringUtil.RTrim( AV7cEspectaculoNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULOFECHA", context.localUtil.Format(AV8cEspectaculoFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cTipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cLugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPAISORIGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cPaisOrigenId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULOCANTIDADINVITACIONES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cEspectaculoCantidadInvitaciones), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOIDFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculonombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculofechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPOESPECTACULOIDFILTERCONTAINER_Class", StringUtil.RTrim( divTipoespectaculoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "LUGARIDFILTERCONTAINER_Class", StringUtil.RTrim( divLugaridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAISORIGENIDFILTERCONTAINER_Class", StringUtil.RTrim( divPaisorigenidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOCANTIDADINVITACIONESFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculocantidadinvitacionesfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE182( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT182( ) ;
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
         return formatLink("gx0030.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pEspectaculoId,4,0))}, new string[] {"pEspectaculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0030" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Espectaculo" ;
      }

      protected void WB180( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEspectaculoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculoidfilter_Internalname, "Espectaculo Id", "", "", lblLblespectaculoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11181_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculoid_Internalname, "Espectaculo Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCespectaculoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cEspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCespectaculoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cEspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cEspectaculoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCespectaculoid_Visible, edtavCespectaculoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divEspectaculonombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculonombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculonombrefilter_Internalname, "Espectaculo Nombre", "", "", lblLblespectaculonombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12181_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculonombre_Internalname, "Espectaculo Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCespectaculonombre_Internalname, StringUtil.RTrim( AV7cEspectaculoNombre), StringUtil.RTrim( context.localUtil.Format( AV7cEspectaculoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculonombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCespectaculonombre_Visible, edtavCespectaculonombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divEspectaculofechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculofechafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculofechafilter_Internalname, "Espectaculo Fecha", "", "", lblLblespectaculofechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13181_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculofecha_Internalname, "Espectaculo Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCespectaculofecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCespectaculofecha_Internalname, context.localUtil.Format(AV8cEspectaculoFecha, "99/99/99"), context.localUtil.Format( AV8cEspectaculoFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculofecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCespectaculofecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0030.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTipoespectaculoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTipoespectaculoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltipoespectaculoidfilter_Internalname, "Tipo Espectaculo Id", "", "", lblLbltipoespectaculoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14181_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtipoespectaculoid_Internalname, "Tipo Espectaculo Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtipoespectaculoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cTipoEspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCtipoespectaculoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cTipoEspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV9cTipoEspectaculoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtipoespectaculoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtipoespectaculoid_Visible, edtavCtipoespectaculoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divLugaridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divLugaridfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbllugaridfilter_Internalname, "Lugar Id", "", "", lblLbllugaridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15181_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClugarid_Internalname, "Lugar Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClugarid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cLugarId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavClugarid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cLugarId), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cLugarId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClugarid_Jsonclick, 0, "Attribute", "", "", "", "", edtavClugarid_Visible, edtavClugarid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divPaisorigenidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaisorigenidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaisorigenidfilter_Internalname, "Pais Origen Id", "", "", lblLblpaisorigenidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16181_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpaisorigenid_Internalname, "Pais Origen Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaisorigenid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cPaisOrigenId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCpaisorigenid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cPaisOrigenId), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cPaisOrigenId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaisorigenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaisorigenid_Visible, edtavCpaisorigenid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0030.htm");
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
            GxWebStd.gx_div_start( context, divEspectaculocantidadinvitacionesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculocantidadinvitacionesfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculocantidadinvitacionesfilter_Internalname, "Espectaculo Cantidad Invitaciones", "", "", lblLblespectaculocantidadinvitacionesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17181_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculocantidadinvitaciones_Internalname, "Espectaculo Cantidad Invitaciones", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCespectaculocantidadinvitaciones_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cEspectaculoCantidadInvitaciones), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCespectaculocantidadinvitaciones_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cEspectaculoCantidadInvitaciones), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cEspectaculoCantidadInvitaciones), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculocantidadinvitaciones_Jsonclick, 0, "Attribute", "", "", "", "", edtavCespectaculocantidadinvitaciones_Visible, edtavCespectaculocantidadinvitaciones_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18181_client"+"'", TempTags, "", 2, "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0030.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START182( )
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
            Form.Meta.addItem("description", "Selection List Espectaculo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP180( ) ;
      }

      protected void WS182( )
      {
         START182( ) ;
         EVT182( ) ;
      }

      protected void EVT182( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A8EspectaculoNombre = cgiGet( edtEspectaculoNombre_Internalname);
                              A19EspectaculoFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtEspectaculoFecha_Internalname), 0));
                              A6TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A3LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19182 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20182 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cespectaculoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOID"), ",", ".") != Convert.ToDecimal( AV6cEspectaculoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cespectaculonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESPECTACULONOMBRE"), AV7cEspectaculoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cespectaculofecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCESPECTACULOFECHA"), 0) != AV8cEspectaculoFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctipoespectaculoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTIPOESPECTACULOID"), ",", ".") != Convert.ToDecimal( AV9cTipoEspectaculoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clugarid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCLUGARID"), ",", ".") != Convert.ToDecimal( AV10cLugarId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaisorigenid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAISORIGENID"), ",", ".") != Convert.ToDecimal( AV11cPaisOrigenId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cespectaculocantidadinvitaciones Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOCANTIDADINVITACIONES"), ",", ".") != Convert.ToDecimal( AV12cEspectaculoCantidadInvitaciones )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21182 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE182( )
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

      protected void PA182( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cEspectaculoId ,
                                        string AV7cEspectaculoNombre ,
                                        DateTime AV8cEspectaculoFecha ,
                                        short AV9cTipoEspectaculoId ,
                                        short AV10cLugarId ,
                                        short AV11cPaisOrigenId ,
                                        short AV12cEspectaculoCantidadInvitaciones )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF182( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ".", "")));
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
         RF182( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF182( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cEspectaculoNombre ,
                                                 AV8cEspectaculoFecha ,
                                                 AV9cTipoEspectaculoId ,
                                                 AV10cLugarId ,
                                                 AV11cPaisOrigenId ,
                                                 AV12cEspectaculoCantidadInvitaciones ,
                                                 A8EspectaculoNombre ,
                                                 A19EspectaculoFecha ,
                                                 A6TipoEspectaculoId ,
                                                 A3LugarId ,
                                                 A7PaisOrigenId ,
                                                 A31EspectaculoCantidadInvitacione ,
                                                 AV6cEspectaculoId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT
                                                 }
            });
            lV7cEspectaculoNombre = StringUtil.PadR( StringUtil.RTrim( AV7cEspectaculoNombre), 60, "%");
            /* Using cursor H00182 */
            pr_default.execute(0, new Object[] {AV6cEspectaculoId, lV7cEspectaculoNombre, AV8cEspectaculoFecha, AV9cTipoEspectaculoId, AV10cLugarId, AV11cPaisOrigenId, AV12cEspectaculoCantidadInvitaciones, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A31EspectaculoCantidadInvitacione = H00182_A31EspectaculoCantidadInvitacione[0];
               A7PaisOrigenId = H00182_A7PaisOrigenId[0];
               A3LugarId = H00182_A3LugarId[0];
               A6TipoEspectaculoId = H00182_A6TipoEspectaculoId[0];
               A19EspectaculoFecha = H00182_A19EspectaculoFecha[0];
               A8EspectaculoNombre = H00182_A8EspectaculoNombre[0];
               A5EspectaculoId = H00182_A5EspectaculoId[0];
               /* Execute user event: Load */
               E20182 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB180( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes182( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ESPECTACULOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cEspectaculoNombre ,
                                              AV8cEspectaculoFecha ,
                                              AV9cTipoEspectaculoId ,
                                              AV10cLugarId ,
                                              AV11cPaisOrigenId ,
                                              AV12cEspectaculoCantidadInvitaciones ,
                                              A8EspectaculoNombre ,
                                              A19EspectaculoFecha ,
                                              A6TipoEspectaculoId ,
                                              A3LugarId ,
                                              A7PaisOrigenId ,
                                              A31EspectaculoCantidadInvitacione ,
                                              AV6cEspectaculoId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV7cEspectaculoNombre = StringUtil.PadR( StringUtil.RTrim( AV7cEspectaculoNombre), 60, "%");
         /* Using cursor H00183 */
         pr_default.execute(1, new Object[] {AV6cEspectaculoId, lV7cEspectaculoNombre, AV8cEspectaculoFecha, AV9cTipoEspectaculoId, AV10cLugarId, AV11cPaisOrigenId, AV12cEspectaculoCantidadInvitaciones});
         GRID1_nRecordCount = H00183_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoId, AV7cEspectaculoNombre, AV8cEspectaculoFecha, AV9cTipoEspectaculoId, AV10cLugarId, AV11cPaisOrigenId, AV12cEspectaculoCantidadInvitaciones) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoId, AV7cEspectaculoNombre, AV8cEspectaculoFecha, AV9cTipoEspectaculoId, AV10cLugarId, AV11cPaisOrigenId, AV12cEspectaculoCantidadInvitaciones) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoId, AV7cEspectaculoNombre, AV8cEspectaculoFecha, AV9cTipoEspectaculoId, AV10cLugarId, AV11cPaisOrigenId, AV12cEspectaculoCantidadInvitaciones) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoId, AV7cEspectaculoNombre, AV8cEspectaculoFecha, AV9cTipoEspectaculoId, AV10cLugarId, AV11cPaisOrigenId, AV12cEspectaculoCantidadInvitaciones) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoId, AV7cEspectaculoNombre, AV8cEspectaculoFecha, AV9cTipoEspectaculoId, AV10cLugarId, AV11cPaisOrigenId, AV12cEspectaculoCantidadInvitaciones) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP180( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19182 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCespectaculoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCespectaculoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESPECTACULOID");
               GX_FocusControl = edtavCespectaculoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cEspectaculoId = 0;
               AssignAttri("", false, "AV6cEspectaculoId", StringUtil.LTrimStr( (decimal)(AV6cEspectaculoId), 4, 0));
            }
            else
            {
               AV6cEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCespectaculoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cEspectaculoId", StringUtil.LTrimStr( (decimal)(AV6cEspectaculoId), 4, 0));
            }
            AV7cEspectaculoNombre = cgiGet( edtavCespectaculonombre_Internalname);
            AssignAttri("", false, "AV7cEspectaculoNombre", AV7cEspectaculoNombre);
            if ( context.localUtil.VCDate( cgiGet( edtavCespectaculofecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Espectaculo Fecha"}), 1, "vCESPECTACULOFECHA");
               GX_FocusControl = edtavCespectaculofecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cEspectaculoFecha = DateTime.MinValue;
               AssignAttri("", false, "AV8cEspectaculoFecha", context.localUtil.Format(AV8cEspectaculoFecha, "99/99/99"));
            }
            else
            {
               AV8cEspectaculoFecha = context.localUtil.CToD( cgiGet( edtavCespectaculofecha_Internalname), 2);
               AssignAttri("", false, "AV8cEspectaculoFecha", context.localUtil.Format(AV8cEspectaculoFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtipoespectaculoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtipoespectaculoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTIPOESPECTACULOID");
               GX_FocusControl = edtavCtipoespectaculoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cTipoEspectaculoId = 0;
               AssignAttri("", false, "AV9cTipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV9cTipoEspectaculoId), 4, 0));
            }
            else
            {
               AV9cTipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCtipoespectaculoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cTipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV9cTipoEspectaculoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavClugarid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavClugarid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCLUGARID");
               GX_FocusControl = edtavClugarid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cLugarId = 0;
               AssignAttri("", false, "AV10cLugarId", StringUtil.LTrimStr( (decimal)(AV10cLugarId), 4, 0));
            }
            else
            {
               AV10cLugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavClugarid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cLugarId", StringUtil.LTrimStr( (decimal)(AV10cLugarId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpaisorigenid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpaisorigenid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPAISORIGENID");
               GX_FocusControl = edtavCpaisorigenid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cPaisOrigenId = 0;
               AssignAttri("", false, "AV11cPaisOrigenId", StringUtil.LTrimStr( (decimal)(AV11cPaisOrigenId), 4, 0));
            }
            else
            {
               AV11cPaisOrigenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCpaisorigenid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cPaisOrigenId", StringUtil.LTrimStr( (decimal)(AV11cPaisOrigenId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCespectaculocantidadinvitaciones_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCespectaculocantidadinvitaciones_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESPECTACULOCANTIDADINVITACIONES");
               GX_FocusControl = edtavCespectaculocantidadinvitaciones_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cEspectaculoCantidadInvitaciones = 0;
               AssignAttri("", false, "AV12cEspectaculoCantidadInvitaciones", StringUtil.LTrimStr( (decimal)(AV12cEspectaculoCantidadInvitaciones), 4, 0));
            }
            else
            {
               AV12cEspectaculoCantidadInvitaciones = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCespectaculocantidadinvitaciones_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cEspectaculoCantidadInvitaciones", StringUtil.LTrimStr( (decimal)(AV12cEspectaculoCantidadInvitaciones), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOID"), ",", ".") != Convert.ToDecimal( AV6cEspectaculoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESPECTACULONOMBRE"), AV7cEspectaculoNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCESPECTACULOFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV8cEspectaculoFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTIPOESPECTACULOID"), ",", ".") != Convert.ToDecimal( AV9cTipoEspectaculoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCLUGARID"), ",", ".") != Convert.ToDecimal( AV10cLugarId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAISORIGENID"), ",", ".") != Convert.ToDecimal( AV11cPaisOrigenId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOCANTIDADINVITACIONES"), ",", ".") != Convert.ToDecimal( AV12cEspectaculoCantidadInvitaciones )) )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E19182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19182( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Espectaculo", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20182( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21182( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pEspectaculoId = A5EspectaculoId;
         AssignAttri("", false, "AV13pEspectaculoId", StringUtil.LTrimStr( (decimal)(AV13pEspectaculoId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pEspectaculoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pEspectaculoId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pEspectaculoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pEspectaculoId", StringUtil.LTrimStr( (decimal)(AV13pEspectaculoId), 4, 0));
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
         PA182( ) ;
         WS182( ) ;
         WE182( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874412679", true, true);
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
         context.AddJavascriptSource("gx0030.js", "?2023874412679", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtEspectaculoId_Internalname = "ESPECTACULOID_"+sGXsfl_84_idx;
         edtEspectaculoNombre_Internalname = "ESPECTACULONOMBRE_"+sGXsfl_84_idx;
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA_"+sGXsfl_84_idx;
         edtTipoEspectaculoId_Internalname = "TIPOESPECTACULOID_"+sGXsfl_84_idx;
         edtLugarId_Internalname = "LUGARID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtEspectaculoId_Internalname = "ESPECTACULOID_"+sGXsfl_84_fel_idx;
         edtEspectaculoNombre_Internalname = "ESPECTACULONOMBRE_"+sGXsfl_84_fel_idx;
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA_"+sGXsfl_84_fel_idx;
         edtTipoEspectaculoId_Internalname = "TIPOESPECTACULOID_"+sGXsfl_84_fel_idx;
         edtLugarId_Internalname = "LUGARID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB180( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtEspectaculoNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtEspectaculoNombre_Internalname, "Link", edtEspectaculoNombre_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoNombre_Internalname,StringUtil.RTrim( A8EspectaculoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEspectaculoNombre_Link,(string)"",(string)"",(string)"",(string)edtEspectaculoNombre_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoFecha_Internalname,context.localUtil.Format(A19EspectaculoFecha, "99/99/99"),context.localUtil.Format( A19EspectaculoFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoEspectaculoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6TipoEspectaculoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A6TipoEspectaculoId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoEspectaculoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A3LugarId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A3LugarId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes182( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Fecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo Espectaculo Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Lugar Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A8EspectaculoNombre)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtEspectaculoNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A19EspectaculoFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A6TipoEspectaculoId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3LugarId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblespectaculoidfilter_Internalname = "LBLESPECTACULOIDFILTER";
         edtavCespectaculoid_Internalname = "vCESPECTACULOID";
         divEspectaculoidfiltercontainer_Internalname = "ESPECTACULOIDFILTERCONTAINER";
         lblLblespectaculonombrefilter_Internalname = "LBLESPECTACULONOMBREFILTER";
         edtavCespectaculonombre_Internalname = "vCESPECTACULONOMBRE";
         divEspectaculonombrefiltercontainer_Internalname = "ESPECTACULONOMBREFILTERCONTAINER";
         lblLblespectaculofechafilter_Internalname = "LBLESPECTACULOFECHAFILTER";
         edtavCespectaculofecha_Internalname = "vCESPECTACULOFECHA";
         divEspectaculofechafiltercontainer_Internalname = "ESPECTACULOFECHAFILTERCONTAINER";
         lblLbltipoespectaculoidfilter_Internalname = "LBLTIPOESPECTACULOIDFILTER";
         edtavCtipoespectaculoid_Internalname = "vCTIPOESPECTACULOID";
         divTipoespectaculoidfiltercontainer_Internalname = "TIPOESPECTACULOIDFILTERCONTAINER";
         lblLbllugaridfilter_Internalname = "LBLLUGARIDFILTER";
         edtavClugarid_Internalname = "vCLUGARID";
         divLugaridfiltercontainer_Internalname = "LUGARIDFILTERCONTAINER";
         lblLblpaisorigenidfilter_Internalname = "LBLPAISORIGENIDFILTER";
         edtavCpaisorigenid_Internalname = "vCPAISORIGENID";
         divPaisorigenidfiltercontainer_Internalname = "PAISORIGENIDFILTERCONTAINER";
         lblLblespectaculocantidadinvitacionesfilter_Internalname = "LBLESPECTACULOCANTIDADINVITACIONESFILTER";
         edtavCespectaculocantidadinvitaciones_Internalname = "vCESPECTACULOCANTIDADINVITACIONES";
         divEspectaculocantidadinvitacionesfiltercontainer_Internalname = "ESPECTACULOCANTIDADINVITACIONESFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoNombre_Internalname = "ESPECTACULONOMBRE";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtTipoEspectaculoId_Internalname = "TIPOESPECTACULOID";
         edtLugarId_Internalname = "LUGARID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioPrueba001", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtLugarId_Jsonclick = "";
         edtTipoEspectaculoId_Jsonclick = "";
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoNombre_Jsonclick = "";
         edtEspectaculoNombre_Link = "";
         edtEspectaculoId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCespectaculocantidadinvitaciones_Jsonclick = "";
         edtavCespectaculocantidadinvitaciones_Enabled = 1;
         edtavCespectaculocantidadinvitaciones_Visible = 1;
         edtavCpaisorigenid_Jsonclick = "";
         edtavCpaisorigenid_Enabled = 1;
         edtavCpaisorigenid_Visible = 1;
         edtavClugarid_Jsonclick = "";
         edtavClugarid_Enabled = 1;
         edtavClugarid_Visible = 1;
         edtavCtipoespectaculoid_Jsonclick = "";
         edtavCtipoespectaculoid_Enabled = 1;
         edtavCtipoespectaculoid_Visible = 1;
         edtavCespectaculofecha_Jsonclick = "";
         edtavCespectaculofecha_Enabled = 1;
         edtavCespectaculonombre_Jsonclick = "";
         edtavCespectaculonombre_Enabled = 1;
         edtavCespectaculonombre_Visible = 1;
         edtavCespectaculoid_Jsonclick = "";
         edtavCespectaculoid_Enabled = 1;
         edtavCespectaculoid_Visible = 1;
         divEspectaculocantidadinvitacionesfiltercontainer_Class = "AdvancedContainerItem";
         divPaisorigenidfiltercontainer_Class = "AdvancedContainerItem";
         divLugaridfiltercontainer_Class = "AdvancedContainerItem";
         divTipoespectaculoidfiltercontainer_Class = "AdvancedContainerItem";
         divEspectaculofechafiltercontainer_Class = "AdvancedContainerItem";
         divEspectaculonombrefiltercontainer_Class = "AdvancedContainerItem";
         divEspectaculoidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Espectaculo";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoId',fld:'vCESPECTACULOID',pic:'ZZZ9'},{av:'AV7cEspectaculoNombre',fld:'vCESPECTACULONOMBRE',pic:''},{av:'AV8cEspectaculoFecha',fld:'vCESPECTACULOFECHA',pic:''},{av:'AV9cTipoEspectaculoId',fld:'vCTIPOESPECTACULOID',pic:'ZZZ9'},{av:'AV10cLugarId',fld:'vCLUGARID',pic:'ZZZ9'},{av:'AV11cPaisOrigenId',fld:'vCPAISORIGENID',pic:'ZZZ9'},{av:'AV12cEspectaculoCantidadInvitaciones',fld:'vCESPECTACULOCANTIDADINVITACIONES',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18181',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLESPECTACULOIDFILTER.CLICK","{handler:'E11181',iparms:[{av:'divEspectaculoidfiltercontainer_Class',ctrl:'ESPECTACULOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULOIDFILTER.CLICK",",oparms:[{av:'divEspectaculoidfiltercontainer_Class',ctrl:'ESPECTACULOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCespectaculoid_Visible',ctrl:'vCESPECTACULOID',prop:'Visible'}]}");
         setEventMetadata("LBLESPECTACULONOMBREFILTER.CLICK","{handler:'E12181',iparms:[{av:'divEspectaculonombrefiltercontainer_Class',ctrl:'ESPECTACULONOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULONOMBREFILTER.CLICK",",oparms:[{av:'divEspectaculonombrefiltercontainer_Class',ctrl:'ESPECTACULONOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCespectaculonombre_Visible',ctrl:'vCESPECTACULONOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLESPECTACULOFECHAFILTER.CLICK","{handler:'E13181',iparms:[{av:'divEspectaculofechafiltercontainer_Class',ctrl:'ESPECTACULOFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULOFECHAFILTER.CLICK",",oparms:[{av:'divEspectaculofechafiltercontainer_Class',ctrl:'ESPECTACULOFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTIPOESPECTACULOIDFILTER.CLICK","{handler:'E14181',iparms:[{av:'divTipoespectaculoidfiltercontainer_Class',ctrl:'TIPOESPECTACULOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPOESPECTACULOIDFILTER.CLICK",",oparms:[{av:'divTipoespectaculoidfiltercontainer_Class',ctrl:'TIPOESPECTACULOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtipoespectaculoid_Visible',ctrl:'vCTIPOESPECTACULOID',prop:'Visible'}]}");
         setEventMetadata("LBLLUGARIDFILTER.CLICK","{handler:'E15181',iparms:[{av:'divLugaridfiltercontainer_Class',ctrl:'LUGARIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLLUGARIDFILTER.CLICK",",oparms:[{av:'divLugaridfiltercontainer_Class',ctrl:'LUGARIDFILTERCONTAINER',prop:'Class'},{av:'edtavClugarid_Visible',ctrl:'vCLUGARID',prop:'Visible'}]}");
         setEventMetadata("LBLPAISORIGENIDFILTER.CLICK","{handler:'E16181',iparms:[{av:'divPaisorigenidfiltercontainer_Class',ctrl:'PAISORIGENIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAISORIGENIDFILTER.CLICK",",oparms:[{av:'divPaisorigenidfiltercontainer_Class',ctrl:'PAISORIGENIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpaisorigenid_Visible',ctrl:'vCPAISORIGENID',prop:'Visible'}]}");
         setEventMetadata("LBLESPECTACULOCANTIDADINVITACIONESFILTER.CLICK","{handler:'E17181',iparms:[{av:'divEspectaculocantidadinvitacionesfiltercontainer_Class',ctrl:'ESPECTACULOCANTIDADINVITACIONESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULOCANTIDADINVITACIONESFILTER.CLICK",",oparms:[{av:'divEspectaculocantidadinvitacionesfiltercontainer_Class',ctrl:'ESPECTACULOCANTIDADINVITACIONESFILTERCONTAINER',prop:'Class'},{av:'edtavCespectaculocantidadinvitaciones_Visible',ctrl:'vCESPECTACULOCANTIDADINVITACIONES',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21182',iparms:[{av:'A5EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoId',fld:'vCESPECTACULOID',pic:'ZZZ9'},{av:'AV7cEspectaculoNombre',fld:'vCESPECTACULONOMBRE',pic:''},{av:'AV8cEspectaculoFecha',fld:'vCESPECTACULOFECHA',pic:''},{av:'AV9cTipoEspectaculoId',fld:'vCTIPOESPECTACULOID',pic:'ZZZ9'},{av:'AV10cLugarId',fld:'vCLUGARID',pic:'ZZZ9'},{av:'AV11cPaisOrigenId',fld:'vCPAISORIGENID',pic:'ZZZ9'},{av:'AV12cEspectaculoCantidadInvitaciones',fld:'vCESPECTACULOCANTIDADINVITACIONES',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoId',fld:'vCESPECTACULOID',pic:'ZZZ9'},{av:'AV7cEspectaculoNombre',fld:'vCESPECTACULONOMBRE',pic:''},{av:'AV8cEspectaculoFecha',fld:'vCESPECTACULOFECHA',pic:''},{av:'AV9cTipoEspectaculoId',fld:'vCTIPOESPECTACULOID',pic:'ZZZ9'},{av:'AV10cLugarId',fld:'vCLUGARID',pic:'ZZZ9'},{av:'AV11cPaisOrigenId',fld:'vCPAISORIGENID',pic:'ZZZ9'},{av:'AV12cEspectaculoCantidadInvitaciones',fld:'vCESPECTACULOCANTIDADINVITACIONES',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoId',fld:'vCESPECTACULOID',pic:'ZZZ9'},{av:'AV7cEspectaculoNombre',fld:'vCESPECTACULONOMBRE',pic:''},{av:'AV8cEspectaculoFecha',fld:'vCESPECTACULOFECHA',pic:''},{av:'AV9cTipoEspectaculoId',fld:'vCTIPOESPECTACULOID',pic:'ZZZ9'},{av:'AV10cLugarId',fld:'vCLUGARID',pic:'ZZZ9'},{av:'AV11cPaisOrigenId',fld:'vCPAISORIGENID',pic:'ZZZ9'},{av:'AV12cEspectaculoCantidadInvitaciones',fld:'vCESPECTACULOCANTIDADINVITACIONES',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoId',fld:'vCESPECTACULOID',pic:'ZZZ9'},{av:'AV7cEspectaculoNombre',fld:'vCESPECTACULONOMBRE',pic:''},{av:'AV8cEspectaculoFecha',fld:'vCESPECTACULOFECHA',pic:''},{av:'AV9cTipoEspectaculoId',fld:'vCTIPOESPECTACULOID',pic:'ZZZ9'},{av:'AV10cLugarId',fld:'vCLUGARID',pic:'ZZZ9'},{av:'AV11cPaisOrigenId',fld:'vCPAISORIGENID',pic:'ZZZ9'},{av:'AV12cEspectaculoCantidadInvitaciones',fld:'vCESPECTACULOCANTIDADINVITACIONES',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CESPECTACULOFECHA","{handler:'Validv_Cespectaculofecha',iparms:[]");
         setEventMetadata("VALIDV_CESPECTACULOFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Lugarid',iparms:[]");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cEspectaculoNombre = "";
         AV8cEspectaculoFecha = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblespectaculoidfilter_Jsonclick = "";
         TempTags = "";
         lblLblespectaculonombrefilter_Jsonclick = "";
         lblLblespectaculofechafilter_Jsonclick = "";
         lblLbltipoespectaculoidfilter_Jsonclick = "";
         lblLbllugaridfilter_Jsonclick = "";
         lblLblpaisorigenidfilter_Jsonclick = "";
         lblLblespectaculocantidadinvitacionesfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV17Linkselection_GXI = "";
         A8EspectaculoNombre = "";
         A19EspectaculoFecha = DateTime.MinValue;
         scmdbuf = "";
         lV7cEspectaculoNombre = "";
         H00182_A31EspectaculoCantidadInvitacione = new short[1] ;
         H00182_A7PaisOrigenId = new short[1] ;
         H00182_A3LugarId = new short[1] ;
         H00182_A6TipoEspectaculoId = new short[1] ;
         H00182_A19EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         H00182_A8EspectaculoNombre = new string[] {""} ;
         H00182_A5EspectaculoId = new short[1] ;
         H00183_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0030__default(),
            new Object[][] {
                new Object[] {
               H00182_A31EspectaculoCantidadInvitacione, H00182_A7PaisOrigenId, H00182_A3LugarId, H00182_A6TipoEspectaculoId, H00182_A19EspectaculoFecha, H00182_A8EspectaculoNombre, H00182_A5EspectaculoId
               }
               , new Object[] {
               H00183_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pEspectaculoId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cEspectaculoId ;
      private short AV9cTipoEspectaculoId ;
      private short AV10cLugarId ;
      private short AV11cPaisOrigenId ;
      private short AV12cEspectaculoCantidadInvitaciones ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A5EspectaculoId ;
      private short A6TipoEspectaculoId ;
      private short A3LugarId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A7PaisOrigenId ;
      private short A31EspectaculoCantidadInvitacione ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCespectaculoid_Enabled ;
      private int edtavCespectaculoid_Visible ;
      private int edtavCespectaculonombre_Visible ;
      private int edtavCespectaculonombre_Enabled ;
      private int edtavCespectaculofecha_Enabled ;
      private int edtavCtipoespectaculoid_Enabled ;
      private int edtavCtipoespectaculoid_Visible ;
      private int edtavClugarid_Enabled ;
      private int edtavClugarid_Visible ;
      private int edtavCpaisorigenid_Enabled ;
      private int edtavCpaisorigenid_Visible ;
      private int edtavCespectaculocantidadinvitaciones_Enabled ;
      private int edtavCespectaculocantidadinvitaciones_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divEspectaculoidfiltercontainer_Class ;
      private string divEspectaculonombrefiltercontainer_Class ;
      private string divEspectaculofechafiltercontainer_Class ;
      private string divTipoespectaculoidfiltercontainer_Class ;
      private string divLugaridfiltercontainer_Class ;
      private string divPaisorigenidfiltercontainer_Class ;
      private string divEspectaculocantidadinvitacionesfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cEspectaculoNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divEspectaculoidfiltercontainer_Internalname ;
      private string lblLblespectaculoidfilter_Internalname ;
      private string lblLblespectaculoidfilter_Jsonclick ;
      private string edtavCespectaculoid_Internalname ;
      private string TempTags ;
      private string edtavCespectaculoid_Jsonclick ;
      private string divEspectaculonombrefiltercontainer_Internalname ;
      private string lblLblespectaculonombrefilter_Internalname ;
      private string lblLblespectaculonombrefilter_Jsonclick ;
      private string edtavCespectaculonombre_Internalname ;
      private string edtavCespectaculonombre_Jsonclick ;
      private string divEspectaculofechafiltercontainer_Internalname ;
      private string lblLblespectaculofechafilter_Internalname ;
      private string lblLblespectaculofechafilter_Jsonclick ;
      private string edtavCespectaculofecha_Internalname ;
      private string edtavCespectaculofecha_Jsonclick ;
      private string divTipoespectaculoidfiltercontainer_Internalname ;
      private string lblLbltipoespectaculoidfilter_Internalname ;
      private string lblLbltipoespectaculoidfilter_Jsonclick ;
      private string edtavCtipoespectaculoid_Internalname ;
      private string edtavCtipoespectaculoid_Jsonclick ;
      private string divLugaridfiltercontainer_Internalname ;
      private string lblLbllugaridfilter_Internalname ;
      private string lblLbllugaridfilter_Jsonclick ;
      private string edtavClugarid_Internalname ;
      private string edtavClugarid_Jsonclick ;
      private string divPaisorigenidfiltercontainer_Internalname ;
      private string lblLblpaisorigenidfilter_Internalname ;
      private string lblLblpaisorigenidfilter_Jsonclick ;
      private string edtavCpaisorigenid_Internalname ;
      private string edtavCpaisorigenid_Jsonclick ;
      private string divEspectaculocantidadinvitacionesfiltercontainer_Internalname ;
      private string lblLblespectaculocantidadinvitacionesfilter_Internalname ;
      private string lblLblespectaculocantidadinvitacionesfilter_Jsonclick ;
      private string edtavCespectaculocantidadinvitaciones_Internalname ;
      private string edtavCespectaculocantidadinvitaciones_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtEspectaculoId_Internalname ;
      private string A8EspectaculoNombre ;
      private string edtEspectaculoNombre_Internalname ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtTipoEspectaculoId_Internalname ;
      private string edtLugarId_Internalname ;
      private string scmdbuf ;
      private string lV7cEspectaculoNombre ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtEspectaculoId_Jsonclick ;
      private string edtEspectaculoNombre_Link ;
      private string edtEspectaculoNombre_Jsonclick ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtTipoEspectaculoId_Jsonclick ;
      private string edtLugarId_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV8cEspectaculoFecha ;
      private DateTime A19EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00182_A31EspectaculoCantidadInvitacione ;
      private short[] H00182_A7PaisOrigenId ;
      private short[] H00182_A3LugarId ;
      private short[] H00182_A6TipoEspectaculoId ;
      private DateTime[] H00182_A19EspectaculoFecha ;
      private string[] H00182_A8EspectaculoNombre ;
      private short[] H00182_A5EspectaculoId ;
      private long[] H00183_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pEspectaculoId ;
      private GXWebForm Form ;
   }

   public class gx0030__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00182( IGxContext context ,
                                             string AV7cEspectaculoNombre ,
                                             DateTime AV8cEspectaculoFecha ,
                                             short AV9cTipoEspectaculoId ,
                                             short AV10cLugarId ,
                                             short AV11cPaisOrigenId ,
                                             short AV12cEspectaculoCantidadInvitaciones ,
                                             string A8EspectaculoNombre ,
                                             DateTime A19EspectaculoFecha ,
                                             short A6TipoEspectaculoId ,
                                             short A3LugarId ,
                                             short A7PaisOrigenId ,
                                             short A31EspectaculoCantidadInvitacione ,
                                             short AV6cEspectaculoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [EspectaculoCantidadInvitacione], [PaisOrigenId], [LugarId], [TipoEspectaculoId], [EspectaculoFecha], [EspectaculoNombre], [EspectaculoId]";
         sFromString = " FROM [Espectaculo]";
         sOrderString = "";
         AddWhere(sWhereString, "([EspectaculoId] >= @AV6cEspectaculoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cEspectaculoNombre)) )
         {
            AddWhere(sWhereString, "([EspectaculoNombre] like @lV7cEspectaculoNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cEspectaculoFecha) )
         {
            AddWhere(sWhereString, "([EspectaculoFecha] >= @AV8cEspectaculoFecha)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cTipoEspectaculoId) )
         {
            AddWhere(sWhereString, "([TipoEspectaculoId] >= @AV9cTipoEspectaculoId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cLugarId) )
         {
            AddWhere(sWhereString, "([LugarId] >= @AV10cLugarId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cPaisOrigenId) )
         {
            AddWhere(sWhereString, "([PaisOrigenId] >= @AV11cPaisOrigenId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cEspectaculoCantidadInvitaciones) )
         {
            AddWhere(sWhereString, "([EspectaculoCantidadInvitacione] >= @AV12cEspectaculoCantidadInvitaciones)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [EspectaculoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00183( IGxContext context ,
                                             string AV7cEspectaculoNombre ,
                                             DateTime AV8cEspectaculoFecha ,
                                             short AV9cTipoEspectaculoId ,
                                             short AV10cLugarId ,
                                             short AV11cPaisOrigenId ,
                                             short AV12cEspectaculoCantidadInvitaciones ,
                                             string A8EspectaculoNombre ,
                                             DateTime A19EspectaculoFecha ,
                                             short A6TipoEspectaculoId ,
                                             short A3LugarId ,
                                             short A7PaisOrigenId ,
                                             short A31EspectaculoCantidadInvitacione ,
                                             short AV6cEspectaculoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Espectaculo]";
         AddWhere(sWhereString, "([EspectaculoId] >= @AV6cEspectaculoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cEspectaculoNombre)) )
         {
            AddWhere(sWhereString, "([EspectaculoNombre] like @lV7cEspectaculoNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cEspectaculoFecha) )
         {
            AddWhere(sWhereString, "([EspectaculoFecha] >= @AV8cEspectaculoFecha)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cTipoEspectaculoId) )
         {
            AddWhere(sWhereString, "([TipoEspectaculoId] >= @AV9cTipoEspectaculoId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cLugarId) )
         {
            AddWhere(sWhereString, "([LugarId] >= @AV10cLugarId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cPaisOrigenId) )
         {
            AddWhere(sWhereString, "([PaisOrigenId] >= @AV11cPaisOrigenId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cEspectaculoCantidadInvitaciones) )
         {
            AddWhere(sWhereString, "([EspectaculoCantidadInvitacione] >= @AV12cEspectaculoCantidadInvitaciones)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00182(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H00183(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00182;
          prmH00182 = new Object[] {
          new ParDef("@AV6cEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@lV7cEspectaculoNombre",GXType.NChar,60,0) ,
          new ParDef("@AV8cEspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@AV9cTipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@AV10cLugarId",GXType.Int16,4,0) ,
          new ParDef("@AV11cPaisOrigenId",GXType.Int16,4,0) ,
          new ParDef("@AV12cEspectaculoCantidadInvitaciones",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00183;
          prmH00183 = new Object[] {
          new ParDef("@AV6cEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@lV7cEspectaculoNombre",GXType.NChar,60,0) ,
          new ParDef("@AV8cEspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@AV9cTipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@AV10cLugarId",GXType.Int16,4,0) ,
          new ParDef("@AV11cPaisOrigenId",GXType.Int16,4,0) ,
          new ParDef("@AV12cEspectaculoCantidadInvitaciones",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00182", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00182,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00183", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00183,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
