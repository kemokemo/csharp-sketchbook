using HtmlAgilityPack;
using html2md;

var htmlDoc = new HtmlDocument();
htmlDoc.Load("sample.html");

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
var childNodes = htmlBody.ChildNodes;
		
foreach (var node in childNodes)
{
    if (node.NodeType != HtmlNodeType.Element)
    {
        continue;
    }

    var converter = new HtmlConverter();
    var content = converter.Convert(node);
    Console.WriteLine(content);
}
