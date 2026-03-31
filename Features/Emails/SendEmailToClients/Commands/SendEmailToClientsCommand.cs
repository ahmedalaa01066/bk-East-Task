using EasyTask.Common.Requests;
using EasyTask.Features.Common.Emails.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Emails;

namespace EasyTask.Features.Emails.SendEmailToClients.Commands
{
    public record SendEmailToClientsCommand(List<string> toEmails, string subject, string body) : IRequestBase<bool>;
    public class SendEmailToClientsCommandHandler : RequestHandlerBase<Email, SendEmailToClientsCommand, bool>
    {
        public SendEmailToClientsCommandHandler(RequestHandlerBaseParameters<Email> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(SendEmailToClientsCommand request, CancellationToken cancellationToken)
        {

            EmailDTO emaildto = await EmailHelper.SendEmailAsync(request.toEmails, request.subject, request.body);
            if (emaildto != null)
            {
                Email email = new Email { Subject = emaildto.Subject, Body = emaildto.Body, EmailAdresses = emaildto.EmailAdresses };
                _repository.Add(email);  // Don't call SaveChanges here
                                         // _repository.SaveChanges(); // Don't call this again because the middleware will handle it
            }

            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }

    }

}
