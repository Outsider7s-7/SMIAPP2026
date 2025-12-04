using Microsoft.Maui.Devices;
using SQLite;
using System.Text.Json.Serialization;

namespace SMIAPP2026.Shared
{
    // Modèle pour les régions
    public class Region
    {
        [JsonPropertyName("Secteur géographique")]
        public string? SecteurGeographique { get; set; }

        [JsonPropertyName("Photo")]
        public string? Photo { get; set; }
    }

    // Réponse contenant une liste de régions
    public class RegionResponse
    {
        public List<Region>? Régions { get; set; } = new List<Region>();
    }

    // Modèle pour les stations
    public class Station
    {
        [JsonPropertyName("Type tiers")]
        public string? TypeTiers { get; set; }

        [JsonPropertyName("Code tiers")]
        public string? CodeTiers { get; set; }

        [JsonPropertyName("Raison sociale")]
        public string? RaisonSociale { get; set; }

        public string? Ville { get; set; }

        public string? Photo { get; set; }

        [JsonPropertyName("Secteur géographique")]
        public string? SecteurGeographique { get; set; }

        public string? GPS { get; set; }

        public bool Active { get; set; }
    }

    // Réponse contenant une liste de stations
    public class StationResponse
    {
        public List<Station>? Stations { get; set; } = new List<Station>();
    }

    // Modèle pour les photos
    public class Photo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Base64 { get; set; } // Base64-encoded image string
        public string? StationName { get; set; }
        public string? City { get; set; }
        public string? GPS { get; set; }
        public string? Region { get; set; }
        public string? Code { get; set; }
        public string? Timestamp { get; set; }
    }

    public interface IApiService
    {
        Task<List<Region>> GetRegionsAsync();
        Task<List<Station>> GetStationsAsync();
        Task<List<Photo>> GetPhotosAsync();
        Task<bool> SavePhotoAsync(Photo photo);
        Task<bool> DeletePhotoAsync(int id);
    }

    public interface IDatabaseService
    {
        Task<int> SavePhoto(Photo photo);
        Task<int> RemovePhoto(string photoBase64);
        Task<List<Photo>> GetPhotos();
    }

    //Login Models
    // Classes for response deserialization
    public class ApiResponse
    {
        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("Info Connexion-Universal Authentification")]
        public List<UserInfo>? InfoConnexionUniversalAuthentification { get; set; }
    }

    public class UserInfo
    {
        [JsonPropertyName("Utilisateur")]
        public string? Utilisateur { get; set; }

        [JsonPropertyName("Nom Prénom")]
        public string? NomPrenom { get; set; }

        [JsonPropertyName("Active")]
        public string? Active { get; set; }

        [JsonPropertyName("Profil")]
        public string? Profil { get; set; }

        [JsonPropertyName("Photo")]
        public string? Photo { get; set; }

        [JsonPropertyName("Token")]
        public string? Token { get; set; }
    }


    public class LocationData
    {
        public string DeviceName { get; set; } = DeviceInfo.Name;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }



}
