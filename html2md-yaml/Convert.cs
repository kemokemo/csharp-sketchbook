using HtmlAgilityPack;

namespace html2md_yml;

class HtmlConverter
{
	private Dictionary<TargetType, string> mdMap;
	private string innerHtml = "{innerHtml}";

	public HtmlConverter() {
		mdMap = new Dictionary<TargetType, string>();
	}

	public HtmlConverter(ConversionCondition[] cca) {
		mdMap = new Dictionary<TargetType, string>();
    foreach( var cc in cca ){
      mdMap.Add(cc.In, cc.Out);
    }
  }

	public string Convert(HtmlNode node)
	{
    foreach ( var item in mdMap ){
      if(TargetTypeChecker.IsTarget(item.Key, node)){
        return convertWithConditions(node, item.Value);
      } 
    }

    return node.OuterHtml;
	}

  private string convertWithConditions(HtmlNode node, string format){
		var content = format;
		content = content.Replace(innerHtml, node.InnerHtml);
		return content;
  }
}
