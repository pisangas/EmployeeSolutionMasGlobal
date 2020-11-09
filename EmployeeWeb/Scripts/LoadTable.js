$(document).ready(function () {
    $('#dtEmployees').DataTable({
        ajax: {
            url: 'https://localhost:44359/api/Employee/',
            dataSrc: ''
        },
        columns: [
            { data: 'EmployeeId' },
            { data: 'Name' },
            { data: 'RoleId' },
            { data: 'RoleName' },
            { data: 'RoleDescription' },
            { data: 'ContractTypeName' },
            { data: 'AnnualSalary' },
        ]
    });
});