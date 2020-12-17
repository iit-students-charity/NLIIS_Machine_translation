using System.Diagnostics;

namespace NLIIS_Machine_translation.Services
{
    public static class SyntaxTreeBuilder
    {
        private static ProcessStartInfo _builderProcessStartInfo;
        
        static SyntaxTreeBuilder()
        {
            _builderProcessStartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = @"cmd.exe",
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden
            };
        }
        
        public static void BuildTree(string sentence)
        {
            _builderProcessStartInfo.Arguments = $@"/c python3 D:\syntax_tree.py ""{sentence}""";
            var builderProcess = Process.Start(_builderProcessStartInfo);
            builderProcess.WaitForExit();
        }
    }
}
