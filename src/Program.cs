using System;
using System.IO;
using System.Diagnostics;

namespace GT_MP_Console
{
	class Program
	{
		internal static Process gtmp = new Process();

		static void Main(string[] args)
		{
			Console.CancelKeyPress += new ConsoleCancelEventHandler(ExitHandler);

			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GrandTheftMultiplayer.Server.exe");
			if (!File.Exists(path))
			{
				Console.WriteLine("Unable to find \"GrandTheftMultiplayer.Server.exe\" ");
				Console.ReadKey();
				Environment.Exit(01);
			}

			gtmp.StartInfo.FileName = "GrandTheftMultiplayer.Server.exe";
			gtmp.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
			gtmp.StartInfo.RedirectStandardOutput = true;
			gtmp.StartInfo.UseShellExecute = false;
			gtmp.OutputDataReceived += (sender, arg) => Console.WriteLine(arg.Data);
			gtmp.Start();
			gtmp.BeginOutputReadLine();
			gtmp.WaitForExit();
		}

		private static void ExitHandler(object sender, ConsoleCancelEventArgs e)
		{
			gtmp.WaitForExit();
		}
	}
}
