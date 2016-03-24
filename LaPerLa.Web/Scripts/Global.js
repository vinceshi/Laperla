
/**
* Declare Variable With C# Boolean 
*/
var True = true, False = false;

var Page = [];

var ServerProcessing = false

var TrueFalseArray = [{ 'txt': '否', 'val': 'false' }, { 'txt': '是', 'val': 'true' }];


var LocalBaseUrl = 'http://' + window.location.host;


//提示信息
var IconArray = [];
IconArray["0"] = "/content/images/pms_layout_error.gif"; //出错icon
IconArray["1"] = "/content/images/pms_layout_ok.gif"; //成功icon
IconArray["2"] = "/content/images/pms_layout_notice.gif"; //提示&警告icon

/**
*上传枚举类型,相册:0，楼书/特色/模板:1,资源文件:2,水印图3,专题4
**/
var UpLoadType = {
    Album: 0,
    File: 1,
    Resource: 2,
    WaterMarkPhoto: 3,
    Topic: 4,
    TopicImages: 5
};

/**
* Upload File
* @param {String} fileID
* @param {String} btnImg
* @param {Int} btnW
* @param {Int} btnH
* @param {String} folder
* @param {URL} script
* @param {String} scriptData
* @param {Function} onComplete
*/
function Upload(fileID, btnImg, btnW, btnH, folder, scriptData, onComplete) {
    var _uploadify = $('#' + fileID).uploadify({
        'uploader': '/scripts/uploadify.swf',
        'script': UpLoadURL,
        'scriptData': { 'UpLoadFileType': scriptData },
        'folder': folder,
        'buttonImg': btnImg,
        'rollover': true,
        'cancelImg': '/content/images/upload_cancel.png',
        'width': btnW,
        'height': btnH,
        'scriptAccess': 'always',
        'auto': true,
        'multi': false,
        'fileExt': '*.jpg;*.gif;*.png;*.jpeg',
        'fileDesc': 'Web Files (*.jpg;*.gif;*.png;*.jpeg)',
        'onOpen': function (event, queueId, fileObj) {
        },
        'onSelect': function () {
        },
        'onError': function () {
            if (arguments[3] != null) {
                window.alert('上传错误请重试，代码：' + arguments[3].info);
            }
        },
        'onComplete': onComplete
    });
}



/**
* Init Radios from array data
* @param {Object} sourceArray
* @param {Object} divElemID
* @param {Object} fillDataElemID
*/
function InitRadiosFromArray(sourceArray, divElemID, fillDataElemID) {
    var str = "";
    if (sourceArray != null) {
        for (i in sourceArray) {
            str += '<input name="' + fillDataElemID + '" type="radio" class="radiobtnfix" id="rdo' + fillDataElemID + i + '" value="' + i + '" />';
            str += '<label for="rdo' + fillDataElemID + i + '">' + sourceArray[i] + '</label> ';
        }
    }

    $('#' + divElemID).append(str);
}

function InitRadiosFromJson(sourceJson, divElemID, fillDataElemID) {
    var str = "";
    if (sourceJson != null) {
        for (i in sourceJson) {
            str += '<input name="' + fillDataElemID + '" type="radio" class="radiobtnfix" id="rdo' + fillDataElemID + i + '" value="' + sourceJson[i].val + '" />';
            str += '<label for="rdo' + fillDataElemID + i + '">' + sourceJson[i].txt + '</label> ';
        }
    }

    $('#' + divElemID).append(str);
}

function InitRadiosFromJson1(sourceJson, divElemID, fillDataElemID) {
    var str = "";
    if (sourceJson != null) {
        for (i in sourceJson) {
            str += '<input name="' + fillDataElemID + '" type="radio" class="radiobtnfix" id="rdo' + fillDataElemID + i + '" value="' + sourceJson[i].txt + '" />';
            str += '<label for="rdo' + fillDataElemID + i + '">' + sourceJson[i].txt + '</label> ';
        }
    }

    $('#' + divElemID).append(str);
}

/**
* Init Checkbox from array data
* @param {Object} sourceArray
* @param {Object} divElemID
* @param {Object} fillDataElemID
*/
function InitCheckboxsFromArray(sourceArray, divElemID, fillDataElemID) {
    var str = "";
    if (sourceArray != null) {
        for (i in sourceArray) {
            //str += '<input type="checkbox" id="ckb' + fillDataElemID + i + '" class="radiobtnfix" name="' + fillDataElemID + '" value="' + sourceArray[i].val + '"/>';
            //str += '<label for="ckb' + fillDataElemID + i + '">' + sourceArray[i].txt + '</label>&nbsp;&nbsp;';
            str += '<label class="checkbox inline"><input type="checkbox" id=ckb' + fillDataElemID + i + ' name=' + fillDataElemID + ' value=' + sourceArray[i].val + ' />' + sourceArray[i].txt + '</label>';
        }
    }
    $('#' + divElemID).append(str);
}

/**
* Init Checkbox from array data
* @param {Object} sourceArray
* @param {Object} divElemID
* @param {Object} fillDataElemID
*/
//function InitCheckboxsFromJson(sourceJson, divElemID, fillDataElemID, useKey) {
//    var str = "";
//    useKey = useKey || false;
//    if (sourceArray != null) {
//        for (i in sourceJson) {
//            str += '<input type="checkbox" id="ckb' + fillDataElemID + i + '" class="radiobtnfix" name="' + fillDataElemID + '" value="'
//                        + (useKey ? i : sourceJson[i].txt) + '"/>';
//            str += '<label for="ckb' + fillDataElemID + i + '">' + sourceArray[i].txt + '</label>&nbsp;&nbsp;';
//        }
//    }

