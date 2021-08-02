using Domain.Catalog;
using Domain.Shared;
using Infrastructure;
using Infrastructure.Catalog;
using TechTalk.SpecFlow;
using Xunit;

namespace Behavior.Catalog.Test.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly CatalogService _catalogService = new(new ProductRepository(new DomainEventService()));
        private string _skuToFetch;
        private Product _result;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the SKU is (.*)")]
        public void GivenTheSkuIs(string sku)
        {
            _skuToFetch = sku; 
        }

        [When("the product is fetched")]
        public void WhenTheProductIsFetched()
        {
            _result = _catalogService.GetProduct(new Sku(_skuToFetch));
        }

        [Then("the result should be a product with SKU (.*)")]
        public void ThenTheResultShouldBeAProductWithSku(string sku)
        {
            Assert.Equal(_result.Sku.GetSku(), sku);
        }
    }
}