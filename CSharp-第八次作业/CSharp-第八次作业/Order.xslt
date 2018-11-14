<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/dotnet_order">
		<html>
			<head>
				<title>DotNet Order</title>
			</head>
			<body>
				<ul>
					<xsl:for-each select="OrderService">
            <br>
						<li>
							<xsl:value-of select="ordernum" />
						</li>
            <li>
              <xsl:value-of select="goodname" />
            </li>
            <li>
              <xsl:value-of select="customername" />
            </li>
            <li>
              <xsl:value-of select="ordervalue" />
            </li>
            <li>
              <xsl:value-of select="customerphone" />
            </li>
            </br>
					</xsl:for-each>
				</ul>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
