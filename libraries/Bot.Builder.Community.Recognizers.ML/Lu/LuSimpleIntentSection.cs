using System;
namespace Bot.Builder.Community.Recognizers.ML.Lu
{
    public class LuSimpleIntentSection : LuSection
    {
        public LuSimpleIntentSection() : base(LuSectionTypes.SimpleIntentSection)
        {
        }

        public object MyProperty { get; set; }
    }
}
