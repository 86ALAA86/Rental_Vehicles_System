using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System.Global
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception e)
                {

                    clsUtil.LogToEventLogger(e);
                    clsUtil.LogToUserOnScreen(e);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"D:\Rental System\People_Images_RS\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                clsUtil.LogToEventLogger(iox);
                clsUtil.LogToUserOnScreen(iox);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }



        public enum SeverityLevel
        {
            Information,
            Warning,
            Error
        }
        
        public static SeverityLevel GetSeverity(Exception ex)
            {
                // 🔴 Critical errors
                if (ex is OutOfMemoryException ||
                    ex is StackOverflowException ||
                    ex is AccessViolationException ||
                    ex is InvalidProgramException)
                {
                    return SeverityLevel.Error;
                }

                // ⚠️ Recoverable warnings
                if (ex is FileNotFoundException ||
                    ex is DirectoryNotFoundException ||
                    ex is EndOfStreamException ||
                    ex is TimeoutException ||
                    ex is IOException)
                {
                    return SeverityLevel.Warning;
                }

                // ℹ️ Informational (non-critical, often expected)
                if (ex is OperationCanceledException ||
                    ex is TaskCanceledException ||
                    ex is NotImplementedException ||
                    ex is NotSupportedException)
                {
                    return SeverityLevel.Information;
                }

                // Default: treat unknown exceptions as errors
                return SeverityLevel.Error;
            }

        public static EventLogEntryType ToEventLogEntryType(SeverityLevel level)
        {
            switch (level)
            {
                case SeverityLevel.Information:
                    return EventLogEntryType.Information;
                case SeverityLevel.Warning:
                    return EventLogEntryType.Warning;
                case SeverityLevel.Error:
                    return EventLogEntryType.Error;
                default:
                    return EventLogEntryType.Information; // fallback
            }
        }

        public static void LogToEventLogger(Exception EX)
        {
            string sourceName = "RentalVehicleSystem";


            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }


            EventLogEntryType EntryType= ToEventLogEntryType(GetSeverity(EX));

            // Log an information event
            EventLog.WriteEntry(sourceName,EX.Message,EntryType);


        }

        public static MessageBoxIcon ToMessageBoxIcon(SeverityLevel level)
        {
            switch (level)
            {
                case SeverityLevel.Information:
                    return MessageBoxIcon.Information;
                case SeverityLevel.Warning:
                    return MessageBoxIcon.Warning;
                case SeverityLevel.Error:
                    return MessageBoxIcon.Error;
                default:
                    return MessageBoxIcon.None; // fallback
            }
        }

        public static void LogToUserOnScreen(Exception EX)
        {
            MessageBox.Show(EX.Message, "", MessageBoxButtons.OK, ToMessageBoxIcon(GetSeverity(EX)));
        }



    }


}
