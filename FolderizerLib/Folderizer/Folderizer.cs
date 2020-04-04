using FolderizerLib.Configuration;
using FolderizerLib.Tags;
using System.Collections.Generic;

namespace FolderizerLib
{
    /// <summary>
    /// <para>This is an abstract class. In order to use Folderizer, you should use one of its implementations.</para>
    /// <para>Take a look at: <see cref="FolderizerLib.AudioFolderizer"/></para>
    /// </summary>
    public abstract class Folderizer
    {
        protected ConfigurationOptions Configuration { get; set; }
        public Folderizer(ConfigurationOptions configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Runs Folderizer and organizes the files supported the <see cref="Folderizer"/> implementation, respecting the given folder structure.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Generates a JSON object mapped with the mounted folder structure.
        /// </summary>
        public abstract void GenerateTreeView();

    }
}

