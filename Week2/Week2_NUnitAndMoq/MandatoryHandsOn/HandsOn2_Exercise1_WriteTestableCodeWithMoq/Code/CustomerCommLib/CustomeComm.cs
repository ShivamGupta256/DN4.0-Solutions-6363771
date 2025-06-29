namespace CustomerCommLib
{
    public class CustomeComm
    {
        private readonly IMailSender _mailSender;

        public CustomeComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            return _mailSender.SendMail("cust123@abc.com", "Some Message");
        }
    }
}