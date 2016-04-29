﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SaveGameFiles
{
  public partial class Form1 : Form
  {
    string SourceSaves = "";
    string BackupSaves = "";

    string DarkSoulsSaveFile = "";
    public string selectedFile = "";

    string currentDocuments = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
    string currentUserName = Environment.UserName;

    public Form1()
    {
      InitializeComponent();

      CListHandler.currentGame = "Dark Souls III";

      CListHandler.Initialize(currentDocuments, currentUserName);
      CListHandler.SetDatFile("_DARKSOULSIII_GameFileInfo.xml");
      CListHandler.LoadGameFileInfo();      
      
      InitializeByGame("Dark Souls III");

      dlgSelectSource.InitialDirectory = CListHandler.gfi.DS3GameFilePath;
      //dlgSelectDestination.InitialDirectory = CListHandler.gfi.DS3SaveGamePath;

      txtSourceFolder.Text = CListHandler.gfi.DS3GameFilePath;
      txtDestinationFolder.Text = CListHandler.gfi.DS3SaveGamePath;
    }

    private string getSelectedGameFilePath(string currentGame)
    {
      if (comboSelectedGame.Text == "Dark Souls")
      {
        return CListHandler.gfi.DS1GameFilePath;
      }
      if (comboSelectedGame.Text == "Dark Souls II")
      {
        return CListHandler.gfi.DS2GameFilePath;
      }
      if (comboSelectedGame.Text == "Dark Souls III")
      {
        return CListHandler.gfi.DS3GameFilePath;
      }
      return "";
    }

    private string getSelectedSaveGamePath(string currentGame)
    {
      if (comboSelectedGame.Text == "Dark Souls")
      {
        return CListHandler.gfi.DS1SaveGamePath;
      }
      if (comboSelectedGame.Text == "Dark Souls II")
      {
        return CListHandler.gfi.DS2SaveGamePath;
      }
      if (comboSelectedGame.Text == "Dark Souls III")
      {
        return CListHandler.gfi.DS3SaveGamePath;
      }
      return "";
    }


    private void btnSource_Click(object sender, EventArgs e)
    {
      dlgSelectSource.Title = "Please identify the game file";
      dlgSelectSource.FileName = "";

      DialogResult r = dlgSelectSource.ShowDialog();

      if (r == DialogResult.OK)
      {
        string fullPath = dlgSelectSource.FileName;
        int lastSlash = fullPath.LastIndexOf('\\');
        string gameFolder = fullPath.Substring(0, 57);

        txtSourceFile.Text = fullPath.Substring(lastSlash + 1);

        if (comboSelectedGame.Text == "Dark Souls")
        {
          CListHandler.gfi.DS1GameFilePath = gameFolder;
        }
        if (comboSelectedGame.Text == "Dark Souls II")
        {
          CListHandler.gfi.DS2GameFilePath = gameFolder;
        }
        if (comboSelectedGame.Text == "Dark Souls III")
        {
          CListHandler.gfi.DS3GameFilePath = gameFolder;
        }

        txtSourceFolder.Text = gameFolder;
      }
    }

    private void btnDestination_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog d = new FolderBrowserDialog();
      d.SelectedPath = getSelectedSaveGamePath(comboSelectedGame.Text);

      DialogResult r = d.ShowDialog();
      if (r == DialogResult.OK)
      {
        if (comboSelectedGame.Text == "Dark Souls")
        {
          CListHandler.gfi.DS1SaveGamePath = d.SelectedPath;
        }
        if (comboSelectedGame.Text == "Dark Souls II")
        {
          CListHandler.gfi.DS2SaveGamePath = d.SelectedPath;
        }
        if (comboSelectedGame.Text == "Dark Souls III")
        {
          CListHandler.gfi.DS3SaveGamePath = d.SelectedPath;
        }
        txtDestinationFolder.Text = d.SelectedPath;

        CListHandler.SetDatFile(GetDatFileBaseName(comboSelectedGame.Text));
        CListHandler.Save();
        updateFileLists(d.SelectedPath);
      }
    }

    private void updateFileLists(string destFolder)
    {
      FileInfo[] fi;
      DirectoryInfo diSource = new DirectoryInfo(txtSourceFolder.Text);
      DirectoryInfo diDest = new DirectoryInfo(txtDestinationFolder.Text);

      listSourceFiles.Items.Clear();
      listDestinationFiles.Items.Clear();

      fi = diSource.GetFiles();
      foreach (FileInfo f in fi)
      {
        if (f.Name.Contains("GameFileInfo"))
          continue;
        listSourceFiles.Items.Add(f.Name);
      }

      fi = diDest.GetFiles();
      foreach (FileInfo f in fi)
      {
        if (f.Name.Contains("GameFileInfo"))
          continue;
        listDestinationFiles.Items.Add(f.Name);
      }

      CListHandler.ValidateFiles(listSourceFiles.Items, listDestinationFiles.Items);
    }

    private void radioSave_CheckedChanged(object sender, EventArgs e)
    {
      if (radioSave.Checked)
      {
        radioRestore.Checked = false;
        dlgSelectSource.InitialDirectory = SourceSaves;
        //dlgSelectDestination.InitialDirectory = BackupSaves;

        txtSourceFile.Text = DarkSoulsSaveFile;
        txtDestinationFile.Text = "";

        txtSourceFolder.Text = SourceSaves;
        txtDestinationFolder.Text = BackupSaves;
      }
      else
      {
        radioRestore.Checked = true;
        dlgSelectSource.InitialDirectory = BackupSaves;
        //dlgSelectDestination.InitialDirectory = SourceSaves;

        txtSourceFile.Text = "";
        txtDestinationFile.Text = DarkSoulsSaveFile;

        txtSourceFolder.Text = BackupSaves;
        txtDestinationFolder.Text = SourceSaves;
      }

      updateFileLists(BackupSaves);
    }

    private void radioRestore_CheckedChanged(object sender, EventArgs e)
    {      
      if (radioRestore.Checked)
      {
        radioSave.Checked = false;
        dlgSelectSource.InitialDirectory = BackupSaves;
        //dlgSelectDestination.InitialDirectory = SourceSaves;

        txtSourceFile.Text = "";
        txtDestinationFile.Text = DarkSoulsSaveFile;

        txtSourceFolder.Text = BackupSaves;
        txtDestinationFolder.Text = SourceSaves;
      }
      else
      {
        radioSave.Checked = true;
        dlgSelectSource.InitialDirectory = SourceSaves;
        //dlgSelectDestination.InitialDirectory = BackupSaves;

        txtSourceFile.Text = DarkSoulsSaveFile;
        txtDestinationFile.Text = "";

        txtSourceFolder.Text = SourceSaves;
        txtDestinationFolder.Text = BackupSaves;
      }

      updateFileLists(BackupSaves);
    }

    private void dlgSelectSource_FileOk(object sender, CancelEventArgs e)
    {
      string fullPath = dlgSelectSource.FileName;
      int lastSlash = fullPath.LastIndexOf('\\');

      txtSourceFile.Text = fullPath.Substring(lastSlash + 1);
    }

    //private void dlgSelectDestination_FileOk(object sender, CancelEventArgs e)
    //{
    //  string fullPath = dlgSelectDestination.FileName;
    //  int lastSlash = fullPath.LastIndexOf('\\');

    //  txtDestinationFile.Text = fullPath.Substring(lastSlash + 1);
    //}

    private void listSourceFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (null != listSourceFiles.SelectedItem)
      {
        try
        {
          txtSourceFile.Text = listSourceFiles.SelectedItem.ToString();
          selectedFile = txtSourceFile.Text;
          txtSelectedFile.Text = selectedFile;

          txtComments.Text = CListHandler.FindbyFilename(txtSourceFile.Text).comments;
        }
        catch (Exception ex)
        {
          string iex = "";
          if (ex.InnerException != null)
          {
            iex = "\n" + ex.InnerException.ToString();
          }
          MessageBox.Show("Exception (listSourceFiles_SelectedIndexChanged):\n" +
                           ex.Message.ToString() + iex);
        }
      }
    }

    private void btnDoIt_Click(object sender, EventArgs e)
    {
      if ((txtSourceFile.Text.Length > 0) && (txtDestinationFile.Text.Length > 0))
      {
        DialogResult msgStatus;
        String SaveOrRestore;

        if (radioSave.Checked == true)
        {
          SaveOrRestore = "SAVE ";
        }
        else
        {
          SaveOrRestore = "RESTORE ";
        }

        string msgText = SaveOrRestore + txtSourceFile.Text + " to " + txtDestinationFile.Text + "?";
        msgStatus = MessageBox.Show(msgText, "Confirm", MessageBoxButtons.OKCancel);

        if (msgStatus == DialogResult.OK)
        {
          string sourceFull = txtSourceFolder.Text + "\\" + txtSourceFile.Text;
          FileInfo sourceFI = new FileInfo(sourceFull);

          string destFull = txtDestinationFolder.Text + "\\" + txtDestinationFile.Text;
          FileInfo destFI = new FileInfo(destFull);

          bool copyFile = true;

          if (destFI.Exists)
          {
            msgStatus = MessageBox.Show("File exists - overwrite?", "", MessageBoxButtons.OKCancel);
            if (msgStatus == DialogResult.Cancel)
            {
              copyFile = false;
            }
          }

          if (copyFile)
          {
            File.Copy(sourceFull, destFull, true);

            if (radioRestore.Checked == true)
            {
              CListHandler.SetRestoredFileComments(txtSourceFile.Text, txtDestinationFile.Text);
            }

            updateInfo();
            updateFileLists(txtDestinationFolder.Text);
            //CListHandler.Save();
          }
        }
      }
      else
      {
        MessageBox.Show("Please specify both source and destination file names");
      }
    }

    private void listDestinationFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        txtDestinationFile.Text = listDestinationFiles.SelectedItem.ToString();

        selectedFile = txtDestinationFile.Text;
        txtSelectedFile.Text = selectedFile;

        txtComments.Text = CListHandler.FindbyFilename(selectedFile).comments;
      }
      catch
      {
      }
    }

    private void updateInfo()
    {
      string comments = txtComments.Text;

      CListHandler.Replace(selectedFile, comments);
      CListHandler.Save();
    }

    private void btnSaveComments_Click(object sender, EventArgs e)
    {
      updateInfo();
    }

    private void txtDestinationFile_TextChanged(object sender, EventArgs e)
    {
      selectedFile = txtDestinationFile.Text;
      txtSelectedFile.Text = selectedFile;
      txtComments.Text = CListHandler.FindbyFilename(selectedFile).comments;
    }

    public void InitializeByGame(string currentGame)
    {
      comboSelectedGame.Text = currentGame;

      string myDocuments = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
      string userName = Environment.UserName;

      if (currentGame == "Dark Souls I")
      {
        SourceSaves = CListHandler.gfi.DS1GameFilePath;
        BackupSaves = CListHandler.gfi.DS1SaveGamePath;
        DarkSoulsSaveFile = "draks0005.sl2";

        if (!System.IO.File.Exists(SourceSaves + "\\" + DarkSoulsSaveFile))
        {
          System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(SourceSaves);
          System.IO.DirectoryInfo[] subDir1 = root.GetDirectories();
          SourceSaves += subDir1[0].Name;
        }
        
        CListHandler.SetDatFile("_DARKSOULS_GameFileInfo.xml");
      }
      if (currentGame == "Dark Souls II")
      {
        SourceSaves = CListHandler.gfi.DS2GameFilePath;
        BackupSaves = CListHandler.gfi.DS2SaveGamePath;
        DarkSoulsSaveFile = "DARKSII0000.sl2";

        if (!System.IO.File.Exists(SourceSaves + "\\" + DarkSoulsSaveFile))
        {
          System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(SourceSaves);
          System.IO.DirectoryInfo[] subDir1 = root.GetDirectories();
          SourceSaves += subDir1[0].Name;
        }

        CListHandler.gfi.DS2GameFilePath = SourceSaves;
        CListHandler.SetDatFile("_DARKSOULSII_GameFileInfo.xml");
      }
      //C:\Users\us\AppData\Roaming\DarkSoulsIII\0110000103a96006

      if (currentGame == "Dark Souls III")
      {
        SourceSaves = CListHandler.gfi.DS3GameFilePath;
        BackupSaves = CListHandler.gfi.DS3SaveGamePath;
        DarkSoulsSaveFile = "DS30000.sl2";

        if (!System.IO.File.Exists(SourceSaves + "\\" + DarkSoulsSaveFile))
        {
          System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(SourceSaves);
          System.IO.DirectoryInfo[] subDir1 = root.GetDirectories();
          SourceSaves += subDir1[0].Name;
        }

        CListHandler.gfi.DS3GameFilePath = SourceSaves;
        CListHandler.SetDatFile("_DARKSOULSIII_GameFileInfo.xml");
      }


      CListHandler.currentGame = currentGame;
      CListHandler.ValidateFolder(BackupSaves);
      CListHandler.Load();
      CListHandler.SetGameData(currentGame, SourceSaves, BackupSaves);
      CListHandler.Save();

      dlgSelectSource.InitialDirectory = SourceSaves;
      //dlgSelectDestination.InitialDirectory = BackupSaves;

      txtSourceFolder.Text = SourceSaves;
      txtDestinationFolder.Text = BackupSaves;

      CListHandler.ClearList();
      CListHandler.Load();

      txtSourceFile.Text = DarkSoulsSaveFile;
      updateFileLists(BackupSaves);
    }

    private void comboSelectedGame_SelectedIndexChanged(object sender, EventArgs e)
    {
      radioSave.Checked = true;
      InitializeByGame(comboSelectedGame.Text);
    }

    private string GetDatFileBaseName(string currentGame)
    {
      if (currentGame == "Dark Souls I")
      {
        return "\\_DARKSOULS_GameFileInfo.xml";
      }
      if (currentGame == "Dark Souls II")
      {
        return "\\_DARKSOULSII_GameFileInfo.xml";
      }
      if (currentGame == "Dark Souls III")
      {
        return "\\_DARKSOULSIII_GameFileInfo.xml";
      }
      return "";
    }
  }
}
