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
   public class gx0041 : GXDataArea
   {
      public gx0041( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public gx0041( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pEspectaculoId ,
                           out short aP1_pSectorId )
      {
         this.AV10pEspectaculoId = aP0_pEspectaculoId;
         this.AV11pSectorId = 0 ;
         executePrivate();
         aP1_pSectorId=this.AV11pSectorId;
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
               AV10pEspectaculoId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10pEspectaculoId", StringUtil.LTrimStr( (decimal)(AV10pEspectaculoId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11pSectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "pSectorId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11pSectorId", StringUtil.LTrimStr( (decimal)(AV11pSectorId), 4, 0));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_54 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_54"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_54_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_54_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_54_idx = GetPar( "sGXsfl_54_idx");
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
         AV6cSectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "cSectorId"), "."), 18, MidpointRounding.ToEven));
         AV7cSectorNombre = GetPar( "cSectorNombre");
         AV8cSectorCapacidad = (int)(Math.Round(NumberUtil.Val( GetPar( "cSectorCapacidad"), "."), 18, MidpointRounding.ToEven));
         AV9cSectorPrecio = (int)(Math.Round(NumberUtil.Val( GetPar( "cSectorPrecio"), "."), 18, MidpointRounding.ToEven));
         AV10pEspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "pEspectaculoId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cSectorId, AV7cSectorNombre, AV8cSectorCapacidad, AV9cSectorPrecio, AV10pEspectaculoId) ;
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
         PA142( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START142( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0041.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pEspectaculoId,4,0)),UrlEncode(StringUtil.LTrimStr(AV11pSectorId,4,0))}, new string[] {"pEspectaculoId","pSectorId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSECTORNOMBRE", StringUtil.RTrim( AV7cSectorNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCSECTORCAPACIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cSectorCapacidad), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSECTORPRECIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cSectorPrecio), 6, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_54", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_54), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SECTORIDFILTERCONTAINER_Class", StringUtil.RTrim( divSectoridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SECTORNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divSectornombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SECTORCAPACIDADFILTERCONTAINER_Class", StringUtil.RTrim( divSectorcapacidadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SECTORPRECIOFILTERCONTAINER_Class", StringUtil.RTrim( divSectorpreciofiltercontainer_Class));
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
            WE142( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT142( ) ;
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
         return formatLink("gx0041.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pEspectaculoId,4,0)),UrlEncode(StringUtil.LTrimStr(AV11pSectorId,4,0))}, new string[] {"pEspectaculoId","pSectorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0041" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Sector" ;
      }

      protected void WB140( )
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
            GxWebStd.gx_div_start( context, divSectoridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSectoridfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsectoridfilter_Internalname, "Sector Id", "", "", lblLblsectoridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0041.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsectorid_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsectorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSectorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCsectorid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cSectorId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cSectorId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsectorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsectorid_Visible, edtavCsectorid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0041.htm");
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
            GxWebStd.gx_div_start( context, divSectornombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSectornombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsectornombrefilter_Internalname, "Sector Nombre", "", "", lblLblsectornombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0041.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsectornombre_Internalname, "Sector Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsectornombre_Internalname, StringUtil.RTrim( AV7cSectorNombre), StringUtil.RTrim( context.localUtil.Format( AV7cSectorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsectornombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsectornombre_Visible, edtavCsectornombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0041.htm");
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
            GxWebStd.gx_div_start( context, divSectorcapacidadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSectorcapacidadfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsectorcapacidadfilter_Internalname, "Sector Capacidad", "", "", lblLblsectorcapacidadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0041.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsectorcapacidad_Internalname, "Sector Capacidad", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsectorcapacidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cSectorCapacidad), 5, 0, ",", "")), StringUtil.LTrim( ((edtavCsectorcapacidad_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cSectorCapacidad), "ZZZZ9") : context.localUtil.Format( (decimal)(AV8cSectorCapacidad), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsectorcapacidad_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsectorcapacidad_Visible, edtavCsectorcapacidad_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0041.htm");
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
            GxWebStd.gx_div_start( context, divSectorpreciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divSectorpreciofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsectorpreciofilter_Internalname, "Sector Precio", "", "", lblLblsectorpreciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0041.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsectorprecio_Internalname, "Sector Precio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsectorprecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cSectorPrecio), 6, 0, ",", "")), StringUtil.LTrim( ((edtavCsectorprecio_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cSectorPrecio), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV9cSectorPrecio), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsectorprecio_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsectorprecio_Visible, edtavCsectorprecio_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0041.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e15141_client"+"'", TempTags, "", 2, "HLP_Gx0041.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl54( ) ;
         }
         if ( wbEnd == 54 )
         {
            wbEnd = 0;
            nRC_GXsfl_54 = (int)(nGXsfl_54_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0041.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 54 )
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

      protected void START142( )
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
            Form.Meta.addItem("description", "Selection List Sector", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP140( ) ;
      }

      protected void WS142( )
      {
         START142( ) ;
         EVT142( ) ;
      }

      protected void EVT142( )
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
                              nGXsfl_54_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
                              SubsflControlProps_542( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_54_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A21SectorNombre = cgiGet( edtSectorNombre_Internalname);
                              A22SectorCapacidad = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A23SectorPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A5EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16142 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E17142 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csectorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTORID"), ",", ".") != Convert.ToDecimal( AV6cSectorId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csectornombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSECTORNOMBRE"), AV7cSectorNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csectorcapacidad Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTORCAPACIDAD"), ",", ".") != Convert.ToDecimal( AV8cSectorCapacidad )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csectorprecio Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTORPRECIO"), ",", ".") != Convert.ToDecimal( AV9cSectorPrecio )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E18142 ();
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

      protected void WE142( )
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

      protected void PA142( )
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
         SubsflControlProps_542( ) ;
         while ( nGXsfl_54_idx <= nRC_GXsfl_54 )
         {
            sendrow_542( ) ;
            nGXsfl_54_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_54_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cSectorId ,
                                        string AV7cSectorNombre ,
                                        int AV8cSectorCapacidad ,
                                        int AV9cSectorPrecio ,
                                        short AV10pEspectaculoId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF142( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECTORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ".", "")));
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
         RF142( ) ;
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

      protected void RF142( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 54;
         nGXsfl_54_idx = 1;
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_542( ) ;
         bGXsfl_54_Refreshing = true;
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
            SubsflControlProps_542( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cSectorNombre ,
                                                 AV8cSectorCapacidad ,
                                                 AV9cSectorPrecio ,
                                                 A21SectorNombre ,
                                                 A22SectorCapacidad ,
                                                 A23SectorPrecio ,
                                                 AV10pEspectaculoId ,
                                                 AV6cSectorId ,
                                                 A5EspectaculoId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cSectorNombre = StringUtil.PadR( StringUtil.RTrim( AV7cSectorNombre), 60, "%");
            /* Using cursor H00142 */
            pr_default.execute(0, new Object[] {AV10pEspectaculoId, AV6cSectorId, lV7cSectorNombre, AV8cSectorCapacidad, AV9cSectorPrecio, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_54_idx = 1;
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A5EspectaculoId = H00142_A5EspectaculoId[0];
               A23SectorPrecio = H00142_A23SectorPrecio[0];
               A22SectorCapacidad = H00142_A22SectorCapacidad[0];
               A21SectorNombre = H00142_A21SectorNombre[0];
               A9SectorId = H00142_A9SectorId[0];
               /* Execute user event: Load */
               E17142 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 54;
            WB140( ) ;
         }
         bGXsfl_54_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes142( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECTORID"+"_"+sGXsfl_54_idx, GetSecureSignedToken( sGXsfl_54_idx, context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9"), context));
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
                                              AV7cSectorNombre ,
                                              AV8cSectorCapacidad ,
                                              AV9cSectorPrecio ,
                                              A21SectorNombre ,
                                              A22SectorCapacidad ,
                                              A23SectorPrecio ,
                                              AV10pEspectaculoId ,
                                              AV6cSectorId ,
                                              A5EspectaculoId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cSectorNombre = StringUtil.PadR( StringUtil.RTrim( AV7cSectorNombre), 60, "%");
         /* Using cursor H00143 */
         pr_default.execute(1, new Object[] {AV10pEspectaculoId, AV6cSectorId, lV7cSectorNombre, AV8cSectorCapacidad, AV9cSectorPrecio});
         GRID1_nRecordCount = H00143_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSectorId, AV7cSectorNombre, AV8cSectorCapacidad, AV9cSectorPrecio, AV10pEspectaculoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSectorId, AV7cSectorNombre, AV8cSectorCapacidad, AV9cSectorPrecio, AV10pEspectaculoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSectorId, AV7cSectorNombre, AV8cSectorCapacidad, AV9cSectorPrecio, AV10pEspectaculoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSectorId, AV7cSectorNombre, AV8cSectorCapacidad, AV9cSectorPrecio, AV10pEspectaculoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSectorId, AV7cSectorNombre, AV8cSectorCapacidad, AV9cSectorPrecio, AV10pEspectaculoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP140( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16142 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_54 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_54"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsectorid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsectorid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSECTORID");
               GX_FocusControl = edtavCsectorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cSectorId = 0;
               AssignAttri("", false, "AV6cSectorId", StringUtil.LTrimStr( (decimal)(AV6cSectorId), 4, 0));
            }
            else
            {
               AV6cSectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsectorid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cSectorId", StringUtil.LTrimStr( (decimal)(AV6cSectorId), 4, 0));
            }
            AV7cSectorNombre = cgiGet( edtavCsectornombre_Internalname);
            AssignAttri("", false, "AV7cSectorNombre", AV7cSectorNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsectorcapacidad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsectorcapacidad_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSECTORCAPACIDAD");
               GX_FocusControl = edtavCsectorcapacidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cSectorCapacidad = 0;
               AssignAttri("", false, "AV8cSectorCapacidad", StringUtil.LTrimStr( (decimal)(AV8cSectorCapacidad), 5, 0));
            }
            else
            {
               AV8cSectorCapacidad = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsectorcapacidad_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cSectorCapacidad", StringUtil.LTrimStr( (decimal)(AV8cSectorCapacidad), 5, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsectorprecio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsectorprecio_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSECTORPRECIO");
               GX_FocusControl = edtavCsectorprecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cSectorPrecio = 0;
               AssignAttri("", false, "AV9cSectorPrecio", StringUtil.LTrimStr( (decimal)(AV9cSectorPrecio), 6, 0));
            }
            else
            {
               AV9cSectorPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsectorprecio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cSectorPrecio", StringUtil.LTrimStr( (decimal)(AV9cSectorPrecio), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTORID"), ",", ".") != Convert.ToDecimal( AV6cSectorId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSECTORNOMBRE"), AV7cSectorNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTORCAPACIDAD"), ",", ".") != Convert.ToDecimal( AV8cSectorCapacidad )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTORPRECIO"), ",", ".") != Convert.ToDecimal( AV9cSectorPrecio )) )
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
         E16142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16142( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selecci�n %1", "Sector", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E17142( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_542( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_54_Refreshing )
         {
            DoAjaxLoad(54, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E18142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18142( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pSectorId = A9SectorId;
         AssignAttri("", false, "AV11pSectorId", StringUtil.LTrimStr( (decimal)(AV11pSectorId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV11pSectorId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pSectorId"});
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
         AV10pEspectaculoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV10pEspectaculoId", StringUtil.LTrimStr( (decimal)(AV10pEspectaculoId), 4, 0));
         AV11pSectorId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV11pSectorId", StringUtil.LTrimStr( (decimal)(AV11pSectorId), 4, 0));
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
         PA142( ) ;
         WS142( ) ;
         WE142( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874412616", true, true);
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
         context.AddJavascriptSource("gx0041.js", "?2023874412616", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_542( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_54_idx;
         edtSectorId_Internalname = "SECTORID_"+sGXsfl_54_idx;
         edtSectorNombre_Internalname = "SECTORNOMBRE_"+sGXsfl_54_idx;
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD_"+sGXsfl_54_idx;
         edtSectorPrecio_Internalname = "SECTORPRECIO_"+sGXsfl_54_idx;
         edtEspectaculoId_Internalname = "ESPECTACULOID_"+sGXsfl_54_idx;
      }

      protected void SubsflControlProps_fel_542( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_54_fel_idx;
         edtSectorId_Internalname = "SECTORID_"+sGXsfl_54_fel_idx;
         edtSectorNombre_Internalname = "SECTORNOMBRE_"+sGXsfl_54_fel_idx;
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD_"+sGXsfl_54_fel_idx;
         edtSectorPrecio_Internalname = "SECTORPRECIO_"+sGXsfl_54_fel_idx;
         edtEspectaculoId_Internalname = "ESPECTACULOID_"+sGXsfl_54_fel_idx;
      }

      protected void sendrow_542( )
      {
         SubsflControlProps_542( ) ;
         WB140( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_54_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_54_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_54_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_54_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtSectorNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtSectorNombre_Internalname, "Link", edtSectorNombre_Link, !bGXsfl_54_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorNombre_Internalname,StringUtil.RTrim( A21SectorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSectorNombre_Link,(string)"",(string)"",(string)"",(string)edtSectorNombre_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorCapacidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22SectorCapacidad), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorCapacidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5EspectaculoId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes142( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_54_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_54_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         /* End function sendrow_542 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl54( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"54\">") ;
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
            context.SendWebValue( "Capacidad") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Precio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Espectaculo Id") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A21SectorNombre)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtSectorNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5EspectaculoId), 4, 0, ".", ""))));
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
         lblLblsectoridfilter_Internalname = "LBLSECTORIDFILTER";
         edtavCsectorid_Internalname = "vCSECTORID";
         divSectoridfiltercontainer_Internalname = "SECTORIDFILTERCONTAINER";
         lblLblsectornombrefilter_Internalname = "LBLSECTORNOMBREFILTER";
         edtavCsectornombre_Internalname = "vCSECTORNOMBRE";
         divSectornombrefiltercontainer_Internalname = "SECTORNOMBREFILTERCONTAINER";
         lblLblsectorcapacidadfilter_Internalname = "LBLSECTORCAPACIDADFILTER";
         edtavCsectorcapacidad_Internalname = "vCSECTORCAPACIDAD";
         divSectorcapacidadfiltercontainer_Internalname = "SECTORCAPACIDADFILTERCONTAINER";
         lblLblsectorpreciofilter_Internalname = "LBLSECTORPRECIOFILTER";
         edtavCsectorprecio_Internalname = "vCSECTORPRECIO";
         divSectorpreciofiltercontainer_Internalname = "SECTORPRECIOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSectorId_Internalname = "SECTORID";
         edtSectorNombre_Internalname = "SECTORNOMBRE";
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD";
         edtSectorPrecio_Internalname = "SECTORPRECIO";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
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
         edtEspectaculoId_Jsonclick = "";
         edtSectorPrecio_Jsonclick = "";
         edtSectorCapacidad_Jsonclick = "";
         edtSectorNombre_Jsonclick = "";
         edtSectorNombre_Link = "";
         edtSectorId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCsectorprecio_Jsonclick = "";
         edtavCsectorprecio_Enabled = 1;
         edtavCsectorprecio_Visible = 1;
         edtavCsectorcapacidad_Jsonclick = "";
         edtavCsectorcapacidad_Enabled = 1;
         edtavCsectorcapacidad_Visible = 1;
         edtavCsectornombre_Jsonclick = "";
         edtavCsectornombre_Enabled = 1;
         edtavCsectornombre_Visible = 1;
         edtavCsectorid_Jsonclick = "";
         edtavCsectorid_Enabled = 1;
         edtavCsectorid_Visible = 1;
         divSectorpreciofiltercontainer_Class = "AdvancedContainerItem";
         divSectorcapacidadfiltercontainer_Class = "AdvancedContainerItem";
         divSectornombrefiltercontainer_Class = "AdvancedContainerItem";
         divSectoridfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Sector";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSectorId',fld:'vCSECTORID',pic:'ZZZ9'},{av:'AV7cSectorNombre',fld:'vCSECTORNOMBRE',pic:''},{av:'AV8cSectorCapacidad',fld:'vCSECTORCAPACIDAD',pic:'ZZZZ9'},{av:'AV9cSectorPrecio',fld:'vCSECTORPRECIO',pic:'ZZZZZ9'},{av:'AV10pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E15141',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLSECTORIDFILTER.CLICK","{handler:'E11141',iparms:[{av:'divSectoridfiltercontainer_Class',ctrl:'SECTORIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSECTORIDFILTER.CLICK",",oparms:[{av:'divSectoridfiltercontainer_Class',ctrl:'SECTORIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsectorid_Visible',ctrl:'vCSECTORID',prop:'Visible'}]}");
         setEventMetadata("LBLSECTORNOMBREFILTER.CLICK","{handler:'E12141',iparms:[{av:'divSectornombrefiltercontainer_Class',ctrl:'SECTORNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSECTORNOMBREFILTER.CLICK",",oparms:[{av:'divSectornombrefiltercontainer_Class',ctrl:'SECTORNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCsectornombre_Visible',ctrl:'vCSECTORNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLSECTORCAPACIDADFILTER.CLICK","{handler:'E13141',iparms:[{av:'divSectorcapacidadfiltercontainer_Class',ctrl:'SECTORCAPACIDADFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSECTORCAPACIDADFILTER.CLICK",",oparms:[{av:'divSectorcapacidadfiltercontainer_Class',ctrl:'SECTORCAPACIDADFILTERCONTAINER',prop:'Class'},{av:'edtavCsectorcapacidad_Visible',ctrl:'vCSECTORCAPACIDAD',prop:'Visible'}]}");
         setEventMetadata("LBLSECTORPRECIOFILTER.CLICK","{handler:'E14141',iparms:[{av:'divSectorpreciofiltercontainer_Class',ctrl:'SECTORPRECIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSECTORPRECIOFILTER.CLICK",",oparms:[{av:'divSectorpreciofiltercontainer_Class',ctrl:'SECTORPRECIOFILTERCONTAINER',prop:'Class'},{av:'edtavCsectorprecio_Visible',ctrl:'vCSECTORPRECIO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E18142',iparms:[{av:'A9SectorId',fld:'SECTORID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pSectorId',fld:'vPSECTORID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSectorId',fld:'vCSECTORID',pic:'ZZZ9'},{av:'AV7cSectorNombre',fld:'vCSECTORNOMBRE',pic:''},{av:'AV8cSectorCapacidad',fld:'vCSECTORCAPACIDAD',pic:'ZZZZ9'},{av:'AV9cSectorPrecio',fld:'vCSECTORPRECIO',pic:'ZZZZZ9'},{av:'AV10pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSectorId',fld:'vCSECTORID',pic:'ZZZ9'},{av:'AV7cSectorNombre',fld:'vCSECTORNOMBRE',pic:''},{av:'AV8cSectorCapacidad',fld:'vCSECTORCAPACIDAD',pic:'ZZZZ9'},{av:'AV9cSectorPrecio',fld:'vCSECTORPRECIO',pic:'ZZZZZ9'},{av:'AV10pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSectorId',fld:'vCSECTORID',pic:'ZZZ9'},{av:'AV7cSectorNombre',fld:'vCSECTORNOMBRE',pic:''},{av:'AV8cSectorCapacidad',fld:'vCSECTORCAPACIDAD',pic:'ZZZZ9'},{av:'AV9cSectorPrecio',fld:'vCSECTORPRECIO',pic:'ZZZZZ9'},{av:'AV10pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSectorId',fld:'vCSECTORID',pic:'ZZZ9'},{av:'AV7cSectorNombre',fld:'vCSECTORNOMBRE',pic:''},{av:'AV8cSectorCapacidad',fld:'vCSECTORCAPACIDAD',pic:'ZZZZ9'},{av:'AV9cSectorPrecio',fld:'vCSECTORPRECIO',pic:'ZZZZZ9'},{av:'AV10pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Espectaculoid',iparms:[]");
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
         AV7cSectorNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsectoridfilter_Jsonclick = "";
         TempTags = "";
         lblLblsectornombrefilter_Jsonclick = "";
         lblLblsectorcapacidadfilter_Jsonclick = "";
         lblLblsectorpreciofilter_Jsonclick = "";
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
         AV15Linkselection_GXI = "";
         A21SectorNombre = "";
         scmdbuf = "";
         lV7cSectorNombre = "";
         H00142_A5EspectaculoId = new short[1] ;
         H00142_A23SectorPrecio = new int[1] ;
         H00142_A22SectorCapacidad = new int[1] ;
         H00142_A21SectorNombre = new string[] {""} ;
         H00142_A9SectorId = new short[1] ;
         H00143_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0041__default(),
            new Object[][] {
                new Object[] {
               H00142_A5EspectaculoId, H00142_A23SectorPrecio, H00142_A22SectorCapacidad, H00142_A21SectorNombre, H00142_A9SectorId
               }
               , new Object[] {
               H00143_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10pEspectaculoId ;
      private short AV11pSectorId ;
      private short wcpOAV10pEspectaculoId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cSectorId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A9SectorId ;
      private short A5EspectaculoId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_54 ;
      private int subGrid1_Rows ;
      private int nGXsfl_54_idx=1 ;
      private int AV8cSectorCapacidad ;
      private int AV9cSectorPrecio ;
      private int edtavCsectorid_Enabled ;
      private int edtavCsectorid_Visible ;
      private int edtavCsectornombre_Visible ;
      private int edtavCsectornombre_Enabled ;
      private int edtavCsectorcapacidad_Enabled ;
      private int edtavCsectorcapacidad_Visible ;
      private int edtavCsectorprecio_Enabled ;
      private int edtavCsectorprecio_Visible ;
      private int A22SectorCapacidad ;
      private int A23SectorPrecio ;
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
      private string divSectoridfiltercontainer_Class ;
      private string divSectornombrefiltercontainer_Class ;
      private string divSectorcapacidadfiltercontainer_Class ;
      private string divSectorpreciofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_54_idx="0001" ;
      private string AV7cSectorNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSectoridfiltercontainer_Internalname ;
      private string lblLblsectoridfilter_Internalname ;
      private string lblLblsectoridfilter_Jsonclick ;
      private string edtavCsectorid_Internalname ;
      private string TempTags ;
      private string edtavCsectorid_Jsonclick ;
      private string divSectornombrefiltercontainer_Internalname ;
      private string lblLblsectornombrefilter_Internalname ;
      private string lblLblsectornombrefilter_Jsonclick ;
      private string edtavCsectornombre_Internalname ;
      private string edtavCsectornombre_Jsonclick ;
      private string divSectorcapacidadfiltercontainer_Internalname ;
      private string lblLblsectorcapacidadfilter_Internalname ;
      private string lblLblsectorcapacidadfilter_Jsonclick ;
      private string edtavCsectorcapacidad_Internalname ;
      private string edtavCsectorcapacidad_Jsonclick ;
      private string divSectorpreciofiltercontainer_Internalname ;
      private string lblLblsectorpreciofilter_Internalname ;
      private string lblLblsectorpreciofilter_Jsonclick ;
      private string edtavCsectorprecio_Internalname ;
      private string edtavCsectorprecio_Jsonclick ;
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
      private string edtSectorId_Internalname ;
      private string A21SectorNombre ;
      private string edtSectorNombre_Internalname ;
      private string edtSectorCapacidad_Internalname ;
      private string edtSectorPrecio_Internalname ;
      private string edtEspectaculoId_Internalname ;
      private string scmdbuf ;
      private string lV7cSectorNombre ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_54_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSectorId_Jsonclick ;
      private string edtSectorNombre_Link ;
      private string edtSectorNombre_Jsonclick ;
      private string edtSectorCapacidad_Jsonclick ;
      private string edtSectorPrecio_Jsonclick ;
      private string edtEspectaculoId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_54_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV15Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00142_A5EspectaculoId ;
      private int[] H00142_A23SectorPrecio ;
      private int[] H00142_A22SectorCapacidad ;
      private string[] H00142_A21SectorNombre ;
      private short[] H00142_A9SectorId ;
      private long[] H00143_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pSectorId ;
      private GXWebForm Form ;
   }

   public class gx0041__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00142( IGxContext context ,
                                             string AV7cSectorNombre ,
                                             int AV8cSectorCapacidad ,
                                             int AV9cSectorPrecio ,
                                             string A21SectorNombre ,
                                             int A22SectorCapacidad ,
                                             int A23SectorPrecio ,
                                             short AV10pEspectaculoId ,
                                             short AV6cSectorId ,
                                             short A5EspectaculoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [EspectaculoId], [SectorPrecio], [SectorCapacidad], [SectorNombre], [SectorId]";
         sFromString = " FROM [EspectaculoSector]";
         sOrderString = "";
         AddWhere(sWhereString, "([EspectaculoId] = @AV10pEspectaculoId and [SectorId] >= @AV6cSectorId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cSectorNombre)) )
         {
            AddWhere(sWhereString, "([SectorNombre] like @lV7cSectorNombre)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8cSectorCapacidad) )
         {
            AddWhere(sWhereString, "([SectorCapacidad] >= @AV8cSectorCapacidad)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV9cSectorPrecio) )
         {
            AddWhere(sWhereString, "([SectorPrecio] >= @AV9cSectorPrecio)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [EspectaculoId], [SectorId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00143( IGxContext context ,
                                             string AV7cSectorNombre ,
                                             int AV8cSectorCapacidad ,
                                             int AV9cSectorPrecio ,
                                             string A21SectorNombre ,
                                             int A22SectorCapacidad ,
                                             int A23SectorPrecio ,
                                             short AV10pEspectaculoId ,
                                             short AV6cSectorId ,
                                             short A5EspectaculoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [EspectaculoSector]";
         AddWhere(sWhereString, "([EspectaculoId] = @AV10pEspectaculoId and [SectorId] >= @AV6cSectorId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cSectorNombre)) )
         {
            AddWhere(sWhereString, "([SectorNombre] like @lV7cSectorNombre)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV8cSectorCapacidad) )
         {
            AddWhere(sWhereString, "([SectorCapacidad] >= @AV8cSectorCapacidad)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV9cSectorPrecio) )
         {
            AddWhere(sWhereString, "([SectorPrecio] >= @AV9cSectorPrecio)");
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H00142(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H00143(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH00142;
          prmH00142 = new Object[] {
          new ParDef("@AV10pEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@AV6cSectorId",GXType.Int16,4,0) ,
          new ParDef("@lV7cSectorNombre",GXType.NChar,60,0) ,
          new ParDef("@AV8cSectorCapacidad",GXType.Int32,5,0) ,
          new ParDef("@AV9cSectorPrecio",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00143;
          prmH00143 = new Object[] {
          new ParDef("@AV10pEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@AV6cSectorId",GXType.Int16,4,0) ,
          new ParDef("@lV7cSectorNombre",GXType.NChar,60,0) ,
          new ParDef("@AV8cSectorCapacidad",GXType.Int32,5,0) ,
          new ParDef("@AV9cSectorPrecio",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00142", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00142,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00143", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00143,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
