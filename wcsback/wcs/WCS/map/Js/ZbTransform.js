//坐标点转换
document.write("<script type=\"text\/javascript\" src=\"http://api.map.baidu.com\/api?v=1.5&ak=3b62f10a17e02430c8a7d4751a1593bd\"><\/script>");
document.write("<script type=\"text\/javascript\" src=\"convertor.js\"><\/script>");//单个转换
document.write("<script type=\"text\/javascript\" src=\"changeMore.js\"><\/script>");//多个转换，最多支持20个

//从GPS转换成百度地图坐标，lng:经度；lat:纬度
function GPSToBaiDuPoint(lng, lat) {    
    var GspPoint = new BMap.Point(lng, lat);
    BMap.Convertor.translate(GspPoint, 0, GPSToBaiDuCallback);  //GSP经纬度转成百度坐标
    
}

//GSP转换百度地图坐标回调函数
function GPSToBaiDuCallback(point) {
    alert(point.lng);
    alert(point.lat);
}

function GooglePointToBaiDuPoint(lng, lat) {
    var GooglePoint = new BMap.Point(lng, lat);
    BMap.Convertor.translate(GooglePoint, 2, translateCallback);  //GSP经纬度转成谷歌坐标    
}

function GoogleToBaiDuCallback(point) {
    alert(point.lng);
}




