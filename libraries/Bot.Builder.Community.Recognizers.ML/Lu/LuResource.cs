using System;
using System.Collections.Generic;
using System.Linq;

namespace Bot.Builder.Community.Recognizers.ML.Lu
{
    public class LuResource
    {
        public LuResource(List<LuSection> sections = null, List<LuErrors> errors = null, List<Diagnostic> diagnostics = null)
        {
            this.Sections = sections ?? new List<LuSection>();
        }

        public List<LuSection> Sections { get; set; }

        public List<LuErrors> Errors { get; set; }

        public List<Diagnostic> Diagnostics { get; set; }

        public LuResource Union(LuResource outputItem)
        {
            this.Sections = this.Sections.Union(outputItem.Sections).ToList();
            this.Errors = this.Errors.Union(outputItem.Errors).ToList();
            this.Diagnostics = this.Diagnostics.Union(outputItem.Diagnostics).ToList();

            return this;
        }
    }
}
