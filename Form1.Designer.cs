
namespace Converter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbValue = new System.Windows.Forms.TextBox();
            this.tbConvertedValue = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.epUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.epValue = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFrom = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSwap = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbSubtitle = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.epUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(24, 165);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(164, 20);
            this.tbValue.TabIndex = 0;
            // 
            // tbConvertedValue
            // 
            this.tbConvertedValue.BackColor = System.Drawing.SystemColors.Window;
            this.tbConvertedValue.Enabled = false;
            this.tbConvertedValue.Location = new System.Drawing.Point(321, 165);
            this.tbConvertedValue.Name = "tbConvertedValue";
            this.tbConvertedValue.ReadOnly = true;
            this.tbConvertedValue.Size = new System.Drawing.Size(164, 20);
            this.tbConvertedValue.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(213, 160);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(79, 28);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // cbFrom
            // 
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Location = new System.Drawing.Point(24, 209);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(164, 21);
            this.cbFrom.TabIndex = 4;
            // 
            // cbTo
            // 
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(321, 209);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(164, 21);
            this.cbTo.TabIndex = 5;
            // 
            // cbUnit
            // 
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(195, 110);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(118, 21);
            this.cbUnit.TabIndex = 6;
            this.cbUnit.SelectedIndexChanged += new System.EventHandler(this.cbUnit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose a type of unit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Converted value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "To";
            // 
            // epUnit
            // 
            this.epUnit.ContainerControl = this;
            // 
            // epValue
            // 
            this.epValue.ContainerControl = this;
            // 
            // epTo
            // 
            this.epTo.ContainerControl = this;
            // 
            // epFrom
            // 
            this.epFrom.ContainerControl = this;
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(213, 204);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(79, 28);
            this.btnSwap.TabIndex = 12;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(156, 29);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(182, 42);
            this.lbTitle.TabIndex = 13;
            this.lbTitle.Text = "Converter";
            // 
            // lbSubtitle
            // 
            this.lbSubtitle.AutoSize = true;
            this.lbSubtitle.Font = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubtitle.Location = new System.Drawing.Point(277, 66);
            this.lbSubtitle.Name = "lbSubtitle";
            this.lbSubtitle.Size = new System.Drawing.Size(105, 15);
            this.lbSubtitle.TabIndex = 14;
            this.lbSubtitle.Text = "by Filip Danilovski";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 285);
            this.Controls.Add(this.lbSubtitle);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.cbTo);
            this.Controls.Add(this.cbFrom);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.tbConvertedValue);
            this.Controls.Add(this.tbValue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Converter";
            ((System.ComponentModel.ISupportInitialize)(this.epUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.TextBox tbConvertedValue;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epUnit;
        private System.Windows.Forms.ErrorProvider epValue;
        private System.Windows.Forms.ErrorProvider epTo;
        private System.Windows.Forms.ErrorProvider epFrom;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbSubtitle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

