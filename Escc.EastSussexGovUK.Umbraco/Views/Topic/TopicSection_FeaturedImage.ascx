﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicSection_FeaturedImage.ascx.cs" Inherits="Escc.EastSussexGovUK.Umbraco.Views.Topic.TopicSection_FeaturedImage" %>

<div id="image1" runat="server" class="topicImageNoWrap"><div><div><div><div><div><div><div>
    <CmsPlaceholders:XhtmlImagePlaceholderControl id="phImage1" runat="server" />
</div></div></div></div></div></div></div><CmsPlaceholders:TextPlaceholderControl ID="caption1" runat="server" CssClass="caption" /></div>
<div id="image2" runat="server" class="topicImageNoWrap"><div><div><div><div><div><div><div>
    <CmsPlaceholders:XhtmlImagePlaceholderControl id="phImage2" runat="server" />
</div></div></div></div></div></div></div><CmsPlaceholders:TextPlaceholderControl ID="caption2" runat="server" CssClass="caption" /></div>
<div id="image3" runat="server" class="topicImageNoWrap"><div><div><div><div><div><div><div>
    <CmsPlaceholders:XhtmlImagePlaceholderControl id="phImage3" runat="server" />
</div></div></div></div></div></div></div><CmsPlaceholders:TextPlaceholderControl ID="caption3" runat="server" CssClass="caption" /></div>

<CmsPlaceholders:RichHtmlPlaceholderControl id="subtitle" runat="server" editcontrolheight="30" Paragraphs="false" ElementName="h2" RenderContainerElement="true" />
<CmsPlaceholders:RichHtmlPlaceholderControl id="content" runat="server" editcontrolheight="300" />