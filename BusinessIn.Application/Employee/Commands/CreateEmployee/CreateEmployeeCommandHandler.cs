using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.DbMapping.Entities;
using MediatR;

namespace BusinessIn.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler(IEmployeesRepository userRepository)
    : IRequestHandler<CreateEmployeeCommand, EmployeeEntity> {
    
    public async Task<EmployeeEntity> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken) {
        try {
            await userRepository.Create(request.Employee);
            // if (employee == null) errorOr.S;
        } catch (Exception e) {
            return null;
        }

        return null;
    }
}