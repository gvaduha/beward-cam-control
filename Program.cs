using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace gvaduha.beward
{
    class Program
    {
        enum CamType
        {
            SV,
            BD
        }

        static async Task<int> Main(string[] args)
        {
            var cla = new CommandLineApplication(throwOnUnexpectedArg: false);
            var cmdlist = cla.Option("-l | --list", "list of available commands", CommandOptionType.NoValue);
            var cmdscheme = cla.Option("-s | --scheme", "uri scheme (http|https)", CommandOptionType.SingleValue);
            var cmdhost = cla.Option("-h | --host", "camera host name", CommandOptionType.SingleValue);
            var cmdport = cla.Option("-n | --port", "camera port, default 80", CommandOptionType.SingleValue);
            var cmduser = cla.Option("-u | --user", "authentication user name", CommandOptionType.SingleValue);
            var cmdpassword = cla.Option("-p | --password", "authentication user password", CommandOptionType.SingleValue);
            var cmdcamtype = cla.Option("-t | --camtype", "SV|BD (SV only supported)", CommandOptionType.SingleValue);
            var cmdcommand = cla.Option("-c | --command", "cam command, see -l", CommandOptionType.SingleValue);
            var cmdset = cla.Option("-S | --set", "use for set value with command", CommandOptionType.NoValue);
            //var cmddata = cla.Option("--", "data for set command", CommandOptionType.MultipleValue);

            SVseriesCam cam;
            bool setCommand;
            SVseriesCam.CamCommand command;

            try
            {
                cla.Execute(args);

                if (cmdlist.HasValue())
                {
                    Console.WriteLine($"SV series commands: {Environment.NewLine}" +
                        string.Join(Environment.NewLine, Enum.GetNames(typeof(SVseriesCam.CamCommand))));
                    return 0;
                }

                var scheme = cmdscheme.HasValue() ? cmdscheme.Value() : "http";
                var host = cmdhost.Value();
                var port = cmdport.HasValue() ? Convert.ToInt32(cmdport.Value()) : 80;
                var user = cmduser.HasValue() ? cmduser.Value() : null;
                var password = cmdpassword.HasValue() ? cmdpassword.Value() : null;
                var camtype = cmdcamtype.Value().ToUpper();
                command = (SVseriesCam.CamCommand)Enum.Parse(typeof(SVseriesCam.CamCommand), cmdcommand.Value());
                setCommand = cmdset.HasValue();

                cam = new SVseriesCam(new UriBuilder(scheme, host, port).Uri, user, password);
            }
            catch (Exception)
            {
                cla.ShowHelp();
                var module = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
                Console.WriteLine(
                    "Examples:{Environment.NewLine}" +
                    $"{module} -l{Environment.NewLine}" +
                    $"{module} -h svcam1 -t SV -c VideoGeneral{Environment.NewLine}" +
                    $"{module} -h svcam1 -t SV -c VideoGeneral -d set -- [VIDEO_GENERAL]..."
                    );
                return -1;
            }

            if (setCommand)
            {
                string line;
                var data = new List<string>();
                using var stdin = new StreamReader(Console.OpenStandardInput());
                while ((line = stdin.ReadLine()) != null)
                {
                    //ignore [XXX] headers, ; comments and empty lines
                    var rgx = new Regex(@"^\s*\[[ 0-9a-zA-Z_\-\.]+\]\s*$|^;.*$|^\s*$");
                    if (!rgx.IsMatch(line))
                        data.Add(line);
                }
                Console.WriteLine(await cam.SetSectionAsync(command, data.ToArray()));
            }
            else
                Console.WriteLine(await cam.GetSectionAsync(command));

            return 0;
        }
    }
}
