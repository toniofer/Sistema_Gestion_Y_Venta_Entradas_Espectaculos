gx.evt.autoSkip=!1;gx.define("conciertosporfecha",!1,function(){this.ServerClass="conciertosporfecha";this.PackageName="GeneXus.Programs";this.ServerFullClass="conciertosporfecha.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="ObligatorioPrueba001";this.SetStandaloneVars=function(){};this.Validv_Fechaconcierto=function(){return this.validCliEvt("Validv_Fechaconcierto",0,function(){try{var n=gx.util.balloon.getNew("vFECHACONCIERTO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV5FechaConcierto)===0||new gx.date.gxdate(this.AV5FechaConcierto).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Concierto fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110y1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("alistadoconciertosporfecha.aspx",[this.AV5FechaConcierto]),[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130y2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140y2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14];this.GXLastCtrlId=14;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fechaconcierto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFECHACONCIERTO",fmt:0,gxz:"ZV5FechaConcierto",gxold:"OV5FechaConcierto",gxvar:"AV5FechaConcierto",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[11],ip:[11],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5FechaConcierto=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5FechaConcierto=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFECHACONCIERTO",gx.O.AV5FechaConcierto,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5FechaConcierto=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFECHACONCIERTO")},nac:gx.falseFn};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"CONCIERTOSPORFECHA",grid:0,evt:"e110y1_client"};this.AV5FechaConcierto=gx.date.nullDate();this.ZV5FechaConcierto=gx.date.nullDate();this.OV5FechaConcierto=gx.date.nullDate();this.AV5FechaConcierto=gx.date.nullDate();this.Events={e130y2_client:["ENTER",!0],e140y2_client:["CANCEL",!0],e110y1_client:["'CONCIERTOSPORFECHA'",!1]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'CONCIERTOSPORFECHA'"]=[[{av:"AV5FechaConcierto",fld:"vFECHACONCIERTO",pic:""}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_FECHACONCIERTO=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(this.conciertosporfecha)})