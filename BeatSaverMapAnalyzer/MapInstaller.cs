using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatSaverSharp;
using System.IO.Compression;
using System.IO;

namespace RandomSongTournamentAssistant
{
    public static class MapInstaller
    {

        public static async Task<string> InstallMap(Beatmap mapData, string mapPath)
        {
            byte[] zipData = await DownloadMap(mapData);
            if (!(zipData is null))
            {
                if (await ExtractZip(mapData, zipData, mapPath))
                {
                    return mapPath;
                }
            }
            return null;
        }

        private static async Task<byte[]> DownloadMap(Beatmap mapData)
        {
            try
            {
                byte[] zipData = await mapData.DownloadZip();
                return zipData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to download map zip: " + ex.ToString());
                return null;
            }
        }

        private static void UnzipFile(string fileName)
        {
            ZipFile.ExtractToDirectory(fileName + ".zip", fileName);
            File.Delete(fileName + ".zip");
        }

        private static async Task<bool> ExtractZip(Beatmap beatmap, byte[] zipData, string mapPath)
        {
            Stream zipStream = new MemoryStream(zipData);
            try
            {
                ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read);
                string basePath = beatmap.Key + " (" + beatmap.Metadata.SongName + " - " + beatmap.Metadata.LevelAuthorName + ")";
                if (!Directory.Exists(mapPath))
                    Directory.CreateDirectory(mapPath);
                await Task.Run(() =>
                {
                    foreach (var entry in archive.Entries)
                    {
                        var entryPath = Path.Combine(mapPath, entry.Name); // Name instead of FullName for better security and because song zips don't have nested directories anyway
                        if (!File.Exists(entryPath)) // Either we're overwriting or there's no existing file
                            entry.ExtractToFile(entryPath);
                    }
                }).ConfigureAwait(false);
                archive.Dispose();
                zipStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to extract map zip: " + ex.ToString());
                zipStream.Close();
                return false;
            }
        }
    }
}
