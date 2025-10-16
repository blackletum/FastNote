namespace FastNote;

partial class AboutForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
        layout = new System.Windows.Forms.FlowLayoutPanel();
        title = new System.Windows.Forms.Label();
        desc = new System.Windows.Forms.Label();
        link = new System.Windows.Forms.LinkLabel();
        license = new System.Windows.Forms.Label();
        scam = new System.Windows.Forms.Label();
        ok = new System.Windows.Forms.Button();
        layout.SuspendLayout();
        SuspendLayout();
        // 
        // layout
        // 
        layout.AutoScroll = true;
        layout.Controls.Add(title);
        layout.Controls.Add(desc);
        layout.Controls.Add(link);
        layout.Controls.Add(license);
        layout.Controls.Add(scam);
        layout.Controls.Add(ok);
        layout.Dock = System.Windows.Forms.DockStyle.Fill;
        layout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        layout.Location = new System.Drawing.Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new System.Windows.Forms.Padding(15);
        layout.Size = new System.Drawing.Size(420, 200);
        layout.TabIndex = 0;
        layout.WrapContents = false;
        // 
        // title
        // 
        title.AutoSize = true;
        title.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic);
        title.Location = new System.Drawing.Point(18, 15);
        title.Name = "title";
        title.Size = new System.Drawing.Size(84, 25);
        title.TabIndex = 0;
        title.Text = "FastNote";
        // 
        // desc
        // 
        desc.AutoSize = true;
        desc.Location = new System.Drawing.Point(18, 40);
        desc.Name = "desc";
        desc.Size = new System.Drawing.Size(278, 45);
        desc.TabIndex = 1;
        desc.Text = "A minimal note-taking application.\nWritten by blackletum.\nCheck for new releases and source code on GitHub.";
        // 
        // link
        // 
        link.AutoSize = true;
        link.Location = new System.Drawing.Point(18, 85);
        link.Name = "link";
        link.Size = new System.Drawing.Size(225, 15);
        link.TabIndex = 2;
        link.TabStop = true;
        link.Text = "https://github.com/blackletum/FastNote";
        // 
        // license
        // 
        license.AutoSize = true;
        license.Location = new System.Drawing.Point(18, 100);
        license.Name = "license";
        license.Size = new System.Drawing.Size(233, 15);
        license.TabIndex = 3;
        license.Text = "FastNote is licensed under the MIT License.";
        // 
        // scam
        // 
        scam.AutoSize = true;
        scam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        scam.ForeColor = System.Drawing.Color.DarkRed;
        scam.Location = new System.Drawing.Point(18, 115);
        scam.Name = "scam";
        scam.Size = new System.Drawing.Size(340, 15);
        scam.TabIndex = 4;
        scam.Text = "If you have paid for this program, you have been SCAMMED.";
        // 
        // ok
        // 
        ok.Anchor = System.Windows.Forms.AnchorStyles.Right;
        ok.DialogResult = System.Windows.Forms.DialogResult.OK;
        ok.Location = new System.Drawing.Point(278, 133);
        ok.Name = "ok";
        ok.Size = new System.Drawing.Size(80, 23);
        ok.TabIndex = 5;
        ok.Text = "OK";
        // 
        // AboutForm
        // 
        AcceptButton = ok;
        ClientSize = new System.Drawing.Size(420, 200);
        Controls.Add(layout);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AboutForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "About FastNote";
        layout.ResumeLayout(false);
        layout.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.LinkLabel link;
    private System.Windows.Forms.FlowLayoutPanel layout;
    private System.Windows.Forms.Label title;
    private System.Windows.Forms.Label desc;
    private System.Windows.Forms.Label license;
    private System.Windows.Forms.Label scam;
    private System.Windows.Forms.Button ok;
}