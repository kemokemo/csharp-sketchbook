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

TargetType tt;
try
{
    tt = d.Deserialize<TargetType>(yml);
}
catch (System.Exception e)
{
    Console.WriteLine($"failed to deserialize yaml, {e.Message}");
    return;
}

Console.WriteLine($"Name: {tt.Name}, Class: {tt.Class}");
