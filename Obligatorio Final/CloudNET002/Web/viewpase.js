gx.evt.autoSkip=!1;gx.define("viewpase",!1,function(){var n,t;this.ServerClass="viewpase";this.PackageName="GeneXus.Programs";this.ServerFullClass="viewpase.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="ObligatorioPrueba001";this.SetStandaloneVars=function(){this.AV11LoadAllTabs=gx.fn.getControlValue("vLOADALLTABS");this.AV7SelectedTabCode=gx.fn.getControlValue("vSELECTEDTABCODE");this.AV12PaseId=gx.fn.getIntegerValue("vPASEID",".");this.AV13PaseTipo=gx.fn.getControlValue("vPASETIPO");this.AV6TabCode=gx.fn.getControlValue("vTABCODE")};this.s112_client=function(){(this.AV11LoadAllTabs||gx.text.compare(this.AV7SelectedTabCode,"")==0||gx.text.compare(this.AV7SelectedTabCode,"General")==0)&&this.createWebComponent("Generalwc","PaseGeneral",[this.AV12PaseId,this.AV13PaseTipo])};this.e130s1_client=function(){return this.clearMessages(),this.AV7SelectedTabCode=this.TABContainer.ActivePageControlName,this.AV11LoadAllTabs=!1,this.s112_client(),this.refreshOutputs([{av:"AV7SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{ctrl:"GENERALWC"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140s2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e150s2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,20,21,23,24,25];this.GXLastCtrlId=25;this.TABContainer=gx.uc.getNew(this,18,15,"gx.ui.controls.BasicTab","TABContainer","Tab","TAB");t=this.TABContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("ActivePage","Activepage","","int");t.setDynProp("ActivePageControlName","Activepagecontrolname","","char");t.setProp("PageCount","Pagecount",1,"num");t.setProp("Class","Class","ww__view__tab","str");t.setProp("HistoryManagement","Historymanagement",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("TabChanged",this.e130s1_client);this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"VIEWALL",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLEFIXEDDATA_1",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOMBREINVITADO",fmt:0,gxz:"Z34NombreInvitado",gxold:"O34NombreInvitado",gxvar:"A34NombreInvitado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A34NombreInvitado=n)},v2z:function(n){n!==undefined&&(gx.O.Z34NombreInvitado=n)},v2c:function(){gx.fn.setControlValue("NOMBREINVITADO",gx.O.A34NombreInvitado,0)},c2v:function(){this.val()!==undefined&&(gx.O.A34NombreInvitado=this.val())},val:function(){return gx.fn.getControlValue("NOMBREINVITADO")},nac:gx.falseFn};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[20]={id:20,fld:"GENERAL_TITLE",format:0,grid:0,ctrltype:"textblock"};n[21]={id:21,fld:"",grid:0};n[23]={id:23,fld:"TABLEGENERAL",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};this.A34NombreInvitado="";this.Z34NombreInvitado="";this.O34NombreInvitado="";this.A34NombreInvitado="";this.AV12PaseId=0;this.AV13PaseTipo="";this.AV6TabCode="";this.A14PaseTipo="";this.A13PaseId=0;this.AV11LoadAllTabs=!1;this.AV7SelectedTabCode="";this.Events={e140s2_client:["ENTER",!0],e150s2_client:["CANCEL",!0],e130s1_client:["TAB.TABCHANGED",!1]};this.EvtParms.REFRESH=[[{av:"AV12PaseId",fld:"vPASEID",pic:"ZZZ9",hsh:!0},{av:"AV13PaseTipo",fld:"vPASETIPO",pic:"",hsh:!0},{av:"AV6TabCode",fld:"vTABCODE",pic:"",hsh:!0},{av:"A34NombreInvitado",fld:"NOMBREINVITADO",pic:""}],[]];this.EvtParms["TAB.TABCHANGED"]=[[{av:"this.TABContainer.ActivePageControlName",ctrl:"TAB",prop:"ActivePageControlName"},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{av:"AV7SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV12PaseId",fld:"vPASEID",pic:"ZZZ9",hsh:!0},{av:"AV13PaseTipo",fld:"vPASETIPO",pic:"",hsh:!0}],[{av:"AV7SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{ctrl:"GENERALWC"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV11LoadAllTabs","vLOADALLTABS",0,"boolean",4,0);this.setVCMap("AV7SelectedTabCode","vSELECTEDTABCODE",0,"char",50,0);this.setVCMap("AV12PaseId","vPASEID",0,"int",4,0);this.setVCMap("AV13PaseTipo","vPASETIPO",0,"char",20,0);this.setVCMap("AV6TabCode","vTABCODE",0,"char",50,0);this.setVCMap("AV12PaseId","vPASEID",0,"int",4,0);this.setVCMap("AV13PaseTipo","vPASETIPO",0,"char",20,0);this.setVCMap("AV11LoadAllTabs","vLOADALLTABS",0,"boolean",4,0);this.setVCMap("AV7SelectedTabCode","vSELECTEDTABCODE",0,"char",50,0);this.Initialize();this.setComponent({id:"GENERALWC",GXClass:null,Prefix:"W0026",lvl:1})});gx.wi(function(){gx.createParentObj(this.viewpase)})