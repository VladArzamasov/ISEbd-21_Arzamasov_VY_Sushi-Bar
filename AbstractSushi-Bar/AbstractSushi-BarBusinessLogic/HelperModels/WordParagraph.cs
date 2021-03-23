using System.Collections.Generic;

namespace AbstractSushi_BarBusinessLogic.HelperModels
{
    class WordParagraph
    {
        public List<(string, WordParagraphProperties)> Texts { get; set; }
        public WordParagraphProperties TextProperties { get; set; }
    }
}
