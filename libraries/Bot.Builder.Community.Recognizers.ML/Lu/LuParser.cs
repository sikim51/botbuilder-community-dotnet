using System;
using System.Linq;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Bot.Builder.Community.Recognizers.ML.Lu
{
    public class LuParser
    {
        public LuParser()
        {
        }

        protected static IParseTree AntlrParse(string fileContent)
        {
            var inputStream = new AntlrInputStream(fileContent);
            var lexer = new LUFileLexer(inputStream);
            lexer.RemoveErrorListeners();
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new LUFileParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.BuildParseTree = true;
            return parser.file();
        }


        private class LuResourceTransformer : LUFileParserBaseVisitor<object>
        {

            private readonly LuResource _luResource;

            public LuResourceTransformer(LuResource luResource)
            {
                this._luResource = luResource;
            }

            public LuResource Transform(IParseTree parseTree)
            {
                if (parseTree != null)
                {
                    Visit(parseTree);
                }
                
                return this._luResource;
            }

            public override object VisitImportSection([NotNull] LUFileParser.ImportSectionContext context)
            {

                string desc = context.importDefinition().IMPORT_DESC().GetText();
                string path = context.importDefinition().IMPORT_PATH().GetText().Replace("(","").Replace(")","");

                if (string.IsNullOrEmpty(path))
                {
                    _luResource.Diagnostics.Add(BuildLuResourceDiagnostic(string.Format(LuErrors.ImportPathEmpty, context.GetText()), context));
                }

                _luResource.Sections.Add(new LuImportSection(desc, path));

                return null;
            }

            public override object VisitNestedIntentSection([NotNull] LUFileParser.NestedIntentSectionContext context) {

                var name = context.nestedIntentNameLine().nestedIntentName().GetText().Trim();
                
                if (IsSectionEnabled())
                {
                    //_luResource.Sections.Add(new LuNestedIntentSection(name,body));
                }

                return null;
            }

            public override object VisitSimpleIntentSection([NotNull] LUFileParser.SimpleIntentSectionContext context) {
                return null;
            }

            public override object VisitModelInfoSection([NotNull] LUFileParser.ModelInfoSectionContext context) {

                string modelInfo = context.modelInfoDefinition().GetText();
                _luResource.Sections.Add(new LuModelInfoSection(modelInfo));

                return null;
            }

            private bool IsSectionEnabled()
            {
                var modelsSections = this._luResource.Sections.Where(section => section.SectionType == LuSectionTypes.ModelInfoSection).Cast<LuModelInfoSection>();

                bool enableSections = false;

                foreach(var modelInfo in modelsSections)
                {
                    var line = modelInfo.ModelInfo;
                    var kvPair = Regex.Split(line, "/@(enableSections).(.*)=/g").Select(item => item.Trim()).ToArray();
                    if (kvPair.Length== 4)
                    {
                        if(kvPair[1] == "enableSections" && kvPair[3] == "true")
                        {
                            enableSections = true;
                            break;
                        }
                    }
                }

                return enableSections;
            }

            private Diagnostic BuildLuResourceDiagnostic(string errorMessage, ParserRuleContext context, DiagnosticSeverity severity = DiagnosticSeverity.Error)
            {
                return new Diagnostic(context.ConvertToRange(), errorMessage, severity);
            }

        }
    }
}