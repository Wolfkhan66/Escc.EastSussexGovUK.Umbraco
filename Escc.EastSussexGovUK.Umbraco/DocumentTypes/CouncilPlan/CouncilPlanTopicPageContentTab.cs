﻿using Escc.EastSussexGovUK.Umbraco.DocumentTypes.Features;
using Escc.Umbraco.PropertyEditors;
using Umbraco.Inception.Attributes;
using Umbraco.Inception.BL;

namespace Escc.EastSussexGovUK.Umbraco.DocumentTypes.CouncilPlan
{
    public class CouncilPlanTopicPageContentTab : TabBase
    {
        [UmbracoProperty("Page Title", "phDefTitle", BuiltInUmbracoDataTypes.Textbox, mandatory: true, sortOrder: 1)]
        public string PhDefTitle { get; set; }

        [UmbracoProperty("Priority", "phDefPriorityClass", BuiltInUmbracoDataTypes.DropDown, PriorityDataType.DataTypeName, sortOrder: 2)]
        public string PhDefPriorityClass { get; set; }

        [UmbracoProperty("Priority Title", "phDefPriorityTitle", BuiltInUmbracoDataTypes.Textbox, sortOrder: 3)]
        public string PhDefPriorityTitle { get; set; }

        [UmbracoProperty("Content", "phDefContent01", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 4)]
        public string PhDefContent01 { get; set; }

        [UmbracoProperty("Additional Image 1", "phDefImage09", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 5, Description = "")]
        public string PhDefImage09 { get; set; }
        [UmbracoProperty("Additional Image 1 Caption", "phDefCaption09", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 6, Description = "")]
        public string phDefCaption09 { get; set; }
        [UmbracoProperty("Additional Content 1", "phDefContent04", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 7)]
        public string PhDefContent04 { get; set; }

        [UmbracoProperty("Additional Image 2", "phDefImage10", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 8, Description = "")]
        public string PhDefImage10 { get; set; }
        [UmbracoProperty("Additional Image 2 Caption", "phDefCaption10", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 9, Description = "")]
        public string phDefCaption10 { get; set; }
        [UmbracoProperty("Additional Content 2", "phDefContent05", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 10)]
        public string PhDefContent05 { get; set; }

        [UmbracoProperty("Additional Image 3", "phDefImage11", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 11, Description = "")]
        public string PhDefImage11 { get; set; }
        [UmbracoProperty("Additional Image 3 Caption", "phDefCaption11", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 12, Description = "")]
        public string phDefCaption11 { get; set; }
        [UmbracoProperty("Additional Content 3", "phDefContent06", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 13)]
        public string PhDefContent06 { get; set; }

        [UmbracoProperty("Additional Image 4", "phDefImage12", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 14, Description = "")]
        public string PhDefImage12 { get; set; }
        [UmbracoProperty("Additional Image 4 Caption", "phDefCaption12", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 15, Description = "")]
        public string phDefCaption12 { get; set; }
        [UmbracoProperty("Additional Content 4", "phDefContent07", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 16)]
        public string PhDefContent07 { get; set; }

        [UmbracoProperty("Additional Image 5", "phDefImage13", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 17, Description = "")]
        public string PhDefImage13 { get; set; }
        [UmbracoProperty("Additional Image 5 Caption", "phDefCaption13", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 18, Description = "")]
        public string phDefCaption13 { get; set; }
        [UmbracoProperty("Additional Content 5", "phDefContent08", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 19)]
        public string PhDefContent08 { get; set; }

        [UmbracoProperty("Additional Image 6", "phDefImage14", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 20, Description = "")]
        public string PhDefImage14 { get; set; }
        [UmbracoProperty("Additional Image 6 Caption", "phDefCaption14", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 21, Description = "")]
        public string phDefCaption14 { get; set; }
        [UmbracoProperty("Additional Content 6", "phDefContent09", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 22)]
        public string PhDefContent09 { get; set; }

        [UmbracoProperty("Additional Image 7", "phDefImage15", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 23, Description = "")]
        public string PhDefImage15 { get; set; }
        [UmbracoProperty("Additional Image 7 Caption", "phDefCaption15", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 24, Description = "")]
        public string phDefCaption15 { get; set; }
        [UmbracoProperty("Additional Content 7", "phDefContent10", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 25)]
        public string PhDefContent10 { get; set; }

        [UmbracoProperty("Leader Image", "phDefImage01", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 26, Description = "")]
        public string PhDefImage01 { get; set; }
        [UmbracoProperty("Leader", "phDefLeaderName", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 27)]
        public string PhDefLeaderName { get; set; }

        [UmbracoProperty("Chief Exec Image", "phDefImage02", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 28, Description = "")]
        public string PhDefImage02 { get; set; }
        [UmbracoProperty("Chief Executive", "phDefChiefExecName", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 29)]
        public string PhDefChiefExecName { get; set; }

        [UmbracoProperty("Aims", "phDefContent02", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 30, Description = "Boxed content, eg for aims of a Council Plan priority")]
        public string PhDefContent02 { get; set; }

        [UmbracoProperty("Second Column text", "phDefContent03", PropertyEditorAliases.RichTextPropertyEditor, RichTextEsccWithFormattingDataType.DataTypeName, sortOrder: 31, Description = "Text and logos for second column. If not used, the page will adapt to a single column layout.")]
        public string PhDefContent03 { get; set; }
        [UmbracoProperty("Logo 1", "phDefImage03", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 32, Description = "")]
        public string PhDefImage03 { get; set; }
        [UmbracoProperty("Logo 2", "phDefImage04", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 33, Description = "")]
        public string PhDefImage04 { get; set; }

        [UmbracoProperty("Image 1", "phDefImage05", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 34, Description = "Row of photos to appear at the foot of the page content")]
        public string PhDefImage05 { get; set; }
        [UmbracoProperty("Image 1 Caption", "phDefCaption05", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 35, Description = "")]
        public string phDefCaption05 { get; set; }

        [UmbracoProperty("Image 2", "phDefImage06", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 36, Description = "")]
        public string PhDefImage06 { get; set; }
        [UmbracoProperty("Image 2 Caption", "phDefCaption06", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 37, Description = "")]
        public string phDefCaption06 { get; set; }

        [UmbracoProperty("Image 3", "phDefImage07", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 38, Description = "")]
        public string PhDefImage07 { get; set; }
        [UmbracoProperty("Image 3 Caption", "phDefCaption07", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 39, Description = "")]
        public string phDefCaption07 { get; set; }

        [UmbracoProperty("Image 4", "phDefImage08", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 40, Description = "")]
        public string PhDefImage08 { get; set; }
        [UmbracoProperty("Image 4 Caption", "phDefCaption08", BuiltInUmbracoDataTypes.TextboxMultiple, SortOrder = 41, Description = "")]
        public string phDefCaption08 { get; set; }

        [UmbracoProperty("Related pages", "phDefRelatedPages", PropertyEditorAliases.RichTextPropertyEditor, RichTextLinksListDataType.DataTypeName, sortOrder: 42)]
        public string PhDefRelatedPages { get; set; }

        [UmbracoProperty("Related websites", "phDefRelatedSites", PropertyEditorAliases.RichTextPropertyEditor, RichTextLinksListDataType.DataTypeName, sortOrder: 43)]
        public string PhDefRelatedSites { get; set; }
    }
}