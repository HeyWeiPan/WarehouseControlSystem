/**
 * XMLHttpRequest Object Pool
 *
 * @author    DZD
 * @link      
 * @Copyright 
 */ 

var XMLHttp = {
    _objPool: [],
    //解决并发问题
    _getInstance: function ()
    {
        for (var i = 0; i < this._objPool.length; i ++)
        {
            if (this._objPool[i].readyState == 0 || this._objPool[i].readyState == 4)
            {
                return this._objPool[i];
            }
        }
        // IE5中不支持push方法
        this._objPool[this._objPool.length] = this._createObj();

        return this._objPool[this._objPool.length - 1];
    },
    //创建XMLHttpRequest
    _createObj: function ()
    {
        try
        {        
            if( window.ActiveXObject )
            {            
                for( var i = 5; i; i-- )
                {               
                    try
                    {                   
                        if( i == 2 )
                        {
                            objXMLHttp = new ActiveXObject( "Microsoft.XMLHTTP" );                       
                        }
                        else
                        {
                            objXMLHttp = new ActiveXObject( "Msxml2.XMLHTTP." + i + ".0" );	
                            objXMLHttp.setRequestHeader("Content-Type","text/xml");objXMLHttp.setRequestHeader("Content-Type","gb2312");                
                        }
                        break;
                     }               
                     catch(e)
                     {   
                        objXMLHttp = false;              
                     }          
                }       
            }
            else if( window.XMLHttpRequest )
            {            
                objXMLHttp = new XMLHttpRequest();           
                if (objXMLHttp.overrideMimeType) 
                {                
                    objXMLHttp.overrideMimeType('text/xml');            
                }       
            }   
        }
        catch(e)
        {        
            objXMLHttp = false;   
        }    
        return objXMLHttp;
    },
    //发送请求(方法[post,get], 地址, 数据, 回调函数)
    sendReq: function (method, url, data, callback)
    {
        var objXMLHttp = this._getInstance();
        with(objXMLHttp)
        {
            try
            {
                //加随机数防止缓存
                if (url.indexOf("?") > 0)
                {
                    url += "&randnum=" + Math.random();
                }
                else
                {
                    url += "?randnum=" + Math.random();
                }
                open(method, url, true);
                // 设定请求编码方式
                //setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=gb2312');
                send(data);
                onreadystatechange = function ()
                {
                    if (objXMLHttp.readyState == 4 && (objXMLHttp.status == 200 || objXMLHttp.status == 304))
                    {
                        callback(objXMLHttp);
                    }
                }
            }
            catch(e)
            {
                alert(e);
            }
        }
    }
};  
