using BusinessIn.Domain.DbMapping.Entities;
using MediatR;

namespace BusinessIn.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommand : IRequest<EmployeeEntity> { 
    public EmployeeEntity Employee;
}