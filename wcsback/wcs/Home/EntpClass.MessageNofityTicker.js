// <reference path="../scripts/jquery-1.6.4.js" />
// <reference path="../scripts/jquery.signalr.js" />
//$(function () {  
//    var ticker = $.connection.messageNotifyTicker; // the generated client-side hub proxy  
//    ticker.notifyClient = function (stock) {     
//        $('#span3').html(stock.NewMsgCount);
//        $('#mail').animate({
//            opacity: 'toggle'
//        }, "slow").animate({
//            opacity: 'show'
//        }, "slow");
//    };
//    ticker.notifyOpened = function () {

//    };
//    ticker.notifyClosed = function () {

//    };
//    ticker.notifyReset = function () {

//    };
//    // Start the connection
//    $.connection.hub.start(function () {
//        ticker.openTicker($('#HidUserID').val());
//    });

//    //    // Wire up the buttons
//    //    $("#open").click(function () {
//    //        debugger;
//    //       
//    //    });

//    $("#close").click(function () {
//        ticker.closeTicker();
//    });

//    $("#reset").click(function () {
//        ticker.reset();
//    });
//});