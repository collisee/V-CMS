<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:param name="name"/>
	<xsl:param name="emailFrom"/>
	<xsl:param name="message"/>
	<xsl:param name="catAlias"/>
	<xsl:param name="articleId"/>
	<xsl:param name="subject"/>
	<xsl:param name="article_link"/>
	<xsl:template match="/">
		<html>

			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
				<title>VietNamNet - Gửi bài viết cho bạn bè</title>
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
							Bạn: <xsl:value-of select="$name"/> (email: <xsl:value-of select="$emailFrom"/>) <br />

							Gửi bạn bài báo:  <xsl:value-of select="$subject"/><br />
							http://203.162.71.133:8181<xsl:value-of select="$article_link"/><br/>
							với lời nhắn:   <xsl:value-of select="$message"/>
							<hr/>
							Email này được gửi bằng tiện ích \"Gửi cho bạn bè\" của VietNamNet.vn.<br />

							Đây là Email tự động, vui lòng đừng trả lời Email này. Nếu có vấn đề xin liên hệ với chúng tôi.
							<br />
							Neu khong doc duoc chu tieng Viet xin vui long chon View/Unicode UTF-8 tren trinh duyet dang dung.
						</td>
					</tr>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>