//    $('#' + divElemID).append(str);
//}

function InitCheckboxsFromJson(sourceJson, divElemID, fillDataElemID, isPrepend) {
    var str = "";
    if (sourceJson != null) {
        for (i in sourceJson) {
            str += '<input type="checkbox" id="ckb' + fillDataElemID + i + '" class="radiobtnfix" name="' + fillDataElemID + '" value="' + sourceJson[i].txt + '" />';
            str += '<label for="ckb' + fillDataElemID + i + '">' + sourceJson[i].txt + '</label>&nbsp;&nbsp;';
        }
    }
    if (arguments.length > 3 && arguments[3] != null)
        $('#' + divElemID).prepend(str);
    else
        $('#' + divElemID).append(str);
}

function InitCheckboxsFromJsonNoLableFor(sourceJson, divElemID, fillDataElemID, isPrepend) {
    var str = "";
    if (sourceJson != null) {
        for (i in sourceJson) {
            str += '<input type="checkbox" id="ckb' + fillDataElemID + i + '" class="radiobtnfix" name="' + fillDataElemID + '" value="' + sourceJson[i].txt + '" />';
            str += sourceJson[i].txt + '&nbsp;&nbsp;';
        }
    }
    if (arguments.length > 3 && arguments[3] != null)
        $('#' + divElemID).prepend(str);
    else
        $('#' + divElemID).append(str);
}

//显示提示
function ShowTips(obj) {
    $(obj).css('cursor', 'pointer');
    if ($(obj).siblings().is(':visible')) {
        $(obj).attr('title', '收起 ' + $(obj).children().html());
    }
    else {
        $(obj).attr('title', '展开 ' + $(obj).children().html());
    }
}


/**
* Init AutoComplete Control
* @param {String} elemID
* @param {String} url
* @param {Function} onSelect
* @param {JSONObject} params
*/
function InitAutoComplete(elemID, url, onSelect, params) {
    if ($('#' + elemID)[0] != null) {
        $('#' + elemID).autocomplete({
            deferRequestBy: 500,
            params: params,
            delimiter: true,
            serviceUrl: url,
            noCache: true,
            onSelect: onSelect
        });
    }
};


/**
* Init Selector Control
* @param {String} elemID
* @param {JSONObject} JSONArray
* @param {Function} onSelected
* @param {String} defValue
* @param {Bool} isMulti
* @return {Object}
*/
function InitSelector(elemID, JSONArray, onSelected, defValue, columnNum, isMulti, colWidth, tbxWidth, defTxt) {
    var showMode = isMulti ? 'multi' : 'single';
    if ($('#' + elemID)[0] != null) {
        columnNum = (columnNum == null && JSONArray.length < 6) ? 1 : columnNum;
        return new Selector({
            containerId: '#' + elemID,
            items: JSONArray,
            defVal: defValue || '',
            tipTxt: defTxt || '',
            showMode: showMode,
            colNum: columnNum,
            colWidth: colWidth || 90,
            tbxWidth: tbxWidth || 90,
            onSelected: onSelected
        });
    }
    else {
        return null;
    }
}

function InitSelectorByElem(elem, JSONArray, onSelected, defValue, columnNum, isMulti, colWidth, tbxWidth) {
    var showMode = isMulti ? 'multi' : 'single';
    if ($(elem)[0] != null) {
        columnNum = (columnNum == null && JSONArray.length < 6) ? 1 : columnNum;
        return new Selector({
            containerId: elem,
            items: JSONArray,
            defVal: defValue || '',
            showMode: showMode,
            colNum: columnNum,
            colWidth: colWidth || 90,
            tbxWidth: tbxWidth || 90,
            onSelected: onSelected
        });
    }
    else {
        return null;
    }
}

/**
* Get Selector Control JSONArray DataSource
* @param {Array} array
* @param {String} defTxt
* @param {String} defVal
* @return {JSONArray}
*/
function GetSelectorJSONArray(array, defTxt, defVal) {
    if (defTxt == null) {
        defTxt = "请选择";
    }
    if (defVal == null) {
        defVal = "";
    }
    var JSONArray = [];

    if (array != null) {
        for (i in array) {
            JSONArray.push({ txt: array[i], val: i });
        }
    }
    var exist = false;
    $.each(JSONArray, function (i) {
        if (this.txt == defTxt && this.val == defVal) {
            exist = true;
        }
    });
    if (!exist) {
        JSONArray.unshift({ txt: defTxt, val: defVal });
    }
    return JSONArray;
}


