using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TandT.TagHelpers
{
	[HtmlTargetElement("hello", Attributes = "hello-text")]
	public class HelloTagHelper : TagHelper
	{
		public string HelloText { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			output.PreContent.SetHtmlContent(@"<div>");
			output.Content.SetHtmlContent($"Hello {HelloText}");
			output.PostContent.SetHtmlContent("</div>");
			output.Attributes.Clear();
		}
	}
}
