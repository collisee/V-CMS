Telerik.Web.UI.Editor.CommandList["InsertNews"] = function(commandName, editor, args)
{
   var myCallbackFunction = function(sender, args)
   {
        editor.pasteHtml(args.text);
   }
   editor.showExternalDialog(
        'PopupInsertNews.aspx', {}, 850, 500,
        myCallbackFunction, null, 'Chọn Tin bài liên quan', true,
        Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize,
        false, true);
};

Telerik.Web.UI.Editor.CommandList["InsertLogo"] = function(commandName, editor, args)
{
   var myCallbackFunction = function(sender, args)
   {
        editor.pasteHtml(args.text);
   }
   editor.showExternalDialog(
        '../PopupSelectLogo.aspx', {}, 400, 310,
        myCallbackFunction, null, 'Chọn logo', true,
        Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize,
        false, true);
};

Telerik.Web.UI.Editor.CommandList["InsertSurvey"] = function(commandName, editor, args)
{
   var myCallbackFunction = function(sender, args)
   {
        editor.pasteHtml(args.text);
   }
   editor.showExternalDialog(
        '/Survey/PopupSurveyListApproved.aspx', {}, 600, 500,
        myCallbackFunction, null, 'Chọn thăm dò', true,
        Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize,
        false, true);
};

Telerik.Web.UI.Editor.CommandList["ImageManager"] = function(commandName, editor, args)
{
   var myCallbackFunction = function(sender, args)
   {
        var files = args;
        if (!files || !files.length) return;
        for (i = 0; i < files.length; i++)
        {
            if (files[i].type == 'Image')
            {
                var img = '<img alt="" src="' + files[i].file + '" />';
                editor.pasteHtml(img);
            }
        }
   }
   editor.showExternalDialog(
        '/FileManager.aspx', {}, 680, 550,
        myCallbackFunction, null, 'Chọn hình ảnh', true,
        Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize,
        false, true);
};

Telerik.Web.UI.Editor.CommandList["MediaManager"] = function(commandName, editor, args)
{
   var myCallbackFunction = function(sender, args)
   {
        var files = args;
        if (!files || !files.length) return;
        for (i = 0; i < files.length; i++)
        {
            if (files[i].type == 'Video' || files[i].type == 'Audio')
            {
                var width = 390;
                var height = (files[i].type == 'Video') ? 250 : 30;
                var media = '<div style="text-align:center;padding:10px 0;"> \r\n' + 
                            '<embed width="' + width + '" height="' + height + '" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"  \r\n'+
                            '    type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player" allowfullscreen="true"  \r\n'+
                            '    wmode="transparent" quality="high" src="/Lib/player.swf" flashvars="file=' + files[i].file + '&amp;skin=/Lib/vnn_v1.0.swf&amp;autostart=false&amp;shuffle=false&amp;mute=false&amp;repeat=none&amp;displayclick=play&amp;playlistsize=100&amp;playlist=none" />  \r\n'+
                            ' </div>';
                editor.pasteHtml(media);
            }
        }
   }
   editor.showExternalDialog(
        '/FileManager.aspx', {}, 680, 550,
        myCallbackFunction, null, 'Chọn file video', true,
        Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize,
        false, true);
};

Telerik.Web.UI.Editor.CommandList["FlashManager"] = function(commandName, editor, args)
{
   var myCallbackFunction = function(sender, args)
   {
        var files = args;
        if (!files || !files.length) return;
        for (i = 0; i < files.length; i++)
        {
            if (files[i].type == 'Flash' || files[i].type == 'Flash')
            {
                var width = 390;
                var height = 220;
                var media = '<div style="text-align:center;padding:10px 0;"> \r\n' + 
                            '<embed width="' + width + '" height="' + height + '" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"  \r\n'+
                            '    type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"  \r\n'+
                            '    wmode="transparent" quality="high" src="' + files[i].file + '" />  \r\n'+
                            ' </div>';
                editor.pasteHtml(media);
            }
        }
   }
   editor.showExternalDialog(
        '/FileManager.aspx', {}, 680, 550,
        myCallbackFunction, null, 'Chọn file flash', true,
        Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize,
        false, true);
};

Telerik.Web.UI.Editor.CommandList["Rolo"] = function(commandName, editor, args)
{
   var myCallbackFunction = function(sender, args)
   {
        if (args) setRoloNews(args);
   }
   editor.showExternalDialog(
        'PopupInsertRolo.aspx', {}, 880, 550,
        myCallbackFunction, null, 'Chọn tin Rolo', true,
        Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move,
        false, true);
};


function checkWords(editor, label)
{
    var content = editor.get_text(); //returns the editor's content as plain text
    var words = 0; 
    if (content) 
    {         
        punctRegX = /[!\.?;,:&_\-\-\{\}\[\]\(\)~#'"]/g; 
        content = content.replace(punctRegX, ""); 
        trimRegX = /(^\s+)|(\s+$)/g; 
        content = content.replace(trimRegX, ""); 
        if (content) 
        { 
            splitRegX = /\s+/; 
            var array = content.split(splitRegX); 
            words = array.length; 
        } 
    } 
    if (words > 50 || content.length > 250) $telerik.$(label).show();
    else  $telerik.$(label).hide();
}

function OnClientLoad(editor)
{ 
    editor.attachEventHandler ("onkeyup", function (e)
    {
        checkWords(editor, '#counter');
    });
}

function OnClientCommandExecuted(editor, args)
{
    checkWords(editor, '#counter');
}    

