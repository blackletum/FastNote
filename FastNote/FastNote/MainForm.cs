using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace FastNote
{
    public class MainForm : Form
    {
        TextBox box; string path; bool dark = false, dirty = false;
        public MainForm()
        {
            Text = "FastNote"; Width = 800; Height = 600;
            //Icon = Icon.ExtractAssociatedIcon(Environment.ExpandEnvironmentVariables(@"%SystemRoot%\System32\notepad.exe"));
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            var m = new MenuStrip();
            var f = new ToolStripMenuItem("File");

            f.DropDownItems.Add(new ToolStripMenuItem("New", null, (s, e) => { if (!CheckSave()) return; box.Clear(); path = null; Text = "FastNote - Untitled"; dirty = false; }));
            f.DropDownItems.Add(new ToolStripMenuItem("Open", null, (s, e) => { if (!CheckSave()) return; using (var d = new OpenFileDialog { Filter = "Text Files|*.txt|All Files|*.*" }) if (d.ShowDialog() == DialogResult.OK) { box.Text = File.ReadAllText(path = d.FileName); Text = $"FastNote - {Path.GetFileName(path)}"; dirty = false; } }));
            f.DropDownItems.Add(new ToolStripSeparator());
            f.DropDownItems.Add(new ToolStripMenuItem("Save", null, (s, e) => { if (path == null) { SaveAs(); return; } File.WriteAllText(path, box.Text); dirty = false; }));
            f.DropDownItems.Add(new ToolStripMenuItem("Save As", null, (s, e) => SaveAs()));
            f.DropDownItems.Add(new ToolStripMenuItem("Close", null, (s, e) => { if (!CheckSave()) return; box.Clear(); path = null; Text = "FastNote - No file open"; dirty = false; }));
            f.DropDownItems.Add(new ToolStripSeparator());
            f.DropDownItems.Add(new ToolStripMenuItem("Exit", null, (s, e) => Close()));

            var v = new ToolStripMenuItem("View");
            var wrap = new ToolStripMenuItem("Word Wrap") { Checked = true, CheckOnClick = true };
            wrap.CheckedChanged += (s, e) => box.WordWrap = wrap.Checked;
            v.DropDownItems.Add(wrap);
            var darkMode = new ToolStripMenuItem("Dark Mode") { CheckOnClick = true };
            darkMode.CheckedChanged += (s, e) => ToggleDark(darkMode.Checked);
            v.DropDownItems.Add(darkMode);

            var help = new ToolStripMenuItem("Help");
            help.DropDownItems.Add(new ToolStripMenuItem("About", null, (s, e) => ShowAbout()));

            m.Items.AddRange(new ToolStripItem[] { f, v, help });
            MainMenuStrip = m;
            Controls.Add(m);

            box = new TextBox { Multiline = true, Dock = DockStyle.Fill, Font = new Font("Consolas", 11), ScrollBars = ScrollBars.Both, BorderStyle = BorderStyle.None, WordWrap = true, AcceptsReturn = true, AcceptsTab = true };

            var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(4, m.Height + 2, 4, 4) };
            panel.Controls.Add(box);
            Controls.Add(panel);
            MainMenuStrip = m;
            KeyPreview = true;
            KeyDown += KeysHandler;
            box.TextChanged += (s, e) => dirty = true;
            FormClosing += (s, e) => { if (!CheckSave()) e.Cancel = true; };
        }

        void SaveAs()
        {
            using (var d = new SaveFileDialog { Filter = "Text Files|*.txt|All Files|*.*" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    path = d.FileName;
                    File.WriteAllText(path, box.Text);
                    Text = $"FastNote - {Path.GetFileName(path)}";
                    dirty = false;
                }
            }
        }

        bool CheckSave()
        {
            if (!dirty) return true;
            var r = MessageBox.Show("Save changes before continuing?", "FastNote", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (r == DialogResult.Cancel) return false;
            if (r == DialogResult.Yes) { if (path == null) SaveAs(); else File.WriteAllText(path, box.Text); dirty = false; }
            return true;
        }

        void ToggleDark(bool on)
        {
            dark = on;
            box.BackColor = dark ? Color.Black : Color.White;
            box.ForeColor = dark ? Color.White : Color.Black;
        }

        void KeysHandler(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) { if (path == null) SaveAs(); else File.WriteAllText(path, box.Text); dirty = false; e.SuppressKeyPress = true; }
            if (e.Control && e.KeyCode == Keys.O) { if (!CheckSave()) return; using (var d = new OpenFileDialog { Filter = "Text Files|*.txt|All Files|*.*" }) if (d.ShowDialog() == DialogResult.OK) { box.Text = File.ReadAllText(path = d.FileName); Text = $"FastNote - {Path.GetFileName(path)}"; dirty = false; } e.SuppressKeyPress = true; }
        }

        void ShowAbout()
        {
            var f = new Form { Text = "About FastNote", Width = 460, Height = 220, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false, StartPosition = FormStartPosition.CenterParent };
            var title = new Label { Text = "FastNote", Font = new Font("Segoe UI", 12, FontStyle.Italic), AutoSize = true, Location = new Point(12, 12) };
            var desc = new Label { Text = "A minimal note-taking application.\r\nWritten by SaintSoftware w/ ChatGPT assistance.\r\nCheck for new releases and source code on GitHub.", AutoSize = true, Location = new Point(12, 40) };
            var link = new LinkLabel { Text = "https://github.com/blackletum/FastNote", AutoSize = true, Location = new Point(12, 84) };
            link.LinkClicked += (s, e) => { try { Process.Start(new ProcessStartInfo(link.Text) { UseShellExecute = true }); } catch { } };
            var scam = new Label { Text = "If you have paid for this program, you have been SCAMMED.", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, Location = new Point(12, 110) };
            var ok = new Button { Text = "OK", DialogResult = DialogResult.OK, Anchor = AnchorStyles.Bottom | AnchorStyles.Right, Size = new Size(80, 26), Location = new Point(f.ClientSize.Width - 92, f.ClientSize.Height - 40) };
            ok.Click += (s, e) => f.Close();
            f.Controls.AddRange(new Control[] { title, desc, link, scam, ok });
            f.AcceptButton = ok;
            f.ShowDialog();
        }
    }
}
