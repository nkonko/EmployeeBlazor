namespace BlazorApp4.Client.Pages.Employees
{
    using BlazorApp4.Shared.Models;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using System.Threading.Tasks;

    public partial class UpdateEmployee
    {
        [Parameter]
        public long Id { get; set; }

        private Employee employee = new Employee();

        private bool isSuccess = false;
        private string message = "";

        protected override async Task OnInitializedAsync()
        {
            employee = await httpClient.GetJsonAsync<Employee>($"api/Employees/{Id}");
        }

        public async Task EditEmployee()
        {
            await httpClient.SendJsonAsync(HttpMethod.Put, $"api/Employees/{Id}", employee);
            isSuccess = true;
            message = "Done!";
            ClearFields();
            StateHasChanged();
        }

        private void ClearFields()
        {
            employee.Name = string.Empty;
            employee.Area = string.Empty;
        }
    }
}
