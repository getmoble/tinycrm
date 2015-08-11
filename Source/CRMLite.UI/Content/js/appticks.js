appticks = {};
appticks.ajax = function ajax(url, params) {
    var xhr;
    if (window.XMLHttpRequest) {
        xhr = new XMLHttpRequest();
    } else {
        xhr = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xhr.open("POST", url, true);

    //Send the proper header information along with the request
    xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

    xhr.onreadystatechange = function () { //Call a function when the state changes.
        if (xhr.readyState == 4 && xhr.status == 200) {
            console.log(xhr.responseText);
        }
    };

    xhr.send(params);
};
appticks.getBrowser = function () {

    var ua = navigator.userAgent, tem, M = ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
    if (/trident/i.test(M[1])) {
        tem = /\brv[ :]+(\d+)/g.exec(ua) || [];
        return { name: 'IE', version: (tem[1] || '') };
    }
    if (M[1] === 'Chrome') {
        tem = ua.match(/\bOPR\/(\d+)/)
        if (tem != null) { return { name: 'Opera', version: tem[1] }; }
    }
    M = M[2] ? [M[1], M[2]] : [navigator.appName, navigator.appVersion, '-?'];
    if ((tem = ua.match(/version\/(\d+)/i)) != null) { M.splice(1, 1, tem[1]); }
    return {
        name: M[0],
        version: M[1]
    };
};
appticks.getPlatform = function () {
    var osName = "Unknown";
    if (window.navigator.userAgent.indexOf("Windows NT 10.0") != -1) osName = "Windows 10";
    if (window.navigator.userAgent.indexOf("Windows NT 6.2") != -1) osName = "Windows 8";
    if (window.navigator.userAgent.indexOf("Windows NT 6.1") != -1) osName = "Windows 7";
    if (window.navigator.userAgent.indexOf("Windows NT 6.0") != -1) osName = "Windows Vista";
    if (window.navigator.userAgent.indexOf("Windows NT 5.1") != -1) osName = "Windows XP";
    if (window.navigator.userAgent.indexOf("Windows NT 5.0") != -1) osName = "Windows 2000";
    if (window.navigator.userAgent.indexOf("Mac") != -1) osName = "Mac/iOS";
    if (window.navigator.userAgent.indexOf("X11") != -1) osName = "UNIX";
    if (window.navigator.userAgent.indexOf("Linux") != -1) osName = "Linux";
    return osName;
};
appticks.sendBeat = function () {
    var url = "http://appticks.logiticks.com/API/Health/HeartBeat";
    var loadTime = window.performance.timing.domContentLoadedEventEnd - window.performance.timing.navigationStart;
    var browser = appticks.getBrowser();
    var parameters = {
        Code: appticks.appCode,
        LoadTime: loadTime,
        Browser: browser.name,
        Version: browser.version,
        Platform: appticks.getPlatform()
    };

    var query = [];
    for (var key in parameters) {
        query.push(encodeURIComponent(key) + '=' + encodeURIComponent(parameters[key]));
    }

    appticks.ajax(url, query.join('&'));
};
appticks.handleError = function (msg, url, line, col, error) {
    var apiUrl = "http://appticks.logiticks.com/API/Error/Report";
    var loadTime = window.performance.timing.domContentLoadedEventEnd - window.performance.timing.navigationStart;
    var browser = appticks.getBrowser();
    var parameters = {
        Code: appticks.appCode,
        LoadTime: loadTime,
        Browser: browser.name,
        Version: browser.version,
        Platform: appticks.getPlatform(),
        Message: msg,
        Line: line,
        Url: url
    };

    var query = [];
    for (var key in parameters) {
        query.push(encodeURIComponent(key) + '=' + encodeURIComponent(parameters[key]));
    }

    appticks.ajax(apiUrl, query.join('&'));
};
appticks.init = function () {
    window.onload = function () {
        appticks.sendBeat();
    };
    window.onerror = function (msg, url, line, col, error) {
        appticks.handleError(msg, url, line, col, error);
    };
};

appticks.appCode = 'crmlite';
appticks.init();
