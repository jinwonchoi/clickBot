using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.Reflection;

namespace WeDoCommon
{
    class ZipUtil
    {
        // Compresses the files in the nominated folder, and creates a zip file on disk named as outPathname.
        //
        public static void CreateZipfile(string outPathname, string folderName)
        {
            CreateZipfile(outPathname, null, folderName);
        }

        // Compresses the files in the nominated folder, and creates a zip file on disk named as outPathname.
        //
        public static void CreateZipfile(string outPathname, string password, string folderName)
        {

            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression

            zipStream.Password = password;  // optional. Null is the same as not setting. Required if using AES.

            // This setting will strip the leading part of the folder path in the entries, to
            // make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign folderOffset = 0.
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            CompressFolder(folderName, zipStream, folderOffset);

            zipStream.IsStreamOwner = true; // Makes the Close also Close the underlying stream
            zipStream.Close();
        }

        // Recurses down the folder structure
        //
        private static void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {

            string[] files = Directory.GetFiles(path);

            foreach (string filename in files)
            {

                FileInfo fi = new FileInfo(filename);

                string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
                entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

                // Specifying the AESKeySize triggers AES encryption. Allowable values are 0 (off), 128 or 256.
                // A password on the ZipOutputStream is required if using AES.
                //   newEntry.AESKeySize = 256;

                // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                // but the zip will be in Zip64 format which not all utilities can understand.
                //   zipStream.UseZip64 = UseZip64.Off;
                newEntry.Size = fi.Length;

                zipStream.PutNextEntry(newEntry);

                // Zip the file in buffered chunks
                // the "using" will close the stream even if an exception occurs
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }

        private static void CreateEmptyZipfile(string outPathname)
        {
            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression

            zipStream.IsStreamOwner = true; // Makes the Close also Close the underlying stream
            zipStream.Close();
            fsOut.Close();
        }

        public static void CreateZipfile(string outPathname, List<string> fileList) {
            try
            {
                if (!(new FileInfo(outPathname)).Exists)
                {
                    CreateEmptyZipfile(outPathname);
                }

                ZipFile zipFile = new ZipFile(outPathname);

                // Must call BeginUpdate to start, and CommitUpdate at the end.
                zipFile.BeginUpdate();
                Logger.info("CreateZipfile.BeginUpdate");

                // The "Add()" method will add or overwrite as necessary.
                // When the optional entryName parameter is omitted, the entry will be named
                // with the full folder path and without the drive e.g. "temp/folder/test1.txt".
                //
                foreach (string fileName in fileList)
                {
                    zipFile.Add(fileName, (new FileInfo(fileName)).Name);
                    Logger.info(string.Format("파일추가완료[{0}]", fileName));
                }
                // Continue calling .Add until finished.

                // Both CommitUpdate and Close must be called.
                zipFile.CommitUpdate();
                Logger.info("CreateZipfile.CommitUpdate");
                zipFile.Close();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                throw new Exception(string.Format("zipfile생성 중 에러발생[{0}]", outPathname));
            }
        }

        
        public static void UpdateExistingZip()
        {
            ZipFile zipFile = new ZipFile(@"c:\eclues\existing.zip");

            // Must call BeginUpdate to start, and CommitUpdate at the end.
            zipFile.BeginUpdate();

            zipFile.Password = "whatever"; // Only if a password is wanted on the new entry

            // The "Add()" method will add or overwrite as necessary.
            // When the optional entryName parameter is omitted, the entry will be named
            // with the full folder path and without the drive e.g. "temp/folder/test1.txt".
            //
            zipFile.Add(@"c:\eclues\Installer_20131223.txt");

            // Specify the entryName parameter to modify the name as it appears in the zip.
            //
            zipFile.Add(@"c:\eclues\Installer_20131220.txt", "Installer_20131220.txt");

            // Continue calling .Add until finished.

            // Both CommitUpdate and Close must be called.
            zipFile.CommitUpdate();
            zipFile.Close();
        }

        public static void ExtractZipFile(string archiveFilenameIn, string outFolder)
        {
            ExtractZipFile(archiveFilenameIn, null, outFolder);
        }

        public static void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;     // AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
        }

        // Compresses the supplied memory stream, naming it as zipEntryName, into a zip,
        // which is returned as a memory stream or a byte array.
        //
        public static MemoryStream CreateToMemoryStream(MemoryStream memStreamIn, string zipEntryName)
        {

            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression

            ZipEntry newEntry = new ZipEntry(zipEntryName);
            newEntry.DateTime = DateTime.Now;

            zipStream.PutNextEntry(newEntry);

            StreamUtils.Copy(memStreamIn, zipStream, new byte[4096]);
            zipStream.CloseEntry();

            zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.

            outputMemStream.Position = 0;
            return outputMemStream;

            // Alternative outputs:
            // ToArray is the cleaner and easiest to use correctly with the penalty of duplicating allocated memory.
            //byte[] byteArrayOut = outputMemStream.ToArray();

            // GetBuffer returns a raw buffer raw and so you need to account for the true length yourself.
            //byte[] byteArrayOut = outputMemStream.GetBuffer();
            //long len = outputMemStream.Length;
        }

        public static void UnzipFromStream(string resourceName, string outFolder)
        {
            Assembly assembly;
            Stream zipStream;

            try
            {
                assembly = Assembly.GetExecutingAssembly();
                zipStream = assembly.GetManifestResourceStream(resourceName);
                //byte[] data = Decompress(zipStream);
                _UnzipFromStream(zipStream, outFolder);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                throw new Exception(string.Format("Unzip 실행중 에러발생[{0}==>{1}]",resourceName,outFolder));
            }
        }

        private static void _UnzipFromStream(Stream zipStream, string outFolder)
        {

            ZipInputStream zipInputStream = new ZipInputStream(zipStream);
            ZipEntry zipEntry = zipInputStream.GetNextEntry();
            while (zipEntry != null)
            {
                String entryFileName = zipEntry.Name;
                // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                // Optionally match entrynames against a selection list here to skip as desired.
                // The unpacked length is available in the zipEntry.Size property.

                byte[] buffer = new byte[4096];     // 4K is optimum

                // Manipulate the output filename here as desired.
                String fullZipToPath = Path.Combine(outFolder, entryFileName);
                string directoryName = Path.GetDirectoryName(fullZipToPath);
                if (directoryName.Length > 0)
                    Directory.CreateDirectory(directoryName);

                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream streamWriter = File.Create(fullZipToPath))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);
                }
                zipEntry = zipInputStream.GetNextEntry();
            }
        }
    }
}
