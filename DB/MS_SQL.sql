USE [CMS]
GO
/****** Object:  User [cms_website]    Script Date: 9/9/2014 2:44:43 PM ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'cms_website')
CREATE USER [cms_website] FOR LOGIN [cms_website] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  StoredProcedure [dbo].[page_delete]    Script Date: 9/9/2014 2:44:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[page_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Derek Dunnom>
-- Create date: <3/16/2014>
-- Description:	<delete a page>
-- =============================================
CREATE PROCEDURE [dbo].[page_delete]
	@PageId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM pages WHERE PageId = @PageId;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[page_insert]    Script Date: 9/9/2014 2:44:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[page_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Derek Dunnom>
-- Create date: <3/16/2014>
-- Description:	<add a page to CMS>
-- =============================================
CREATE PROCEDURE [dbo].[page_insert]
	@ContentKey varchar(100),
	@Title varchar(1000) = null,
	@PageContent text = null,
	@HeadContent text = null,
	@ScriptBlock text = null
AS
BEGIN
	SET NOCOUNT ON;
		INSERT INTO pages (ContentKey, Title, PageContent, HeadContent, ScriptBlock, DateModified)
	VALUES (@ContentKey, @Title, @PageContent, @HeadContent, @ScriptBlock, GetDate());
	SELECT CAST(SCOPE_IDENTITY() as Int)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[page_select]    Script Date: 9/9/2014 2:44:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[page_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Derek Dunnom>
-- Create date: <3/16/2014>
-- Description:	<select a page>
-- =============================================
CREATE PROCEDURE [dbo].[page_select]
AS
BEGIN
	SELECT PageId, ContentKey, Title, PageContent, HeadContent, ScriptBlock, MetaContent, PrimaryMenu, AuxMenu, DateModified
	FROM pages
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[page_update]    Script Date: 9/9/2014 2:44:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[page_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Derek Dunnom>
-- Create date: <3/16/2014>
-- Description:	<update a page>
-- =============================================
CREATE PROCEDURE [dbo].[page_update]
	@PageId int,
	@ContentKey varchar(100),
	@Title varchar(1000) = null,
	@PageContent text = null,
	@HeadContent text = null,
	@ScriptBlock text = null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE pages SET ContentKey = @ContentKey, Title = @Title, PageContent = @PageContent, HeadContent = @HeadContent, ScriptBlock = @ScriptBlock, DateModified = GetDate()
	WHERE pageId = @pageId;
END
' 
END
GO
/****** Object:  Table [dbo].[Pages]    Script Date: 9/9/2014 2:44:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Pages](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[ContentKey] [varchar](100) NOT NULL,
	[Title] [varchar](1000) NULL,
	[PageContent] [text] NULL,
	[HeadContent] [text] NULL,
	[ScriptBlock] [text] NULL,
	[MetaContent] [text] NULL,
	[PrimaryMenu] [varchar](1000) NULL,
	[AuxMenu] [varchar](1000) NULL,
	[DateModified] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Pages] ON 

GO
INSERT [dbo].[Pages] ([PageId], [ContentKey], [Title], [PageContent], [HeadContent], [ScriptBlock], [MetaContent], [PrimaryMenu], [AuxMenu], [DateModified]) VALUES (3, N'Careers', N'CMS_Company Careers', N'<img class="right margins" src="Content/images/careers3.gif" width="200" height="200" alt="Careers" title="Careers" />
        <div class="Column1 width5 floatright">
            <h3 title="Further your career by becoming a CMS_Company">Further your career by becoming a CMS pro</h3>
            <p>CMS_Company is rapidly growing nationwide in ways that are making an important difference in the commercial blankety blank industry. We offer a stimulating workplace based on open collaboration, personal development and future opportunity</p>
            <p>Our continued success thrives on the attraction and retention of spirited people who share our passion for service. CMS_Company is driven by a unique company culture that values knowledge, experience, and the importance of offering our customers an incomparable depth of product and application expertise.</p>
            <ul>
                <h4 class="benfits">Employee Benefits</h4>
                <li class="brands">CMS_Company is an equal opportunity employer</li>
                <li class="brands">Comprehensive rewards strategy</li>
                <li class="brands">Professional-development opportunities</li>
                <li class="brands">Medical, dental, vision, life and disability</li>
                <li class="brands">Health-care and dependent-care spending accounts</li>
                <li class="brands">401(k) accounts and incentive programs</li>
                <li class="brands">Available to associates and their spouses, domestic partners, dependents</li>
            </ul>
        </div>', NULL, NULL, NULL, NULL, NULL, CAST(0xB8380B00 AS Date))
GO
INSERT [dbo].[Pages] ([PageId], [ContentKey], [Title], [PageContent], [HeadContent], [ScriptBlock], [MetaContent], [PrimaryMenu], [AuxMenu], [DateModified]) VALUES (4, N'About', N'About CMS_Company', N'<h2>About Us</h2>
<p>A rich history with the promise of great things to come. When we started out in 1958 as a small retailer in Memphis, Tennessee, our goal was to be better than the next guy down the street or, even the next county over. It’s all about trust, relationships, parts on the shelf and reliable delivery&#8212;do the right things and you’ve earned a customer for life.</p>
<p>A lot has changed since 1958, but our know-how and passion for serving the needs of our customers hasn’t wavered. No &#8220;fancy&#8221; parts look-up database systems, just some of the best trained and experienced blankety blank professionals in the business&#8212;we’ll put our team up against the ones across the street, and all across the country.</p>
<p>Your business needs honest, reliable, diagnostics, repair or replace services. With over 80 service shops throughout the CMS_Company network, you’re just down the highway from getting the expert advice you need and the top mechanics that get the job done fast, economically, and right every time.</p>', NULL, NULL, NULL, NULL, NULL, CAST(0xCA380B00 AS Date))
GO
SET IDENTITY_INSERT [dbo].[Pages] OFF
GO
