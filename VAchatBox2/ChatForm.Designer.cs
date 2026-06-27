namespace VAchatBox2
{
    partial class ChatForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnQuiz = new System.Windows.Forms.Button();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.grpAddTask = new System.Windows.Forms.GroupBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.txtTaskDesc = new System.Windows.Forms.TextBox();
            this.lblTaskDesc = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.grpTasks = new System.Windows.Forms.GroupBox();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnRefreshLog = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.grpAddTask.SuspendLayout();
            this.grpTasks.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabChat);
            this.tabControl.Controls.Add(this.tabTasks);
            this.tabControl.Controls.Add(this.tabLog);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.tabControl.Location = new System.Drawing.Point(0, 80);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(884, 581);
            this.tabControl.TabIndex = 0;
            // 
            // tabChat
            // 
            this.tabChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.tabChat.Controls.Add(this.rtbChat);
            this.tabChat.Controls.Add(this.pnlInput);
            this.tabChat.Location = new System.Drawing.Point(4, 31);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(4);
            this.tabChat.Size = new System.Drawing.Size(876, 546);
            this.tabChat.TabIndex = 0;
            this.tabChat.Text = "Chat";
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChat.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.rtbChat.ForeColor = System.Drawing.Color.White;
            this.rtbChat.Location = new System.Drawing.Point(4, 4);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChat.Size = new System.Drawing.Size(868, 492);
            this.rtbChat.TabIndex = 0;
            this.rtbChat.Text = "";
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(58)))));
            this.pnlInput.Controls.Add(this.txtInput);
            this.pnlInput.Controls.Add(this.btnSend);
            this.pnlInput.Controls.Add(this.btnQuiz);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInput.Location = new System.Drawing.Point(4, 496);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(6);
            this.pnlInput.Size = new System.Drawing.Size(868, 46);
            this.pnlInput.TabIndex = 1;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(6, 6);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(686, 31);
            this.txtInput.TabIndex = 0;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Location = new System.Drawing.Point(692, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 34);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnQuiz
            // 
            this.btnQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(220)))));
            this.btnQuiz.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuiz.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuiz.ForeColor = System.Drawing.Color.White;
            this.btnQuiz.Location = new System.Drawing.Point(772, 6);
            this.btnQuiz.Name = "btnQuiz";
            this.btnQuiz.Size = new System.Drawing.Size(90, 34);
            this.btnQuiz.TabIndex = 2;
            this.btnQuiz.Text = "Quiz";
            this.btnQuiz.UseVisualStyleBackColor = false;
            this.btnQuiz.Click += new System.EventHandler(this.btnQuiz_Click);
            // 
            // tabTasks
            // 
            this.tabTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.tabTasks.Controls.Add(this.grpAddTask);
            this.tabTasks.Controls.Add(this.grpTasks);
            this.tabTasks.Location = new System.Drawing.Point(4, 31);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(4);
            this.tabTasks.Size = new System.Drawing.Size(876, 546);
            this.tabTasks.TabIndex = 1;
            this.tabTasks.Text = "Task Assistant";
            // 
            // grpAddTask
            // 
            this.grpAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.grpAddTask.Controls.Add(this.btnAddTask);
            this.grpAddTask.Controls.Add(this.dtpReminder);
            this.grpAddTask.Controls.Add(this.chkReminder);
            this.grpAddTask.Controls.Add(this.txtTaskDesc);
            this.grpAddTask.Controls.Add(this.lblTaskDesc);
            this.grpAddTask.Controls.Add(this.txtTaskTitle);
            this.grpAddTask.Controls.Add(this.lblTaskTitle);
            this.grpAddTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAddTask.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.grpAddTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.grpAddTask.Location = new System.Drawing.Point(374, 4);
            this.grpAddTask.Name = "grpAddTask";
            this.grpAddTask.Size = new System.Drawing.Size(498, 538);
            this.grpAddTask.TabIndex = 0;
            this.grpAddTask.TabStop = false;
            this.grpAddTask.Text = "Add a New Task";
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddTask.ForeColor = System.Drawing.Color.Black;
            this.btnAddTask.Location = new System.Drawing.Point(14, 244);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(320, 36);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // dtpReminder
            // 
            this.dtpReminder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReminder.Location = new System.Drawing.Point(14, 206);
            this.dtpReminder.MinDate = new System.DateTime(2026, 6, 26, 0, 0, 0, 0);
            this.dtpReminder.Name = "dtpReminder";
            this.dtpReminder.Size = new System.Drawing.Size(200, 29);
            this.dtpReminder.TabIndex = 1;
            this.dtpReminder.Visible = false;
            // 
            // chkReminder
            // 
            this.chkReminder.Font = new System.Drawing.Font("Consolas", 9F);
            this.chkReminder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.chkReminder.Location = new System.Drawing.Point(14, 180);
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Size = new System.Drawing.Size(200, 22);
            this.chkReminder.TabIndex = 2;
            this.chkReminder.Text = "Set Reminder Date";
            this.chkReminder.CheckedChanged += new System.EventHandler(this.chkReminder_CheckedChanged);
            // 
            // txtTaskDesc
            // 
            this.txtTaskDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.txtTaskDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskDesc.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtTaskDesc.ForeColor = System.Drawing.Color.White;
            this.txtTaskDesc.Location = new System.Drawing.Point(14, 104);
            this.txtTaskDesc.Multiline = true;
            this.txtTaskDesc.Name = "txtTaskDesc";
            this.txtTaskDesc.Size = new System.Drawing.Size(320, 65);
            this.txtTaskDesc.TabIndex = 3;
            // 
            // lblTaskDesc
            // 
            this.lblTaskDesc.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblTaskDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.lblTaskDesc.Location = new System.Drawing.Point(14, 84);
            this.lblTaskDesc.Name = "lblTaskDesc";
            this.lblTaskDesc.Size = new System.Drawing.Size(200, 18);
            this.lblTaskDesc.TabIndex = 4;
            this.lblTaskDesc.Text = "Description:";
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.txtTaskTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskTitle.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtTaskTitle.ForeColor = System.Drawing.Color.White;
            this.txtTaskTitle.Location = new System.Drawing.Point(14, 48);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(320, 30);
            this.txtTaskTitle.TabIndex = 5;
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblTaskTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.lblTaskTitle.Location = new System.Drawing.Point(14, 28);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(200, 18);
            this.lblTaskTitle.TabIndex = 6;
            this.lblTaskTitle.Text = "Task Title:";
            // 
            // grpTasks
            // 
            this.grpTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.grpTasks.Controls.Add(this.lstTasks);
            this.grpTasks.Controls.Add(this.btnComplete);
            this.grpTasks.Controls.Add(this.btnDeleteTask);
            this.grpTasks.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpTasks.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.grpTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.grpTasks.Location = new System.Drawing.Point(4, 4);
            this.grpTasks.Name = "grpTasks";
            this.grpTasks.Size = new System.Drawing.Size(370, 538);
            this.grpTasks.TabIndex = 1;
            this.grpTasks.TabStop = false;
            this.grpTasks.Text = "Your Cybersecurity Tasks";
            // 
            // lstTasks
            // 
            this.lstTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(58)))));
            this.lstTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTasks.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstTasks.ForeColor = System.Drawing.Color.White;
            this.lstTasks.ItemHeight = 22;
            this.lstTasks.Location = new System.Drawing.Point(3, 25);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(364, 442);
            this.lstTasks.TabIndex = 0;
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(110)))));
            this.btnComplete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(3, 467);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(364, 34);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "Mark Done";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDeleteTask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTask.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTask.Location = new System.Drawing.Point(3, 501);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(364, 34);
            this.btnDeleteTask.TabIndex = 2;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // tabLog
            // 
            this.tabLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.tabLog.Controls.Add(this.lstLog);
            this.tabLog.Controls.Add(this.btnRefreshLog);
            this.tabLog.Location = new System.Drawing.Point(4, 31);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(4);
            this.tabLog.Size = new System.Drawing.Size(876, 546);
            this.tabLog.TabIndex = 2;
            this.tabLog.Text = "Activity Log";
            // 
            // lstLog
            // 
            this.lstLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(58)))));
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.lstLog.ItemHeight = 22;
            this.lstLog.Location = new System.Drawing.Point(4, 4);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(868, 502);
            this.lstLog.TabIndex = 0;
            // 
            // btnRefreshLog
            // 
            this.btnRefreshLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnRefreshLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefreshLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshLog.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshLog.Location = new System.Drawing.Point(4, 506);
            this.btnRefreshLog.Name = "btnRefreshLog";
            this.btnRefreshLog.Size = new System.Drawing.Size(868, 36);
            this.btnRefreshLog.TabIndex = 1;
            this.btnRefreshLog.Text = "Refresh Log";
            this.btnRefreshLog.UseVisualStyleBackColor = false;
            this.btnRefreshLog.Click += new System.EventHandler(this.btnRefreshLog_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(58)))));
            this.pnlHeader.Controls.Add(this.lblSlogan);
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblSlogan
            // 
            this.lblSlogan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSlogan.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Italic);
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(50)))));
            this.lblSlogan.Location = new System.Drawing.Point(0, 54);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblSlogan.Size = new System.Drawing.Size(884, 26);
            this.lblSlogan.TabIndex = 0;
            this.lblSlogan.Text = "Making your security as easy as ABC";
            this.lblSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblLogo.Size = new System.Drawing.Size(884, 46);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "ABChat  ◈  Cybersecurity Awareness Bot";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChatForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABChat — Cybersecurity Awareness Bot";
            this.tabControl.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.tabTasks.ResumeLayout(false);
            this.grpAddTask.ResumeLayout(false);
            this.grpAddTask.PerformLayout();
            this.grpTasks.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       


        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnQuiz;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.GroupBox grpTasks;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.GroupBox grpAddTask;
        private System.Windows.Forms.Label lblTaskTitle;
        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.Label lblTaskDesc;
        private System.Windows.Forms.TextBox txtTaskDesc;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.DateTimePicker dtpReminder;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnRefreshLog;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSlogan;
    }
}