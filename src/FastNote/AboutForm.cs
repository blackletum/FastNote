using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FastNote
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Load += AboutForm_Load;
        }

        private void AboutForm_Load(object? sender, EventArgs e)
        {
            link.LinkClicked += (_, __) =>
            {
                try { Process.Start(new ProcessStartInfo(link.Text) { UseShellExecute = true }); } catch { }
            };
        }
    }
}
