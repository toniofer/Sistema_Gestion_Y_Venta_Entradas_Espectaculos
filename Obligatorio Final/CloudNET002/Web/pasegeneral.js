gx.evt.autoSkip=!1;gx.define("pasegeneral",!0,function(n){this.ServerClass="pasegeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="pasegeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="ObligatorioPrueba001";this.SetStandaloneVars=function(){};this.Valid_Paseid=function(){return this.validCliEvt("Valid_Paseid",0,function(){try{var n=gx.util.balloon.getNew("PASEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Pasetipo=function(){return this.validCliEvt("Valid_Pasetipo",0,function(){try{var n=gx.util.balloon.getNew("PASETIPO");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculoid=function(){return this.validCliEvt("Valid_Espectaculoid",0,function(){try{var n=gx.util.balloon.getNew("ESPECTACULOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Sectorid=function(){return this.validCliEvt("Valid_Sectorid",0,function(){try{var n=gx.util.balloon.getNew("SECTORID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Paiscomprapaseid=function(){return this.validCliEvt("Valid_Paiscomprapaseid",0,function(){try{var n=gx.util.balloon.getNew("PAISCOMPRAPASEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110x1_client=function(){return this.clearMessages(),this.call("pase.aspx",["UPD",this.A13PaseId,this.A14PaseTipo],null,["Mode","PaseId","PaseTipo"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120x1_client=function(){return this.clearMessages(),this.call("pase.aspx",["DLT",this.A13PaseId,this.A14PaseTipo],null,["Mode","PaseId","PaseTipo"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150x2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160x2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69];this.GXLastCtrlId=69;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e110x1_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e120x1_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Paseid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PASEID",fmt:0,gxz:"Z13PaseId",gxold:"O13PaseId",gxvar:"A13PaseId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A13PaseId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z13PaseId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PASEID",gx.O.A13PaseId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A13PaseId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PASEID",".")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Valid_Pasetipo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PASETIPO",fmt:0,gxz:"Z14PaseTipo",gxold:"O14PaseTipo",gxvar:"A14PaseTipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A14PaseTipo=n)},v2z:function(n){n!==undefined&&(gx.O.Z14PaseTipo=n)},v2c:function(){gx.fn.setComboBoxValue("PASETIPO",gx.O.A14PaseTipo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A14PaseTipo=this.val())},val:function(){return gx.fn.getControlValue("PASETIPO")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONOMBRE",fmt:0,gxz:"Z8EspectaculoNombre",gxold:"O8EspectaculoNombre",gxvar:"A8EspectaculoNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8EspectaculoNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z8EspectaculoNombre=n)},v2c:function(){gx.fn.setControlValue("ESPECTACULONOMBRE",gx.O.A8EspectaculoNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8EspectaculoNombre=this.val())},val:function(){return gx.fn.getControlValue("ESPECTACULONOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFECHA",fmt:0,gxz:"Z19EspectaculoFecha",gxold:"O19EspectaculoFecha",gxvar:"A19EspectaculoFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A19EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z19EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOFECHA",gx.O.A19EspectaculoFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.A19EspectaculoFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("ESPECTACULOFECHA")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORNOMBRE",fmt:0,gxz:"Z21SectorNombre",gxold:"O21SectorNombre",gxvar:"A21SectorNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A21SectorNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z21SectorNombre=n)},v2c:function(){gx.fn.setControlValue("SECTORNOMBRE",gx.O.A21SectorNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A21SectorNombre=this.val())},val:function(){return gx.fn.getControlValue("SECTORNOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"",grid:0};t[43]={id:43,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORPRECIO",fmt:0,gxz:"Z23SectorPrecio",gxold:"O23SectorPrecio",gxvar:"A23SectorPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A23SectorPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z23SectorPrecio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SECTORPRECIO",gx.O.A23SectorPrecio,0)},c2v:function(){this.val()!==undefined&&(gx.O.A23SectorPrecio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SECTORPRECIO",".")},nac:gx.falseFn};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISCOMPRAPASENOMBRE",fmt:0,gxz:"Z35PaisCompraPaseNombre",gxold:"O35PaisCompraPaseNombre",gxvar:"A35PaisCompraPaseNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A35PaisCompraPaseNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z35PaisCompraPaseNombre=n)},v2c:function(){gx.fn.setControlValue("PAISCOMPRAPASENOMBRE",gx.O.A35PaisCompraPaseNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A35PaisCompraPaseNombre=this.val())},val:function(){return gx.fn.getControlValue("PAISCOMPRAPASENOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(48,function(){});t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOMBREINVITADO",fmt:0,gxz:"Z34NombreInvitado",gxold:"O34NombreInvitado",gxvar:"A34NombreInvitado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A34NombreInvitado=n)},v2z:function(n){n!==undefined&&(gx.O.Z34NombreInvitado=n)},v2c:function(){gx.fn.setControlValue("NOMBREINVITADO",gx.O.A34NombreInvitado,0)},c2v:function(){this.val()!==undefined&&(gx.O.A34NombreInvitado=this.val())},val:function(){return gx.fn.getControlValue("NOMBREINVITADO")},nac:gx.falseFn};t[54]={id:54,fld:"",grid:0};t[55]={id:55,fld:"",grid:0};t[56]={id:56,fld:"",grid:0};t[57]={id:57,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z5EspectaculoId",gxold:"O5EspectaculoId",gxvar:"A5EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5EspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOID",gx.O.A5EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5EspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ESPECTACULOID",".")},nac:gx.falseFn};this.declareDomainHdlr(57,function(){});t[58]={id:58,fld:"",grid:0};t[59]={id:59,fld:"",grid:0};t[60]={id:60,fld:"",grid:0};t[61]={id:61,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Sectorid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORID",fmt:0,gxz:"Z9SectorId",gxold:"O9SectorId",gxvar:"A9SectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9SectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9SectorId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SECTORID",gx.O.A9SectorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9SectorId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SECTORID",".")},nac:gx.falseFn};this.declareDomainHdlr(61,function(){});t[62]={id:62,fld:"",grid:0};t[63]={id:63,fld:"",grid:0};t[64]={id:64,fld:"",grid:0};t[65]={id:65,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Paiscomprapaseid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISCOMPRAPASEID",fmt:0,gxz:"Z15PaisCompraPaseId",gxold:"O15PaisCompraPaseId",gxvar:"A15PaisCompraPaseId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15PaisCompraPaseId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15PaisCompraPaseId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PAISCOMPRAPASEID",gx.O.A15PaisCompraPaseId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A15PaisCompraPaseId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PAISCOMPRAPASEID",".")},nac:gx.falseFn};this.declareDomainHdlr(65,function(){});t[66]={id:66,fld:"",grid:0};t[67]={id:67,fld:"",grid:0};t[68]={id:68,fld:"",grid:0};t[69]={id:69,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOINVITACIONESENTREGA",fmt:0,gxz:"Z33EspectaculoInvitacionesEntrega",gxold:"O33EspectaculoInvitacionesEntrega",gxvar:"A33EspectaculoInvitacionesEntrega",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A33EspectaculoInvitacionesEntrega=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z33EspectaculoInvitacionesEntrega=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOINVITACIONESENTREGA",gx.O.A33EspectaculoInvitacionesEntrega,0)},c2v:function(){this.val()!==undefined&&(gx.O.A33EspectaculoInvitacionesEntrega=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ESPECTACULOINVITACIONESENTREGA",".")},nac:gx.falseFn};this.A13PaseId=0;this.Z13PaseId=0;this.O13PaseId=0;this.A14PaseTipo="";this.Z14PaseTipo="";this.O14PaseTipo="";this.A8EspectaculoNombre="";this.Z8EspectaculoNombre="";this.O8EspectaculoNombre="";this.A19EspectaculoFecha=gx.date.nullDate();this.Z19EspectaculoFecha=gx.date.nullDate();this.O19EspectaculoFecha=gx.date.nullDate();this.A21SectorNombre="";this.Z21SectorNombre="";this.O21SectorNombre="";this.A23SectorPrecio=0;this.Z23SectorPrecio=0;this.O23SectorPrecio=0;this.A35PaisCompraPaseNombre="";this.Z35PaisCompraPaseNombre="";this.O35PaisCompraPaseNombre="";this.A34NombreInvitado="";this.Z34NombreInvitado="";this.O34NombreInvitado="";this.A5EspectaculoId=0;this.Z5EspectaculoId=0;this.O5EspectaculoId=0;this.A9SectorId=0;this.Z9SectorId=0;this.O9SectorId=0;this.A15PaisCompraPaseId=0;this.Z15PaisCompraPaseId=0;this.O15PaisCompraPaseId=0;this.A33EspectaculoInvitacionesEntrega=0;this.Z33EspectaculoInvitacionesEntrega=0;this.O33EspectaculoInvitacionesEntrega=0;this.A13PaseId=0;this.A14PaseTipo="";this.A8EspectaculoNombre="";this.A19EspectaculoFecha=gx.date.nullDate();this.A21SectorNombre="";this.A23SectorPrecio=0;this.A35PaisCompraPaseNombre="";this.A34NombreInvitado="";this.A5EspectaculoId=0;this.A9SectorId=0;this.A15PaisCompraPaseId=0;this.A33EspectaculoInvitacionesEntrega=0;this.Events={e150x2_client:["ENTER",!0],e160x2_client:["CANCEL",!0],e110x1_client:["'DOUPDATE'",!1],e120x1_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A13PaseId",fld:"PASEID",pic:"ZZZ9"},{ctrl:"PASETIPO"},{av:"A14PaseTipo",fld:"PASETIPO",pic:""},{av:"A5EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A13PaseId",fld:"PASEID",pic:"ZZZ9"},{ctrl:"PASETIPO"},{av:"A14PaseTipo",fld:"PASETIPO",pic:""}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A13PaseId",fld:"PASEID",pic:"ZZZ9"},{ctrl:"PASETIPO"},{av:"A14PaseTipo",fld:"PASETIPO",pic:""}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_PASEID=[[],[]];this.EvtParms.VALID_PASETIPO=[[],[]];this.EvtParms.VALID_ESPECTACULOID=[[],[]];this.EvtParms.VALID_SECTORID=[[],[]];this.EvtParms.VALID_PAISCOMPRAPASEID=[[],[]];this.Initialize()})