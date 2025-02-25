using System.Diagnostics;

namespace NVM_GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new GUI());
        }

        /**
          * Show a message from nvm
          * @param output Message to show
          */
        public static void ShowCustomMessage(string output)
        {
            if (output.Contains("error", StringComparison.CurrentCultureIgnoreCase))
            {
                MessageBox.Show(output, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(output, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /**
          * Run a command in the terminal
          * @param command Command to run
          * @return string Output of the command
          */
        public static string RunCommand(string command, bool showMessage = true)
        {
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = new() { StartInfo = psi };
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                {
                    if (showMessage)
                    {
                        MessageBox.Show("Error:\n" + error);
                    }

                    return string.Empty;
                }

                return output;
            }
            catch (Exception ex)
            {
                if (showMessage)
                { 
                    MessageBox.Show("Error:\n" + ex.Message);
                }

                return string.Empty;
            }
        }
    }
}