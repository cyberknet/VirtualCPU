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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tabProcessor = new System.Windows.Forms.TabPage();
            tabMemory = new System.Windows.Forms.TabPage();
            tabProcessor.SuspendLayout();
            tabMemory.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(174, 42);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(55, 13);
            label4.TabIndex = 10;
            label4.Text = "Zero Flag:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(174, 19);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(54, 13);
            label2.TabIndex = 8;
            label2.Text = "Sign Flag:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
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
            tabProcessor.Location = new System.Drawing.Point(4, 22);
            tabProcessor.Name = "tabProcessor";
            tabProcessor.Padding = new System.Windows.Forms.Padding(3);
            tabProcessor.Size = new System.Drawing.Size(619, 261);
            tabProcessor.TabIndex = 0;
            tabProcessor.Text = "Processor";
            tabProcessor.UseVisualStyleBackColor = true;
            // 
            // NextClock
            // 
            this.NextClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextClock.Location = new System.Drawing.Point(518, 230);
            this.NextClock.Name = "NextClock";
            this.NextClock.Size = new System.Drawing.Size(95, 23);
            this.NextClock.TabIndex = 12;
            this.NextClock.Text = "Next Clock";
            this.NextClock.UseVisualStyleBackColor = true;
            this.NextClock.Click += new System.EventHandler(this.NextClock_Click);
            // 
            // ZeroFlag
            // 
            this.ZeroFlag.AutoSize = true;
            this.ZeroFlag.Location = new System.Drawing.Point(234, 42);
            this.ZeroFlag.Name = "ZeroFlag";
            this.ZeroFlag.Size = new System.Drawing.Size(32, 13);
            this.ZeroFlag.TabIndex = 11;
            this.ZeroFlag.Text = "False";
            // 
            // SignFlag
            // 
            this.SignFlag.AutoSize = true;
            this.SignFlag.Location = new System.Drawing.Point(234, 19);
            this.SignFlag.Name = "SignFlag";
            this.SignFlag.Size = new System.Drawing.Size(32, 13);
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
            this.RegisterView.Location = new System.Drawing.Point(5, 19);
            this.RegisterView.Name = "RegisterView";
            this.RegisterView.Size = new System.Drawing.Size(163, 234);
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
            tabMemory.Location = new System.Drawing.Point(4, 22);
            tabMemory.Name = "tabMemory";
            tabMemory.Padding = new System.Windows.Forms.Padding(3);
            tabMemory.Size = new System.Drawing.Size(619, 261);
            tabMemory.TabIndex = 1;
            tabMemory.Text = "Memory";
            tabMemory.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(tabProcessor);
            this.tabControl1.Controls.Add(tabMemory);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 287);
            this.tabControl1.TabIndex = 6;
            // 
            // hexBox1
            // 
            this.hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox1.Location = new System.Drawing.Point(3, 3);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(613, 255);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 344);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(670, 382);
            this.Name = "Form1";
            this.Text = "Form1";
            tabProcessor.ResumeLayout(false);
            tabProcessor.PerformLayout();
            tabMemory.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
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
    }
}

