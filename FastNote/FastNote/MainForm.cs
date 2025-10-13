using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace FastNote
{
    public class MainForm : Form
    {
        private TextBox textBox;
        private string currentFile;

        public MainForm()
        {
            Text = "FastNote";
            Width = 800; Height = 600;

            // --- Menu setup ---
            var menu = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("File");

            var newFile = new ToolStripMenuItem("New", null, (s, e) => NewFile());
            var open = new ToolStripMenuItem("Open", null, (s, e) => OpenFile());
            var save = new ToolStripMenuItem("Save", null, (s, e) => SaveFile());
            var saveAs = new ToolStripMenuItem("Save As", null, (s, e) => SaveFileAs());
            var closeFile = new ToolStripMenuItem("Close File", null, (s, e) => CloseFile());
            var exit = new ToolStripMenuItem("Exit", null, (s, e) => Close());

            // Explicitly define array type to avoid CS0826
            fileMenu.DropDownItems.AddRange(new ToolStripItem[]
            {
                newFile, open, save, saveAs, closeFile,
                new ToolStripSeparator(),
                exit
            });

            var viewMenu = new ToolStripMenuItem("View");
            var wordWrap = new ToolStripMenuItem("Word Wrap")
            {
                Checked = true,
                CheckOnClick = true
            };
            wordWrap.CheckedChanged += (s, e) => textBox.WordWrap = wordWrap.Checked;
            viewMenu.DropDownItems.Add(wordWrap);

            menu.Items.AddRange(new ToolStripItem[] { fileMenu, viewMenu });
            MainMenuStrip = menu;
            Controls.Add(menu);

            // --- TextBox setup ---
            textBox = new TextBox()
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                WordWrap = true,
                ScrollBars = ScrollBars.Both,
                AcceptsTab = true,
                AcceptsReturn = true,
                Font = new Font("Consolas", 11),
                BorderStyle = BorderStyle.None // match Notepad
            };

            // Place TextBox *below* the menu strip properly
            var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(4, menu.Height + 2, 4, 4) };
            panel.Controls.Add(textBox);
            Controls.Add(panel);

            // --- Start blank file ---
            NewFile();
        }

        private void NewFile()
        {
            textBox.Clear();
            currentFile = null;
            Text = "FastNote - Untitled";
        }

        private void CloseFile()
        {
            textBox.Clear();
            currentFile = null;
            Text = "FastNote - No file open";
        }

        private void OpenFile()
        {
            using (var d = new OpenFileDialog() { Filter = "Text Files|*.txt|All Files|*.*" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = File.ReadAllText(d.FileName);
                    currentFile = d.FileName;
                    Text = $"FastNote - {Path.GetFileName(currentFile)}";
                }
            }
        }

        private void SaveFile()
        {
            if (currentFile == null)
            {
                SaveFileAs();
                return;
            }
            File.WriteAllText(currentFile, textBox.Text);
        }

        private void SaveFileAs()
        {
            using (var d = new SaveFileDialog() { Filter = "Text Files|*.txt|All Files|*.*" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    currentFile = d.FileName;
                    SaveFile();
                    Text = $"FastNote - {Path.GetFileName(currentFile)}";
                }
            }
        }
    }
}