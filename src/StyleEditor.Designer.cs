namespace Nodepad
{
    partial class StyleEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleEditor));
            this.stylePreviewBox = new System.Windows.Forms.RichTextBox();
            this.fontListBox = new System.Windows.Forms.ListBox();
            this.labelFont = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.fontSizeBox = new System.Windows.Forms.NumericUpDown();
            this.styleColorButton = new System.Windows.Forms.Button();
            this.styleColorDialog = new System.Windows.Forms.ColorDialog();
            this.labelColor = new System.Windows.Forms.Label();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.styleListBox = new System.Windows.Forms.ListBox();
            this.addStyleButton = new System.Windows.Forms.Button();
            this.moveStyleUpButton = new System.Windows.Forms.Button();
            this.removeStyleButton = new System.Windows.Forms.Button();
            this.labelPreview = new System.Windows.Forms.Label();
            this.moveStyleDownButton = new System.Windows.Forms.Button();
            this.styleNameTextBox = new System.Windows.Forms.TextBox();
            this.labelStyleName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // stylePreviewBox
            // 
            this.stylePreviewBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.stylePreviewBox.Location = new System.Drawing.Point(196, 205);
            this.stylePreviewBox.Name = "stylePreviewBox";
            this.stylePreviewBox.ReadOnly = true;
            this.stylePreviewBox.Size = new System.Drawing.Size(269, 65);
            this.stylePreviewBox.TabIndex = 10;
            this.stylePreviewBox.Text = "The quicker blue cat catches the lazy dog chasing the quick brown fox, and jumps " +
                "into a tree.";
            // 
            // fontListBox
            // 
            this.fontListBox.FormattingEnabled = true;
            this.fontListBox.Location = new System.Drawing.Point(196, 62);
            this.fontListBox.Name = "fontListBox";
            this.fontListBox.Size = new System.Drawing.Size(120, 95);
            this.fontListBox.TabIndex = 6;
            this.fontListBox.SelectedIndexChanged += new System.EventHandler(this.fontListBox_SelectedIndexChanged);
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(193, 45);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(28, 13);
            this.labelFont.TabIndex = 14;
            this.labelFont.Text = "Font";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(322, 64);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(27, 13);
            this.labelSize.TabIndex = 13;
            this.labelSize.Text = "Size";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(322, 91);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(44, 13);
            this.labelPosition.TabIndex = 12;
            this.labelPosition.Text = "Position";
            // 
            // fontSizeBox
            // 
            this.fontSizeBox.Location = new System.Drawing.Point(372, 62);
            this.fontSizeBox.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.fontSizeBox.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.fontSizeBox.Name = "fontSizeBox";
            this.fontSizeBox.Size = new System.Drawing.Size(92, 20);
            this.fontSizeBox.TabIndex = 7;
            this.fontSizeBox.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontSizeBox.ValueChanged += new System.EventHandler(this.fontSizeBox_ValueChanged);
            // 
            // styleColorButton
            // 
            this.styleColorButton.BackColor = System.Drawing.Color.Black;
            this.styleColorButton.Location = new System.Drawing.Point(441, 115);
            this.styleColorButton.Name = "styleColorButton";
            this.styleColorButton.Size = new System.Drawing.Size(23, 23);
            this.styleColorButton.TabIndex = 9;
            this.styleColorButton.UseVisualStyleBackColor = false;
            this.styleColorButton.Click += new System.EventHandler(this.styleColorButton_Click);
            // 
            // styleColorDialog
            // 
            this.styleColorDialog.AnyColor = true;
            this.styleColorDialog.FullOpen = true;
            this.styleColorDialog.SolidColorOnly = true;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(322, 120);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(31, 13);
            this.labelColor.TabIndex = 11;
            this.labelColor.Text = "Color";
            // 
            // positionComboBox
            // 
            this.positionComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.positionComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.positionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Location = new System.Drawing.Point(372, 88);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(92, 21);
            this.positionComboBox.TabIndex = 8;
            this.positionComboBox.SelectedIndexChanged += new System.EventHandler(this.positionComboBox_SelectedIndexChanged);
            // 
            // styleListBox
            // 
            this.styleListBox.DisplayMember = "Name";
            this.styleListBox.FormattingEnabled = true;
            this.styleListBox.Location = new System.Drawing.Point(12, 12);
            this.styleListBox.Name = "styleListBox";
            this.styleListBox.Size = new System.Drawing.Size(120, 264);
            this.styleListBox.TabIndex = 0;
            this.styleListBox.ValueMember = "Name";
            this.styleListBox.SelectedIndexChanged += new System.EventHandler(this.styleListBox_SelectedIndexChanged);
            // 
            // addStyleButton
            // 
            this.addStyleButton.Image = ((System.Drawing.Image)(resources.GetObject("addStyleButton.Image")));
            this.addStyleButton.Location = new System.Drawing.Point(140, 13);
            this.addStyleButton.Name = "addStyleButton";
            this.addStyleButton.Size = new System.Drawing.Size(26, 26);
            this.addStyleButton.TabIndex = 1;
            this.addStyleButton.UseVisualStyleBackColor = true;
            this.addStyleButton.Click += new System.EventHandler(this.addStyleButton_Click);
            // 
            // moveStyleUpButton
            // 
            this.moveStyleUpButton.Image = ((System.Drawing.Image)(resources.GetObject("moveStyleUpButton.Image")));
            this.moveStyleUpButton.Location = new System.Drawing.Point(140, 45);
            this.moveStyleUpButton.Name = "moveStyleUpButton";
            this.moveStyleUpButton.Size = new System.Drawing.Size(26, 26);
            this.moveStyleUpButton.TabIndex = 2;
            this.moveStyleUpButton.UseVisualStyleBackColor = true;
            this.moveStyleUpButton.Click += new System.EventHandler(this.moveStyleUpButton_Click);
            // 
            // removeStyleButton
            // 
            this.removeStyleButton.Image = ((System.Drawing.Image)(resources.GetObject("removeStyleButton.Image")));
            this.removeStyleButton.Location = new System.Drawing.Point(140, 109);
            this.removeStyleButton.Name = "removeStyleButton";
            this.removeStyleButton.Size = new System.Drawing.Size(26, 26);
            this.removeStyleButton.TabIndex = 4;
            this.removeStyleButton.UseVisualStyleBackColor = true;
            this.removeStyleButton.Click += new System.EventHandler(this.removeStyleButton_Click);
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Location = new System.Drawing.Point(193, 189);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(45, 13);
            this.labelPreview.TabIndex = 16;
            this.labelPreview.Text = "Preview";
            // 
            // moveStyleDownButton
            // 
            this.moveStyleDownButton.Image = ((System.Drawing.Image)(resources.GetObject("moveStyleDownButton.Image")));
            this.moveStyleDownButton.Location = new System.Drawing.Point(140, 77);
            this.moveStyleDownButton.Name = "moveStyleDownButton";
            this.moveStyleDownButton.Size = new System.Drawing.Size(26, 26);
            this.moveStyleDownButton.TabIndex = 3;
            this.moveStyleDownButton.UseVisualStyleBackColor = true;
            this.moveStyleDownButton.Click += new System.EventHandler(this.moveStyleDownButton_Click);
            // 
            // styleNameTextBox
            // 
            this.styleNameTextBox.Location = new System.Drawing.Point(260, 10);
            this.styleNameTextBox.Name = "styleNameTextBox";
            this.styleNameTextBox.Size = new System.Drawing.Size(204, 20);
            this.styleNameTextBox.TabIndex = 5;
            this.styleNameTextBox.TextChanged += new System.EventHandler(this.styleNameTextBox_TextChanged);
            // 
            // labelStyleName
            // 
            this.labelStyleName.AutoSize = true;
            this.labelStyleName.Location = new System.Drawing.Point(193, 13);
            this.labelStyleName.Name = "labelStyleName";
            this.labelStyleName.Size = new System.Drawing.Size(61, 13);
            this.labelStyleName.TabIndex = 15;
            this.labelStyleName.Text = "Style Name";
            // 
            // StyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 284);
            this.Controls.Add(this.labelStyleName);
            this.Controls.Add(this.styleNameTextBox);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.removeStyleButton);
            this.Controls.Add(this.moveStyleDownButton);
            this.Controls.Add(this.moveStyleUpButton);
            this.Controls.Add(this.addStyleButton);
            this.Controls.Add(this.styleListBox);
            this.Controls.Add(this.positionComboBox);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.styleColorButton);
            this.Controls.Add(this.fontSizeBox);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.fontListBox);
            this.Controls.Add(this.stylePreviewBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StyleEditor";
            this.ShowInTaskbar = false;
            this.Text = "Nodepad - Style Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.styleEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.Label labelStyleName;
        private System.Windows.Forms.RichTextBox stylePreviewBox;
        private System.Windows.Forms.ListBox fontListBox;
        private System.Windows.Forms.NumericUpDown fontSizeBox;
        private System.Windows.Forms.Button styleColorButton;
        private System.Windows.Forms.ColorDialog styleColorDialog;
        private System.Windows.Forms.ComboBox positionComboBox;
        private System.Windows.Forms.ListBox styleListBox;
        private System.Windows.Forms.Button addStyleButton;
        private System.Windows.Forms.Button moveStyleUpButton;
        private System.Windows.Forms.Button removeStyleButton;
        private System.Windows.Forms.Button moveStyleDownButton;
        private System.Windows.Forms.TextBox styleNameTextBox;
    }
}