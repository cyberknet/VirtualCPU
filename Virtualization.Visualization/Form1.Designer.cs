namespace Virtualization.Visualization
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.TabPage tabProcessor;
            System.Windows.Forms.TabPage tabMemory;
            this.NextClock = new System.Windows.Forms.Button();
            this.ZeroFlag = new System.Windows.Forms.Label();
            this.SignFlag = new System.Windows.Forms.Label();
            this.RegisterView = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.txtProgram = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tabProcessor = new System.Windows.Forms.TabPage();
            tabMemory = new System.Windows.Forms.TabPage();
            tabProcessor.SuspendLayout();
            tabMemory.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(232, 52);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 17);
            label4.TabIndex = 10;
            label4.Text = "Zero Flag:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(232, 23);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 17);
            label2.TabIndex = 8;
            label2.Text = "Sign Flag:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 4);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 17);
            label1.TabIndex = 7;
            label1.Text = "Registers:";
            // 
            // tabProcessor
            // 
            tabProcessor.Controls.Add(this.NextClock);
            tabProcessor.Controls.Add(this.ZeroFlag);
            tabProcessor.Controls.Add(label4);
            tabProcessor.Controls.Add(this.SignFlag);
            tabProcessor.Controls.Add(label2);
            tabProcessor.Controls.Add(label1);
            tabProcessor.Controls.Add(this.RegisterView);
            tabProcessor.Location = new System.Drawing.Point(4, 25);
            tabProcessor.Margin = new System.Windows.Forms.Padding(4);
            tabProcessor.Name = "tabProcessor";
            tabProcessor.Padding = new System.Windows.Forms.Padding(4);
            tabProcessor.Size = new System.Drawing.Size(828, 324);
            tabProcessor.TabIndex = 0;
            tabProcessor.Text = "Processor";
            tabProcessor.UseVisualStyleBackColor = true;
            // 
            // NextClock
            // 
            this.NextClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextClock.Location = new System.Drawing.Point(691, 283);
            this.NextClock.Margin = new System.Windows.Forms.Padding(4);
            this.NextClock.Name = "NextClock";
            this.NextClock.Size = new System.Drawing.Size(127, 28);
            this.NextClock.TabIndex = 12;
            this.NextClock.Text = "Next Clock";
            this.NextClock.UseVisualStyleBackColor = true;
            this.NextClock.Click += new System.EventHandler(this.NextClock_Click);
            // 
            // ZeroFlag
            // 
            this.ZeroFlag.AutoSize = true;
            this.ZeroFlag.Location = new System.Drawing.Point(312, 52);
            this.ZeroFlag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ZeroFlag.Name = "ZeroFlag";
            this.ZeroFlag.Size = new System.Drawing.Size(42, 17);
            this.ZeroFlag.TabIndex = 11;
            this.ZeroFlag.Text = "False";
            // 
            // SignFlag
            // 
            this.SignFlag.AutoSize = true;
            this.SignFlag.Location = new System.Drawing.Point(312, 23);
            this.SignFlag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SignFlag.Name = "SignFlag";
            this.SignFlag.Size = new System.Drawing.Size(42, 17);
            this.SignFlag.TabIndex = 9;
            this.SignFlag.Text = "False";
            // 
            // RegisterView
            // 
            this.RegisterView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RegisterView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
            this.RegisterView.Location = new System.Drawing.Point(7, 23);
            this.RegisterView.Margin = new System.Windows.Forms.Padding(4);
            this.RegisterView.Name = "RegisterView";
            this.RegisterView.Size = new System.Drawing.Size(216, 287);
            this.RegisterView.TabIndex = 6;
            this.RegisterView.UseCompatibleStateImageBehavior = false;
            this.RegisterView.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 93;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            // 
            // tabMemory
            // 
            tabMemory.Controls.Add(this.hexBox1);
            tabMemory.Location = new System.Drawing.Point(4, 25);
            tabMemory.Margin = new System.Windows.Forms.Padding(4);
            tabMemory.Name = "tabMemory";
            tabMemory.Padding = new System.Windows.Forms.Padding(4);
            tabMemory.Size = new System.Drawing.Size(828, 324);
            tabMemory.TabIndex = 1;
            tabMemory.Text = "Memory";
            tabMemory.UseVisualStyleBackColor = true;
            // 
            // hexBox1
            // 
            this.hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox1.Location = new System.Drawing.Point(4, 4);
            this.hexBox1.Margin = new System.Windows.Forms.Padding(4);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(820, 316);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(tabProcessor);
            this.tabControl1.Controls.Add(tabMemory);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(941, 464);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtProgram);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(933, 435);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Program";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtProgram
            // 
            this.txtProgram.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.txtProgram.AutoListPosition = null;
            this.txtProgram.AutoListSelectedText = "";
            this.txtProgram.AutoListVisible = false;
            this.txtProgram.BackColor = System.Drawing.Color.White;
            this.txtProgram.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.txtProgram.CopyAsRTF = false;
            this.txtProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgram.Document = this.syntaxDocument1;
            this.txtProgram.FontName = "Courier new";
            this.txtProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtProgram.InfoTipCount = 1;
            this.txtProgram.InfoTipPosition = null;
            this.txtProgram.InfoTipSelectedIndex = 0;
            this.txtProgram.InfoTipVisible = false;
            this.txtProgram.Location = new System.Drawing.Point(3, 3);
            this.txtProgram.LockCursorUpdate = false;
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.ReadOnly = true;
            this.txtProgram.ShowScopeIndicator = false;
            this.txtProgram.Size = new System.Drawing.Size(927, 429);
            this.txtProgram.SmoothScroll = false;
            this.txtProgram.SplitviewH = -4;
            this.txtProgram.SplitviewV = -4;
            this.txtProgram.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.txtProgram.TabIndex = 0;
            this.txtProgram.Text = "syntaxBoxControl1";
            this.txtProgram.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 492);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(887, 459);
            this.Name = "Form1";
            this.Text = "VirtualCPU Visualization";
            this.Load += new System.EventHandler(this.Form1_Load);
            tabProcessor.ResumeLayout(false);
            tabProcessor.PerformLayout();
            tabMemory.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label ZeroFlag;
        private System.Windows.Forms.Label SignFlag;
        private System.Windows.Forms.ListView RegisterView;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Timer ClockTimer;
        private System.Windows.Forms.Button NextClock;
        private Be.Windows.Forms.HexBox hexBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private Alsing.Windows.Forms.SyntaxBoxControl txtProgram;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
    }
}

