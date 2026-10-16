using System;

namespace ParaDesk.Rdp
{
    /// <summary>将用户选择的账户身份传给 RDP，保留在线身份提供方的限定名。</summary>
    internal struct RdpCredentialName
    {
        public string Domain { get; private set; }
        public string UserName { get; private set; }
        public bool ProviderQualified { get; private set; }

        public static RdpCredentialName Parse(string savedName)
        {
            string name = savedName ?? "";
            int separator = name.IndexOf('\\');
            string prefix = separator > 0 ? name.Substring(0, separator) : "";
            bool provider = string.Equals(prefix, "MicrosoftAccount", StringComparison.OrdinalIgnoreCase)
                || string.Equals(prefix, "AzureAD", StringComparison.OrdinalIgnoreCase);

            // Keep online-provider identities in their explicit qualified form.
            // Treat only traditional machine/domain prefixes as the Domain field.
            if (separator > 0 && !provider)
            {
                return new RdpCredentialName
                {
                    Domain = prefix,
                    UserName = name.Substring(separator + 1),
                    ProviderQualified = false
                };
            }
            return new RdpCredentialName
            {
                Domain = "",
                UserName = name,
                ProviderQualified = provider
            };
        }
    }
}
