gx.evt.autoSkip=!1;gx.define("wwinvitacion",!1,function(){var n,t;this.ServerClass="wwinvitacion";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwinvitacion.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="ObligatorioPrueba001";this.SetStandaloneVars=function(){this.A31EspectaculoCantidadInvitacione=gx.fn.getIntegerValue("ESPECTACULOCANTIDADINVITACIONE",".")};this.Valid_Espectaculoid=function(){var n=gx.fn.currentGridRowImpl(27);return this.validCliEvt("Valid_Espectaculoid",27,function(){try{if(gx.fn.currentGridRowImpl(27)===0)return!0;var n=gx.util.balloon.getNew("ESPECTACULOID",gx.fn.currentGridRowImpl(27));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculoinvitacionesentrega=function(){var n=gx.fn.currentGridRowImpl(27);return this.validCliEvt("Valid_Espectaculoinvitacionesentrega",27,function(){try{if(gx.fn.currentGridRowImpl(27)===0)return!0;var n=gx.util.balloon.getNew("ESPECTACULOINVITACIONESENTREGA",gx.fn.currentGridRowImpl(27));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110f2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e150f2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e160f2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,22,23,24,25,26,28,29,30,31,32,33,34];this.GXLastCtrlId=34;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",27,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwinvitacion",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(17,28,"INVITACIONID","Id","","InvitacionId","int",0,"px",4,4,"end",null,[],17,"InvitacionId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(30,29,"INVITACIONNOMBREINVITADO","Nombre Invitado","","InvitacionNombreInvitado","char",0,"px",60,60,"start",null,[],30,"InvitacionNombreInvitado",!0,0,!1,!1,"attribute-description",0,"column");t.addSingleLineEdit(5,30,"ESPECTACULOID","Espectáculo Id","","EspectaculoId","int",0,"px",4,4,"end",null,[],5,"EspectaculoId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(8,31,"ESPECTACULONOMBRE","Nombre Espectáculo","","EspectaculoNombre","char",0,"px",60,60,"start",null,[],8,"EspectaculoNombre",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(19,32,"ESPECTACULOFECHA","Fecha","","EspectaculoFecha","date",0,"px",8,8,"end",null,[],19,"EspectaculoFecha",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(32,33,"ESPECTACULOINVITACIONESDISPONI"," Invitaciones Disp.","","EspectaculoInvitacionesDisponi","int",0,"px",4,4,"end",null,[],32,"EspectaculoInvitacionesDisponi",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(33,34,"ESPECTACULOINVITACIONESENTREGA","Invitaciones Entregadas","","EspectaculoInvitacionesEntrega","int",0,"px",4,4,"end",null,[],33,"EspectaculoInvitacionesEntrega",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"GRIDCELL",grid:0};n[6]={id:6,fld:"GRIDTABLE",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLETOP",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"BTNINSERT",grid:0,evt:"e110f2_client"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vINVITACIONNOMBREINVITADO",fmt:0,gxz:"ZV11InvitacionNombreInvitado",gxold:"OV11InvitacionNombreInvitado",gxvar:"AV11InvitacionNombreInvitado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11InvitacionNombreInvitado=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11InvitacionNombreInvitado=n)},v2c:function(){gx.fn.setControlValue("vINVITACIONNOMBREINVITADO",gx.O.AV11InvitacionNombreInvitado,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11InvitacionNombreInvitado=this.val())},val:function(){return gx.fn.getControlValue("vINVITACIONNOMBREINVITADO")},nac:gx.falseFn};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"GRIDCONTAINER",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVITACIONID",fmt:0,gxz:"Z17InvitacionId",gxold:"O17InvitacionId",gxvar:"A17InvitacionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A17InvitacionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z17InvitacionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("INVITACIONID",n||gx.fn.currentGridRowImpl(27),gx.O.A17InvitacionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A17InvitacionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("INVITACIONID",n||gx.fn.currentGridRowImpl(27),".")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVITACIONNOMBREINVITADO",fmt:0,gxz:"Z30InvitacionNombreInvitado",gxold:"O30InvitacionNombreInvitado",gxvar:"A30InvitacionNombreInvitado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A30InvitacionNombreInvitado=n)},v2z:function(n){n!==undefined&&(gx.O.Z30InvitacionNombreInvitado=n)},v2c:function(n){gx.fn.setGridControlValue("INVITACIONNOMBREINVITADO",n||gx.fn.currentGridRowImpl(27),gx.O.A30InvitacionNombreInvitado,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30InvitacionNombreInvitado=this.val(n))},val:function(n){return gx.fn.getGridControlValue("INVITACIONNOMBREINVITADO",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z5EspectaculoId",gxold:"O5EspectaculoId",gxvar:"A5EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A5EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(27),gx.O.A5EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(27),".")},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONOMBRE",fmt:0,gxz:"Z8EspectaculoNombre",gxold:"O8EspectaculoNombre",gxvar:"A8EspectaculoNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A8EspectaculoNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z8EspectaculoNombre=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULONOMBRE",n||gx.fn.currentGridRowImpl(27),gx.O.A8EspectaculoNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8EspectaculoNombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULONOMBRE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFECHA",fmt:0,gxz:"Z19EspectaculoFecha",gxold:"O19EspectaculoFecha",gxvar:"A19EspectaculoFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A19EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z19EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFECHA",n||gx.fn.currentGridRowImpl(27),gx.O.A19EspectaculoFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A19EspectaculoFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("ESPECTACULOFECHA",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOINVITACIONESDISPONI",fmt:0,gxz:"Z32EspectaculoInvitacionesDisponi",gxold:"O32EspectaculoInvitacionesDisponi",gxvar:"A32EspectaculoInvitacionesDisponi",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A32EspectaculoInvitacionesDisponi=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z32EspectaculoInvitacionesDisponi=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOINVITACIONESDISPONI",n||gx.fn.currentGridRowImpl(27),gx.O.A32EspectaculoInvitacionesDisponi,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A32EspectaculoInvitacionesDisponi=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOINVITACIONESDISPONI",n||gx.fn.currentGridRowImpl(27),".")},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:this.Valid_Espectaculoinvitacionesentrega,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOINVITACIONESENTREGA",fmt:0,gxz:"Z33EspectaculoInvitacionesEntrega",gxold:"O33EspectaculoInvitacionesEntrega",gxvar:"A33EspectaculoInvitacionesEntrega",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A33EspectaculoInvitacionesEntrega=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z33EspectaculoInvitacionesEntrega=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOINVITACIONESENTREGA",n||gx.fn.currentGridRowImpl(27),gx.O.A33EspectaculoInvitacionesEntrega,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A33EspectaculoInvitacionesEntrega=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOINVITACIONESENTREGA",n||gx.fn.currentGridRowImpl(27),".")},nac:gx.falseFn};this.AV11InvitacionNombreInvitado="";this.ZV11InvitacionNombreInvitado="";this.OV11InvitacionNombreInvitado="";this.Z17InvitacionId=0;this.O17InvitacionId=0;this.Z30InvitacionNombreInvitado="";this.O30InvitacionNombreInvitado="";this.Z5EspectaculoId=0;this.O5EspectaculoId=0;this.Z8EspectaculoNombre="";this.O8EspectaculoNombre="";this.Z19EspectaculoFecha=gx.date.nullDate();this.O19EspectaculoFecha=gx.date.nullDate();this.Z32EspectaculoInvitacionesDisponi=0;this.O32EspectaculoInvitacionesDisponi=0;this.Z33EspectaculoInvitacionesEntrega=0;this.O33EspectaculoInvitacionesEntrega=0;this.AV11InvitacionNombreInvitado="";this.A31EspectaculoCantidadInvitacione=0;this.A17InvitacionId=0;this.A30InvitacionNombreInvitado="";this.A5EspectaculoId=0;this.A8EspectaculoNombre="";this.A19EspectaculoFecha=gx.date.nullDate();this.A32EspectaculoInvitacionesDisponi=0;this.A33EspectaculoInvitacionesEntrega=0;this.Events={e110f2_client:["'DOINSERT'",!0],e150f2_client:["ENTER",!0],e160f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionNombreInvitado",fld:"vINVITACIONNOMBREINVITADO",pic:""}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A17InvitacionId",fld:"INVITACIONID",pic:"ZZZ9",hsh:!0},{av:"A5EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("INVITACIONNOMBREINVITADO","Link")',ctrl:"INVITACIONNOMBREINVITADO",prop:"Link"},{av:'gx.fn.getCtrlProperty("ESPECTACULONOMBRE","Link")',ctrl:"ESPECTACULONOMBRE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A17InvitacionId",fld:"INVITACIONID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionNombreInvitado",fld:"vINVITACIONNOMBREINVITADO",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionNombreInvitado",fld:"vINVITACIONNOMBREINVITADO",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionNombreInvitado",fld:"vINVITACIONNOMBREINVITADO",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionNombreInvitado",fld:"vINVITACIONNOMBREINVITADO",pic:""}],[]];this.EvtParms.VALID_ESPECTACULOID=[[],[]];this.EvtParms.VALID_ESPECTACULOINVITACIONESENTREGA=[[],[]];this.setVCMap("A31EspectaculoCantidadInvitacione","ESPECTACULOCANTIDADINVITACIONE",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[18]);t.addRefreshingParm(this.GXValidFnc[18]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwinvitacion)})