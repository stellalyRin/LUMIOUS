// Reflectee 由 星澜音 隶属于 Project Hazelita | Reflectee by stellalyRin in Project Hazelita

// Reflectee 是 星澜音 严格意义上的第一个 C# 作品，因此很多地方都欠缺打磨，仍望各位朋友海涵（；´д｀）ゞ
// 这是一个非常简单的小程序，它允许用户一站式创建自己的 GitHub Profile README 文件，省去自行搜索 badges 或其他工具的麻烦。

// Reflectee is stellalyRin's VERY FIRST C# project, therefore it may be not that well-written ψ(._. )>
// It is a very simple program that fetches user's information and then creates a very stylish GitHub Profile README file.

using System;
using System.IO;

class Reflectee
{
    static void Main(string[] args)
    {
        Console.Write("请输入 README.md 文件的所在目录路径，例如 \"C:\\Users\\Username\\Desktop\"：");
        string? directoryPath = Console.ReadLine();

        Console.Write("请输入你的昵称：");
        string? username = Console.ReadLine();
        
        Console.Write("请输入你的 slogan：");
        string? slogan = Console.ReadLine();

        Console.Write("请输入你的简短介绍");
        string? briefIntro = Console.ReadLine();

        Console.Write("请输入你的世界观");
        string? worldview = Console.ReadLine();

        Console.Write("请输入你的设备列表（用逗号分隔）：");
        string? devicesInput = Console.ReadLine();
        List<string> devices = devicesInput?.Split(',').Select(d => d.Trim()).ToList() ?? new List<string>();
        var devicesItems = devices.Select(d => $"- {d}").ToList();
        string devicesSection = string.Join("\n", devicesItems);

        Console.Write("请输入你的 IDE 列表（用逗号分隔）：");
        string? idesInput = Console.ReadLine();
        List<string> ides = idesInput?.Split(',').Select(i => i.Trim()).ToList() ?? new List<string>();
        var idesItems = ides.Select(i => $"- {i}").ToList();
        string idesSection = string.Join("\n", idesItems);

        Console.Write("请输入你的朋友列表（用逗号分隔）：");
        string? friendsInput = Console.ReadLine();
        List<string> friends = friendsInput?.Split(',').Select(f => f.Trim()).ToList() ?? new List<string>();
        var friendsItems = friends.Select(f => $"- {f}").ToList();
        string friendsSection = string.Join("\n", friendsItems);

        Console.Write("请输入你的赞助者列表（用逗号分隔）：");
        string? sponsorsInput = Console.ReadLine();
        List<string> sponsors = sponsorsInput?.Split(',').Select(s => s.Trim()).ToList() ?? new List<string>();
        var sponsorsItems = sponsors.Select(s => $"- {s}").ToList();
        string sponsorsSection = string.Join("\n", sponsorsItems);

        try
        {
            Directory.CreateDirectory(directoryPath);
            string filePath = Path.Combine(directoryPath, "README.md");
            string introduction = $"<div align=\"center\">\n\n> {slogan}\n\n# {username}\n\n</div>\n\n" +
                                  $"# 简短介绍\n\n{briefIntro}\n\n" +
                                  $"# 世界观\n\n{worldview}\n\n" +
                                  $"# 设备列表\n\n{devicesSection}\n\n" +
                                  $"# IDE 列表\n\n{idesSection}\n\n" +
                                  $"# 朋友列表\n\n{friendsSection}\n\n" +
                                  $"# 赞助者列表\n\n{sponsorsSection}\n";
            File.WriteAllText(filePath, introduction);
            Console.WriteLine($"已写入文件 {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"写入文件时发生错误：{ex.Message}");
        }

    }
}