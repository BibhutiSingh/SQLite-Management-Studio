using ScintillaNET;
using System.Drawing;

namespace SQLite_Management_Studio.Helpers
{
    public static class SyntaxHighlighterHelper
    {
        public static void ApplySqlHighlighting(this ScintillaNET.Scintilla txtScintilla)
        {

            InitSyntaxColoring(txtScintilla);

            // NUMBER MARGIN
            InitNumberMargin(txtScintilla);
        }
        private static void InitNumberMargin(ScintillaNET.Scintilla txt)
        {
            int BACK_COLOR = 0xCCCCCC;
            int FORE_COLOR = 0x212121;
            int NUMBER_MARGIN = 1;
            txt.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            txt.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            txt.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            txt.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = txt.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
        }
        private static void InitSyntaxColoring(ScintillaNET.Scintilla txt)
        {
            // Configure the default style
            txt.StyleResetDefault();
            txt.Styles[Style.Default].Font = "Consolas";
            txt.Styles[Style.Default].Size = 12;
            txt.Styles[Style.Default].BackColor = IntToColor(0xFFFFFF);
            txt.Styles[Style.Default].ForeColor = Color.Black;
            txt.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            txt.Styles[Style.Sql.Identifier].ForeColor = Color.Black;
            txt.Styles[Style.Sql.Comment].ForeColor = Color.Green;
            txt.Styles[Style.Sql.CommentLine].ForeColor = Color.Green;
            txt.Styles[Style.Sql.CommentDoc].ForeColor = Color.Green;
            txt.Styles[Style.Sql.Number].ForeColor = Color.Green;
            txt.Styles[Style.Sql.String].ForeColor = Color.Red;
            txt.Styles[Style.Sql.Character].ForeColor = Color.Red;
            txt.Styles[Style.Sql.Operator].ForeColor = Color.Red;
            txt.Styles[Style.Sql.CommentLineDoc].ForeColor = Color.Green;
            txt.Styles[Style.Sql.Word].ForeColor = Color.Blue;
            txt.Styles[Style.Sql.Word2].ForeColor = Color.Purple;
            txt.Styles[Style.Sql.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            txt.Styles[Style.Sql.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
            txt.LexerName = "sql";

            txt.SetKeywords(0, "select from where group by having delete update insert values into create table");
            txt.SetKeywords(1, "* desc set rownum top min max avg count asc not null primary key autoincrement");


        }
        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}
