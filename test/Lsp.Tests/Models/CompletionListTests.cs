using System;
using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using OmniSharp.Extensions.LanguageServer.Protocol;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization;
using Xunit;

namespace Lsp.Tests.Models
{
    public class CompletionListTests
    {
        [Theory, JsonFixture]
        public void SimpleTest(string expected)
        {
            var model = new CompletionList(new List<CompletionItem>() { new CompletionItem()
            {
                Kind = CompletionItemKind.Class,
                Detail = "details"
            } });
            var result = Fixture.SerializeObject(model);

            result.Should().Be(expected);

            var deresult = new Serializer(ClientVersion.Lsp3).DeserializeObject<CompletionList>(expected);
            deresult.ShouldBeEquivalentTo(model);
        }

        [Theory, JsonFixture]
        public void ComplexTest(string expected)
        {
            var model = new CompletionList(new List<CompletionItem>() {
                new CompletionItem()
            {
                Kind = CompletionItemKind.Class,
                Detail = "details"
            } }, true);
            var result = Fixture.SerializeObject(model);

            result.Should().Be(expected);

            var deresult = new Serializer(ClientVersion.Lsp3).DeserializeObject<CompletionList>(expected);
            deresult.ShouldBeEquivalentTo(model);
        }
    }
}
