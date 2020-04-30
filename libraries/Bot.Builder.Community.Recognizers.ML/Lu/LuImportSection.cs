namespace Bot.Builder.Community.Recognizers.ML.Lu
{
    internal class LuImportSection : LuSection
    {

        public LuImportSection(string desc, string path) : base(LuSectionTypes.ImportSection)
        {
            this.Desc = desc;
            this.Path = path;
        }

        public string Desc { get; set; }
        public string Path { get; set; }

        protected override string GenerateId()
        {
            return $"{base.GenerateId()}_{this.Path}";
        }
    }
}