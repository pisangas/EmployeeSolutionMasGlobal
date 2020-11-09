$(document).ready(function () {
    SearchEmployees();

    $("#btnSearch").click(function () {
        var Id = $("#txtId").val();
        $("#dtEmployees").detach();
        SearchById(Id);
    });
});

function SearchById(Id) {
    $(document).ready(function () {
        $('#dtEmployees').DataTable({
            ajax: {
                url: 'https://localhost:44359/api/Employee/?Id' + Id,
                dataSrc: ''
            },
            columns: [
                { data: 'AnnualSalary' },
                { data: 'ContractTypeName' },
                { data: 'EmployeeId' },
                { data: 'Name' },
                { data: 'RoleDescription' },
                { data: 'RoleId' },
                { data: 'RoleName' },
            ]
        });
    });
}

function SearchEmployees() {

    $(document).ready(function () {
        $('#dtEmployees').DataTable({
            ajax: {
                url: 'https://localhost:44359/api/Employee/',
                dataSrc: ''
            },
            columns: [
                { data: 'AnnualSalary' },
                { data: 'ContractTypeName' },
                { data: 'EmployeeId' },
                { data: 'Name' },
                { data: 'RoleDescription' },
                { data: 'RoleId' },
                { data: 'RoleName' },
            ]
        });
    });
}