/**
* Register jQuery Validate Method
*/
function registerValidatorMethod() {
    if (jQuery.validator != null) {
        jQuery.validator.addMethod('UserName', function (value, element) {
            return this.optional(element) || /^[\u0391-\uFFE5\w]+$/.test(value);
        }, 'invalid username format');

        jQuery.validator.addMethod('AllNumbers', function (value, element) {
            return this.optional(element) || !(/^\d+$|^(-?\d+)(\.\d+)?$/.test(value));
        }, 'companyname can not be all numbers');

        jQuery.validator.addMethod('Hour', function (value, element) {
            return this.optional(element) || /^([0-1][0-9]|[2][0-3]):([0-5][0-9])$/.test(value);
        }, 'companyname can not be all numbers');

        jQuery.validator.addMethod('BizPhoneNumber', function (value, element) {
            value = value.replace(/，/ig, ',');
            return this.optional(element) || (/^\d{7,8}$|^(\d{7,8}\,\d{7,8})+$/.test(value));
        }, 'phone number error');

        jQuery.validator.addMethod('isMobile', function (value, element) {
            var length = value.length;
            return this.optional(element) || (length == 11 && /(^1[358][0-9]{9}$)/.test(value));
        }, 'invalid mobilephone number');

        jQuery.validator.addMethod('isWorkPhone', function (value, element) {
            var tel = /(^(\d{2,4}[-_－—]?)?\d{3,8}([-_－—]?\d{3,8})?([-#\*]?\d{1,7})?$)|(^0?1[35] \d{9}$)/;
            return this.optional(element) || (tel.test(value));
        }, 'invalid workphone number');

        jQuery.validator.addMethod('IntegerNumber', function (value, element) {
            return this.optional(element) || /(^[0-9]+$)/.test(value);
        }, 'invalid integer number');

        jQuery.validator.addMethod('PositiveInteger', function (value, element) {
            return this.optional(element) || /(^[1-9][0-9]*$)/.test(value);
        }, '请输入大于零的整数');

        jQuery.validator.addMethod('IntegerComma', function (value, element) {
            //value = value.replace(/，/ig, ',');
            return this.optional(element) || (/^\d+$|^(\d+\,\d*)+$/.test(value));
        }, 'RoomArea error');

        jQuery.validator.addMethod('HHMMTimeFormat', function (value, element) {
            return this.optional(element) || (/^([0-9]|0\d{1}|1\d{1}|2[0-3]):([0-5]\d{1})$/.test(value));
        }, 'hh:mm time format error');

        jQuery.validator.addMethod("isDecimalTwo", function (value, element) {
            var decimal = /^-?\d+(\.\d{1,2})?$/;
            return this.optional(element) || (decimal.test(value));
        }, '小数位数不能超过2位');

        jQuery.validator.addMethod("float", function (value, element) {
            var decimal = /^\d+((\.)?\d*)?$/;
            return this.optional(element) || (decimal.test(value));
        }, '小数位数不能超过2位');

        jQuery.validator.addMethod("isWebsite", function (value, element) {
            var decimal = /^http:\/\/([\w-]+\.)+[\w-]+(\/[\w- .\/?%&=]*)?/;
            //var decimal = /[a-zA-z]+:\/\/[^\s]*/;
            return this.optional(element) || (decimal.test(value));
        }, '请输入正确的网址');

        jQuery.validator.addMethod("isZipcode", function (value, element) {
            var decimal = /[1-9]\d{5}(?!\d)/;
            return this.optional(element) || (decimal.test(value));
        }, '邮编格式错误');

        jQuery.validator.addMethod("isEmail", function (value, element) {
            var decimal = /\w@\w*\.\w/;
            return this.optional(element) || (decimal.test(value));
        }, '电子邮箱格式错误');

        jQuery.validator.addMethod("isTel", function (value, element) {
            var decimal = /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/;
            return this.optional(element) || (decimal.test(value));
        }, 'invalid workphone number');

        jQuery.validator.addMethod("isQQ", function (value, element) {
            var decimal = /\d{5,12}/;
            return this.optional(element) || (decimal.test(value));
        }, 'QQ号码格式错误');

        jQuery.validator.addMethod("isWeibo", function (value, element) {
            var reg = /^(?!.*?@).*$/;
            return this.optional(element) || (reg.test(value));
        }, '微博账号不得包含@符号');
    }
}


/**
* Set Validator Defaults Method
*/
function SetValidatorDefaults() {
    if ($.validator != null) {
        $(":submit").attr("disabled", false);

        $.validator.setDefaults({
            submitHandler: function (form) {
                form.submit();
            }
        });

        $.extend($.validator.messages, {
            required: "请输入",
            IntegerNumber: "请输入大于等于零的整数",
            number: "请输入正确的数字"
        });
    }
}


//验证是否是整数
function checkIntegerNumber(value) {
    return /(^[0-9]+$)/.test(value);
}

/**
* Get Validator Remote Method
* @param {String} url
* @param {JSONObject} data
*/
function GetValidatorRemote(url, data) {
    var remote = {
        type: 'POST',
        async: false,
        url: url,
        dataType: 'json',
        data: data,
        dataFilter: function (res) {
            var resJSON = eval('(' + res + ')');
            return resJSON.res;
        }
    };
    return remote;
}


/**
* 显示调试信息（浏览器FireFox/IE，显示至控制台）
* @param {Object|String} info 
*/
var Log = function (info) {
    var isObject = (typeof info == "object");
    if (typeof console != "undefined" && typeof console.info != "undefined") {
        console.info("Global Debug: " + (isObject ? "%o" : "%s"), info);
    }
    else {
        window.alert((isObject ? "ERROR! " : "") + info);
    }
};


/**
* 获取URL参数值
* @param {String} key
* @return {String}
*/
var GetQueryString = function (key) {
    var str = decodeURI(window.location.search);
    var reg = new RegExp("(^|&)" + key + "=([^&]*)(&|$)", "i");
    var r = str.substr(1).match(reg);
    if (r != null) {
        return unescape(r[2]);
    } else {
        return null;
    }
};


/**
* 全角字符转为半角字符
* @param {String} str 
* @return {String}
*/
var FullToHalfChar = function (str) {
    var myArray = [];
    if (str.charCodeAt != null && String.fromCharCode != null) {
        for (var i = 0; i < str.length; i++) {
            var charCode = str.charCodeAt(i);
            if (charCode > 0xfee0 && charCode != 65292 && charCode != 65281 && charCode != 65311 && charCode != 65307 && charCode != 65306 && charCode != 65294) {
                myArray[i] = String.fromCharCode(charCode - 0xfee0);
            }
            else
                myArray[i] = String.fromCharCode(charCode);
        }
    }
    return myArray.join('');
}


/**
* 得到字符串长度（汉字长度为2）
* @param {String} str 
* @return {Int}
*/
var GetStringLen = function (str) {
    return str.replace(/[^\x00-\xff]/g, '**').length;
}


/**
* 设置cookies
* @param {String} key 
* @param {String} value 
*/
var SetCookie = function (key, value) {
    var argv = setCookie.arguments;
    var argc = setCookie.arguments.length;
    var expires = (argc > 2) ? argv[2] : null;
    if (expires != null) {
        var LargeExpDate = new Date();
        LargeExpDate.setTime(LargeExpDate.getTime() + (expires * 1000 * 3600 * 24));
    }
    document.cookie = key + "=" + encodeURIComponent(value) + ((expires == null) ? "" : ("; expires=" + LargeExpDate.toGMTString()));
};


/**
* 获取Cookie对应值
* @param {String} key
* @return {String}
*/
var GetCookie = function (key) {
    var arr = document.cookie.match(new RegExp("(^| )" + key + "=([^;]*)(;|$)"));
    if (arr != null) {
        return decodeURIComponent(arr[2]);
    } else {
        return null;
    }
};


/**
* 检查标签匹配闭合
* @param string tagname 表单元素name
* @return 1,0, 1表示闭合良好
*/
var CheckHTMLTag = function (content, noAlert) {
    var retag = content;

    function compare(txt1, txt2) {
        var txt = '<' + '/' + txt1.substr(1);
        return (txt == txt2) ? 1 : 0;
    }
    function checkComment(txt) {
        var _ret;
        txt = txt.replace(/\r|\n/ig, '');
        txt = txt.replace(/<style *[^<>]*>.*?<\/style>/ig, '');
        txt = txt.replace(/<script *[^<>]*>.*?<\/script>/ig, '');
        if (/<\!-+>/ig.test(txt) || /<\!--(-+(.*?)|(.*?)-+)-->/ig.test(txt)) {
            _ret = false;
        }
        else {
            if (txt.split("<!--").length != txt.split("-->").length)
                _ret = false;
            else {
                _ret = true;
            }
        }
        return _ret;
    }

    if (retag == '') {
        return 1; //空串直接返回1
    }

    // pass comment tag checker?
    if (checkComment(retag) == false) {
        if (!noAlert)
            alert("注释代码错误，请遵守<!-- comment -->格式！\n提示：<!--->, <!----->, <!--- comment -->等等都是不规范的注释。");
        return 0;
    }
    else {
        retag = retag.replace(/\r|\n/ig, ''); //除去回车和换行	
        // 去掉不能很好控制的<script>...<\/script>和<!--...-->
        retag = retag.replace(/<style *[^<>]*>.*?<\/style>/ig, '');
        retag = retag.replace(/<script *[^<>]*>.*?<\/script>/ig, '');
        retag = retag.replace(/<\!--.*?-->/ig, '');

        var arrIntElement = retag.match(/<\/?[A-Za-z][a-z0-9]*[^>]*>/ig);

        if (arrIntElement != null) {


            //预处理标签,得到规整的标签数组,去掉所有属性只留下<a>和</a>
            var arrPrElement = Array();
            for (var k = 0; k < arrIntElement.length; k++) {
                arrPrElement[k] = arrIntElement[k].replace(/(<\/?[A-Za-z0-9]+) *[^>]*>/ig, "$1>");
                arrPrElement[k] = arrPrElement[k].replace(/[\s]+/g, '').toLowerCase();
            }

            //不需要配对的标签,小写
            var arrMinus = new Array('<img>', '<input>', '<meta>', '<hr>', '<br>', '<link>', '<param>', '<frame>', '<base>', '<basefont>', '<isindex>', '<area>', '<col>', '<embed>');

            //去掉多余的单标签标记,返回新的arrIntElement
            for (var i = 0; i < arrPrElement.length; i++) {
                for (var k = 0; k < arrMinus.length; k++) {
                    if (arrPrElement[i] == arrMinus[k]) {
                        arrPrElement.splice(i, 1);
                        i--;
                    }
                }
            }

            //判断<aaa>与</aaa>是配对的html标签
            var stack = new Array();
            stack[0] = '#';
            var p = 0;
            var problem;
            for (var j = 0; j < arrPrElement.length; j++) {
                if (compare(stack[p], arrPrElement[j])) {
                    p--;
                    stack.length--;
                }
                else {
                    stack[++p] = arrPrElement[j];
                }
            }

            if (stack[p] != "#") {
                if (!noAlert)
                    alert("存在未闭合的html标签，请检查<a>,<div>,<p>,<li>,<ul>,<font>等标签是否闭合");
                return 0;
            }

            //双引号和单引号完整性检查
            for (var k = 0; k < arrIntElement.length; k++) {
                var rr = arrIntElement[k].match(/\"/ig);
                var r = arrIntElement[k].match(/\'/ig);
                if (rr != null) {
                    if (rr.length % 2 != 0) {
                        if (!noAlert)
                            alert("警告：" + arrIntElement[k] + " 双引号不完整");
                        return 0;
                    }
                }
                if (r != null) {
                    if (r.length % 2 != 0) {
                        if (!noAlert)
                            alert("警告：" + arrIntElement[k] + " 单引号不完整");
                        return 0;
                    }
                }
            }
        }
    }

    return 1;
};


/**
* 复制内容至剪切板
* @param {String} txt 
*/
var CopyToClipBoard = function (txt) {
    if (window.clipboardData) {
        window.clipboardData.clearData();
        window.clipboardData.setData("Text", txt);
    } else if (navigator.userAgent.indexOf("Opera") != -1) {
        window.location = txt;
    } else if (window.netscape) {
        try {
            netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        } catch (e) {
            alert("被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
        }
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip)
            return;
        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans)
            return;
        trans.addDataFlavor('text/unicode');
        var str = new Object();
        var len = new Object();
        var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
        var copytext = txt;
        str.data = copytext;
        trans.setTransferData("text/unicode", str, copytext.length * 2);
        var clipid = Components.interfaces.nsIClipboard;
        if (!clip)
            return false;
        clip.setData(trans, null, clipid.kGlobalClipboard);
    }
};


/**
* 处理IE6下默认不缓存背景图片
*/
(function () {
    var ua = window.navigator.userAgent.toLowerCase();
    var isOpera = ua.indexOf("opera") > -1;
    var isIE = !isOpera && ua.indexOf("msie") > -1;
    var isIE7 = !isOpera && ua.indexOf("msie 7") > -1;

    if (isIE && !isIE7) {
        try {
            document.execCommand("BackgroundImageCache", false, true);
        }
        catch (e) {
        }
    }
})();


/**
* Create New UUID
*/
function NewUUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    }).toUpperCase();
}


/**
* Serialize Form Elements To JSON
*/
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name] += (',' + ($.trim(this.value) || ''));     // CheckBox Value Split with ','
            //o[this.name].push($.trim(this.value) || '');
        } else {
            o[this.name] = $.trim(this.value) || '';
        }
    });
    return o;
};


