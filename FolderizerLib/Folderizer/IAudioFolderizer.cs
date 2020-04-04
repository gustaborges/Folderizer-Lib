using FolderizerLib.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolderizerLib
{
    /// <summary>
    /// Provides an interface for <see cref="Folderizer"/> implementations that handle audio files, such as
    /// <see cref="AudioFolderizer"/>.
    /// </summary>
    public interface IAudioFolderizer
    {
        /// <summary>
        /// <para>Sets the desired organization structure which will be used to organize the audio files of the given directory.</para>
        /// <para>The exception <see cref="InvalidTagSequenceException" /> will be thrown if:</para>
        /// <list type="bullet">
        /// <item><description>When used, <see cref="AudioTag.Album"/> is not placed at the last position of the organization sequence;</description></item>
        /// <item><description>There are duplicates <see cref="AudioTag"/>.</description></item>
        /// </list>
        /// <example>
        /// Correct usage example:
        /// <code>
        /// AudioFolderizer.SetOrganizationSequence(AudioTags.Year, AudioTags.Artist, AudioTags.Album);
        /// </code>
        /// </example>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        void SetOrganizationSequence(params AudioTag[] tags);

        /// <summary>
        /// Provides access to the organization sequence defined in <see cref="SetOrganizationSequence"/>
        /// </summary>
        public List<AudioTag> TagsSequence { get; }
    }
}
