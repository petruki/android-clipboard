﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AndroidClipboard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ExecuteCommand($"adb shell input text '{textArea.SelectedText}'");
        }

        public void ExecuteCommand(string cmd)
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", $"/K {cmd} && exit")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            process = Process.Start(processInfo);
            process.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textArea.Text = "";
        }
    }
}
