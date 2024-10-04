<%@ Page Language="C#" MasterPageFile="~/Popup.Master" AutoEventWireup="true" Codebehind="PopupInsertRolo.aspx.cs"
    Inherits="VietNamNet.CMS.Articles.PopupInsertRolo" Title="Lấy tin Rolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">
                      
            function pageLoad()
            {
                $telerik.$('body').css({overflow:'hidden'});
            }

            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Cancel':
                        eventArgs.set_cancel(true);
                        break;
                    default:
                        break;
                };
            }
            
            function radToolBarDefault_ClientButtonClicked(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Cancel':
                        closeWin();
                        break;
                    default:
                        break;
                };
            }
          
        </script>
        
        <script type="text/javascript">

            function getRadWindow()
            {
                if (window.radWindow) return window.radWindow;
                if (window.frameElement && window.frameElement.radWindow) return window.frameElement.radWindow;
                return null;
            }
            
            function getData()
            {
                news = {
                    title: $get('<%=txtTitle.ClientID %>').value,
                    image: $get('<%=txtImage.ClientID %>').value,
                    lead: $get('<%=txtLead.ClientID %>').value,
                    content: $get('<%=txtContent.ClientID %>').value,
                    source: $get('<%=txtSource.ClientID %>').value
                }
                return news;
            }
            
            function insertNews(){
                //bind data return
                var arg = getData();
                
                //return data to parent
                var wnd = getRadWindow();
                if (wnd) wnd.close(arg); //use the close function of the getRadWindow to close the dialog 
                                         //and pass the arguments from the dialog to the callback function on the main page.
                else window.close();
            }

            function closeWin()
            {
                //get a reference to the RadWindow
                var wnd = getRadWindow();

                //close the RadWindow            
                if (wnd) wnd.close();
                else window.close();
            }
            
            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Insert':
                        eventArgs.set_cancel(true);
                        insertNews();
                        break;
                    case 'Close':
                        eventArgs.set_cancel(true);
                        closeWin();
                        break;
                    default:
                        break;
                };
            }
        
        </script>

        <script type="text/javascript">
            $ = jQuery = $telerik.$;
            /* AJAX Manager Add-on */
            (function($){$.extend({manageAjax:function(o){o=$.extend({manageType:'normal',maxReq:0,blockSameRequest:false,global:true},o);return new $.ajaxManager(o);},ajaxManager:function(o){this.opt=o;this.queue=[];}});$.extend($.ajaxManager.prototype,{add:function(o){var quLen=this.queue.length,s=this.opt,q=this.queue,self=this,i,j;o=$.extend({},s,o);var cD=(o.data&&typeof o.data!="string")?$.param(o.data):o.data;if(s.blockSameRequest){var toPrevent=false;for(i=0;i<quLen;i++){if(q[i]&&q[i].data===cD&&q[i].url===o.url&&q[i].type===o.type){toPrevent=true;break;}}if(toPrevent){return false;}}q[quLen]={fnError:o.error,fnSuccess:o.success,fnComplete:o.complete,fnAbort:o.abort,error:[],success:[],complete:[],done:false,queued:false,data:cD,url:o.url,type:o.type,xhr:null};o.error=function(){if(q[quLen]){q[quLen].error=arguments;}};o.success=function(){if(q[quLen]){q[quLen].success=arguments;}};o.abort=function(){if(q[quLen]){q[quLen].abort=arguments;}};function startCallbacks(num,opts){if(q[num].fnError&&q[num].error.length){q[num].fnError.apply(opts||$,q[num].error);}if(q[num].fnSuccess){q[num].fnSuccess.apply(opts||$,q[num].success);}if(q[num].fnComplete){q[num].fnComplete.apply(opts||$,q[num].complete);}self.abort(num,true);}o.complete=function(){if(!q[quLen]){return;}q[quLen].complete=arguments;q[quLen].done=true;switch(s.manageType){case'sync':if(quLen===0||!q[quLen-1]){var curQLen=q.length;for(i=quLen;i<curQLen;i++){if(q[i]){if(q[i].done){startCallbacks(i,this);}else{break;}}}}break;case'queue':if(quLen===0||!q[quLen-1]){var curQLen=q.length;for(i=0,j=0;i<curQLen;i++){if(q[i]&&q[i].queued){q[i].xhr=jQuery.ajax(q[i].xhr);q[i].queued=false;break;}}}startCallbacks(quLen,this);break;case'abortOld':startCallbacks(quLen,this);for(i=quLen;i>=0;i--){if(q[i]){self.abort(i);}}break;default:startCallbacks(quLen,this);break;}};if(s.maxReq){if(s.manageType!='queue'){for(i=quLen,j=0;i>=0;i--){if(j>=s.maxReq){this.abort(i);}if(q[i]){j++;}}}else{for(i=0,j=0;i<=quLen&&!q[quLen].queued;i++){if(q[i]&&!q[i].queued)j++;if(j>s.maxReq)q[quLen].queued=true;}}}q[quLen].xhr=(q[quLen].queued)?o:jQuery.ajax(o);return quLen;},cleanUp:function(){this.queue=[];},abort:function(num,completed){var qLen=this.queue.length,s=this.opt,q=this.queue,self=this,i;function del(num){if(!q[num]){return;}((!completed&&q[num].fnAbort)&&q[num].fnAbort.apply($,[num]));if(!q[num]){return;}if(q[num].xhr){if(typeof q[num].xhr.abort!='undefined'){q[num].xhr.abort();}if(typeof q[num].xhr.close!='undefined'){q[num].xhr.close();}q[num].xhr=null;}if(s.global&&$.active&&!--$.active){$.event.trigger("ajaxStop");}q[num]=null;}if(!num&&num!==0){for(i=0;i<qLen;i++){del(i);}this.cleanUp();}else{del(num);var allowCleaning=true;for(i=qLen;i>=0;i--){if(q[i]){allowCleaning=false;break;}}if(allowCleaning){this.cleanUp();}}}});})(jQuery);
            /* XML -> JSON Add-on */
            ;if(window.jQuery)(function($){$.extend({xml2json:function(xml,extended){if(!xml)return{};function parseXML(node,simple){if(!node)return null;var txt='',obj=null,att=null;var nt=node.nodeType,nn=jsVar(node.localName||node.nodeName);var nv=node.text||node.nodeValue||'';if(node.childNodes){if(node.childNodes.length>0){$.each(node.childNodes,function(n,cn){var cnt=cn.nodeType,cnn=jsVar(cn.localName||cn.nodeName);var cnv=cn.text||cn.nodeValue||'';if(cnt==8){return}else if(cnt==3||cnt==4||!cnn){if(cnv.match(/^\s+$/)){return};txt+=cnv.replace(/^\s+/,'').replace(/\s+$/,'')}else{obj=obj||{};if(obj[cnn]){if(!obj[cnn].length)obj[cnn]=myArr(obj[cnn]);obj[cnn][obj[cnn].length]=parseXML(cn,true);obj[cnn].length=obj[cnn].length}else{obj[cnn]=parseXML(cn)}}})}};if(node.attributes){if(node.attributes.length>0){att={};obj=obj||{};$.each(node.attributes,function(a,at){var atn=jsVar(at.name),atv=at.value;att[atn]=atv;if(obj[atn]){if(!obj[atn].length)obj[atn]=myArr(obj[atn]);obj[atn][obj[atn].length]=atv;obj[atn].length=obj[atn].length}else{obj[atn]=atv}})}};if(obj){obj=$.extend((txt!=''?new String(txt):{}),obj||{});txt=(obj.text)?(typeof(obj.text)=='object'?obj.text:[obj.text||'']).concat([txt]):txt;if(txt)obj.text=txt;txt=''};var out=obj||txt;if(extended){if(txt)out={};txt=out.text||txt||'';if(txt)out.text=txt;if(!simple)out=myArr(out)};return out};var jsVar=function(s){return String(s||'').replace(/-/g,"_")};var isNum=function(s){return(typeof s=="number")||String((s&&typeof s=="string")?s:'').test(/^((-)?([0-9]*)((\.{0,1})([0-9]+))?$)/)};var myArr=function(o){if(!o.length)o=[o];o.length=o.length;return o};if(typeof xml=='string')xml=$.text2xml(xml);if(!xml.nodeType)return;if(xml.nodeType==3||xml.nodeType==4)return xml.nodeValue;var root=(xml.nodeType==9)?xml.documentElement:xml;var out=parseXML(root,true);xml=null;root=null;return out},text2xml:function(str){var out;try{var xml=($.browser.msie)?new ActiveXObject("Microsoft.XMLDOM"):new DOMParser();xml.async=false}catch(e){throw new Error("XML Parser could not be instantiated")};try{if($.browser.msie)out=(xml.loadXML(str))?xml:false;else out=xml.parseFromString(str,"text/xml")}catch(e){throw new Error("Error parsing XML string")};return out}})})(jQuery);
            /* VietNamNet.Framework.JS Add-on */
            var VietNamNet=window.VietNamNet||{};VietNamNet.namespace=function(D){if(!D||!D.length){return null}var C=D.split(".");var A=VietNamNet;for(var B=(C[0]=="VietNamNet")?1:0;B<C.length;++B){A[C[B]]=A[C[B]]||{};A=A[C[B]]}return A};
            VietNamNet.namespace("Framework.JS");
            VietNamNet.Framework.JS.AjaxManager = $.manageAjax({manageType: 'queue', maxReq: 3, blockSameRequest: true});
            VietNamNet.Framework.JS.Template=Template=function(config){this.config={id:'id',template:''};$.extend(this.config,config||{});$.extend(this,this.config);};Template.prototype={append:function(c,o){if(typeof(c)=='string')c=$('#'+c);else c=$(c);var E=this.text(o);$(E).appendTo(c);},overwrite:function(c,o){if(typeof(c)=='string')c=$('#'+c);else c=$(c);c.html(this.text(o));},text:function(o){var t=this.template;for(var prop in o){var r=new RegExp("{"+prop+"}","g");t=t.replace(r,o[prop]);};return t;}};TemplateManager=function(config){this.config={id:'TemplateManager',items:[]};$.extend(this.config,config||{});$.extend(this,this.config);};TemplateManager.prototype={clear:function(){this.items.clear();},add:function(t){this.items.add(t);},remove:function(t){this.items.remove(t);},get:function(id){return this.items.get(id);},bind:function(c,o,t){if(o.length&&o.length>0){for(var i=0;i<o.length;i++){if(i==0){t.overwrite(c,o[i]);}else{t.append(c,o[i]);}}}else{t.overwrite(c,o);}}};
            VietNamNet.Framework.JS.TemplateManager=new TemplateManager({});
            
            //LINK: /ajax/ajaxProxy/get.html?url=http://news.rolo.vn/news/topnewsapi&action=get_news&catid=9&num=20&apikey=qwertyu
            function getRoloTopNews(){
                //scroll
                $('#rolo').scrollTop(0);
                //show loading
                $('#rolo-topnews').html('<img src="/Images/loading.gif" />');
                
                VietNamNet.Framework.JS.AjaxManager.add({
                    url: '/ajax/ajaxProxy/get.html',
                    dataType: "xml",
                    data: {
                        url: 'http://news.rolo.vn/news/topnewsapi', 
                        action: 'get_news', 
                        apikey: 'qwertyu',
                        contentType: "text/xml",
                        catid: $('#catid').val(), 
                        num: $('#num').val()
                    },
                    success : function(xml){
                        $('#rolo-topnews').html('&nbsp;');
                        newsList = [];
                        $(xml).find('news').each(function(){
                            newsList.push({
                                id: $(this).attr('id'),
                                link: $(this).attr('link'),
                                title: $(this).attr('title'),
                                date: $(this).attr('date'),
                                image: $(this).attr('img'),
                                lead: $(this).attr('summary'),
                                source: $(this).attr('source')
                            });
                        });
                        
                        var templateNews = new VietNamNet.Framework.JS.Template({
                            id: 'templateNews',
                            template: '<div class="news-item">'+
                                      '<div class="news-item-img fleft w100 pr05">'+
                                      '    <a href="javascript:getRoloNews({id})"><img src="{image}" width="100" /></a>'+
                                      '</div>'+
                                      '<div class="news-item-title">'+
                                      '    <a href="javascript:getRoloNews({id})" class="bold">{title}</a>'+
                                      '</div>'+
                                      '<div class="news-item-time small">Ngày đăng: <span class="gray">{date}</span></div>'+
                                      '<div class="news-item-time">{lead}</div>'+
                                      '<div class="news-item-time">Nguồn: <a href="{link}" target="_blank" class="blue1">{source}</a></div>'+
                                      '<br class="clear" />'+
                                      '</div>'
                        });
                        if (newsList && newsList.length > 0) VietNamNet.Framework.JS.TemplateManager.bind('rolo-topnews', newsList, templateNews);
                    }
                });
            }
            
            function getRoloNews(id, lead, source){
                //clear value
                $get('<%=txtTitle.ClientID %>').value = '';
                $get('<%=txtImage.ClientID %>').value = '';
                $get('<%=txtLead.ClientID %>').value = '';
                $get('<%=txtContent.ClientID %>').value = '';
                $get('<%=txtSource.ClientID %>').value = '';
                
                //scroll
                $('#rolo').scrollTop(0);
                //show loading
                $('#rolo-newsdetail').html('<img src="/Images/loading.gif" />');
                
                VietNamNet.Framework.JS.AjaxManager.add({
                    url: '/ajax/ajaxProxy/get.html',
                    dataType: "xml",
                    data: {
                        url: 'http://news.rolo.vn/news/topnewsapi',
                        action: 'news_content',
                        apikey: 'qwertyu',
                        contentType: "text/xml",
                        id: id
                    },
                    success : function(xml){
                        $('#rolo-newsdetail').html('&nbsp;');
                        //var news = {};
                        for (var i = 0; i < newsList.length; i++){
                            if (newsList[i].id == id){
                                news = newsList[i];
                                break;
                            }
                        }
                        $(xml).find('news').each(function(){
                            news = $.extend(news, {
                                content: $(this).attr('content')
                            });
                        });
                        
                        var templateNews = new VietNamNet.Framework.JS.Template({
                            id: 'templateNews',
                            template: '<div class="news-item">'+
                                      '<div class="news-item-title bold fs18 pt10 pb10">{title}</div>'+
                                      '<div class="news-item-img fleft w100 pr05">'+
                                      '    <a href="javascript:void(0)"><img src="{image}" width="100" /></a>'+
                                      '</div>'+
                                      '<div class="news-item-time small">Ngày đăng: <span class="gray">{date}</span></div>'+
                                      '<div class="news-item-time">{content}</div>'+
                                      '<div class="news-item-time">Nguồn: <a href="{link}" target="_blank" class="blue1">{source}</a></div>'+
                                      '<br class="clear" />'+
                                      '</div>'
                        });
                        if (news) {
                            $get('<%=txtTitle.ClientID %>').value = news.title;
                            $get('<%=txtImage.ClientID %>').value = news.image;
                            $get('<%=txtLead.ClientID %>').value = news.lead;
                            $get('<%=txtContent.ClientID %>').value = news.content;
                            $get('<%=txtSource.ClientID %>').value = news.source;
                            VietNamNet.Framework.JS.TemplateManager.bind('rolo-newsdetail', news, templateNews);
                        }
                    }
                });
            }
            
            $(function(){
                getRoloTopNews();
            });
        </script>

    </telerik:RadScriptBlock>
    
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="ajaxPanelNews" runat="server" LoadingPanelID="radAjaxLoadingPanel" ClientEvents-OnResponseEnd="insertNews">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnClientButtonClicked="radToolBarDefault_ClientButtonClicked"
                OnClientButtonClicking="radToolBarDefault_ClientButtonClicking" OnButtonClick="radToolBarDefault_ButtonClick">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveitem.gif" CommandName="Save"
                        Text="Lấy tin" AccessKey="S">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/goback1.gif" CommandName="Cancel"
                        Text="Đóng" AccessKey="C">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        <asp:TextBox ID="txtTitle" runat="server" Width="0px" Height="0px" CssClass="none"></asp:TextBox>
        <asp:TextBox ID="txtImage" runat="server" Width="0px" Height="0px" CssClass="none"></asp:TextBox>
        <asp:TextBox ID="txtSource" runat="server" Width="0px" Height="0px" CssClass="none"></asp:TextBox>
        <asp:TextBox ID="txtLead" runat="server" Width="0px" Height="0px" CssClass="none" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="txtContent" runat="server" Width="0px" Height="0px" CssClass="none" TextMode="MultiLine"></asp:TextBox>
    <div class="pd10" style="border-bottom:dotted 1px Blue;">
        Chuyên mục: 
        <select onchange="getRoloTopNews()" id="catid">
            <option value="1">Xã hội</option>
            <option value="2">Kinh tế</option>
            <option value="3">Khoa học công nghệ</option>
            <option value="4">Giáo dục</option>
            <option value="5">Thể thao</option>
            <option value="6">Thế giới</option>
            <option value="7">Nghệ thuật</option>
            <option value="8">Sức khỏe</option>
            <option value="9">Nhịp sống trẻ</option>
        </select>
        Số tin: 
        <select onchange="getRoloTopNews()" id="num" class="w50">
            <%--<option value="1">1</option>
            <option value="2">2</option>
            <option value="5">5</option>--%>
            <option value="10" selected="selected">10</option>
            <option value="20">20</option>
            <option value="40">40</option>
            <option value="60">60</option>
            <option value="80">80</option>
            <option value="100">100</option>
        </select>
    </div>
    <div id="rolo" style="width:863px;height:438px;overflow-y:scroll;overflow-x:hidden;">
        <div class="news-items fleft w400 pd10" id="rolo-topnews">
        </div>
        <div class="fleft w400 pd10" id="rolo-newsdetail">
        </div>
        <br class="clear" />
    </div>
    </telerik:RadAjaxPanel>
</asp:Content>
