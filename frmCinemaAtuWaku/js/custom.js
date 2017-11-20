$(document).ready(function(){
	$('ul.nav.menu > li:has(ul)').addClass('desplegable');
	$('ul.nav.menu > li > a').click(function() {
		var comprobar = $(this).next();
		$('ul.menu li').removeClass('activa');
		$(this).closest('li').addClass('activa');
		if((comprobar.is('ul')) && (comprobar.is(':visible'))) {
			$(this).closest('li').removeClass('activa');
			comprobar.slideUp('normal');
		}
		if((comprobar.is('ul')) && (!comprobar.is(':visible'))) {
			$('ul.menu li ul:visible').slideUp('normal');
			comprobar.slideDown('normal');
		}
	});
});