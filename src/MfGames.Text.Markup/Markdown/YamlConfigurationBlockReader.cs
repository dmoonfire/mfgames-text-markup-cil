// <copyright file="YamlConfigurationBlockReader.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    using System.Text;

    /// <summary>
    /// Parses a YAML configuration block, but only if it is the first
    /// element in the document.
    /// </summary>
    public class YamlConfigurationBlockReader : BlockReaderBase
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public override MarkdownBlockType BlockType
        {
            get
            {
                return MarkdownBlockType.Metadata;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="markdownReader">
        /// </param>
        /// <param name="input">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool CanRead(
            MarkdownReader markdownReader, 
            InputBuffer input)
        {
            // If the markdown reader doesn't have metadata blocks enables,
            // then skip it.
            if (!markdownReader.Options.AllowMetadata)
            {
                return false;
            }

            // If we aren't the first line, then skip it.
            if (input.LineIndex != 1)
            {
                return false;
            }

            // If the first line isn't a "---", then it isn't a YAML.
            if (input.CurrentLine != "---")
            {
                return false;
            }

            // If we got this far, then we can parse it.
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="reader">
        /// </param>
        /// <param name="input">
        /// </param>
        /// <returns>
        /// </returns>
        public override BlockReadStatus Read(
            MarkdownReader reader, 
            InputBuffer input)
        {
            // Figure out if we need a metadata start.
            switch (reader.ElementType)
            {
                case MarkupElementType.YamlMetadata:
                    reader.SetState(MarkupElementType.EndMetadata);
                    return BlockReadStatus.Continue;

                case MarkupElementType.EndMetadata:
                    return BlockReadStatus.Finished;
            }

            // Right now, we only support YAML headers. Grab the first "---" and then
            // loop through until we find the last one.
            var buffer = new StringBuilder();

            buffer.AppendLine(input.CurrentLine);

            do
            {
                input.ReadNext();
                buffer.AppendLine(input.CurrentLine);
            }
            while (input.CurrentLine != "---");

            // Gather up the elements and set it.
            input.ReadNext();
            reader.SetState(
                MarkupElementType.YamlMetadata, 
                buffer.ToString());
            return BlockReadStatus.Continue;
        }

        #endregion
    }
}