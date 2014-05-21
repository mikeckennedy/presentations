var site = site || {};

$(document).ready(function() {
    site.manage_jumbo();
});

site.manage_jumbo = function () {
    $(".jumbotron").slideDown(200).slideUp(600);
    // $.post()    
}