using FolderizerLib;
using FolderizerLib.Configuration;
using FolderizerLib.Tags;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using static System.Environment;

namespace FolderizerLibTest.UnitTests
{
    class AudioFolderizerTest
    {
        private ConfigurationOptions Configurations { get; set; }
        private AudioFolderizer AudioFolderizer { get; set; }
        

        public AudioFolderizerTest()
        {
            DirectoryInfo i = new DirectoryInfo(TestPaths.ValidBasePath);

            foreach (string file in Directory.GetFiles(TestPaths.RootTestFolderPath))
            {
                string fileDestinationName = file.Split("\\").Last();
                // Copies the test files to the directory in the path to be used as base path, if they haven't been yet.
                try
                {
                    File.Copy(file, Path.Combine(TestPaths.ValidBasePath, fileDestinationName));
                }
                catch (Exception e)
                {
                    return;
                }
            }
        }

        [SetUp]
        public void Setup()
        {
            Configurations = new ConfigurationOptions();
            AudioFolderizer = new AudioFolderizer(Configurations);
            //
            Directory.Delete(TestPaths.ValidMountingPath);
        }

        [Test]
        public void SetOrganizationSequence_WhenProvidedASingleTag_TagSequencePropertyShouldContainTheGivenTag()
        {
            AudioFolderizer.SetOrganizationSequence(AudioTag.Album);
            Assert.True(AudioFolderizer.TagsSequence.Contains(AudioTag.Album));
        }

        [Test]
        public void SetOrganizationSequence_WhenProvidedAValidSequenceOfTwoTags_TagSequencePropertyShouldContainTheGivenSequence()
        {
            AudioFolderizer.SetOrganizationSequence(AudioTag.Genre, AudioTag.Album);
            Assert.True(AudioFolderizer.TagsSequence[0] == AudioTag.Genre);
            Assert.True(AudioFolderizer.TagsSequence[1] == AudioTag.Album);
        }

        [Test]
        public void SetOrganizationSequence_WhenProvidedDuplicateTags_ShouldThrowInvalidTagSequenceException()
        {
            Assert.Throws(typeof(InvalidTagSequenceException), () => AudioFolderizer.SetOrganizationSequence(AudioTag.Genre, AudioTag.Genre));
        }

        [Test]
        public void SetOrganizationSequence_WhenAlbumTagIsNotLocatedInLastPosition_ShouldThrowInvalidTagSequenceException()
        {
            Assert.Throws(typeof(InvalidTagSequenceException), () => AudioFolderizer.SetOrganizationSequence(AudioTag.Album, AudioTag.Year, AudioTag.Artist));
        }

        [Test]
        public void SetOrganizationSequence_WhenAlbumTagIsPresentInLastPosition_ShouldNotThrowInvalidTagSequenceException()
        {
            AudioFolderizer.SetOrganizationSequence(AudioTag.Year, AudioTag.Artist, AudioTag.Album);
        }

        [Test]
        public void Execute_WhenValidBasePathAndCriteriaOneTag_ShouldResultProperDirectoryStructure()
        {
            AudioFolderizer.SetOrganizationSequence(AudioTag.Album);
            AudioFolderizer.Execute();
            // TODO
        }

    }
}
