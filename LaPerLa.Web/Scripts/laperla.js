(function ($) {

    $.Laperla = function (params) {
    }

    $.Laperla.showTip = function (content, title, width, height, padding) {
        $.Dialog({
            shadow: true,
            overlay: false,
            icon: '<span class="icon-rocket"></span>',
            title: title ? title : '提示',
            width: width ? width : 200,
            //height: height ? height : 100,
            padding: padding ? padding : 10,
            content: content
        });
    }

    $.Laperla.post = function (URL, PARAMS) {
        var temp = document.createElement("form");
        temp.action = URL;
        temp.method = "post";
        temp.style.display = "none";
        for (var x in PARAMS) {
            var opt = document.createElement("textarea");
            opt.name = x;
            opt.value = PARAMS[x];
            // alert(opt.name)      
            temp.appendChild(opt);
        }
        document.body.appendChild(temp);
        temp.submit();
        return temp;
    }

})(jQuery);







