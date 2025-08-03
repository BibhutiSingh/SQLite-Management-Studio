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

            txt.SetKeywords(0, "abort action add after all alter always analyze and as asc attach autoincrement before begin between by cascade case cast check collate column commit conflict constraint create cross current current_date current_time current_timestamp database default deferrable deferred delete desc detach distinct do drop each else end escape except exclude exclusive exists explain fail filter first following for foreign from full generated glob group groups having if ignore immediate in index indexed initially inner insert instead intersect into is isnull join key last left like limit match materialized natural no not nothing notnull null nulls of offset on or order others outer over partition plan pragma preceding primary query raise range recursive references regexp reindex release rename replace restrict returning right rollback row rows savepoint select set table temp temporary then ties to transaction trigger unbounded union unique update using vacuum values view virtual when where window with without");
            txt.SetKeywords(1, "* set rownum top min max avg count sum total group_concat string_agg int integer tinyint smallint mediumint bigint unsigned big int int2 int8 character varchar varying character nchar native character nvarchar text clob blob real double double precision float numeric decimal boolean date datetime");


        }
        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}
