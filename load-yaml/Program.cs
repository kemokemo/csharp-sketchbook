using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using load_yaml;

var yml = @"
name: div
class: header1
";

var d = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

var p = d.Deserialize<TargetType>(yml);
Console.WriteLine($"Name: {p.Name}, Class: {p.Class}");

