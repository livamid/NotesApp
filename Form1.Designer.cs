namespace Notes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBoxTitle = new TextBox();
            richTextBoxNote = new RichTextBox();
            listBoxNotes = new ListBox();
            btnSearch = new Button();
            textBoxSearch = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnExportPDF = new Button();
            btnClearSelection = new Button();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // textBoxTitle
            // 
            textBoxTitle.BackColor = Color.WhiteSmoke;
            textBoxTitle.Location = new Point(428, 103);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(335, 23);
            textBoxTitle.TabIndex = 0;
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.BackColor = Color.WhiteSmoke;
            richTextBoxNote.Location = new Point(428, 148);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(335, 254);
            richTextBoxNote.TabIndex = 1;
            richTextBoxNote.Text = "";
            // 
            // listBoxNotes
            // 
            listBoxNotes.BackColor = Color.WhiteSmoke;
            listBoxNotes.FormattingEnabled = true;
            listBoxNotes.ItemHeight = 15;
            listBoxNotes.Location = new Point(29, 148);
            listBoxNotes.Name = "listBoxNotes";
            listBoxNotes.Size = new Size(350, 304);
            listBoxNotes.TabIndex = 2;
            listBoxNotes.SelectedIndexChanged += listBoxNotes_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.WhiteSmoke;
            btnSearch.Location = new Point(285, 102);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = Color.WhiteSmoke;
            textBoxSearch.Location = new Point(29, 102);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(250, 23);
            textBoxSearch.TabIndex = 4;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.WhiteSmoke;
            btnAdd.Location = new Point(428, 412);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(335, 40);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.WhiteSmoke;
            btnUpdate.Location = new Point(428, 467);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 40);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.WhiteSmoke;
            btnDelete.Location = new Point(548, 467);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 40);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExportPDF
            // 
            btnExportPDF.BackColor = Color.WhiteSmoke;
            btnExportPDF.Location = new Point(658, 467);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(105, 40);
            btnExportPDF.TabIndex = 8;
            btnExportPDF.Text = "Экспорт в PDF";
            btnExportPDF.UseVisualStyleBackColor = false;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // btnClearSelection
            // 
            btnClearSelection.BackColor = Color.WhiteSmoke;
            btnClearSelection.Location = new Point(29, 467);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(130, 40);
            btnClearSelection.TabIndex = 9;
            btnClearSelection.Text = "Отменить выбор";
            btnClearSelection.UseVisualStyleBackColor = false;
            btnClearSelection.Click += btnClearSelection_Click;
            // 
            // button1
            // 
            button1.Location = new Point(-100, -100);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unispace", 39.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(300, 18);
            label1.Name = "label1";
            label1.Size = new Size(187, 64);
            label1.TabIndex = 11;
            label1.Text = "Notes";
            // 
            // button2
            // 
            button2.BackColor = Color.WhiteSmoke;
            button2.Location = new Point(29, 34);
            button2.Name = "button2";
            button2.Size = new Size(92, 35);
            button2.TabIndex = 12;
            button2.Text = "О нас";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.WhiteSmoke;
            button3.Location = new Point(671, 34);
            button3.Name = "button3";
            button3.Size = new Size(92, 35);
            button3.TabIndex = 12;
            button3.Text = "Выйти";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(800, 533);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(btnClearSelection);
            Controls.Add(btnExportPDF);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(textBoxSearch);
            Controls.Add(btnSearch);
            Controls.Add(listBoxNotes);
            Controls.Add(richTextBoxNote);
            Controls.Add(textBoxTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Notes";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTitle;
        private RichTextBox richTextBoxNote;
        private ListBox listBoxNotes;
        private Button btnSearch;
        private TextBox textBoxSearch;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnExportPDF;
        private Button btnClearSelection;
        private Button button1;
        private Label label1;
        private Button button2;
        private Button button3;
    }
}
