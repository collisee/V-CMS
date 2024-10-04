<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:param name="name"/>
	<xsl:param name="emailFrom"/>
  <xsl:param name="phone"/>
	<xsl:param name="notes"/> 
	<xsl:param name="subject"/> 
  <xsl:param name="userfile"/> 
	<xsl:template match="/">
		<html>

			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
				<title>VietNamNet - Thông tin Upload clip</title>
				<style>
					body, form {
					margin: 0;
					}
					body {
					font-family: arial, verdana, helvetica, sans-serif;
					font-size:13px;
					background: white;
					color: black;
					}
				</style>
			</head>
			<body>
				<table border="0" width="100%">
					<tr>
						<td width="10px"></td>
						<td class="ms-formbody">
              <h4>Thông tin clip gửi đến tòa soạn </h4>
							Bạn: <xsl:value-of select="$name"/> (email: <xsl:value-of select="$emailFrom"/>, SĐT: <xsl:value-of select="$phone"/>) <br />

							Gửi đến toàn soạn clip với tiêu đề:  <xsl:value-of select="$subject"/><br />
							 
							với tên file là : <xsl:value-of select="$userfile"/> và thông tin:   <xsl:value-of select="$notes"/>
              
							Email này được gửi bằng tiện ích \"Gửi cho bạn bè\" của VietNamNet.vn.<br />
							Đây là Email tự động, vui lòng đừng trả lời Email này. Nếu có vấn đề xin liên hệ với chúng tôi.							<br />
							Neu khong doc duoc chu tieng Viet xin vui long chon View/Unicode UTF-8 tren trinh duyet dang dung.
						</td>
					</tr>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>