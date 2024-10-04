<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSlideImageContent.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelSlideImageContent" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<asp:Repeater ID="rptNewsDetail" runat="server">
    <ItemTemplate>
        
        <script language="javascript" type="text/javascript">
        $(document).ready(function(){
	        checkContentMask();
        });
        function checkContentMask() {
	        if($("#VNNsliderContentDisplay").height() > $("#VNNsliderContentMask").height()) {
		        $("#linkShowFullDetail").show();
		        $("#VNNsliderContentMask").height(525);
	        } else {
		        $("#linkShowFullDetail").hide();		        
	        }
        }
        </script>
        
        <div class="clearfix titleSlidePage">
            <div class="c_l">
                <h1 class="article-title">
                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                </h1>
            </div>
            <div class="c_r">
                <p align="right">                     
                     <a class="img_button print" href="javascript:void(0)" onclick="window.open(window.location.href.replace('/vn/', '/vn/print/'));" title="In bài viết">Print</a>                     
                     <a href="javascript:void(0)" onclick="share_facebook();" class="img_button facebook" title="Chia sẻ bài viết với bạn bè trên Facebook">FaceBook</a>
                     <a href="javascript:void(0)" onclick="share_twitter();" class="img_button twitter" title="Chia sẻ bài viết với bạn bè trên Twitter">Twitter</a>                     
                </p>
            </div>
        </div>
        <div class="clearfix contentSlidePage">
            <div class="c_l floatLeft">
                <div id="VNNsliderDisplay">
                    Bạn cần cài đặt Flash player để có thể xem Slider ảnh.<a href="http://www.adobe.com/go/getflashplayer"><img
                        src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                        alt="Get Adobe Flash player" /></a></div>
                <!-- embedding SWF -->

                <script type="text/javascript">
							var flashvars = {};
							flashvars.xml_file = "/ajax/getPhoto/get.html?DocId=<%=ArticleId %>&MediaType=Image";
							flashvars.time_delay = 10000;
							
							var params = {};
							params.wmode = "transparent";	
							params.allowScriptAccess = "sameDomain";
							params.scale = "noscale";
							params.allowFullScreen = "true";
							params.salign = "";
							params.quality = "high";
							
							var attributes = {};
							attributes.id = "slider";
							swfobject.embedSWF("/lib/sport_photo_main.swf", "VNNsliderDisplay", "650", "563", "9.0.0","", flashvars, params, attributes);
                </script>

                <!-- embedding SWF -->
            </div>
            <div class="c_r floatLeft">
                <div id="VNNsliderContentBox">
                    <a class="fullDetail thickbox" id="linkShowFullDetail" href="#TB_inline?height=450&width=760&inlineId=VNNsliderContentMask" title="<%#DataBinder.Eval(Container.DataItem, "Name") %>">
                        <span>Mở rộng nội dung</span></a>
                    <div id="VNNsliderContentMask">
                        <div id="VNNsliderContentDisplay">
                            <p class="article-date">
                                Cập nhật lúc
                                <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
                                (GMT+7)</p>
                            <%#DataBinder.Eval(Container.DataItem, "Detail")%>                            
                        </div>
                        <!-- [VNNsliderContentDisplay] -->
                    </div>
                    <!-- [VNNsliderContentMask] -->
                </div>
                <!-- [VNNsliderContentBox] -->
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
