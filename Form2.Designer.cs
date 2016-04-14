﻿namespace SaveGameFiles
{
  partial class ObsoleteListItemsDlg
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
      this.LeaveItemsInListButton = new System.Windows.Forms.Button();
      this.RemoveFromListButton = new System.Windows.Forms.Button();
      this.EntryList = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // LeaveItemsInListButton
      // 
      this.LeaveItemsInListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.LeaveItemsInListButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.LeaveItemsInListButton.Location = new System.Drawing.Point(12, 290);
      this.LeaveItemsInListButton.Name = "LeaveItemsInListButton";
      this.LeaveItemsInListButton.Size = new System.Drawing.Size(98, 36);
      this.LeaveItemsInListButton.TabIndex = 2;
      this.LeaveItemsInListButton.Text = "Do NOT Remove Items from List";
      this.LeaveItemsInListButton.UseVisualStyleBackColor = false;
      this.LeaveItemsInListButton.Click += new System.EventHandler(this.LeaveItemsInListButton_Click);
      // 
      // RemoveFromListButton
      // 
      this.RemoveFromListButton.BackColor = System.Drawing.Color.Yellow;
      this.RemoveFromListButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.RemoveFromListButton.Location = new System.Drawing.Point(209, 290);
      this.RemoveFromListButton.Name = "RemoveFromListButton";
      this.RemoveFromListButton.Size = new System.Drawing.Size(98, 36);
      this.RemoveFromListButton.TabIndex = 1;
      this.RemoveFromListButton.Text = "Remove Items from List";
      this.RemoveFromListButton.UseVisualStyleBackColor = false;
      this.RemoveFromListButton.Click += new System.EventHandler(this.RemoveFromListButton_Click);
      // 
      // EntryList
      // 
      this.EntryList.FormattingEnabled = true;
      this.EntryList.Location = new System.Drawing.Point(12, 54);
      this.EntryList.Name = "EntryList";
      this.EntryList.ScrollAlwaysVisible = true;
      this.EntryList.Size = new System.Drawing.Size(295, 212);
      this.EntryList.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(61, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(171, 16);
      this.label1.TabIndex = 4;
      this.label1.Text = "The following files are not in";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(66, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(164, 16);
      this.label2.TabIndex = 5;
      this.label2.Text = "the backup save file folder";
      // 
      // ObsoleteListItemsDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(319, 376);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.EntryList);
      this.Controls.Add(this.LeaveItemsInListButton);
      this.Controls.Add(this.RemoveFromListButton);
      this.Name = "ObsoleteListItemsDlg";
      this.Text = "Entries Not Found";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button LeaveItemsInListButton;
    private System.Windows.Forms.Button RemoveFromListButton;
    private System.Windows.Forms.ListBox EntryList;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}