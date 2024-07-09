"use strict";(self.webpackChunkadmin_ui_openiddict=self.webpackChunkadmin_ui_openiddict||[]).push([[200],{2200:(k,r,i)=>{i.r(r),i.d(r,{ClaimTypesModule:()=>K});var y=i(177),c=i(1583),p=i(9417),T=i(779),v=i(534),d=i(7005),f=i(8939),u=i(4193),R=i(1993),C=i(8389),m=i(1780),h=i(5731),g=i(3665),G=i(7175),$=i(367),Y=i(9838),I=i(6303),O=i(7921),e=i(4438),V=i(5794),F=i(526),D=i(345),E=i(5424),S=i(3680),b=i(8698),x=i(8762);const j=(a,n)=>({title:a,link:n}),t=a=>[a];function w(a,n){1&a&&(e.j41(0,"span",10),e.EFF(1),e.nI1(2,"translate"),e.k0s()),2&a&&(e.R7$(),e.JRh(e.bMT(2,1,"Common.Types.String")))}function N(a,n){1&a&&(e.j41(0,"span",10),e.EFF(1),e.nI1(2,"translate"),e.k0s()),2&a&&(e.R7$(),e.JRh(e.bMT(2,1,"Common.Types.Int")))}function X(a,n){1&a&&(e.j41(0,"span",10),e.EFF(1),e.nI1(2,"translate"),e.k0s()),2&a&&(e.R7$(),e.JRh(e.bMT(2,1,"Common.Types.DateTime")))}function M(a,n){1&a&&(e.j41(0,"span",10),e.EFF(1),e.nI1(2,"translate"),e.k0s()),2&a&&(e.R7$(),e.JRh(e.bMT(2,1,"Common.Types.Boolean")))}function U(a,n){1&a&&(e.j41(0,"span",11),e.EFF(1),e.nI1(2,"translate"),e.k0s()),2&a&&(e.R7$(),e.JRh(e.bMT(2,1,"Common.Types.Enum")))}function J(a,n){if(1&a&&(e.j41(0,"app-form-row",3),e.nrm(1,"app-readonly",4),e.k0s()),2&a){const l=e.XpG(2);e.Y8G("label","Claims.AllowedValues"),e.R7$(),e.Y8G("values",e.eq3(3,t,l.claimTypeReadOnlyDictionary.allowedValues))("fieldType",l.ReadOnlyFieldType.CommaSeparated)}}function B(a,n){if(1&a&&(e.j41(0,"app-form-row",3),e.nrm(1,"app-readonly",4),e.k0s()),2&a){const l=e.XpG(2);e.Y8G("label","Claims.RegexRule"),e.R7$(),e.Y8G("values",e.eq3(3,t,l.claimTypeReadOnlyDictionary.rule))("fieldType",l.ReadOnlyFieldType.Single)}}function L(a,n){if(1&a&&(e.j41(0,"app-form-row",3),e.nrm(1,"app-readonly",4),e.k0s()),2&a){const l=e.XpG(2);e.Y8G("label","Claims.RuleValidationFailureDescription"),e.R7$(),e.Y8G("values",e.eq3(3,t,l.claimTypeReadOnlyDictionary.ruleValidationFailureDescription))("fieldType",l.ReadOnlyFieldType.Single)}}function z(a,n){if(1&a&&(e.j41(0,"div",2)(1,"form")(2,"app-form-row",3),e.nrm(3,"app-readonly",4),e.k0s(),e.j41(4,"app-form-row",3),e.nrm(5,"app-readonly",4),e.k0s(),e.j41(6,"app-form-row",3)(7,"div"),e.DNE(8,w,3,3,"span",5)(9,N,3,3,"span",5)(10,X,3,3,"span",5)(11,M,3,3,"span",5)(12,U,3,3,"span",6),e.k0s()(),e.DNE(13,J,2,5,"app-form-row",7),e.j41(14,"app-form-row",3),e.nrm(15,"app-readonly",4),e.k0s(),e.DNE(16,B,2,5,"app-form-row",7)(17,L,2,5,"app-form-row",7),e.j41(18,"app-form-row",8),e.nrm(19,"app-readonly",4),e.k0s(),e.j41(20,"app-form-row",9),e.nrm(21,"app-readonly",4),e.k0s()()()),2&a){const l=e.XpG();e.R7$(2),e.Y8G("label","Common.Name"),e.R7$(),e.Y8G("values",e.eq3(27,t,l.claimTypeReadOnlyDictionary.name))("fieldType",l.ReadOnlyFieldType.Single),e.R7$(),e.Y8G("label","Common.DisplayName"),e.R7$(),e.Y8G("values",e.eq3(29,t,l.claimTypeReadOnlyDictionary.displayName))("fieldType",l.ReadOnlyFieldType.Single),e.R7$(),e.Y8G("label","Common.Type"),e.R7$(2),e.Y8G("ngIf","String"==l.claimTypeValueType),e.R7$(),e.Y8G("ngIf","Int"==l.claimTypeValueType),e.R7$(),e.Y8G("ngIf","DateTime"==l.claimTypeValueType),e.R7$(),e.Y8G("ngIf","Boolean"==l.claimTypeValueType),e.R7$(),e.Y8G("ngIf","Enum"==l.claimTypeValueType),e.R7$(),e.Y8G("ngIf","Enum"===l.claimTypeValueType),e.R7$(),e.Y8G("label","Common.Description"),e.R7$(),e.Y8G("values",e.eq3(31,t,l.claimTypeReadOnlyDictionary.description))("fieldType",l.ReadOnlyFieldType.Single),e.R7$(),e.Y8G("ngIf","String"===l.claimTypeValueType),e.R7$(),e.Y8G("ngIf","String"===l.claimTypeValueType),e.R7$(),e.Y8G("label","Claims.Required")("help","Claims.FutureUsers"),e.R7$(),e.Y8G("values",e.eq3(33,t,l.claimTypeReadOnlyDictionary.required))("fieldType",l.ReadOnlyFieldType.Single),e.R7$(),e.Y8G("label","Common.UserEditable")("help","Claims.UserEditable")("isLast",!0),e.R7$(),e.Y8G("values",e.eq3(35,t,l.claimTypeReadOnlyDictionary.userEditable))("fieldType",l.ReadOnlyFieldType.Single)}}let A=(()=>{class a{constructor(l,o,s,W,Z){this.translate=l,this.toastr=o,this.claimTypeService=s,this.titleService=W,this.errorService=Z}ngOnInit(){this.claimTypeSubscription=this.claimTypeService.getCachedClaimType().subscribe(l=>{this.claimTypeName=l.name,this.claimTypeValueType=l.valueType,this.claimTypeReadOnlyDictionary=new O.b(l),this.titleService.setTitle(this.translate.instant("Claims.Title")+" "+l.name+` - ${Y.$9.SITE_TITLE}`)},l=>{this.errorService.handleError(l)})}ngOnDestroy(){this.claimTypeSubscription.unsubscribe()}get ReadOnlyFieldType(){return I.t}static{this.\u0275fac=function(o){return new(o||a)(e.rXU(m.c$),e.rXU(V.tw),e.rXU(F.X),e.rXU(D.hE),e.rXU(E.I))}}static{this.\u0275cmp=e.VBU({type:a,selectors:[["ng-component"]],decls:4,vars:13,consts:[[3,"title","crumbs","isReadOnly"],["id","viewClaimType","class","tw-container tw-mx-auto",4,"ngIf"],["id","viewClaimType",1,"tw-container","tw-mx-auto"],[3,"label"],[3,"values","fieldType"],["class","disabled inactive",4,"ngIf"],["value","Enum","class","disabled inactive",4,"ngIf"],[3,"label",4,"ngIf"],[3,"label","help"],[3,"label","help","isLast"],[1,"disabled","inactive"],["value","Enum",1,"disabled","inactive"]],template:function(o,s){1&o&&(e.nrm(0,"app-title-bar",0),e.nI1(1,"translate"),e.nI1(2,"localize"),e.DNE(3,z,22,37,"div",1)),2&o&&(e.Y8G("title",s.claimTypeName)("crumbs",e.eq3(11,t,e.l_i(8,j,e.bMT(1,4,"Nav.ClaimTypes"),e.bMT(2,6,"/claim-types"))))("isReadOnly",!0),e.R7$(3),e.Y8G("ngIf",s.claimTypeReadOnlyDictionary))},dependencies:[y.bT,p.qT,p.cb,p.cV,S.z,b.Y,x.O,m.D9,d.tl],styles:["[_nghost-%COMP%]{width:100%;display:block;position:relative}"]})}}return a})();var P=i(3843),Q=i(7677);const H=[{path:"",component:A}];let K=(()=>{class a{static{this.\u0275fac=function(o){return new(o||a)}}static{this.\u0275mod=e.$C({type:a})}static{this.\u0275inj=e.G2t({providers:[f.R],imports:[y.MD,p.YN,p.X1,v.Ss,T.Q_,c.iI.forChild(H),m.h,d.XE,$.m,h.i,u.c,g.t,G.c,R.E,C.w,P.G,Q.N]})}}return a})()}}]);