using System;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using WindowsGSM.Functions;
using WindowsGSM.GameServer.Query;
using WindowsGSM.GameServer.Engine;
using System.IO;

namespace WindowsGSM.Plugins
{
    public class NotD : SteamCMDAgent
    {
        // - Plugin Details
        public Plugin Plugin = new Plugin
        {
            name = "WindowsGSM.NotD", // WindowsGSM.XXXX
            author = "Gimpy",
            description = "WindowsGSM plugin for supporting NotD Dedicated Server",
            version = "1.0",
            url = "https://github.com/tadavispmd040507/WindowsGSM.NotD", // Github repository link (Best practice)
            color = "#12ff12" // Color Hex
        };

        // - Settings properties for SteamCMD installer
        public override bool loginAnonymous => true;
        public override string AppId => "1420710"; // Game server appId Steam

        // - Standard Constructor and properties
        public NotD(ServerConfig serverData) : base(serverData) => base.serverData = serverData;


        // - Game server Fixed variables
        public override string StartPath => @"LF\Binaries\Win64\LFServer-Win64-Shipping.exe"; // Game server start path
        public string FullName = "Night of the Dead Dedicated Server"; // Game server FullName
        public bool AllowsEmbedConsole = true;  // Does this server support output redirect?
        public int PortIncrements = 1; // This tells WindowsGSM how many ports should skip after installation

        // TODO: Undisclosed method
        public object QueryMethod = new A2S(); // Query method should be use on current server type. Accepted value: null or new A2S() or new FIVEM() or new UT3()

        // - Game server default values
        public string Port = "7777"; // Default port
        public string QueryPort = "27015"; // Default query port. This is the port specified in the Server Manager in the client UI to establish a server connection.
        public string Defaultmap = "Default"; // Default map name
        public string Maxplayers = "16"; // Default maxplayers
        public string Additional = ""; // Additional server start parameter
        public string configFile = "ServerSettings.ini";


        // - Create a default cfg for the game server after installation
        public async void CreateServerCFG()
        {
            string iniPath = Functions.ServerPath.GetServersServerFiles(serverData.ServerID, @"LF\Saved\Config");

            if (!Directory.Exists(iniPath))
            {
                Directory.CreateDirectory(iniPath);
            }

        }
        
        // - Start server function, return its Process to WindowsGSM
        public async Task<Process> Start()
        {
            string sourcePath = Functions.ServerPath.GetServersServerFiles(serverData.ServerID);
            string destinationPath = Functions.ServerPath.GetServersServerFiles(serverData.ServerID, @"LF\Saved\Config");
            string serverINI = "ServerSettings.ini";

            if (File.Exists(Path.Combine(sourcePath, serverINI)))
            {
                try
                {
                    File.Copy(Path.Combine(sourcePath, serverINI), Path.Combine(destinationPath, serverINI), true);
                }
                catch (Exception ex)
                {
                    Error = $"Error: {ex.Message}";
                }
            }
            await Task.Delay(1000);

            string shipExePath = Functions.ServerPath.GetServersServerFiles(serverData.ServerID, StartPath);
            if (!File.Exists(shipExePath))
            {
                Error = $"{Path.GetFileName(shipExePath)} not found ({shipExePath})";
                return null;
            }

            var param = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(serverData.ServerName))
                param.Append($"?Name=\"\"\"{serverData.ServerName}\"\"\"");
            
            param.Append("?listen");

            param.Append(" -log");

            if (!string.IsNullOrWhiteSpace(serverData.ServerPort))
                param.Append($" -Port={serverData.ServerPort}");
            
            if (!string.IsNullOrWhiteSpace(serverData.ServerQueryPort))
                param.Append($" -QueryPort={serverData.ServerQueryPort}");

            param.Append(" -CRASHREPORTS");

            // Prepare Process
            var p = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = ServerPath.GetServersServerFiles(serverData.ServerID),
                    FileName = ServerPath.GetServersServerFiles(serverData.ServerID, StartPath),
                    Arguments = param.ToString(),
                    WindowStyle = ProcessWindowStyle.Minimized,
                    CreateNoWindow = false,
                    UseShellExecute = false
                },
                EnableRaisingEvents = true
            };

            // Set up Redirect Input and Output to WindowsGSM Console if EmbedConsole is on
            if (AllowsEmbedConsole)
            {
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;
                var serverConsole = new ServerConsole(serverData.ServerID);
                p.OutputDataReceived += serverConsole.AddOutput;
                p.ErrorDataReceived += serverConsole.AddOutput;
            }

            // Start Process
            try
            {
                p.Start();
                if (AllowsEmbedConsole)
                {
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                }
                return p;
            }
            catch (Exception e)
            {
                Error = e.Message;
                return null; // return null if fail to start
            }
        }


        // - Stop server function
        public async Task Stop(Process p)
        {
            await Task.Run(() =>
            {
                Functions.ServerConsole.SetMainWindow(p.MainWindowHandle);
                Functions.ServerConsole.SendWaitToMainWindow("^c");
                p.WaitForExit(2000);
				if (!p.HasExited)
					p.Kill();
            });
        }

        // fixes WinGSM bug, https://github.com/WindowsGSM/WindowsGSM/issues/57#issuecomment-983924499
        public async Task<Process> Update(bool validate = false, string custom = null)
        {
            var (p, error) = await Installer.SteamCMD.UpdateEx(serverData.ServerID, AppId, validate, custom: custom, loginAnonymous: loginAnonymous);
            Error = error;
            return p;
        }

    }
}
