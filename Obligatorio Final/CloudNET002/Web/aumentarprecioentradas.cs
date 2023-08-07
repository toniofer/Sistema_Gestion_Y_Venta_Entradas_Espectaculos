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
   public class aumentarprecioentradas : GXDataArea
   {
      public aumentarprecioentradas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioPrueba001", true);
      }

      public aumentarprecioentradas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavPaisid = new GXCombobox();
         dynavEspectaculoid = new GXCombobox();
         dynavSectorid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPAISID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPAISID102( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vESPECTACULOID") == 0 )
            {
               AV5PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvESPECTACULOID102( AV5PaisId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSECTORID") == 0 )
            {
               AV6EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSECTORID102( AV6EspectaculoId) ;
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         nRC_GXsfl_31 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_31"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_31_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_31_idx = GetPar( "sGXsfl_31_idx");
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
         dynavEspectaculoid.FromJSonString( GetNextPar( ));
         AV6EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
         dynavSectorid.FromJSonString( GetNextPar( ));
         AV7SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
         dynavPaisid.FromJSonString( GetNextPar( ));
         AV5PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( AV6EspectaculoId, AV7SectorId, AV5PaisId) ;
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
         PA102( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START102( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("aumentarprecioentradas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SectorId), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_31", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_31), 8, 0, ",", "")));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE102( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT102( ) ;
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
         return formatLink("aumentarprecioentradas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AumentarPrecioEntradas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aumentar Precio Entradas" ;
      }

      protected void WB100( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row column WWOptionalColumn", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 100, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "AUMENTO DE PRECIO DE ENTRADAS", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-02", 0, "", 1, 1, 0, 0, "HLP_AumentarPrecioEntradas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row column WWOptionalColumn", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavPaisid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavPaisid_Internalname, "Pais Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'" + sGXsfl_31_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavPaisid, dynavPaisid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0)), 1, dynavPaisid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavPaisid.Enabled, 0, 0, 10, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "", true, 0, "HLP_AumentarPrecioEntradas.htm");
            dynavPaisid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0));
            AssignProp("", false, dynavPaisid_Internalname, "Values", (string)(dynavPaisid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row column WWOptionalColumn", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavEspectaculoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEspectaculoid_Internalname, "Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_31_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEspectaculoid, dynavEspectaculoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0)), 1, dynavEspectaculoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEspectaculoid.Enabled, 0, 0, 10, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "", true, 0, "HLP_AumentarPrecioEntradas.htm");
            dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
            AssignProp("", false, dynavEspectaculoid_Internalname, "Values", (string)(dynavEspectaculoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row column WWOptionalColumn", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavSectorid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSectorid_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_31_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSectorid, dynavSectorid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0)), 1, dynavSectorid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSectorid.Enabled, 0, 0, 10, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_AumentarPrecioEntradas.htm");
            dynavSectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0));
            AssignProp("", false, dynavSectorid_Internalname, "Values", (string)(dynavSectorid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row column WWOptionalColumn", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPorcentajeaumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPorcentajeaumento_Internalname, "Porcentaje Aumento", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_31_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPorcentajeaumento_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8PorcentajeAumento), 4, 0, ",", "")), StringUtil.LTrim( ((edtavPorcentajeaumento_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8PorcentajeAumento), "ZZZ9") : context.localUtil.Format( (decimal)(AV8PorcentajeAumento), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPorcentajeaumento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPorcentajeaumento_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AumentarPrecioEntradas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAumentar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(31), 2, 0)+","+"null"+");", "Aumentar", bttAumentar_Jsonclick, 5, "Aumentar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'AUMENTAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AumentarPrecioEntradas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl31( ) ;
         }
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            nRC_GXsfl_31 = (int)(nGXsfl_31_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 31 )
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

      protected void START102( )
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
            Form.Meta.addItem("description", "Aumentar Precio Entradas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP100( ) ;
      }

      protected void WS102( )
      {
         START102( ) ;
         EVT102( ) ;
      }

      protected void EVT102( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'AUMENTAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Aumentar' */
                              E11102 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VESPECTACULOID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12102 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPAISID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13102 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
                              SubsflControlProps_312( ) ;
                              A9SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A21SectorNombre = cgiGet( edtSectorNombre_Internalname);
                              A23SectorPrecio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A22SectorCapacidad = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14102 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Espectaculoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vESPECTACULOID"), ",", ".") != Convert.ToDecimal( AV6EspectaculoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sectorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTORID"), ",", ".") != Convert.ToDecimal( AV7SectorId )) )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE102( )
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

      protected void PA102( )
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
               GX_FocusControl = dynavPaisid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         GXVvESPECTACULOID_html102( AV5PaisId) ;
         GXVvSECTORID_html102( AV6EspectaculoId) ;
         /* End function dynload_actions */
      }

      protected void GXDLVvPAISID102( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPAISID_data102( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvPAISID_html102( )
      {
         short gxdynajaxvalue;
         GXDLVvPAISID_data102( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavPaisid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavPaisid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPAISID_data102( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Seleccione País");
         /* Using cursor H00102 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00102_A1PaisId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00102_A2PaisNombre[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvESPECTACULOID102( short AV5PaisId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvESPECTACULOID_data102( AV5PaisId) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvESPECTACULOID_html102( short AV5PaisId )
      {
         short gxdynajaxvalue;
         GXDLVvESPECTACULOID_data102( AV5PaisId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEspectaculoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavEspectaculoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavEspectaculoid.ItemCount > 0 )
         {
            AV6EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynavEspectaculoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
         }
      }

      protected void GXDLVvESPECTACULOID_data102( short AV5PaisId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00103 */
         pr_default.execute(1, new Object[] {AV5PaisId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00103_A5EspectaculoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00103_A8EspectaculoNombre[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSECTORID102( short AV6EspectaculoId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTORID_data102( AV6EspectaculoId) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvSECTORID_html102( short AV6EspectaculoId )
      {
         short gxdynajaxvalue;
         GXDLVvSECTORID_data102( AV6EspectaculoId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSectorid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavSectorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSECTORID_data102( short AV6EspectaculoId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Ninguno");
         /* Using cursor H00104 */
         pr_default.execute(2, new Object[] {AV6EspectaculoId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00104_A9SectorId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00104_A21SectorNombre[0]));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_312( ) ;
         while ( nGXsfl_31_idx <= nRC_GXsfl_31 )
         {
            sendrow_312( ) ;
            nGXsfl_31_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_31_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( short AV6EspectaculoId ,
                                        short AV7SectorId ,
                                        short AV5PaisId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF102( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvPAISID_html102( ) ;
            GXVvESPECTACULOID_html102( AV5PaisId) ;
            GXVvSECTORID_html102( AV6EspectaculoId) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavPaisid.ItemCount > 0 )
         {
            AV5PaisId = (short)(Math.Round(NumberUtil.Val( dynavPaisid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavPaisid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0));
            AssignProp("", false, dynavPaisid_Internalname, "Values", dynavPaisid.ToJavascriptSource(), true);
         }
         if ( dynavEspectaculoid.ItemCount > 0 )
         {
            AV6EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynavEspectaculoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
            AssignProp("", false, dynavEspectaculoid_Internalname, "Values", dynavEspectaculoid.ToJavascriptSource(), true);
         }
         if ( dynavSectorid.ItemCount > 0 )
         {
            AV7SectorId = (short)(Math.Round(NumberUtil.Val( dynavSectorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7SectorId", StringUtil.LTrimStr( (decimal)(AV7SectorId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0));
            AssignProp("", false, dynavSectorid_Internalname, "Values", dynavSectorid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF102( ) ;
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

      protected void RF102( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 31;
         nGXsfl_31_idx = 1;
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         bGXsfl_31_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "Grid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_312( ) ;
            /* Using cursor H00105 */
            pr_default.execute(3, new Object[] {AV6EspectaculoId, AV7SectorId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A5EspectaculoId = H00105_A5EspectaculoId[0];
               A22SectorCapacidad = H00105_A22SectorCapacidad[0];
               A23SectorPrecio = H00105_A23SectorPrecio[0];
               A21SectorNombre = H00105_A21SectorNombre[0];
               A9SectorId = H00105_A9SectorId[0];
               /* Execute user event: Load */
               E14102 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            wbEnd = 31;
            WB100( ) ;
         }
         bGXsfl_31_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes102( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         GXVvPAISID_html102( ) ;
         GXVvESPECTACULOID_html102( AV5PaisId) ;
         GXVvSECTORID_html102( AV6EspectaculoId) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP100( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_31 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_31"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            dynavPaisid.Name = dynavPaisid_Internalname;
            dynavPaisid.CurrentValue = cgiGet( dynavPaisid_Internalname);
            AV5PaisId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavPaisid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
            dynavEspectaculoid.Name = dynavEspectaculoid_Internalname;
            dynavEspectaculoid.CurrentValue = cgiGet( dynavEspectaculoid_Internalname);
            AV6EspectaculoId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavEspectaculoid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
            dynavSectorid.Name = dynavSectorid_Internalname;
            dynavSectorid.CurrentValue = cgiGet( dynavSectorid_Internalname);
            AV7SectorId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavSectorid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7SectorId", StringUtil.LTrimStr( (decimal)(AV7SectorId), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPorcentajeaumento_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPorcentajeaumento_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPORCENTAJEAUMENTO");
               GX_FocusControl = edtavPorcentajeaumento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8PorcentajeAumento = 0;
               AssignAttri("", false, "AV8PorcentajeAumento", StringUtil.LTrimStr( (decimal)(AV8PorcentajeAumento), 4, 0));
            }
            else
            {
               AV8PorcentajeAumento = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavPorcentajeaumento_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8PorcentajeAumento", StringUtil.LTrimStr( (decimal)(AV8PorcentajeAumento), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E11102( )
      {
         /* 'Aumentar' Routine */
         returnInSub = false;
         if ( ! (0==AV6EspectaculoId) )
         {
            if ( ( AV8PorcentajeAumento >= 5 ) && ( AV8PorcentajeAumento <= 15 ) )
            {
               new aumentarentradas(context ).execute(  AV6EspectaculoId,  AV7SectorId,  AV8PorcentajeAumento) ;
               GX_msglist.addItem("Se actualizó el precio de las entradas");
               AV7SectorId = 0;
               AssignAttri("", false, "AV7SectorId", StringUtil.LTrimStr( (decimal)(AV7SectorId), 4, 0));
               AV5PaisId = 0;
               AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
               AV6EspectaculoId = 0;
               AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
               AV8PorcentajeAumento = 0;
               AssignAttri("", false, "AV8PorcentajeAumento", StringUtil.LTrimStr( (decimal)(AV8PorcentajeAumento), 4, 0));
            }
            else
            {
               GX_msglist.addItem("El porcentaje de aumento debe ser entre 5 y 15");
            }
         }
         else
         {
            GX_msglist.addItem("No hay ningún espectáculo seleccionado");
         }
         /*  Sending Event outputs  */
         dynavSectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0));
         AssignProp("", false, dynavSectorid_Internalname, "Values", dynavSectorid.ToJavascriptSource(), true);
         dynavPaisid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0));
         AssignProp("", false, dynavPaisid_Internalname, "Values", dynavPaisid.ToJavascriptSource(), true);
         dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
         AssignProp("", false, dynavEspectaculoid_Internalname, "Values", dynavEspectaculoid.ToJavascriptSource(), true);
      }

      protected void E12102( )
      {
         /* Espectaculoid_Controlvaluechanged Routine */
         returnInSub = false;
         AV7SectorId = 0;
         AssignAttri("", false, "AV7SectorId", StringUtil.LTrimStr( (decimal)(AV7SectorId), 4, 0));
         gxgrGrid1_refresh( AV6EspectaculoId, AV7SectorId, AV5PaisId) ;
         /*  Sending Event outputs  */
         dynavSectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0));
         AssignProp("", false, dynavSectorid_Internalname, "Values", dynavSectorid.ToJavascriptSource(), true);
      }

      protected void E13102( )
      {
         /* Paisid_Controlvaluechanged Routine */
         returnInSub = false;
         AV7SectorId = 0;
         AssignAttri("", false, "AV7SectorId", StringUtil.LTrimStr( (decimal)(AV7SectorId), 4, 0));
         gxgrGrid1_refresh( AV6EspectaculoId, AV7SectorId, AV5PaisId) ;
         /*  Sending Event outputs  */
         dynavSectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0));
         AssignProp("", false, dynavSectorid_Internalname, "Values", dynavSectorid.ToJavascriptSource(), true);
      }

      private void E14102( )
      {
         /* Load Routine */
         returnInSub = false;
         sendrow_312( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_31_Refreshing )
         {
            DoAjaxLoad(31, Grid1Row);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA102( ) ;
         WS102( ) ;
         WE102( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023874412583", true, true);
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
         context.AddJavascriptSource("aumentarprecioentradas.js", "?2023874412583", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_312( )
      {
         edtSectorId_Internalname = "SECTORID_"+sGXsfl_31_idx;
         edtSectorNombre_Internalname = "SECTORNOMBRE_"+sGXsfl_31_idx;
         edtSectorPrecio_Internalname = "SECTORPRECIO_"+sGXsfl_31_idx;
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD_"+sGXsfl_31_idx;
      }

      protected void SubsflControlProps_fel_312( )
      {
         edtSectorId_Internalname = "SECTORID_"+sGXsfl_31_fel_idx;
         edtSectorNombre_Internalname = "SECTORNOMBRE_"+sGXsfl_31_fel_idx;
         edtSectorPrecio_Internalname = "SECTORPRECIO_"+sGXsfl_31_fel_idx;
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD_"+sGXsfl_31_fel_idx;
      }

      protected void sendrow_312( )
      {
         SubsflControlProps_312( ) ;
         WB100( ) ;
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
            if ( ((int)((nGXsfl_31_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_31_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SectorId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorNombre_Internalname,StringUtil.RTrim( A21SectorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A23SectorPrecio), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorCapacidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22SectorCapacidad), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorCapacidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         send_integrity_lvl_hashes102( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_31_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_31_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         /* End function sendrow_312 */
      }

      protected void init_web_controls( )
      {
         dynavPaisid.Name = "vPAISID";
         dynavPaisid.WebTags = "";
         dynavEspectaculoid.Name = "vESPECTACULOID";
         dynavEspectaculoid.WebTags = "";
         dynavSectorid.Name = "vSECTORID";
         dynavSectorid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl31( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"31\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector Precio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector Capacidad") ;
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
            Grid1Container.AddObjectProperty("Class", "Grid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A21SectorNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23SectorPrecio), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22SectorCapacidad), 5, 0, ".", ""))));
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
         lblTextblock1_Internalname = "TEXTBLOCK1";
         dynavPaisid_Internalname = "vPAISID";
         dynavEspectaculoid_Internalname = "vESPECTACULOID";
         dynavSectorid_Internalname = "vSECTORID";
         edtavPorcentajeaumento_Internalname = "vPORCENTAJEAUMENTO";
         bttAumentar_Internalname = "AUMENTAR";
         edtSectorId_Internalname = "SECTORID";
         edtSectorNombre_Internalname = "SECTORNOMBRE";
         edtSectorPrecio_Internalname = "SECTORPRECIO";
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD";
         divMaintable_Internalname = "MAINTABLE";
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
         edtSectorCapacidad_Jsonclick = "";
         edtSectorPrecio_Jsonclick = "";
         edtSectorNombre_Jsonclick = "";
         edtSectorId_Jsonclick = "";
         subGrid1_Class = "Grid";
         subGrid1_Backcolorstyle = 0;
         edtavPorcentajeaumento_Jsonclick = "";
         edtavPorcentajeaumento_Enabled = 1;
         dynavSectorid_Jsonclick = "";
         dynavSectorid.Enabled = 1;
         dynavEspectaculoid_Jsonclick = "";
         dynavEspectaculoid.Enabled = 1;
         dynavPaisid_Jsonclick = "";
         dynavPaisid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Aumentar Precio Entradas";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Paisid( )
      {
         AV5PaisId = (short)(Math.Round(NumberUtil.Val( dynavPaisid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         AV6EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynavEspectaculoid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         AV7SectorId = (short)(Math.Round(NumberUtil.Val( dynavSectorid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         GXVvESPECTACULOID_html102( AV5PaisId) ;
         dynload_actions( ) ;
         if ( dynavEspectaculoid.ItemCount > 0 )
         {
            AV6EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynavEspectaculoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6EspectaculoId), 4, 0, ".", "")));
         dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
         AssignProp("", false, dynavEspectaculoid_Internalname, "Values", dynavEspectaculoid.ToJavascriptSource(), true);
      }

      public void Validv_Espectaculoid( )
      {
         AV5PaisId = (short)(Math.Round(NumberUtil.Val( dynavPaisid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         AV6EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynavEspectaculoid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         AV7SectorId = (short)(Math.Round(NumberUtil.Val( dynavSectorid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         GXVvSECTORID_html102( AV6EspectaculoId) ;
         dynload_actions( ) ;
         if ( dynavSectorid.ItemCount > 0 )
         {
            AV7SectorId = (short)(Math.Round(NumberUtil.Val( dynavSectorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV7SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SectorId), 4, 0, ".", "")));
         dynavSectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7SectorId), 4, 0));
         AssignProp("", false, dynavSectorid_Internalname, "Values", dynavSectorid.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'dynavPaisid'},{av:'AV5PaisId',fld:'vPAISID',pic:'ZZZ9'},{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'},{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'AUMENTAR'","{handler:'E11102',iparms:[{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'},{av:'AV8PorcentajeAumento',fld:'vPORCENTAJEAUMENTO',pic:'ZZZ9'},{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'}]");
         setEventMetadata("'AUMENTAR'",",oparms:[{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'},{av:'dynavPaisid'},{av:'AV5PaisId',fld:'vPAISID',pic:'ZZZ9'},{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'},{av:'AV8PorcentajeAumento',fld:'vPORCENTAJEAUMENTO',pic:'ZZZ9'}]}");
         setEventMetadata("VESPECTACULOID.CONTROLVALUECHANGED","{handler:'E12102',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'},{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'},{av:'dynavPaisid'},{av:'AV5PaisId',fld:'vPAISID',pic:'ZZZ9'}]");
         setEventMetadata("VESPECTACULOID.CONTROLVALUECHANGED",",oparms:[{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'}]}");
         setEventMetadata("VPAISID.CONTROLVALUECHANGED","{handler:'E13102',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'},{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'},{av:'dynavPaisid'},{av:'AV5PaisId',fld:'vPAISID',pic:'ZZZ9'}]");
         setEventMetadata("VPAISID.CONTROLVALUECHANGED",",oparms:[{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_PAISID","{handler:'Validv_Paisid',iparms:[{av:'dynavPaisid'},{av:'AV5PaisId',fld:'vPAISID',pic:'ZZZ9'},{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'},{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'}]");
         setEventMetadata("VALIDV_PAISID",",oparms:[{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_ESPECTACULOID","{handler:'Validv_Espectaculoid',iparms:[{av:'dynavPaisid'},{av:'AV5PaisId',fld:'vPAISID',pic:'ZZZ9'},{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'},{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'}]");
         setEventMetadata("VALIDV_ESPECTACULOID",",oparms:[{av:'dynavSectorid'},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_SECTORID","{handler:'Validv_Sectorid',iparms:[]");
         setEventMetadata("VALIDV_SECTORID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Sectorcapacidad',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttAumentar_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A21SectorNombre = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00102_A1PaisId = new short[1] ;
         H00102_A2PaisNombre = new string[] {""} ;
         H00103_A3LugarId = new short[1] ;
         H00103_A5EspectaculoId = new short[1] ;
         H00103_A8EspectaculoNombre = new string[] {""} ;
         H00103_A1PaisId = new short[1] ;
         H00104_A9SectorId = new short[1] ;
         H00104_A21SectorNombre = new string[] {""} ;
         H00104_A5EspectaculoId = new short[1] ;
         H00105_A5EspectaculoId = new short[1] ;
         H00105_A22SectorCapacidad = new int[1] ;
         H00105_A23SectorPrecio = new int[1] ;
         H00105_A21SectorNombre = new string[] {""} ;
         H00105_A9SectorId = new short[1] ;
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aumentarprecioentradas__default(),
            new Object[][] {
                new Object[] {
               H00102_A1PaisId, H00102_A2PaisNombre
               }
               , new Object[] {
               H00103_A3LugarId, H00103_A5EspectaculoId, H00103_A8EspectaculoNombre, H00103_A1PaisId
               }
               , new Object[] {
               H00104_A9SectorId, H00104_A21SectorNombre, H00104_A5EspectaculoId
               }
               , new Object[] {
               H00105_A5EspectaculoId, H00105_A22SectorCapacidad, H00105_A23SectorPrecio, H00105_A21SectorNombre, H00105_A9SectorId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV5PaisId ;
      private short AV6EspectaculoId ;
      private short AV7SectorId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV8PorcentajeAumento ;
      private short A9SectorId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A5EspectaculoId ;
      private short GRID1_nEOF ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short ZV6EspectaculoId ;
      private short ZV7SectorId ;
      private int nRC_GXsfl_31 ;
      private int nGXsfl_31_idx=1 ;
      private int edtavPorcentajeaumento_Enabled ;
      private int A23SectorPrecio ;
      private int A22SectorCapacidad ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_31_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string dynavPaisid_Internalname ;
      private string TempTags ;
      private string dynavPaisid_Jsonclick ;
      private string dynavEspectaculoid_Internalname ;
      private string dynavEspectaculoid_Jsonclick ;
      private string dynavSectorid_Internalname ;
      private string dynavSectorid_Jsonclick ;
      private string edtavPorcentajeaumento_Internalname ;
      private string edtavPorcentajeaumento_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttAumentar_Internalname ;
      private string bttAumentar_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSectorId_Internalname ;
      private string A21SectorNombre ;
      private string edtSectorNombre_Internalname ;
      private string edtSectorPrecio_Internalname ;
      private string edtSectorCapacidad_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string sGXsfl_31_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtSectorId_Jsonclick ;
      private string edtSectorNombre_Jsonclick ;
      private string edtSectorPrecio_Jsonclick ;
      private string edtSectorCapacidad_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_31_Refreshing=false ;
      private bool returnInSub ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavPaisid ;
      private GXCombobox dynavEspectaculoid ;
      private GXCombobox dynavSectorid ;
      private IDataStoreProvider pr_default ;
      private short[] H00102_A1PaisId ;
      private string[] H00102_A2PaisNombre ;
      private short[] H00103_A3LugarId ;
      private short[] H00103_A5EspectaculoId ;
      private string[] H00103_A8EspectaculoNombre ;
      private short[] H00103_A1PaisId ;
      private short[] H00104_A9SectorId ;
      private string[] H00104_A21SectorNombre ;
      private short[] H00104_A5EspectaculoId ;
      private short[] H00105_A5EspectaculoId ;
      private int[] H00105_A22SectorCapacidad ;
      private int[] H00105_A23SectorPrecio ;
      private string[] H00105_A21SectorNombre ;
      private short[] H00105_A9SectorId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class aumentarprecioentradas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00102;
          prmH00102 = new Object[] {
          };
          Object[] prmH00103;
          prmH00103 = new Object[] {
          new ParDef("@AV5PaisId",GXType.Int16,4,0)
          };
          Object[] prmH00104;
          prmH00104 = new Object[] {
          new ParDef("@AV6EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmH00105;
          prmH00105 = new Object[] {
          new ParDef("@AV6EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@AV7SectorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00102", "SELECT [PaisId], [PaisNombre] FROM [Pais] ORDER BY [PaisNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00102,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00103", "SELECT T2.[LugarId], T1.[EspectaculoId], T1.[EspectaculoNombre], T2.[PaisId] FROM ([Espectaculo] T1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = T1.[LugarId]) WHERE T2.[PaisId] = @AV5PaisId ORDER BY T1.[EspectaculoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00103,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00104", "SELECT [SectorId], [SectorNombre], [EspectaculoId] FROM [EspectaculoSector] WHERE [EspectaculoId] = @AV6EspectaculoId ORDER BY [SectorNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00104,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00105", "SELECT [EspectaculoId], [SectorCapacidad], [SectorPrecio], [SectorNombre], [SectorId] FROM [EspectaculoSector] WHERE [EspectaculoId] = @AV6EspectaculoId and [SectorId] = @AV7SectorId ORDER BY [EspectaculoId], [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00105,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
