namespace BlazorApp4.Client.Pages.Employees
{
    using BlazorApp4.Shared.Models;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using System.Threading.Tasks;
    public partial class AddEmployee
    {
        private Employee employee = new Employee();

        private bool isSuccess = false;
        private string message = "";

        public async Task PostEmployee()
        {
            await httpClient.SendJsonAsync(HttpMethod.Post, $"api/Employees", employee);
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
