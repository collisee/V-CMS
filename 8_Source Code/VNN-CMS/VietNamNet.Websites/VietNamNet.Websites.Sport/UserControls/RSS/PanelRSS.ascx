<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelRSS.ascx.cs" Inherits="VietNamNet.Websites.Sport.UserControls.RSS.PanelRSS" %>
<div class="sktt ">
				<div class="sktt-top">&nbsp;</div>
<div class="rss-menu" style=" ">
    <ul>
        <li><a href="#WhatRssIs">RSS là gì?</a></li>
        <li><a href="#VietNamNetChannel">Danh mục Kênh RSS của báo VietNamNet</a></li>
        <li><a href="#AddPersonal">Thêm RSS vào trang Cá nhân</a></li>
        <li><a href="#WhatRssReaderIs">Chương trình đọc RSS là gì?</a> </li>
        <li><a href="#TermAndConditionOfUse">Điều kiện sử dụng</a></li>
    </ul>
 </div>

				<div class="pdlr10">
				
					<div class="patway-search">
							RSS
					</div>
					<div class="rss-text">
						<div class="content-article" style="padding: 15px; text-align: justify; line-height: 1.5em;">
							  <h3 id="WhatRssIs">
								RSS là gì?</h3>
							  <p>
								RSS là định dạng dữ liệu dựa theo chuẩn XML được sử dụng để chia sẻ và phát tán
								nội dung Web. Việc sử dụng các chương trình đọc tin (News Reader, RSS Reader hay
								RSS Feeds) sẽ giúp bạn luôn xem được nhanh chóng tin tức mới nhất từ Báo VietNamNet
							  </p>
							  <p>
								Mỗi tin dưới dạng RSS sẽ gồm : Tiêu đề, tóm tắt nội dung và đường dẫn nối đến trang
								Web chứa nội dung đầy đủ của tin.
							  </p>
							  <h3 id="VietNamNetChannel">
								Các kênh RSS của báo VietNamNet</h3>
							  <p>
								</p><table width="100%">
								  <tbody><tr>
									<td>
									  <a href="/rss/home.rss">
										<img alt="RSS trang chủ" src="/Images/rss.png"></a>
									</td>
									<td>
									  <a href="/vn/index.html">Trang chủ</a>
									</td>
									<td>
									  <a href="/rss/home.rss">
										http://thethao.vietnamnet.vn/vn/rss/trang-chu.rss</a></td>
									<td>
									  <a onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/vn/rss/home.rss');" href="#">
										<img src="/Images/plus_google.gif" alt="Add to Google"></a> <a onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/vn/rss/home.rss');" href="#">
										  <img src="/Images/addtomyyahoo.gif" alt="Add to MyYahoo"></a></td>
								  </tr>
								  <tr>
									<td>
									  <a href="/rss/doi-tuyen-viet-nam.rss">
										<img alt="RSS Đội tuyển Việt Nam" src="/Images/rss.png"></a>
									</td>
									<td>
									  <a href="/vn/doi-tuyen-viet-nam/index.html">Đội tuyển Việt Nam</a></td>
									<td>
									  <a href="/rss/doi-tuyen-viet-nam.rss">
										http://thethao.vietnamnet.vn/rss/doi-tuyen-viet-nam.rss</a></td>
									<td>
									  <a onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/rss/doi-tuyen-viet-nam.rss');" href="#">
										<img src="/Images/plus_google.gif" alt="Add to Google"></a> <a onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/rss/doi-tuyen-viet-nam.rss');" href="#">
										  <img src="/Images/addtomyyahoo.gif" alt="Add to MyYahoo"></a></td>
								  </tr>
                                      <tr>
                                          <td>
                                              <a href="/rss/v-league.rss">
                                                  <img alt="RSS V League" src="/Images/rss.png"></a>
                                          </td>
                                          <td>
                                              <a href="/vn/v-league/index.html">V League</a></td>
                                          <td>
                                              <a href="/rss/v-league.rss">http://thethao.vietnamnet.vn/rss/v-league.rss</a></td>
                                          <td>
                                              <a href="#" onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/rss/v-league.rss');">
                                                  <img alt="Add to Google" src="/Images/plus_google.gif"></a> <a href="#" onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/rss/v-league.rss');">
                                                      <img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif"></a></td>
                                      </tr>
								  <tr>
									<td>
									  <a href="/rss/premier-league.rss">
										<img alt="RSS Premier League" src="/Images/rss.png"></a>
									</td>
									<td>
									  <a href="/vn/premier-league/index.html">Premier League</a></td>
									<td>
									  <a href="/rss/premier-league.rss">
										http://thethao.vietnamnet.vn/vn/rss/premier-league.rss</a></td>
									<td>
									  <a onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/vn/rss/premier-league.rss');" href="#">
										<img src="/Images/plus_google.gif" alt="Add to Google"></a> <a onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/vn/rss/premier-league.rss');" href="#">
										  <img src="/Images/addtomyyahoo.gif" alt="Add to MyYahoo"></a></td>
								  </tr>
								  <tr>
									<td>
									  <a href="/rss/la-liga.rss">
										<img alt="RSS La Liga" src="/Images/rss.png"></a>
									</td>
									<td>
									  <a href="/vn/la-liga/index.html">La Liga</a></td>
									<td>
									  <a href="/rss/la-liga.rss">
										http://thethao.vietnamnet.vn/vn/rss/la-liga.rss</a></td>
									<td>
									  <a onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/vn/rss/la-liga.rss');" href="#">
										<img src="/Images/plus_google.gif" alt="Add to Google"></a> <a onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/vn/rss/la-liga.rss');" href="#">
										  <img src="/Images/addtomyyahoo.gif" alt="Add to MyYahoo"></a></td>
								  </tr>
								  <tr>
									<td>
									  <a href="/rss/serie-a.rss">
										<img src="/Images/rss.png" alt="RSS Serie A"></a>
									</td>
									<td>
									  <a href="/vn/serie-a/index.html">Serie A</a></td>
									<td>
									  <a href="/rss/serie-a.rss">
										http://thethao.vietnamnet.vn/vn/rss/serie-a.rss</a></td>
									<td>
									  <a onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/vn/rss/serie-a.rss');" href="#">
										<img src="/Images/plus_google.gif" alt="Add to Google"></a> <a onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/vn/rss/serie-a.rss');" href="#">
										  <img src="/Images/addtomyyahoo.gif" alt="Add to MyYahoo"></a></td>
								  </tr>
								  <tr>
									<td>
									  <a href="/rss/bundesliga.rss">
										<img src="/Images/rss.png" alt="RSS Bundesliga"></a>
									</td>
									<td>
									  <a href="/vn/bundesliga/index.html">Bundesliga</a></td>
									<td>
									  <a href="/rss/bundesliga.rss">
										http://thethao.vietnamnet.vn/vn/rss/bundesliga.rss</a></td>
									<td>
									  <a onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/vn/rss/bundesliga.rss');" href="#">
										<img src="/Images/plus_google.gif" alt="Add to Google"></a> <a onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/vn/rss/bundesliga.rss');" href="#">
										  <img src="/Images/addtomyyahoo.gif" alt="Add to MyYahoo"></a></td>
								  </tr>
								  <tr>
									<td>
									  <a href="/rss/champions-league.rss">
										<img src="/Images/rss.png" alt="RSS Champions League"></a>
									</td>
									<td>
									  <a href="/vn/champions-league/index.html">Champions League</a></td>
									<td>
									  <a href="/rss/champions-league.rss">
										http://thethao.vietnamnet.vn/vn/rss/champions-league.rss</a></td>
									<td>
									  <a onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/vn/rss/champions-league.rss');" href="#">
										<img src="/Images/plus_google.gif" alt="Add to Google"></a> <a onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/vn/rss/champions-league.rss');" href="#">
										  <img src="/Images/addtomyyahoo.gif" alt="Add to MyYahoo"></a></td>
								  </tr> 
                                      <tr>
                                          <td>
                                              <a href="/rss/hau-truong.rss">
                                                  <img alt="RSS Hậu trường" src="/Images/rss.png"></a>
                                          </td>
                                          <td>
                                              <a href="/vn/hau-truong/index.html">Hậu trường</a></td>
                                          <td>
                                              <a href="/rss/hau-truong.rss">http://thethao.vietnamnet.vn/vn/rss/hau-truong.rss</a></td>
                                          <td>
                                              <a href="#" onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/vn/rss/hau-truong.rss');">
                                                  <img alt="Add to Google" src="/Images/plus_google.gif"></a> <a href="#" onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/vn/rss/hau-truong.rss');">
                                                      <img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif"></a></td>
                                      </tr>
                                      <tr>
                                          <td>
                                              <a href="/rss/dien-dan.rss">
                                                  <img alt="RSS Diễn đàn bạn đọc" src="/Images/rss.png"></a>
                                          </td>
                                          <td>
                                              <a href="/vn/dien-dan/index.html">Diễn đàn bạn đọc</a></td>
                                          <td>
                                              <a href="/rss/dien-dan.rss">http://thethao.vietnamnet.vn/vn/rss/dien-dan.rss</a></td>
                                          <td>
                                              <a href="#" onclick="return rss_GoogleReader('http://thethao.vietnamnet.vn/vn/rss/dien-dan.rss');">
                                                  <img alt="Add to Google" src="/Images/plus_google.gif"></a> <a href="#" onclick="return rss_MyYahoo('http://thethao.vietnamnet.vn/vn/rss/dien-dan.rss');">
                                                      <img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif"></a></td>
                                      </tr>  
                                      
                                  </tbody></table>
							  
							
							  <h3 id="AddPersonal">
								Thêm một kênh <a href="#WhatRssIs">RSS</a> của báo VietNamNet vào các trang Cá
								nhân: Google, MyYahoo!</h3>
							  <div>1. Nhấn vào nút "+Google" hoặc "+My Yahoo!" cùng dòng với mục bạn muốn trong bảng
								  danh mục <a href="#VietNamNetChannel">kênh RSS</a> của báo VietNamNet.</div>
								<div>2. Làm theo các chỉ dẫn để thêm mục RSS tương ứng của báo VietNamNet vào trang Cá
								  nhân của bạn.</div>
								 
							  <h3 id="WhatRssReaderIs">
								Chương trình đọc RSS là gì?</h3>
							  <p>
								Rss Reader là phần mềm có chức năng tự động lấy tin tức đã được cấu trúc theo định
								dạng RSS. Một số phần mềm đọc RSS cho phép bạn lập lịch cập nhật tin tức. Với chương
								trình đọc RSS, bạn có thể nhấn chuột vào tiêu đề của 1 tin để đọc phần tóm tắt của
								hoặc mở ra nội dung của toàn bộ tin trong một cửa sổ trình duyệt mặc định.</p>
							  <p>
								Có rất nhiều phần mềm phục vụ khai thác tin qua định dạng RSS, bạn có thể tham khảo
								bảng các chương trình đọc RSS bên cạnh và lựa chọn cái bạn thích nhất.</p>
							  <p>
								Nếu đang sử dụng FireFox, bạn có thể tải chương trình Wizz RSS từ<a href="https://addons.mozilla.org/firefox/424/">địa
								  chỉ này</a></p>
							<h3 id="Add2RssReader">
								Sử dụng chương trình đọc RSS (RSS Reader)</h3>
							  
								<div >1. Chép (copy) đường dẫn (URL) tương ứng với kênh RSS mà bạn ưa thích.</div>
								<div >
									2. Dán (paste) URL vào chương trình đọc RSS.
								</div>
							 
							  <h3 id="TermAndConditionOfUse">
								Điều kiện sử dụng</h3>
							  <p>
								Báo VietNamNet không chịu trách nhiệm về các nội dung của các trang khác ngoài Báo
								VietNamNet được dẫn trong trang này.</p>
							  <p>
								Khi sử dụng lại các tin lấy từ Báo VietNamNet, bạn phải ghi rõ nguồn tin là "Theo
								Báo VietNamNet" hoặc "Báo VietNamNet".</p>
							  <a href="#" class="totop">Về đầu trang</a>
							</div>
					</div>
				</div>
				<div class="sktt-bottom ">&nbsp;</div>
			</div>