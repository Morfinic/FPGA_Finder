using Shared;
using System.Net.Http.Json;
using Frontend.Models;

namespace Frontend.Services;

public class FpgaApiService(HttpClient http)
{
    public async Task<List<FpgaCardSummary>?> GetAllAsync() =>
        await http.GetFromJsonAsync<List<FpgaCardSummary>>("api/FpgaCard");

    public async Task<FpgaCard?> GetDetailAsync(int cardId) =>
        await http.GetFromJsonAsync<FpgaCard>($"api/FpgaCard/{cardId}");
    
    public async Task<List<DailyUsageDto>?> GetUsageLogsAsync(int cardId) =>
        await http.GetFromJsonAsync<List<DailyUsageDto>>($"api/UsageLogs/card/{cardId}");
    
    public async Task<List<FpgaCardSummary>?> GetFilteredAsync(string url) =>
        await http.GetFromJsonAsync<List<FpgaCardSummary>>(url);
    
    public async Task<FilterOptions?> GetFilterOptionsAsync() =>
        await http.GetFromJsonAsync<FilterOptions>("api/FpgaCard/filter-options");
}