using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    [TestMethod("Deve retornar uma exceção quando a Url for inválida")]
    [TestCategory("Teste de Url")]
    [ExpectedException(typeof(InvalidUrlException))]
    public void ShouldReturnExceptionWhenUrlIsInvalid()
    {
        new Url("banana");
    }

    [TestMethod("Não deve retornar uma exceção quando a Url for válida")]
    [TestCategory("Teste de Url")]
    public void ShouldNotReturnExceptionWhenUrlIsValid()
    {
        new Url("https://balta.io");
        Assert.IsTrue(true);
    }
}
