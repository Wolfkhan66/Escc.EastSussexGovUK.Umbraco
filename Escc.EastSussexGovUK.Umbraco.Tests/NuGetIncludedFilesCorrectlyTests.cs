﻿using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using NUnit.Framework;

namespace Escc.EastSussexGovUK.Umbraco.Tests
{
    [TestFixture]
    public class NuGetIncludedFilesCorrectlyTests
    {
        // Escc.EastSussexGovUK.UmbracoViews project
        [TestCase(@"Views\_ViewStart.cshtml")]
        [TestCase(@"Views\Layouts\Desktop.cshtml")]

        // Escc.CustomerFocusTemplates.Website project
        [TestCase(@"App_Plugins\OpeningSoon\openingsoon.html")] 
        [TestCase(@"App_Plugins\OpeningSoon\scripts\jquery.timepicker.js")] 
        [TestCase(@"css\CustomerFocusTemplates\task-small.css")] 
        [TestCase(@"js\CustomerFocusTemplates\guide.js")]
        [TestCase(@"Views\Partials\_LocationIsOpen.cshtml")]
        [TestCase(@"Views\Location.cshtml")]

        // Escc.CampaignTemplates.Website project
        [TestCase(@"js\CampaignTemplates\campaign-landing.js")]
        [TestCase(@"css\CampaignTemplates\campaign-small.css")]
        [TestCase(@"Views\CampaignLanding.cshtml")]

        // Escc.Alerts.Website project
        [TestCase(@"Views\Alerts.cshtml")]
        [TestCase(@"images\HomePage\jobs.png")]

        // EScc.Schools.TermDates project
        [TestCase(@"Views\TermDates\QuickAnswer.ascx")]

        // Escc.Umbraco project
        [TestCase(@"App_Plugins\Escc.Umbraco.DataTypes.MediaUsage\mediausage.controller.js")]
        
        // Escc.Umbraco.MediaSync project
        [TestCase(@"Config\uMediaSync.config")]

        // Escc.Umbraco.PropertyEditors project
        [TestCase(@"App_Plugins\Escc.Umbraco.PropertyEditors.RichTextPropertyEditor\controller.js")]

        // Escc.Umbraco.MicrosoftCmsMigration project
        [TestCase(@"MicrosoftCmsMigration\UserControls\Latest.ascx")]

        // Escc.Registration.MarriageSkin project
        [TestCase(@"MarriageSkin\js\min\marriage-skin.js")]
        [TestCase(@"MarriageSkin\css\min\marriage-skin-small.css")]
        [TestCase(@"MarriageSkin\img\marriage-banner.jpg")]

        public void NuGetPackagesCorrectlyIncludedInProject(string filePathWhichShouldBeIncluded)
        {
            var commonParent = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
            var reader = new XPathDocument(Path.Combine(commonParent.FullName, @"escc.eastsussexgovuk.umbraco\escc.eastsussexgovuk.umbraco.csproj"));
            var nav = reader.CreateNavigator();
            nav.MoveToRoot();

            var namespaces = new XmlNamespaceManager(nav.NameTable);
            namespaces.AddNamespace("ms", "http://schemas.microsoft.com/developer/msbuild/2003");

            var node = nav.SelectSingleNode(@"/ms:Project/ms:ItemGroup/ms:Content[@Include='" + filePathWhichShouldBeIncluded + "']", namespaces);

            Assert.IsNotNull(node);
        }
    }
}
