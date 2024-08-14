#r "nuget: Lestaly, 0.67.0"
#r "nuget: Kokuban, 0.2.0"
#nullable enable
using System.Threading;
using Kokuban;
using Lestaly;
using Lestaly.Cx;

await Paved.RunAsync(async () =>
{
    var composeFile = ThisSource.RelativeFile("./docker/docker-compose.yml");

    WriteLine(Chalk.Green["Customize Footnotes"]);
    WriteLine($"""
    The following must be added to the custom header in the BookStack configuration.
      {Chalk.Yellow["""<script src="https://cdnjs.cloudflare.com/ajax/libs/markdown-it-footnote/3.0.2/markdown-it-footnote.min.js"></script>"""]}
      {Chalk.Yellow["""<script src="/custom/md-it-footnote.js"></script>"""]}
    """);
    WriteLine();

    WriteLine(Chalk.Green["Restart containers."]);
    await "docker".args("compose", "--file", composeFile.FullName, "down", "--remove-orphans", "--volumes");
    await "docker".args("compose", "--file", composeFile.FullName, "up", "-d", "--wait").result().success();
    WriteLine();

    WriteLine("Container up completed.");
    var pubPort = await "docker".args("compose", "--file", composeFile.FullName, "port", "app", "80").silent().result().success().output();
    var portNum = pubPort.AsSpan().SkipToken(':').TryParseNumber<ushort>();
    var service = new Uri($"http://localhost:{portNum}");

    await CmdShell.ExecAsync(service.AbsoluteUri);
});
