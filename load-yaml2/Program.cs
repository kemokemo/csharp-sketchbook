using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using load_yaml2;

var yml = @"
- in:
    name: h1
    class: 
  out: '# {innerHtml}{newLine}'
- in:
    name: div
    class: header1
  out: '# {innerHtml}{newLine}'
";

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

foreach( var cc in cca ){
  Console.WriteLine($"In: Name: {cc.In.Name}, Class: {cc.In.Class}");
  Console.WriteLine($"Out: {cc.Out}");
}

