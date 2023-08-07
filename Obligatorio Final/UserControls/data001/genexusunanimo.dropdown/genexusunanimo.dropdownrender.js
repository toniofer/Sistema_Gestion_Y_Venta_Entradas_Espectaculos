function GeneXusUnanimo_Dropdown($) {
	  
	  
	  
	  
	  
	  
	  
	  
	  
	 this.setDropdownItems = function(value) {
			this.DropdownItems = value;
		}

		this.getDropdownItems = function() {
			return this.DropdownItems;
		} 
	  
	  
	  

	var template = '<div class=\"dropdown\" id=\"dropdown{{Id}}\">	<div class=\"dd-flex-container\">		<div class=\"dd-text-container\" id=\"textContainer{{Id}}\">			<div class=\"row\"> <span class=\"dd-username\">{{UserFullName}}</span> </div>			<div class=\"row\"> <span class=\"dd-companyname\">{{UserCompany}}</span> </div>		</div>		<div class=\"dd-avatar-container\" id=\"imgContainer{{Id}}\">			<img {{#UserPhoto}}src={{UserPhoto}}{{/UserPhoto}} class=\"dd-avatar\" alt=\"avatar-image\">		</div>		{{#ShowVerticalSeparator}}		<div class=\"dd-vertical-separator\" id=\"ddSeparator{{Id}}\"></div>		{{/ShowVerticalSeparator}}	</div> 	<div class=\"dropdown-content\" id=\"dropdown-content{{Id}}\">		{{#DropdownItems}}		<a id=\"{{id}}\" class=\"dd-option-container\" href=\"#\">			<img alt=\"{{alternativeText}}\" class=\"dd-option-icon\" src={{icon}}>			<span class=\"dd-option\">{{title}}</span>		</a>		{{/DropdownItems}}		{{#ShowLogoutOption}}		<!-- default logout event -->		<a class=\"dd-option-container\"  data-event=\"Logout\" >			<img alt=\"logout_icon\" class=\"dd-option-icon\" src={{LogoutIcon}}>			<span class=\"dd-option\">Logout</span>		</a>		{{/ShowLogoutOption}}	</div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnLogout = 0; 
	var _iOnItemClick = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnLogout = 0; 
			_iOnItemClick = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Logout']")
				.on('click', this.onLogoutHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='ItemClick']")
				.on('itemclick', this.onItemClickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Init(); 
	}

	this.Scripts = [];

		this.Init = function() {

			  	const UC = this;
				const imgContainerId = "imgContainer" + UC.Id;
				const imgContainer = document.getElementById(imgContainerId);
				const textContainerId = "textContainer" + UC.Id;
				const textContainer = document.getElementById(textContainerId);
				const separatorId = "ddSeparator" + UC.Id;
				const verticalSeparator = document.getElementById(separatorId);
				
				const elBox = document.getElementById("dropdown" + UC.Id);
				const elContent = document.getElementById("dropdown-content" + UC.Id);
				
				switch(UC.DisplayType) {
					case "Avatar":
					textContainer.hidden = true;
					break;
					case "Text": 
					imgContainer.hidden = true;
					break;
					case "Avatar and Text":
					break;
					case "Text into options box":
					elContent.prepend(textContainer);
					break;
				}
				switch(UC.ExpandBehavior) {
					case "Click":
					elBox.addEventListener("click", function(e){
						if (!elContent.classList.contains('dropdown-content--visible')){
							elContent.classList.add('dropdown-content--visible');  
						}else {
							elContent.classList.remove('dropdown-content--visible');  
						}		
					})
					break;
					case "Hover":
					elBox.addEventListener("mouseover", function(e){
						elContent.classList.add('dropdown-content--visible');
					})
					elBox.addEventListener("mouseout", function(e){
						elContent.classList.remove('dropdown-content--visible');
					})
					break;
				}
				//close dropdown when click outside the control
				document.addEventListener("click", function(e) {
					var target = event.target
					if(!target.closest('.dropdown') && elContent.classList.contains('dropdown-content--visible')) {
						elContent.classList.remove('dropdown-content--visible');
					}        
				});
				/*get the item's target*/
				elContent.addEventListener("click", function(e){
					var anchor = getParentAnchor(e.target);
					if(anchor !== null) {
						for (let i = 0; i < UC.DropdownItems.length; i++) {
							const item = UC.DropdownItems[i];
							if (item.id === anchor.id){
								UC.SelectedItemId = item.id;
								UC.SelectedItemTarget = item.link;
								UC.ItemClick();
								break;
							}
						}
					}
				});
				var getParentAnchor = function (element) {
					while (element !== null) {
						if (element.tagName && element.tagName.toUpperCase() === "A") {
						return element;
						}
						element = element.parentNode;
					}
					return null;
				};
			  
		}


		this.onLogoutHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 this.DropdownItemsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.Logout) {
				this.Logout();
			}
		} 

		this.onItemClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 this.DropdownItemsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.ItemClick) {
				this.ItemClick();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}