﻿using System;

namespace RootedPhylogeneticTreeCalculator
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
            this.graphPanel = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeCheckLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rfDistanceLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.compLabel = new System.Windows.Forms.Label();
            this.rozbicieButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rozbicieLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.Location = new System.Drawing.Point(154, 13);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(448, 680);
            this.graphPanel.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(12, 12);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(136, 22);
            this.loadFileButton.TabIndex = 4;
            this.loadFileButton.Text = "Wczytaj drzewa";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Stwórz drzewo konsensusu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 179);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "70";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Poprawne:";
            // 
            // treeCheckLabel
            // 
            this.treeCheckLabel.AutoSize = true;
            this.treeCheckLabel.Location = new System.Drawing.Point(72, 255);
            this.treeCheckLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.treeCheckLabel.Name = "treeCheckLabel";
            this.treeCheckLabel.Size = new System.Drawing.Size(29, 13);
            this.treeCheckLabel.TabIndex = 9;
            this.treeCheckLabel.Text = "Brak";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 344);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Odległosc RF:";
            // 
            // rfDistanceLabel
            // 
            this.rfDistanceLabel.AutoSize = true;
            this.rfDistanceLabel.Location = new System.Drawing.Point(11, 363);
            this.rfDistanceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rfDistanceLabel.Name = "rfDistanceLabel";
            this.rfDistanceLabel.Size = new System.Drawing.Size(29, 13);
            this.rfDistanceLabel.TabIndex = 1;
            this.rfDistanceLabel.Text = "Brak";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(136, 95);
            this.listBox1.TabIndex = 10;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Sprawdź";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 142);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "pokaż klastry";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(90, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Sprawdź";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Zgodność:";
            // 
            // compLabel
            // 
            this.compLabel.AutoSize = true;
            this.compLabel.Location = new System.Drawing.Point(14, 311);
            this.compLabel.Name = "compLabel";
            this.compLabel.Size = new System.Drawing.Size(28, 13);
            this.compLabel.TabIndex = 16;
            this.compLabel.Text = "brak";
            // 
            // rozbicieButton
            // 
            this.rozbicieButton.Location = new System.Drawing.Point(12, 389);
            this.rozbicieButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rozbicieButton.Name = "rozbicieButton";
            this.rozbicieButton.Size = new System.Drawing.Size(113, 23);
            this.rozbicieButton.TabIndex = 19;
            this.rozbicieButton.Text = "Sprawdz rozbicie krawedzi";
            this.rozbicieButton.UseVisualStyleBackColor = true;
            this.rozbicieButton.Click += new System.EventHandler(this.rozbicieKrawedzi);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 419);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Rozbite podzbiory";
            // 
            // rozbicieLabel
            // 
            this.rozbicieLabel.AutoSize = true;
            this.rozbicieLabel.Location = new System.Drawing.Point(11, 439);
            this.rozbicieLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.rozbicieLabel.Name = "rozbicieLabel";
            this.rozbicieLabel.Size = new System.Drawing.Size(0, 13);
            this.rozbicieLabel.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 449);
            this.Controls.Add(this.rozbicieLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rozbicieButton);
            this.Controls.Add(this.compLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.rfDistanceLabel);
            this.Controls.Add(this.treeCheckLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.graphPanel);
            this.Name = "Form1";
            this.Text = "„Kalkulator” drzew filogenetycznych ukorzenionych";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label treeCheckLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label rfDistanceLabel;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label compLabel;
        private System.Windows.Forms.Button rozbicieButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label rozbicieLabel;
    }
}

