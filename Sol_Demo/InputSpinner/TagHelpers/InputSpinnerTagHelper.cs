using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace InputSpinner.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("jquery-input-spinner")]
    public class InputSpinnerTagHelper : TagHelper
    {
        private readonly IHtmlHelper htmlHelper = null;

        private const String IdAttributeName = "id";
        private const String ClassAttributeName = "class";
        private const String ForAttributeName = "asp-for";
        private const String MinAttributeName = "min";
        private const String MaxAttributeName = "max";
        private const String StepAttributeName = "step";
        private const String DecimalsAttributeName = "decimals";
        private const String SuffixAttributeName = "suffix";
        private const String PrefixAttributeName = "prefix";
        private const String InputEventAttributeName = "input-js-event";
        private const String ChangeEventAttributeName = "change-js-event";
        private const String BorderColorAttributeName = "border-color";

        public InputSpinnerTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        [HtmlAttributeName(IdAttributeName)]
        public String Id { get; set; }

        [HtmlAttributeName(ClassAttributeName)]
        public String Class { get; set; }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(MinAttributeName)]
        public int Min { get; set; }

        [HtmlAttributeName(MaxAttributeName)]
        public int Max { get; set; }

        [HtmlAttributeName(StepAttributeName)]
        public double Step { get; set; }

        [HtmlAttributeName(DecimalsAttributeName)]
        public int Decimals { get; set; }

        [HtmlAttributeName(SuffixAttributeName)]
        public String Suffix { get; set; }

        [HtmlAttributeName(PrefixAttributeName)]
        public String Prefix { get; set; }

        [HtmlAttributeName(InputEventAttributeName)]
        public String InputEvent { get; set; }

        [HtmlAttributeName(ChangeEventAttributeName)]
        public String ChangeEvent { get; set; }

        [HtmlAttributeName(BorderColorAttributeName)]
        public String BorderColor { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var content = await htmlHelper?.PartialAsync("~/TagHelpers/_InputSpinnerPartialView.cshtml", this);

            output.Content.SetHtmlContent(content);
        }
    }
}