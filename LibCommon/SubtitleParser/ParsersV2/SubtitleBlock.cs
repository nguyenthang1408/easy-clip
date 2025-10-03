using System;
using System.Collections.Generic;

namespace SubtitlesParser.ParsersV2
{
    // Subtitle block class.
    /// <summary>
    /// Subtitle block is a class holds order number, starting and ending time of subtitle and lines of contents.
    /// </summary>
    public class SubtitleBlock
    {
        // Ordered number of subtitles
        /// <summary>
        /// Order number of subtitle blocks.
        /// </summary>
        public int OrderNumber;

        /// <summary>
        /// Starting time of subtitle block.
        /// </summary>
        // Starting time of subtitle.
        public TimeSpan StartTime;

        // Ending time of subtitle.
        /// <summary>
        /// Ending time of subititle.
        /// </summary>
        public TimeSpan EndTime;

        // Ending time of subtitle.
        /// <summary>
        /// Ending time of subititle.
        /// </summary>
        public TimeSpan EndTimeExtern;

        // Multiple-line text content of subtitle.
        /// <summary>
        /// Lines of text contents.
        /// </summary>
        public List<string> InlineTextList;
    }
}
