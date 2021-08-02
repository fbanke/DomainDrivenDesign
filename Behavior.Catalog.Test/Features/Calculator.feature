Feature: Catalog
Simple service for retrieving products by **SKU**

@catalog
Scenario: Get a product by SKU
	Given the SKU is 1
	When the product is fetched
	Then the result should be a product with SKU 1