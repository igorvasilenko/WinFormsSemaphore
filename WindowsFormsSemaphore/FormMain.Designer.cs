namespace WindowsFormsSemaphore
{
    partial class FormMain
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
            this.btnCreateThread = new System.Windows.Forms.Button();
            this.numInitialCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRunning = new System.Windows.Forms.ListBox();
            this.lbRunAndWait = new System.Windows.Forms.ListBox();
            this.lbCreated = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateThread
            // 
            this.btnCreateThread.Location = new System.Drawing.Point(465, 497);
            this.btnCreateThread.Name = "btnCreateThread";
            this.btnCreateThread.Size = new System.Drawing.Size(156, 23);
            this.btnCreateThread.TabIndex = 0;
            this.btnCreateThread.Text = "Create Thread";
            this.btnCreateThread.UseVisualStyleBackColor = true;
            this.btnCreateThread.Click += new System.EventHandler(this.btnCreateThread_Click);
            // 
            // numInitialCount
            // 
            this.numInitialCount.Location = new System.Drawing.Point(18, 500);
            this.numInitialCount.Name = "numInitialCount";
            this.numInitialCount.ReadOnly = true;
            this.numInitialCount.Size = new System.Drawing.Size(130, 20);
            this.numInitialCount.TabIndex = 1;
            this.numInitialCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInitialCount.ValueChanged += new System.EventHandler(this.numInitialCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кол-во мест в семафоре";
            // 
            // lbRunning
            // 
            this.lbRunning.FormattingEnabled = true;
            this.lbRunning.Location = new System.Drawing.Point(18, 37);
            this.lbRunning.Name = "lbRunning";
            this.lbRunning.Size = new System.Drawing.Size(156, 420);
            this.lbRunning.TabIndex = 3;
            this.lbRunning.DoubleClick += new System.EventHandler(this.lbRunning_DoubleClick);
            // 
            // lbRunAndWait
            // 
            this.lbRunAndWait.FormattingEnabled = true;
            this.lbRunAndWait.Location = new System.Drawing.Point(238, 37);
            this.lbRunAndWait.Name = "lbRunAndWait";
            this.lbRunAndWait.Size = new System.Drawing.Size(156, 420);
            this.lbRunAndWait.TabIndex = 4;
            // 
            // lbCreated
            // 
            this.lbCreated.FormattingEnabled = true;
            this.lbCreated.Location = new System.Drawing.Point(465, 37);
            this.lbCreated.Name = "lbCreated";
            this.lbCreated.Size = new System.Drawing.Size(156, 420);
            this.lbCreated.TabIndex = 5;
            this.lbCreated.DoubleClick += new System.EventHandler(this.lbCreated_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Созданные потоки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ожидание";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Выполняющиеся";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 550);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCreated);
            this.Controls.Add(this.lbRunAndWait);
            this.Controls.Add(this.lbRunning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numInitialCount);
            this.Controls.Add(this.btnCreateThread);
            this.Name = "FormMain";
            this.Text = "Work with Semaphore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numInitialCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateThread;
        private System.Windows.Forms.NumericUpDown numInitialCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbRunAndWait;
        private System.Windows.Forms.ListBox lbCreated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ListBox lbRunning;
    }
}

