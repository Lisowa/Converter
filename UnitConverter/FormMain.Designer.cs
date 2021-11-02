
namespace UnitConverter
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
            this.comboBoxСategory = new System.Windows.Forms.ComboBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.comboBoxUnitFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.comboBoxUnitTo = new System.Windows.Forms.ComboBox();
            this.checkBoxToAllUnits = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxСategory
            // 
            this.comboBoxСategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxСategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxСategory.FormattingEnabled = true;
            this.comboBoxСategory.Location = new System.Drawing.Point(44, 25);
            this.comboBoxСategory.Name = "comboBoxСategory";
            this.comboBoxСategory.Size = new System.Drawing.Size(447, 28);
            this.comboBoxСategory.TabIndex = 1;
            this.comboBoxСategory.SelectedValueChanged += new System.EventHandler(this.comboBoxСategory_SelectedValueChanged);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalculate.Location = new System.Drawing.Point(44, 163);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(211, 34);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Рассчитать";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxUnitFrom
            // 
            this.comboBoxUnitFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnitFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUnitFrom.FormattingEnabled = true;
            this.comboBoxUnitFrom.Location = new System.Drawing.Point(44, 112);
            this.comboBoxUnitFrom.Name = "comboBoxUnitFrom";
            this.comboBoxUnitFrom.Size = new System.Drawing.Size(211, 28);
            this.comboBoxUnitFrom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "=";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFrom.Location = new System.Drawing.Point(44, 80);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(211, 26);
            this.textBoxFrom.TabIndex = 8;
            this.textBoxFrom.Text = "1";
            // 
            // textBoxTo
            // 
            this.textBoxTo.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTo.Enabled = false;
            this.textBoxTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTo.ForeColor = System.Drawing.SystemColors.Control;
            this.textBoxTo.Location = new System.Drawing.Point(280, 80);
            this.textBoxTo.Multiline = true;
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.ReadOnly = true;
            this.textBoxTo.Size = new System.Drawing.Size(211, 26);
            this.textBoxTo.TabIndex = 10;
            // 
            // comboBoxUnitTo
            // 
            this.comboBoxUnitTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnitTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUnitTo.Location = new System.Drawing.Point(280, 112);
            this.comboBoxUnitTo.Name = "comboBoxUnitTo";
            this.comboBoxUnitTo.Size = new System.Drawing.Size(211, 28);
            this.comboBoxUnitTo.TabIndex = 9;
            // 
            // checkBoxToAllUnits
            // 
            this.checkBoxToAllUnits.AutoSize = true;
            this.checkBoxToAllUnits.Location = new System.Drawing.Point(280, 174);
            this.checkBoxToAllUnits.Name = "checkBoxToAllUnits";
            this.checkBoxToAllUnits.Size = new System.Drawing.Size(200, 17);
            this.checkBoxToAllUnits.TabIndex = 12;
            this.checkBoxToAllUnits.Text = "Конвертировать во все величины ";
            this.checkBoxToAllUnits.UseVisualStyleBackColor = true;
            this.checkBoxToAllUnits.CheckedChanged += new System.EventHandler(this.checkBoxToAllUnits_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 226);
            this.Controls.Add(this.checkBoxToAllUnits);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.comboBoxUnitTo);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxUnitFrom);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.comboBoxСategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер физических величин";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.ComboBox comboBoxUnitFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.ComboBox comboBoxUnitTo;
        private System.Windows.Forms.ComboBox comboBoxСategory;
        private System.Windows.Forms.CheckBox checkBoxToAllUnits;
    }
}

