gx.evt.autoSkip=!1;gx.define("entrada",!1,function(){this.ServerClass="entrada";this.PackageName="GeneXus.Programs";this.ServerFullClass="entrada.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="ObligatorioPrueba001";this.SetStandaloneVars=function(){this.A22SectorCapacidad=gx.fn.getIntegerValue("SECTORCAPACIDAD",".");this.AV7EntradaId=gx.fn.getIntegerValue("vENTRADAID",".");this.AV11Insert_EspectaculoId=gx.fn.getIntegerValue("vINSERT_ESPECTACULOID",".");this.AV12Insert_SectorId=gx.fn.getIntegerValue("vINSERT_SECTORID",".");this.AV13Insert_PaisCompraId=gx.fn.getIntegerValue("vINSERT_PAISCOMPRAID",".");this.Gx_date=gx.fn.getDateValue("vTODAY");this.AV16Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Entradaid=function(){return this.validCliEvt("Valid_Entradaid",0,function(){try{var n=gx.util.balloon.getNew("ENTRADAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculoid=function(){return this.validSrvEvt("Valid_Espectaculoid",0).then(function(n){return n}.closure(this))};this.Valid_Espectaculofecha=function(){return this.validCliEvt("Valid_Espectaculofecha",0,function(){try{var n=gx.util.balloon.getNew("ESPECTACULOFECHA");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Sectorid=function(){return this.validSrvEvt("Valid_Sectorid",0).then(function(n){return n}.closure(this))};this.Valid_Sectorentradasvendidas=function(){return this.validCliEvt("Valid_Sectorentradasvendidas",0,function(){try{var n=gx.util.balloon.getNew("SECTORENTRADASVENDIDAS");this.AnyError=0;try{this.Gx_mode=="INS"&&(this.A25SectorEntradasVendidas=gx.num.trunc(gx.OldInteger("SECTORENTRADASVENDIDAS","O25SectorEntradasVendidas")+1,0))}catch(t){}try{this.A24SectorEntradasDisponibles=gx.num.trunc(this.A22SectorCapacidad-this.A25SectorEntradasVendidas,0)}catch(t){}if(this.A24SectorEntradasDisponibles<0)try{n.setError("No hay entradas disponibles para ese sector");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Sectorentradasdisponibles=function(){return this.validCliEvt("Valid_Sectorentradasdisponibles",0,function(){try{var n=gx.util.balloon.getNew("SECTORENTRADASDISPONIBLES");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Paiscompraid=function(){return this.validSrvEvt("Valid_Paiscompraid",0).then(function(n){return n}.closure(this))};this.e12042_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13046_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14046_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96];this.GXLastCtrlId=96;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15046_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16046_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17046_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18046_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19046_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Entradaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAID",fmt:0,gxz:"Z11EntradaId",gxold:"O11EntradaId",gxvar:"A11EntradaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A11EntradaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z11EntradaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ENTRADAID",gx.O.A11EntradaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A11EntradaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ENTRADAID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z5EspectaculoId",gxold:"O5EspectaculoId",gxvar:"A5EspectaculoId",ucs:[],op:[49,44],ip:[44,49,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5EspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOID",gx.O.A5EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5EspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ESPECTACULOID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV11Insert_EspectaculoId)}};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONOMBRE",fmt:0,gxz:"Z8EspectaculoNombre",gxold:"O8EspectaculoNombre",gxvar:"A8EspectaculoNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8EspectaculoNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z8EspectaculoNombre=n)},v2c:function(){gx.fn.setControlValue("ESPECTACULONOMBRE",gx.O.A8EspectaculoNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8EspectaculoNombre=this.val())},val:function(){return gx.fn.getControlValue("ESPECTACULONOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Valid_Espectaculofecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFECHA",fmt:0,gxz:"Z19EspectaculoFecha",gxold:"O19EspectaculoFecha",gxvar:"A19EspectaculoFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A19EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z19EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOFECHA",gx.O.A19EspectaculoFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.A19EspectaculoFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("ESPECTACULOFECHA")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Sectorid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORID",fmt:0,gxz:"Z9SectorId",gxold:"O9SectorId",gxvar:"A9SectorId",ucs:[],op:[64,59],ip:[64,59,54,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9SectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9SectorId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SECTORID",gx.O.A9SectorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9SectorId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SECTORID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV12Insert_SectorId)}};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORNOMBRE",fmt:0,gxz:"Z21SectorNombre",gxold:"O21SectorNombre",gxvar:"A21SectorNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A21SectorNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z21SectorNombre=n)},v2c:function(){gx.fn.setControlValue("SECTORNOMBRE",gx.O.A21SectorNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A21SectorNombre=this.val())},val:function(){return gx.fn.getControlValue("SECTORNOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(59,function(){});n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORPRECIO",fmt:0,gxz:"Z23SectorPrecio",gxold:"O23SectorPrecio",gxvar:"A23SectorPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A23SectorPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z23SectorPrecio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SECTORPRECIO",gx.O.A23SectorPrecio,0)},c2v:function(){this.val()!==undefined&&(gx.O.A23SectorPrecio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SECTORPRECIO",".")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"int",len:5,dec:0,sign:!1,pic:"ZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Sectorentradasvendidas,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORENTRADASVENDIDAS",fmt:0,gxz:"Z25SectorEntradasVendidas",gxold:"O25SectorEntradasVendidas",gxvar:"A25SectorEntradasVendidas",ucs:[],op:[74,69],ip:[74,69],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A25SectorEntradasVendidas=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z25SectorEntradasVendidas=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SECTORENTRADASVENDIDAS",gx.O.A25SectorEntradasVendidas,0)},c2v:function(){this.val()!==undefined&&(gx.O.A25SectorEntradasVendidas=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SECTORENTRADASVENDIDAS",".")},nac:gx.falseFn};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"int",len:5,dec:0,sign:!1,pic:"ZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Sectorentradasdisponibles,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORENTRADASDISPONIBLES",fmt:0,gxz:"Z24SectorEntradasDisponibles",gxold:"O24SectorEntradasDisponibles",gxvar:"A24SectorEntradasDisponibles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A24SectorEntradasDisponibles=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z24SectorEntradasDisponibles=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SECTORENTRADASDISPONIBLES",gx.O.A24SectorEntradasDisponibles,0)},c2v:function(){this.val()!==undefined&&(gx.O.A24SectorEntradasDisponibles=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SECTORENTRADASDISPONIBLES",".")},nac:gx.falseFn};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Paiscompraid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISCOMPRAID",fmt:0,gxz:"Z12PaisCompraId",gxold:"O12PaisCompraId",gxvar:"A12PaisCompraId",ucs:[],op:[84],ip:[84,79],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A12PaisCompraId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12PaisCompraId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PAISCOMPRAID",gx.O.A12PaisCompraId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A12PaisCompraId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PAISCOMPRAID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV13Insert_PaisCompraId)}};this.declareDomainHdlr(79,function(){});n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISCOMPRANOMBRE",fmt:0,gxz:"Z27PaisCompraNombre",gxold:"O27PaisCompraNombre",gxvar:"A27PaisCompraNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A27PaisCompraNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z27PaisCompraNombre=n)},v2c:function(){gx.fn.setControlValue("PAISCOMPRANOMBRE",gx.O.A27PaisCompraNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A27PaisCompraNombre=this.val())},val:function(){return gx.fn.getControlValue("PAISCOMPRANOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(84,function(){});n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"BTN_ENTER",grid:0,evt:"e13046_client",std:"ENTER"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"BTN_CANCEL",grid:0,evt:"e14046_client"};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"BTN_DELETE",grid:0,evt:"e20046_client",std:"DELETE"};n[94]={id:94,fld:"PROMPT_5",grid:6};n[95]={id:95,fld:"PROMPT_9",grid:6};n[96]={id:96,fld:"PROMPT_12",grid:6};this.A11EntradaId=0;this.Z11EntradaId=0;this.O11EntradaId=0;this.A5EspectaculoId=0;this.Z5EspectaculoId=0;this.O5EspectaculoId=0;this.A8EspectaculoNombre="";this.Z8EspectaculoNombre="";this.O8EspectaculoNombre="";this.A19EspectaculoFecha=gx.date.nullDate();this.Z19EspectaculoFecha=gx.date.nullDate();this.O19EspectaculoFecha=gx.date.nullDate();this.A9SectorId=0;this.Z9SectorId=0;this.O9SectorId=0;this.A21SectorNombre="";this.Z21SectorNombre="";this.O21SectorNombre="";this.A23SectorPrecio=0;this.Z23SectorPrecio=0;this.O23SectorPrecio=0;this.A25SectorEntradasVendidas=0;this.Z25SectorEntradasVendidas=0;this.O25SectorEntradasVendidas=0;this.A24SectorEntradasDisponibles=0;this.Z24SectorEntradasDisponibles=0;this.O24SectorEntradasDisponibles=0;this.A12PaisCompraId=0;this.Z12PaisCompraId=0;this.O12PaisCompraId=0;this.A27PaisCompraNombre="";this.Z27PaisCompraNombre="";this.O27PaisCompraNombre="";this.AV16Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV11Insert_EspectaculoId=0;this.AV12Insert_SectorId=0;this.AV13Insert_PaisCompraId=0;this.AV17GXV1=0;this.AV14TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7EntradaId=0;this.AV10WebSession={};this.A11EntradaId=0;this.A5EspectaculoId=0;this.A9SectorId=0;this.A12PaisCompraId=0;this.A25SectorEntradasVendidas=0;this.Gx_date=gx.date.nullDate();this.A24SectorEntradasDisponibles=0;this.A8EspectaculoNombre="";this.A19EspectaculoFecha=gx.date.nullDate();this.A21SectorNombre="";this.A23SectorPrecio=0;this.A27PaisCompraNombre="";this.A22SectorCapacidad=0;this.Gx_mode="";this.Events={e12042_client:["AFTER TRN",!0],e13046_client:["ENTER",!0],e14046_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7EntradaId",fld:"vENTRADAID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7EntradaId",fld:"vENTRADAID",pic:"ZZZ9",hsh:!0},{av:"A11EntradaId",fld:"ENTRADAID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"A11EntradaId",fld:"ENTRADAID",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_ENTRADAID=[[],[]];this.EvtParms.VALID_ESPECTACULOID=[[{av:"A5EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"},{av:"A19EspectaculoFecha",fld:"ESPECTACULOFECHA",pic:""},{av:"Gx_date",fld:"vTODAY",pic:""},{av:"A8EspectaculoNombre",fld:"ESPECTACULONOMBRE",pic:""}],[{av:"A8EspectaculoNombre",fld:"ESPECTACULONOMBRE",pic:""},{av:"A19EspectaculoFecha",fld:"ESPECTACULOFECHA",pic:""}]];this.EvtParms.VALID_ESPECTACULOFECHA=[[],[]];this.EvtParms.VALID_SECTORID=[[{av:"A5EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"},{av:"A9SectorId",fld:"SECTORID",pic:"ZZZ9"},{av:"A21SectorNombre",fld:"SECTORNOMBRE",pic:""},{av:"A23SectorPrecio",fld:"SECTORPRECIO",pic:"ZZZZZ9"},{av:"A22SectorCapacidad",fld:"SECTORCAPACIDAD",pic:"ZZZZ9"}],[{av:"A21SectorNombre",fld:"SECTORNOMBRE",pic:""},{av:"A23SectorPrecio",fld:"SECTORPRECIO",pic:"ZZZZZ9"},{av:"A22SectorCapacidad",fld:"SECTORCAPACIDAD",pic:"ZZZZ9"}]];this.EvtParms.VALID_SECTORENTRADASVENDIDAS=[[{av:"A24SectorEntradasDisponibles",fld:"SECTORENTRADASDISPONIBLES",pic:"ZZZZ9"},{av:"A25SectorEntradasVendidas",fld:"SECTORENTRADASVENDIDAS",pic:"ZZZZ9"}],[{av:"A24SectorEntradasDisponibles",fld:"SECTORENTRADASDISPONIBLES",pic:"ZZZZ9"},{av:"A25SectorEntradasVendidas",fld:"SECTORENTRADASVENDIDAS",pic:"ZZZZ9"}]];this.EvtParms.VALID_SECTORENTRADASDISPONIBLES=[[],[]];this.EvtParms.VALID_PAISCOMPRAID=[[{av:"A12PaisCompraId",fld:"PAISCOMPRAID",pic:"ZZZ9"},{av:"A27PaisCompraNombre",fld:"PAISCOMPRANOMBRE",pic:""}],[{av:"A27PaisCompraNombre",fld:"PAISCOMPRANOMBRE",pic:""}]];this.setPrompt("PROMPT_5",[39]);this.setPrompt("PROMPT_9",[54]);this.setPrompt("PROMPT_12",[79]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("A22SectorCapacidad","SECTORCAPACIDAD",0,"int",5,0);this.setVCMap("AV7EntradaId","vENTRADAID",0,"int",4,0);this.setVCMap("AV11Insert_EspectaculoId","vINSERT_ESPECTACULOID",0,"int",4,0);this.setVCMap("AV12Insert_SectorId","vINSERT_SECTORID",0,"int",4,0);this.setVCMap("AV13Insert_PaisCompraId","vINSERT_PAISCOMPRAID",0,"int",4,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("AV16Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"GeneralUITransactionContext",0,0);this.Initialize();this.LvlOlds[6]=["O25SectorEntradasVendidas"]});gx.wi(function(){gx.createParentObj(this.entrada)})