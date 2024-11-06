using KartLauncher.Properties;
using System;
using System.Windows.Forms;

namespace KartLauncher.Data.Forms
{
    partial class Launcher
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            Start_Button = new Button();
            GetKart_Button = new Button();
            label_DeveloperName = new Label();
            MinorVersion = new Label();
            SuspendLayout();
            // 
            // Start_Button
            // 
            Start_Button.Location = new System.Drawing.Point(19, 20);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new System.Drawing.Size(114, 23);
            Start_Button.TabIndex = 364;
            Start_Button.Text = "启动游戏";
            Start_Button.UseVisualStyleBackColor = true;
            Start_Button.Click += new EventHandler(Start_Button_Click);
            // 
            // GetKart_Button
            // 
            GetKart_Button.Location = new System.Drawing.Point(19, 49);
            GetKart_Button.Name = "GetKart_Button";
            GetKart_Button.Size = new System.Drawing.Size(114, 23);
            GetKart_Button.TabIndex = 365;
            GetKart_Button.Text = "添加道具";
            GetKart_Button.UseVisualStyleBackColor = true;
            GetKart_Button.Click += new EventHandler(GetKart_Button_Click);
            // 
            // label_DeveloperName
            // 
            label_DeveloperName.AutoSize = true;
            label_DeveloperName.BackColor = System.Drawing.SystemColors.Control;
            label_DeveloperName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label_DeveloperName.ForeColor = System.Drawing.Color.Blue;
            label_DeveloperName.Location = new System.Drawing.Point(2, 160);
            label_DeveloperName.Name = "label_DeveloperName";
            label_DeveloperName.Size = new System.Drawing.Size(53, 12);
            label_DeveloperName.TabIndex = 367;
            label_DeveloperName.Text = "Version:";
            // 
            // MinorVersion
            // 
            MinorVersion.AutoSize = true;
            MinorVersion.BackColor = System.Drawing.SystemColors.Control;
            MinorVersion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            MinorVersion.ForeColor = System.Drawing.Color.Red;
            MinorVersion.Location = new System.Drawing.Point(55, 160);
            MinorVersion.Name = "MinorVersion";
            MinorVersion.Size = new System.Drawing.Size(10, 12);
            MinorVersion.TabIndex = 367;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(257, 180);
            Controls.Add(MinorVersion);
            Controls.Add(label_DeveloperName);
            Controls.Add(GetKart_Button);
            Controls.Add(Start_Button);
            Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.icon;
            MaximizeBox = false;
            Name = "Launcher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Launcher";
            FormClosing += new FormClosingEventHandler(OnFormClosing);
            Load += new EventHandler(OnLoad);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button Start_Button;
        private Button GetKart_Button;
        private Label label_DeveloperName;
        private Label MinorVersion;
    }
}
