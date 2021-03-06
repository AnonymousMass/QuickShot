﻿namespace GIFBuilder
{
    partial class GIFBuilderUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.listPreviewImages = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numSeconds = new System.Windows.Forms.NumericUpDown();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdBuild = new System.Windows.Forms.Button();
            this.numTargetHeight = new System.Windows.Forms.NumericUpDown();
            this.numTargetWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BuildProgress = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择图片 :";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(93, 5);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(75, 21);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.Text = "浏览";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // listPreviewImages
            // 
            this.listPreviewImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPreviewImages.Location = new System.Drawing.Point(7, 54);
            this.listPreviewImages.Name = "listPreviewImages";
            this.listPreviewImages.Size = new System.Drawing.Size(478, 226);
            this.listPreviewImages.TabIndex = 3;
            this.listPreviewImages.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "图片列表 :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "每帧间隔 (sec) :";
            // 
            // numSeconds
            // 
            this.numSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numSeconds.DecimalPlaces = 1;
            this.numSeconds.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSeconds.Location = new System.Drawing.Point(183, 314);
            this.numSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSeconds.Name = "numSeconds";
            this.numSeconds.Size = new System.Drawing.Size(57, 21);
            this.numSeconds.TabIndex = 4;
            this.numSeconds.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(410, 341);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdBuild
            // 
            this.cmdBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBuild.Location = new System.Drawing.Point(326, 341);
            this.cmdBuild.Name = "cmdBuild";
            this.cmdBuild.Size = new System.Drawing.Size(75, 21);
            this.cmdBuild.TabIndex = 2;
            this.cmdBuild.Text = "生成";
            this.cmdBuild.UseVisualStyleBackColor = true;
            this.cmdBuild.Click += new System.EventHandler(this.cmdBuild_Click);
            // 
            // numTargetHeight
            // 
            this.numTargetHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numTargetHeight.Location = new System.Drawing.Point(183, 286);
            this.numTargetHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTargetHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTargetHeight.Name = "numTargetHeight";
            this.numTargetHeight.Size = new System.Drawing.Size(57, 21);
            this.numTargetHeight.TabIndex = 4;
            this.numTargetHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // numTargetWidth
            // 
            this.numTargetWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numTargetWidth.Location = new System.Drawing.Point(324, 286);
            this.numTargetWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTargetWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTargetWidth.Name = "numTargetWidth";
            this.numTargetWidth.Size = new System.Drawing.Size(57, 21);
            this.numTargetWidth.TabIndex = 4;
            this.numTargetWidth.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "高(px) :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "宽(px) :";
            // 
            // BuildProgress
            // 
            this.BuildProgress.Location = new System.Drawing.Point(7, 341);
            this.BuildProgress.Minimum = 1;
            this.BuildProgress.Name = "BuildProgress";
            this.BuildProgress.Size = new System.Drawing.Size(302, 21);
            this.BuildProgress.TabIndex = 6;
            this.BuildProgress.Value = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "目标图像大小:";
            // 
            // GIFBuilderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 367);
            this.Controls.Add(this.BuildProgress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numTargetWidth);
            this.Controls.Add(this.numTargetHeight);
            this.Controls.Add(this.numSeconds);
            this.Controls.Add(this.listPreviewImages);
            this.Controls.Add(this.cmdBuild);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 395);
            this.Name = "GIFBuilderUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIF生成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GIFBuilderUI_FormClosing);
            this.Load += new System.EventHandler(this.GIFBuilderUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GIFBuilderUI_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.ListView listPreviewImages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSeconds;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdBuild;
        private System.Windows.Forms.NumericUpDown numTargetHeight;
        private System.Windows.Forms.NumericUpDown numTargetWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar BuildProgress;
        private System.Windows.Forms.Label label4;
    }
}