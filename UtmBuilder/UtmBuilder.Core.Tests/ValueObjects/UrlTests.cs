using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    [TestMethod("Deve retornar uma exceção quando a Url for inválida")]
    [TestCategory("Teste de Url")]
    public void ShouldReturnExceptionWhenUrlIsInvalid()
    {
        try
        {
            var url = new Url("banana");
            Assert.Fail();
        }
        catch (InvalidUrlException e)
        {
            Assert.IsTrue(true);
        }
    }

    [TestMethod("Não deve retornar uma exceção quando a Url for válida")]
    [TestCategory("Teste de Url")]
    public void ShouldNotReturnExceptionWhenUrlIsValid()
    {
        Assert.Fail();
    }
}
