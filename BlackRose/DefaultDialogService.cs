using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.IO;
namespace BlackRose
{
    class DefaultDialogService : IFileService
    {
        public string Path
        {
            get
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "Audio Files|*.mp3; *.wav; *.aif; *.mid";
                if (openFileDialog.ShowDialog() == true)
                    return openFileDialog.FileName;
                return null;
            }
        }
        public string[] ext { get; } = { ".mp3", ".wav", ".aif", ".mid" };
        public List<FullTrack> DirOfTracks
        {
            get
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Выберите папку с аудио - файлами";
                folderBrowserDialog.ShowNewFolderButton = false;
                if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                    List<FullTrack> list = new List<FullTrack>();
                    foreach(var file in directoryInfo.GetFiles())
                    {
                        for(int count = 0; count < ext.Length; count ++)
                        {
                            if(ext[count] == file.Extension)
                            {
                                list.Add(new FullTrack(new Track(file.FullName), new System.Windows.Media.MediaPlayer()));
                                break;
                            }
                        }
                        
                    }
                    folderBrowserDialog.Dispose();
                    return list;
                }
                folderBrowserDialog.Dispose();
                return null;
            }
        }
    }
}
