<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:param name="FullName"/>
	<xsl:param name="Password"/>
	<xsl:template match="/">
		<html>

			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
				<title>Mật khẩu mới</title>
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
							Dear <xsl:value-of select="$FullName"/>,
							<br/>
							Mật khẩu mới của bạn là:
							<br/>
							<xsl:value-of select="$Password"/>
							<br/>
							<br/>
							Thanks &amp; Regards,
							<br/>
							VietNamNet Support.
							<br/>
						</td>
					</tr>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>