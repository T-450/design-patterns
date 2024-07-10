using System.Diagnostics;

namespace CreationalDesignPatterns.FactoryMethod
{
    /// <summary>
    /// Concrete Factory object.
    /// Represents an audio player for Linux systems.
    /// </summary>
    internal class LinuxPlayer : Player
    {
        public override Task Play(string fileName)
        {
            Console.WriteLine("Playing audio via the following command:");
            Console.WriteLine($"mpg123 -q '{fileName}'");

            // Uncomment for testing on a real device
            // StartBashProcess($"mpg123 -q '{fileName}'");

            return Task.CompletedTask;
        }

        /// <summary>
        /// Starts a Bash process with the specified command.
        /// </summary>
        /// <param name="command">The command to execute in the Bash process.</param>
        private void StartBashProcess(string command)
        {
            var escapedArgs = command.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
        }
    }
}
