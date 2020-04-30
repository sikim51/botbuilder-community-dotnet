using System;
namespace Bot.Builder.Community.Recognizers.ML.Lu
{
    public class LuSection
    {
        
        public LuSection(LuSectionTypes sectionTypes)
        {
            this.SectionType = sectionTypes;
        }

        public LuSectionTypes SectionType { get; }

        public string Id { get => GenerateId(); }

        protected virtual string GenerateId()
        {
            return $"{Enum.GetName(typeof(LuSectionTypes), SectionType)}";
        }
    }
}
