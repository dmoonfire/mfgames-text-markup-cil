// <copyright file="BlockReaderBase.cs" company="Moonfire Games">
//     Copyright (c) Moonfire Games. Some Rights Reserved.
// </copyright>
// MIT Licensed (http://opensource.org/licenses/MIT)
namespace MfGames.Text.Markup.Markdown
{
    /// <summary>
    /// Base implementation for a block reader, a reader designed to parse the
    /// high-level blocks inside Markdown.
    /// </summary>
    public abstract class BlockReaderBase
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public virtual MarkdownBlockType BlockType
        {
            get
            {
                return MarkdownBlockType.Content;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// </summary>
        protected bool Initialized { get; set; }

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
        public virtual bool CanRead(
            MarkdownReader markdownReader, 
            InputBuffer input)
        {
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="reader">
        /// </param>
        /// <param name="input">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual BlockReadStatus Read(
            MarkdownReader reader, 
            InputBuffer input)
        {
            return BlockReadStatus.Finished;
        }

        /// <summary>
        /// </summary>
        public virtual void Reset()
        {
            this.Initialized = false;
        }

        #endregion
    }
}