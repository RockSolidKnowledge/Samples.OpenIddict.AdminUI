"use strict";(self.webpackChunkadmin_ui_openiddict=self.webpackChunkadmin_ui_openiddict||[]).push([[419],{4822:(C,u,o)=>{o.d(u,{$:()=>T});var t=o(2734),e=o(2771),r=o(4438),c=o(1626),v=o(9564);let y=(()=>{class p extends t.x{constructor(m,d){super(),this.http=m,this.headersService=d,this.userSubject=new e.m(1),this.actionUrl="clients",this.headers=this.headersService.setHeaders()}getAudits(m,d,g,l,P,i,s){throw new Error("AuditClientService doesn't support getAudits method")}getResourceAudits(m,d,g,l,P,i,s,a,n){const f=this.buildParams(g,P,l,i,s,a,n,d);return this.http.get(`${this.actionUrl}/${m}/auditedEvents`,{headers:this.headers,params:f})}static{this.\u0275fac=function(d){return new(d||p)(r.KVO(c.Qq),r.KVO(v.m))}}static{this.\u0275prov=r.jDH({token:p,factory:p.\u0275fac})}}return p})();var _=o(9838),w=o(1594),I=o(3577),E=o(345),b=o(1780),S=o(177),x=o(9861);function A(p,R){if(1&p&&r.nrm(0,"app-audits-list",2),2&p){const m=r.XpG();r.Y8G("resourceName",m.clientId)}}let T=(()=>{class p{constructor(m,d,g){this.clientsService=m,this.titleService=d,this.translate=g}ngOnInit(){this.clientsService.unsavedCache$.pipe((0,w.$)()).subscribe(d=>{this.clientId=d.id,this.clientName=d.clientName});const m=this.translate.instant("Users.Singular")+" "+this.clientName+" "+this.translate.instant("Nav.Audits")+" - "+_.$9.SITE_TITLE;this.titleService.setTitle(m)}static{this.\u0275fac=function(d){return new(d||p)(r.rXU(I.e),r.rXU(E.hE),r.rXU(b.c$))}}static{this.\u0275cmp=r.VBU({type:p,selectors:[["app-audit-clients"]],features:[r.Jv_([{provide:t.x,useClass:y}])],decls:2,vars:1,consts:[["id","clientList"],[3,"resourceName",4,"ngIf"],[3,"resourceName"]],template:function(d,g){1&d&&(r.j41(0,"div",0),r.DNE(1,A,1,1,"app-audits-list",1),r.k0s()),2&d&&(r.R7$(),r.Y8G("ngIf",g.clientId))},dependencies:[S.bT,x.k],encapsulation:2})}}return p})()},1681:(C,u,o)=>{o.d(u,{d:()=>i});var t=o(1594),e=o(4438),r=o(8173),c=o(3577),v=o(7499),y=o(1583),_=o(177),w=o(6719),I=o(251);const E=["AdvancedTabs"],b=["tokensComponent"];function S(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Clients.AuthRequest")("tabValue","authrequest")}function x(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Common.Consent")("tabValue","consent")}function A(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Clients.Tokens.Title")("tabValue","tokens")}function T(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Common.RefreshTokens")("tabValue","refreshtokens")}function p(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Common.SingeSignOut")("tabValue","singlesignout")}function R(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Common.DeviceFlow")("tabValue","deviceflow")}function m(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Index.Claims.Heading")("tabValue","claims")}function d(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Common.IdentityProviders")("tabValue","identityproviders")}function g(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Common.Properties")("tabValue","properties")}function l(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Common.DPoP")("tabValue","dpop")}function P(s,a){1&s&&e.nrm(0,"app-custom-tab",3),2&s&&e.Y8G("tabTitle","Common.Other")("tabValue","other")}let i=(()=>{class s{constructor(n,f,h){this.clientViewService=n,this.clientCachingService=f,this.dialogService=h}ngOnInit(){this.clientCachingService.unsavedCache$.pipe((0,t.$)()).subscribe(n=>{this.client=JSON.parse(JSON.stringify(n))})}static{this.\u0275fac=function(f){return new(f||s)(e.rXU(r.q),e.rXU(c.e),e.rXU(v.o))}}static{this.\u0275cmp=e.VBU({type:s,selectors:[["app-client-advanced"]],viewQuery:function(f,h){if(1&f&&(e.GBs(E,7),e.GBs(b,7)),2&f){let M;e.mGM(M=e.lsd())&&(h.advancedTabs=M.first),e.mGM(M=e.lsd())&&(h.tokenComp=M.first)}},decls:14,vars:12,consts:[[3,"pillMode"],[3,"tabTitle","tabValue",4,"ngIf"],["id","editClientAdvanced"],[3,"tabTitle","tabValue"]],template:function(f,h){1&f&&(e.j41(0,"app-custom-tabs",0),e.DNE(1,S,1,2,"app-custom-tab",1)(2,x,1,2,"app-custom-tab",1)(3,A,1,2,"app-custom-tab",1)(4,T,1,2,"app-custom-tab",1)(5,p,1,2,"app-custom-tab",1)(6,R,1,2,"app-custom-tab",1)(7,m,1,2,"app-custom-tab",1)(8,d,1,2,"app-custom-tab",1)(9,g,1,2,"app-custom-tab",1)(10,l,1,2,"app-custom-tab",1)(11,P,1,2,"app-custom-tab",1),e.k0s(),e.j41(12,"div",2),e.nrm(13,"router-outlet"),e.k0s()),2&f&&(e.Y8G("pillMode",!0),e.R7$(),e.Y8G("ngIf",h.clientViewService.authRequest.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.consent.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.tokens.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.refreshTokens.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.singleSignOut.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.deviceFlow.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.claims.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.identityProviders.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.properties.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.dpop.display),e.R7$(),e.Y8G("ngIf",h.clientViewService.other.display))},dependencies:[y.n3,_.bT,w.G,I.v],encapsulation:2})}}return s})()},4117:(C,u,o)=>{o.d(u,{J:()=>t});class t{}},1207:(C,u,o)=>{o.d(u,{H:()=>t});class t{static{this.claimTypes=new Map([["Actor","http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor"],["Anonymous","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/anonymous"],["Authentication","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authentication"],["AuthenticationInstant","http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationinstant"],["AuthenticationMethod","http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationmethod"],["AuthorizationDecision","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision"],["CookiePath","http://schemas.microsoft.com/ws/2008/06/identity/claims/cookiepath"],["Country","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country"],["DateOfBirth","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth"],["DenyOnlyPrimaryGroupSid","http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarygroupsid"],["DenyOnlyPrimarySid","http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarysid"],["DenyOnlySid","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/denyonlysid"],["DenyOnlyWindowsDeviceGroup","http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlywindowsdevicegroup"],["Dns","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dns"],["Dsa","http://schemas.microsoft.com/ws/2008/06/identity/claims/dsa"],["Email","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],["Expiration","http://schemas.microsoft.com/ws/2008/06/identity/claims/expiration"],["Expired","http://schemas.microsoft.com/ws/2008/06/identity/claims/expired"],["Gender","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender"],["GivenName","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"],["GroupSid","http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid"],["Hash","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/hash"],["HomePhone","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/homephone"],["IsPersistent","http://schemas.microsoft.com/ws/2008/06/identity/claims/ispersistent"],["Locality","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/locality"],["MobilePhone","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone"],["Name","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],["NameIdentifier","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],["OtherPhone","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/otherphone"],["PostalCode","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/postalcode"],["PrimaryGroupSid","http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid"],["PrimarySid","http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"],["Role","http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],["Rsa","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/rsa"],["SerialNumber","http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber"],["Sid","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"],["Spn","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/spn"],["StateOrProvince","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/stateorprovince"],["StreetAddress","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/streetaddress"],["Surname","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"],["System","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/system"],["Thumbprint","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/thumbprint"],["Upn","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn"],["Uri","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri"],["UserData","http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata"],["Version","http://schemas.microsoft.com/ws/2008/06/identity/claims/version"],["Webpage","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/webpage"],["WindowsAccountName","http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname"],["WindowsDeviceClaim","http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdeviceclaim"],["WindowsDeviceGroup","http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdevicegroup"],["WindowsFqbnVersion","http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsfqbnversion"],["WindowsSubAuthority","http://schemas.microsoft.com/ws/2008/06/identity/claims/windowssubauthority"],["WindowsUserClaim","http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsuserclaim"],["X500DistinguishedName","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/x500distinguishedname"]])}}},3954:(C,u,o)=>{o.d(u,{W:()=>e,s:()=>t});class t{constructor(c,v,y,_){this.isAllowedCorsOrigin=!1,this.isRedirectUri=!1,this.isPostLogoutRedirectUri=!1,this.url=c,this.isAllowedCorsOrigin=v,this.isRedirectUri=y,this.isPostLogoutRedirectUri=_}}class e extends t{constructor(c,v,y,_,w){super(c,v,y,_),this.oldUrl=c,this.index=w}}},1477:(C,u,o)=>{o.d(u,{c:()=>t});var t=function(e){return e.Identity="identity",e.Protected="protected",e}(t||{})},9166:(C,u,o)=>{o.d(u,{s:()=>e});var t=o(4438);let e=(()=>{class c{constructor(){}uploadFile(y,_){throw new Error("not implemented")}uploadViaMetaData(y,_){throw new Error("not implemented")}updateCertCache(y){throw new Error("not implemented")}static{this.\u0275fac=function(_){return new(_||c)}}static{this.\u0275prov=t.jDH({token:c,factory:c.\u0275fac})}}return c})()},6520:(C,u,o)=>{o.d(u,{C:()=>g});var t=o(4438);class e{constructor(){this.key="",this.value=""}}class r extends e{constructor(){super()}}var c=o(4252),v=o(1258),y=o(5794),_=o(1780),w=o(4754),I=o(9812),E=o(177),b=o(9417),S=o(8577),x=o(7294),A=o(3899),T=o(8698);const p=["addButton"];function R(l,P){if(1&l){const i=t.RV6();t.j41(0,"app-action-bar"),t.qex(1,5),t.j41(2,"button",6,0),t.bIt("click",function(){t.eBV(i);const a=t.XpG();return t.Njj(a.openAddModal())}),t.EFF(4),t.nI1(5,"translate"),t.k0s(),t.bVm(),t.k0s()}2&l&&(t.R7$(2),t.Y8G("id","addClaim"),t.R7$(2),t.SpI(" ",t.bMT(5,2,"Clients.Properties.AddProperty")," "))}function m(l,P){if(1&l){const i=t.RV6();t.j41(0,"app-custom-modal",7),t.bIt("onCancel",function(){t.eBV(i);const a=t.XpG();return t.Njj(a.closeAddAndReset())})("onSave",function(){t.eBV(i);const a=t.XpG();return t.Njj(a.addProperty())}),t.j41(1,"app-form-row",8)(2,"input",9),t.mxI("ngModelChange",function(a){t.eBV(i);const n=t.XpG();return t.DH7(n.addProp.key,a)||(n.addProp.key=a),t.Njj(a)}),t.k0s()(),t.j41(3,"app-form-row",10)(4,"input",11),t.mxI("ngModelChange",function(a){t.eBV(i);const n=t.XpG();return t.DH7(n.addProp.value,a)||(n.addProp.value=a),t.Njj(a)}),t.k0s()()()}if(2&l){const i=t.XpG();t.Y8G("title","Clients.Properties.AddProperty")("modalId",i.addModalId)("actions",i.addModalActions)("addDisabled",i.addProp.key.length<1||i.addProp.value.length<1),t.R7$(),t.Y8G("label","Common.Key")("id","propertyAddKey"),t.R7$(),t.R50("ngModel",i.addProp.key),t.R7$(),t.Y8G("label","Common.Value")("id","propertyAddValue")("isLast",!0),t.R7$(),t.R50("ngModel",i.addProp.value)}}function d(l,P){if(1&l){const i=t.RV6();t.j41(0,"app-custom-modal",7),t.bIt("onCancel",function(){t.eBV(i);const a=t.XpG();return t.Njj(a.closeModalAndReset())})("onSave",function(){t.eBV(i);const a=t.XpG();return t.Njj(a.saveEdit())}),t.j41(1,"app-form-row",8)(2,"input",12),t.mxI("ngModelChange",function(a){t.eBV(i);const n=t.XpG();return t.DH7(n.editProp.key,a)||(n.editProp.key=a),t.Njj(a)}),t.k0s()(),t.j41(3,"app-form-row",10)(4,"input",13),t.mxI("ngModelChange",function(a){t.eBV(i);const n=t.XpG();return t.DH7(n.editProp.value,a)||(n.editProp.value=a),t.Njj(a)}),t.k0s()()()}if(2&l){const i=t.XpG();t.Y8G("title","Clients.Properties.EditProperty")("modalId",i.editModalId)("actions",i.editModalActions)("addDisabled",i.editProp.key.length<1||i.editProp.value.length<1),t.R7$(),t.Y8G("label","Common.Key")("id","propertyEditKey"),t.R7$(),t.R50("ngModel",i.editProp.key),t.R7$(),t.Y8G("label","Common.Value")("id","propertyEditValue")("isLast",!0),t.R7$(),t.R50("ngModel",i.editProp.value)}}let g=(()=>{class l{set properties(i){this._properties=i||[]}get properties(){return this._properties}set isReadOnly(i){this._isReadOnly=i||!1}get isReadOnly(){return this._isReadOnly}set modalId(i){this._addModalId="add_"+i,this._editModalId="edit_"+i}get addModalId(){return this._addModalId}get editModalId(){return this._editModalId}constructor(i,s,a,n){this.toastr=i,this.translate=s,this.modalService=a,this.dataTableService=n,this.propertiesChanged=new t.bkB,this.addProp=new e,this.editing=!1,this.editProp=new r,this.propertyDataTableActions=[c.AA.Delete,c.AA.Select],this.addModalActions=[v.N.Save],this.editModalActions=[v.N.Save],this._properties=[]}ngOnInit(){this.dtsSubscription=this.dataTableService.deleteRowEvent.subscribe(i=>{this.deleteProperty(i)})}ngOnDestroy(){this.dtsSubscription?.unsubscribe()}openAddModal(){this.modalService.showById(this.addModalId,this.addButtonRef)}closeAddAndReset(){this.addProp=new e,this.modalService.hideById(this.addModalId)}editProperty(i){this.editProp=JSON.parse(JSON.stringify(i.data)),this.editProp.originalIndex=this.properties.indexOf(i.data),this.editing=!0,this.modalService.showById(this.editModalId,i.element)}closeModalAndReset(){this.editProp=new r,this.editing=!1,this.modalService.hideById(this.editModalId)}saveEdit(){const i=this.properties.slice(),s=i[this.editProp.originalIndex];s.key=this.editProp.key,s.value=this.editProp.value,this.updateProperties(i),this.closeModalAndReset()}addProperty(){if(this.properties.find(s=>s.key===this.addProp.key))return void this.toastr.error(this.translate.instant("Clients.UnableToAddProperty"),this.translate.instant("Notifications.Error"));if(null==this.addProp.key||""===this.addProp.key.trim())return void this.toastr.error("Key is Invalid",this.translate.instant("Notifications.Error"));if(null==this.addProp.value||""===this.addProp.value.trim())return void this.toastr.error("Value is Invalid",this.translate.instant("Notifications.Error"));const i=this.properties.slice();i.push(this.addProp),this.updateProperties(i),this.addProp=new e}deleteProperty(i){const s=this.properties.slice();s.splice(i,1),this.updateProperties(s)}updateProperties(i){this.properties=i,this.propertiesChanged.emit(this.properties)}static{this.\u0275fac=function(s){return new(s||l)(t.rXU(y.tw),t.rXU(_.c$),t.rXU(w.B),t.rXU(I.I))}}static{this.\u0275cmp=t.VBU({type:l,selectors:[["app-properties-editor"]],viewQuery:function(s,a){if(1&s&&t.GBs(p,5),2&s){let n;t.mGM(n=t.lsd())&&(a.addButtonRef=n.first)}},inputs:{properties:"properties",isReadOnly:"isReadOnly",modalId:"modalId"},outputs:{propertiesChanged:"propertiesChanged"},decls:6,vars:15,consts:[["addButton",""],[4,"ngIf"],[3,"title","modalId","actions","addDisabled","onCancel","onSave",4,"ngIf"],[3,"onSelect","isReadOnly","rows","norowslabel","actions"],[3,"prop","title","headClasses","cellClasses"],["right",""],[1,"tw-btn-success",3,"click","id"],[3,"onCancel","onSave","title","modalId","actions","addDisabled"],[3,"label","id"],["id","propertyAddKey","type","text",1,"tw-form-control","tw-max-w-full",3,"ngModelChange","ngModel"],[3,"label","id","isLast"],["id","propertyAddValue","type","text",1,"tw-form-control","tw-max-w-full",3,"ngModelChange","ngModel"],["id","propertyEditKey","type","text",1,"tw-form-control","tw-max-w-full",3,"ngModelChange","ngModel"],["id","propertyEditValue","type","text",1,"tw-form-control","tw-max-w-full",3,"ngModelChange","ngModel"]],template:function(s,a){1&s&&(t.DNE(0,R,6,4,"app-action-bar",1)(1,m,5,11,"app-custom-modal",2),t.j41(2,"app-data-table",3),t.bIt("onSelect",function(f){return a.editProperty(f)}),t.nrm(3,"app-data-table-column",4)(4,"app-data-table-column",4),t.k0s(),t.DNE(5,d,5,11,"app-custom-modal",2)),2&s&&(t.Y8G("ngIf",!a.isReadOnly),t.R7$(),t.Y8G("ngIf",!a.isReadOnly),t.R7$(),t.Y8G("isReadOnly",a.isReadOnly)("rows",a.properties)("norowslabel","Clients.Properties.None")("actions",a.propertyDataTableActions),t.R7$(),t.Y8G("prop","key")("title","Common.Key")("headClasses","md:tw-w-1/3")("cellClasses","tw-max-w-0 tw-truncate"),t.R7$(),t.Y8G("prop","value")("title","Common.Value")("headClasses","tw-hidden sm:tw-table-cell")("cellClasses","tw-hidden tw-max-w-0 tw-truncate sm:tw-table-cell"),t.R7$(),t.Y8G("ngIf",!a.isReadOnly))},dependencies:[E.bT,b.me,b.BC,b.vS,c.up,S.w,x.n,A.G,T.Y,_.D9],encapsulation:2})}}return l})()}}]);