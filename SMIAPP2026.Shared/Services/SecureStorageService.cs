using System;
using Microsoft.Maui.Storage;

namespace SMIAPP2026.Shared
{
    public class SecureStorageService
    {
        private const string TokenKey = "AuthToken";

        // Save token asynchronously
        public async Task SaveTokenAsync(string token)
        {
            try
            {
                await SecureStorage.Default.SetAsync(TokenKey, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save token: {ex.Message}");
            }
        }

        // Retrieve token asynchronously
        public async Task<string?> GetTokenAsync()
        {
            try
            {
                return await SecureStorage.Default.GetAsync(TokenKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to retrieve token: {ex.Message}");
                return null;
            }
        }

        // Clear the stored token
        public void ClearToken()
        {
            SecureStorage.Default.Remove(TokenKey);
        }
    }
}
