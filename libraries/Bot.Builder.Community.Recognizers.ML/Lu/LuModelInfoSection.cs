using System;
namespace Bot.Builder.Community.Recognizers.ML.Lu
{
    public class LuModelInfoSection : LuSection
    {
        public LuModelInfoSection(string modelInfo) : base(LuSectionTypes.ModelInfoSection)
        {
            this.ModelInfo = modelInfo;
        }

        public string ModelInfo { get; set; }

        protected override string GenerateId()
        {
            return $"{base.GenerateId()}_{ModelInfo}";
        }
    }
}
