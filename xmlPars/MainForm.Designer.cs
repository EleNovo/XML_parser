namespace xmlPars
{
    partial class Form
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
            this.choiceB = new System.Windows.Forms.Button();
            this.exportB = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // choiceB
            // 
            this.choiceB.Location = new System.Drawing.Point(12, 324);
            this.choiceB.Name = "choiceB";
            this.choiceB.Size = new System.Drawing.Size(112, 39);
            this.choiceB.TabIndex = 0;
            this.choiceB.Text = "Выбор архива";
            this.choiceB.UseVisualStyleBackColor = true;
            this.choiceB.Click += new System.EventHandler(this.choiceB_Click);
            // 
            // exportB
            // 
            this.exportB.Location = new System.Drawing.Point(130, 324);
            this.exportB.Name = "exportB";
            this.exportB.Size = new System.Drawing.Size(112, 39);
            this.exportB.TabIndex = 0;
            this.exportB.Text = "Выгрузить в Excel";
            this.exportB.UseVisualStyleBackColor = true;
            this.exportB.Visible = false;
            this.exportB.Click += new System.EventHandler(this.exportB_Click);
            // 
            // Table
            // 
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(12, 12);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(810, 302);
            this.Table.TabIndex = 1;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(834, 371);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.exportB);
            this.Controls.Add(this.choiceB);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Парсер";
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button choiceB;
        private System.Windows.Forms.Button exportB;
        private System.Windows.Forms.DataGridView Table;
    }
}

