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

function confirmDelete()
{
    return confirm('Bạn có chắc chắn muốn Xóa mục này?');
}

function confirmDeleteAll()
{
    return confirm('Bạn có chắc chắn muốn Xóa Tất cả?');
}

function confirmAddBlackList()
{
    return confirm('Bạn có chắc chắn muốn thêm Người này vào danh sách Black List?');
}

function confirmRemoveBlackList()
{
    return confirm('Bạn có chắc chắn muốn cho Người này ra khỏi danh sách Black List?');
}

function RowDblClick(sender, eventArgs)
{
    var editedRow = eventArgs.get_itemIndexHierarchical();
    sender.get_masterTableView().editItem(editedRow);
}

function decodeHTML(html)
{
    var p = document.createElement('p');
    p.innerHTML = html;
    return p.innerText ? p.innerText : p.textContent;
}

            
function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
{
    var cmd = eventArgs.get_item().get_commandName();
    switch (cmd)
    {
        case 'Delete':
            eventArgs.set_cancel(!confirm('Bạn có chắc chắn muốn Xóa mục này?'));
            break;
        default:
            break;
    };
}
