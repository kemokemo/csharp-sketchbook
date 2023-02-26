using HtmlAgilityPack;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using html2md_yml;

var cd = Directory.GetCurrentDirectory();
var ymlPath = Path.Combine(cd, "sample.yml");

string yml;
try
{
   yml = File.ReadAllText(ymlPath);
}
catch (System.Exception e)
{
    Console.WriteLine($"failed to read yaml, {e.Message}");
    return;
}

var d = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

ConversionCondition[] cca;
try
{
    cca = d.Deserialize<ConversionCondition[]>(yml);
}
catch (System.Exception e)
{
    Console.WriteLine($"failed to deserialize yaml, {e.Message}");
    return;
}

var htmlDoc = new HtmlDocument();
htmlDoc.Load("sample.html");

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
var childNodes = htmlBody.ChildNodes;
	
var converter = new HtmlConverter(cca);
foreach (var node in childNodes)
{
    if (node.NodeType != HtmlNodeType.Element)
    {
        continue;
    }

    var content = converter.Convert(node);
    Console.WriteLine(content + Environment.NewLine);
}
