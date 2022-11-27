using AutoMapper;
using Grpc.Core;
using LoansAPI.DataAccess;

namespace LoansAPI.Protos
{
    public class LoansService : LoanService.LoanServiceBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LoansService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public override Task<LoanResponse> SetReturnDate(LoanRequest request, ServerCallContext context)
        {
            var loan = unitOfWork.LoansRepository.GetById(request.Id);

            if (loan is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Loan not found"));

            unitOfWork.LoansRepository.SetReturnDate(request.Id);
            unitOfWork.SaveChanges();
            return Task.FromResult(new LoanResponse
            {
                Message = "Loan return date successfully updated",
                Success = true
            });
        }
    }
}
