using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace PepperMintDemo.Localization
{
    public static class PepperMintDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    PepperMintDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PepperMintDemoLocalizationConfigurer).GetAssembly(),
                        "PepperMintDemo.Localization.PepperMintDemo"
                    )
                )
            );
        }
    }
}