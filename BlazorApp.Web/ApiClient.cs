﻿using BlazorApp.Model.Models.Others;
using BlazorApp.Web.Authentication;
using Grpc.Core;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlazorApp.Web;

public class ApiClient(HttpClient httpClient, ProtectedLocalStorage localStorage, AuthenticationStateProvider authStateProvider)
{
	public async Task SetAuthorizeHeader()
    {
		var sessionState = (await localStorage.GetAsync<LoginResponseModel>("sessionState")).Value;
		if (sessionState != null && !string.IsNullOrEmpty(sessionState.Token))
		{
			if (sessionState.TokenExpired < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
			{
				await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
			}
			else if (sessionState.TokenExpired < DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())
			{
				var res = await httpClient.GetFromJsonAsync<LoginResponseModel>($"/api/auth/loginByRefeshToken?refreshToken={sessionState.RefreshToken}");
				if (res != null)
				{
					await ((CustomAuthStateProvider)authStateProvider).MarkUserAsAuthenticated(res);
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", res.Token);
				}
				else
				{
					await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
				}
			}
			else
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionState.Token);
			}
		}
	}

	public async Task<T> GetFromJsonAsync<T>(string path)
	{
		await SetAuthorizeHeader();
		return await httpClient.GetFromJsonAsync<T>(path);
	}
	public async Task<T1> PostAsync<T1, T2>(string path, T2 postModel)
	{
		await SetAuthorizeHeader();

		var res = await httpClient.PostAsJsonAsync(path, postModel);
		if (res != null && res.IsSuccessStatusCode)
		{
			return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
		}
        else
        {
            // Ném ra ngoại lệ với thông tin lỗi từ API
            var errorContent = await res.Content.ReadAsStringAsync();
            var errorMessage = JsonConvert.DeserializeObject<Dictionary<string, string>>(errorContent)?["message"] ?? "Có lỗi xảy ra.";
            throw new ApiException(errorMessage, (int)res.StatusCode);
        }
        return default;
	}
	public async Task<T1> PutAsync<T1, T2>(string path, T2 postModel)
	{
		await SetAuthorizeHeader();
		var res = await httpClient.PutAsJsonAsync(path, postModel);
		if (res != null && res.IsSuccessStatusCode)
		{
			return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
		}
		return default;
	}
	public async Task<T> DeleteAsync<T>(string path)
	{
		await SetAuthorizeHeader();
		return await httpClient.DeleteFromJsonAsync<T>(path);
	}
    public async Task<T1> PatchAsync<T1,T2>(string path, T2 patchModel)
    {
        await SetAuthorizeHeader();
        var res = await httpClient.PatchAsJsonAsync(path, patchModel);

        if (res != null && res.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
        }

        // Ném ra ngoại lệ với thông tin lỗi từ API
        var errorContent = await res.Content.ReadAsStringAsync();
        var errorMessage = JsonConvert.DeserializeObject<Dictionary<string, string>>(errorContent)?["message"] ?? "Có lỗi xảy ra.";
        throw new ApiException(errorMessage, (int)res.StatusCode);
    }

	public async Task<bool> CheckSessionState()
	{
		var sessionState = (await localStorage.GetAsync<LoginResponseModel>("sessionState")).Value;
		if (sessionState == null || string.IsNullOrEmpty(sessionState.Token) || sessionState.TokenExpired < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
		{
			await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
			return false;
		}
		else if (sessionState.TokenExpired < DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())
		{
			// Làm mới token nếu sắp hết hạn
			var res = await httpClient.GetFromJsonAsync<LoginResponseModel>($"/api/auth/loginByRefeshToken?refreshToken={sessionState.RefreshToken}");
			if (res != null)
			{
				await ((CustomAuthStateProvider)authStateProvider).MarkUserAsAuthenticated(res);
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", res.Token);
			}
			else
			{
				await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
				return false;
			}
		}
		return true;
	}
}

