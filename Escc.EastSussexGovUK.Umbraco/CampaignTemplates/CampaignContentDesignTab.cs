﻿using Umbraco.Inception.Attributes;
using Umbraco.Inception.BL;

namespace Escc.EastSussexGovUK.Umbraco.CampaignTemplates
{
    /// <summary>
    /// Design tab for the campaign content document type
    /// </summary>
    public class CampaignContentDesignTab : TabBase
    {
        [UmbracoProperty("Banner image (small screens)", "BannerImageSmall", BuiltInUmbracoDataTypes.MediaPicker, sortOrder:1,
            Description="Banner image at the top of the page on small screens such as mobiles and tablets. 75px high, and tiles horizontally up to 802px wide.")]
        public string BannerImageSmall { get; set; }

        [UmbracoProperty("Banner image (large screens)", "BannerImageLarge", BuiltInUmbracoDataTypes.MediaPicker, sortOrder: 2,
            Description = "Banner image at the top of the page on large screens like laptops. 290px high, and tiles horizontally.")]
        public string BannerImageLarge { get; set; }

        [UmbracoProperty("Upper/lower pull quote: text colour", "PullQuoteTextColour", ColourPickerDataType.PropertyEditor, ColourPickerDataType.DataTypeName, sortOrder: 3,
            Description = "The default is white. Text must contrast with its background to meet legal accessibility standards. Check at http://tinyurl.com/wcag-contrast")]
        public string PullQuoteTextColour { get; set; }

        [UmbracoProperty("Upper/lower pull quote: background colour", "PullQuoteBackground", ColourPickerDataType.PropertyEditor, ColourPickerDataType.DataTypeName, sortOrder: 4,
            Description = "The default is blue. Text must contrast with its background to meet legal accessibility standards. Check at http://tinyurl.com/wcag-contrast")]
        public string PullQuoteBackground { get; set; }

        [UmbracoProperty("Upper/lower pull quote: quotation marks colour", "PullQuoteMarks", ColourPickerDataType.PropertyEditor, ColourPickerDataType.DataTypeName, sortOrder: 5,
            Description = "The default is green. Text must contrast with its background to meet legal accessibility standards. Check at http://tinyurl.com/wcag-contrast")]
        public string PullQuoteQuotations { get; set; }

        [UmbracoProperty("Central pull quote: text colour", "CentralQuoteTextColour", ColourPickerDataType.PropertyEditor, ColourPickerDataType.DataTypeName, sortOrder: 6,
            Description = "The default is white. Text must contrast with its background to meet legal accessibility standards. Check at http://tinyurl.com/wcag-contrast")]
        public string CentralQuoteTextColour { get; set; }

        [UmbracoProperty("Central pull quote: background colour", "CentralQuoteBackground", ColourPickerDataType.PropertyEditor, ColourPickerDataType.DataTypeName, sortOrder: 7,
            Description= "The default is green. Text must contrast with its background to meet legal accessibility standards. Check at http://tinyurl.com/wcag-contrast")]
        public string CentralQuoteBackground { get; set; }

        [UmbracoProperty("Central pull quote image is a cutout of a person", "CentralQuoteImageIsCutout", BuiltInUmbracoDataTypes.Boolean, sortOrder: 8,
Description = "This will add a line below the image which shows up if the quote is taller than the image.")]
        public string CentralQuoteImageIsCutout { get; set; }

        [UmbracoProperty("Final pull quote: text colour", "FinalQuoteColour", ColourPickerDataType.PropertyEditor, ColourPickerDataType.DataTypeName, sortOrder: 9,
            Description = "Must contrast with a white background to meet legal accessibility standards. Check at http://tinyurl.com/wcag-contrast")]
        public string FinalQuoteColour { get; set; }

        [UmbracoProperty("Quotes: font family", "QuoteFontFamily", BuiltInUmbracoDataTypes.Textbox, sortOrder: 10,
            Description = "Select a font family from https://fonts.google.com and paste the name of the embedded version, eg 'Cormorant+Garamond:400,400i'")]
        public string QuoteFontFamily { get; set; }

        [UmbracoProperty("Quotes: use bold text", "QuotesInBold", BuiltInUmbracoDataTypes.Boolean, sortOrder: 11,
            Description="Make sure you select a typeset bold style in Google Fonts if you want to avoid a browser-generated version.")]
        public string QuotesInBold { get; set; }

        [UmbracoProperty("Quotes: use italic text", "QuotesInItalic", BuiltInUmbracoDataTypes.Boolean, sortOrder: 12,
            Description = "Make sure you select a typeset italic style in Google Fonts if you want to avoid a browser-generated version.")]
        public string QuotesInItalic { get; set; }

        [UmbracoProperty("Custom CSS (small screens)", "CssSmall", BuiltInUmbracoDataTypes.TextboxMultiple, sortOrder: 13,
             Description = "Custom CSS to apply to small screens such as mobiles. This will still apply at larger sizes but may be overridden by the CSS for medium and large screens.")]
        public string CssSmall { get; set; }

        [UmbracoProperty("Custom CSS (medium screens)", "CssMedium", BuiltInUmbracoDataTypes.TextboxMultiple, sortOrder: 14,
             Description = "Custom CSS to apply to medium screens such as tablets. This will still apply at larger sizes but may be overridden by the CSS for large screens.")]
        public string CssMedium { get; set; }

        [UmbracoProperty("Custom CSS (large screens)", "CssLarge", BuiltInUmbracoDataTypes.TextboxMultiple, sortOrder: 15,
        Description = "Custom CSS to apply to large screens such as laptops. This is added to and can override the CSS for small and medium screens.")]
        public string CssLarge { get; set; }

        [UmbracoProperty("Video width", "VideoWidth", BuiltInUmbracoDataTypes.Textbox, sortOrder: 16, ValidationRegularExpression = "^(|[0-9]{1,4})$",
    Description = "Change the default width of videos on this page")]
        public string VideoWidth { get; set; }

        [UmbracoProperty("Video height", "VideoHeight", BuiltInUmbracoDataTypes.Textbox, sortOrder: 17, ValidationRegularExpression = "^(|[0-9]{1,4})$",
    Description = "Change the default height of videos on this page.")]
        public string VideoHeight { get; set; }
    }
}