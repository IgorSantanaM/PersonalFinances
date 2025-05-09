
using PersonalFinances.Application.Helpers;
using PersonalFinances.Application.Mail;

public class EmbeddedResourceMailTemplateProvider : IMailTemplateProvider {
	public string OrderConfirmationMjml => EmbeddedResource.ReadAllText("AccountCreatedConfirmation.csmjml");
}

