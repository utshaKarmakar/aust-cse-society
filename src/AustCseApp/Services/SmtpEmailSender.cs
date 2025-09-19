using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace AustCseApp.Services
{
	public class SmtpOptions
	{
		public string Host { get; set; } = "";
		public int Port { get; set; } = 587;
		public bool EnableSsl { get; set; } = true;
		public string Username { get; set; } = "";
		public string Password { get; set; } = "";
		public string FromAddress { get; set; } = "";
		public string FromDisplayName { get; set; } = "AUST CSE Portal";
		public string DeptHeadEmail { get; set; } = "headcse@aust.edu";
	}

	public class SmtpEmailSender : IEmailSender
	{
		private readonly SmtpOptions _opt;

		public SmtpEmailSender(IOptions<SmtpOptions> opt)
		{
			_opt = opt.Value;
		}

		public async Task SendAsync(string to, string subject, string htmlBody, string? from = null)
		{
			using var client = new SmtpClient(_opt.Host, _opt.Port)
			{
				EnableSsl = _opt.EnableSsl,
				Credentials = new NetworkCredential(_opt.Username, _opt.Password)
			};

			var msg = new MailMessage
			{
				From = new MailAddress(string.IsNullOrWhiteSpace(from) ? _opt.FromAddress : from, _opt.FromDisplayName),
				Subject = subject,
				Body = htmlBody,
				IsBodyHtml = true
			};
			msg.To.Add(to);

			await client.SendMailAsync(msg);
		}
	}
}
