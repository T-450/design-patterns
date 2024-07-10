using System.Runtime.InteropServices;
using System.Text;

namespace CreationalDesignPatterns.FactoryMethod
{
    /// <summary>
    /// Concrete Factory object.
    /// Represents an audio player for Windows systems.
    /// </summary>
    internal class WindowsPlayer:Player
    {
        /// <summary>
        /// Plays the audio file with the specified file name on Windows systems.
        /// </summary>
        /// <param name="fileName">The name of the audio file to play.</param>
        /// <returns>A task that represents the asynchronous play operation.</returns>
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string command,StringBuilder stringReturn,int returnLength,IntPtr hwndCallback);
        public override Task Play(string fileName)
        {
            var sb = new StringBuilder();
            var result = mciSendString($"Play {fileName}", sb ,1024*1024,IntPtr.Zero);
            Console.WriteLine(result);
            return Task.CompletedTask;
        }
    }
}
