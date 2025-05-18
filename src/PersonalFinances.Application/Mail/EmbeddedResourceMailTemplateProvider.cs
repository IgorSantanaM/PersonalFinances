
using PersonalFinances.Application.Helpers;
using PersonalFinances.Application.Mail;

public class EmbeddedResourceMailTemplateProvider : IMailTemplateProvider {
	public string AccountCreatedConfirmation => EmbeddedResource.ReadAllText("AccountCreatedConfirmation.csmjml");
}

