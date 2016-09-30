
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

function validateBoolean2(oSrc, args) {
    args.IsValid = true;
    alert('enter');
    var searchType = $('.searchtype-list').find(":selected").text();
    if (searchType == "Boolean") {
        var searchText = $.trim($('.second-term').val());
        if ((searchText[0] == "(") && (searchText[searchText.length - 1] == ")")) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
}


