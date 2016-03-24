(function ($) {
    var index = {
        init: function () {
            this.initClick();
        },
        initClick: function () {
            $("button[data-tag='statistics']").bind("click", function () { index.getStatistics(); });
            $("button[data-tag='excel']").bind("click", function () { index.downExcel(); });
            $('#divDistrict .dropdown-menu').children().bind("click", function () { index.chooseDistrict(this); index.createShopList(this); });
            $('#divShop .dropdown-menu').children().bind("click", function () { index.chooseShop(this);});
            $('#divMonth .dropdown-menu').children().bind("click", function () { index.chooseMonth(this); });
            $("button[data-tag='statistics']").click();
        },
        getStatistics: function () {
            var districtId = $('#hidDistrict').val();
            var shopId = $('#hidShop').val();
            var month = $('#hidMonth').val();
            $("div[data-tag='container']").html("加载中...");
            $("button[data-tag='excel']").addClass("disabled");
            $.ajax({
                type: "POST",
                data: "districtId=" + districtId+ "&shopId=" + shopId + "&month=" + month,
                url: "/Home/Statistics",
                success: function (res) {
                    if (res != null && res != "") {
                        $("div[data-tag='container']").html(res);
                        $("button[data-tag='excel']").removeClass("disabled");
                    }
                },
                error: function (res) {
                    $.Laperla.showTip(res);
                    $("div[data-tag='container']").html("加载失败，请重试!")
                }
            });
        },
        chooseDistrict: function (obj) {
            var districtName = $(obj).find('a').html();
            var districtId = $(obj).find('a').attr("data-data");
            $('#divDistrict .dropdown-toggle span').html(districtName);
            $('#hidDistrict').val(districtId);
        },
        chooseShop: function (obj) {
            var shopName = $(obj).find('a').html();
            var shopId = $(obj).find('a').attr("data-data");
            $('#divShop .dropdown-toggle span').html(shopName);
            $('#hidShop').val(shopId);
        },
        chooseMonth: function (obj) {
            var month = $(obj).find('a').html();
            $('#divMonth .dropdown-toggle span').html(month);
            $('#hidMonth').val(month);
        },
        createShopList: function (obj)
        {
            var districtId = $(obj).find('a').attr("data-data");
            $("#divShop").hide();
            $.ajax({
                type: "POST",
                data: "districtId=" + districtId,
                url: "/Ajax/ChooseShop",
                success: function (res) {
                    if (res && res.result == 1 && res.data.length > 0) {
                        var html="";
                        if (res.data.length > 1) {
                            for (var i = 0; i < res.data.length; i++) {
                                html += "<li><a data-data=" + res.data[i].key + ">" + res.data[i].value + "</a></li>"
                            }
                            $('#divShop .dropdown-toggle i').show();
                        }
                        else {
                            $('#divShop .dropdown-toggle i').hide();
                        }
                        $('#divShop .dropdown-toggle span').html(res.data[0].value);
                        $('#hidShop').val(res.data[0].key);
                        $('#divShop .dropdown-menu').html(html);
                        $('#divShop .dropdown-menu').children().bind("click", function () { index.chooseShop(this); });
                        $("#divShop").show();
                    }
                },
                error: function (res) {
                    $.Laperla.showTip(res);
                }
            });
        },
        downExcel: function ()
        {
            var shopName = $('#divShop .dropdown-toggle span').html();
            var html = $("div[data-tag='container']").html();
            $.Laperla.post('home/DownExcel', { strHtml: html, name: shopName });
        },
    }

    index.init();
})(jQuery);




