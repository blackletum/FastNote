using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastNote;

public partial class MainForm : Form
{
    private string? path;
    private bool dark = false;
    private bool dirty = false;

    public MainForm()
    {
        InitializeComponent();
    }

    private void darkMode_CheckedChanged(object sender, EventArgs e)
    {
        ToggleDark(darkMode.Checked);
    }

    private void wrap_CheckedChanged(object sender, EventArgs e)
    {
        box.WordWrap = wrap.Checked;
    }

    private void newDropDownItem_Click(object sender, EventArgs e)
    {
        if (!CheckSave()) return;
        box.Clear();
        path = null;
        Text = "FastNote - Untitled";
        dirty = false;
    }

    private void openDropDownItem_Click(object sender, EventArgs e)
    {
        if (!CheckSave()) return;
        using (var d = new OpenFileDialog { Filter = "Text Files|*.txt|All Files|*.*" })
        {
            if (d.ShowDialog() == DialogResult.OK)
            {
                box.Text = File.ReadAllText(path = d.FileName);
                Text = $"FastNote - {Path.GetFileName(path)}";
                dirty = false;
            }
        }
    }

    private void saveDropDownItem_Click(object sender, EventArgs e)
    {
        if (path == null)
        {
            SaveAs();
            return;
        }
        File.WriteAllText(path, box.Text);
        dirty = false;
    }

    private void saveAsDropDownItem_Click(object sender, EventArgs e) =>
        SaveAs();

    private void closeDropDownItem_Click(object sender, EventArgs e)
    {
        if (!CheckSave()) return;
        box.Clear();
        path = null;
        Text = "FastNote - No file open";
        dirty = false;
    }

    private void exitDropDownItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void aboutDropDownItem_Click(object sender, EventArgs e)
    {
        ShowAbout();
    }
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!CheckSave())
            e.Cancel = true;
    }

    private void box_TextChanged(object sender, EventArgs e)
    {
        dirty = true;
    }

    private void SaveAs()
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

    private bool CheckSave()
    {
        if (!dirty) return true;
        var r = MessageBox.Show("Save changes before continuing?", "FastNote", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        if (r == DialogResult.Cancel) return false;
        if (r == DialogResult.Yes) { if (path == null) SaveAs(); else File.WriteAllText(path, box.Text); dirty = false; }
        return true;
    }

    private void ToggleDark(bool on)
    {
        dark = on;
        box.BackColor = dark ? Color.Black : Color.White;
        box.ForeColor = dark ? Color.White : Color.Black;
    }

    private void KeysHandler(object s, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.S) { if (path == null) SaveAs(); else File.WriteAllText(path, box.Text); dirty = false; e.SuppressKeyPress = true; }
        if (e.Control && e.KeyCode == Keys.O) { if (!CheckSave()) return; using (var d = new OpenFileDialog { Filter = "Text Files|*.txt|All Files|*.*" }) if (d.ShowDialog() == DialogResult.OK) { box.Text = File.ReadAllText(path = d.FileName); Text = $"FastNote - {Path.GetFileName(path)}"; dirty = false; } e.SuppressKeyPress = true; }
    }

    private void ShowAbout()
    {
        var f = new AboutForm
        {
            Owner = this
        };
        f.ShowDialog();
    }
}
