using HtmlAgilityPack;

var htmlDoc = new HtmlDocument();
htmlDoc.Load("sample.html");

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
var childNodes = htmlBody.ChildNodes;
		
foreach (var node in childNodes)
{
    if (node.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(node.OuterHtml);
    }
}
