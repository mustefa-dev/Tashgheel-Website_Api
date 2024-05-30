

using System.Diagnostics;
using NReco.VideoInfo;


namespace Tashgheel_Api.Services
{

    public interface IFileService
    {
        Task<(string? file, string? error)> Upload(IFormFile file);
        Task<(List<string>? files, string? error)> Upload(IFormFile[] files);
        Task<(string? file, string? error)> UploadVideo(IFormFile file);
    }

    public class FileService : IFileService
    {

        public async Task<(string? file, string? error)> Upload(IFormFile file)
        {
            var id = Guid.NewGuid();
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{id}{extension}";

            var attachmentsDir = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "Attachments");
            if (!File.Exists(attachmentsDir)) Directory.CreateDirectory(attachmentsDir);


            var path = Path.Combine(attachmentsDir, fileName);
            await using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            var filePath = Path.Combine("Attachments", fileName);
            return (filePath, null);
        }

        public async Task<(List<string> files, string? error)> Upload(IFormFile[] files)
        {
            var fileList = new List<string>();
            foreach (var file in files)
            {
                var fileToAdd = await Upload(file);
                fileList.Add(fileToAdd.file!);
            }

            return (fileList, null);
        }

        public async Task<(string? file, string? error)> UploadVideo(IFormFile file)
        {
            var id = Guid.NewGuid();
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{id}{extension}";

            var attachmentsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Attachments");
            if (!Directory.Exists(attachmentsDir)) Directory.CreateDirectory(attachmentsDir);

            var path = Path.Combine(attachmentsDir, fileName);
            await using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            var filePath = Path.Combine("Attachments", fileName);

            // Close the FileStream before splitting the video into chunks
            await stream.DisposeAsync();

            // Split the video into chunks
            await SplitVideoIntoChunks(path, fileName, extension);

            return (filePath, null);
        }

        private async Task SplitVideoIntoChunks(string path, string fileName, string extension)
        {
            var attachmentsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Attachments");
            var chunkIndex = 0;
            var chunkDuration = 5; // Duration of each chunk in seconds

            // Get the total duration of the video using NReco.VideoInfo
            var ffProbe = new FFProbe();
            var videoInfo = ffProbe.GetMediaInfo(path);

            // Get the total duration in seconds
            var totalDuration = videoInfo.Duration.TotalSeconds;

            // Calculate the number of chunks
            var numberOfChunks = (int)Math.Ceiling(totalDuration / chunkDuration);

            for (chunkIndex = 0; chunkIndex < numberOfChunks; chunkIndex++)
            {
                // Calculate the start time for this chunk
                var startTime = chunkIndex * chunkDuration;

                // Generate the output file name for this chunk
                var outputFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_ch{chunkIndex}{extension}";
                var outputPath = Path.Combine(attachmentsDir, outputFileName);

                // Use ffmpeg to extract this chunk of the video
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = $"-ss {startTime} -i \"{path}\" -t {chunkDuration} -c copy \"{outputPath}\"",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();
                await process.WaitForExitAsync();
            }
        }
    }
}