resource "azurerm_cosmosdb_mongo_collection" "mongodb-collection" {
  name                = "PersonalFinancesAPIDB${var.env_id}"
  database_name       = "PersonalFinancesAPIDB"
  resource_group_name = azurerm_resource_group.personal_finances_rg.name
  account_name        = azurerm_cosmosdb_account.cosmodb_account.name

  throughput = 400

  index {
    keys = ["_id"] 
  }
}