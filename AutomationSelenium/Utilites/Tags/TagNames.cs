using System.ComponentModel;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.Tags
{
    public enum TagNames
    {
        [Description("textarea")]
        TextArea,

        [Description("input")]
        Input,

        [Description("a")]
        Link,

        [Description("span")]
        Span,

        [Description("iframe")]
        InlineFrame,

        [Description("div")]
        Div,

        [Description("img")]
        Image
    }
}
