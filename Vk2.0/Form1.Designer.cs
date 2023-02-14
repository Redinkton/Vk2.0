namespace Vk2._0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Upload = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Likes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Proxy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(907, 61);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(160, 56);
            this.Upload.TabIndex = 0;
            this.Upload.Text = "Upload Groups";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(907, 273);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(160, 52);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(907, 344);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(160, 58);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Link
            // 
            this.Link.HeaderText = "Ссылка";
            this.Link.MinimumWidth = 8;
            this.Link.Name = "Link";
            this.Link.Width = 250;
            // 
            // Likes
            // 
            this.Likes.HeaderText = "Лайки";
            this.Likes.MinimumWidth = 8;
            this.Likes.Name = "Likes";
            this.Likes.Width = 70;
            // 
            // Text
            // 
            this.Text.HeaderText = "Текст";
            this.Text.MinimumWidth = 8;
            this.Text.Name = "Text";
            this.Text.Width = 350;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.Width = 80;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Text,
            this.Likes,
            this.Link});
            this.dataGridView1.Location = new System.Drawing.Point(40, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(815, 404);
            this.dataGridView1.TabIndex = 3;
            // 
            // Proxy
            // 
            this.Proxy.Location = new System.Drawing.Point(907, 140);
            this.Proxy.Name = "Proxy";
            this.Proxy.Size = new System.Drawing.Size(160, 59);
            this.Proxy.TabIndex = 4;
            this.Proxy.Text = "Add Proxy";
            this.Proxy.UseVisualStyleBackColor = true;
            this.Proxy.Click += new System.EventHandler(this.Proxy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 450);
            this.Controls.Add(this.Proxy);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Upload);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button Upload;
        private Button Start;
        private Button Stop;
        private OpenFileDialog openFileDialog1;
        private DataGridViewTextBoxColumn Link;
        private DataGridViewTextBoxColumn Likes;
        private DataGridViewTextBoxColumn Text;
        private DataGridViewTextBoxColumn Date;
        private DataGridView dataGridView1;
        private Button Proxy;
    }
}