resource "azurerm_cosmosdb_account" "cosmodb_account" {
  name = "personalfinancescosmodbaccount${var.env_id}"
  resource_group_name = azurerm_resource_group.personal_finances_rg.name
  location = azurerm_resource_group.personal_finances_rg.location
  offer_type = "Standard"
  kind = "MongoDB"

  consistency_policy {
    consistency_level = "Session"
  }

  capabilities {
    name = "EnableMongo"
  }

  geo_location {
      location = azurerm_resource_group.personal_finances_rg.location
      failover_priority = 0
  }

  tags = {
    environment = var.env_id
    src = var.src_key
  }
}