namespace Vtys.Core.Attributes
{
    public class TextAttribute : Attribute
    {
        private string _text;

        public TextAttribute(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
    }
}
