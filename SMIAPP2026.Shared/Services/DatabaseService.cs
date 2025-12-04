using SQLite;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
namespace SMIAPP2026.Shared
{
    public class DatabaseService : IDatabaseService
    {
        private readonly SQLiteConnection _database;
        private readonly string _dbPath;

        public DatabaseService()
        {
            // Define database path
            _dbPath = Path.Combine(FileSystem.AppDataDirectory, "photos.db");
            _database = new SQLiteConnection(_dbPath);
            _database.CreateTable<Photo>();
        }
        // Vérifie si une photo existe déjà (en utilisant Base64 comme identifiant unique)
        public bool PhotoExists(string? photoBase64)
        {
            if (string.IsNullOrEmpty(photoBase64))
            {
                return false; // Return false if photoBase64 is null or empty
            }

            return _database.Table<Photo>().Any(p => p.Base64 == photoBase64); // Check if any photo has the same Base64
        }


        // Asynchronous save photo method (Android)
        public async Task<int> SavePhoto(Photo photo)
        {
            if (photo == null || string.IsNullOrEmpty(photo.Base64))
            {
                Console.WriteLine("Invalid photo or Base64 string is null.");
                return 0; // Return 0 if the photo object or Base64 is invalid
            }

            try
            {
                if (!PhotoExists(photo.Base64))
                {
                    return await Task.Run(() => _database.InsertOrReplace(photo)); // Insert or replace the photo in the database
                }
                else
                {
                    Console.WriteLine("Photo already exists.");
                    return 0; // No record added if photo already exists
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving photo: {ex.Message}");
                return 0; // Return 0 in case of error
            }
        }





        // Asynchronous remove photo method (Android)
        public async Task<int> RemovePhoto(string photoBase64)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var photoToRemove = _database.Table<Photo>().FirstOrDefault(p => p.Base64 == photoBase64);
                    if (photoToRemove != null)
                    {
                        return _database.Delete(photoToRemove);
                    }
                    return 0; // Return 0 if no photo is found
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing photo: {ex.Message}");
                return 0;
            }
        }

        // Asynchronous get photos method (Android)
        public async Task<List<Photo>> GetPhotos()
        {
            try
            {
                return await Task.Run(() => _database.Table<Photo>().ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving photos: {ex.Message}");
                return new List<Photo>();
            }
        }
   

    }
}
