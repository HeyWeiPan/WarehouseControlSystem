﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;

public partial class UploadFile_FileUpload : PageBase
{   
    public override void SetPageInfo(ref PageParameter p)
    {
        return;
    }

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }     
}
