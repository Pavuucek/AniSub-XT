using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.COM;
using AniDB.Pack;

namespace AniDB
{
    class UnZipRar
    {
        private static KnownSevenZipFormat ZipFormatG;

        public UnZipRar()
        {
        }

        public List<string> List(string archiveName, KnownSevenZipFormat ZipFormat)
        {
            List<string> List = new List<string>();

            using (SevenZipFormat Format = new SevenZipFormat(SevenZipDllPath))
            {
                IInArchive Archive = Format.CreateInArchive(SevenZipFormat.GetClassIdFromKnownFormat(ZipFormat));
                if (Archive == null)
                    return List;

                try
                {
                    using (InStreamWrapper ArchiveStream = new InStreamWrapper(File.OpenRead(archiveName)))
                    {
                        IArchiveOpenCallback OpenCallback = new ArchiveOpenCallback();

                        ulong CheckPos = 256 * 1024;

                        if (Archive.Open(ArchiveStream, ref CheckPos, OpenCallback) != 0)
                            return List;

                        uint Count = Archive.GetNumberOfItems();
                        for (uint I = 0; I < Count; I++)
                        {
                            PropVariant Name = new PropVariant();
                            Archive.GetProperty(I, ItemPropId.kpidPath, ref Name);
                            string[] T = Name.GetObject().ToString().Split('\\');
                            List.Add(T[T.Length - 1]);
                        }
                    }
                }
                finally
                {
                    Marshal.ReleaseComObject(Archive);
                }
            }

            return List;
        }

        public string Extract(string archiveName, string folderToExtract, uint fileNumber, KnownSevenZipFormat ZipFormat, out bool isDirectory)
        {
            isDirectory = false;

            ZipFormatG = ZipFormat;

            string FileName = null;
            try
            {
                using (SevenZipFormat Format = new SevenZipFormat(SevenZipDllPath))
                {
                    IInArchive Archive = Format.CreateInArchive(SevenZipFormat.GetClassIdFromKnownFormat(ZipFormat));
                    if (Archive == null)
                        return null;

                    try
                    {
                        using (InStreamWrapper ArchiveStream = new InStreamWrapper(File.OpenRead(archiveName)))
                        {
                            IArchiveOpenCallback OpenCallback = new ArchiveOpenCallback();

                            ulong CheckPos = 256 * 1024;

                            if (Archive.Open(ArchiveStream, ref CheckPos, OpenCallback) != 0)
                                return null;

                            PropVariant Name = new PropVariant();
                            Archive.GetProperty(fileNumber, ItemPropId.kpidPath, ref Name);
                            FileName = (string)Name.GetObject();
                            Archive.GetProperty(fileNumber, ItemPropId.kpidIsFolder, ref Name);
                            isDirectory = (bool)Name.GetObject();

                            if (!isDirectory)
                                Archive.Extract(new uint[] { fileNumber }, 1, 0, new ArchiveExtractCallback(fileNumber, folderToExtract + FileName));
                        }
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(Archive);
                    }

                }
            }
            catch
            {
            }
            return FileName;
        }

