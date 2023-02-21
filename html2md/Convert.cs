using HtmlAgilityPack;

namespace html2md
{
	class HtmlConverter
	{
		private Dictionary<string, string> mdMap;
		private string innerHtml = "$innerHtml$";
		private string newLine = "$newLine$";

		public HtmlConverter() {
			mdMap = new Dictionary<string, string>();
			// TODO: WIP
			mdMap.Add("h1", $"# {innerHtml}{newLine}");
			mdMap.Add("h2", $"## {innerHtml}{newLine}");
			mdMap.Add("h3", $"### {innerHtml}{newLine}");
			mdMap.Add("h4", $"#### {innerHtml}{newLine}");
			mdMap.Add("h5", $"##### {innerHtml}{newLine}");
			mdMap.Add("h6", $"###### {innerHtml}{newLine}");
			mdMap.Add("h7", $"####### {innerHtml}{newLine}");
			mdMap.Add("h8", $"######## {innerHtml}{newLine}");
			mdMap.Add("h9", $"######### {innerHtml}{newLine}");
			mdMap.Add("h10", $"########## {innerHtml}{newLine}");
			mdMap.Add("br", $"{newLine}");
			mdMap.Add("p", $"{innerHtml}");
		}

		public string Convert(HtmlNode node)
		{
			if(!mdMap.ContainsKey(node.Name)){
				return node.OuterHtml;
			}

			var content = mdMap[node.Name];
			content = content.Replace(innerHtml, node.InnerHtml);
			content = content.Replace(newLine, Environment.NewLine);
			return content;
		}
	}
}