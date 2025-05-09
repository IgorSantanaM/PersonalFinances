using Mjml.Net;
using PersonalFinances.Domain.Accounts;
using RazorEngine.Templating;

namespace PersonalFinances.Application.Mail
{
    public class RazorEngineMjmlMailRenderer : IHtmlMailRenderer
    {
        private string TEMPLATE_KEY = "AccountCreatedEmailTemplate";
        private readonly IRazorEngineService _razor;
        private readonly IMjmlRenderer _mjml;
        private readonly IMailTemplateProvider _templates;
        private readonly MjmlOptions options = new();

        public RazorEngineMjmlMailRenderer(IRazorEngineService razor, IMjmlRenderer mjml, IMailTemplateProvider templates)
        {
            _razor = razor;
            _mjml = mjml;
            _templates = templates;
        }
        #region cssRules
        private readonly string[] cssAtRules = [
        "bottom-center", "bottom-left", "bottom-left-corner", "bottom-right", "bottom-right-corner", "charset", "counter-style",
        "document", "font-face", "font-feature-values", "import", "left-bottom", "left-middle", "left-top", "keyframes", "media",
        "namespace", "page", "right-bottom", "right-middle", "right-top", "supports", "top-center", "top-left", "top-left-corner",
        "top-right", "top-right-corner"
        ];

        private string EscapeCssRulesInRazorTemplate(string mjmlOutput) =>
        cssAtRules.Aggregate(mjmlOutput,
            (current, rule) => current.Replace($"@{rule}", $"@@{rule}"));

        private string EscapeCssFontWeightsInRazorTemplate(string mjmlOutput) =>
        mjmlOutput.Replace(":wght@", ":wght@@");
        #endregion

        public string RenderHtmlEmail(Account model)
        {
            if (!_razor.IsTemplateCached(TEMPLATE_KEY, typeof(Account))) CacheTemplate();
            return _razor.Run(TEMPLATE_KEY, typeof(Account), model);
        }
        private void CacheTemplate()
        {
            var razorSource = CompileMjml();
            _razor.AddTemplate(TEMPLATE_KEY, razorSource);
            _razor.Compile(TEMPLATE_KEY, typeof(Account));
        }

        private string CompileMjml()
        {
            var mjmlSource = _templates.OrderConfirmationMjml;
            var (mjmlOutput, errors) = _mjml.Render(mjmlSource, options);
            if (errors.Any()) throw new(errors.First().Error);
            mjmlOutput = EscapeCssRulesInRazorTemplate(mjmlOutput);
            mjmlOutput = EscapeCssFontWeightsInRazorTemplate(mjmlOutput);
            return mjmlOutput;
        }
    }
}