//Loading
function initLoading() {
    var divLoading =
    '<div id="divLoading" class="loading resultTip">' +
            '<b class="ico-loading"></b>' +
            '<p class="fl">数据处理中，请耐心等待...</p>' +
    '</div>';
    $("body").append(divLoading);
}

/**
* Show Loading
*/
function Loading(show) {
    if (show == null) { show = true; }
    var $Loading = $('#divLoading');
    if ($Loading[0] != null) {
        if (show) $Loading.fadeIn();
        else $Loading.fadeOut();
    }
    ServerProcessing = show ? true : false;
}

//检查是否在请求数据
function checkProcessing() {
    return ServerProcessing;
}

//在页面跳转时进行数据保存的提示
function RedirectSaveConfirm(url) {
    if (confirm("请确保在跳转前数据已保存!")) {
        document.location.href = url;
    }
}
//选中一个单选按钮
function selOneRadio(divID, txtVal) {
    $("#" + divID + " input").each(function () {
        if ($(this).val() == txtVal) {
            $(this).attr('checked', true);
        }
    });
}


//选中一个单选按钮按照汉字
function selOneRadioValue(divID, txt) {
    $("#" + divID + " label").each(function () {
        if ($(this).html() == txt) {
            $(this).prev().attr('checked', true);
        }
    });
}

