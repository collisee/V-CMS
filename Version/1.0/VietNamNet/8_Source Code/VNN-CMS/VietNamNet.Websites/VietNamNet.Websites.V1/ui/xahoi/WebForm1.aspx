


<div class="box-ttol ">
    <div class="ttol-title">
        <a target="_blank" href="http://tintuconline.vietnamnet.vn">
            <img alt="#" height="25" width="135" src="/common/v5/image/blank.gif" />
        </a>
    </div>
    
    <div class="ttol-text">
    
     <xsl:for-each select="ROW">
          <xsl:if test="position() = 1">
            <xsl:choose>
              <xsl:when test="CATE_TYPE = 100">              
                    <div class="cat_box1">
                        <a class="left vien2 boder-img" href="{PAGE_URL}">
                            <img height="64" width="116" src="/dataimages/{IMAGE_CREATE_DATE}/original/{IMAGE_FILE_NAME}" />
                        </a>
                    </div>        
                    <a class="avata" href="{PAGE_URL}"><xsl:value-of select="TITLE" /></a>
                    <div class="clear">,</div>              
              </xsl:when>
            </xsl:choose>
          </xsl:if>
     </xsl:for-each>    
    
        
    <xsl:for-each select="ROW">
          <xsl:if test="position() > 1">
            <xsl:choose>
              <xsl:when test="CATE_TYPE = 100">                               
                     <div class="ttol-item">
                        <a class="ttol-img2 " href="#">
                            <img alt="{PAGE_URL}" height="34" width="62" class="boder-img" src="/dataimages/{IMAGE_CREATE_DATE}/original/{IMAGE_FILE_NAME}">
                        </a>
                        <a class="ttol-link" href="#"><xsl:value-of select="LEAD" /></a>
                    </div>                        
              </xsl:when>
            </xsl:choose>
          </xsl:if>
     </xsl:for-each>     
        
        
        
    </div>
</div>
