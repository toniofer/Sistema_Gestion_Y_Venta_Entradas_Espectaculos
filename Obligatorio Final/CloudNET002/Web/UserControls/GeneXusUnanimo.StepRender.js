function GeneXusUnanimo_Step(n){var t,r,u,f,i;this.setStepItems=function(n){this.StepItems=n};this.getStepItems=function(){return this.StepItems};t='<ch-step-list id="ch-step{{id}}">\t{{#StepItems}}\t<ch-step-list-item class="{{Class}}" >\t\t{{text}}\t<\/ch-step-list-item>\t{{/StepItems}}<\/ch-step-list>';r={};Mustache.parse(t);u=0;this.show=function(){f=n(this.getContainerControl());u=0;this.setHtml(Mustache.render(t,this,r));this.renderChildContainers();n(this.getContainerControl()).find("[data-event='ItemClick']").on("itemclick",this.onItemClickHandler.closure(this)).each(function(n){this.setAttribute("data-items-index",n+1)});this.initItemClick()};this.Scripts=[];this.initItemClick=function(){const n=this,t="ch-step"+n.id,i=document.getElementById(t);i.addEventListener("itemClicked",function(t){for(let i=0;i<n.StepItems.length;i++){const r=n.StepItems[i];if(r.text===t.detail["item-clicked"]){n.SelectedItem=r.text;n.ItemClick&&n.ItemClick();break}}})};this.onItemClickHandler=function(t){if(t){var i=t.currentTarget;t.preventDefault();this.StepItemsCurrentIndex=parseInt(n(i).attr("data-items-index"),10)||1}this.ItemClick&&this.ItemClick()};this.autoToggleVisibility=!0;i={};this.renderChildContainers=function(){f.find("[data-slot][data-parent='"+this.ContainerName+"']").each(function(t,r){var e=n(r),f=e.attr("data-slot"),u;u=i[f];u||(u=this.getChildContainer(f),i[f]=u,u.parentNode.removeChild(u));e.append(u);n(u).show()}.closure(this))}}