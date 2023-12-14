using System.Drawing;

namespace NotePadLibrary
{
    public struct TextBoxState
    {
        public string Text { get; set; }
        public Font Font { get; set; }
        public TextBoxState(string text, Font font)
        {
            Text = text;
            Font = font;
        }
    }
}