//选中多个复选框
function selCkboxs(divID, txtVal) {
    $("#" + divID + " input").each(function () {
        if (txtVal.indexOf($(this).val()) >= 0) {
            $(this).attr('checked', true);
        }
    });
}

//折叠 add zhangzhichun
function ToggleNextBlk(obj) {
    $(obj).siblings().toggle();
}

//suggest input blur function
function suggestInputBlur() {
    $('.inputbox_sv').each(function () {
        $(this).blur(function () {
            $(this).valid();
        });
    });
}

//日期格式方法扩增
Date.prototype.format = function (format) {
    var o =
    {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "h+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format))
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(format))
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}

//跳转到指定页面
function gotoUrl(url) {
    if (url != null && url != '') {
        window.location = url;
    }
}

//javascript HTMLEnCode 过滤网页标记
function HTMLEncode(input) {
    var converter = document.createElement("DIV");
    $(converter).html(input);
    var output = $(converter).text();
    converter = null;
    return output;
}

//javascript HTMLDeCode 过滤网页标记
function HTMLDecode(input) {
    var converter = document.createElement("DIV");
    converter.innerHTML = input;
    var output = "";
    if (navigator.appName.indexOf("Explorer") > -1) {
        output = converter.innerText;
    }
    else {
        output = converter.textContent;
    }
    converter = null;
    return output;
}

//四舍五入
function round(v, e) {
    var t = 1;
    for (; e > 0; t *= 10, e--);
    for (; e < 0; t /= 10, e++);
    return Math.round(v * t) / t;
}

