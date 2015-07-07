using System;
using System.IO;
using System.Linq;
using EighthBit.Collection;
using Xunit;

namespace EighthBit.Trie.Tests
{
    public class GeneralTrieTests
    {
        [Fact]
        public void Once()
        {
            var trie = new Trie<string, string>();
            trie.Add("123", "hello");

            var get = trie.Values("123").Single();
            Assert.Equal("hello", get);
        }

        [Fact]
        public void Twice()
        {
            var trie = new Trie<string, string>();
            trie.Add("123", "hello");
            trie.Add("123", "bye");

            var get = trie.Values("123");
            Assert.Equal("bye", get.First());
            Assert.Equal("hello", get.Last());
        }

        [Fact]
        public void TwiceOnNearTrieIncorrect()
        {
            var trie = new Trie<string, string>();
            trie.Add("1233", "hello");
            trie.Add("123", "bye");

            var get = trie.Values("12");
            Assert.True(!get.Any());
        }

        [Fact]
        public void TwiceOnNearTrieCorrect()
        {
            var trie = new Trie<string, string>();
            trie.Add("1233", "hello");
            trie.Add("123", "bye");

            var get = trie.Values("1234");
            Assert.Equal("bye", get.Single());
        }

        [Fact]
        public void TwiceOnTrieCorrect()
        {
            var trie = new Trie<string, string>();
            trie.Add("123", "hello");
            trie.Add("123", "bye");

            var get = trie.Values("1234");
            Assert.Equal(new[] { "bye", "hello" }, get.ToArray());
        }

        [Fact]
        public void TrieOnce()
        {
            var trie = new Trie<string, string>();
            trie.Add("123", "hello");

            var get = trie.Values("123").Single();
            Assert.Equal("hello", get);
        }

        [Serializable]
        class FakeData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        }

        [Fact]
        public void NoKey()
        {
            var trie = new Trie<string, string>();
            trie.Add("123", "hello");

            var get = trie.Values("43").SingleOrDefault();
            Assert.Null(get);
        }

        [Fact]
        public void EmptyTrie()
        {
            var trie = new Trie<string, string>();

            var get = trie.Values("43").SingleOrDefault();
            Assert.Null(get);
        }

        [Fact]
        public void SaveTrie()
        {
            var trie = new Trie<string, FakeData>();
            trie.Add("123", new FakeData { Id = 1, Name = "123", Description = "D 123" });
            trie.Add("1234", new FakeData { Id = 2, Name = "1234", Description = "D 1234" });
            trie.Add("45", new FakeData { Id = 3, Name = "45", Description = "D 45" });

            var origSave = new MemoryStream();
            trie.Save(origSave);
            origSave.Position = 0;

            var reload = new Trie<string, FakeData>();
            reload.Load(origSave);

            var reloadSave = new MemoryStream();
            reload.Save(reloadSave);

            Assert.Equal(origSave.ToArray(), reloadSave.ToArray());
        }
    }
}
