AP.Core.JS.Initialization.add(AP.Core.JS.PopupLead.init);

function onKeyPress(evt,act,c,a,s)
{
    var e=(window.event)?window.event:evt;
    var mykey,alt,ctrl,shift,str;
    if(!c)c=false;
    if(!a)a=false;
    if(!s)s=false;
    mykey=e.keyCode;
    ctrl=e.ctrlKey;
    alt=e.altKey;
    shift=e.shiftKey;
    if((mykey==13)&&(ctrl==c)&&(alt==a)&&(shift==s))
    {
        act();
        if(e.preventDefault)e.preventDefault()
        else e.returnValue=false;
    }
}

function search(id)
{
    document.getElementById(id).click();
}


function initLink(){
    var rnd = 0.6;
    $('a').each(function(){
        var href = this.href;
        if (href && href.indexOf('/vn/') > -1 && Math.random() < rnd){
            href = href.replace('/vn/', '/vi/');
            $(this).click(function(){
                var pageTracker=_gat._getTracker('UA-6610653-21');
                pageTracker._trackPageview(href);
//                var link = {href: href};
//                recordOutboundLink(this, 'virtual link', 'vietnamnet.vn');
//                return false;
            });
        }
    });
}
AP.Core.JS.Initialization.add(initLink);