/**
* Init Calendar Control
* @param {String} elemID
* @param {Function} onSelect
*/
function InitCalendar(elemID, onSelect, min, max) {
    if (Calendar != null) {
        return new Calendar({
            inputField: elemID,
            dateFormat: "%Y-%m-%d",
            trigger: elemID,
            bottomBar: true,
            min: min,
            max: max,
            onSelect: function () {
                if (typeof (onSelect) == "function") {
                    onSelect() | this.hide();
                } else {
                    this.hide();
                }
            }
        });
    }
    return null;
}


//获取当前要跳转的页码
function getCurrentPageIndex(pageIndex) {
    pageIndex = (pageIndex == null) ? 1 : pageIndex;
    // 取文本框值跳转页面
    if (pageIndex == 0) {
        if ($('#txtGoPage').val() == '' || isNaN($('#txtGoPage').val())) {
            $('#txtGoPage').val('1');
        }
        pageIndex = parseInt($('#txtGoPage').val());
    }
    return pageIndex;
}
//选中的导航栏目
function SelectNav(selectId, className) {
    selectId = selectId - 1 || 0;
    var topNav = $("#topNav li");
    for (var i = 0; i < topNav.length; i++) {
        if (selectId == i)
            topNav.eq(i).addClass(className);
        else
            topNav.eq(i).removeClass("class", className);
    }
}
//多个复选框的选中(data为以,号分割的项)
function initChecked(data, divID) {
    var shopTypeList = data.split(',');
    for (var i = 0; i < shopTypeList.length; i++) {
        selCkboxs(divID, shopTypeList[i]);
    }
}
//选中指定复选框
function selCkboxs(divID, txtVal) {
    $("#" + divID + " input").each(function () {
        if (txtVal.indexOf($(this).val()) >= 0) {
            $(this).attr('checked', true);
        }
    });
}

//选中一个单选按钮
function selOneRadio(divID, txtVal) {
    $("#" + divID + " input").each(function () {
        if ($(this).val() == txtVal) {
            $(this).attr('checked', true);
        }
    });
}

function HtmlRaw(oldStr) {
    oldStr = oldStr.replace("&lt;", "<");
    oldStr = oldStr.replace("&gt;", ">");
    oldStr = oldStr.replace("<br/>", "\r\n");
    oldStr = oldStr.replace("<br/>", "\r");
    oldStr = oldStr.replace("<br/>", "\n");
    oldStr = oldStr.replace("&nbsp;&nbsp;&nbsp;", "\t");
    oldStr = oldStr.replace("&quot;", "\"");
    return oldStr;
}
//对象是否为空 true:为空 false:不空
function objIsNull(obj) {
    for (var i in obj) {
        return false;
    }
    return true;
}
//设置按钮不可用
function disableButton(btnId) {
    $("#" + btnId + " span").html("处理中...");
    $("#" + btnId).addClass("btn_gray");
    $("#" + btnId).removeAttr("onclick");
}
//设置按钮可用
function enableButton(btnId, name, clickEvent) {
    $("#" + btnId + " span").html(name);
    $("#" + btnId).removeClass("btn_gray");
    $("#" + btnId).bind("click", clickEvent);
}

//弹窗
//controlId   要显示的控件的内容
//title       显示的标题
//width       显示的宽度
//cancel      是否有取消按钮
//
function showControlMsg(controlId, title, width, cancel, eleId) {
    title = title || '提示';
    width = width || 300;
    if (cancel == null || cancel === '') {
        cancel = true;
    }
    art.dialog({
        id: controlId,
        skin: "dialogbox",
        title: title,
        cancel: cancel,
        content: document.getElementById(controlId),
        opacity: 0.2,
        lock: true,
        width: width,
        padding: 10,
        drag: true,
        resize: false,
        eleId: eleId
    });
}
//弹窗提示
//title     标题
//content   内容
//width     宽度
//ok_callback       '确定'回调函数
//cancle_callback   '取消'回调函数，供showConfirm调用
//cancle_show       是否显示'取消'按钮，供showConfirm调用
function showMsg(content, title, width, ok_callback, cancle_callback, cancle_show, eleId) {
    content = content || '';
    title = title || '提示';
    width = width || 300;
    ok_callback = ok_callback || closeDialog;
    cancle_callback = cancle_callback || closeDialog;
    cancle_show = cancle_show || false;

    if ($('#msg_box')[0] == null) {
        initMsg();
    }
    if (cancle_show) {
        $('#aCancle').show();
    }
    else {
        $('#aCancle').hide();
    }

    $('#aOK').unbind('click');
    $('#aCancle').unbind('click');
    $('#aOK').click(ok_callback);
    $('#aCancle').click(cancle_callback);

    $('#pContent').text(content);

    art.dialog({
        id: 'msg_box',
        skin: "dialogbox",
        title: title,
        content: document.getElementById('msg_box'),
        opacity: 0.2,
        lock: true,
        width: width,
        padding: 10,
        drag: false,
        resize: false,
        eleId: eleId
    });
}
//初始化提示信息层
function initMsg() {
    var divMsg = '<div id="msg_box" style="display:none">' +
                    '<div class="layout_con">' +
                        '<p class="layout_msg" id="pContent"></p>' +
                        '<div class="layout_btn">' +
                            '<a href="javascript:void(0)" id="aOK"  class="btn_confirm"><span>确定</span></a>' +
                            '<a href="javascript:void(0)" id="aCancle" class="btn_cancel" style="display:none"><span>取消</span></a></div>' +
                    '</div>' +
                '</div>';
    $('body').append(divMsg);
}
//confirm弹层
//title             标题
//content           内容
//ok_callback       ‘确定’回调函数
//cancle_callback   ‘取消‘回调函数
//width             宽度
function showConfirm(content, title, ok_callback, cancle_callback, width, eleId) {
    showMsg(content, title, width, ok_callback, cancle_callback, true, eleId);
}
//关闭指定的弹框
//dialogId  弹窗ID
function closeDialog(dialogId) {
    art.dialog({ id: dialogId }).close();
}
/**
* js显示提示框
* @param {String}   content   内容
* @param {int}      time      显示时间(单位为毫秒,默认为3)
* @param {int}      icon      图标(0为x,1为√,2为i,默认为0 )
* @param {Function} callBack  回调函数(默认为空)
*/
function showTip(content, time, icon, callBack, eleId) {
    time = time || 3;
    icon = icon || 0; //默认出现  提示&报错icon
    callBack = callBack || null;
    artDialog({
        id: 'Tips',
        content: content,
        time: time,
        icon: IconArray[icon],
        padding: "20px 0px",
        skin: "simpletip",
        title: false,
        cancel: false,
        fixed: true,
        lock: false,
        eleId: eleId
    });

    if (typeof (callBack) == "function") {
        setTimeout(callBack, time * 1000);
    }
}
/* layout */

