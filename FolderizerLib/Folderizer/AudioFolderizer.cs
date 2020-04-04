using FolderizerLib.Configuration;
using FolderizerLib.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderizerLib
{
    /// <summary>
    /// This class provides means to dynamically organize audio files from a directory into a given folder structure.
    /// </summary>
    public class AudioFolderizer : Folderizer, IAudioFolderizer
    {
        public AudioFolderizer(ConfigurationOptions configs) : base(configs)
        {

        }

        private List<AudioTag> _tagsSequence;
        public List<AudioTag> TagsSequence {
            get => _tagsSequence;
            private set => _tagsSequence = OrganizationSequenceValidator.ValidateSequence(value);
        }

        public void SetOrganizationSequence(params AudioTag[] tags)
        {
            TagsSequence = tags.ToList();
        }


        public override void Execute()
        {
            
        }

        public override void GenerateTreeView()
        {
            throw new NotImplementedException();
        }

    }
}
