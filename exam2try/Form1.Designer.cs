namespace exam2try
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
            mainPanel = new Panel();
            saveBT = new Button();
            currencyDG = new DataGridView();
            convertBT = new Button();
            currencyResultCB = new ComboBox();
            currencyResultLB = new Label();
            currencyCB = new ComboBox();
            currencyTB = new TextBox();
            name = new DataGridViewTextBoxColumn();
            reduction = new DataGridViewTextBoxColumn();
            convert = new DataGridViewTextBoxColumn();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)currencyDG).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.AutoScroll = true;
            mainPanel.Controls.Add(saveBT);
            mainPanel.Controls.Add(currencyDG);
            mainPanel.Controls.Add(convertBT);
            mainPanel.Controls.Add(currencyResultCB);
            mainPanel.Controls.Add(currencyResultLB);
            mainPanel.Controls.Add(currencyCB);
            mainPanel.Controls.Add(currencyTB);
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 5;
            // 
            // saveBT
            // 
            saveBT.Location = new Point(530, 227);
            saveBT.Name = "saveBT";
            saveBT.Size = new Size(267, 29);
            saveBT.TabIndex = 11;
            saveBT.Text = "Сохранить список валюты в файл";
            saveBT.UseVisualStyleBackColor = true;
            saveBT.Click += saveBT_Click;
            // 
            // currencyDG
            // 
            currencyDG.AllowUserToAddRows = false;
            currencyDG.AllowUserToDeleteRows = false;
            currencyDG.AllowUserToResizeColumns = false;
            currencyDG.AllowUserToResizeRows = false;
            currencyDG.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            currencyDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            currencyDG.Columns.AddRange(new DataGridViewColumn[] { name, reduction, convert });
            currencyDG.Location = new Point(0, 262);
            currencyDG.Name = "currencyDG";
            currencyDG.RowHeadersWidth = 51;
            currencyDG.RowTemplate.Height = 29;
            currencyDG.Size = new Size(800, 188);
            currencyDG.TabIndex = 10;
            // 
            // convertBT
            // 
            convertBT.Location = new Point(253, 163);
            convertBT.Name = "convertBT";
            convertBT.Size = new Size(219, 29);
            convertBT.TabIndex = 9;
            convertBT.Text = "Конвертировать валюту";
            convertBT.UseVisualStyleBackColor = true;
            convertBT.Click += convertBT_Click;
            // 
            // currencyResultCB
            // 
            currencyResultCB.FormattingEnabled = true;
            currencyResultCB.Location = new Point(517, 101);
            currencyResultCB.Name = "currencyResultCB";
            currencyResultCB.Size = new Size(151, 28);
            currencyResultCB.TabIndex = 8;
            // 
            // currencyResultLB
            // 
            currencyResultLB.AutoSize = true;
            currencyResultLB.Location = new Point(517, 52);
            currencyResultLB.Name = "currencyResultLB";
            currencyResultLB.Size = new Size(233, 20);
            currencyResultLB.TabIndex = 7;
            currencyResultLB.Text = "Сдесь будет результат перевода";
            // 
            // currencyCB
            // 
            currencyCB.FormattingEnabled = true;
            currencyCB.Location = new Point(62, 101);
            currencyCB.Name = "currencyCB";
            currencyCB.Size = new Size(151, 28);
            currencyCB.TabIndex = 6;
            // 
            // currencyTB
            // 
            currencyTB.Location = new Point(62, 49);
            currencyTB.Name = "currencyTB";
            currencyTB.Size = new Size(151, 27);
            currencyTB.TabIndex = 5;
            // 
            // name
            // 
            name.Frozen = true;
            name.HeaderText = "Название валюты";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 250;
            // 
            // reduction
            // 
            reduction.Frozen = true;
            reduction.HeaderText = "Сокращение названия валюты";
            reduction.MinimumWidth = 6;
            reduction.Name = "reduction";
            reduction.ReadOnly = true;
            reduction.Width = 250;
            // 
            // convert
            // 
            convert.Frozen = true;
            convert.HeaderText = "Курс относительно рубля";
            convert.MinimumWidth = 6;
            convert.Name = "convert";
            convert.Width = 250;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPanel);
            Name = "Form1";
            Text = "Form1";
            Resize += Form1_Resize;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)currencyDG).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button convertBT;
        private ComboBox currencyResultCB;
        private Label currencyResultLB;
        private ComboBox currencyCB;
        private TextBox currencyTB;
        private DataGridView currencyDG;
        private Button saveBT;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn reduction;
        private DataGridViewTextBoxColumn convert;
    }
}