using System.Drawing;
using System.Windows.Forms;

namespace FastNote;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        m = new MenuStrip();
        f = new ToolStripMenuItem();
        newDropDownItem = new ToolStripMenuItem();
        openDropDownItem = new ToolStripMenuItem();
        saveDropDownItem = new ToolStripMenuItem();
        saveAsDropDownItem = new ToolStripMenuItem();
        closeDropDownItem = new ToolStripMenuItem();
        exitDropDownItem = new ToolStripMenuItem();
        v = new ToolStripMenuItem();
        wrap = new ToolStripMenuItem();
        darkMode = new ToolStripMenuItem();
        help = new ToolStripMenuItem();
        aboutDropDownItem = new ToolStripMenuItem();
        panel = new Panel();
        box = new TextBox();
        m.SuspendLayout();
        panel.SuspendLayout();
        SuspendLayout();
        // 
        // m
        // 
        m.Items.AddRange(new ToolStripItem[] { f, v, help });
        m.Location = new Point(0, 0);
        m.Name = "m";
        m.Size = new Size(784, 24);
        m.TabIndex = 0;
        // 
        // f
        // 
        f.DropDownItems.AddRange(new ToolStripItem[] { newDropDownItem, openDropDownItem, saveDropDownItem, saveAsDropDownItem, closeDropDownItem, exitDropDownItem });
        f.Name = "f";
        f.Size = new Size(37, 20);
        f.Text = "File";
        // 
        // newDropDownItem
        // 
        newDropDownItem.Name = "newDropDownItem";
        newDropDownItem.Size = new Size(112, 22);
        newDropDownItem.Text = "New";
        newDropDownItem.Click += newDropDownItem_Click;
        // 
        // openDropDownItem
        // 
        openDropDownItem.Name = "openDropDownItem";
        openDropDownItem.Size = new Size(112, 22);
        openDropDownItem.Text = "Open";
        openDropDownItem.Click += openDropDownItem_Click;
        // 
        // saveDropDownItem
        // 
        saveDropDownItem.Name = "saveDropDownItem";
        saveDropDownItem.Size = new Size(112, 22);
        saveDropDownItem.Text = "Save";
        saveDropDownItem.Click += saveDropDownItem_Click;
        // 
        // saveAsDropDownItem
        // 
        saveAsDropDownItem.Name = "saveAsDropDownItem";
        saveAsDropDownItem.Size = new Size(112, 22);
        saveAsDropDownItem.Text = "Save as";
        saveAsDropDownItem.Click += saveAsDropDownItem_Click;
        // 
        // closeDropDownItem
        // 
        closeDropDownItem.Name = "closeDropDownItem";
        closeDropDownItem.Size = new Size(112, 22);
        closeDropDownItem.Text = "Close";
        closeDropDownItem.Click += closeDropDownItem_Click;
        // 
        // exitDropDownItem
        // 
        exitDropDownItem.Name = "exitDropDownItem";
        exitDropDownItem.Size = new Size(112, 22);
        exitDropDownItem.Text = "Exit";
        exitDropDownItem.Click += exitDropDownItem_Click;
        // 
        // v
        // 
        v.DropDownItems.AddRange(new ToolStripItem[] { wrap, darkMode });
        v.Name = "v";
        v.Size = new Size(44, 20);
        v.Text = "View";
        // 
        // wrap
        // 
        wrap.Checked = true;
        wrap.CheckOnClick = true;
        wrap.CheckState = CheckState.Checked;
        wrap.Name = "wrap";
        wrap.Size = new Size(134, 22);
        wrap.Text = "Word Wrap";
        wrap.CheckedChanged += wrap_CheckedChanged;
        // 
        // darkMode
        // 
        darkMode.Name = "darkMode";
        darkMode.Size = new Size(134, 22);
        darkMode.Text = "Dark Mode";
        darkMode.CheckedChanged += darkMode_CheckedChanged;
        // 
        // help
        // 
        help.DropDownItems.AddRange(new ToolStripItem[] { aboutDropDownItem });
        help.Name = "help";
        help.Size = new Size(44, 20);
        help.Text = "Help";
        // 
        // aboutDropDownItem
        // 
        aboutDropDownItem.Name = "aboutDropDownItem";
        aboutDropDownItem.Size = new Size(107, 22);
        aboutDropDownItem.Text = "About";
        aboutDropDownItem.Click += aboutDropDownItem_Click;
        // 
        // panel
        // 
        panel.Controls.Add(box);
        panel.Dock = DockStyle.Fill;
        panel.Location = new Point(0, 0);
        panel.Name = "panel";
        panel.Padding = new Padding(4, 24, 4, 4);
        panel.Size = new Size(784, 561);
        panel.TabIndex = 1;
        // 
        // box
        // 
        box.AcceptsReturn = true;
        box.AcceptsTab = true;
        box.BorderStyle = BorderStyle.None;
        box.Dock = DockStyle.Fill;
        box.Font = new Font("Consolas", 11F);
        box.Location = new Point(4, 24);
        box.Multiline = true;
        box.Name = "box";
        box.ScrollBars = ScrollBars.Both;
        box.Size = new Size(776, 533);
        box.TabIndex = 0;
        box.TextChanged += box_TextChanged;
        // 
        // MainForm
        // 
        ClientSize = new Size(784, 561);
        Controls.Add(m);
        Controls.Add(panel);
        Icon = (Icon)resources.GetObject("$this.Icon");
        KeyPreview = true;
        MainMenuStrip = m;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FastNote";
        FormClosing += MainForm_FormClosing;
        KeyDown += KeysHandler;
        m.ResumeLayout(false);
        m.PerformLayout();
        panel.ResumeLayout(false);
        panel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();

    }

    private ToolStripMenuItem darkMode;
    private ToolStripMenuItem wrap;
    private TextBox box;
    private MenuStrip m;
    private ToolStripMenuItem f;
    private ToolStripMenuItem newDropDownItem;
    private ToolStripMenuItem openDropDownItem;
    private ToolStripMenuItem saveDropDownItem;
    private ToolStripMenuItem saveAsDropDownItem;
    private ToolStripMenuItem closeDropDownItem;
    private ToolStripMenuItem exitDropDownItem;
    private ToolStripMenuItem v;
    private ToolStripMenuItem help;
    private ToolStripMenuItem aboutDropDownItem;
    private Panel panel;
}