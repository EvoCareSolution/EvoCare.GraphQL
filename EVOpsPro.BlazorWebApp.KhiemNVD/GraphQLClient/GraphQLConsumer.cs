using EVOpsPro.BlazorWebApp.KhiemNVD.Models;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace EVOpsPro.BlazorWebApp.KhiemNVD.GraphQLClient
{
    public class GraphQLConsumer
    {
        public string? LastErrorMessage { get; private set; }
        private readonly IGraphQLClient _graphQLClient;
        public GraphQLConsumer(IGraphQLClient graphQLClient) => _graphQLClient = graphQLClient;

        public async Task<List<SystemUserAccount>> GetSystemUserAccounts()
        {
            try
            {
                var query = @"
query {
    systemUserAccounts {
        userAccountId
        fullName
        email
        phone
    }
}";

                var response = await _graphQLClient.SendQueryAsync<SystemUserAccountListResponse>(query);
                return response.Data?.SystemUserAccounts ?? new List<SystemUserAccount>();
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return new List<SystemUserAccount>();
            }
        }

        // Response wrapper class
        public async Task<List<ReminderTypeKhiemNvd>> GetReminderTypes(bool includeInactive = false)
        {
            try
            {
                var query = @"
query ($includeInactive: Boolean!) {
    reminderTypes(includeInactive: $includeInactive) {
        reminderTypeKhiemNvdid
        typeName
        description
        isRecurring
        intervalDays
        intervalKm
        isPaymentRelated
        isActive
    }
}";

                var request = new GraphQLRequest
                {
                    Query = query,
                    Variables = new { includeInactive }
                };

                var response = await _graphQLClient.SendQueryAsync<ReminderTypeListGraphQLResponse>(request);
                return response.Data?.ReminderTypes ?? new List<ReminderTypeKhiemNvd>();
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return new List<ReminderTypeKhiemNvd>();
            }
        }

        public async Task<List<ReminderKhiemNvd>> GetReminderKhiemNvds(ReminderSearchRequestInput? filters = null)
        {
            try
            {
                var query = @"
query ($request: ReminderSearchRequestInput) {
    reminderKhiemNvds(request: $request) {
        reminderKhiemNvdid
        userAccountId
        reminderTypeKhiemNvdid
        vehicleVin
        dueDate
        dueKm
        message
        isSent
        isActive
        systemUserAccount {
            fullName
            email
        }
        reminderTypeKhiemNvd {
            typeName
            isRecurring
            isActive
        }
    }
}";

                var request = new GraphQLRequest
                {
                    Query = query,
                    Variables = new { request = filters }
                };

                var response = await _graphQLClient.SendQueryAsync<ReminderListGraphQLResponse>(request);
                return response.Data?.Reminders ?? new List<ReminderKhiemNvd>();
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return new List<ReminderKhiemNvd>();
            }
        }

        public async Task<ReminderPagingResult?> GetReminderKhiemNvdsWithPaging(ReminderSearchRequestInput filters)
        {
            try
            {
                var query = @"
query ($request: ReminderSearchRequestInput!) {
    reminderKhiemNvdsWithPaging(request: $request) {
        items {
            reminderKhiemNvdid
            userAccountId
            reminderTypeKhiemNvdid
            vehicleVin
            dueDate
            dueKm
            message
            isSent
            isActive
            systemUserAccount {
                fullName
            }
            reminderTypeKhiemNvd {
                typeName
            }
        }
        totalItems
        totalPages
        currentPage
        pageSize
    }
}";

                var request = new GraphQLRequest
                {
                    Query = query,
                    Variables = new { request = filters }
                };

                var response = await _graphQLClient.SendQueryAsync<ReminderPagingGraphQLResponse>(request);
                return response.Data?.Result;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
        }

        public async Task<ReminderKhiemNvd?> GetReminderById(int id)
        {
            try
            {
                var query = @"
query ($id: Int!) {
    reminderKhiemNvd(id: $id) {
        reminderKhiemNvdid
        userAccountId
        reminderTypeKhiemNvdid
        vehicleVin
        dueDate
        dueKm
        message
        isSent
        isActive
    }
}";

                var request = new GraphQLRequest
                {
                    Query = query,
                    Variables = new { id }
                };

                var response = await _graphQLClient.SendQueryAsync<ReminderGraphQLResponse>(request);
                return response.Data?.Reminder;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
        }

        public async Task<int?> CreateReminder(ReminderKhiemNvd reminder)
        {
            try
            {
                LastErrorMessage = null;
                var mutation = @"
mutation ($input: ReminderKhiemNvdInput!) {
    createReminder(reminder: $input)
}";

                var request = new GraphQLRequest
                {
                    Query = mutation,
                    Variables = new { input = BuildReminderInput(reminder) }
                };

                var response = await _graphQLClient.SendMutationAsync<ReminderMutationResponse>(request);
                if (response.Errors != null && response.Errors.Any())
                {
                    LastErrorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                    return null;
                }

                return response.Data?.CreatedId;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
        }

        public async Task<int?> UpdateReminder(ReminderKhiemNvd reminder)
        {
            try
            {
                LastErrorMessage = null;
                var mutation = @"
mutation ($input: ReminderKhiemNvdInput!) {
    updateReminder(reminder: $input)
}";

                var request = new GraphQLRequest
                {
                    Query = mutation,
                    Variables = new { input = BuildReminderInput(reminder) }
                };

                var response = await _graphQLClient.SendMutationAsync<ReminderUpdateMutationResponse>(request);
                if (response.Errors != null && response.Errors.Any())
                {
                    LastErrorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                    return null;
                }

                return response.Data?.UpdatedId;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
        }

        public async Task<bool> DeleteReminder(int id)
        {
            try
            {
                LastErrorMessage = null;
                var mutation = @"
mutation ($id: Int!) {
    deleteReminder(id: $id)
}";

                var request = new GraphQLRequest
                {
                    Query = mutation,
                    Variables = new { id }
                };

                var response = await _graphQLClient.SendMutationAsync<ReminderDeleteMutationResponse>(request);
                if (response.Errors != null && response.Errors.Any())
                {
                    LastErrorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                    return false;
                }

                return response.Data?.Result ?? false;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return false;
            }
        }

        public async Task<bool> MarkReminderAsSent(int id)
        {
            try
            {
                LastErrorMessage = null;
                var mutation = @"
mutation ($id: Int!) {
    markReminderAsSent(id: $id)
}";

                var request = new GraphQLRequest
                {
                    Query = mutation,
                    Variables = new { id }
                };

                var response = await _graphQLClient.SendMutationAsync<ReminderMarkSentMutationResponse>(request);
                if (response.Errors != null && response.Errors.Any())
                {
                    LastErrorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                    return false;
                }

                return response.Data?.Result ?? false;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return false;
            }
        }

        private static object BuildReminderInput(ReminderKhiemNvd reminder)
        {
            return new
            {
                reminderKhiemNvdid = reminder.ReminderKhiemNvdid == 0 ? (int?)null : reminder.ReminderKhiemNvdid,
                userAccountId = reminder.UserAccountId,
                reminderTypeKhiemNvdid = reminder.ReminderTypeKhiemNvdid,
                vehicleVin = reminder.VehicleVin,
                dueDate = reminder.DueDate,
                dueKm = reminder.DueKm,
                message = reminder.Message,
                isSent = reminder.IsSent,
                isActive = reminder.IsActive
            };
        }

        public async Task<int?> CreateReminderType(ReminderTypeKhiemNvd type)
        {
            try
            {
                LastErrorMessage = null;
                var mutation = @"
mutation ($input: ReminderTypeKhiemNvdInput!) {
    createReminderType(reminderType: $input)
}";

                var request = new GraphQLRequest
                {
                    Query = mutation,
                    Variables = new { input = type }
                };

                var response = await _graphQLClient.SendMutationAsync<ReminderTypeMutationResponse>(request);
                if (response.Errors != null && response.Errors.Any())
                {
                    LastErrorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                    return null;
                }

                return response.Data?.CreatedId;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
        }

        public async Task<int?> UpdateReminderType(ReminderTypeKhiemNvd type)
        {
            try
            {
                LastErrorMessage = null;
                var mutation = @"
mutation ($input: ReminderTypeKhiemNvdInput!) {
    updateReminderType(reminderType: $input)
}";

                var request = new GraphQLRequest
                {
                    Query = mutation,
                    Variables = new { input = type }
                };

                var response = await _graphQLClient.SendMutationAsync<UpdateReminderTypeResponse>(request);
                if (response.Errors != null && response.Errors.Any())
                {
                    LastErrorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                    return null;
                }

                return response.Data?.UpdatedId;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
        }

        public async Task<bool> UpdateReminderTypeStatus(int id, bool isActive)
        {
            try
            {
                LastErrorMessage = null;
                var mutation = @"
mutation ($id: Int!, $isActive: Boolean!) {
    updateReminderTypeStatus(id: $id, isActive: $isActive)
}";

                var request = new GraphQLRequest
                {
                    Query = mutation,
                    Variables = new { id, isActive }
                };

                var response = await _graphQLClient.SendMutationAsync<UpdateReminderTypeStatusResponse>(request);
                if (response.Errors != null && response.Errors.Any())
                {
                    LastErrorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                    return false;
                }

                return response.Data?.Result ?? false;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return false;
            }
        }
    }
}

