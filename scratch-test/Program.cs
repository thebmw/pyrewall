// See https://aka.ms/new-console-template for more information

using libnftables;

Console.WriteLine("Hello, World!");
var nftables = new Nftables();
Console.WriteLine("Created nftables instance");
var result = nftables.RunCommand("list tables");
Console.WriteLine("Ran command");
Console.WriteLine(result.Output);