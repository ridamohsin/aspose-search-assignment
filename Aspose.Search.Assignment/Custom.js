
function validateBoolean(oSrc, args) {
    args.IsValid = true;
    var searchType = $('.searchtype-list').find(":selected").text();
    if (searchType == "Boolean") {
        var searchText = $.trim($('.search-term').val());
        if ((searchText[0] == "(") && (searchText[searchText.length - 1] == ")")) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
}

if ($('.second-term').css('visibility') == 'hidden') {
    alert('hidden');
    $('.required-second-term').hide();
}

