<%@ Page Language="C#" AutoEventWireup="true" %>

<script runat="server">
    void Page_Load()
    {
        Sitecore.Diagnostics.Log.Info("Warmup URL 2 loaded", this);

        System.Threading.Thread.Sleep(150000); 
    }
</script>
App Test OK