<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/ArrayOfOrder">
		<html>
			<head>
				<title>Orders</title>
			</head>
			<body>
				<ul>
					<xsl:for-each select="Order">
						<li>
							
							<xsl:value-of select="serialNo" />
							<xsl:value-of select="GoodsName" />
							<xsl:value-of select="Price"/>											<xsl:value-of select="Quantity"/>
						</li>		
						<li>
							<xsl:value-of select="Customer" />
						</li>
						<br/>
<li>
							<xsl:value-of select="CustPhone" />
						</li>
						<br/>
						<li>
							<xsl:value-of select="OrderNo" />
						</li>
						<br/>
					</xsl:for-each>
				</ul>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
