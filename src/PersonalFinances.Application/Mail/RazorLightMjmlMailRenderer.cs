using Mjml.Net;
using PersonalFinances.Application.DTOs;
using RazorEngine.Templating;
using RazorLight;
using System.Text.RegularExpressions;

namespace PersonalFinances.Application.Mail
{
    public class RazorLightMjmlMailRenderer : IHtmlMailRenderer
    {
        private string TEMPLATE_KEY = "AccountCreatedConfirmation";
        private readonly RazorLightEngine _razor;
        private readonly IMjmlRenderer _mjml;
        private readonly IMailTemplateProvider _templates;
        private readonly MjmlOptions options = new();

        public RazorLightMjmlMailRenderer(IRazorEngineService razor, IMjmlRenderer mjml, IMailTemplateProvider templates)
        {
            _razor = new RazorLightEngineBuilder()
                .UseMemoryCachingProvider()
                .EnableDebugMode()
                .Build();

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
        (current, rule) => Regex.Replace(current, $@"(?<!@)@{rule}\b", $"@@{rule}"));

        private string EscapeCssFontWeightsInRazorTemplate(string mjmlOutput) =>
        mjmlOutput.Replace(":wght@", ":wght@@");
        #endregion

        public string RenderHtmlEmail(AccountForSendingMailDto model)
        {
            var templateContent = CompileMjml();
            return _razor.CompileRenderStringAsync(TEMPLATE_KEY, templateContent, model)
                .GetAwaiter()
                .GetResult();
        }
        private string CompileMjml()
        {
            var mjmlSource = _templates.AccountCreatedConfirmation;
            var (mjmlOutput, errors) = _mjml.Render(mjmlSource, options);

            if (errors.Any())
            {
                var allErrors = string.Join("\n", errors.Select(e => $"Line {e.Position}: {e.Error}"));
                throw new Exception($"Erro ao compilar MJML:\n{allErrors}");
            }

            mjmlOutput = EscapeCssRulesInRazorTemplate(mjmlOutput);
            mjmlOutput = EscapeCssFontWeightsInRazorTemplate(mjmlOutput);

            return mjmlOutput;
        }
    }
}
