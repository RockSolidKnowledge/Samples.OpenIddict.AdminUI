"use strict";(self.webpackChunkadmin_ui_openiddict=self.webpackChunkadmin_ui_openiddict||[]).push([[907],{5907:(oe,g,a)=>{a.r(g),a.d(g,{ViewRolesModule:()=>se});var m=a(177),l=a(9417),u=a(1583),d=a(7005),p=a(1780),w=a(1683),y=a(6199),U=a(4193),b=a(2571),C=a(275),I=a(8389),R=a(5731),j=a(7677),F=a(7175),V=a(367),$=a(9838),G=a(7921),P=a(6303),e=a(4438),v=a(3519),M=a(345),x=a(8698),z=a(8762);const f=n=>[n];let N=(()=>{class n{constructor(t,o,s){this.rolesService=t,this.titleService=o,this.translate=s}ngOnInit(){this.getCachedRoleSubscription=this.rolesService.getCachedRole().subscribe(t=>{this.role=t,this.roleReadOnlyDictionary=new G.b(this.role);const o=this.translate.instant("Roles.Role")+" "+this.role.name+" - "+$.$9.SITE_TITLE;this.titleService.setTitle(o)})}ngOnDestroy(){this.getCachedRoleSubscription.unsubscribe()}get ReadOnlyFieldType(){return P.t}static{this.\u0275fac=function(o){return new(o||n)(e.rXU(v.P),e.rXU(M.hE),e.rXU(p.c$))}}static{this.\u0275cmp=e.VBU({type:n,selectors:[["app-view-role-details"]],decls:6,vars:11,consts:[["id","viewRoleDetails",1,"tw-container","tw-mx-auto"],[3,"label"],[3,"values","fieldType"],[3,"label","isLast"]],template:function(o,s){1&o&&(e.j41(0,"div",0)(1,"form")(2,"app-form-row",1),e.nrm(3,"app-readonly",2),e.k0s(),e.j41(4,"app-form-row",3),e.nrm(5,"app-readonly",2),e.k0s()()()),2&o&&(e.R7$(2),e.Y8G("label","Common.Name"),e.R7$(),e.Y8G("values",e.eq3(7,f,s.roleReadOnlyDictionary.name))("fieldType",s.ReadOnlyFieldType.Single),e.R7$(),e.Y8G("label","Common.Description")("isLast",!0),e.R7$(),e.Y8G("values",e.eq3(9,f,s.roleReadOnlyDictionary.description))("fieldType",s.ReadOnlyFieldType.Single))},dependencies:[x.Y,l.qT,l.cb,l.cV,z.O],styles:["[_nghost-%COMP%]{width:100%;display:block;position:relative}"]})}}return n})();var T=a(1413),X=a(1594),S=a(6354),h=a(1716),E=a(9172),L=a(1397),D=a(1986),Y=a(5435),O=a(5794),B=a(5424),J=a(5602),H=a(7156),W=a(7384),Z=a(7294);function A(n,c){if(1&n){const t=e.RV6();e.qex(0,12),e.j41(1,"div",13)(2,"label",14),e.EFF(3),e.nI1(4,"translate"),e.k0s(),e.j41(5,"select",15),e.mxI("ngModelChange",function(s){e.eBV(t);const i=e.XpG(2);return e.DH7(i.pageSize,s)||(i.pageSize=s),e.Njj(s)}),e.bIt("change",function(){e.eBV(t);const s=e.XpG(2);return e.Njj(s.setPageLength(+s.pageSize))}),e.j41(6,"option",16),e.EFF(7),e.nI1(8,"translate"),e.k0s(),e.j41(9,"option",17),e.EFF(10),e.nI1(11,"translate"),e.k0s(),e.j41(12,"option",18),e.EFF(13),e.nI1(14,"translate"),e.k0s()()(),e.bVm()}if(2&n){const t=e.XpG(2);e.R7$(3),e.Lme("",t.pageSize," ",e.bMT(4,6,"Nav.PerPage"),""),e.R7$(2),e.R50("ngModel",t.pageSize),e.R7$(2),e.SpI("25 ",e.bMT(8,8,"Nav.PerPage"),""),e.R7$(3),e.SpI("50 ",e.bMT(11,10,"Nav.PerPage"),""),e.R7$(3),e.SpI("100 ",e.bMT(14,12,"Nav.PerPage"),"")}}function K(n,c){if(1&n&&(e.j41(0,"app-action-bar"),e.DNE(1,A,15,14,"ng-container",11),e.k0s()),2&n){const t=e.XpG();e.R7$(),e.Y8G("ngIf",(null==t.pagedResult?null:t.pagedResult.results.length)>0)}}function Q(n,c){1&n&&e.nrm(0,"app-simple-loader")}function k(n,c){1&n&&(e.j41(0,"div",19)(1,"div"),e.EFF(2),e.nI1(3,"translate"),e.k0s()()),2&n&&(e.R7$(2),e.JRh(e.bMT(3,1,"Users.NoUsersFound")))}function _(n,c){if(1&n){const t=e.RV6();e.j41(0,"tr")(1,"td",25),e.bIt("click",function(){const s=e.eBV(t).$implicit,i=e.XpG(2);return e.Njj(i.goToUser(s))}),e.j41(2,"b",26),e.EFF(3),e.k0s()(),e.j41(4,"td",27),e.bIt("click",function(){const s=e.eBV(t).$implicit,i=e.XpG(2);return e.Njj(i.goToUser(s))}),e.EFF(5),e.k0s(),e.j41(6,"td",27),e.bIt("click",function(){const s=e.eBV(t).$implicit,i=e.XpG(2);return e.Njj(i.goToUser(s))}),e.EFF(7),e.k0s()()}if(2&n){const t=c.$implicit;e.R7$(3),e.JRh(t.username),e.R7$(2),e.SpI(" ",t.firstName," "),e.R7$(2),e.SpI(" ",t.lastName," ")}}function q(n,c){if(1&n&&(e.j41(0,"table",20)(1,"thead")(2,"tr")(3,"th",21),e.EFF(4),e.nI1(5,"translate"),e.k0s(),e.j41(6,"th",22),e.EFF(7),e.nI1(8,"translate"),e.k0s(),e.j41(9,"th",22),e.EFF(10),e.nI1(11,"translate"),e.k0s()()(),e.j41(12,"tbody",23),e.DNE(13,_,8,3,"tr",24),e.k0s()()),2&n){const t=e.XpG();e.R7$(4),e.JRh(e.bMT(5,4,"Users.Username")),e.R7$(3),e.JRh(e.bMT(8,6,"Users.FirstName")),e.R7$(3),e.JRh(e.bMT(11,8,"Users.LastName")),e.R7$(3),e.Y8G("ngForOf",t.users)}}function ee(n,c){if(1&n){const t=e.RV6();e.j41(0,"app-pager",28),e.bIt("onGoToPage",function(s){e.eBV(t);const i=e.XpG();return e.Njj(i.goToPage(s))}),e.k0s()}if(2&n){const t=e.XpG();e.Y8G("totalResults",null==t.pagedResult?null:t.pagedResult.totalCount)("currentPage",t.page)("lastPage",null==t.pagedResult?null:t.pagedResult.pageCount)}}const te=[{path:"",redirectTo:"details",pathMatch:"full"},{path:"details",component:N},{path:"users",component:(()=>{class n extends Y.if{constructor(t,o,s,i,r,ae,ne){super(r,o,!0),this.rolesService=t,this.localize=s,this.router=i,this.errorService=ae,this.userService=ne,this.pageStream=new T.B,this.pageSizeStream=new T.B,this.userToRemove=null,this.removeSummaryTranslation="",this.removeSummary="",this.page=1,this.pageSize=25}ngOnInit(){this.isLoading=!0,this.rolesService.getCachedRole().pipe((0,X.$)()).subscribe(t=>{this.role=t,this.removeSummaryTranslation=this.removeSummaryTranslation.replace("{1}",this.role.name);const o=this.pageStream.pipe((0,S.T)(r=>(this.page=r,{searchTerm:this.searchTerm,page:r,pageSize:this.pageSize}))),s=this.pageSizeStream.pipe((0,S.T)(r=>(this.pageSize=r,{searchTerm:this.searchTerm,page:this.page,pageSize:r})));o.pipe((0,h.h)(s),(0,h.h)(this.searchSource),(0,h.h)(this.enterKeySource),(0,E.Z)({searchTerm:this.searchTerm,page:this.page,pageSize:this.pageSize}),(0,L.Z)(r=>(this.isLoading=!0,this.rolesService.getUsersInRole(t.id,r.page,r.pageSize,r.searchTerm).pipe((0,D.c)(200))))).subscribe(r=>{this.pagedResult=r,this.users=r.results,this.isLoading=!1},r=>{this.errorService.handleError(r),this.isLoading=!1})})}mapSearchTerm(t){return this.searchTerm=t,{searchTerm:this.searchTerm,page:1,pageSize:this.pageSize}}onSubmit(t){this.pageStream.next(1)}goToPage(t){this.pageStream.next(t)}setPageLength(t){this.page=1,this.pageSizeStream.next(t)}goToUser(t){const o=[this.localize.translateRoute("/users/view/"),t.subject,"roles"];this.router.navigate(o)}removeUser(t){this.removeSummary=this.removeSummaryTranslation.replace("{0}",t.username),this.userToRemove=t}delete(){this.isLoading=!0,this.userService.deleteUserRoles(this.userToRemove.subject,[this.role.name]).subscribe(t=>{let o=this.users&&1===this.users.length&&this.page>1?this.page-1:this.page;o<1&&(o=1),this.goToPage(o),this.toastr.success(this.translate.instant("Roles.Success"),this.translate.instant("Notifications.Success")),this.userToRemove=null},t=>{this.isLoading=!1,"401"===t.status&&this.toastr.warning(this.translate.instant("Roles.UnassignUnauthorized"),this.translate.instant("Notifications.Unauthorized")),this.userToRemove=null})}static{this.\u0275fac=function(o){return new(o||n)(e.rXU(v.P),e.rXU(p.c$),e.rXU(d.QG),e.rXU(u.Ix),e.rXU(O.tw),e.rXU(B.I),e.rXU(J.D))}}static{this.\u0275cmp=e.VBU({type:n,selectors:[["app-role-users"]],features:[e.Vt3],decls:14,vars:9,consts:[[1,"tw-container","tw-mx-auto"],["id","searchContainer",1,"tw-mb-2"],[1,"tw-flex","tw-bg-white","tw-border","tw-border-grey-300","tw-opacity-75","tw-cursor-text","tw-rounded","focus-within:tw-opacity-100","focus-within:tw-border-blue-400","tw-transition-all","tw-ease-in-out"],["for","searchTerm",1,"tw-flex","tw-items-center","tw-text-grey-500","tw-m-0","tw-ml-3"],["aria-hidden","true",1,"far","fa-search","tw-text-sm"],[1,"sr-only"],["id","searchRole","type","search","minlength","2","maxlength","25","required","","autocomplete","off",1,"tw-bg-transparent","tw-border-0","tw-text-base","tw-leading-tight","tw-px-2","tw-py-2","tw-w-full","focus:tw-outline-none","tw-transition-all","tw-ease-in-out",3,"ngModelChange","keyup","ngModel"],[4,"ngIf"],["class","tw-alert","role","alert",4,"ngIf"],["id","roleUsersTable","class","datatable selectable hover",4,"ngIf"],[3,"totalResults","currentPage","lastPage","onGoToPage",4,"ngIf"],["left","",4,"ngIf"],["left",""],[1,"tw-form-select","tw-w-auto"],["for","pageSizeToggle",1,"sr-only"],["id","pageSizeToggle",1,"tw-form-control","tw-form-control-small",3,"ngModelChange","change","ngModel"],["value","25"],["value","50"],["value","100"],["role","alert",1,"tw-alert"],["id","roleUsersTable",1,"datatable","selectable","hover"],[1,"sm:tw-w-1/3","md:tw-w-1/2"],[1,"tw-hidden","sm:tw-table-cell"],["id","usersInRoleTable"],[4,"ngFor","ngForOf"],[1,"tw-max-w-0","tw-truncate",3,"click"],[1,"tw-text-blue-500"],[1,"tw-hidden","tw-max-w-0","tw-truncate","sm:tw-table-cell",3,"click"],[3,"onGoToPage","totalResults","currentPage","lastPage"]],template:function(o,s){1&o&&(e.j41(0,"div",0)(1,"div",1)(2,"div",2)(3,"label",3),e.nrm(4,"span",4),e.j41(5,"span",5),e.EFF(6),e.nI1(7,"translate"),e.k0s()(),e.j41(8,"input",6),e.mxI("ngModelChange",function(r){return e.DH7(s.searchTerm,r)||(s.searchTerm=r),r}),e.bIt("keyup",function(r){return s.search(r)}),e.k0s()()(),e.DNE(9,K,2,1,"app-action-bar",7)(10,Q,1,0,"app-simple-loader",7)(11,k,4,3,"div",8)(12,q,14,10,"table",9)(13,ee,1,3,"app-pager",10),e.k0s()),2&o&&(e.R7$(6),e.JRh(e.bMT(7,7,"Common.Search")),e.R7$(2),e.R50("ngModel",s.searchTerm),e.R7$(),e.Y8G("ngIf",!s.isLoading),e.R7$(),e.Y8G("ngIf",s.isLoading),e.R7$(),e.Y8G("ngIf",s.users&&0==s.users.length&&!s.isLoading),e.R7$(),e.Y8G("ngIf",s.users&&s.users.length>0&&!s.isLoading),e.R7$(),e.Y8G("ngIf",(null==s.pagedResult?null:s.pagedResult.results.length)>0&&!s.isLoading))},dependencies:[m.Sq,m.bT,H.B,W.d,Z.n,l.xH,l.y7,l.me,l.wz,l.BC,l.YS,l.xh,l.tU,l.vS,p.D9],styles:["[_nghost-%COMP%]{width:100%;display:block;position:relative}"]})}}return n})()}];let se=(()=>{class n{static{this.\u0275fac=function(o){return new(o||n)}}static{this.\u0275mod=e.$C({type:n})}static{this.\u0275inj=e.G2t({providers:[y.v],imports:[m.MD,u.iI.forChild(te),p.h.forChild({extend:!0}),w.Y,V.m,R.i,d.XE,I.w,b.A,C.W,F.c,R.i,U.c,l.YN,j.N]})}}return n})()}}]);