//Loading
function showLoading(content) {

    content = content || ' 正在处理...';

    artDialog({
        id: 'Loadingtip',
        content: '<img src="/content/images/dcr_wait.gif" style="vertical-align:text-bottom" />' + content,
        time: 1000,
        skin: "simpletip",
        title: false,
        cancel: false,
        fixed: true,
        lock: false
    });
}
//关闭弹窗
function hideMsgBox() {
    closeDialogById("msg_box");
}
//关闭Loading
function hideLoading() {
    closeDialogById("Loadingtip");
}
//关闭指定的弹框
//dialogId  弹窗ID
function closeDialogById(dialogId) {
    art.dialog({ id: dialogId }).close();
}

//关闭弹框
function closeDialog() {
    var list = art.dialog.list;
    for (var i in list) {
        list[i].close();
    };
}

//校验是否全由数字组
function isDigit(s) {
    var patrn = /^[0-9]{1,20}$/;
    if (!patrn.exec(s)) return false
    return true
}

//字符串千分位分割
function splitThousand(str) {
    var countTem = parseFloat(str);

    var regular = /(\d{1,3})(?=(\d{3})+(?:$|\.))/g;

    if (Math.round(countTem) === parseFloat(countTem)) {

        return countTem.toString().replace(regular, "$1,") + ".00";
    } else {
        return str.replace(regular, "$1,");
    }
}

//设置主菜单高亮
function setHeaderTab(index) {
    //var dom = $('#header .nav_wrap ul').find('li').eq(index);
    var dom = $("#header .nav_wrap>.clearfix> li").eq(index);
    if ($(dom)[0] != null) {
        $(dom).attr("class", "cur");
    }
}

//处理多选下拉框的值
function dealMultiSelectorText(selName) {
    var res = '';
    var ckName = '请选择';
    if (selName != ckName) {
        if (selName.substr(selName.length - 1) == ',') {
            res = selName.substring(0, selName.length - 1);
        }
        else {
            res = selName;
        }
    }
    return res;
}

//省市
function GetCities() {
    return GetSelectorJSONArray(CityArray);
}
//区
function GetDistricts(cityVal) {
    if (cityVal == null || cityVal == '') {
        return GetSelectorJSONArray();
    }
    else {
        var _districtArray = [];
        for (i in District) {
            if (i.substring(0, 2) == cityVal) {
                _districtArray[i] = District[i];
            }
        }
        return GetSelectorJSONArray(_districtArray);
    }
}

/**
 * @name  initRadiosFromJson        从数组中的数据生成单选按钮组
 * @param {Array}   sourceArray     数据格式 [{val:'value',txt:'文字'},{val:'value',txt:'文字'}]
 * @param {String}  divElemID       生成内容的DIV层的ID
 * @param {String}  fillDataElemID  单选按钮的name值
 * @param {Bool}    useKey          单选框的Value值是否用suorceArray数组的索引值,如果为true则数据中可以不含val
 */
function initRadiosFromJson(sourceJson, divElemID, fillDataElemID) {
    var str = "";
    if (sourceJson != null) {
        for (i in sourceJson) {
            //str += '<input name="' + fillDataElemID + '" type="radio" class="radiobtnfix" id="rdo' + fillDataElemID + i + '" value="' + sourceJson[i].val + '" />';
            //str += '<label for="rdo' + fillDataElemID + i + '">' + sourceJson[i].txt + '</label> ';
            str += '<label class="radio inline"><input type="radio" name="optionsRadios" id="rdo' + fillDataElemID + i + '" value="' + sourceJson[i].val + '">' + sourceJson[i].txt + '</label>';
        }
    }
    $('#' + divElemID).append(str);
}