        public string SevenZipDllPath
        {
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "7z.dll"); }
        }

        private class ArchiveOpenCallback : IArchiveOpenCallback
        {
            public void SetTotal(IntPtr files, IntPtr bytes)
            {
            }

            public void SetCompleted(IntPtr files, IntPtr bytes)
            {
            }
        }

        private class ArchiveExtractCallback : IProgress, IArchiveExtractCallback
        {
            private int k = 0;
            private uint FileNumber;
            private string FileName;
            private OutStreamWrapper FileStream;
            private MemoryStream memStream;

            public ArchiveExtractCallback(uint fileNumber, string fileName)
            {
                this.FileNumber = fileNumber;
                this.FileName = fileName;
                this.memStream = new MemoryStream();
            }

            #region IProgress Members

            public void SetTotal(ulong total)
            {
            }

            public void SetCompleted(ref ulong completeValue)
            {
            }

            #endregion

            #region IArchiveExtractCallback Members

            public int GetStream(uint index, out ISequentialOutStream outStream, AskMode askExtractMode)
            {
                if (k == 0)
                {
                    string FileDir = Path.GetDirectoryName(FileName);
                    if (!string.IsNullOrEmpty(FileDir))
                        Directory.CreateDirectory(FileDir);
                    FileStream = new OutStreamWrapper(File.Create(FileName));
                    outStream = FileStream;

                    k++;
                }
                else if (index == FileNumber && askExtractMode == AskMode.kExtract && k != 0)
                {
                    string FileDir = Path.GetDirectoryName(FileName);
                    if (!string.IsNullOrEmpty(FileDir))
                        Directory.CreateDirectory(FileDir);
                    FileStream = new OutStreamWrapper(File.Create(FileName));
                    outStream = FileStream;
                }
                else
                    outStream = new OutStreamWrapper(this.memStream);

                return 0;
            }

            public void PrepareOperation(AskMode askExtractMode)
            {
            }

            public void SetOperationResult(OperationResult resultEOperationResult)
            {
                memStream.Seek(0, SeekOrigin.Begin);
                FileStream.Dispose();
            }

            #endregion
        }

        private class ArchiveUpdateCallback : IProgress, IArchiveUpdateCallback
        {
            private IList<FileInfo> FileList;
            private Stream CurrentSourceStream;

            public ArchiveUpdateCallback(IList<FileInfo> list)
            {
                FileList = list;
            }

            #region IProgress Members

            public void SetTotal(ulong total)
            {
            }

            public void SetCompleted(ref ulong completeValue)
            {
            }

            #endregion

            #region IArchiveUpdateCallback Members

            public void GetUpdateItemInfo(int index, out int newData, out int newProperties, out uint indexInArchive)
            {
                newData = 1;
                newProperties = 1;
                indexInArchive = 0xFFFFFFFF;
            }

            private void GetTimeProperty(DateTime time, IntPtr value)
            {
                Marshal.GetNativeVariantForObject(time.ToFileTime(), value);
                Marshal.WriteInt16(value, (short)VarEnum.VT_FILETIME);
            }

            public void GetProperty(int index, ItemPropId propID, IntPtr value)
            {
                FileInfo Source = FileList[index];
                switch (propID)
                {
                    case ItemPropId.kpidPath:
                        Marshal.GetNativeVariantForObject(Path.GetFileName(Source.FullName), value);
                        break;
                    case ItemPropId.kpidIsFolder:
                    case ItemPropId.kpidIsAnti:
                        Marshal.GetNativeVariantForObject(false, value);
                        break;
                    //case ItemPropId.kpidAttributes:
                    //  Marshal.WriteInt16(value, (short)VarEnum.VT_EMPTY);
                    //  break;
                    case ItemPropId.kpidCreationTime:
                        GetTimeProperty(Source.CreationTime, value);
                        break;
                    case ItemPropId.kpidLastAccessTime:
                        GetTimeProperty(Source.LastAccessTime, value);
                        break;
                    case ItemPropId.kpidLastWriteTime:
                        GetTimeProperty(Source.LastWriteTime, value);
                        break;
                    case ItemPropId.kpidSize:
                        Marshal.GetNativeVariantForObject((ulong)Source.Length, value);
                        break;
                    default:
                        Marshal.WriteInt16(value, (short)VarEnum.VT_EMPTY);
                        break;
                }
            }

            public void GetStream(int index, out ISequentialInStream inStream)
            {
                FileInfo Source = FileList[index];

                Console.Write("Packing: ");
                Console.Write(Path.GetFileName(Source.FullName));
                Console.Write(' ');

                CurrentSourceStream = Source.OpenRead();
                inStream = new InStreamTimedWrapper(CurrentSourceStream);
            }

            public void SetOperationResult(int operationResult)
            {
                CurrentSourceStream.Close();
            }

            #endregion
        }

    }
}