// See https://aka.ms/new-console-template for more information

using libnftables;

Console.WriteLine("Hello, World!");
var nftables = new Nftables();
nftables.JsonOutput = true;
Console.WriteLine("Created nftables instance");
var result = nftables.RunCommand("list ruleset");
Console.WriteLine("Ran command");
Console.WriteLine(result.Output);
Console.WriteLine(result.Error);