//验证身份证
function validateIdCard(obj) {
    //是否验证空值
    //不验证空值
    if (!obj) {
        return true;
    }
    var aCity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙 江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖 北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西 藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国 外" };
    var iSum = 0;
    //var info = "";
    var strIDno = obj;
    var idCardLength = strIDno.length;
    if (!/^\d{17}(\d|x)$/i.test(strIDno) && !/^\d{15}$/i.test(strIDno))
        return false; //非法身份证号

    if (aCity[parseInt(strIDno.substr(0, 2))] == null)
        return false;// 非法地区

    // 15位身份证转换为18位
    if (idCardLength == 15) {
        sBirthday = "19" + strIDno.substr(6, 2) + "-" + Number(strIDno.substr(8, 2)) + "-" + Number(strIDno.substr(10, 2));
        var d = new Date(sBirthday.replace(/-/g, "/"))
        var dd = d.getFullYear().toString() + "-" + (d.getMonth() + 1) + "-" + d.getDate();
        if (sBirthday != dd)
            return 3; //非法生日
        strIDno = strIDno.substring(0, 6) + "19" + strIDno.substring(6, 15);
        strIDno = strIDno + GetVerifyBit(strIDno);
    }

    // 判断是否大于2078年，小于1900年
    var year = strIDno.substring(6, 10);
    if (year < 1900 || year > 2078)
        return false;//非法生日

    //18位身份证处理

    //在后面的运算中x相当于数字10,所以转换成a
    strIDno = strIDno.replace(/x$/i, "a");

    sBirthday = strIDno.substr(6, 4) + "-" + Number(strIDno.substr(10, 2)) + "-" + Number(strIDno.substr(12, 2));
    var d = new Date(sBirthday.replace(/-/g, "/"))
    if (sBirthday != (d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate()))
        return false; //非法生日
    // 身份证编码规范验证
    for (var i = 17; i >= 0; i--)
        iSum += (Math.pow(2, i) % 11) * parseInt(strIDno.charAt(17 - i), 11);
    if (iSum % 11 != 1)
        return false;// 非法身份证号

    // 判断是否屏蔽身份证
    var words = new Array();
    words = new Array("11111119111111111", "12121219121212121");

    for (var k = 0; k < words.length; k++) {
        if (strIDno.indexOf(words[k]) != -1) {
            return false;
        }
    }

    return true;
}

//处理图片路径
function GetImage(path, width, height) {
    var pathArray = path.replace(/\//g, "").split('.');
    if (pathArray.length > 1) {
        if (!width || !height) {
            return pathArray[0] + "_50x50_1." + pathArray[1];
        }
        else {
            return pathArray[0] + "_" + width + "x" + height + "_0." + pathArray[1];
        }
    }
    return null;
}

function GetNewImage(path, width, height) {
    var url = path.slice(path.indexOf('/'));
    var pathArray = url.replace(/\//g, "").split('.');
    if (pathArray.length > 1) {
        if (!width || !height) {
            return pathArray[0] + "_50x50_1." + pathArray[1];
        }
        else {
            return pathArray[0] + "_" + width + "x" + height + "_0." + pathArray[1];
        }
    }
    return null;
}

//修改指定行状态
function doChagneStatus(id, status) {
    var ispp = 0;
    if (arguments.length > 2 && arguments[2] != null) {
        ispp = arguments[2];
    }

    if ($("#st_" + id)[0]) {
        switch (status) {
            case 1:
                $("#st_" + id).html(ispp == 2 ? "通过审核" : (ispp == 1 ? "未使用" : "正常"));
                $("#st_" + id).attr("class", "label fz12 label-success");
                break;
            case 0:
                $("#st_" + id).html(ispp == 2 ? "待审核" : (ispp == 1 ? "已过期" : (ispp == 3 ? "驳回" : "冻结")));
                $("#st_" + id).attr("class", "label fz12 label-warning");
                break;
            case -1:
                $("#st_" + id).html(ispp == 2 ? "未通过审核" : (ispp == 1 ? "已使用" : "删除"));
                $("#st_" + id).attr("class", "label fz12");
                break;
            default:
                break;
        }
    }
    return false;
}

//修改活动/优惠状态后图标显示
function changePromotionStatus(id, status) {
    if ($("#st_" + id)[0]) {
        switch (status) {
            case 1:
                $("#st_" + id).html("通过审核");
                $("#st_" + id).attr("class", "label fz12 label-success");
                break;
            case 0:
                $("#st_" + id).html("待审核");
                $("#st_" + id).attr("class", "label fz12 label-info");
                break;
            case -1:
                $("#st_" + id).html("驳回");
                $("#st_" + id).attr("class", "label fz12 label-warning");
                break;
            case -2:
                $("#st_" + id).html("删除");
                $("#st_" + id).attr("class", "label fz12");
                break;
            default:
                break;
        }
    }
    return false;
}


var sortField = "";
var sortDirection = "";

function toggleSort(elem, name) {
    var preSortDirection = $(elem).attr("class");
    $(".sort").attr("class", "sort");
    if (preSortDirection.indexOf("asc") > 0) {
        $(elem).removeClass("asc").addClass("desc");
        sortDirection = "desc";
    } else {
        $(elem).addClass("asc");
        sortDirection = "asc";
    }

    sortField = name;

    doSearch();
}

function gotoPage() {
    var page = $("#txtGoPage").val();
    if (parseInt(page) >= 1) {
        doSearch(page);
    } else {
        alert("请输入正确的页码");
    }
}

//替换所有匹配的字符串
String.prototype.replaceAll = function (s1, s2) {
    var r = new RegExp(s1.replace(/([\(\)\[\]\{\}\^\$\+\-\*\?\.\"\'\|\/\\])/g, "\\$1"), "ig");
    return this.replace(r, s2);
}