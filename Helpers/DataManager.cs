namespace DnD_Companion_blazor.Helpers;

using System.Text.Json;

public static class DataManager
{
    public static async Task SaveData<T>(string key, T data)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(key)) key = data?.GetType()?.Name ?? "data";

            string jsonString = JsonSerializer.Serialize(data);
            Device.BeginInvokeOnMainThread(async () =>
                await SecureStorage.Default.SetAsync(key, jsonString));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    public static async Task<T?> LoadData<T>(string key)
    {
        try
        {
            string jsonString = await SecureStorage.Default.GetAsync(key) ?? string.Empty;
            if (string.IsNullOrWhiteSpace(jsonString)) return default;
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
            return default;
        }
    }
}