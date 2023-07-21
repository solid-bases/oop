namespace Bricklayer.WallGenerators;

internal class WallGeneratorFactory
{

    public static IWallGenerator NewGenerator(RowBricks[] wall)
    {
        var input = "\0";
        do {
            Console.Write(Environment.NewLine);
            if (input != "\0") {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Not valid input, please type C or H.");
                Console.ResetColor();
            }
            Console.Write("Do you want an HTML (H) or a Console (C) output? (C/H): ");
            input = Console.ReadLine();
        } while (String.IsNullOrWhiteSpace(input) || (input.ToLower() != "h" && input.ToLower() != "c"));

        if (input.ToLower() == "c")
        {
            return new ConsoleWallGenerator(wall);
        }
        return new HtmlWallGenerator(wall);
    }
}