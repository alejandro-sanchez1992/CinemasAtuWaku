$(document).ready(function(){
	$("ul.nav.menu > li").on("click", function(){
		$(".submenu").stop().slideToggle();
	});
});