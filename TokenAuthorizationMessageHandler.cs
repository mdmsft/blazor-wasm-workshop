using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class TokenAuthorizationMessageHandler : AuthorizationMessageHandler
{
    private readonly IAccessTokenProvider provider;

    public TokenAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigation) : base(provider, navigation)
    {
        this.provider = provider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await provider.RequestAccessToken();
        if (token.Status == AccessTokenResultStatus.Success && token.TryGetToken(out var accessToken))
        {
            request.Headers.Remove("Authorization");
            request.Headers.Add("Authorization", $"Bearer {accessToken.Value}");
        }
        return await base.SendAsync(request, cancellationToken);
    }
}