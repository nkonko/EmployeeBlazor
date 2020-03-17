namespace BlazorApp4.Client.Pages.Employees
{
    using BlazorApp4.Shared.Models;
    using Microsoft.AspNetCore.Components;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public partial class EmployeeList
    {
        bool showModal = false;

        public List<Employee> Employees { get; set; } = new List<Employee>();

        private Employee employee = new Employee();

        protected override async Task OnInitializedAsync() => await GetEmployees();

        void ModalShow() => showModal = true;
        void ModalCancel() => showModal = false;

        public async Task DeleteEmployee(int Id)
        {
            await GetEmployee(Id);
            await httpClient.SendJsonAsync(HttpMethod.Delete, $"api/Employees/{Id}", employee);
            showModal = false;
            await GetEmployees();
            StateHasChanged();
        }

        private async Task GetEmployee(int Id)
        {
            employee = await httpClient.GetJsonAsync<Employee>($"api/Employees/{Id}");
        }

        private async Task GetEmployees()
        {
            Employees = await httpClient.GetJsonAsync<List<Employee>>("api/Employees");
        }
    }
}
