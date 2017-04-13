<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Tyler State Reporting REST API Documentation</title>
        <meta charset="utf-8" />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
          <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        <style>
          .jumbotron {
          padding-left:50px;
          background-color: #40528f;
          color: #ffffff;
          }
          .path{
          padding:5px;
          color: #d74fef;
          font-weight:700;
          }
          .small-alert{
          padding:3px !important;
          margin-right: 5px;
          }
          .sum-div{
          padding:4px;
          font-size:1.2em;
          }
          .big{
          font-size:1.2em;
          padding-left:20px;
          }
          .space{
          padding-left:20px;
          }
          .panel-body{
          padding-top:5px !important;
          padding-bottom:5px !important;
          padding-left:15px;
          padding-right:15px;
          }
          .panel-heading{
          padding-top:3px !important;
          padding-bottom:3px !important;
          padding-left:15px;
          padding-right:15px;
          }
          h5{
          padding:2px !important;
          }
        </style>
      </head>
      <body>
        <div class="jumbotron container-fluid">
          <h3>Tyler Technologies State Reporting REST API</h3>
        </div>
        
        <div class="container">
          
          <div class="panel panel-default">
            <div class="panel-heading">
              <h4>
                Documentation for the Tyler Technologies State Reporting RESTful API.
              </h4>
            </div>
          </div>

          <xsl:for-each select="doc/members/member">
            <xsl:if test="method != ''">
            <div class="panel panel-default">
              <div class="panel-heading">
                <h5>
                  <b>
                    <xsl:value-of select="name"/>
                  </b>
                </h5>
              </div>
              <div class="panel-body">
                <div class="row" style="width:100%;font-size:,.8em;padding:5px">
                  <div class="path">
                    <span class="alert alert-info small-alert">
                      <strong>
                        <xsl:value-of select="method"/>
                      </strong>
                    </span>
                    <xsl:value-of select="path"/>
                  </div>
                  <div class="sum-div">
                    <xsl:value-of select="summary"/>
                  </div>
                  <div class="space">
                  <b>Parameters:</b>
                  <br/>
                  <xsl:for-each select="param">
                    <span class="big"><xsl:value-of select="."/></span>
                    <br/>
                  </xsl:for-each>
                  </div>
                  <div class="space">
                    <b>Returns:</b>
                    <br/>
                    <xsl:for-each select="returns">
                      <span class="big">
                        <xsl:value-of select="."/>
                      </span>
                      <br/>
                    </xsl:for-each>
                  </div>
                  
                </div>
              </div>
            </div>
           </xsl:if>
          </xsl:for-each>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>