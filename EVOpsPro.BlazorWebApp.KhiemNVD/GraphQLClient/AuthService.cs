using EVOpsPro.BlazorWebApp.KhiemNVD.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.JSInterop;

namespace EVOpsPro.BlazorWebApp.KhiemNVD.GraphQLClient
{
    public class AuthService
    {
        private readonly IGraphQLClient _graphQLClient;
        private readonly IJSRuntime _js;
        public AuthService(IGraphQLClient graphQLClient, IJSRuntime js)
        {
            _graphQLClient = graphQLClient;
            _js = js;
        }

        public async Task<UserDto> LoginAsync(string username, string password)
        {
           

            var mutation = @"
                    mutation ($username: String!, $password: String!) {
                        login(username: $username, password: $password) {
                            userAccountId
                            roleId
                            
                        }
                    }";

            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new
                {
                    username,
                    password
                }
            };

            var response = await _graphQLClient.SendMutationAsync<LoginWrapper>(request);
            if (response.Errors != null && response.Errors.Any())
            {
                var errorMessages = string.Join("; ", response.Errors.Select(e => e.Message));
                throw new Exception($"Login failed: {errorMessages}");
            }
            var user = response.Data?.Login;

            if (user != null)
            {
                // ?? Lýu thông tin vào localStorage
                await _js.InvokeVoidAsync("localStorage.setItem", "userId", user.UserAccountId.ToString());
                await _js.InvokeVoidAsync("localStorage.setItem", "roleId", user.RoleId.ToString());
            }

            return user;
        }

    }

}
