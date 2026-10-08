using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Common.Results;
using bdoProject.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Commands.AnswerRequest;

public sealed class AnswerRequestHandler : IRequestHandler<AnswerRequestCommand, Result<string>>
{
    private readonly IDataContext _context;

    public AnswerRequestHandler(IDataContext context) => _context = context;

    public async Task<Result<string>> Handle(AnswerRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId, cancellationToken);

        if (employee == null)
            return Result<string>.Failure(ErrorResults.NotFoundMessage("თანამშრომელი ვერ მოიძებნა!"));

        var leaveRequest = await _context.LeaveRequests
            .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId &&
                                      x.Id == request.RequestId, cancellationToken);
        
        if (leaveRequest == null)
            return Result<string>.Failure(ErrorResults.NotFoundMessage("თანამშრომელის მოთხოვნა ვერ მოიძებნა!"));
        
        if (leaveRequest.Status == LEAVE_REQUEST_STATUS.Cancelled)
            return Result<string>.Failure(ErrorResults.NotFoundMessage("მოთხოვნის სტატუსის შეცვლა შეუძლებელია!"));

        LEAVE_REQUEST_STATUS status = request.IsAccepted switch
        {
            true => LEAVE_REQUEST_STATUS.Approved,
            _ => LEAVE_REQUEST_STATUS.Rejected
        };
        
        leaveRequest.ChangeStatus(status, request.Message);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Result<string>.Success("წარმატებით შეიცვალა მოთხოვნის სტატუსი!");
    }
}